using CatFishingWebSite.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatFishingWebSite.Pages.AccountManage
{
    public class SuccessModel : PageModel
    {
        public int Id;
        public void OnGet()
        {
            Id = CookieModel.id;
        }
    }
}