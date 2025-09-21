namespace CafeMenuProject.WebUI.Areas.Admin.Models.Product
{
    /// <summary>
    /// Create product property model
    /// </summary>
    public class CreateProductPropertyModel
    {
        #region Properties

        public int ProductId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        #endregion
    }
}
