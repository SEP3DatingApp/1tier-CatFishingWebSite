using CatFishingWebSite.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                //GetUser("client2", "qwerty");
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
                Type = RequestTypes.LOGIN.ToString(),
                Args = new User() { Username = username, Password = password }
            };
            var json = System.Text.Json.JsonSerializer.Serialize(request);

            Debug.WriteLine(json);
            byte[] byData = Encoding.ASCII.GetBytes(json + ";");


            Debug.WriteLine(BitConverter.ToString(byData));

            client.Send(byData);

            Debug.Write("data have been sent");

            json = Encoding.ASCII.GetString(byData);
            Debug.WriteLine(json);




            //// receive data：

            string recvStr = "";
            byte[] recvBytes = new byte[1024];
            int bytes;
            bytes = client.Receive(recvBytes, recvBytes.Length, 0);
            recvStr += Encoding.ASCII.GetString(recvBytes, 0, bytes);
            Debug.WriteLine("DATA RECEIVED====" + recvStr);

            if (recvStr.Contains("Username or password is incorrect"))
            {
                return null;
            }


            string js = @"{""user"":"+recvStr + "}";
            Debug.WriteLine(js);
            JObject jObject = JObject.Parse(js);
            JToken jUser = jObject["user"];
            User user = new User();
            user.Username = (string)jUser["username"];
            user.Usertype = (string)jUser["role"];
            string token = (string)jUser["token"];
            
            Debug.WriteLine("hello : "+user.Username);

            // DATA RECEIVED===={ "role":"Administrator","userID":2,"username":"admin1","token":"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQWRtaW5pc3RyYXRvciIsIm5iZiI6MTU4OTk5MTgwMywiZXhwIjoxNTg5OTk1NDAzLCJpYXQiOjE1ODk5OTE4MDN9.Io8en2j6urqXQQBLD1wM0SK8lTMAp8ETsRhmND3aag0"}
            //json = JsonSerializer.Deserialize(byData.Enc)
         //   user = JsonSerializer.Deserialize<User>(js);
            if (user.Username != "")
            {
                return user;
            }
              
                return null;
        }
    }
}
 