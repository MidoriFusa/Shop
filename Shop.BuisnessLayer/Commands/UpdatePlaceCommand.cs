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
        public int? Id { get; set; }

       
        public string Name { get; set; }

       

    }
}
