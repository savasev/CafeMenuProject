namespace CafeMenuProject.WebUI.Areas.Admin.Models.Category
{
    /// <summary>
    /// Category with product count model
    /// </summary>
    public class CategoryWithProductCountModel
    {
        #region Properties

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int TotalProductCount { get; set; }

        #endregion
    }
}
