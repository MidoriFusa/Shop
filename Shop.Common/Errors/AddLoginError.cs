namespace Shop.Common.Errors
{
    using System.Collections.Generic;

    using Shop.Common;

    /// <inheritdoc />
    /// <summary>
    /// The add login error.
    /// </summary>
    public class AddLoginError : BaseError
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.AddLoginError" /> class.
        /// </summary>
        public AddLoginError() : this(new List<string> { "Add login error" })
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.AddLoginError" /> class.
        /// </summary>
        /// <param name="errors">
        /// The errors.
        /// </param>
        public AddLoginError(IEnumerable<string> errors)
            : base(errors, ErrorCodes.AddLogin)
        {
        }
    }
}
