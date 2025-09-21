namespace CafeMenuProject.WebUI.Areas.Admin.Models.Product
{
    /// <summary>
    /// Edit product property model
    /// </summary>
    public class EditProductPropertyModel
    {
        #region Properties

        public int ProductPropertyId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        #endregion
    }
}
