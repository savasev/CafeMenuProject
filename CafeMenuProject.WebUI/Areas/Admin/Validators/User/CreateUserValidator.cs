using CafeMenuProject.WebUI.Areas.Admin.Models.User;
using FluentValidation;

namespace CafeMenuProject.WebUI.Areas.Admin.Validators.User
{
    public class CreateUserValidator : AbstractValidator<CreateUserModel>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Ad zorunludur")
                .NotEmpty().WithMessage("Ad zorunludur");

            RuleFor(x => x.Surname)
                .NotNull().WithMessage("Soyad zorunludur")
                .NotEmpty().WithMessage("Soyad zorunludur");

            RuleFor(x => x.Username)
                .NotNull().WithMessage("Kullanıcı adı zorunludur")
                .NotEmpty().WithMessage("Kullanıcı adı zorunludur");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("Şifre zorunludur")
                .NotEmpty().WithMessage("Şifre zorunludur");
        }
    }
}
