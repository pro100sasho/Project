using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.DTOs
{
    class UserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
    }
}
