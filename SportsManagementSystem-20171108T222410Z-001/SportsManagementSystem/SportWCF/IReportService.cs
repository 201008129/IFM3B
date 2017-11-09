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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReportService" in both code and config file together.
    [ServiceContract]
    public interface IReportService
    {
        /// <summary>
        /// Get game stats
        /// </summary>
        /// <param name="Game_ID"></param>
        /// <param name="type"> type of game stat request</param>
        /// <returns> list of number of yellow cards, position 0 stores team 1 and position 1 stores team 2'a card</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "gt_GameStats/{Game_ID},{type}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<int> gt_GameStats(string Game_ID, string type);


        //Compare all leagues: Useful for general users to make decisions about which league to follow
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "gt_LeaguesStats", ResponseFormat =
          WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<rep_league> gt_LeaguesStats();

        //Compare all leagues: Useful for administrators
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "gt_LeaguesStatsForAdmin/{ID}", ResponseFormat =
          WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<rep_league> gt_LeaguesStatsForAdmin(string  ID);

        //Get league's player stats, both for overall best player and top goal scorer
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "gt_LeagueBestPlayer/{ID},{type}", ResponseFormat =
         WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<bestplayer> gt_LeagueBestPlayer(string ID, string type);

        //Get teams in the league with highest average
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "gt_LeagueBestTeam/{leagueID}", ResponseFormat =
         WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<rep_Teams> gt_LeagueBestTeam(string leagueID);

        //Get player's ranking in a team
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "gt_PlayerRanking/{sportID}", ResponseFormat =
         WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<rep_Teams> gt_PlayerRanking(string sportID);

        //Get Team performance in a league
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "gt_TeamAverage/{sportID}", ResponseFormat =
         WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<rep_Teams> gt_TeamAverage(string sportID);
    }
}
