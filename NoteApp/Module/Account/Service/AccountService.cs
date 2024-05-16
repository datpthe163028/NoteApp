using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.UnitOfWork;
using NoteApp.Module.Account.Request;

namespace NoteApp.Module.Account.Service
{
    public interface IAccountService
    {
        Task<(User Account, string ErrorMessage)> RegisterAsync(AccountRegisterRequest account);
    }

    public class AccountService : IAccountService
    {
        private readonly UnitOfWork _unitOfWork;

        public AccountService (UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public Task<(User Account, string ErrorMessage)> RegisterAsync(AccountRegisterRequest account)
        {
            throw new NotImplementedException();
        }

    }
}
