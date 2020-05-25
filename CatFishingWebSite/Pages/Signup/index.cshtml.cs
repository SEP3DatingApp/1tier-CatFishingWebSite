using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
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
        private static readonly WebService webService = new WebService();


        [BindProperty]
        public Fisher fisher { get; set; }

        [BindProperty]
        public string passwordAgain { get; set; }
        public string errorMessage;
        public string successMessage;
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {


            //if( ! webService.IsUniqueUserName(fisher.Username))
            //{
            //    errorMessage = "Username already exists";
            //    return Page();
            //}
            if (fisher.Password != passwordAgain)
            {
                errorMessage = "please type right password again";
                return Page();
            }
            if (fisher.Username == null)
            {
                return Page();
            }
            if (fisher.Password == null)
            {
                return Page();
            }
            if (fisher.SexPref != 'M' && fisher.SexPref != 'F' && fisher.SexPref != 'B')
            {
                errorMessage = "select your gender or sex preference";
                return Page();
            }
            if (fisher.Gender != 'M' && fisher.Gender != 'F')
            {
                errorMessage = "select your gender or sex preference";
                return Page();
            }
            successMessage = "Sign up now...";
            bool created;
            try { created = webService.CreateUser(fisher.Username, fisher.Password, fisher.Gender, fisher.SexPref); }
            catch (SocketException)
            {
                return RedirectToPage("Error");
            }

            if (created)
            {
                Console.WriteLine("Create a new account");
                successMessage = "Sign up successfully ,Back to login page";
                
                return RedirectToPage("./Success");
            }
            errorMessage = "Username already exists";
            return Page();


        }
    }
}