using Newtonsoft.Json;
using SportClient.Definition;
using SportClient.Definition.Reporting;
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
    public class TeamServiceClient
    {
        private string URL = "http://localhost:57567/TeamService.svc/";

        // List<TeamModel> getLeagueTeams(string leagueID)

        public List<rep_Teams> getLeagueTeams(string leagueID)
        {
            Team item = new Team();
           
            string json = null;
            List<rep_Teams> data = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(URL + "getLeagueTeams/" + leagueID);
                data = JsonConvert.DeserializeObject<List<rep_Teams>>(json);
                return data;
            }
            catch
            {
                return null;
            }
        }

        //AddTeam(Team _team)
        public int AddTeam(Team _team)
        {
           
                _team.eDate = DateTime.Now;
                //_team.sDate = DateTime.Now;
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(Team));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, _team);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                string response = webClient.UploadString(URL + "AddTeam", "POST", data);
                int teamID = Convert.ToInt32(response);
                return teamID;
            
        }
        //EditTeam(Team _team)
        public string EditTeam(Team _team)
        {
            string response = null;
            string data = null;
            //   string res = "";
            _team.eDate = DateTime.Now;
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(Team));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, _team);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(URL + "EditTeam", "PUT", data);
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

        //find teams by sport  category
        public List<Team> getAllTeamByCategory(string category)
        {
            string json = null;
            List<Team> data = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(URL + "getAllTeamByCategory/" + category);
                data = JsonConvert.DeserializeObject<List<Team>>(json);
                return data;
            }
            catch
            {
                return null;
            }
        }
        //find Leagues by sport  category
        public List<League> getAllLeaguesByCategory(string category)
        {
            string json = null;
            List<League> data = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(URL + "getAllLeaguesByCategory/" + category);
                data = JsonConvert.DeserializeObject<List<League>>(json);
                return data;
            }
            catch
            {
                return null;
            }
        }

        //find current playing games for specific league
        public List<MyTeamModel> getTeamsByGameID(string gID)
        {
            string json = null;
            List<MyTeamModel> data = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(URL + "getTeamsByGameID/" + gID);
                data = JsonConvert.DeserializeObject<List<MyTeamModel>>(json);
                return data;
            }
            catch
            {
                return null;
            }
        }

        //find team details
        public MyTeamModel getTeamsDetails(string ID)
        {
            string json = null;
            MyTeamModel data = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(URL + "getTeamsDetails/" + ID);
                data = JsonConvert.DeserializeObject<MyTeamModel>(json);
                return data;
            }
            catch
            {
                return null;
            }
        }

        //Delete Team by ID
        public string DeleteGameByID(string id)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(URL + "DeleteSportByID/" + id, "DELETE", "");
                return json;
            }
            catch
            {
                string res = "Failed";
                return res;
            }
        }

        //Delete Team by ID
        public string DeleteTeamByID(string id)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(URL + "DeleteSportByID/" + id, "DELETE", "");
                return json;
            }
            catch
            {
                string res = "Failed";
                return res;
            }
        }

        //TeamModel getTeamsDetails(string ID)
    }
}