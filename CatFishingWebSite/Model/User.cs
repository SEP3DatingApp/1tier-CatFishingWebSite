using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatFishingWebSite.Model
{
    public class User
    {

        
        [Range(1, 99999999999)]
        public int UserID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public string Usertype { get; set; }
      
      
    }

    public class Fisher : User
    {
        public string Email { get; set; }
        [StringLength(1)]
        public char gender { get; set; }

        public char sexpref { get; set; }

        public int age { get; set; }

        public bool isActive { get; set; }

        public string name { get; set; }

        public string description { get; set; }

    }
}
