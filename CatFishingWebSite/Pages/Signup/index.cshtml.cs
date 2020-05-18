using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CatFishingWebSite.Model;
using CatFishingWebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
 
namespace CatFishingWebSite.Pages.Signup
{
    public class indexModel : PageModel
    {
        private static readonly IWebService webService = new WebService();
        

        [BindProperty]
        public User user { get; set; }

        [BindProperty]
        public string passwordAgain { get; set; }
        public string errorMessage;
        public string successMessage;
        public void OnGet()
        {
             
        }

        public async Task<IActionResult> OnPostAsync()
        {
            
            if( ! webService.isUniqueUserName(user.Username))
            {
                errorMessage = "Username already exists";
                return Page();
            }
            if (user.Password!=passwordAgain)
            {
                errorMessage = "please type right password again";
                return Page();
            }
            if(user.Username == null)
            {
                return Page();
            }
            if(user.Password == null)
            {
                return Page();
            }
            successMessage = "Sign up now...";
            webService.createUser(user.Username, user.Password);
            Console.WriteLine("Create a new account");
            successMessage = "Sign up successfully ,Back to login page";
            Thread.Sleep(3000);
            return RedirectToPage("../Index");
            
        }
        }
}