namespace Shop.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;

    using Microsoft.AspNet.Identity;
    using Shop.BusinessLayer.Accounts.Commands;
    using Shop.BusinessLayer.Accounts.Handlers;
    using Shop.BusinessLayer.Accounts.Responses;
    using Shop.Common.Errors;
    using Shop.DataLayer;
    using Shop.Errors;
    using Shop.Filters;
    using Shop.Identity;
    using Shop.Models;
   

    /// <inheritdoc />
    /// <summary>
    /// The account controller.
    /// </summary>
    [RoutePrefix("account")]
    public class AccountController : BaseApiController
    {
        /// <summary>
        /// The forgot password.
        /// </summary>
        /// <param name="userName">
        /// The email.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("forgotPassword")]
        [ResponseError(typeof(ArgumentError), typeof(ArgumentNullError), typeof(UserNotFoundError))]
        [ResponseType(typeof(AccessTokenDto))]
        [ValidateModel]
        public IHttpActionResult ForgotPassword(string userName) =>
            this.RunHandler<ResetPasswordHandler, string, AccessTokenDto>(userName);

        /// <summary>
        /// The post authorize.
        /// </summary>
        /// <param name="dto">
        /// The data transfer object.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [AllowAnonymous]
        [Route("authorize")]
        [ValidateModel]
        [ResponseError(
            typeof(ArgumentError),
            typeof(ArgumentNullError),
            typeof(UserNotFoundError))]
        [ResponseType(typeof(AccessTokenDto))]
        public IHttpActionResult PostAuthorize(LoginDto dto)
        {
            var loginInfo = new LoginInfo
            {
                Email = dto.UserName,
                Password = dto.Password,
                AuthenticationType = Startup.OAuthBearerOptions.AuthenticationType,
                SecureDataFormat = Startup.OAuthBearerOptions.AccessTokenFormat
            };

            return this.RunHandler<AuthorizeHandler, LoginInfo, AccessTokenDto>(loginInfo);
        }

        /// <summary>
        /// The post change password.
        /// </summary>
        /// <param name="userName">
        /// The email.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <param name="newPassword">
        /// The new password.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [AllowAnonymous]
        [Route("changePassword")]
        [ResponseError(
            typeof(ArgumentError),
            typeof(ArgumentNullError),
            typeof(InvalidPasswordError),
            typeof(InvalidPasswordResetTokenError),
            typeof(UserNotFoundError),
            typeof(ChangePasswordError))]
        [ValidateModel]
        public IHttpActionResult PostChangePassword(string userName, string token, string newPassword)
        {
            var command = new ChangePasswordCommand
            {
                User = new SystemUser { UserName = userName, PasswordResetToken = token },
                NewPassword = newPassword
            };
            return this.RunHandler<ChangePasswordHandler, ChangePasswordCommand, bool>(command);
        }

        /// <summary>
        /// The get user information.
        /// </summary>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpGet]
        [AuthorizeRoles(
            IdentityRoles.StoreKeeper,
            IdentityRoles.Driver)]
        [Route("userInfo")]
        [ResponseType(typeof(UserInfoDto))]
        public IHttpActionResult GetUserInfo()
        {
            var userId = this.User.Identity.GetUserId();
            return this.RunHandler<GetUserInfoHandler, string, UserInfoDto>(userId);
        }
    }
}