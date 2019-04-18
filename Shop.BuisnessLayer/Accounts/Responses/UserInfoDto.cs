namespace Shop.BusinessLayer.Accounts.Responses
{
    using System.Collections.Generic;
    using System.Linq;

    using Shop.Identity;
    using Shop.Models;

    /// <summary>
    /// Information about user
    /// </summary>
    public class UserInfoDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfoDto"/> class.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="userRoles">
        /// The user roles.
        /// </param>
        /// <param name="companyId">
        /// The company Id.
        /// </param>
        public UserInfoDto(SystemUser user, List<Role> userRoles)
        {
            this.Id = user.Id;
            this.UserName = user.UserName;
            ////this.FirstName = user.FirstName;
            ////this.LastName = user.LastName;
            this.Email = user.Email;
          
            this.Roles = userRoles.Select(x => new RoleDto(x)).ToList();
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the company id.
        /// </summary>
      
        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        public List<RoleDto> Roles { get; set; }

        /// <summary>
        /// Dto for user role
        /// </summary>
        public class RoleDto
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="RoleDto"/> class. 
            /// </summary>
            public RoleDto()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="RoleDto"/> class. 
            /// </summary>
            /// <param name="role">
            /// </param>
            public RoleDto(Role role)
            {
                this.RoleId = role.RoleId;
                this.RoleName = role.RoleName;
            }

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
}