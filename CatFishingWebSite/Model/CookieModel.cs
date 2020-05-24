using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatFishingWebSite.Model
{
    // store user data after login
    public class CookieModel
    {
        // set login info for navigation bar
        public static bool isLogin { get; set; }
        // set username for navigation bar
        public static string userName { get; set; }

        public static int id { get; set; }

        // store token after login
        public static string token { get; set; }
    }
}
