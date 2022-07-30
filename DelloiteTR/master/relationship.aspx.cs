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
    public partial class Relationship : System.Web.UI.Page
    {
        private RelationshipServices _services;

        protected void Page_Load(object sender, EventArgs e)
        {
            SetErrorMessage("");
            SetSuccesstMessage("");
            if (string.IsNullOrEmpty(Session["userLog"] as string))
            {
                Response.Redirect("~/login/login.aspx?t=1");
            }

            if (Session["userRole"].ToString() == "2")
            {
                Response.Redirect("~/default.aspx");
            }

            _services = ServicesFactory.CreateRelationshipServices(ConnectionString.Value);
            if (!this.IsPostBack)
            {
                this.loadData();
            }
        }
        
        private void SetErrorMessage(string message)
        {
            if (message == "")
            {
                errorBox.Visible = false;
                errorMsg.Text = "";
            }
            else
            {
                errorBox.Visible = true;
                errorMsg.Text = message;
            }
        }

        private void SetSuccesstMessage(string message)
        {
            if (message == "")
            {
                successBox.Visible = false;
                successMsg.Text = "";
            }
            else
            {
                successBox.Visible = true;
                successMsg.Text = message;
            }
        }

        private void loadalldata()
        {
            try
            {
                List<vm.Relationship> relations = _services.GetAll();
                string htmltext = "";
                int i = 1;
                foreach (vm.Relationship relation in relations)
                {
                    htmltext += "<tr><td>" + i + "</td><td>" + relation.relationship + "</td><td><ul class=\"icons-list\"><li><a href='?a=2&id=" + relation.id + "' ><i class=\"icon-pencil7\"></i></a></li><li><a href='?a=1&id=" + relation.id + "' OnClick=\"return confirm('Are you sure?')\"><i class='icon-trash'></i></a></li></ul></td></tr>";
                    dataTableRelation.Text = htmltext;
                    i++;
                }
            }catch(Exception ex){
                SetErrorMessage(ex.Message);
            }
        }

        private void loadData()
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    if (Request.QueryString["a"] == "1")
                    {
                        if (_services.Delete(id))
                        {
                            loadalldata();
                            SetSuccesstMessage("Data has been deleted");
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                        vm.Relationship relation = _services.GetByID(id);
                        relationid.Value = relation.id.ToString();
                        relationship.Text = relation.relationship;

                    }
                }

                loadalldata();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/master/relationship.aspx");
        }

        protected void btnSaveRelation_Click(object sender, EventArgs e)
        {
            try
            {
                String timeStamp = Hash.UnixTimeNow().ToString();

                if (relationid.Value != "")
                {
                    if (_services.Update(int.Parse(relationid.Value), relationship.Text, Session["userLog"].ToString(), timeStamp, Session["userLog"].ToString(), timeStamp))
                    {
                        loadalldata();
                        SetSuccesstMessage("Data has been updated");
                    }
                }
                else
                {
                    if (_services.Create(relationship.Text, Session["userLog"].ToString(), timeStamp, Session["userLog"].ToString(), timeStamp))
                    {
                        loadalldata();
                        SetSuccesstMessage("Data has been saved");
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}