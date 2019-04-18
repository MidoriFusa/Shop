namespace Shop.Identity
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The matrix user.
    /// </summary>
    public class SystemUser
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password reset token.
        /// </summary>
        public string PasswordResetToken { get; set; }

        /// <summary>
        /// Gets or sets the hash password.
        /// </summary>
        public string HashPassword { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        public string FullName => $"{this.FirstName} {this.LastName}";

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        public IEnumerable<string> Roles { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the encrypted password.
        /// </summary>
        public byte[] EncryptedPassword { get; set; }

        /// <summary>
        /// Gets or sets the company id.
        /// </summary>
        public int? CompanyId { get; set; }
    }
}