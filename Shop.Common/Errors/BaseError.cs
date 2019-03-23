namespace Shop.Common.Errors
{
    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// The base error.
    /// </summary>
    public abstract class BaseError : IError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseError"/> class.
        /// </summary>
        /// <param name="errors">
        /// The errors.
        /// </param>
        /// <param name="errorCode">
        /// The error Code.
        /// </param>
        protected BaseError(IEnumerable<string> errors, ErrorCodes errorCode)
        {
            this.ErrorCode = errorCode;
            this.Errors = errors;
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the error code.
        /// </summary>
        public ErrorCodes ErrorCode { get; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the errors.
        /// </summary>
        public IEnumerable<string> Errors { get; }
    }
}