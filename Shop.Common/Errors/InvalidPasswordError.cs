namespace Shop.Common.Errors
{
    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// InvalidPasswordError
    /// </summary>
    public class InvalidPasswordError : BaseError
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.InvalidPasswordError" /> class.
        /// </summary>
        public InvalidPasswordError() : this(new List<string> { "InvalidPassword" })
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.InvalidPasswordError" /> class.
        /// </summary>
        /// <param name="errors">
        /// The errors.
        /// </param>
        public InvalidPasswordError(IEnumerable<string> errors)
            : base(errors, ErrorCodes.InvalidPassword)
        {
        }
    }
}