using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatFishingWebSite.Model
{
    // store user data after login
    public class CookieModel
    {
        public static bool isLogin { get; set; }

        public static string userName { get; set; }

        public string token { get; set; }
    }
}
