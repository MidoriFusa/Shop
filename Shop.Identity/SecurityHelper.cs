namespace Shop.Identity
{
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Infrastructure;
    using Microsoft.Owin.Security;
    using Shop.Models.Database;
    using System;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The security helper.
    /// </summary>
    public class SecurityHelper
    {
        /// <summary>
        /// The user manager.
        /// </summary>
        private readonly UserManager<User> userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityHelper"/> class.
        /// </summary>
        /// <param name="userManager">
        /// The user manager.
        /// </param>
        public SecurityHelper(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        /// <summary>
        /// The from register.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="DbUser"/>.
        /// </returns>
        public static User FromRegister(SystemUser user) =>
            user == null
                ? null
                : new User
                      {
                          UserName = user.UserName, 
                          //FirstName = user.FirstName, 
                          //LastName = user.LastName, 
                          Email = user.UserName, 
                          //Created = DateTime.UtcNow
                      };

        /// <summary>
        /// The from matrix user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="DbUser"/>.
        /// </returns>
        public static User FromSystemUser(SystemUser user) =>
            user == null
                ? null
                : new User
                      {
                          Id = user.Id,
                          UserName = user.UserName,
                          //FirstName = user.FirstName,
                          //LastName = user.LastName,
                          PasswordHash = user.HashPassword,
                          //Created = user.Created,
                          Email = user.Email,
                      };

        /// <summary>
        /// The map matrix user to user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="identityUser">
        /// The identity user.
        /// </param>
        public static void MapMatrixUserToUser(SystemUser user, User identityUser)
        {
            identityUser.Email = user.Email;
            //identityUser.FirstName = user.FirstName;
            //identityUser.LastName = user.LastName;           
        }

        /// <summary>
        /// The generate access token.
        /// </summary>
        /// <param name="identity">
        /// The identity.
        /// </param>
        /// <param name="formatter">
        /// The formatter.
        /// </param>
        /// <param name="expirationHours">
        /// The expiration Hours.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GenerateAccessToken(
            ClaimsIdentity identity, ISecureDataFormat<AuthenticationTicket> formatter, int expirationHours = 24)
        {
            var ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
            var currentUtc = new SystemClock().UtcNow;
            ticket.Properties.IssuedUtc = currentUtc;

            //// TODO resolve issue with token expiration
            ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromHours(expirationHours));
            return formatter.Protect(ticket);
        }

        /// <summary>
        /// The generate random token.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="CryptographicException">The cryptographic service provider (CSP) cannot be acquired. </exception>
        public static string GenerateRandomToken()
        {
            var token = new StringBuilder();

            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                var data = new byte[4];
                for (var i = 0; i < 32; i++)
                {
                    rngCsp.GetBytes(data);
                    var randomChar = Convert.ToChar((byte)(BitConverter.ToUInt32(data, 0) % 26) + 65);
                    token.Append(randomChar);
                }
            }

            var tokenid = token.ToString();
            return tokenid;
        }

        /// <summary>
        /// The to matrix user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="SystemUser"/>.
        /// </returns>
        public static SystemUser ToSystemUser(User user) =>
            user == null
                ? null
                : new SystemUser
                      {
                          Id = user.Id,
                          UserName = user.UserName,
                          //FirstName = user.FirstName,
                          //LastName = user.LastName,
                          //PasswordResetToken = user.PasswordResetToken,
                          HashPassword = user.PasswordHash,
                          //Created = user.Created,
                          Email = user.Email,
                          //EncryptedPassword = user.Password
                      };

        /// <summary>
        /// The hash password.
        /// </summary>
        /// <param name="newPassword">
        /// The new password.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string HashPassword(string newPassword) => this.userManager.PasswordHasher.HashPassword(newPassword);

        /// <summary>
        /// The validate password async.
        /// </summary>
        /// <param name="newPassword">
        /// The new password.
        /// </param>
        /// <returns>
        /// The <see cref="System.Threading.Tasks.Task"/>.
        /// </returns>
        public async Task<IdentityResult> ValidatePasswordAsync(string newPassword) => await this.userManager.PasswordValidator.ValidateAsync(newPassword);

        /// <summary>
        /// The validate password.
        /// </summary>
        /// <param name="newPassword">
        /// The new password.
        /// </param>
        /// <returns>
        /// The <see cref="IdentityResult"/>.
        /// </returns>
        public IdentityResult ValidatePassword(string newPassword) => this.userManager.PasswordValidator.ValidateAsync(newPassword).Result;
    }
}