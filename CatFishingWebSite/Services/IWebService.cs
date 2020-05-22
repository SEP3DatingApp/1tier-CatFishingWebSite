using CatFishingWebSite.Model;
using Microsoft.Extensions.Primitives;
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
        bool CreateUser(string username, string password,char gender,char sexpf);

        // edit account
        Fisher GetFisherByName(string username);

       // bool UpdateFisher(string username, string password, char gender, char sexpf, string firstName, string surname, string email, int age, string description, bool isActive);
    }
}
