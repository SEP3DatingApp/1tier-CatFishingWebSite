using System.Collections.Generic;
using System.Net.Sockets;
using CatFishingWebSite.Model;
using CatFishingWebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatFishingWebSite.Pages.AccountManage
{
    public class LikeMeBackModel : PageModel
    {
        private readonly WebService webService;
        public LikeMeBackModel(WebService service)
        {
            webService = service;
        }
        public List<History> histories { get; set; }
        public void OnGet()
        {
            // sprint backlog “Like me back history“ not done
            try
            {
                //histories = webService.GetHistory();
                histories = new List<History>();
                
            }
            catch (SocketException) { }


        }
    }
}