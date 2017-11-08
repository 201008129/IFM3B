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
    public class LeagueClient
    {
        string URL = "http://localhost:57567/LeagueService.svc/";

        //CreateLeagueTeams(Team _teams)
        public string CreateLeagueTeams(Team _teams)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(Team));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, _teams);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                string response = webClient.UploadString(URL + "CreateLeagueTeams", "POST", data);
                //int leagueID = Convert.ToInt32(response);
                if(response.Contains("true"))
                {
                    return "success";
                }else
                {
                    return "fail";
                }
            }
            catch (Exception)
            {
                return "fail";
            }
        }
        //CreateLeague(League _league)
        public int CreateLeague(League _league)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(League));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, _league);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                string response = webClient.UploadString(URL + "CreateLeague", "POST", data);
                int leagueID = Convert.ToInt32(response);
                return leagueID;
            }
            catch(Exception)
            {
                return 0;
            }
        }
        //UpdateLeague(League _league)
        public string UpdateLeague(League _league)
        {
            string response = null;
            string data = null;
            //   string res = "";
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(League));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, _league);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(URL + "UpdateLeague", "PUT", data);
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


        //Getters====================>>>>
        //find All Leagues
        public List<League> GetAllLeagues()
        {
            string json = null;
            List<League> data = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(URL + "GetAllLeagues");
                data = JsonConvert.DeserializeObject<List<League>>(json);
                return data;
            }
            catch
            {
                return null;
            }
        }

        //find All Leagues by category
        public List<League> GetleagueByCat(string Cat)
        {
            string json = null;
            List<League> data = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(URL + "GetleagueByCat/" + Cat);
                data = JsonConvert.DeserializeObject<List<League>>(json);
                return data;
            }
            catch
            {
                return null;
            }
        }

        public List<League> GetleagueByUseID(string UserID)
        {
            string json = null;
            List<League> data = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(URL + "GetleagueByUseID/" + UserID);
                data = JsonConvert.DeserializeObject<List<League>>(json);
                return data;
            }
            catch
            {
                return null;
            }
        }

        //GetleagueByID
        public League GetleagueByID(string ID)
        {
            string json = null;
            League data = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(URL + "GetleagueByID/" + ID);
                data = JsonConvert.DeserializeObject<League>(json);
                return data;
            }
            catch
            {
                return null;
            }
        }


        //=================----DELETION--------===================>>
        //Delete Sport League Bridging Table
        public string dl_SprotLeague_BTByID(string sportID)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(URL + "DeletSportInBT/" + sportID, "DELETE", "");
                if (json.ToLower().Contains("success"))
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

        //Delete League
        public string dl_League(string ID)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(URL + "DL_LeagueBYID/" + ID, "DELETE", "");
                return json;
            }
            catch
            {
                string res = "Failed";
                return res;
            }
        }

    }
}