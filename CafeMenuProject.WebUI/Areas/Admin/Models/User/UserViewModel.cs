namespace CafeMenuProject.WebUI.Areas.Admin.Models.User
{
    /// <summary>
    /// User view model
    /// </summary>
    public class UserViewModel
    {
        #region Properties

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        #endregion
    }
}
