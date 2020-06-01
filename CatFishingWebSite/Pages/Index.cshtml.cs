using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CatFishingWebSite.Model;
using CatFishingWebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.CompilerServices;

namespace CatFishingWebSite.Pages
{
    public class IndexModel : PageModel

    {
        private readonly WebService webService;

        [BindProperty]
        public User user { get; set; }

        private readonly ILogger<IndexModel> _logger;

        private bool isLogin;
        public string errorMessage;
        public IndexModel(ILogger<IndexModel> logger, WebService service)
        {
            _logger = logger;
            webService = service;
        }

        public void OnGet()
        {
            CookieModel.count = 0;
            CookieModel.isLogin = false;
            CookieModel.userName = null;
            CookieModel.otherIdsMatched = null;
        }
        public IActionResult OnPostLogin()
        {
            bool isint = true;
            string un = user.Username;
            string pwd = user.Password;
            // check user input if int
            int tmp;
            if (!int.TryParse(un, out tmp))
            {
                isint = false;
            }
            else
            {
                isint = true;
            }
            if (isint)
            {
                errorMessage = "Please type the right format of username";
                return Page();
            }
            if (un == null || pwd == null || un == "")
            {
                errorMessage = "Username or password is reqired";
                return Page();
            }

            try
            {
                isLogin = webService.IsLogin(un, pwd);

            }
            catch (Exception)
            {
                return RedirectToPage("Error");
            }

            if (isLogin)
            {
                CookieModel.userName = un;
                CookieModel.isLogin = true;
                CookieModel.otherIdsMatched = webService.GetFishersList(CookieModel.id);
                IdOfUser first = CookieModel.otherIdsMatched[0];
                if (first.Id == 0)
                {
                    Debug.WriteLine("can't find otherId");
                    return Page();
                }

                return Redirect("/Match/" + CookieModel.id + "&" + first.Id);

            }
            else
                errorMessage = "User Name or Password is incorrect";
            return Page();

        }
        public string getUserName()
        {
            return user.Username;
        }

    }
}
