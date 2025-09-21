namespace CafeMenuProject.WebUI.Areas.Admin.Models.Product
{
    /// <summary>
    /// Property view model
    /// </summary>
    public class ProductPropertyViewModel
    {
        #region Properties

        public int ProductPropertyId { get; set; }

        public int PropertyId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        #endregion
    }
}
