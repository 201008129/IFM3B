using Newtonsoft.Json;
using SportClient.Definition;
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
    public class LogServiceClient
    {
        string URL = "http://localhost:57567/LogService.svc/";
        //CreateLog(Log log)
        public string CreateLog(Log log)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(Log));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, log);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                string response = webClient.UploadString(URL + "CreateLog", "POST", data);
                //int teamID = Convert.ToInt32(response);
                return response;
            }
            catch
            {
                return "faile: catched";
            }
        }
        //UpdateLog(Log log)
        public string UpdateLog(Log log)
        {
            string response = null;
            string data = null;
            //   string res = "";
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(Log));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, log);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(URL + "UpdateLog", "PUT", data);
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

        //Delete League Log By League ID
        public string DeletLogbyLeagueID(string id)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(URL + "DeletLogbyLeagueID/" + id, "DELETE", "");
                return json;
            }
            catch
            {
                string res = "Failed";
                return res;
            }
        }

        //Log GetLogByLeagueID(string ID)

        //find All Leagues by category
        public List<Log> GetleagueByCat(string Cat)
        {
            string json = null;
            List<Log> data = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(URL + "GetleagueByCat/" + Cat);
                data = JsonConvert.DeserializeObject<List<Log>>(json);
                return data;
            }
            catch
            {
                return null;
            }
        }
    }
}