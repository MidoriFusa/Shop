using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.Dtos
{
    public class CreateProductDto
    {

        public int Id { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 6)]
        public string ProductName { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public double Width { get; set; }
        [Required]
        public double Length { get; set; }

        public ICollection<PlaceDto> places { get; set; }

        public CreateProductDto()
        {
            places = new List<PlaceDto>();
        }


    }
}
