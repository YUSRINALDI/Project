using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DelloiteTRLib;
using DelloiteTRLib.Services;
using vm = DelloiteTRLib.Model;
using System.Globalization;


namespace DelloiteTR
{
    public partial class Profile : System.Web.UI.Page
    {
        UserServices _services;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _services = ServicesFactory.CreateUserServices(ConnectionString.Value);
                vm.User vmuser = _services.GetUser(Session["userLog"].ToString());
                username.Text = vmuser.username;
                fullname.Text = vmuser.fullname;
                email.Text = vmuser.email;

                string rolename = "";
                if (vmuser.roleid == 1)
                {
                    rolename = "Admin";
                }
                else
                {
                    rolename = "User";
                }

                role.Text = rolename;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            try
            {
                String timeStamp = Hash.UnixTimeNow().ToString();
                vm.User vmUser = _services.Login(Session["userLog"].ToString(), currentpassword.Text);
                if (vmUser != null)
                {
                    _services.ChangePassword(Session["userLog"].ToString(), newpassword.Text, timeStamp);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data has been saved');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Incorrect Password');", true);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}