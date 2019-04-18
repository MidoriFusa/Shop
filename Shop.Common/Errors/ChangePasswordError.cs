namespace Shop.Common.Errors
{
    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// The change password error.
    /// </summary>
    public class ChangePasswordError : BaseError
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.ChangePasswordError" /> class.
        /// </summary>
        public ChangePasswordError() : this(new List<string> { "ChangePassword" })
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.ChangePasswordError" /> class.
        /// </summary>
        /// <param name="errors">
        /// The errors.
        /// </param>
        public ChangePasswordError(IEnumerable<string> errors)
            : base(errors, ErrorCodes.ChangePassword)
        {
        }
    }
}
