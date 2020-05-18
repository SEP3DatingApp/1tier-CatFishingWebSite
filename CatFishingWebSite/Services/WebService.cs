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
            User user = sockets.GetUser(username, password);
           if (user != null && username ==user.Username && password == user.Password )
            {
                return true;
            }
            return false;
             
        }

        public bool isUniqueUserName(string username)
        {
            throw new NotImplementedException();
        } 
        
        public void createUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Fisher GetFisherByName(string username)
        {
            
            throw new NotImplementedException();
        }
    }
}
