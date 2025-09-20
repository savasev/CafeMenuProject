using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace CafeMenuProject.WebUI.Infrastructure
{
    /// <summary>
    /// Json camel case result
    /// </summary>
    public class JsonCamelCaseResult : ActionResult
    {
        #region Properties

        public object Data { get; set; }

        public JsonRequestBehavior JsonRequestBehavior { get; set; } = JsonRequestBehavior.DenyGet;

        #endregion

        #region Methods

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            var response = context.HttpContext.Response;
            response.ContentType = "application/json";

            if (Data != null)
            {
                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
                };

                var json = JsonConvert.SerializeObject(Data, settings);
                response.Write(json);
            }
        }

        #endregion
    }
}
