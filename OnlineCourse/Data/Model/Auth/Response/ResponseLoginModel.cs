﻿namespace OnlineCourse.Data.Model.Auth.Response
{
    public class ResponseLoginModel
    {
        public string FullName { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
