using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace SportClient.ServiceImplementation
{
    public class PlayerServiceClient
    {

        string URL = "http://localhost:57567/PlayerService.svc/";

        //Delete Player By Sport ID
        public string Dl_PlayersBySportID(string id)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(URL + "Dl_PlayersBySportID/" + id, "DELETE", "");
                if(json.ToLower().Contains("success"))
                {
                    return "succcess";
                }
                else
                {
                    return "fail";
                }
            }
            catch
            {
                string res = "Failed";
                return res;
            }
        }
    }
}