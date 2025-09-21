using CafeMenuProject.WebUI.Areas.Admin.Models.Product;
using FluentValidation;

namespace CafeMenuProject.WebUI.Areas.Admin.Validators
{
    public class ProductValidator : AbstractValidator<CreateProductModel>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adı boş olamaz.");
            
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Fiyat sıfırdan büyük olmalı.");

            RuleFor(x => x.CategoryId)
                .NotNull().WithMessage("Lütfen kategori seçiniz.")
                .NotEmpty().WithMessage("Lütfen kategori seçiniz.")
                .GreaterThan(0).WithMessage("Lütfen kategori seçiniz.");
        }
    }
}
