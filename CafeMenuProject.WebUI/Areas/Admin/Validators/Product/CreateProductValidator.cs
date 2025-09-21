using CafeMenuProject.WebUI.Areas.Admin.Models.Product;
using FluentValidation;

namespace CafeMenuProject.WebUI.Areas.Admin.Validators.Product
{
    public class CreateProductValidator : AbstractValidator<CreateProductModel>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.ProductName)
                .NotNull().WithMessage("Ürün adı boş olamaz.")
                .NotEmpty().WithMessage("Ürün adı boş olamaz.");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Fiyat sıfırdan büyük olmalı.")
                .NotNull().WithMessage("Fiyat sıfırdan büyük olmalı.")
                .GreaterThan(0).WithMessage("Fiyat sıfırdan büyük olmalı.");

            RuleFor(x => x.CategoryId)
                .NotNull().WithMessage("Lütfen kategori seçiniz.")
                .NotEmpty().WithMessage("Lütfen kategori seçiniz.")
                .GreaterThan(0).WithMessage("Lütfen kategori seçiniz.");
        }
    }
}
