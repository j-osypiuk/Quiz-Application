﻿namespace QuizzApp.Model
{
    public class UserCredentials
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserAccount UserAccount { get; set; }
        public int UserAccountId { get; set; }
    }
}
