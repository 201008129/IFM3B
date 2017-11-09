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
    public partial class LeagueFixture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String L_ID = Request.QueryString["L_ID"];
            //if(L_ID == null)
            //{
            //    Response.Redirect("Index.aspx");
            //}else
            //{
            //    int intL_ID = Convert.ToInt32(L_ID);
            //    populateTable(intL_ID);
            //}


        }

        //public void populateTable(int ID)
        //{
        //    MatchServiceClient league = new MatchServiceClient();
        //    List<MyTeamModel> games = new List<MyTeamModel>();
        //    games = league.LeagueGames(Convert.ToString(ID));
          
        //        string html = "";
        //        foreach(MyTeamModel gm in games)
        //        {
        //            html += "<td><img src='" + gm.ImagePath + "' alt = '...' class='img-circle profile_img'/></td>";
        //            html += "<td><a href=ViewGame.aspx?G_ID="+gm.G_ID+">" + gm.TeamOne+" vs "+gm.TeamTwo+"</a></td>";
        //            html += "<td></td>";
        //            html += "<td>"+gm.Date+"</td>";
        //            html += "<td>"+gm.Venue+"</td>";
        //            html += "<td><a href='#'>Get Ticket</a></td>";
        //        }
        //  //      TeamRow = html;
            
        //}
    }
}