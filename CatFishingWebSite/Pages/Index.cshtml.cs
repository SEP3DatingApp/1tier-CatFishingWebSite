using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatFishingWebSite.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CatFishingWebSite.Pages
{
    public class IndexModel : PageModel

    {
        [BindProperty]
        public User user { get; set; }
        
        private readonly ILogger<IndexModel> _logger;

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
            Console.WriteLine("onpost for login"); 
            Console.WriteLine("user name: "+user.Username);
            Console.WriteLine(user.Password);
           
            if (user.Username.Equals("1") && user.Password.Equals("1"))
            {
                
                return RedirectToPage("Match/index/"+user.Username);
                
            }else
           errorMessage = "invalid"; 
            return Page();
            
        }
    }
}
