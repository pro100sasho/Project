using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Products")]
    public class Product
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue)]
        [DefaultValue(0.00)]
        public decimal Price { get; set; }
    }
}
