﻿using Shop.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.Dtos
{
   public class ProductDto : BaseDto
    {

        public double Height { get; set; }
       
        public double Width { get; set; }
        
        public double Length { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }


    }
}
