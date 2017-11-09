using SportClient.Definition.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SportWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPlayerService" in both code and config file together.
    [ServiceContract]
    public interface IPlayerService
    {
        //Get All teams per sport category
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAllTeamPlayers/{teamID}", ResponseFormat =
              WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Player> getAllTeamPlayers(string teamID);

        //Deletions-------------------------------------------------------------->>>>
        //Delete TTeam Players
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Dl_PlayersBySportID/{ID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string Dl_PlayersBySportID(string ID);
    }
}
