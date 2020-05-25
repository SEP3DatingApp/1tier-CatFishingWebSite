using CatFishingWebSite.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using CatFishingWebSite.Services;

namespace CatFishingWebSite.Services
{
   
    public class WebService
    {
        // private static WebService instance = new WebService();

        //public static WebService getInstance()
        //{
        //    return instance;
        //}

        public Sockets sock { get; set; }
        public WebService()
        {
            //192.168.1.144
            //192.168.1.142
            //localhost
            sock = new Sockets("192.168.1.143", 5000);
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

        public bool CreateUser(string username,string firstname, string password,char gender,char sexpf)
        {
            string reply =  sock.Create(username,firstname, password, gender, sexpf);
            if (reply.Contains("200"))
            {
                return true;
            }
            return false;
        }

        public Fisher GetFisherByName(int id)
        {
            
            string reply = sock.GetFisher(id);

            if (reply.Contains("role fisher"))
            {
                //string js = @"{""fisher"":" + recvStr + "}";
                //Debug.WriteLine(js);
                //JObject jObject = JObject.Parse(js);
               // JToken jFisher = jObject["fisher"];
                //Fisher fisher = new Fisher();
                //fisher.Username = (string)jUser["username"];
                //fisher.id = id;
                //fisher.Gender = jFisher["gender"];
                //fisher.SexPref = jFisher["sexprf"];
                //fisher.FirstName = jFisher["firstname"];
                //fisher.Surname = jFisher["surname"];
                //fisher.Age = jFisher["age"];
                //fisher.Description = jFisher["description"];
                //user.Usertype = (string)jUser["role"];
                //var token = (string)jUser["token"];
            }else if(reply.Contains("role admin"))
            {

            }

            Fisher dummy = new Fisher();
            dummy.id = 9;
            dummy.Username = "dummy";
            dummy.Gender = 'F';
            return dummy;
        }

        public bool UpdateFisher(int id, char sexpf, string password, string email, int age, string description, bool isActive)
        {
            string req = sock.EditFisher(id, sexpf, password, email, age, description, isActive);

            if (req.Contains("200"))
            {
                return true;
            }
            return false;
        }
    }
}
