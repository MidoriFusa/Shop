namespace Shop.Identity
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Globalization;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Shop.DataLayer;
    using Shop.Models.Database;

    /// <summary>
    /// The asp net identity storage.
    /// </summary>
    public class AspNetIdentityStorage : IIdentityStorage
    {
        /// <summary>
        /// The role manager.
        /// </summary>
        private readonly RoleManager<IdentityRole> roleManager;

        /// <summary>
        /// The user manager.
        /// </summary>
        private readonly UserManager<User> userManager;

        /// <summary>
        /// Initializes static members of the <see cref="AspNetIdentityStorage"/> class.
        /// </summary>
        static AspNetIdentityStorage()
        {
            UserManagerFactory = () =>
                {
                    var um = new UserManager<User>(new UserStore<User>(new dbcont()));
                    return um;
                };

            RoleManagerFactory =
                () => new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new dbcont()));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AspNetIdentityStorage"/> class.
        /// </summary>
        public AspNetIdentityStorage()
        {
            this.userManager = UserManagerFactory();
            this.roleManager = RoleManagerFactory();
            this.userManager.UserValidator = new UserValidator<User>(this.userManager)
                                                 {
                                                     AllowOnlyAlphanumericUserNames = false
                                                 };

            this.userManager.PasswordValidator = new PasswordValidator
                                                     {
                                                         RequireDigit = true,
                                                         RequiredLength = 8,
                                                         RequireUppercase = true,
                                                         RequireLowercase = true,
                                                         RequireNonLetterOrDigit = true
                                                     };
        }

        /// <summary>
        /// Gets the user manager.
        /// </summary>
        public UserManager<User> UserManager
        {
            get
            {
                return this.userManager;
            }
        }

        /// <summary>
        /// Gets or sets the role manager factory.
        /// </summary>
        private static Func<RoleManager<IdentityRole>> RoleManagerFactory { get; set; }

        /// <summary>
        /// Gets or sets the user manager factory.
        /// </summary>
        private static Func<UserManager<User>> UserManagerFactory { get; set; }

        /// <summary>
        /// The add login.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="login">
        /// The login.
        /// </param>
        /// <returns>
        /// The <see cref="IdentityResult"/>.
        /// </returns>
        public IdentityResult AddLogin(string id, UserLoginInfo login)
        {
            return this.userManager.AddLogin(id, login);
        }

        /// <summary>
        /// The add password async.
        /// </summary>
        /// <param name="getUserId">
        /// The get user id.
        /// </param>
        /// <param name="newPassword">
        /// The new password.
        /// </param>
        /// <returns>
        /// The <see cref="Task{T}"/>.
        /// </returns>
        public async Task<IdentityResult> AddPasswordAsync(string getUserId, string newPassword)
        {
            return await this.userManager.AddPasswordAsync(getUserId, newPassword);
        }

        /// <summary>
        /// The add user to roles.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="roles">
        /// The roles.
        /// </param>
        /// <returns>
        /// The <see cref="IdentityResult"/>.
        /// </returns>
        public IdentityResult AddUserToRoles(string id, string[] roles)
        {
            foreach (var matrixRolese in roles)
            {
                var result = this.userManager.AddToRole(id, matrixRolese);
                if (!result.Succeeded)
                {
                    return result;
                }
            }

            return IdentityResult.Success;
        }

        /// <summary>
        /// The change password async.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="oldPassword">
        /// The old password.
        /// </param>
        /// <param name="newPassword">
        /// The new password.
        /// </param>
        /// <returns>
        /// The <see cref="Task{T}"/>.
        /// </returns>
        public async Task<IdentityResult> ChangePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            return await this.userManager.ChangePasswordAsync(userId, oldPassword, newPassword);
        }

        /// <summary>
        /// The create identity.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="ClaimsIdentity"/>.
        /// </returns>
        public ClaimsIdentity CreateIdentity(SystemUser user, string type) => this.userManager.CreateIdentity(SecurityHelper.FromSystemUser(user), type);

        /// <summary>
        /// The create user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <param name="roles">
        /// The roles.
        /// </param>
        /// <returns>
        /// The <see cref="IdentityResult"/>.
        /// </returns>
        public IdentityResult CreateUser(SystemUser user, string password, params string[] roles)
        {
            var identityUser = SecurityHelper.FromRegister(user);
            var result = this.userManager.Create(identityUser, password);
            if (!result.Succeeded)
            {
                return result;
            }

            result = this.AddUserToRoles(identityUser.Id, roles);
            user.Id = identityUser.Id;

            return result;
        }

        /// <summary>
        /// The generate password.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GeneratePassword()
        {
            const string Specials = "!@#$%^&*()";

            var randomDigit = DateTime.UtcNow.Millisecond.ToString(CultureInfo.InvariantCulture)[0];
            var ch =
                Convert.ToChar(Convert.ToInt32(Math.Floor((26 * new Random().NextDouble()) + 65)))
                    .ToString(CultureInfo.InvariantCulture);

            return Guid.NewGuid().ToString().Substring(0, 6) + randomDigit + ch.ToUpper()
                   + Specials[new Random().Next(9)];
        }

        /// <summary>
        /// The get logins.
        /// </summary>
        /// <param name="getUserId">
        /// The get user id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public IEnumerable<UserLoginInfo> GetLogins(string getUserId) => this.userManager.GetLogins(getUserId);

        /// <summary>
        /// The get roles.
        /// </summary>
        /// <returns>
        /// The <see cref="Dictionary{T,T}"/>.
        /// </returns>
        public Dictionary<string, string> GetRoles()
        {
            var roles = this.roleManager.Roles.ToList();
            var result = new Dictionary<string, string>();
            roles.ForEach(r => result.Add(r.Id, r.Name));
            return result;
        }

        /// <summary>
        /// The get user.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The <see cref="SystemUser"/>.
        /// </returns>
        public SystemUser GetUser(string email)
        {
            return SecurityHelper.ToSystemUser(this.userManager.FindByName(email));
        }

        /// <summary>
        /// The get user.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The <see cref="SystemUser"/>.
        /// </returns>
        public SystemUser GetUser(string email, string password)
        {
            return SecurityHelper.ToSystemUser(this.userManager.Find(email, password));
        }

        /// <summary>
        /// The get user.
        /// </summary>
        /// <param name="userLoginInfo">
        /// The user login info.
        /// </param>
        /// <returns>
        /// The <see cref="SystemUser"/>.
        /// </returns>
        public SystemUser GetUser(UserLoginInfo userLoginInfo)
        {
            return SecurityHelper.ToSystemUser(this.userManager.Find(userLoginInfo));
        }

        /// <summary>
        /// The get user by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="SystemUser"/>.
        /// </returns>
        public SystemUser GetUserById(string id)
        {
            return SecurityHelper.ToSystemUser(this.userManager.FindById(id));
        }

        /// <summary>
        /// The get user roles.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="IList{T}"/>.
        /// </returns>
        public IList<string> GetUserRoles(string userId)
        {
            return this.UserManager.GetRoles(userId);
        }

        /// <summary>
        /// The get users.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public IEnumerable<User> GetUsers()
        {
            if (this.userManager.Users != null)
            {
                var users = this.userManager.Users.Include(u => u.Roles);
                return users;
            }

            return Enumerable.Empty<User>();
        }

        /// <summary>
        /// The is in role async.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="role">
        /// The role.
        /// </param>
        /// <returns>
        /// The <see cref="Task{T}"/>.
        /// </returns>
        public async Task<bool> IsInRoleAsync(string userId, string role)
        {
            return await this.userManager.IsInRoleAsync(userId, role);
        }

        /// <summary>
        /// The remove login.
        /// </summary>
        /// <param name="getUserId">
        /// The get user id.
        /// </param>
        /// <param name="loginInfo">
        /// The login info.
        /// </param>
        /// <returns>
        /// The <see cref="IdentityResult"/>.
        /// </returns>
        public IdentityResult RemoveLogin(string getUserId, UserLoginInfo loginInfo)
        {
            return this.userManager.RemoveLogin(getUserId, loginInfo);
        }

        /// <summary>
        /// The remove user from roles.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="roles">
        /// The roles.
        /// </param>
        /// <returns>
        /// The <see cref="IdentityResult"/>.
        /// </returns>
        public IdentityResult RemoveUserFromRoles(string id, string[] roles)
        {
            foreach (var matrixRole in roles)
            {
                var result = this.userManager.RemoveFromRole(id, matrixRole);
                if (!result.Succeeded)
                {
                    return result;
                }
            }

            return IdentityResult.Success;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="IdentityResult"/>.
        /// </returns>
        public IdentityResult Update(SystemUser user)
        {
            var identityUser = this.userManager.FindById(user.Id);

            identityUser.PasswordHash = user.HashPassword;
            //identityUser.PasswordResetToken = user.PasswordResetToken;
            //identityUser.Password = user.EncryptedPassword;

            return this.userManager.Update(identityUser);
        }

        /// <summary>
        /// The update re login required.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="IdentityResult"/>.
        /// </returns>
        public IdentityResult UpdateReLoginRequired(SystemUser user)
        {
            var identityUser = this.userManager.FindById(user.Id);

            // identityUser.IsReLoginRequired = user.IsReLoginRequired;
            return this.userManager.Update(identityUser);
        }
    }
}