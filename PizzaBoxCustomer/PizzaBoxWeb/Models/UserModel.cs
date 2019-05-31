using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBoxWeb.Models
{
    public class UserModel
    {
        [DisplayName("Username")]
        [Required(ErrorMessage = "Must have a username.")]
        [StringLength(20, ErrorMessage = "Username should be maximun 20 characters",MinimumLength = 1)]
        public string Username { get; set; }

        public int LocationId { get; set; }


        [DisplayName("Password")]
        [Required(ErrorMessage = "Must have a password.")]
        [StringLength(20, ErrorMessage = "Password should be maximun 20 characters", MinimumLength = 1)]
        public string Password { get; set; }
    }
}
