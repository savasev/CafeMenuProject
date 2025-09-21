namespace CafeMenuProject.WebUI.Areas.Admin.Models.User
{
    /// <summary>
    /// Edit user model
    /// </summary>
    public class EditUserModel
    {
        #region Properties

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        #endregion
    }
}
