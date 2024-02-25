using Nelibur.ObjectMapper;
using OnlineCourse.Data.Entity.Auth;
using OnlineCourse.Data.Model.Auth;
using OnlineCourse.Data.Model.Auth.Request;
using OnlineCourse.Data.Model.Email;
using OnlineCourse.Repository;
using OnlineCourse.Services.Auth.Interface;
using OnlineCourse.Services.Email.Interface;
using OnlineCourse.Util;
using System.Data;

namespace OnlineCourse.Services.Auth
{
    public class UserService : IUserService
    {
        private IUnitOfWork unitOfWork;
        private IEmailService emailService;
        private IUtilService utilService;
        public UserService(IServiceProvider serviceProvider)
        {
            unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            emailService = serviceProvider.GetRequiredService<IEmailService>();
            utilService = serviceProvider.GetRequiredService<IUtilService>();
        }

        public async Task<List<UserModel>> GetUsers()
        {
            try
            {
                var users = await unitOfWork.UserRepository.GetAll();
                var validUsers = users.Where(i => i.IsActive == true).ToList();
                var usersModel = TinyMapper.Map<List<UserModel>>(validUsers);
                return usersModel;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserModel> CreateUser(RequestCreateUserModel model)
        {
            try
            {
                var users = await unitOfWork.UserRepository.GetAll();
                var existedUser = users.Where(x => x.IsActive == true && 
                (x.Account == model.Account || x.Email == model.Email || x.PhoneNumber == model.PhoneNumber)).FirstOrDefault();
                if(existedUser != null)
                {
                    throw new Exception("User is existed !!");
                }

                var entity = TinyMapper.Map<UserEntity>(model);
                await unitOfWork.UserRepository.Add(entity);
                var resModel = TinyMapper.Map<UserModel>(entity);
                unitOfWork.SaveChanges();
                return resModel;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<UserModel> GetUserById(string id)
        {
            try
            {
               var user = await unitOfWork.UserRepository.GetSingleById(id);
               if(user.IsActive == true)
               {
                    var model = TinyMapper.Map<UserModel>(user);
                    return model;
               }
                throw new Exception("Id not found");
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserModel> RegisterUser(RequestCreateUserModel model)
        {
            try
            {
                var users = await unitOfWork.UserRepository.GetAll();
                var existedUser = users.Where(x => x.IsActive == true &&
                (x.Account == model.Account || x.Email == model.Email || x.PhoneNumber == model.PhoneNumber)).FirstOrDefault();
                if (existedUser != null)
                {
                    throw new Exception("User is existed !!");
                }

                var entity = TinyMapper.Map<UserEntity>(model);
                var verifyToken = utilService.GenerateRandomNumber();
                entity.VerifyToken = verifyToken;
                entity.IsActive = false;
                await unitOfWork.UserRepository.Add(entity);
                // save change
                unitOfWork.SaveChanges();
                //send mail
                var sendMail = new SendMailModel
                {
                    Sbuject = "Verify your account for Online Course",
                    Content = "Your verify code is: " + verifyToken,
                    ReceiveAddress = entity.Email
                };
                emailService.SendMail(sendMail);
                var resModel = TinyMapper.Map<UserModel>(entity);
                return resModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task VerifyEmail(RequestVerifyModel model)
        {
            try
            {
                var user = await unitOfWork.UserRepository.GetSingleById(model.UserId);
                if (user == null)
                {
                    throw new Exception("User Not Existed");
                }
                if (user.VerifyToken != model.Otp)
                {
                    throw new Exception("Wrong verify code");
                }
                user.VerifyToken = null;
                user.IsActive = true;
                unitOfWork.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateUser(UserModel model)
        {
            try
            {
                var entity = TinyMapper.Map<UserEntity>(model);
                await unitOfWork.UserRepository.Update(entity);
                unitOfWork.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteUser(string id)
        {
            try
            {
                var existed = await unitOfWork.UserRepository.GetSingleById(id);
                if(existed == null)
                {
                    throw new Exception("User not found");
                }
                await unitOfWork.UserRepository.Delete(existed);
                unitOfWork.SaveChanges();
            }
            catch (ConstraintException ex)
            {
                throw new Exception("Contraint: \n" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
