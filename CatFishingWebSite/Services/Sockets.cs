using CatFishingWebSite.Model;
using Newtonsoft.Json;
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
           
            Debug.WriteLine("Trying To connect to the server");
            try
            {
                client.Connect(ipAdressOfServer,port);
                Debug.WriteLine("Connection is succesfull");
                GetUser("client2", "qwerty");
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
                Type = RequestTypes.LOGIN,
                Args = new User() { Username = username,Password = password }
            };
             var json = System.Text.Json.JsonSerializer.Serialize(request);
             
            Debug.WriteLine(json);
            byte[] byData = Encoding.ASCII.GetBytes(json);
            string m = "hello";
            byte[] dd = Encoding.ASCII.GetBytes("hello");
            client.Send(dd);
            Debug.Write("data have been sent");
    
            json = Encoding.ASCII.GetString(byData);
            Debug.WriteLine(json);


            // receive data：
            //string recvStr = "";
            //byte[] recvBytes = new byte[1024];
            //int bytes;
            //bytes = client.Receive(recvBytes, recvBytes.Length, 0);
            //recvStr += Encoding.ASCII.GetString(recvBytes, 0, bytes);
            //Debug.WriteLine("DATA RECEIVED===="+ recvStr);
            //var jjs = JsonSerializer.Deserialize(json);
            //User user = new User();
            //{

            //}
           //User user = JsonConvert.DeserializeObject<User>(recvStr);
           
            return null;
            //json = JsonSerializer.Deserialize(byData.Enc)

        }
    }
}
