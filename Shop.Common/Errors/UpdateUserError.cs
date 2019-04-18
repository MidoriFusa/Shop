namespace Shop.Common.Errors
{
    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// The update user error.
    /// </summary>
    public class UpdateUserError : BaseError
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.UpdateUserError" /> class.
        /// </summary>
        public UpdateUserError() : this(new List<string> { "Update user error" })
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.UpdateUserError" /> class.
        /// </summary>
        /// <param name="errors">
        /// The errors.
        /// </param>
        public UpdateUserError(IEnumerable<string> errors)
            : base(errors, ErrorCodes.UpdateUser)
        {
        }
    }
}
