namespace Shop.BusinessLayer.Accounts.Handlers
{
    using Shop.DataLayer;
    using Shop.BuisnessLayer;
    using Shop.BusinessLayer.Accounts.Responses;
    using Shop.Common;
    using Shop.Identity;

    /// <summary>
    /// The reset password handler.
    /// </summary>
    public class ResetPasswordHandler : BaseCommandHandler<string, AccessTokenDto>
    {
        /// <summary>
        /// The service.
        /// </summary>
        private readonly IIdentityService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResetPasswordHandler"/> class.
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
        public ResetPasswordHandler(UnitOfWork unitOfWork,  IIdentityService service)
            : base(unitOfWork)
        {
            this.service = service;
        }

        /// <inheritdoc />
        public override HandlerResult<AccessTokenDto> Execute(string command)
        {
            var response = this.service.GenerateForgotPasswordToken(command);

            if (!response.Succeeded)
            {
                return new HandlerResult<AccessTokenDto>(response);
            }

            return new HandlerResult<AccessTokenDto>(new AccessTokenDto { Token = response.Data.Token });
        }
    }
}
