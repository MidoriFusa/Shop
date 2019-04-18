namespace Shop.Errors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using Shop.Common;

    /// <inheritdoc />
    /// <summary>
    /// Error Codes Attribute
    /// </summary>
    public class ResponseErrorAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseErrorAttribute"/> class.
        /// </summary>
        /// <param name="errors">
        /// The errors.
        /// </param>
        public ResponseErrorAttribute(params Type[] errors)
        {
            this.ResponseError = errors.Select(a => new ApiError(HttpStatusCode.BadRequest, (IError)Activator.CreateInstance(a), null)).ToArray();
        }

        /// <summary>
        /// Gets the response error.
        /// </summary>
        public IEnumerable<ApiError> ResponseError { get; }
    }
}