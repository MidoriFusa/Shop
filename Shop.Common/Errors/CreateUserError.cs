namespace Shop.Common.Errors
{
    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// The create user error.
    /// </summary>
    public class CreateUserError : BaseError
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.CreateUserError" /> class.
        /// </summary>
        public CreateUserError() : this(new List<string> { "Crete user error" })
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.CreateUserError" /> class.
        /// </summary>
        /// <param name="errors">
        /// The errors.
        /// </param>
        public CreateUserError(IEnumerable<string> errors)
            : base(errors, ErrorCodes.CreateUser)
        {
        }
    }
}
