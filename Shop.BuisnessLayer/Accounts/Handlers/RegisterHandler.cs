namespace Shop.BusinessLayer.Accounts.Handlers
{
    using System;
    using Shop.DataLayer;
    using Shop.BuisnessLayer;
    using Shop.BusinessLayer.Accounts.Commands;
    using Shop.Common;
    using Shop.Identity;
    using Shop.Models.Database;
    using System.Linq;

    /// <summary>
    /// The register handler.
    /// </summary>
    public class RegisterHandler : BaseCommandHandler<RegisterCommand, User>
    {
        /// <summary>
        /// The service.
        /// </summary>
        private readonly IIdentityService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterHandler"/> class.
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
        public RegisterHandler(UnitOfWork unitOfWork, IIdentityService service) : base(unitOfWork)
        {
            this.service = service;
        }

        /// <inheritdoc />
        public override HandlerResult<User> Execute(RegisterCommand command)
        {
            var systemUser = new SystemUser
                                 {
                                     Email = command.Email,
                                     UserName = command.UserName,
                                     Created = DateTime.UtcNow,
                                     FirstName = command.FirstName,
                                     LastName = command.LastName,
                                     CompanyId = command.CompanyId
                                 };
            var result = this.service.Register(systemUser, command.Password, command.Roles);

            if (!result.Succeeded)
            {
                return new HandlerResult<User>(result);
            }

            var user = this.UnitOfWork.users.GetAll().SingleOrDefault(e => e.Id == result.Data);


            return new HandlerResult<User>(user);
        }
    }
}
