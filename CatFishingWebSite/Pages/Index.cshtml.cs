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

namespace CatFishingWebSite.Pages
{
    public class IndexModel : PageModel

    {
        private static readonly WebService webService = new WebService();
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
            bool  isint = true;
            string un = user.Username;
            string pwd = user.Password;
        // check user input if int
            try
            {
                Convert.ToInt32(un);
               isint =  true;
            }
            catch { isint = false; }

            if (un == null || pwd == null  || un=="" || isint)
            {
                errorMessage = "Username or password is reqired";
                return Page();
            }

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
