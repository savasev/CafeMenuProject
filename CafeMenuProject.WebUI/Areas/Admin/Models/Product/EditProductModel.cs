using System.Collections.Generic;
using System.Web.Mvc;

namespace CafeMenuProject.WebUI.Areas.Admin.Models.Product
{
    /// <summary>
    /// Edit product model
    /// </summary>
    public class EditProductModel
    {
        #region Constructor

        public EditProductModel()
        {
            AvailableCategories = new List<SelectListItem>();
            ProductPropertySearchModel = new ProductPropertySearchModel
            {
                PageSize = 20,
                ProductId = ProductId
            };
        }

        #endregion

        #region Properties

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public IList<SelectListItem> AvailableCategories { get; set; }

        public ProductPropertySearchModel ProductPropertySearchModel { get; set; }

        #endregion
    }
}
