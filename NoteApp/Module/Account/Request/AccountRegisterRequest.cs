namespace NoteApp.Module.Account.Request
{
    public class AccountRegisterRequest
    {
    }

    public class AccountLoginRequest
    {
        public string? email { get; set; }
        public string? password { get; set; }
    }
}
