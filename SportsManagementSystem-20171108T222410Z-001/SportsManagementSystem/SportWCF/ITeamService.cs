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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITeamService" in both code and config file together.
    [ServiceContract]
    public interface ITeamService
    {
        //Insert
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AddTeam", ResponseFormat =
          WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int AddTeam(Team _team);
        //Edit
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "EditTeam", ResponseFormat =
          WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string EditTeam(Team _team);

        //Get All teams per sport category
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAllTeamByCategory/{category}", ResponseFormat =
              WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<MyTeamModel> getAllTeamByCategory(string category);

        //Get All teams for sport admin
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAllTeamByUserID/{ID}", ResponseFormat =
              WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<MyTeamModel> getAllTeamByUserID(string ID);

        ////Get All teams per sport category
        //[OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "getAllGames", ResponseFormat =
        //      WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        //List<Team> getAllGames();

        //Get Two playing game
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getTeamsByGameID/{gID}", ResponseFormat =
              WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<TeamModel> getTeamsByGameID(string gID);

        //Get Teams by User ID
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getTeamsByUserID/{ID}", ResponseFormat =
              WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<TeamModel> getTeamsByUserID(string ID);


        //Get Team Details by team ID
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getTeamsDetails/{ID}", ResponseFormat =
              WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        TeamModel getTeamsDetails(string ID);

        //Get League Teams by league ID
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getLeagueTeams/{leagueID}", ResponseFormat =
              WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<rep_Teams> getLeagueTeams(string leagueID);

        //Deletions=============================================>>>.
        //Delete Log by league ID
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "DeleteSportByID/{ID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string DeleteSportByID(string ID);
    }
}
