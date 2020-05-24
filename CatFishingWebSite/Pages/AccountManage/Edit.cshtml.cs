using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatFishingWebSite.Model;
using CatFishingWebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatFishingWebSite.Pages.AccountManage
{
    public class EditModel : PageModel
    {
        private static readonly WebService webService = WebService.getInstance();

        public Fisher fisher { get; set; }

        public string Username;

        public void OnGet(int id)
        {
            fisher = webService.GetFisherByName(CookieModel.userName);

            Username = CookieModel.userName;
        }
    }
}