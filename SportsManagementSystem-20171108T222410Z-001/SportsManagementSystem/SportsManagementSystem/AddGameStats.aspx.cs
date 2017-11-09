using SportClient.Definition;
using SportClient.Definition.Reporting;
using SportClient.ServiceImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsManagementSystem
{
    public partial class AddGameStats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string gameID = Request.QueryString["G_ID"];
                TeamServiceClient tsc = new TeamServiceClient();
                List<MyTeamModel> teams = new List<MyTeamModel>();
                teams = tsc.getTeamsByGameID(gameID);
                if (teams.Count() != 0 || teams == null)
                {
                    MyTeamModel team1 = teams.First();
                    MyTeamModel team2 = teams.Last();
                    string html = "";
                    html += "<img src=" + team1.ImagePath + " class='avatar' alt='Avatar'/>";
                    tmOneImage.InnerHtml = html;
                    html = "";
                    T1.InnerHtml = team1.TeamOne;
                    T2.InnerHtml = team2.TeamTwo;
                    tmTwoImage.InnerHtml = "<img src=" + team2.ImagePath + " class='avatar' alt='Avatar'/>";
                }
            }

            //getTeamsByGameID
        }

        protected void lnkAddLeague_Click(object sender, EventArgs e)
        {
            string gameID = Request.QueryString["G_ID"];
            string lgID = Request.QueryString["L_ID"];
            TeamServiceClient tsc = new TeamServiceClient();
            List<MyTeamModel> teams = new List<MyTeamModel>();
            teams = tsc.getTeamsByGameID(gameID);

            //string gameID = Request.QueryString["G_ID"];
            Game gameStats = new Game();

            gameStats.ID = Convert.ToInt32(gameID);
            gameStats.BestPlayer = TextBestPlayer.Value;


            gameStats.TeamOnePos = Convert.ToInt32(txt1Position.Value);
            gameStats.TeamOneFouls = Convert.ToInt32(txt1Foul.Value);
            gameStats.TeamOneCornerKick = Convert.ToInt32(txtT1_CK.Value);
            gameStats.TeamOneGoalScored = Convert.ToInt32(txt1_GS.Value);
            gameStats.TeamOneYellowCard = Convert.ToInt32(txtT1_YC.Value);
            gameStats.TeamOneRedCard = Convert.ToInt32(txtT1_RC.Value);
            gameStats.TeamOne_OveralAverage = Convert.ToDecimal(txt1Average.Value);

            gameStats.TeamTwoFouls = Convert.ToInt32(txt2Foul.Value);
            gameStats.TeamTwoPos = Convert.ToInt32(txt2Position.Value);
            gameStats.TeamTwoCornerKick = Convert.ToInt32(txtT2_CK.Value);
            gameStats.TeamTwoGoalScored = Convert.ToInt32(txt2_GS.Value);
            gameStats.TeamTwoYellowCard = Convert.ToInt32(txtT2_YC.Value);
            gameStats.TeamTwoRedCard = Convert.ToInt32(txtT2_RC.Value);
            gameStats.TeamTwo_OveralAverage = Convert.ToDecimal(txt2Average.Value);

            MatchServiceClient msc = new MatchServiceClient();
            string res = msc.GameStats(gameStats);
            
            if(res.Contains("success"))
            {
                bestplayer BPlayer = new bestplayer();
                BPlayer.leagueID = Convert.ToInt32(lgID);
                BPlayer.Name = TextBestPlayer.Value;
                BPlayer.Goals = Convert.ToInt32(txtBestPlayerGoals.Value);
                //Calculate Average
                msc.AddBestPlayer(BPlayer);
                Response.Redirect("ViewGameStats.aspx?G_ID=" + gameID+ "&L_ID=" + lgID);
            }
        }



    }
}