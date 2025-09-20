using System.Collections.Generic;
using System.Web.Mvc;

namespace CafeMenuProject.WebUI.Areas.Admin.Models.Categories
{
    public class CreateCategoryModel
    {
        #region Ctor

        public CreateCategoryModel()
        {
            AvailableParentCategories = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        public string CategoryName { get; set; }

        public int? ParentCategoryId { get; set; }

        public IList<SelectListItem> AvailableParentCategories { get; set; }

        #endregion
    }
}
