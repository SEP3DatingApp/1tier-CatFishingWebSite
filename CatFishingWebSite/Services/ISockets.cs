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

        string Create(string username,string firstname, int age,string password, string gender, string sxepf);

        string GetFisher(int id);

        string EditFisher(int id, string sexpf, string password, string email, string description, bool isActive);

        void Logout();
        //Match

        string GetMatchList(int id);

        string Like(int id, int otherId);

        string Reject(int id, int otherId);
    }
}
