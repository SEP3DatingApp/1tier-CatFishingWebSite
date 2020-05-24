using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using CatFishingWebSite.Model;
using CatFishingWebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CatFishingWebSite.Pages
{
    public class IndexModel : PageModel

    {
        private static readonly WebService webService = WebService.getInstance();
        // private static readonly DummyServer dummy = new DummyServer();



        [BindProperty]
        public User user { get; set; }

        private readonly ILogger<IndexModel> _logger;

        private bool isLogin;
        public string errorMessage;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            CookieModel.isLogin = false;
            CookieModel.userName = null;
            Console.WriteLine("on get for login");
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Debug.WriteLine("onpost for login");
            Debug.WriteLine("user name: " + user.Username);

            string un = user.Username;
            string pwd = user.Password;

            try { isLogin = webService.IsLogin(un, pwd); }
            catch (SocketException)
            {
                return RedirectToPage("Error");
            }
            //isLogin = true;
            if (isLogin)
            {
                CookieModel.userName = un;
                CookieModel.isLogin = true;
                
                return Redirect("/Match/"+CookieModel.id );

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
