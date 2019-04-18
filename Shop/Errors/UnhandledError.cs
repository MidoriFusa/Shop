namespace Shop.Errors
{
    using System.Collections.Generic;

    using Shop.Common;
    using Shop.Common.Errors;

    /// <inheritdoc />
    /// <summary>
    /// The unhandled error.
    /// </summary>
    public class UnhandledError : BaseError
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Errors.UnhandledError" /> class.
        /// </summary>
        public UnhandledError() : base(new List<string> { "Internal error" }, (ErrorCodes)(-1))
        {
        }
    }
}