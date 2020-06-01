using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatFishingWebSite.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatFishingWebSite.Pages.AccountManage
{
    public class LikeMeBackModel : PageModel
    {
        public List<History> histories { get; set; }
        public void OnGet()
        {
            histories = new List<History>();
            histories.Add(new History(1, 2, 3));
            histories.Add(new History(1, 95, 3));
            histories.Add(new History(1, 10, 3));
            histories.Add(new History(1, 44, 3));
            histories.Add(new History(1, 7, 3));
            histories.Add(new History(1, 67, 3));
            histories.Add(new History(1, 42, 3));
            histories.Add(new History(1, 86, 3));
            histories.Add(new History(1, 23, 3));
        }
    }
}