namespace Shop.Common.Errors
{
    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// The add password error.
    /// </summary>
    public class AddPasswordError : BaseError
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.AddPasswordError" /> class.
        /// </summary>
        public AddPasswordError() : this(new List<string> { "Add password error" })
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.AddPasswordError" /> class.
        /// </summary>
        /// <param name="errors">
        /// The errors.
        /// </param>
        public AddPasswordError(IEnumerable<string> errors)
            : base(errors, ErrorCodes.AddPassword)
        {
        }
    }
}
