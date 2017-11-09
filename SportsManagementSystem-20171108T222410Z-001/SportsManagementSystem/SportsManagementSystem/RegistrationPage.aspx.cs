using SportClient.Definition;
using SportClient.Definition.Users;
using SportClient.ServiceImplementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsManagementSystem
{
    public partial class RegistrationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void btnRegUser_Click(object sender, EventArgs e)
        //{
        //    RegServiceClient rsc = new RegServiceClient();
        //    string level = role.Value;
        //    BASE_USER user = new BASE_USER();
        //    user.Name = name.Value;
        //    user.Surname = surname.Value;
        //    user.Email = email.Value;
        //    user.Level = level;
        //    user.Pass = password.Value;

        //    string strResponse = rsc.RegisterUser(user);
        //    if (strResponse.ToLower().Contains("succ"))
        //    {
        //        Response.Redirect("LoginPage.aspx");
        //    }
        //    else
        //    {
        //        Response.Redirect("RegistrationPage.aspx");
        //    }
        //}

        protected void lnkReg_Click(object sender, EventArgs e)
        {
            RegServiceClient rsc = new RegServiceClient();
            string level = role.Value;
            BASE_USER user = new BASE_USER();
            user.Name = name.Value;
            user.Surname = surname.Value;
            user.Email = email.Value;
            user.Level = level;
            user.Pass = password.Value;

            int strResponse = rsc.RegisterUser(user);
            if (strResponse != 0) //Login Success
            {
                //Upload Image
                makeDirectory(Convert.ToString(strResponse));

                //Upload Team Image
                ImageFile img = new ImageFile();
                img = UploadFile(flUserImge, Convert.ToString(strResponse), "User_Image", "Users"); //Upload Event Main's Image to client directory
                FileClient fc = new FileClient();
                string res1 = fc.saveUserImage(img); //Upload Event Main's Image to Database
                string number = res1;


                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                Response.Redirect("RegistrationPage.aspx");
            }
        }

        //HELPER FUNCTIONS
        protected void makeDirectory(string ID)
        {
            string directoryPath = Server.MapPath(string.Format("~/{0}/", "Users/" + ID));

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                Directory.CreateDirectory(Path.Combine(directoryPath, "User_Image"));

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Directory already exists.');", true);
            }
        }

        private ImageFile UploadFile(FileUpload fileToUpload, string ID, string subfolder, string pathSubFolder)
        {
            int teamID = Convert.ToInt32(ID);
            if (fileToUpload.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(fileToUpload.FileName);
                    string serverLocation = "~/" + pathSubFolder + "/" + teamID.ToString() + "/" + subfolder + "/" + filename;
                    string SaveLoc = Server.MapPath(serverLocation);
                    int fileSize = fileToUpload.PostedFile.ContentLength;
                    string fileExtention = Path.GetExtension(fileToUpload.FileName);

                    if (fileExtention.ToLower() == ".jpg" || fileExtention.ToLower() == ".png" || fileExtention.ToLower() == ".jpeg" && fileSize <= 15728640)
                    {
                        fileToUpload.SaveAs(SaveLoc);
                        ImageFile file = new ImageFile()
                        {
                            foreignID = Convert.ToString(teamID),
                            Name = filename,
                            path = "SportsManagementSystem/SportsManagementSystem/" + pathSubFolder + "/" + teamID.ToString() + "/" + subfolder + "/" + filename,
                        };

                        return file;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
                return null;
        }
    }
}