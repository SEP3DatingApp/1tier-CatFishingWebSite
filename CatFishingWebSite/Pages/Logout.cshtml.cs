using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatFishingWebSite.Model;
using CatFishingWebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatFishingWebSite.Pages
{
    public class LogoutModel : PageModel
    {
        WebService webService = WebService.getInstance();
        public void OnGet()
        {
            CookieModel.isLogin = false;
            webService.Logout();
        }
    }
}