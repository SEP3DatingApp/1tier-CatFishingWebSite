using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CatFishingWebSite.Model;
using CatFishingWebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CatFishingWebSite.Pages.Match
{
    // match page for fisher , provide users after fitter
    public class indexModel : PageModel
    {
        public string errorMessage;
        private WebService webService = WebService.getInstance();
        [BindProperty]
        public Fisher fisher { get; set; }

        public string Title { get; set; }
        public void OnGet(int id, int otherId)
        {
            Debug.WriteLine("ID: " + id);
            Debug.WriteLine("OI " + otherId);
            if (CookieModel.isLogin)
            {
                fisher = webService.GetFisherByName(CookieModel.otherIdsMatched[CookieModel.count]);
            }
            else
            {
                errorMessage = "Please login to find your match";
            }

        }

        //public async Task<IActionResult> OnGetAsync(int id,int otherId)
        //{

        //    Console.WriteLine(id);
        //    message = "hello user ";
        //    if (id == 0)
        //    {
        //        return NotFound();
        //    }


        //    return Page();
        //}
        public async Task<IActionResult> OnPostAsync()
        {
            Debug.WriteLine("shit a fisher");
            return Redirect("../index");
        }

        public RedirectResult OnPostLike(int id, int otherId)
        {
            Debug.WriteLine("ID: " + id);
            Debug.WriteLine("OI " + otherId);
            Debug.WriteLine("like a fisher");
            return Redirect("./Chat");


        }

        public void OnPostSkip()
        {
            Debug.WriteLine("Skip a fisher");
        }
        public void OnPostBack()
        {
            Debug.WriteLine("Back a fisher");
        }

        public void OnPostRefuse(int id, int otherId)
        {
            Debug.WriteLine("Skip a fisher");
        }
    }
}