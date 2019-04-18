namespace Shop.Common.Errors
{
    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// The user already exists error.
    /// </summary>
    public class UserAlreadyExistsError : BaseError
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.UserAlreadyExistsError" /> class.
        /// </summary>
        public UserAlreadyExistsError() : this(new List<string>{ "User already exists" })
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.UserAlreadyExistsError" /> class.
        /// </summary>
        /// <param name="errors">
        /// The errors.
        /// </param>
        public UserAlreadyExistsError(IEnumerable<string> errors)
            : base(errors, ErrorCodes.UserAlreadyExists)
        {
        }
    }
}