namespace Shop.Models
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The matrix roles.
    /// </summary>
    public class IdentityRoles
    {
        /// <summary>
        /// The Super User.
        /// </summary>
        public const string SuperUser = "SuperUser";

        public const string Driver = "Driver";
        public const string StoreKeeper = "StoreKeeper"; 
        /// <summary>
        /// The all roles.
        /// </summary>
        public static string[] AllRoles => new[] { SuperUser, Driver, StoreKeeper };

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        public List<Role> Roles { get; set; }
    }

    /// <summary>
    /// The role.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", 
        Justification = "Reviewed. Suppression is OK here.")]
    public class Role
    {
        /// <summary>
        /// Gets or sets the role id.
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// Gets or sets the role name.
        /// </summary>
        public string RoleName { get; set; }
    }
}