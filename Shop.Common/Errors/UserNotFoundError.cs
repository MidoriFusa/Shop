namespace Shop.Common.Errors
{
    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// The user not found error.
    /// </summary>
    public class UserNotFoundError : BaseError
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.UserNotFoundError" /> class.
        /// </summary>
        public UserNotFoundError() : this(new List<string> { "User not found error" })
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.UserNotFoundError" /> class.
        /// </summary>
        /// <param name="errors">
        /// The errors.
        /// </param>
        public UserNotFoundError(IEnumerable<string> errors)
            : base(errors, ErrorCodes.UserNotFound)
        {
        }
    }
}