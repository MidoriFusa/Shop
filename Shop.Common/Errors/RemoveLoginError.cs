namespace Shop.Common.Errors
{
    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// The remove login error.
    /// </summary>
    public class RemoveLoginError : BaseError
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.RemoveLoginError" /> class.
        /// </summary>
        public RemoveLoginError() : this(new List<string> { "Remove login" })
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.RemoveLoginError" /> class.
        /// </summary>
        /// <param name="errors">
        /// The errors.
        /// </param>
        public RemoveLoginError(IEnumerable<string> errors)
            : base(errors, ErrorCodes.RemoveLogin)
        {
        }
    }
}
