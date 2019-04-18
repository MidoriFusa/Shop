using Shop.Identity;

namespace Shop.BusinessLayer.Accounts.Commands
{
    /// <summary>
    /// The change password command.
    /// </summary>
    public class ChangePasswordCommand
    {
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public SystemUser User { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string NewPassword { get; set; }
    }
}
