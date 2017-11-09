using SportClient.Definition;
using SportClient.ServiceImplementation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsManagementSystem
{
    public partial class AddLeague : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkAddLeague_Click(object sender, EventArgs e)
        {

            int LoggedID = Convert.ToInt32(Session["ID"]);
            League toCreate = new League();
            LeagueClient lc = new LeagueClient();
            toCreate.Name = txtName.Value;
            toCreate.Price = Convert.ToDecimal(txtPrice.Value);
            toCreate.Desc = txtDesc.Value;
            toCreate.sDate = DateTime.ParseExact(txtsDate.Text, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            toCreate.eDate = DateTime.ParseExact(txteDate.Text, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            toCreate.foreignID = LoggedID;
            toCreate.NumTeams = Convert.ToInt32(txtNumTeams.Value);
            toCreate.Category = txtType.Value;
            int leagueID = lc.CreateLeague(toCreate);
            if(leagueID == -1)
            {
                //Cant Upload Team
            }else
            {
                //Upload league image
                makeLeagueDirectory(Convert.ToString(leagueID));
                //Upload Team Image
                ImageFile img = new ImageFile();
                img = UploadFile(flImage, Convert.ToString(leagueID), "League_Images", "Leagues");
                FileClient fc = new FileClient();
                string res1 = fc.saveLeagueImage(img);
                if(!res1.ToLower().Contains("success"))
                {
                    //Cant Upload League Image
                }
                Response.Write("Proceed To Adding Teams");
            }


            //string htmtl = "";
            //htmtl += "<a href='TeamAdding.aspx?teamId ={{Soc.ID}}' class='btn btn-success' name='table_records'>Add Team</a>";
            //tdRedirectSoccer.InnerHtml = htmtl;

            //htmtl = "";
            //htmtl += "<a href='TeamAdding.aspx?teamId ={{Rug.ID}}' class='btn btn-success' name='table_records'>Add Team</a>";
            //tdRedirectRugby.InnerHtml = htmtl;

            //htmtl = "";
            //htmtl += "<a href='TeamAdding.aspx?teamId ={{Crick.ID}}' class='btn btn-success' name='table_records'>Add Team</a>";
            //tdRedirectCricket.InnerHtml = htmtl;
            //Adding Teams
            //toinsert.League_Id = leagues.League_Id;
            //toinsert.Sport_Id = teams.Sport_Id;
            //toinsert.LeagueName = leagues.Name;
            //toinsert.TeamName = teams.Name;
            //for (int i=0; i<toCreate.NumTeams; i++)
            //{
            //    if(toCreate.Category.ToLower().Equals("soccer"))
            //    {
            //        if (soc.Checked == true)
            //        {
            //            Team leagueTeam = new Team();
            //            leagueTeam.Name = rug_TeamName.Text;
            //            leagueTeam.LeagueName = txtName.Value;
            //            string res = lc.CreateLeagueTeams(leagueTeam);
            //        }
            //    }else if(toCreate.Category.ToLower().Equals("cricket"))
            //    {
            //        if (crick.Checked == true)
            //        {
            //            Team leagueTeam = new Team();
            //            leagueTeam.Name = rug_TeamName.Text;
            //            leagueTeam.LeagueName = txtName.Value;
            //            string res = lc.CreateLeagueTeams(leagueTeam);
            //        }
            //    }
            //    else if (toCreate.Category.ToLower().Equals("rugby"))
            //    {
            //        if (rug.Checked == true)
            //        {
            //            Team leagueTeam = new Team();
            //            leagueTeam.Name = rug_TeamName.Text;
            //            leagueTeam.LeagueName = txtName.Value;
            //            string res = lc.CreateLeagueTeams(leagueTeam);
            //        }
            //    }
            //}
        }


        //League Foler
        protected void makeLeagueDirectory(string teamID)
        {
            string directoryPath = Server.MapPath(string.Format("~/{0}/", "Leagues/" + teamID));

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                Directory.CreateDirectory(Path.Combine(directoryPath, "League_Images"));
                Directory.CreateDirectory(Path.Combine(directoryPath, "Game_Images"));
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

        protected void btnSub_Click(object sender, EventArgs e)
        {
            String LeagueName = "";
            int LoggedID = Convert.ToInt32(Session["ID"]);
            League toCreate = new League();
            LeagueClient lc = new LeagueClient();
            toCreate.Name = txtName.Value;
            toCreate.Price = Convert.ToDecimal(txtPrice.Value);
            toCreate.Desc = txtDesc.Value;
            toCreate.sDate = DateTime.ParseExact(txtsDate.Text, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            toCreate.eDate = DateTime.ParseExact(txteDate.Text, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            toCreate.foreignID = LoggedID;
            toCreate.NumTeams = Convert.ToInt32(txtNumTeams.Value);
            toCreate.Category = txtType.Value;
            int leagueID = lc.CreateLeague(toCreate);
            if (leagueID == -1)
            {
                //Cant Upload Team
            }
            else
            {
                LeagueName = txtName.Value;
                Session.Add("LeagueName", LeagueName);
                //Upload league image
                makeLeagueDirectory(Convert.ToString(leagueID));
                //Upload Team Image
                ImageFile img = new ImageFile();
                img = UploadFile(flImage, Convert.ToString(leagueID), "League_Images", "Leagues");
                FileClient fc = new FileClient();
                string res1 = fc.saveLeagueImage(img);
                if (!res1.ToLower().Contains("success"))
                {
                    //Cant Upload League Image
                }else
                {
                    Response.Redirect("LeagueTeams.aspx?leagueID=" + leagueID);
                }
                //Pop-Up
            }


            //string htmtl = "";
            //htmtl += "<a href='TeamAdding.aspx?teamId ={{Soc.ID}}' class='btn btn-success' name='table_records'>Add Team</a>";
            //tdRedirectSoccer.InnerHtml = htmtl;

            //htmtl = "";
            //htmtl += "<a href='TeamAdding.aspx?teamId ={{Rug.ID}}' class='btn btn-success' name='table_records'>Add Team</a>";
            //tdRedirectRugby.InnerHtml = htmtl;

            //htmtl = "";
            //htmtl += "<a href='TeamAdding.aspx?teamId ={{Crick.ID}}' class='btn btn-success' name='table_records'>Add Team</a>";
            //tdRedirectCricket.InnerHtml = htmtl;
            //Adding Teams
            //toinsert.League_Id = leagues.League_Id;
            //toinsert.Sport_Id = teams.Sport_Id;
            //toinsert.LeagueName = leagues.Name;
            //toinsert.TeamName = teams.Name;
            //for (int i=0; i<toCreate.NumTeams; i++)
            //{
            //    if(toCreate.Category.ToLower().Equals("soccer"))
            //    {
            //        if (soc.Checked == true)
            //        {
            //            Team leagueTeam = new Team();
            //            leagueTeam.Name = rug_TeamName.Text;
            //            leagueTeam.LeagueName = txtName.Value;
            //            string res = lc.CreateLeagueTeams(leagueTeam);
            //        }
            //    }else if(toCreate.Category.ToLower().Equals("cricket"))
            //    {
            //        if (crick.Checked == true)
            //        {
            //            Team leagueTeam = new Team();
            //            leagueTeam.Name = rug_TeamName.Text;
            //            leagueTeam.LeagueName = txtName.Value;
            //            string res = lc.CreateLeagueTeams(leagueTeam);
            //        }
            //    }
            //    else if (toCreate.Category.ToLower().Equals("rugby"))
            //    {
            //        if (rug.Checked == true)
            //        {
            //            Team leagueTeam = new Team();
            //            leagueTeam.Name = rug_TeamName.Text;
            //            leagueTeam.LeagueName = txtName.Value;
            //            string res = lc.CreateLeagueTeams(leagueTeam);
            //        }
            //    }
            //}
        }
    }
}