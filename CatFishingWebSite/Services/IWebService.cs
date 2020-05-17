using CatFishingWebSite.Model;
using System.Collections.Generic;

namespace CatFishingWebSite.Services
{
    // IWebService is for razor pages
    interface IWebService
    {
        List<User> getAllUsers();
        User GetUser(string username,string password);

        // login
        bool isLogin(string username, string password);


        // register
        void createUser(string username, string password);

        bool isUniqueUserName(string username);


        // edit account
    }
}
