namespace Shop.BusinessLayer.Accounts.Handlers
{
    using System.Linq;
    using Shop.DataLayer;
    using Shop.BuisnessLayer;
    using Shop.BusinessLayer.Accounts.Responses;
    using Shop.Common;
    using Shop.Identity;

    /// <summary>
    /// The get user info handler.
    /// </summary>
    public class GetUserInfoHandler : BaseCommandHandler<string, UserInfoDto>
    {
        /// <summary>
        /// The service.
        /// </summary>
        private readonly IIdentityService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserInfoHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit of work.
        /// </param>
        /// <param name="service">
        /// The service.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public GetUserInfoHandler(UnitOfWork unitOfWork, IIdentityService service) : base(unitOfWork)
        {
            this.service = service;
        }

        /// <inheritdoc />
        public override HandlerResult<UserInfoDto> Execute(string userId)
        {
            var userInfoResponse = this.service.GetUserProfile(userId);
            var userRoleResponse = this.service.GetUserRoles(userId);

            if (!userInfoResponse.Succeeded)
            {
                return new HandlerResult<UserInfoDto>(userInfoResponse);
            }

            if (!userRoleResponse.Succeeded)
            {
                return new HandlerResult<UserInfoDto>(userRoleResponse);
            }

            var userRoles = userRoleResponse.Data.Roles.ToList();
            userRoles.Sort(new UserRolesComparer());

            var companyId = this.UnitOfWork.users.GetAll().Where(e => e.Id == userId).SingleOrDefault();

            var result = new UserInfoDto(userInfoResponse.Data, userRoles);
            return new HandlerResult<UserInfoDto>(result);
        }
    }
}
