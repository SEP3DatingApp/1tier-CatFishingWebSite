using CatFishingWebSite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatFishingWebSite.Services
{
    interface ISockets
    {
        User LoginUser(string username, string password);

        string Create(string username,string firstname, string password, char gender, char sxepf);

        string GetFisher(int id);

        string EditFisher(int id, char sexpf, string password, string email, int age, string description, bool isActive);


    }
}
