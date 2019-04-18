namespace Shop.BusinessLayer.Accounts.Commands
{
    /// <summary>
    /// The register command.
    /// </summary>
    public class RegisterCommand
    {
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the company id.
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        public string[] Roles { get; set; }
    }
}