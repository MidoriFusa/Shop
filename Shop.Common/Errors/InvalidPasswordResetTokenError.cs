namespace Shop.Common.Errors
{
    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// The invalid password reset token error.
    /// </summary>
    public class InvalidPasswordResetTokenError : BaseError
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.InvalidPasswordResetTokenError" /> class.
        /// </summary>
        public InvalidPasswordResetTokenError() : this(new List<string> { "Invalid password reset token" })
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.InvalidPasswordResetTokenError" /> class.
        /// </summary>
        /// <param name="errors">
        /// The errors.
        /// </param>
        public InvalidPasswordResetTokenError(IEnumerable<string> errors)
            : base(errors, ErrorCodes.InvalidPasswordResetToken)
        {
        }
    }
}