using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatFishingWebSite.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
 
namespace CatFishingWebSite.Pages.Signup
{
    public class indexModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }
        public void OnGet()
        {
             
        }
    }
}