using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatFishingWebSite.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatFishingWebSite.Pages.Match
{
    public class indexModel : PageModel
    { 
        
        public User user { get;set; }
        public string Title { get; set; }
        //public void OnGet(string ? username)
        //{ 
        
        //}
        String message;
        public async Task<IActionResult> OnGetAsync(string ? username)
        {
            
            Console.WriteLine(username);
            message = "hello user ";
            if (username == null)
            {
                return NotFound();
            }
            Title = username;

            
 
            return Page();
        }
    }
}