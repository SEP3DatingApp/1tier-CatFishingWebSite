using CatFishingWebSite.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using CatFishingWebSite.Services;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Nancy.Json;
using AutoMapper;

namespace CatFishingWebSite.Services
{

    public class WebService
    {
        private static WebService instance;
        private readonly IMapper _mapper;

        public WebService(IMapper mapper, WebService service)
        {
            _mapper = mapper;
            instance = service;
        }

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
            sock = new Sockets("192.168.1.144", 5000);
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

        public bool CreateUser(string username, string firstname,int age, string password, string gender, int sexpf)
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
            fisher.PersonSexualityId = (int)jFisher["personSexualityId"];
            fisher.FirstName = (string)jFisher["firstName"];
            fisher.Age = (int)jFisher["age"];
            fisher.Description = (string)jFisher["description"];


            return fisher;
        }

        public bool UpdateFisher(int id, int sexpf, string password, string email, string description, bool isActive)
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
        //  sock.Logout();
        }
        //method for Match

        //get list of ID which match with primeUser
 public List<IdOfUser> GetFishersList(int id)
        {

            string json = sock.GetMatchList(id);   
            Debug.WriteLine("WebService getList :     "+json);

            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<IdOfUser> records =new List<IdOfUser>(  ser.Deserialize<List<IdOfUser>>(json));
            Debug.WriteLine("List: "+records[0]);
            return records;
        }
        // like fisher 
        public void LikeFisher(int otherId)
        {
            Debug.WriteLine("Like");
           string re =  sock.Like(otherId);
            Debug.WriteLine(re);
            
        }
        //reject fisher
        public void RejectFisher(int otherid)
        {
            Debug.WriteLine("Reject");

            string re = sock.Reject(otherid);
            Debug.WriteLine(re);
        }

        public List<Fisher> GetLikeMeBackList(int id)
        {
            return null;
        }
    }
}
