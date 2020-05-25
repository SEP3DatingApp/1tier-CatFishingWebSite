using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CatFishingWebSite.Model;
using CatFishingWebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatFishingWebSite.Pages.AccountManage
{
    public class EditModel : PageModel
    {
        private static readonly WebService webService = new WebService();
        [BindProperty]
        public Fisher fisher { get; set; }
        public int Id;
        public string Username;

        public void OnGet(int id)
        {
            Id = id;
            fisher = webService.GetFisherByName(id);

            Username = CookieModel.userName;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            bool isUpdate = webService.UpdateFisher(Id, fisher.SexPref,fisher.FirstName,fisher.Surname,fisher.Email,fisher.Age,fisher.Description,fisher.IsActive);
            if (isUpdate)
            {
                Debug.WriteLine("change successfully");
            }
            return Page();
        }
        }
}