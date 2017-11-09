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
    public partial class TeamAdding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string TeamName = Convert.ToString(Request.QueryString["teamName"]);
            string LeagueName = Convert.ToString(Session["LeagueName"]);
            Team tm = new Team();
            tm.Name = TeamName;
            tm.LeagueName = LeagueName;
            tm.eDate = DateTime.Now;
           // tm.sDate = DateTime.Now;
            LeagueClient lg = new LeagueClient();
            string res = lg.CreateLeagueTeams(tm);
            if(res.ToLower().Contains("success"))
            {
                //Pop up needed
                Response.Redirect("LeagueTeams.aspx");
            }else
            {
                //Pop up neeeded
                Response.Redirect("LeagueTeams.aspx");
            }
        }
    }
}