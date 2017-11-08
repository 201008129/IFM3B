using SportClient.Definition.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace SportClient.ServiceImplementation
{
    public class RegServiceClient
    {
        private string URL = "http://localhost:57567/RegistrationService.svc/";
        //Register User
        public int RegisterUser(BASE_USER user)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(BASE_USER));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, user);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                string response = webClient.UploadString(URL + "registerUser", "POST", data);
                int res = Convert.ToInt32(response);
                return res;
            }
            catch
            {
                return 0;
            }
        }

        //Insert Team Player
        public string InsertTeamPlayer(Player player)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(Player));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, player);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                string response = webClient.UploadString(URL + "registerPlayer", "POST", data);

                return response;
            }
            catch
            {
                return null;
            }
        }

    }
}