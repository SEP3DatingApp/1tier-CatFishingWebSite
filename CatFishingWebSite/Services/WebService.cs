using CatFishingWebSite.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using CatFishingWebSite.Services;

namespace CatFishingWebSite.Services
{
   
    public class WebService
    {
        private static WebService instance = new WebService();

        public static WebService getInstance()
        {
            return instance;
        }

        public Sockets sock { get; set; }
        private WebService()
        {
            //192.168.1.144
            //192.168.1.142
            //localhost
            sock = new Sockets("localhost", 5000);
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
            string reply =  sock.Create(username, password, gender, sexpf);
            if (reply.Contains("200"))
            {
                return true;
            }
            return false;
        }

        public Fisher GetFisherByName(string username)
        {
            string reply = sock.GetFisher(username);
            Debug.WriteLine("OHOHOHOH get fisher JSON");
            Debug.WriteLine(reply);
            Fisher dummy = new Fisher();
            dummy.Id = 24;
            dummy.Username = "dummy";
            dummy.Gender = 'F';
            return dummy;
        }

        public bool UpdateFisher(string username, string password, char gender, char sexpf, string firstName, string surname, string email, int age, string description, bool isActive)
        {
            throw new NotImplementedException();
        }
    }
}
