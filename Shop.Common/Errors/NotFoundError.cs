namespace Shop.Common.Errors
{
    using System.Collections.Generic;

    /// <summary>
    /// The not found error.
    /// </summary>
    public class NotFoundError : BaseError
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.NotFoundError" /> class.
        /// </summary>
        public NotFoundError() : this(new List<string> { "Not found error" })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundError"/> class.
        /// </summary>
        /// <param name="error">
        /// The error.
        /// </param>
        public NotFoundError(string error) : this(new List<string> { error})
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.NotFoundError" /> class.
        /// </summary>
        /// <param name="errors">
        /// The errors.
        /// </param>
        public NotFoundError(IEnumerable<string> errors)
            : base(errors, ErrorCodes.NotFound)
        {
        }
    }
}