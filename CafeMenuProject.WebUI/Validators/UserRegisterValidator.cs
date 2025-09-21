using CafeMenuProject.WebUI.Models;
using FluentValidation;

namespace CafeMenuProject.WebUI.Validators
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterModel>
    {
        public UserRegisterValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Lütfen adınızı giriniz")
                .NotEmpty().WithMessage("Lütfen adınızı giriniz");

            RuleFor(x => x.Surname)
                .NotNull().WithMessage("Lütfen soyadınızı giriniz")
                .NotEmpty().WithMessage("Lütfen soyadınızı giriniz");

            RuleFor(x => x.Username)
                .NotNull().WithMessage("Lütfen kullanıcı adı giriniz")
                .NotEmpty().WithMessage("Lütfen kullanıcı adı giriniz");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("Lütfen şifre giriniz")
                .NotEmpty().WithMessage("Lütfen şifre giriniz");
        }
    }
}
