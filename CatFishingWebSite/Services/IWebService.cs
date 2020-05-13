using CatFishingWebSite.Model;
using System.Collections.Generic;

namespace CatFishingWebSite.Services
{
    interface IWebService
    {
        List<User> getAllUsers();
        User GetUser(string username,string password);
    }
}
