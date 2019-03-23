namespace Shop.Common.Errors
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The exception error.
    /// </summary>
    public class ExceptionError : BaseError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionError"/> class.
        /// </summary>
        public ExceptionError()
            : this(new Exception("Exception error"))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionError"/> class.
        /// </summary>
        /// <param name="exception">
        /// The exception.
        /// </param>
        public ExceptionError(Exception exception)
            : base(new List<string> { exception.Message, exception.ToString() }, ErrorCodes.Exception)
        {
        }
    }
}