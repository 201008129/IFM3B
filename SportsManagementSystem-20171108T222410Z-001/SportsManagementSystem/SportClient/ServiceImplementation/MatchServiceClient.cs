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

namespace SportClient.ServiceImplementation
{
    public class MatchServiceClient
    {
        private string URL = "http://localhost:57567/GameService.svc/";
        //int AddMatch(Game game)
        public int AddMatch(Game game)
        {
            try
            {
                game.ticket_pDate = DateTime.Now;
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(Game));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, game);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                string response = webClient.UploadString(URL + "AddMatch", "POST", data);
                int GameID = Convert.ToInt32(response);
                return GameID;
            }
            catch
            {
                return 0;
            }
        }
        //AddBestPlayer
        public void AddBestPlayer(bestplayer BPlayer)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(bestplayer));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, BPlayer);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                string response = webClient.UploadString(URL + "AddBestPlayer", "POST", data);
                string check = response;
            }
            catch(Exception e)
            {
               string msg = e.Message;
            }
        }

        //string GameStats(Game game)
        public string GameStats(Game game)
        {
            try
            {
                game.sDate = DateTime.Now;
                game.ticket_pDate = DateTime.Now;
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(Game));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, game);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                string response = webClient.UploadString(URL + "GameStats", "POST", data);
                
                return response;
            }
            catch
            {
                return "failed: catched";
            }
        }

        //CreateGameTicket(Game game)
        public string CreateGameTicket(Game game)
        {
            try
            {
                game.sDate = DateTime.Now;
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(Game));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, game);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                string response = webClient.UploadString(URL + "CreateGameTicket", "POST", data);
                int GameID = 0;
                return response;
            }
            catch
            {
                return "failed: catched";
            }
        }

        //find current playing games for specific league
        public List<Team> GetAllGamesByCat(string Category)
        {
            string json = null;
            List<Team> data = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(URL + "GetAllGamesByCat/" + Category);
                data = JsonConvert.DeserializeObject<List<Team>>(json);
                return data;
            }
            catch
            {
                return null;
            }
        }

        //find playing games
        public Team GetGameByID(string id)
        {
            string json = null;
            Team data = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(URL + "GetGameByID/" + id);
                data = JsonConvert.DeserializeObject<Team>(json);
                return data;
            }
            catch
            {
                return null;
            }
        }

        //Edit Game Stats
        public string EditGameStats(Game game)
        {
            string response = null;
            string data = null;
            //   string res = "";
            game.sDate = DateTime.Now;
            game.ticket_pDate = DateTime.Now;
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(Game));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, game);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(URL + "EditGameStats", "PUT", data);
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


        //Get League Fixture
        //GetAllGamesByLeagueID
        public List<MyTeamModel> LeagueGames(string ID)
        {
            string json = null;
            List<MyTeamModel> data = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(URL + "GetAllGamesByLeagueID/" + ID);
                data = JsonConvert.DeserializeObject<List<MyTeamModel>>(json);
                return data;
            }
            catch
            {
                return null;
            }
        }

        //GetAllGameStatByLeagueID
      //  GetAllGameStatByLeagueID
        //Get game stats for all league games played
        public List<Game> LeagueStats(string ID)
        {
            string json = null;
            List<Game> data = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(URL + "GetAllGameStatByLeagueID/" + ID);
                data = JsonConvert.DeserializeObject<List<Game>>(json);
                return data;
            }
            catch
            {
                return null;
            }
        }

        //Deletion=====================================>

        //Delete Game Stats
        public string DeleteGameStatsGameByID(string id)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(URL + "DeleteGameStatsGameByID/" + id, "DELETE", "");
                return json;
            }
            catch
            {
                string res = "Failed";
                return res;
            }
        }

        //Delete Game by ID
        public string DeleteGameByID(string id)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(URL + "DeleteGameByID/" + id, "DELETE", "");
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