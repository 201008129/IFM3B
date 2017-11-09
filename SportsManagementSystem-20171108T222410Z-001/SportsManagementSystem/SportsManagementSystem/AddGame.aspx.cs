using SportClient.Definition;
using SportClient.Definition.Reporting;
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
    public partial class AddGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string LeagueID = Request.QueryString["LeagueID"];
            //Populate dropdownlist
            TeamServiceClient teamClient = new TeamServiceClient();
            List<rep_Teams> teams = teamClient.getLeagueTeams(LeagueID);
            //COnvert team list to string list of team name
            List<String> TeamNames = new List<string>();
            foreach(rep_Teams tm in teams)
            {
                dl_Teams.Items.Add(tm.Name);
                d2_Teams.Items.Add(tm.Name);
            }
            //dl_Teams.DataSource = teams;
            //dl_Teams.DataTextField = "Name";
            //dl_Teams.DataValueField = "Name";
            //dl_Teams.DataBind();

            //d2_Teams.DataSource = teams;
            //d2_Teams.DataTextField = "Name";
            //d2_Teams.DataValueField = "Name";
            //d2_Teams.DataBind();

        }

        protected void lnkSubmit_Click(object sender, EventArgs e)
        {
            string LeagueID = Request.QueryString["LeagueID"];
            //Populate dropdownlist
            //TeamServiceClient teamClient = new TeamServiceClient();
            //List<rep_Teams> teams = teamClient.getLeagueTeams(LeagueID);
            //dl_Teams.DataSource = teams;
            //dl_Teams.DataTextField = "Name";
            //dl_Teams.DataValueField = "S_ID";
            //dl_Teams.DataBind();
            
            if (dl_Teams.SelectedValue.Equals(d2_Teams.SelectedValue))
            {
                Response.Redirect("AddGame.aspx?LeagueID=" + LeagueID);
            }

            Game game = new Game();
            game.TeamOne = dl_Teams.Text;
            game.TeamTwo = d2_Teams.Text;
            game.Venue = txtVenue.Value;
            game.sDate = DateTime.ParseExact(txtDate.Text, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            game.LeagueID = Convert.ToInt32(LeagueID);
            makeLeagueDirectory(Convert.ToString(game.LeagueID));
            MatchServiceClient msc = new MatchServiceClient();
            int GameID = msc.AddMatch(game);
            //Upload Game Image
            ImageFile img = new ImageFile();
            img = UploadFile(flImage, Convert.ToString(game.LeagueID), "Game_Images", "Leagues");
            img.foreignID = Convert.ToString(GameID);
            FileClient fc = new FileClient();
            string res1 = fc.saveGameImage(img);
            string number = res1;
            Response.Redirect("ViewGame.aspx?G_ID=" + GameID);
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

        protected void btnSubm_Click(object sender, EventArgs e)
        {
            string LeagueID = Request.QueryString["LeagueID"];
            if (dl_Teams.SelectedValue.Equals(d2_Teams.SelectedValue))
            {
                Response.Redirect("AddGame.aspx?LeagueID=" + LeagueID);
            }

            Game game = new Game();
            game.TeamOne = dl_Teams.SelectedValue;
            game.TeamTwo = d2_Teams.SelectedValue;
            game.Venue = txtVenue.Value;
            game.sDate = DateTime.ParseExact(txtDate.Text, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            game.LeagueID = Convert.ToInt32(LeagueID);
            makeLeagueDirectory(Convert.ToString(game.LeagueID));
            MatchServiceClient msc = new MatchServiceClient();
            int GameID = msc.AddMatch(game);
            //Upload Game Image
            ImageFile img = new ImageFile();
            img = UploadFile(flImage, Convert.ToString(game.LeagueID), "Game_Images", "Leagues");
            img.foreignID = Convert.ToString(GameID);
            FileClient fc = new FileClient();
            string res1 = fc.saveGameImage(img);
            string number = res1;
            Response.Redirect("ViewGame.aspx?G_ID=" + GameID);

        }
    }
}