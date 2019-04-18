namespace Shop.Identity
{
    using Shop.Models;
    using System.Collections.Generic;

    /// <summary>
    /// The user roles comparer.
    /// </summary>
    public class UserRolesComparer : IComparer<Role>
    {
        /// <summary>
        /// The all sorted roles.
        /// </summary>
        private readonly List<string> allSortedRoles = new List<string>
                                                           {
                                                               IdentityRoles.SuperUser,
                                                               IdentityRoles.Driver,
                                                               IdentityRoles.StoreKeeper
                                                              
                                                           };

        /// <summary>
        /// The compare.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <param name="y">
        /// The y.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int Compare(Role x, Role y)
        {
            var index1 = this.allSortedRoles.IndexOf(x.RoleName);
            var index2 = this.allSortedRoles.IndexOf(y.RoleName);

            return index1.CompareTo(index2);
        }
    }
}
