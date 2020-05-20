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
        private static readonly IWebService webService = new WebService();
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
            Console.WriteLine("onget for login");
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Debug.WriteLine("onpost for login");
            Debug.WriteLine("user name: " + user.Username);

            string un = user.Username;
            string pwd = user.Password;

            try { isLogin = webService.IsLogin(un, pwd); }
            catch (SocketException e)
            {
                return RedirectToPage("Error");
            }

            if (isLogin)
            {

                return RedirectToPage("Match/" + user.Username);

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
