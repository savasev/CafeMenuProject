using System;
using System.Web.Mvc;

namespace CafeMenuProject.WebUI.Filters
{
    /// <summary>
    /// Parameter based on form name attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ParameterBasedOnFormNameAttribute : ActionFilterAttribute
    {
        #region Fields

        private readonly string _formKeyName;
        private readonly string _actionParameterName;

        #endregion

        #region Constructor

        public ParameterBasedOnFormNameAttribute(string formKeyName, string actionParameterName)
        {
            _formKeyName = formKeyName ?? throw new ArgumentNullException(nameof(formKeyName));
            _actionParameterName = actionParameterName ?? throw new ArgumentNullException(nameof(actionParameterName));
        }

        #endregion

        #region Methods

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException(nameof(filterContext));

            // Form collectiondan key var mı diye kontrol et
            bool keyExists = filterContext.HttpContext.Request.Form[_formKeyName] != null;

            // Action parametrelerine ata
            if (filterContext.ActionParameters.ContainsKey(_actionParameterName))
            {
                filterContext.ActionParameters[_actionParameterName] = keyExists;
            }

            base.OnActionExecuting(filterContext);
        }

        #endregion
    }
}
