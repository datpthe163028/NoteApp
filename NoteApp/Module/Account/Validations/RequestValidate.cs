using FluentValidation;
using NoteApp.Module.Account.Request;
using System;

namespace NoteApp.Module.Account.Validations
{
    public class AccountRequestValidate : AbstractValidator<AccountLoginRequest>
    {
        public AccountRequestValidate()
        {
            RuleFor(x => x.email)
            .NotEmpty().WithMessage("Email not empty")
            .EmailAddress().WithMessage("Email invalid");
        }
    }
}
