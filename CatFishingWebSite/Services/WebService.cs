using CatFishingWebSite.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using CatFishingWebSite.Services;

namespace CatFishingWebSite.Services
{
    public class WebService : IWebService
    {
        public Sockets sock { get; set; }
        public WebService()
        {
            sock = new Sockets("localhost", 5000);
        }
        public List<User> getAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUser(string username, string password)
        {
            sock.GetUser(username, password);
            return null;
        }

        public bool IsLogin(string username, string password)
        {

            Debug.WriteLine(username);

            User user = sock.GetUser(username, password);
            if (user != null && username == user.Username)
            {
                return true;
            }
            return false;

        }

        public bool IsUniqueUserName(string username)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Fisher GetFisherByName(string username)
        {

            throw new NotImplementedException();
        }
    }
}
