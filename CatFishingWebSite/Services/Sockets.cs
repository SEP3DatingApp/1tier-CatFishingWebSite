using CatFishingWebSite.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Linq;
// NuGet command to install for edcode token , command below
// Install-Package jose-jwt -Version 2.5.0
using System.IdentityModel.Tokens.Jwt;

namespace CatFishingWebSite.Services
{
    // send request and recevice response , Webservice will deal with the response
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
            catch (Exception)
            {
                Debug.WriteLine("WRONG");
                //client.Close();
            }
        }

        public string Create(string username,string firstname, string password, char gender, char sexpf)
        {
            Request request = new Request()
            {
                Type = RequestTypes.CREATEUSER.ToString(),
                Args = new Fisher { Username = username, FirstName = firstname ,Password = password, Gender = gender, SexPref = sexpf, IsActive = true }
            };
            string recvStr = SendReceive(request);
            Debug.WriteLine("DATA RECEIVED====" + recvStr);
            return recvStr;
        }

        public string EditFisher(int id, char sexpf, string password, string email, int age, string description, bool isActive)
        {
            Request request = new Request()
            {
                Type = RequestTypes.EDITFISHER.ToString(),
                Args = new Fisher { id = id, SexPref = sexpf, IsActive = true, Password = password, Email = email, Age = age, Description = description, token = CookieModel.token }
            };
            string recvStr = SendReceive(request);
            Debug.WriteLine("DATA RECEIVED====" + recvStr);
            return recvStr;
        }

        public string GetFisher(int id)
        {
            // get fisher by name
            Request request = new Request()
            {
                Type = RequestTypes.GETFISHER.ToString(),
                Args = new Fisher { Gender = 'M', id = id, token = CookieModel.token }
            };
            string recvStr = SendReceive(request);
            Debug.WriteLine("DATA RECEIVED====" + recvStr);

            return recvStr;
        }

        public User LoginUser(string username, string password)
        {
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
            var token = (string)jUser["token"];
            // decode token
            string jwtEncodedString = token;
            var t = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);

            Debug.WriteLine("Id => " + t.Claims.First(c => c.Type == "unique_name").Value);
            string value = t.Claims.First(c => c.Type == "unique_name").Value;
            CookieModel.token = token;
            CookieModel.id = Convert.ToInt32(value);
            user.id = Convert.ToInt32(value);
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
