using SportClient.Definition;
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
    public partial class UpdateTeam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string sportID = Request.QueryString["SportID"];
                MyTeamModel toupdate = new MyTeamModel();
                TeamServiceClient tsc = new TeamServiceClient();
                toupdate = tsc.getTeamsDetails(sportID);
                txtName.Value = toupdate.TeamName;
                txtDesc.Value = toupdate.Desc;
                txtNumPlayer.Text = Convert.ToString(toupdate.NumPlayers);
                txtCategory.Value = toupdate.Type;

            }
            //getTeamsDetails
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            string sportID = Request.QueryString["SportID"];
            TeamServiceClient teamClient = new TeamServiceClient();
            Team _team = new Team();
            //  _team.Type = txtType.Text;
            _team.ID = Convert.ToInt32(sportID);
            _team.Name = txtName.Value;
            _team.Desc = txtDesc.Value;
            _team.NumPlayers = Convert.ToInt32(txtNumPlayer.Text);
            _team.Category = txtCategory.Value;
            string res = teamClient.EditTeam(_team);
            if(res.ToLower().Contains("success"))
            {
                //Upload Team Image
                ImageFile img = new ImageFile();
                img = UploadFile(flImage, Convert.ToString(sportID), "Team_Images", "Teams"); //Upload Event Main's Image to client directory
                FileClient fc = new FileClient();
                if(img != null)
                {
                    string res1 = fc.saveTeamImage(img); //Upload Event Main's Image to Database
                    string number = res1;
                }
                //pop-up done!
                 Response.Redirect("ViewTeam.aspx?SportID=" + sportID);
            }
        }

        //HELPER METHOD=================================================
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