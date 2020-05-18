using CatFishingWebSite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatFishingWebSite.Services
{
    //Dummy user for test   (HZ)
    public class DummyServer
    {
        private Fisher dummy;
        public DummyServer()
        {
            dummy = new Fisher();
            dummy.UserID = 1;
            dummy.Username = "dummy";
            dummy.Password = "password";
            dummy.SexPref = 'f';
            dummy.FirstName = "Dummy";
            dummy.Surname = "Test";
            dummy.Age = 23;
            dummy.Email = "22@via.dk";
        }
        public Fisher GetFisher()
        {
           
            return dummy;
            //throw new NotImplementedException();
        }
    }
}
