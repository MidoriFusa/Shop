namespace Shop.BusinessLayer.Accounts.Handlers
{
    using Shop.DataLayer;
    using Shop.BuisnessLayer;
    using Shop.BusinessLayer.Accounts.Responses;
    using Shop.Common;
    using Shop.Identity;

    /// <summary>
    /// The authorize handler.
    /// </summary>
    public class AuthorizeHandler : BaseCommandHandler<LoginInfo, AccessTokenDto>
    {
        /// <summary>
        /// The service.
        /// </summary>
        private readonly IIdentityService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizeHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit of work.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="service">
        /// The service.
        /// </param>
        public AuthorizeHandler(UnitOfWork unitOfWork, IIdentityService service)
            : base(unitOfWork)
        {
            this.service = service;
        }

        /// <inheritdoc />
        public override HandlerResult<AccessTokenDto> Execute(LoginInfo command)
        {
            var response = this.service.OAuthAuthorize(command);

            return !response.Succeeded
                       ? new HandlerResult<AccessTokenDto>(response)
                       : new HandlerResult<AccessTokenDto>(new AccessTokenDto { Token = response.Data.Token, });
        }
    }
}
