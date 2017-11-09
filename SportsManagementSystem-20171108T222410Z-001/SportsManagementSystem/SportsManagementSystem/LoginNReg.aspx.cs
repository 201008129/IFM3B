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
    public partial class LoginNReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LoginServiceClient login = new LoginServiceClient();
            BASE_USER user = new BASE_USER();
            user = login.Login(Email.Text, Password.Text);
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

        public void SetSessions(BASE_USER user)
        {
            Session.Add("ID", user.ID.ToString());
            Session.Add("Name", user.Name);
            Session.Add("Surname", user.Surname);
            Session.Add("Email", user.Email);
            Session.Add("Level", user.Level);
        }

        protected void btnRegUser_Click(object sender, EventArgs e)
        {
            RegServiceClient rsc = new RegServiceClient();
            string level = txtLevel.Text;
                BASE_USER user = new BASE_USER();
            user.Name = txtName.Text;
            user.Surname = txtSurname.Text;
            user.Email = txtEmail.Text;
            user.Level = txtLevel.Text;
            user.Pass = txtPass.Text;

            int strResponse = rsc.RegisterUser(user);
            //if(strResponse.ToLower().Contains("succ"))
            //{
            //    txtName.Text = "Success";
            //}else
            //{
            //    txtName.Text = "Success";
            //}
        }
    }
}