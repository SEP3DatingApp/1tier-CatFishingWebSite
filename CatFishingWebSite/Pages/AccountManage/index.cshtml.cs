using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CatFishingWebSite.Model;
using CatFishingWebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatFishingWebSite.Pages.AccountManage
{
    public class indexModel : PageModel
    {
        private static readonly WebService webService = new WebService();

       
        public Fisher fisher { get; set; }
        string Username { get; set; }
        public void OnGet(int id)
        {
            fisher = webService.GetFisherByName(id);
            Debug.WriteLine("OHOHOH"+fisher.FirstName);
            Username = CookieModel.userName;
        }
    }
}