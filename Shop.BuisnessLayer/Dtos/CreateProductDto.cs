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
      
        public string Name { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public double Width { get; set; }
        [Required]
        public double Length { get; set; }
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }



    }
}
