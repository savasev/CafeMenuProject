using System.Collections.Generic;

namespace CafeMenuProject.WebUI.Areas.Admin.Models
{
    /// <summary>
    /// Data table result model
    /// </summary>
    public class DataTableResult<T>
    {
        #region Properties

        public int Draw { get; set; }

        public int RecordsTotal { get; set; }

        public int RecordsFiltered { get; set; }

        public List<T> Data { get; set; }

        #endregion
    }
}
