using SportClient.Definition.Users;
using SportClient.ServiceImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsManagementSystem
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public void SetSessions(BASE_USER user)
        {
            Session.Add("ID", user.ID.ToString());
            Session.Add("Name", user.Name);
            Session.Add("Surname", user.Surname);
            Session.Add("Email", user.Email);
            Session.Add("Level", user.Level);
        }



        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            LoginServiceClient login = new LoginServiceClient();
            BASE_USER user = new BASE_USER();
            user = login.Login(email.Value, password.Value);
            if (user != null)
            {

                SetSessions(user);
                Response.Redirect("Index.aspx");
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }
    }
}