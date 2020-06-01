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
  
            if (CookieModel.isLogin)
            {
                try { fisher = webService.GetFisherByName(CookieModel.otherIdsMatched[CookieModel.count]); }
                catch (SocketException)
                {
                    Debug.WriteLine("Error socket");
                }
            }
            else
            {
                errorMessage = "Please login to find your match";
            }
        }


        public RedirectResult OnPostLike(int id, int otherId)
        {
            Debug.WriteLine("like a fisher");
            webService.LikeFisher(id, otherId);
            return Redirect("./Chat");
        }

        public RedirectResult OnPostSkip(int id, int otherId)
        {
            if (CookieModel.count++ < CookieModel.otherIdsMatched.Count())
            {
                int next = CookieModel.otherIdsMatched[CookieModel.count++];
                return Redirect("./" + id + "&" + next);
            }
            Debug.WriteLine("Skip a fisher");
            return Redirect("./" + id + "&" + otherId);
        }


        public RedirectResult OnPostRefuse(int id, int otherId)
        {
            Debug.WriteLine("Reject a fisher");
            int next = CookieModel.otherIdsMatched[CookieModel.count++];
            webService.RejectFisher(id, otherId);
            return Redirect("./" + id + "&" + next);
        }
    }
}
