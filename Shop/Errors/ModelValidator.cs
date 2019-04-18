namespace Shop.Errors
{
    using System.Linq;
    using System.Net;
    using System.Web.Http.Controllers;

    using Shop.Common.Errors;

    /// <summary>
    /// Model validator
    /// </summary>
    public class ModelValidator
    {
        /// <summary>
        /// Model validation
        /// </summary>
        /// <param name="actionContext">
        /// The action Context.
        /// </param>
        public static void Validate(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                var errorMessage = actionContext.ModelState.Values.First(v => v.Errors.Any()).Errors.FirstOrDefault(e => !string.IsNullOrWhiteSpace(e.ErrorMessage));
                var message = errorMessage == null
                                     ? actionContext.ModelState.Values.First(v => v.Errors.Any()).Errors.First().Exception
                                         .Message
                                     : errorMessage.ErrorMessage;
                var error = new ApiError(HttpStatusCode.BadRequest, new ArgumentError(message), null);
                error.Execute(actionContext);
            }

            if (actionContext.ActionArguments.ContainsValue(null))
            {
                var error = new ApiError(HttpStatusCode.BadRequest, new ArgumentError("Model is required"), null);
                error.Execute(actionContext);
            }
        }
    }
}