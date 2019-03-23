using DataLayer;
using Shop.BuisnessLayer.Commands;
using Shop.BuisnessLayer.Dtos;
using Shop.Common;
using Shop.Common.Errors;
using Shop.Models.Database;

namespace Shop.BuisnessLayer.ProductHandler
{
    public class CreateProductHandler : BaseCommandHandler<CreateProductCommand,ProductDto >
    {
        

        public CreateProductHandler(UnitOfWork unitOfWork): base(unitOfWork) { }

        public override HandlerResult<ProductDto> Execute(CreateProductCommand command)
        {
            Product entity;


            if (command.Id.GetValueOrDefault()==0)
            {
                entity = new Product();
            }
            else
            {
                entity = this.UnitOfWork.prods.GetByid(command.Id);
            }

            if (entity == null)
            {
                return new HandlerResult<ProductDto>(new NotFoundError($"Not found region with id {command.Id}"));
            }

            entity.ProductName = command.ProductName;
            entity.places = command.places;
            entity.Length = command.Length;
            entity.Height = command.Height;
            entity.Width = command.Width;
            if (command.Id.GetValueOrDefault() == 0)
            {
                this.UnitOfWork.prods.Create(entity);
            }
            else
            {
                this.UnitOfWork.prods.Update(entity);
            }
            this.UnitOfWork.Save();
            var handler = new GetProductByIdHandler(this.UnitOfWork);
            var result = handler.Execute(entity.ProductId);
            return result;

        }
    }
}
