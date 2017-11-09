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
    public partial class ViewTeam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sportID = Request.QueryString["SportID"];
            MyTeamModel toupdate = new MyTeamModel();
            TeamServiceClient tsc = new TeamServiceClient();
            toupdate = tsc.getTeamsDetails(sportID);
            string htmltag = "";
            htmltag += "<img src='"+toupdate.ImagePath+"' alt='...' />";
            imgDiv.InnerHtml = htmltag;
            htmltag = "";
            htmltag += toupdate.TeamName;
            Name.InnerHtml = htmltag;
            Desc.InnerHtml = toupdate.Desc;
       //     ManagerName.InnerHtml = toupdate.LeaguName;
        }
    }
}