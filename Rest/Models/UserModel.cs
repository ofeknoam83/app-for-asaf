using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rest.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Your must provide a PhoneNumber")]
        public string phoneNumber { get; set; }
        [Required(ErrorMessage = "Your must provide a password")]
        public string password { get; set; }
    }
}