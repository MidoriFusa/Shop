namespace Shop.Common.Errors
{
    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// The argument null error.
    /// </summary>
    public class ArgumentNullError : BaseError
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SecurityFirms.Common.Errors.ArgumentNullError" /> class.
        /// </summary>
        public ArgumentNullError()
            : base(new List<string> { "Argument null error" }, ErrorCodes.ArgumentNull)
        {
        }
    }
}