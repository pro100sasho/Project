using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class ProductDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public int Quantity { get; set; }

        [DefaultValue(0.00)]
        public decimal Price { get; set; }

        public string SellerId { get; set; }
    }
}
