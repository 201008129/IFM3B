using SportWCF.CRUD_ANGULAR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SportWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmpService" in both code and config file together.
    [ServiceContract]
    public interface IEmpService
    {    //Getters
        //Get Image Path by ID
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getEmployeeByID/{strID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        employee getEmployeeByID(string strID);
        //Get Image Path by ID
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAllEmployee", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<employee> getAllEmployee();

        //saveGameImage
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "PostEmployee", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string PostEmployee(employee employee);

        //saveGameImage
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "PutEmployee", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string PutEmployee(employee employee);
        //Deletion
        //Delete game image
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteID/{ID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string deleteID(string ID);
    }
}
