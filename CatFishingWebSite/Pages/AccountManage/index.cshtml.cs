using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatFishingWebSite.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatFishingWebSite.Pages.AccountManage
{
    public class indexModel : PageModel
    {
        Fisher fisher { get; set; }
        string Username { get; set; }
        public void OnGet(string  username)
        {
             Username = username;
        }
    }
}