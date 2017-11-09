using SportClient.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SportWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILeagueService" in both code and config file together.
    [ServiceContract]
    public interface ILeagueService
    {        
        //Insert
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CreateLeague", ResponseFormat =
          WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int CreateLeague(League _league);

        //CreateTeamLeague
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CreateLeagueTeams", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool CreateLeagueTeams(Team _teams);

        //Edit
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "UpdateLeague", ResponseFormat =
          WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string UpdateLeague(League _league);

        //Get All Leagues
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetAllLeagues", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<League> GetAllLeagues();

        //Get League By Category
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetleagueByCat/{Cat}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<League> GetleagueByCat(string Cat);

        //Get League By LeagueID
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetleagueByID/{ID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        League GetleagueByID(string ID);

        //Get League By LeagueID
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetleagueByUserID/{ID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<League> GetleagueByUserID(string ID);

        ////Get League By User ID
        //[OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "GetleagueByUseID/{UserID}", ResponseFormat =
        //    WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        //List<League> GetleagueByUseID(string UserID);

        //Delete 
        //Delete Sport league BT 
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "DeletSportLeagueByID/{leagueID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string DeletSportLeagueByID(string leagueID);

        //Delete Sport in BT table
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "DeletSportInBT/{sportID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string DeletSportInBT(string sportID);

        //Delete Sport league BT 
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "DL_LeagueBYID/{ID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string DL_LeagueBYID(string ID);
    }
}
