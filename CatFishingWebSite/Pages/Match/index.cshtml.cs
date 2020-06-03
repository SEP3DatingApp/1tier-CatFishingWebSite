using System.Diagnostics;
using System.Net.Sockets;
using CatFishingWebSite.Model;
using CatFishingWebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public string sexp { get; set; }

        public string gend { get; set; }

        public bool isLast { get; set; }

        public indexModel(WebService service)
        {

            webService = service;

        }
        public void OnGet(int id, int otherId)
        {
            if (CookieModel.isLogin)
            {
                try { fisher = webService.GetFisherByName(otherId); }
                catch (SocketException)
                {
                    Debug.WriteLine("Error socket");
                }
                if (fisher.PersonSexualityId == 2)
                {
                    sexp = " Gay ";
                }
                else if (fisher.PersonSexualityId == 3)
                {
                    sexp = " Bisexual ";
                }
                else if (fisher.PersonSexualityId == 1)
                {
                    sexp = " Straight ";
                }
                else
                {
                    sexp = "Error";
                }

                if (fisher.Gender.Contains("M"))
                {
                    gend = " Male ";
                }
                else if (fisher.Gender.Contains("F"))
                {
                    gend = "Female";
                }
                else
                {
                    gend = " Error ";
                }
            }
            else
            {
                errorMessage = "Please login to find your match";
            }
        }


        public RedirectResult OnPostLike(int id, int otherId)
        {
            webService.LikeFisher(otherId);
            return Redirect("../Chat");
        }

        public IActionResult OnPostSkip(int id, int otherId)
        {
            if (CookieModel.count + 1 < CookieModel.otherIdsMatched.Count)
            {

                int next = CookieModel.otherIdsMatched[CookieModel.count++].Id;
                return Redirect("./" + next);
            }
            isLast = true;
            errorMessage = "It's the last one!";
            return Redirect("../LastOne/");
        }


        public RedirectResult OnPostRefuse(int otherId)
        {
            if (CookieModel.count + 1 < CookieModel.otherIdsMatched.Count)
            {
                int next = CookieModel.otherIdsMatched[CookieModel.count++].Id;
                webService.RejectFisher(otherId);
                return Redirect("./" + next);
            }
            isLast = true;
            errorMessage = "It's the last one!";
            return Redirect("../LastOne/");
        }
    }
}
