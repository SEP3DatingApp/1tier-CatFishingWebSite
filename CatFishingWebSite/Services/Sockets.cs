using CatFishingWebSite.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CatFishingWebSite.Services
{
    public class Sockets : ISockets
    { 
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public Sockets(string ipAdressOfServer,int port)
        {
            GetUser("a","opwd");
            Debug.WriteLine("Trying To connect to the server");
            try
            {
                client.Connect(ipAdressOfServer,port);
                Debug.WriteLine("Connection is succesfull");
            }
            catch (Exception e)
            {
                Debug.WriteLine("WRONG");
                //client.Close();
            }
        }

        public User GetUser(string username, string password)
        {
            Debug.WriteLine("MetHoOOOOOOOOOOOOOOOOOOOOOOOOOOD");
            Request request = new Request()
            {
                Type = RequestTypes.GETUSER,
                Arg = new User() { Username = username,Password = password }
            };
            var json = JsonSerializer.Serialize(request);
            Debug.WriteLine(json);
            byte[] byData = Encoding.ASCII.GetBytes(json + ";");
            client.Send(byData);
            Debug.Write("data have been sent");
            json = Encoding.ASCII.GetString(byData);
            Debug.WriteLine(json);
            //var jjs = JsonSerializer.Deserialize(json);
            User user = new User();
            {
                
            }

            return null;
            //json = JsonSerializer.Deserialize(byData.Enc)

        }
    }
}
