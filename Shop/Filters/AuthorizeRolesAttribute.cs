namespace Shop.Filters
{
    using System;
    using System.Web.Http;

    using Shop.Models;

    /// <summary>
    /// The authorize roles attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizeRolesAttribute"/> class.
        /// </summary>
        /// <param name="roles">
        /// The roles.
        /// </param>
        public AuthorizeRolesAttribute(params string[] roles)
        {
            this.Roles = string.Join(",", roles);
            this.Roles += "," + IdentityRoles.SuperUser;
        }
    }
}