﻿using CatFishingWebSite.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Linq;
// NuGet command to install for edcode token , command below
// Install-Package jose-jwt -Version 2.5.0
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace CatFishingWebSite.Services
{
    // send request and recevice response , Webservice will deal with the response
    public class Sockets : ISockets
    {
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public Sockets(string ipAdressOfServer, int port)
        {
            try
            {
                client.Connect(ipAdressOfServer, port);
                Debug.WriteLine("Connection is succesfull");
            }
            catch (Exception)
            {
                Debug.WriteLine("WRONG");
            }
        }

        public string Create(string username, string firstname, int age, string password, string gender, int sexpf)
        {
            Request request = new Request()
            {
                Type = RequestTypes.CREATEUSER.ToString(),
                Args = new Fisher { Username = username, FirstName = firstname, Password = password, Age = age, Gender = gender, PersonSexualityId = sexpf, IsActive = true }
            };
            string recvStr = SendReceive(request);
            return recvStr;
        }

        public string EditFisher(int id, int sexpf, string password, string email, string description, bool isActive)
        {
            Request request = new Request()
            {
                Type = RequestTypes.EDITFISHER.ToString(),
                Args = new Fisher { id = id, PersonSexualityId = sexpf, IsActive = isActive, Password = password, Email = email, Description = description, token = CookieModel.token }
            };
            string recvStr = SendReceive(request);
            return recvStr;
        }

        public string GetFisher(int id)
        {
            // get fisher by id
            Request request = new Request()
            {
                Type = RequestTypes.GETFISHER.ToString(),
                Args = new Fisher { id = id, token = CookieModel.token }
            };
            string recvStr = SendReceive(request);
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
            JObject jObject = JObject.Parse(js);
            JToken jUser = jObject["user"];
            User user = new User();
            user.Username = (string)jUser["username"];
            user.Usertype = (string)jUser["role"];
            var token = (string)jUser["Token"];
            // decode token
            string jwtEncodedString = token;
            var t = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);
            string value = t.Claims.First(c => c.Type == "unique_name").Value;
            CookieModel.token = token;
            CookieModel.id = Convert.ToInt32(value);
            user.id = Convert.ToInt32(value);

            if (user.Username != "")
            {
                return user;
            }
            return null;
        }

        public void Logout()
        {
            Request request = new Request()
            {
                Type = RequestTypes.LOGOUT.ToString(),
                Args = new User { }
            };
            SendReceive(request);
        }

        public string GetMatchList(int id)
        {
            Request request = new Request()
            {
                Type = RequestTypes.MATCHLIST.ToString(),
                Args = new MatchIDs { id = id, token = CookieModel.token }
            };
            string recvStr = SendReceive(request);

            return recvStr;
        }

        public string Like(int otherId)
        {
            Request request = new Request()
            {
                Type = RequestTypes.LIKE.ToString(),
                Args = new MatchModel { OtherId = otherId }
            };
            string recvStr = SendReceive(request);

            return recvStr;
        }
        public string Reject(int otherId)
        {
            Request request = new Request()
            {

                Type = RequestTypes.REJECT.ToString(),
                Args = new MatchModel { OtherId = otherId }
            };
            string recvStr = SendReceive(request);

            return recvStr;
        }
        public string GetHis()
        {
            Request request = new Request()
            {
                Type = RequestTypes.HISTORY.ToString()
            };
            string recvStr = SendReceive(request);

            return recvStr;
        }
        private string SendReceive(Request request)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(request);
            byte[] byData = Encoding.ASCII.GetBytes(json + ";");
            //send
            client.Send(byData);
            //receive
            string recvStr = "";
            byte[] recvBytes = new byte[1024];
            int bytes;
            bytes = client.Receive(recvBytes, recvBytes.Length, 0);
            recvStr += Encoding.ASCII.GetString(recvBytes, 0, bytes);
            return recvStr;
        }
    }
}
