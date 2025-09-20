namespace CafeMenuProject.WebUI.Areas.Admin.Models
{
    /// <summary>
    /// Base search model
    /// </summary>
    public class BaseSearchModel
    {
        #region Properties

        public int Draw { get; set; } = 1;

        public int PageIndex { get; set; } = 0;

        public int PageSize { get; set; } = 10;

        #endregion
    }
}
