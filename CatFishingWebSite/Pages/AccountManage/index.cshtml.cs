using CatFishingWebSite.Model;
using CatFishingWebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatFishingWebSite.Pages.AccountManage
{
    public class indexModel : PageModel
    {
        private readonly WebService webService;

        public indexModel(WebService service)
        {
            webService = service;
        }

        public Fisher fisher { get; set; }
        public string isAct { get; set; }
        public string Gend { get; set; }
        public string SexP { get; set; }
        public void OnGet(int id)
        {
            fisher = webService.GetFisherByName(id);

            if (fisher.IsActive)
            {
                isAct = "Active";
            }
            else
            {
                isAct = "Not active";
            }

            if (fisher.Gender.Contains("M"))
            {
                Gend = "Male";
            }
            else
            {
                Gend = "Female";
            }
            if (fisher.PersonSexualityId == 2)
            {
                SexP = "Gay";
            }
            else if (fisher.PersonSexualityId == 3)
            {
                SexP = "Bisexual";
            }
            else
            {
                SexP = "Straight";
            }
        }
    }
}