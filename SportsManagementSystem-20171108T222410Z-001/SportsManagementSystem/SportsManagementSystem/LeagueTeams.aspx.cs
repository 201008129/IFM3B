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
    public partial class LeagueTeams : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////string htmltag = "";
            ////htmltag += "<li role='presentation' class=''><a href='#tab_content1' id='home-tab' role='tab' data-toggle='tab' aria-expanded='true'>League Info</a></li>";
            ////htmltag += "<li role='presentation' class='active'><a href='#tab_content3' role='tab' id='profile-tab2' data-toggle='tab' aria-expanded='false'>Team Selection</a></li>";
            ////myTab.InnerHtml = htmltag;
          //int leagueID = Convert.ToInt32(Request.QueryString["leagueID"]);
          //  LeagueClient lg = new LeagueClient();
          // League myLeage = lg.GetleagueByID(Convert.ToString(leagueID));
            

        }

        protected void btnSub_Click(object sender, EventArgs e)
        {

        }
    }
}