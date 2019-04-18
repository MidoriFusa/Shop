namespace Shop.Filters
{
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    using Shop.Errors;

    /// <summary>
    /// Validation attribute
    /// </summary>
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        /// <inheritdoc />
        /// <summary>
        /// Occurs before the action method is invoked.
        /// </summary>
        /// <param name="actionContext">
        /// The action context.
        /// </param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            ModelValidator.Validate(actionContext);
        }
    }
}