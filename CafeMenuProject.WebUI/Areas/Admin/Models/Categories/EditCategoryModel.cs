using System.Collections.Generic;
using System.Web.Mvc;

namespace CafeMenuProject.WebUI.Areas.Admin.Models.Categories
{
    /// <summary>
    /// Edit category model
    /// </summary>
    public class EditCategoryModel
    {
        #region Ctor

        public EditCategoryModel()
        {
            AvailableParentCategories = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int? ParentCategoryId { get; set; }

        public IList<SelectListItem> AvailableParentCategories { get; set; }

        #endregion
    }
}
