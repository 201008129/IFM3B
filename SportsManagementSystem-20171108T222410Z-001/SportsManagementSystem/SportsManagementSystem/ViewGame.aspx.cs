using SportClient.Definition;
using SportClient.Definition.Users;
using SportClient.ServiceImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsManagementSystem
{
    public partial class ViewGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                int GameID = Convert.ToInt32(Request.QueryString["G_ID"]);
                MatchServiceClient msc = new MatchServiceClient();
                TeamServiceClient tsc = new TeamServiceClient();
                Team gm = new Team();
                gm = msc.GetGameByID(Convert.ToString(GameID));
                List<MyTeamModel> teams = tsc.getTeamsByGameID(Convert.ToString(GameID));
            //Team tm = teams.First();
            //Team tm2 = teams.Last();
            try
            {
                if(teams != null || teams.Count() != 0)
                {
                    MyTeamModel t1 = teams.First();
                    MyTeamModel t2 = teams.Last();
                    if (t1 != null || t2 != null)
                    {
                        List<Player> T1players = t1.players;
                        List<Player> T2players = t2.players;
                        if (T1players != null || T2players != null)
                        {
                            string html = "";
                            html += "<img style='width: 100%; display: block;' src='" + t1.ImagePath + "' alt='image'/>";
                            img1Div.InnerHtml = html;

                            html = "";
                            html += "<b>" + t1.TeamName + "</b>";
                            T1Name.InnerHtml = html;
                            T1_Desc.InnerHtml = t1.Desc;
                            T2_Desc.InnerHtml = t2.Desc;
                            html = "";
                            html += "<img style='width: 100%; display: block;' src='" + t2.ImagePath + "' alt='image'/>";
                            img2Div.InnerHtml = html;
                            html = "";
                            html += "<b>" + t2.TeamName + "</b>";
                            t2Name.InnerHtml = html;

                            html = "";
                            html += gm.sDate + " : " + gm.Venue;
                            Venue_Time.InnerHtml = html;

                            html = "";
                            if (T1players != null || T2players != null)
                            {
                                foreach (Player pl in T1players)
                                {
                                    html += "<tr>";
                                    html += "<th scope='row'>" + pl.Position + "</th>";
                                    html += "<td>" + pl.Name + "</td>";
                                    html += "<td>" + pl.PerformanceRate + "</td></tr>";
                                }
                                player1.InnerHtml = html;

                                html = "";
                                foreach (Player pl in T2players)
                                {
                                    html += "<tr>";
                                    html += "<th scope='row'>" + pl.Position + "</th>";
                                    html += "<td>" + pl.Name + "</td>";
                                    html += "<td>" + pl.PerformanceRate + "</td></tr>";
                                }
                                player2.InnerHtml = html;
                            }
                        }
                    }
                }

            }
            catch(Exception)
            {
                //DO Something
            }
           // MyTeamModel t1 = teams.ElementAt(0);
           //     MyTeamModel t2 = teams.ElementAt(1);
               
            
        }
    }
}