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
        private static readonly WebService webService = WebService.getInstance();


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
            if (!CookieModel.isLogin)
            {
                errorMessage = "Please log in";
                return Page();
            }
            if (fisher.Password != passwordAgain)
            {
                errorMessage = "Passwords doesn't match, please type the right passwords again";
                return Page();
            }
            if (fisher.FirstName == null)
            {
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
            if (fisher.SexPref != "S"&& fisher.SexPref != "G"&& fisher.SexPref != "B")
            {
                errorMessage = "Select your gender or sexual preference";
                return Page();
            }
            if (fisher.Gender !="M" && fisher.Gender != "F")
            {
                errorMessage = "Select your gender or sexual preference";
                return Page();
            }
            successMessage = "Sign up now...";
            bool created;
            try { created = webService.CreateUser(fisher.Username,fisher.FirstName,fisher.Age, fisher.Password, fisher.Gender, fisher.SexPref); }
            catch (SocketException)
            {
                return RedirectToPage("Error");
            }

            if (created)
            {
                Console.WriteLine("Create a new account");
                successMessage = "Sign up successfully, back to login page";
                
                return RedirectToPage("./Success");
            }
            errorMessage = "Username already exists or other error";
            return Page();


        }
    }
}