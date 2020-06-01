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
        private readonly WebService webService;

        public indexModel(WebService service)
        {
            webService = service;
        }

        [BindProperty]
        public Fisher fisher { get; set; }

        [BindProperty]
        public string passwordAgain { get; set; }
        public string errorMessage;
        public string successMessage;
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {

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
            if (fisher.PersonSexualityId != 1 && fisher.PersonSexualityId != 2 && fisher.PersonSexualityId != 3)
            {
                errorMessage = "Select your gender or sexual preference";
                return Page();
            }
            if (fisher.Gender != "M" && fisher.Gender != "F")
            {
                errorMessage = "Select your gender or sexual preference";
                return Page();
            }
            successMessage = "Sign up now...";
            bool created;
            try { created = webService.CreateUser(fisher.Username, fisher.FirstName, fisher.Age, fisher.Password, fisher.Gender, fisher.PersonSexualityId); }
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