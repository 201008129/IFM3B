using SportClient.Definition.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace SportClient.ServiceImplementation
{
    public class LoginServiceClient
    {
        public string URL = "http://localhost:57567/LoginService.svc/";
        //User Login
        public BASE_USER Login(string email, string pass)
        {
            BASE_USER user = new BASE_USER();
            try
            {
                var webclient = new WebClient();
                string url = string.Format(URL + "Login/" +  email + "," + pass);
                var json = webclient.DownloadString(url);
                var js = new JavaScriptSerializer();
                user = js.Deserialize<BASE_USER>(json);
                return user;
            }
            catch
            {
                return null;
            }
        }

        //Edit Game Stats
        public string EditGameStats(BASE_USER user)
        {
            string response = null;
            string data = null;
            //   string res = "";
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(BASE_USER));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, user);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(URL + "UpdateUser", "PUT", data);
                //  newEvent = JsonConvert.DeserializeObject<string>(response);
                //  var js = new JavaScriptSerializer();
                //  res = js.Deserialize<string>(response);
                return response;
            }
            catch
            {
                return null;
            }
        }
    }
}