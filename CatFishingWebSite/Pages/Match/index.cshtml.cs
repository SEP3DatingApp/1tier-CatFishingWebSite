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
        private WebService webService;
        [BindProperty]
        public Fisher fisher { get; set; }

        public string Title { get; set; }

        public indexModel( WebService service)
        {
            
            webService = service;

        }
        public void OnGet(int id, int otherId)
        {
  
            if (CookieModel.isLogin)
            {
                Debug.WriteLine(CookieModel.count);
                try { fisher = webService.GetFisherByName(CookieModel.otherIdsMatched[CookieModel.count].Id); }
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
            webService.LikeFisher(otherId);
            return Redirect("./Chat");
        }

        public RedirectResult OnPostSkip(int id, int otherId)
        {
            if (CookieModel.count +1< CookieModel.otherIdsMatched.Count)
            {
                int next = CookieModel.otherIdsMatched[CookieModel.count++].Id;
                return Redirect("./" + id + "&" + next);
            }
            Debug.WriteLine("Skip a fisher");
            errorMessage = "It's the last one!";
            return Redirect("./" + id + "&" + otherId);
        }


        public RedirectResult OnPostRefuse(int id, int otherId)
        {
            Debug.WriteLine("Reject a fisher");
            if (CookieModel.count + 1 < CookieModel.otherIdsMatched.Count)
            {
                int next = CookieModel.otherIdsMatched[CookieModel.count++].Id;
                webService.RejectFisher(otherId);
                return Redirect("./" + id + "&" + next);
            }
            errorMessage = "It's the last one!";
            return Redirect("./" + id + "&" + otherId);
        }
    }
}
