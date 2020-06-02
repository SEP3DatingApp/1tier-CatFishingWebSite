using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CatFishingWebSite.Model
{
    [Serializable]
    public class User
    {

        public int id { get; set; }

        [Required]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "Username contains ':', '.' ';', '*', '/' or '\' which are not allowed!")]
        [StringLength(20, ErrorMessage = "Max characters for username are 20")]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "Password contains ':', '.' ';', '*', '/' or '\' which are not allowed!")]
        [StringLength(20, ErrorMessage = "Max characters for password are 20")]
        public string Password { get; set; }

        public string Usertype { get; set; }

        public string token { get; set; }
    }

    public class Fisher : User
    {

        public string FirstName { get; set; }

        [RegularExpression(@"^[^\\/:*;\)\(]+$", ErrorMessage = "Email contains ':', '.' ';', '*', '/' or '\' which are not allowed!")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "The Gender must be 1 characters.")]
        [RegularExpression("M|F", ErrorMessage = "The Gender must be either 'M' or 'F' only.")]
        public string Gender { get; set; }
        [Required]
        [Range(1, 6, ErrorMessage = "Value must be between 1 to 6")]
        public int PersonSexualityId { get; set; }
        public string PicRef { get; set; }
        [Range(18, 99)]
        public int Age { get; set; }

         [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "Description contains ':', '.' ';', '*', '/' and '\' which are not allowed!")]
        [StringLength(250, ErrorMessage = "Max characters for description are 250")]
        public string Description { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }

    }
}
