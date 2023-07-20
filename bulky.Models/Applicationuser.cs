using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models
{
    public class Applicationuser : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public string? Streetaddres { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Postelcode { get; set; }





    }
}
