using CafeMenuProject.Core.Entities;
using System;
using System.Web;
using System.Web.Security;

namespace CafeMenuProject.WebUI.Helpers
{
    /// <summary>
    /// Auth helper
    /// </summary>
    public static class AuthHelper
    {
        #region Methods

        public static void SignIn(User user, bool isPersistent = true, int expireHours = 2)
        {
            var userData = $"{user.UserId}|{user.Username}|{user.Name}|{user.Surname}";

            var ticket = new FormsAuthenticationTicket(version: 1,
                name: user.Username,
                issueDate: DateTime.Now,
                expiration: DateTime.Now.AddHours(2),
                isPersistent: true,
                userData: userData,
                cookiePath: FormsAuthentication.FormsCookiePath);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket))
            {
                HttpOnly = true,
                Expires = ticket.Expiration
            };

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public static (int userId, string username, string fullName)? GetCurrentUser()
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
                return null;

            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
            if (ticket == null)
                return null;

            var parts = ticket.UserData.Split('|');
            if (parts.Length != 2)
                return null;

            if (!int.TryParse(parts[0], out int userId))
                return null;

            var username = parts[1];
            var fullName = $"{parts[2]} {parts[3]}";

            return (userId, username, fullName);
        }

        #endregion
    }
}
