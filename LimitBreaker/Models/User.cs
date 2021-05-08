using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LimitBreaker.Models
{
    [Table("User", Schema = "Limits")]
    public class User
    {
        //FIELD & PROPS
        public int Id { get; set; }
        [Required(ErrorMessage = "UserName is Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Age { get; set; }
        public bool? IsAdmin { get; set; }

        // CONSTRUCTORS


        //METHODS
    }
}
