using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsManagementSystem
{
    public partial class Statistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strSessionLevel = Convert.ToString(Session["Level"]);
            if(strSessionLevel.ToLower().Equals("manager"))
            {
                ManagerReports.Visible = true;
                AdminReports.Visible = false;
            }
            else if (strSessionLevel.ToLower().Equals("admin"))
            {
                ManagerReports.Visible = false;
                AdminReports.Visible = true;
            }
        }
    }
}