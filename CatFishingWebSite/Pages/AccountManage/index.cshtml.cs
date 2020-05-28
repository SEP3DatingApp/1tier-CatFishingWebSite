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
        private static readonly WebService webService = WebService.getInstance();

       
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
            if (fisher.SexPref.Contains("M"))
            {
                SexP = "Man";
            }else if (fisher.SexPref.Contains("B"))
            {
                SexP = "Both Woman and Man";
            }
            else
            {
                SexP = "Woman";
            }
        }
    }
}