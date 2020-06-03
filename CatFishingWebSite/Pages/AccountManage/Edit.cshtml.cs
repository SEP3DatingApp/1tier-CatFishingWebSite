using System.Diagnostics;
using System.Net.Sockets;
using CatFishingWebSite.Model;
using CatFishingWebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatFishingWebSite.Pages.AccountManage
{
    public class EditModel : PageModel
    {
        private readonly WebService webService;
        public EditModel(WebService service)
        {
            webService = service;
        }
        [BindProperty]
        public Fisher fisher { get; set; }
        public int Id { get; set; }
        public string Username;
        private bool isUpdate { get; set; }

        public void OnGet(int id)
        {
            fisher = webService.GetFisherByName(id);
            CookieModel.id = id;
            Username = CookieModel.userName;
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(fisher.Password))
            {
                fisher.Password = null;
            }
            try { isUpdate = webService.UpdateFisher(CookieModel.id, fisher.PersonSexualityId, fisher.Password, fisher.Email, fisher.Description, fisher.IsActive); }
            catch (SocketException)
            {
                return Redirect("../error");
            }
            if (isUpdate)
            {
                return RedirectToPage("./Success");
            }
            return Page();
        }
    }
}