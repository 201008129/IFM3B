using SportClient.Definition;
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
    public class FileClient
    {
        string URL = "http://localhost:57567/FileUpload.svc/";
        //saveUserImage(ImageFile image)
        public string saveUserImage(ImageFile image)
        {
            string response = null;
            string data = null;
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(ImageFile));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, image);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(URL + "saveUserImage", "POST", data);

                return response;
            }
            catch
            {
                return null;
            }
        }
        //saveTeamImage(ImageFile image)
        public string saveTeamImage(ImageFile image)
        {
            string response = null;
            string data = null;
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(ImageFile));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, image);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(URL + "saveTeamImage", "POST", data);

                return response;
            }
            catch
            {
                return null;
            }
        }
        //saveLeagueImage
        public string saveLeagueImage(ImageFile image)
        {
            string response = null;
            string data = null;
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(ImageFile));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, image);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(URL + "saveLeagueImage", "POST", data);

                return response;
            }
            catch
            {
                return null;
            }
        }

        //saveGameImage(ImageFile image)
        public string saveGameImage(ImageFile image)
        {
            string response = null;
            string data = null;
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(ImageFile));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, image);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(URL + "saveGameImage", "POST", data);
                return response;
            }
            catch
            {
                return null;
            }
        }

        //=======Getters======================================
        //getUserImagePathById(string strID)
        public string getUserImagePathById(string strID)
        {
            {
                string path = "";
                try
                {
                    var webclient = new WebClient();
                    string url = string.Format(URL + "getUserImagePathById/" + strID);
                    var json = webclient.DownloadString(url);
                    var js = new JavaScriptSerializer();
                    path = js.Deserialize<string>(json);
                    return path;
                }
                catch
                {
                    return null;
                }
            }
        }

        //Get game image path
        public string getGameImagePathById(string strID)
        {
            {
                string path = "";
                try
                {
                    var webclient = new WebClient();
                    string url = string.Format(URL + "getGameImagePathById/" + strID);
                    var json = webclient.DownloadString(url);
                    var js = new JavaScriptSerializer();
                    path = js.Deserialize<string>(json);
                    return path;
                }
                catch
                {
                    return null;
                }
            }
        }

        //Get team Image
        public string getTeamImagePathById(string strID)
        {
            {
                string path = "";
                try
                {
                    var webclient = new WebClient();
                    string url = string.Format(URL + "getImagePathById/" + strID);
                    var json = webclient.DownloadString(url);
                    var js = new JavaScriptSerializer();
                    path = js.Deserialize<string>(json);
                    return path;
                }
                catch
                {
                    return null;
                }
            }
        }

        //Deletions=========================================
        //Delete User Image
        public string deleteUserImageByUserID(string id)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(URL + "deleteUserImageByID/" + id, "DELETE", "");
                return json;
            }
            catch
            {
                string res = "Failed";
                return res;
            }
        }
        //Delete Team Image by sport ID
        public string deleteTeamImageBySportID(string id)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(URL + "deleteTeamImageByID/" + id, "DELETE", "");
                if (json.ToLower().Contains("success"))
                {
                    return "succcess";
                }
                else
                {
                    return "fail";
                }
            }
            catch
            {
                string res = "Failed";
                return res;
            }
        }

        //Delete League Image by ID
        public string deleteLeagueImageByID(string id)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(URL + "deleteLeagueImageByID/" + id, "DELETE", "");
                return json;
            }
            catch
            {
                string res = "Failed";
                return res;
            }
        }

        //Delete Game Image by Game ID
        public string deleteGameImageByID(string id)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(URL + "deleteImageByID/" + id, "DELETE", "");
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