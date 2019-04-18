namespace Shop.Common.Errors
{
    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// The remove user from roles error.
    /// </summary>
    public class RemoveUserFromRolesError : BaseError
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.RemoveUserFromRolesError" /> class.
        /// </summary>
        public RemoveUserFromRolesError() : this(new List<string> { "Remove user from role error" })
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.RemoveUserFromRolesError" /> class.
        /// </summary>
        /// <param name="errors">
        /// The errors.
        /// </param>
        public RemoveUserFromRolesError(IEnumerable<string> errors)
            : base(errors, ErrorCodes.RemoveUserFromRole)
        {
        }
    }
}
