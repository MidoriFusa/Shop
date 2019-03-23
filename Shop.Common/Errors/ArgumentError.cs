namespace Shop.Common.Errors
{
    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// The argument error.
    /// </summary>
    public class ArgumentError : BaseError
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.ArgumentError" /> class.
        /// </summary>
        public ArgumentError()
            : this(new List<string> { "Argument error" })
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.ArgumentError" /> class.
        /// </summary>
        /// <param name="errors">
        /// The errors.
        /// </param>
        public ArgumentError(IEnumerable<string> errors) : base(errors, ErrorCodes.Argument)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.ArgumentError" /> class.
        /// </summary>
        /// <param name="error">
        /// The error.
        /// </param>
        public ArgumentError(string error) : this(new List<string> { error })
        {
        }
    }
}