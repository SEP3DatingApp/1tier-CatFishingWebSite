using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatFishingWebSite.Model
{
    public class User
    {

        [Required]
        [Range(1, 99999999999)]
        public int UserID { get; set; }
        public String Username { get; set; }
        [Required]
        public String Password { get; set; }

        public String Usertype { get; set; }
    }

    public class Fisher : User
    {
        public String Email { get; set; }

       

    }
}
