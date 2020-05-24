using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatFishingWebSite.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatFishingWebSite.Pages.Match
{
    // match page for fisher , provide users after fitter
    public class indexModel : PageModel
    {

        public User user { get; set; }
        public string Title { get; set; }
        //public void OnGet(string ? username)
        //{ 

        //}
        String message;
        public async Task<IActionResult> OnGetAsync(int id)
        {

            Console.WriteLine(id);
            message = "hello user ";
            if (id ==0)
            {
                return NotFound();
            }
            



            return Page();
        }
    }
}