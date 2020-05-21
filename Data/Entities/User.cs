using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Users")]
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        
        public string Username { get; set; }

        
        [Required]
        
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }


        [DefaultValue(0.00)]
        public decimal Balance { get; set; }
    }
}
