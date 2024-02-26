using Microsoft.IdentityModel.Tokens;
using OnlineCourse.Data.Entity.Auth;
using OnlineCourse.Data.Model.Auth.Request;
using OnlineCourse.Data.Model.Auth.Response;
using OnlineCourse.Repository;
using OnlineCourse.Services.Auth.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineCourse.Services.Auth
{
    public class AuthenticationService : IAuthenticationService
    {
        private static IConfiguration configuration1 = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("SecurityKey");

        private readonly string Key = configuration1.ToString();

        private IUnitOfWork _unitOfWork;

        public AuthenticationService(IServiceProvider serviceProvider)
        {
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }

        public async Task<ResponseLoginModel> Authenticator(RequestLoginModel model)
        {
            try
            {
                var listUser = await _unitOfWork.UserRepository.GetAll();
                var account = listUser.Where(x => x.Account == model.Account && x.Password == model.Password).FirstOrDefault();

                if (account == null)
                {
                    throw new Exception("Account not found");
                }

                var token = CreateJwtToken(account);
                var refreshTokens = await CreateRefreshToken(account);
                var result = new ResponseLoginModel()
                {
                    FullName = account.FirstName + account.LastName,
                    UserId = account.Id,
                    Token = await token,
                    RefreshToken = refreshTokens.Token
                }; 
                return result;

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseLoginModel> RefreshToken(string token)
        {
            var listToken = await _unitOfWork.RefreshTokensRepository.GetAll();
            var validateToken = listToken.Where(x => x.Token == token && x.Expires < DateTime.UtcNow && x.IsActive == true).FirstOrDefault();
            if(validateToken == null)
            {
                throw new Exception("Refresh Token is unvalid");
            }
            validateToken.IsActive = false;
            var user = await _unitOfWork.UserRepository.GetSingleById(validateToken.UserId);
            var jwtToken = CreateJwtToken(user);
            var newRefreshToken = await CreateRefreshToken(user);
            var result = new ResponseLoginModel()
            {
                FullName = user.FirstName + user.LastName,
                UserId = user.Id,
                RefreshToken = newRefreshToken.Token,
                Token = await jwtToken,
            };
            await _unitOfWork.RefreshTokensRepository.Add(newRefreshToken);
            _unitOfWork.SaveChanges();
            return result;
        }

        public async Task<RefreshTokens> CreateRefreshToken(UserEntity account)
        {
            try
            {
                var randomBytes = new byte[64];
                var token = Convert.ToBase64String(randomBytes);
                var refreshToken = new RefreshTokens
                {
                    UserId = account.Id,
                    Expires = DateTime.UtcNow.AddDays(1),
                    IsActive = true,
                    Token = token
                };
                var user = _unitOfWork.UserRepository.GetSingleById(refreshToken.Id);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                await _unitOfWork.RefreshTokensRepository.Add(refreshToken);
                _unitOfWork.SaveChanges();
                return refreshToken;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> CreateJwtToken(UserEntity account)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(Key);
                var sercurityKey = new SymmetricSecurityKey(key);
                var credential = new SigningCredentials(sercurityKey, SecurityAlgorithms.HmacSha256);
                var listRole = await _unitOfWork.UserPerRepository.GetAll();
                var role = listRole.Where(x => x.UserId ==  account.Id).FirstOrDefault();
                var tokenDescription = new SecurityTokenDescriptor
                {
                    Audience = "",
                    Issuer = "",
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name, account.FirstName + " " + account.LastName),
                    new Claim(ClaimTypes.Email, account.Email),
                    new Claim("PhoneNumber", account.PhoneNumber),
                    new Claim(ClaimTypes.Gender, account.Sex ? "Male" : "Female"),
                    new Claim("Nationality", account.Nationality)
                }),
                    
                Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = credential
                };
                // Get All Action On Permission
                var permissionActionList = await _unitOfWork.PerActionRepository.GetAll();

                // Get Permission Name use for role name
                var permissionList = await _unitOfWork.PermissionRepository.GetAll();
                var permissionName = permissionList.Where(x => x.Id == role.PermissionId).FirstOrDefault();
                tokenDescription.Subject.AddClaim(new Claim("authorize", permissionName.Name));

                // Get List of Action Id prepare for get action name
                var listAcionId = new List<string>();
                foreach (var x in  permissionActionList)
                {
                    if(x.PermissionId == role.PermissionId)
                    {
                        listAcionId.Add(x.ActionId);
                    }
                }
                
                // Get Action name
                var actionList = await _unitOfWork.ActionRepository.GetAll();
                foreach (var x in listAcionId)
                {
                    foreach(var y in actionList)
                    {
                        if(x == y.Id)
                        {
                            tokenDescription.Subject.AddClaim(new Claim(ClaimTypes.Role, y.Name));
                        }
                    }
                }
                //foreach (var role in roles)
                //    tokenDescription.Subject.AddClaim(new Claim(ClaimTypes.Role, role.PermissionId));
                var token = tokenHandler.CreateToken(tokenDescription);
                return tokenHandler.WriteToken(token);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
