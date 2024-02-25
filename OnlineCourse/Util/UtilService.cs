namespace OnlineCourse.Util
{
    public interface IUtilService
    {
        string GenerateRandomNumber();
    }
    public class UtilService : IUtilService
    {
        public string GenerateRandomNumber()
        {
            // Create an instance of Random class
            Random random = new Random();

            // Generate a 6-digit random number
            int randomNumber = random.Next(100000, 999999);

            // Convert the number to a string
            string randomString = randomNumber.ToString();

            return randomString;
        }
    }
}
