namespace Shop.BusinessLayer.Accounts.Handlers
{
    using Shop.DataLayer;
    using Shop.BuisnessLayer;
    using Shop.BusinessLayer.Accounts.Commands;
    using Shop.Common;
    using Shop.Identity;

    /// <summary>
    /// The change password handler.
    /// </summary>
    public class ChangePasswordHandler : BaseCommandHandler<ChangePasswordCommand, bool>
    {
        /// <summary>
        /// The service.
        /// </summary>
        private readonly IIdentityService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePasswordHandler"/> class.
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
        public ChangePasswordHandler(UnitOfWork unitOfWork, IIdentityService service)
            : base(unitOfWork)
        {
            this.service = service;
        }

        /// <inheritdoc />
        public override HandlerResult<bool> Execute(ChangePasswordCommand command)
        {
            var response = this.service
                               .ChangePasswordAsync(command.User, command.NewPassword)
                               .Result;

            if (!response.Succeeded)
            {
                return new HandlerResult<bool>(response);
            }

            return new HandlerResult<bool>(true);
        }
    }
}
