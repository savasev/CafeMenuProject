using System.Collections.Generic;
using System.Web.Mvc;

namespace CafeMenuProject.WebUI.Areas.Admin.Models.Product
{
    /// <summary>
    /// Create product model
    /// </summary>
    public class CreateProductModel
    {
        #region Constructor

        public CreateProductModel()
        {
            AvailableCategories = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public IList<SelectListItem> AvailableCategories { get; set; }

        #endregion
    }
}
