using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.Dtos
{
    public class PlaceUpdateDto
    {
        public int PlaceId { get; set; }

        [Required]
        [StringLength(4, MinimumLength = 2)]
        public string PlaceName { get; set; }

        public ICollection<ProductDto> products { get; set; }

        public PlaceUpdateDto()
        {
            products = new List<ProductDto>();
        }




    }
}
