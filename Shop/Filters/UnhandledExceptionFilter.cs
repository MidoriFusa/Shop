namespace Shop.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Filters;

    

    using Shop.Common;
    using Shop.Common.Errors;
    using Shop.Errors;

    /// <inheritdoc />
    /// <summary>
    /// The unhandled exception filter.
    /// </summary>
    public class UnhandledExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// The logger.
        /// </summary>
     

        /// <summary>
        /// Initializes a new instance of the <see cref="UnhandledExceptionFilter"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public UnhandledExceptionFilter()
        {
          

            this.Mappings = new Dictionary<Type, IError>
                                {
                                        { typeof(ArgumentNullException), new ArgumentNullError() },
                                        { typeof(ArgumentException), new ArgumentError() },
                                        { typeof(HttpResponseException), new ArgumentError() }
                                };
        }

        /// <summary>
        /// Gets the mappings.
        /// </summary>
        public Dictionary<Type, IError> Mappings { get; private set; }

        /// <summary>
        /// The on exception.
        /// </summary>
        /// <param name="actionExecutedContext">
        /// The context.
        /// </param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception == null)
            {
                return;
            }

            this.LogException(actionExecutedContext.Exception);
            this.CreateHttpError(actionExecutedContext, actionExecutedContext.Exception);
        }

        /// <summary>
        /// The create http error.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        private void CreateHttpError(HttpActionExecutedContext context, Exception exception)
        {
            if (this.Mappings.ContainsKey(exception.GetType()))
            {
                var error = new ApiError(HttpStatusCode.BadRequest, this.Mappings[exception.GetType()], null);
                error.Execute(context);
            }
            else
            {
               
                var error = new ApiError(HttpStatusCode.InternalServerError, new UnhandledError(), null);
                error.Execute(context);
            }
        }

        /// <summary>
        /// The log exception.
        /// </summary>
        /// <param name="exception">
        /// The exception.
        /// </param>
        private void LogException(Exception exception)
        {
            try
            {
               
            }
            catch
            {
                // Just suppress all exceptions.
            }
        }
    }
}