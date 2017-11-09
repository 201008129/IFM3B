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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILogService" in both code and config file together.
    [ServiceContract]
    public interface ILogService
    {
        //Insert
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CreateLog", ResponseFormat =
          WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string CreateLog(Log log);

        //Edit Log Entries
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "UpdateLog", ResponseFormat =
          WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string UpdateLog(Log log);

        //Deletions
        //Delete Log by league ID
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "DeletLogbyLeagueID/{ID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string DeletLogbyLeagueID(string ID);

        //Get League By Category
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetLogByLeagueID/{ID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Log> GetLogByLeagueID(string ID);

        //Get League By Category || Updated Version
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "gt_LogByLeagueID/{LeagueID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Log> gt_LogByLeagueID(string LeagueID);

    }
}
