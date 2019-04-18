namespace Shop
{
    using AutoMapper;
    using Shop.BuisnessLayer.Commands;
    using Shop.BuisnessLayer.Dtos;



    /// <summary>
    /// The auto mapper config.
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        /// The configure.
        /// </summary>
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
                {

                    cfg.CreateMap<CreateOrderPunctDto, CreateOrderPunctCommand>();
                    cfg.CreateMap<CreateOrderDto, CreateOderCommand>();

                    cfg.CreateMap<CreateProductDto, CreateProductCommand>();
                 

                    cfg.CreateMap<PlaceUpdateDto, UpdatePlaceCommand>();
                  
                });
        }
    }
}