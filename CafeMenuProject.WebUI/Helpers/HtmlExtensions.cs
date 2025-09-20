using System.Linq;
using System.Web.Mvc;

namespace CafeMenuProject.WebUI.Helpers
{
    /// <summary>
    /// Html extensions
    /// </summary>
    public static class HtmlExtensions
    {
        #region Methods

        public static string IsActive(this HtmlHelper html,
                      string control = null,
                      string action = null,
                      string area = null,
                      string cssClass = "active")
        {
            var routeData = html.ViewContext.RouteData;

            var routeControl = (string)routeData.Values["controller"];
            var routeAction = (string)routeData.Values["action"];
            var routeArea = (string)html.ViewContext.RouteData.DataTokens["area"];

            var controlMatch = (string.IsNullOrEmpty(control) || control == routeControl);
            var actionMatch = (string.IsNullOrEmpty(action) || action == routeAction);
            var areaMatch = (string.IsNullOrEmpty(area) || area == routeArea);

            return (controlMatch && actionMatch && areaMatch) ? cssClass : string.Empty;
        }

        public static string IsMenuOpen(this HtmlHelper html, string[] controllers, string area = null)
        {
            var routeData = html.ViewContext.RouteData;
            var routeControl = (string)routeData.Values["controller"];
            var routeArea = (string)html.ViewContext.RouteData.DataTokens["area"];

            var controlMatch = controllers.Contains(routeControl);
            var areaMatch = (string.IsNullOrEmpty(area) || area == routeArea);

            return (controlMatch && areaMatch) ? "menu-open" : string.Empty;
        }

        #endregion
    }
}
