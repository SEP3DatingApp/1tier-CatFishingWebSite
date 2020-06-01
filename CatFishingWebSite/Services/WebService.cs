﻿using CatFishingWebSite.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using CatFishingWebSite.Services;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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
        public WebService()
        {
            //192.168.1.144
            //192.168.1.142
            //localhost
            //
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

            if (user != null && username == user.Username)
            {
                return true;
            }
            return false;

        }

        public bool CreateUser(string username, string firstname,int age, string password, string gender, string sexpf)
        {
            string reply = sock.Create(username, firstname,age, password, gender, sexpf);
            if (reply.Contains("200"))
            {
                return true;
            }
            return false;
        }

        public Fisher GetFisherByName(int id)
        {
            Fisher fisher = new Fisher();
            string reply = sock.GetFisher(id);
            if (reply.Contains("ResponseCode"))
            {
                Debug.WriteLine("Failed to get fisher");
                return fisher;
            }

            string js = @"{""fisher"":" + reply + "}";
            Debug.WriteLine(js);
            JObject jObject = JObject.Parse(js);
            JToken jFisher = jObject["fisher"];
             
            fisher.Username = (string)jFisher["username"];
            fisher.id = id;
            fisher.IsActive = (bool)jFisher["isActive"];
            fisher.Email =(string) jFisher["email"];
            fisher.Gender = (string)jFisher["gender"];
            fisher.SexPref = (string)jFisher["sexPref"];
            fisher.FirstName = (string)jFisher["firstName"];
            fisher.Age = (int)jFisher["age"];
            fisher.Description = (string)jFisher["description"];


            return fisher;
        }

        public bool UpdateFisher(int id, string sexpf, string password, string email, string description, bool isActive)
        {
            string req = sock.EditFisher(id, sexpf, password, email, description, isActive);

            if (req.Contains("200"))
            {
                return true;
            }
            return false;
        }
   

        public void Logout()
        {
            Debug.WriteLine("user ready to logout");
          sock.Logout();
        }
        //method for Match

        //get list of ID which match with primeUser
 public List<int> GetFishersList(int id)
        {
            string json = sock.GetMatchList(id);
            List<int> model = JsonConvert.DeserializeObject<List<int>>(json);
            Debug.WriteLine(json);
            return model;
        }
        // like fisher 
        public void LikeFisher(int primeId ,int otherId)
        {
            Debug.WriteLine("Like");
           string re =  sock.Like(primeId, otherId);
            Debug.WriteLine(re);
            
        }
        //reject fisher
        public void RejectFisher(int primeId,int otherid)
        {
            Debug.WriteLine("Reject");
            string re = sock.Reject(primeId, otherid);
            Debug.WriteLine(re);
        }

        public List<Fisher> GetLikeMeBackList(int id)
        {
            return null;
        }
    }
}
