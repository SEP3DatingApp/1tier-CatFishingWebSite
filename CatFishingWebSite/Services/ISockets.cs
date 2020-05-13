using CatFishingWebSite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatFishingWebSite.Services
{
    interface ISockets
    {
        User GetUser(string username, string password);
    }
}
