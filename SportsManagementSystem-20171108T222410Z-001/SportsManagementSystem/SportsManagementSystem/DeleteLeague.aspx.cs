using SportClient.ServiceImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsManagementSystem
{
    public partial class DeleteLeague : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string l_ID = Request.QueryString["LeagueID"];
            int LoggedID = Convert.ToInt32(Session["ID"]);
            //dl_League
            LeagueClient lgClient = new LeagueClient();
            string dl_league = lgClient.dl_League(l_ID);
            if(dl_league.ToLower().Contains("success"))
            {
                //popup
                Response.Redirect("LeagueList.aspx?UserID=" + LoggedID);
            }else
            {
                //popup
                Response.Redirect("LeagueList.aspx?UserID=" + LoggedID);
            }
        }
    }
}