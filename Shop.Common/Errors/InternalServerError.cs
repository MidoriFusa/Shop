namespace Shop.Common.Errors
{
    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// The internal server error.
    /// </summary>
    public class InternalServerError : BaseError
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.InternalServerError" /> class.
        /// </summary>
        public InternalServerError()
            : this(new List<string> { "Internal server error" })
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.InternalServerError" /> class.
        /// </summary>
        /// <param name="errors">
        /// The errors.
        /// </param>
        public InternalServerError(IEnumerable<string> errors)
            : base(errors, ErrorCodes.InternalServerError)
        {
        }
    }
}