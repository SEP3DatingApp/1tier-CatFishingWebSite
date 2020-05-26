﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CatFishingWebSite.Model;
using CatFishingWebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatFishingWebSite.Pages.AccountManage
{
    public class EditModel : PageModel
    {
        private static readonly WebService webService = new WebService();
        [BindProperty]
        public Fisher fisher { get; set; }
        public int Id { get; set; }
        public string Username;
        private bool isUpdate { get; set; }

        public void OnGet(int id)
        {
           
            fisher = webService.GetFisherByName(id);

            Username = CookieModel.userName;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try {  isUpdate = webService.UpdateFisher(CookieModel.id, fisher.SexPref, fisher.Password, fisher.Email, fisher.Age, fisher.Description, fisher.IsActive); }
            catch (SocketException)
            {
                return Redirect("../error");
            }
            if (isUpdate)
            {
                Debug.WriteLine("change successfully");
            }

            return Page();
        }
    }
}