using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Entities.Models
{
  
    public class Users
    {
        [Key]
        public string UserId { get; set; }


        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
                
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "ZIP is required")]
        public string ZIP { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        public string email { get; set; }

        [Required(ErrorMessage = "Registred is required")]
        public int registred { get; set; }


    }
}
