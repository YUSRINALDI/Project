using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DelloiteTRLib.Services;
using DelloiteTRLib.Model;

namespace DelloiteTR.login
{
    public partial class login : System.Web.UI.Page
    {
        private UserServices _userServices;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["t"]))
            {
                timeout.Visible = false;
            }
            else
            {
                timeout.Visible = true;
            }

            divError.Visible = false;
            _userServices = ServicesFactory.CreateUserServices(ConnectionString.Value);
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = this.txtUsername.Text;
                string password = this.txtPassword.Text;

                if(string.IsNullOrEmpty(username)){
                    divError.Visible = true;
                    labelError.Text = "Username is required";
                    this.txtUsername.Text = username;
                    this.txtPassword.Text = password;
                    this.txtUsername.Focus();
                }
                else if (string.IsNullOrEmpty(password))
                {
                    divError.Visible = true;
                    labelError.Text = "Password is required";
                    this.txtUsername.Text = username;
                    this.txtPassword.Text = password;
                    this.txtPassword.Focus();
                }else{
                    User User = _userServices.Login(username, password);

                    Session["userLog"] = User.username;
                    Session["userFullname"] = User.fullname;
                    Session["userRole"] = User.roleid;
                    //Session.Timeout = 900;
                    //Session["userToken"] = User.username;

                    Response.Redirect("~/default.aspx");
                }
                
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                labelError.Text = "Invalid Username or Password";
            }

        }
    }
}