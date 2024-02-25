using OnlineCourse.Data.Model.Email;

namespace OnlineCourse.Services.Email.Interface
{
    public interface IEmailService
    {
        void SendMail(SendMailModel model);
    }
}
