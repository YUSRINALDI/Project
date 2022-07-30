using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DelloiteTRLib;

namespace DelloiteTR
{
    public partial class Delloite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["logout"] == "1")
            {
                Session.Clear();
                Response.Redirect("~/default.aspx");
            }
            if (string.IsNullOrEmpty(Session["userLog"] as string))
            {
                Response.Redirect("~/login/login.aspx");
            }
            else
            {
                if (Session["userRole"].ToString() == "1")
                {
                    panelAdmin.Visible = true;
                    panelUser.Visible = true;
                }
                else if (Session["userRole"].ToString() == "2")
                {
                    panelAdmin.Visible = false;
                    panelUser.Visible = true;
                }
                lblFullname.Text = Session["userFullname"].ToString();
            }
        }
    }
}
