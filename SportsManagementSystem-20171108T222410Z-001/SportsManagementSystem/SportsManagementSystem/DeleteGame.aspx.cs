using SportClient.ServiceImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsManagementSystem
{
    public partial class DeleteGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string gameID = Request.QueryString["G_ID"];
            int LoggedID = Convert.ToInt32(Session["ID"]);
            //DeleteGameStatsGameByID
            //DeleteGameByID
            //deleteImageByID
            FileClient flClient = new FileClient();
            string dl_Image = flClient.deleteGameImageByID(gameID);
            MatchServiceClient gameClient = new MatchServiceClient();
            string dl_GameStats = gameClient.DeleteGameStatsGameByID(gameID);
            string dl_Game = gameClient.DeleteGameByID(gameID);
            if(dl_Game.ToLower().Contains("success"))
            {
                //Popup
                Response.Redirect("GameManagement.aspx?UserID="+LoggedID);
            }
            else
            {
                //Popup
                Response.Redirect("");
            }
        }
    }
}