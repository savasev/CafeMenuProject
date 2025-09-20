using Newtonsoft.Json;
using System.Collections;

namespace CafeMenuProject.WebUI.Areas.Admin.Models
{
    /// <summary>
    /// Data table result model
    /// </summary>
    public class DataTableResult
    {
        #region Properties

        [JsonProperty("draw")]
        public int Draw { get; set; }

        [JsonProperty("recordsTotal")]
        public int RecordsTotal { get; set; }

        [JsonProperty("recordsFiltered")]
        public int RecordsFiltered { get; set; }

        [JsonProperty("data")]
        public IEnumerable Data { get; set; }

        #endregion
    }
}
