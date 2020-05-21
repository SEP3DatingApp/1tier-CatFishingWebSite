using CatFishingWebSite.Model;
using System.Collections.Generic;
using System.Net.Sockets;

namespace CatFishingWebSite.Services
{
    // IWebService is for razor pages
    interface IWebService
    {
        List<User> getAllUsers();
        User GetUser(string username, string password);

        // login 1st sprint
        bool IsLogin(string username, string password);

        // register
        string CreateUser(string username, string password,char gender,char sexpf);

        bool IsUniqueUserName(string username);


        // edit account
        Fisher GetFisherByName(string username);
    }
}
