﻿namespace NoteApp.Module.Account.Request
{
    public class AccountRegisterRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string RePassword { get; set; }

        public int UniversityId { get; set; }
        public int MajorId { get; set; }
        public int SemesterId { get; set; }
    }

    public class AccountLoginRequest
    {
        public string? email { get; set; }
        public string? password { get; set; }
    }
}
