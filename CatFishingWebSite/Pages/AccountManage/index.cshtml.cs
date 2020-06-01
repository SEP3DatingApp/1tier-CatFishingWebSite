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
        private readonly WebService webService;

        public indexModel(WebService service)
        {

            webService = service;

        }

        public Fisher fisher { get; set; }
        string Username { get; set; }
       public string isAct { get; set; }
        public string Gend { get; set; }
        public string SexP { get; set; }
        public void OnGet(int id)
        {
            fisher = webService.GetFisherByName(id);
            //Username = CookieModel.userName;
            if (fisher.IsActive)
            {
                isAct = "Active";
            }
            else
            {
                isAct = "Not active";
            }

            if (fisher.Gender.Contains("M"))
            {
                Gend = "Male";
            }
            else
            {
                Gend = "Female";
            }
            if (fisher.PersonSexualityId == 2)
            {
                SexP = "Gay";
            }else if (fisher.PersonSexualityId == 3)
            {
                SexP = "Bisexual";
            }
            else
            {
                SexP = "Straight";
            }
        }
    }
}