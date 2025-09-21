using CafeMenuProject.WebUI.Areas.Admin.Models.Category;
using FluentValidation;

namespace CafeMenuProject.WebUI.Areas.Admin.Validators.Category
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryModel>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotNull().WithMessage("Kategori adı boş olamaz.")
                .NotEmpty().WithMessage("Kategori adı boş olamaz.");
        }
    }
}
