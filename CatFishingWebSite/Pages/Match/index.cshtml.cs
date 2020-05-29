using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CatFishingWebSite.Model;
using CatFishingWebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatFishingWebSite.Pages.Match
{
    // match page for fisher , provide users after fitter
    public class indexModel : PageModel
    {
        private WebService webService = WebService.getInstance();
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
            if (id == 0)
            {
                return NotFound();
            }




            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            return Redirect("../index}");
        }

        public void OnPostLogout()
        {
            Debug.WriteLine("+++LOG OUTTTTTTTTTTT");

            webService.Logout();
        }
    }
}