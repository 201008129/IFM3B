using SportClient.Definition;
using SportClient.Definition.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SportWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGameService" in both code and config file together.
    [ServiceContract]
    public interface IGameService
    {
        //AddBestPlayer
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AddBestPlayer", ResponseFormat =
          WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string AddBestPlayer(bestplayer BPlayer);
        //Insert
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AddMatch", ResponseFormat =
          WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int AddMatch(Game game);

        //Insert Game Stats
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GameStats", ResponseFormat =
          WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string GameStats(Game game);


        //Insert Game TIckets
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CreateGameTicket", ResponseFormat =
          WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string CreateGameTicket(Game game);


        //Updates======================================>>
        //Edit
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "EditGameStats", ResponseFormat =
          WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string EditGameStats(Game game);

        //====================---------Getters--------=====================>>>

        //List<decimal> calcAverage(string TeamOne, string TeamTwo)
        //[OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "calcAverage/{TeamOne},{TeamTwo}", ResponseFormat =
        //    WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        //List<decimal> calcAverage(string TeamOne, string TeamTwo);

        //Get all game stats for league
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetAllGameStatByLeagueID/{L_ID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<GameModel> GetAllGameStatByLeagueID(string L_ID);

        //getGameImagePathById(string strID)
        //Get Game by Category
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetAllGamesByCat/{Category}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<TeamModel> GetAllGamesByCat(string Category);

        //Get All games by admin
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetAllGamesByUserID/{ID}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<TeamModel> GetAllGamesByUserID(string ID);



        //Get Games by league ID || League Fixture
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetAllGamesByLeagueID/{ID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<TeamModel> GetAllGamesByLeagueID(string ID);

        //Get Game by Category
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetGameByID/{id}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        TeamModel GetGameByID(string id);


        //Deletions
        //Delete Game by ID
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "DeleteGameByID/{ID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string DeleteGameByID(string ID);

        //Deletions
        //Delete Game by ID
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "DeleteGameByLeague/{ID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string DeleteGameByLeague(string ID);

        //Deletions
        //Delete Game by ID
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "DeleteGameStatsGameByID/{ID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string DeleteGameStatsGameByID(string ID);

    }
}
