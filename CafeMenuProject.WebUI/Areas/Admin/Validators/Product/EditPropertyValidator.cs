using CafeMenuProject.WebUI.Areas.Admin.Models.Product;
using FluentValidation;

namespace CafeMenuProject.WebUI.Areas.Admin.Validators.Product
{
    public class EditPropertyValidator : AbstractValidator<EditPropertyModel>
    {
        public EditPropertyValidator()
        {
            RuleFor(x => x.Key)
                .NotNull().WithMessage("Özellik adı boş olamaz.")
                .NotEmpty().WithMessage("Özellik adı boş olamaz.");

            RuleFor(x => x.Value)
                .NotNull().WithMessage("Özellik değeri boş olamaz.")
                .NotEmpty().WithMessage("Özellik değeri boş olamaz.");
        }
    }
}
