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

        public Sockets(string ipAdressOfServer, int port)
        {

            Debug.WriteLine("Trying To connect to the server");
            try
            {
                client.Connect(ipAdressOfServer, port);
                Debug.WriteLine("Connection is succesfull");
            }
            catch (Exception e)
            {
                Debug.WriteLine("WRONG");
                //client.Close();
            }
        }

        public string create(string username, string password, char gender, char sexpf)
        {
            Request request = new Request()
            {
                Type = RequestTypes.CREATEUSER.ToString(),
                Args = new Fisher { Username = username, Password = password, Gender = gender, SexPref = sexpf, IsActive = true }
            };
            string recvStr = SendReceive(request);
            Debug.WriteLine("DATA RECEIVED====" + recvStr);
            return recvStr;
        }

        public User LoginUser(string username, string password)
        {

            Debug.WriteLine("MetHoOOOOOOOOOOOOOOOOOOOOOOOOOOD");
            Request request = new Request()
            {
                Type = RequestTypes.LOGIN.ToString(),
                Args = new User() { Username = username, Password = password }
            };
            string recvStr = SendReceive(request);

            if (recvStr.Contains("Username or password is incorrect"))
            {
                return null;
            }

            string js = @"{""user"":" + recvStr + "}";
            Debug.WriteLine(js);
            JObject jObject = JObject.Parse(js);
            JToken jUser = jObject["user"];
            User user = new User();
            user.Username = (string)jUser["username"];
            user.Usertype = (string)jUser["role"];
            string token = (string)jUser["token"];

            Debug.WriteLine("hello : " + user.Username);

            if (user.Username != "")
            {
                return user;
            }
            return null;
        }
        private string SendReceive(Request request)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(request);

            Debug.WriteLine(json);
            byte[] byData = Encoding.ASCII.GetBytes(json + ";");

            Debug.WriteLine(BitConverter.ToString(byData));
            //send
            client.Send(byData);

            Debug.Write("data have been sent");

            json = Encoding.ASCII.GetString(byData);
            //receive
            string recvStr = "";
            byte[] recvBytes = new byte[1024];
            int bytes;
            bytes = client.Receive(recvBytes, recvBytes.Length, 0);
            recvStr += Encoding.ASCII.GetString(recvBytes, 0, bytes);
            Debug.WriteLine("DATA RECEIVED==== " + recvStr);
            return recvStr;
        }
    }
}
