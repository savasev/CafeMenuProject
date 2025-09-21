namespace CafeMenuProject.WebUI.Areas.Admin.Models.User
{
    /// <summary>
    /// Create user model
    /// </summary>
    public class CreateUserModel
    {
        #region Properties

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        #endregion
    }
}
