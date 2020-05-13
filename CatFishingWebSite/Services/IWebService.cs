using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatFishingWebSite.Services
{
    interface IWebService
    {
        public  bool IsLogin(string Username, string Password);
    }
}
