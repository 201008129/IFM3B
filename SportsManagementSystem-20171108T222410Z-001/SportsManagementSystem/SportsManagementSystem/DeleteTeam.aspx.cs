using SportClient.ServiceImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsManagementSystem
{
    public partial class DeleteTeam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sportID = Request.QueryString["SportID"];
            //Delete Teams
            //Delete Team Image First
            //Delete Team Players
            //Delete Record in Sport League BT

            //Delete Team players
            PlayerServiceClient playerClient = new PlayerServiceClient();
            string dl_Player = playerClient.Dl_PlayersBySportID(sportID);

            //Delete Team Image
            FileClient flClient = new FileClient();
            string dl_Image = flClient.deleteTeamImageBySportID(sportID);

            //Delete from  SportLeague Bridging table
            LeagueClient lgClient = new LeagueClient();
            string dl_BridgingTable = lgClient.dl_SprotLeague_BTByID(sportID);

            //Now delete the team
            int LoggedID = Convert.ToInt32(Session["ID"]);
            TeamServiceClient tsc = new TeamServiceClient();
            string dl_Sport = tsc.DeleteTeamByID(sportID);
            if (dl_Sport.Contains("success"))
            {
                Response.Redirect("TeamManagement.aspx?UserID=" + LoggedID);
            }
        }
    }
}