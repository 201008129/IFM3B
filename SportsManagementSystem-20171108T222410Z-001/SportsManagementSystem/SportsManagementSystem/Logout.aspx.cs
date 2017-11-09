using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsManagementSystem
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session.Count != 0)
            {
                Session.RemoveAll();
                Response.Redirect("Index.aspx");
            }else
            {
                Response.Redirect("Index.aspx");
            }
        }
    }
}