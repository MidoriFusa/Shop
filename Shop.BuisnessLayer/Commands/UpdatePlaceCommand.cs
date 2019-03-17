using Shop.BuisnessLayer.Dtos;
using Shop.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.Commands
{
    public class UpdatePlaceCommand
    {
        public int? PlaceId { get; set; }

       
        public string PlaceName { get; set; }

        public ICollection<Product> products { get; set; }

        public UpdatePlaceCommand()
        {
            products = new List<Product>();
        }


    }
}
