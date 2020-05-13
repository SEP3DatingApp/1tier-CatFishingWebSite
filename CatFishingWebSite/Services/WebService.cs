using CatFishingWebSite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatFishingWebSite.Services
{
    public class WebService : IWebService
    {
        ISockets sockets = new Sockets("127.0.0.1", 5000);
        public List<User> getAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUser(string username, string password)
        {
            sockets.GetUser(username, password);
            return null;
        }

        public bool isLogin(string username, string password)
        {
            // need to be finished
            throw new NotImplementedException();
        }


    }
}
