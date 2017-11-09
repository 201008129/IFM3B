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
    public partial class AddTeam : System.Web.UI.Page
    {
        string SUBFOLDER = "Team_Images";
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            TeamServiceClient teamClient = new TeamServiceClient();
            Team _team = new Team();
            _team.foreignID = 2;
            _team.Type = txtType.Text;
            _team.Name = txtName.Text;
            _team.Desc = txtDesc.Text;
            _team.NumPlayers = Convert.ToInt32(txtNumPlayers.Text);
            int TeamID = teamClient.AddTeam(_team);
            makeDirectory(Convert.ToString(TeamID));

            //Upload Team Image
            ImageFile img = new ImageFile();
            img = UploadFile(flTeamImage, Convert.ToString(TeamID), SUBFOLDER, "Teams"); //Upload Event Main's Image to client directory
            FileClient fc = new FileClient();
            string res1 = fc.saveTeamImage(img); //Upload Event Main's Image to Database
            string number = res1;
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            TeamServiceClient teamClient = new TeamServiceClient();
            Team _team = new Team();
            //  _team.Type = txtType.Text;
            _team.ID = 1;
            _team.Name = txtName.Text;
            _team.Desc = txtDesc.Text;
            _team.NumPlayers = Convert.ToInt32(txtNumPlayers.Text);
            string res = teamClient.EditTeam(_team);
        }

        //HELPER FUNCTIONS
        protected void makeDirectory(string teamID)
        {
            string directoryPath = Server.MapPath(string.Format("~/{0}/", "Teams/" + teamID));

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                Directory.CreateDirectory(Path.Combine(directoryPath, "Team_Images"));

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Directory already exists.');", true);
            }
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
                    string serverLocation = "~/" +pathSubFolder +"/" + teamID.ToString() + "/" + subfolder + "/" + filename;
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
                            path = "SportsManagementSystem/SportsManagementSystem/" +pathSubFolder +"/" + teamID.ToString() + "/" + subfolder + "/" + filename,
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

        protected void btnLeague_Click(object sender, EventArgs e)
        {
            League toCreate = new League();
            LeagueClient lc = new LeagueClient();
            toCreate.Name = txtLeagueName.Text;
            toCreate.Price = Convert.ToDecimal(txtPrice.Text);
            toCreate.Desc = txtLeagueDesc.Text;
            //DateTime.ParseExact(txtStart.Text, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            toCreate.sDate = DateTime.ParseExact(txtStartDate.Text, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            toCreate.eDate = DateTime.ParseExact(txtEndDate.Text, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            toCreate.foreignID = 3;
            int leagueID = lc.CreateLeague(toCreate);
            //Upload league image
            makeLeagueDirectory(Convert.ToString(leagueID));
            //Upload Team Image
            ImageFile img = new ImageFile();
            img = UploadFile(flLeague, Convert.ToString(leagueID),"League_Images","Leagues"); 
            FileClient fc = new FileClient();
            string res1 = fc.saveLeagueImage(img); 
            string number = res1;
        }

        protected void btnRegTeam_Click(object sender, EventArgs e)
        {
            //CreateLeagueTeams(Team _teams)
            Team team = new Team();
            team.Name = txtT_Name.Text;
            team.LeagueName = txtL_Name.Text;
            LeagueClient lc = new LeagueClient();
            string res = lc.CreateLeagueTeams(team);
        }

        protected void btnMatch_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            game.TeamOne = txtTeamOne.Text;
            game.TeamTwo = txtTeamTwo.Text;
            game.Venue = txtVenue.Text;
            game.Type = txtGameType.Text;
            game.sDate = DateTime.ParseExact(txtGameDate.Text, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            game.LeagueID = 14;
            makeLeagueDirectory(Convert.ToString(game.LeagueID));
            MatchServiceClient msc = new MatchServiceClient();
            int GameID = msc.AddMatch(game);
            //Upload Game Image
            ImageFile img = new ImageFile();
            img = UploadFile(flGameImage, Convert.ToString(game.LeagueID), "Game_Images", "Leagues");
            img.foreignID = Convert.ToString(GameID);
            FileClient fc = new FileClient();
            string res1 = fc.saveGameImage(img); 
            string number = res1;
        }

        protected void btnStats_Click(object sender, EventArgs e)
        {
            Game gameStats = new Game();
            gameStats.ID = 1;
            gameStats.BestPlayer = txtBPlayer.Text;
            gameStats.TeamOnePos = Convert.ToInt32(txtT1_Pos.Text);
            gameStats.TeamTwoPos = Convert.ToInt32(txtT2_Pos.Text);
            gameStats.TeamOneFouls = Convert.ToInt32(txtT1_Foul.Text);
            gameStats.TeamTwoFouls = Convert.ToInt32(txtT2_Foul.Text);
            MatchServiceClient msc = new MatchServiceClient();
            string res = msc.GameStats(gameStats);
            int blah = 0;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Game gameTicket = new Game();
            MatchServiceClient msc = new MatchServiceClient();
            gameTicket.ID = 1;
            gameTicket.ticket_Price = Convert.ToDecimal(txtTicketPrice.Text);
            gameTicket.ticket_pDate = DateTime.ParseExact(txtTicketDate.Text, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            gameTicket.NumTicket = Convert.ToInt32(txtQuantity.Text);
            string res = msc.CreateGameTicket(gameTicket);
            int blah = 0;
        }

        protected void btnAddLog_Click(object sender, EventArgs e)
        {
            Log lg = new Log();
            LogServiceClient lsc = new LogServiceClient();
            lg.TeamName = txtL_TeamName.Text;
            lg.Position = Convert.ToInt32(txtL_Pos.Text);
            lg.MatchPlayed = Convert.ToInt32(txtL_MPlayed.Text);
            lg.Wins = Convert.ToInt32(txtL_Wins.Text);
            lg.Loose = Convert.ToInt32(txtL_Lose.Text);
            lg.Draws = Convert.ToInt32(txtL_Draws.Text);
            lg.Points = Convert.ToInt32(txtL_Points.Text);
            lg.League_ID = 1;
            string res = lsc.CreateLog(lg);


        }

        protected void btnUpdateLog_Click(object sender, EventArgs e)
        {
            Log lg = new Log();
            LogServiceClient lsc = new LogServiceClient();
            lg.TeamName = txtLU_TeamName.Text;
            lg.Position = Convert.ToInt32(txtLU_Pos.Text);
            lg.MatchPlayed = Convert.ToInt32(txtLU_MPlayed.Text);
            lg.Wins = Convert.ToInt32(txtLU_Wins.Text);
            lg.Loose = Convert.ToInt32(txtLU_Lose.Text);
            lg.Draws = Convert.ToInt32(txtLU_Draws.Text);
            lg.Points = Convert.ToInt32(txtLU_Points.Text);
            lg.League_ID = 1;
            lg.ID = 1;
            string res = lsc.UpdateLog(lg);
        }

        //CreateLog(Log log)
    }
}