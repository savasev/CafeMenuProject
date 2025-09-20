using System.Collections.Generic;
using System.Web.Mvc;

namespace CafeMenuProject.WebUI.Areas.Admin.Models.Product
{
    /// <summary>
    /// Product search model
    /// </summary>
    public class ProductSearchModel : BaseSearchModel
    {
        #region Constructor

        public ProductSearchModel()
        {
            AvailableCategories = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public IList<SelectListItem> AvailableCategories { get; set; }

        #endregion
    }
}
