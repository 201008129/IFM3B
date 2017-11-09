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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFileUpload" in both code and config file together.
    [ServiceContract]
    public interface IFileUpload
    {
        //Insertions
        //Insert Team Image
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "saveTeamImage", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string saveTeamImage(ImageFile image);

        //Insert user image
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "saveUserImage", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string saveUserImage(ImageFile image);



        //saveLeagueImage
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "saveLeagueImage", ResponseFormat =
    WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string saveLeagueImage(ImageFile image);

        //saveGameImage
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "saveGameImage", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string saveGameImage(ImageFile image);

        //Getters
        //Get Image Path by ID
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getImagePathById/{strID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string getImagePathById(string strID);

        //Get Image Team Image by Team Name
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getTeamImageByTeamName/{strID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string getTeamImageByTeamName(string strID);

        //Get User Image Path by ID
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getUserImagePathById/{strID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string getUserImagePathById(string strID);


        //Get Game Image Path by ID
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getGameImagePathById/{strID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string getGameImagePathById(string strID);


        //Get Game Image Path by ID
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getLeagueImagePath/{strID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string getLeagueImagePath(string strID);

        //Deletion
        //Delete game image
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteImageByID/{ID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string deleteImageByID(string ID);

        //Delete Team image
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteTeamImageByID/{ID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string deleteTeamImageByID(string ID);

        //Delete Team image
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteUserImageByID/{ID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string deleteUserImageByID(string ID);


        //Delete Team image
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteLeagueImageByID/{ID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string deleteLeagueImageByID(string ID);
    }
}
