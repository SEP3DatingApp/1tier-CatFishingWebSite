using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatFishingWebSite.Model
{
    [Serializable]
    public class User
    {

        public int id { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public string Usertype { get; set; }

        public  string token { get; set; }
    }

    public class Fisher : User
    {
       
        public string FirstName { get; set; }
      
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string SexPref { get; set; }
        public string PicRef { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }

    }
}
