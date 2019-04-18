namespace Shop.Common.Errors
{
    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// The add user to roles error.
    /// </summary>
    public class AddUserToRolesError : BaseError
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.AddUserToRolesError" /> class.
        /// </summary>
        public AddUserToRolesError() : this(new List<string> { "AddUserToRole" })
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.AddUserToRolesError" /> class.
        /// </summary>
        /// <param name="errors">
        /// The errors.
        /// </param>
        public AddUserToRolesError(IEnumerable<string> errors)
            : base(errors, ErrorCodes.AddUserToRole)
        {
        }
    }
}
