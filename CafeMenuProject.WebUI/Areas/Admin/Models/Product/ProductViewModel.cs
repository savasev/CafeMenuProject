using System;

namespace CafeMenuProject.WebUI.Areas.Admin.Models.Product
{
    /// <summary>
    /// Product view model
    /// </summary>
    public class ProductViewModel
    {
        #region Properties

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public string CreatedDate { get; set; }

        #endregion
    }
}
