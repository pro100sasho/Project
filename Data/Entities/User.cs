using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
    /// <summary>
    /// App implementation of IdentityUser
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Gets or Sets the first name of the User
        /// </summary>
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets the last name of the User
        /// </summary>
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or Sets the money balance of the User
        /// </summary>
        [DefaultValue(0.00)]
        [Range(0, double.MaxValue)]
        public decimal Balance { get; set; }
    }
}
