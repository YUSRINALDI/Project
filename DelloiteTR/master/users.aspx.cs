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

namespace DelloiteTR.master
{
    public partial class users : System.Web.UI.Page
    {
        private UserServices _services;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["userLog"] as string))
            {
                Response.Redirect("~/login/login.aspx?t=1");
            }

            if (Session["userRole"].ToString() == "2")
            {
                Response.Redirect("~/default.aspx");
            }

            _services = ServicesFactory.CreateUserServices(ConnectionString.Value);
            if (!this.IsPostBack)
            {
                this.loadData();
            }
        }

        private void loadData()
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    string textUsername = Request.QueryString["id"];
                    if (Request.QueryString["a"] == "1")
                    {
                        if (_services.Delete(textUsername))
                        {
                            Response.Redirect("~/master/users.aspx");
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                        vm.User user = _services.GetUser(textUsername);
                        username2.Text = user.username;
                        fullname2.Text = user.fullname;
                        email2.Text = user.email;
                        role2.SelectedValue = user.roleid.ToString();
                        suspended2.SelectedValue = user.suspended.ToString();

                    }
                }

                List<vm.User> users = _services.GetUsers();
                string htmltext = "";
                int i = 1;
                foreach (vm.User user in users)
                {
                    htmltext += "<tr><td>" + i + "</td>";
                    htmltext += "<td>" + user.username + "</td>";
                    htmltext += "<td>" + user.fullname + "</td>";
                    htmltext += "<td>" + user.email + "</td>";
                    if (user.roleid == 1)
                    {
                        htmltext += "<td>Admin</td>";
                    }
                    else
                    {
                        htmltext += "<td>User</td>";
                    }

                    if (user.suspended == 1)
                    {
                        htmltext += "<td>Suspended</td>";
                    }
                    else
                    {
                        htmltext += "<td>Visible</td>";
                    }

                    if (user.username == "admin")
                    {
                        htmltext += "<td><ul class=\"icons-list\"><li><a href='?a=2&id=" + user.username + "' ><i class=\"icon-pencil7\"></i></a></li></ul></td></tr>";
                    }
                    else
                    {
                        htmltext += "<td><ul class=\"icons-list\"><li><a href='?a=2&id=" + user.username + "' ><i class=\"icon-pencil7\"></i></a></li><li><a href='?a=1&id=" + user.username + "' OnClick=\"return confirm('Are you sure?')\"><i class='icon-trash'></i></a></li></ul></td></tr>";
                    }
                    
                    dataTable.Text = htmltext;
                    i++;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/master/users.aspx");
        }

        protected void LBSave_Click(object sender, EventArgs e)
        {
            try
            {
                String timeStamp = Hash.UnixTimeNow().ToString();

                if (_services.Create(username.Text, password.Text, short.Parse(suspended.SelectedValue.ToString()), 0, short.Parse(role.SelectedValue.ToString()), fullname.Text, email.Text, timeStamp, timeStamp, "0", "0"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "SuccessPopup()", true);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void LBEdit_Click(object sender, EventArgs e)
        {
            try
            {
                String timeStamp = Hash.UnixTimeNow().ToString();

                if (_services.Update(username2.Text, short.Parse(role2.SelectedValue.ToString()), fullname2.Text, email2.Text, short.Parse(suspended2.SelectedValue.ToString()), timeStamp))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "SuccessPopup()", true);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}