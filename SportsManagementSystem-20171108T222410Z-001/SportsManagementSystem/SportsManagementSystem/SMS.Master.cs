using SportClient.Definition;
using SportClient.ServiceImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsManagementSystem
{
    public partial class SMS : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session.Count != 0)
            {
                FileClient fc = new FileClient();
                int LoggedID = Convert.ToInt32(Session["ID"]);
                string Name = Convert.ToString(Session["Name"]);
                string imgLocation = fc.getUserImagePathById(Convert.ToString(LoggedID));
                string html = "";
                html += "<div class='profile_pic'>";
                html += "<img src='"+imgLocation+"' alt='...' class='img-circle profile_img'/></div>";
                html += "<div class='profile_info'>";
                html += "<span>Welcome,</span>";
                html += "<h2>"+Name+"</h2></div>";
                profileInfo.InnerHtml = html;

                //Testing
                string html2 = "";
                html2 += "<img src=" + imgLocation + " alt=''/>";
                html2 += "<p>"+ Name+" </p><span class=' fa fa-angle-down'></span>";

                   reg.Visible = false;
                login.Visible = false;
                logout.Visible = true;


                if (Convert.ToString(Session["Level"]).ToLower().Equals("general"))
                {
                    adminNav.Visible = false;
                    managerNavBar.Visible = false;
                }
                else if (Convert.ToString(Session["Level"]).ToLower().Equals("admin"))
                {
                    adminNav.Visible = true;
                    managerNavBar.Visible = false;
                   
                    string lgHtml = "<a href='LeagueList.aspx?UserID=" + LoggedID + "'>League Management</a>";
                    //UserID
                    lg_Management.InnerHtml = lgHtml;

                    string gamehtml = "<a href='GameManagement.aspx?UserID="+ LoggedID + "'>Game Management</a>";
                    GameManagement.InnerHtml = gamehtml;
                    //GameManagement.aspx
                    AddGame.InnerHtml = "<a href='LeagueList.aspx?UserID=" + LoggedID + "'>New Game</a>";
                }
                else if (Convert.ToString(Session["Level"]).ToLower().Equals("player"))
                {
                    adminNav.Visible = false;
                    managerNavBar.Visible = false;
                }
                else if (Convert.ToString(Session["Level"]).ToLower().Equals("manager"))
                {
                    adminNav.Visible = false;
                    managerNavBar.Visible = true;
                    string tmHtml = "<a href='TeamManagement.aspx?UserID=" + LoggedID + "'>Team Management</a>";
                    TeamManagement.InnerHtml = tmHtml;
                }else
                {
                    adminNav.Visible = false;
                    managerNavBar.Visible = false;
                }
            }
            else
            {
                logout.Visible = false;
                reg.Visible = true;
                login.Visible = true;
                adminNav.Visible = false;
                managerNavBar.Visible = false;
            }

            //Load Leagues
            // GetleagueByCat
            List<League> RugbyLeague = new List<League>();
            List<League> SoccerLeague = new List<League>();
            List<League> CricketLeague = new List<League>();
            RugbyLeague = GetLeague("Rugby");
            SoccerLeague = GetLeague("Soccer");
            CricketLeague = GetLeague("Cricket");
            string htmlFix = "";
            string htmlRes = "";
            string htmlLog = "";
            //Foorball League
            foreach (League sc in SoccerLeague) //League Fixure
            {
                htmlFix += "<li><a href=LeagueFixture.aspx?L_ID="+sc.ID+">"+ sc.Name +"</a></li>";
                htmlRes += "<li><a href=GeneralGameStats.aspx?L_ID=" + sc.ID+">"+sc.Name+"</a></li>";
                htmlLog += "<li><a href=LeagueLog.aspx?L_ID=" + sc.ID+">" + sc.Name + "</a></li>";
            }
            footbalFixureLeague.InnerHtml = htmlFix;
            footbalRes.InnerHtml = htmlRes;
            footbalLog.InnerHtml = htmlLog;

            //Rugby
            htmlFix = "";
            htmlRes = "";
            htmlLog = "";
            foreach (League rg in RugbyLeague) //League Fixure
            {
                htmlFix += "<li><a href=LeagueFixture.aspx?L_ID=" + rg.ID + ">" + rg.Name + "</a></li>";
                htmlRes += "<li><a href=GeneralGameStats.aspx?L_ID=" + rg.ID + ">" + rg.Name + "</a></li>";
                htmlLog += "<li><a href=LeagueLog.aspx?L_ID=" + rg.ID + ">" + rg.Name + "</a></li>";
            }
            rugFix.InnerHtml = htmlFix;
            rugRes.InnerHtml = htmlRes;
            rugLog.InnerHtml = htmlLog;

            //Cricket
            htmlFix = "";
            htmlRes = "";
            htmlLog = "";
            foreach (League cr in CricketLeague) //League Fixure
            {
                htmlFix += "<li><a href=LeagueFixture.aspx?L_ID=" + cr.ID + ">" + cr.Name + "</a></li>";
                htmlRes += "<li><a href=GeneralGameStats.aspx?L_ID=" + cr.ID + ">" + cr.Name + "</a></li>";
                htmlLog += "<li><a href=LeagueLog.aspx?L_ID=" + cr.ID + ">" + cr.Name + "</a></li>";
            }
            crickFix.InnerHtml = htmlFix;
            crickRes.InnerHtml = htmlRes;
            crickLog.InnerHtml = htmlLog;
        }

        public List<League> GetLeague(string Category)
        {
            
            LeagueClient leagueClient = new LeagueClient();
            List<League> leagues = new List<League>();

            try
            {
                leagues = leagueClient.GetleagueByCat(Category);
                return leagues;
            }catch(Exception)
            {
                return null;
            }
        }
    }
}