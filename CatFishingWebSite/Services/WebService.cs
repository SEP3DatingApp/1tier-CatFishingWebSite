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
            //192.168.1.144
            //192.168.1.142
            //localhost
            sock = new Sockets("192.168.1.142", 5000);
        }
        public List<User> getAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUser(string username, string password)
        {
            sock.LoginUser(username, password);
            return null;
        }

        public bool IsLogin(string username, string password)
        {

            Debug.WriteLine(username);

            User user = sock.LoginUser(username, password);
            Debug.WriteLine("user: " + user.Username + " log in now!!!!");
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

        public bool CreateUser(string username, string password,char gender,char sexpf)
        {
            string reply =  sock.create(username, password, gender, sexpf);
            if (reply.Contains("200"))
            {
                return true;
            }
            return false;
        }

        public Fisher GetFisherByName(string username)
        {

            throw new NotImplementedException();
        }
    }
}
