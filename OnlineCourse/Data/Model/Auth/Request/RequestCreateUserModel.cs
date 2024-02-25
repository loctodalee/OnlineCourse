namespace OnlineCourse.Data.Model.Auth.Request
{
    public class RequestCreateUserModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public bool Sex { get; set; }

        public DateTime DOB { get; set; }

        public string? Nationality { get; set; }
    }
}
