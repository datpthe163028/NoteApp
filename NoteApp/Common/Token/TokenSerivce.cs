namespace NoteApp.Common.Token
{
    public class TokenSerivce
    {
        public static string GenerateVerificationToken()
        {
         
            return Guid.NewGuid().ToString();
        }
    }
}
