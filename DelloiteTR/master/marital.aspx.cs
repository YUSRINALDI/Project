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
    public partial class Marital : System.Web.UI.Page
    {
        private MaritalServices _maritalServices;

        protected void Page_Load(object sender, EventArgs e)
        {
            SetErrorMessage("");
            SetSuccesstMessage("");
            if (string.IsNullOrEmpty(Session["userLog"] as string))
            {
                Response.Redirect("~/login/login.aspx?t=1");
            }
            else
            {
                if (Session["userRole"].ToString() == "2")
                {
                    Response.Redirect("~/default.aspx");
                }

                _maritalServices = ServicesFactory.CreateMaritalServices(ConnectionString.Value);
                if (!this.IsPostBack)
                {
                    this.loadData();
                }
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
                        if (_maritalServices.Delete(id))
                        {
                            loadalldata();
                            SetSuccesstMessage("Data has been deleted");
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                        vm.Marital marital = _maritalServices.GetByID(id);
                        maritalid.Value = marital.id.ToString();
                        year.Text = marital.year;

                        status.Value = marital.status;
                        
                        amount.Text = marital.amount.ToString("#,##0");
                        dependant.Text = marital.dependant.ToString("#,##0");

                    }
                }

                loadalldata();
            }
            catch (Exception ex)
            {
                SetErrorMessage(ex.Message);
            }
        }

        private void loadalldata()
        {
            try
            {
                List<vm.Marital> maritals = _maritalServices.GetAll();
                string htmltext = "";
                int i = 1;
                foreach (vm.Marital marital in maritals)
                {
                    var stat = "";
                    if (marital.status == "Married1")
                    {
                        stat = "Married";
                    }
                    else if (marital.status == "Married2")
                    {
                        stat = "Married+";
                    }
                    else
                    {
                        stat = marital.status;
                    }
                    string amount = marital.amount.ToString("#,##0");
                    string dependant = marital.dependant.ToString("#,##0");
                    htmltext += "<tr><td>" + i + "</td><td>" + marital.year + "</td><td>" + stat + "</td><td style='text-align:right;'>" + amount + "</td><td style='text-align:right;'>" + dependant + "</td><td><ul class=\"icons-list\"><li><a href='?a=2&id=" + marital.id + "' ><i class=\"icon-pencil7\"></i></a></li><li><a href='?a=1&id=" + marital.id + "' OnClick=\"return confirm('Are you sure?')\"><i class='icon-trash'></i></a></li></ul></td></tr>";
                    dataTable.Text = htmltext;
                    i++;
                }
            }
            catch(Exception ex){
                SetErrorMessage(ex.Message);
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/master/marital.aspx");
        }

        protected void LBSave_Click(object sender, EventArgs e)
        {
            try
            {
                string txtyear = year.Text;
                string txtstatus = status.Value;
                string txtdependant = dependant.Text.Replace(",", "");
                txtdependant = txtdependant.Split('.')[0].ToString();
                string txtamount = amount.Text.Replace(",", "");
                txtamount = txtamount.Split('.')[0].ToString();
                String timeStamp = Hash.UnixTimeNow().ToString();

                int amountnumber;
                IFormatProvider provider = CultureInfo.CreateSpecificCulture("en-US");
                string value = txtamount;
                if (Int32.TryParse(value, NumberStyles.Integer | NumberStyles.AllowThousands,
                            provider, out amountnumber))
                {
                }

                int dependantmount;
                provider = CultureInfo.CreateSpecificCulture("en-US");
                value = txtdependant;
                if (Int32.TryParse(value, NumberStyles.Integer | NumberStyles.AllowThousands,
                            provider, out dependantmount))
                {
                }


                if (maritalid.Value != "")
                {
                    if (_maritalServices.Update(int.Parse(maritalid.Value), year.Text, txtstatus, amountnumber, Session["userLog"].ToString(), timeStamp, Session["userLog"].ToString(), timeStamp, dependantmount))
                    {
                        loadalldata();
                        SetSuccesstMessage("Data has been updated");
                    }
                }
                else
                {
                    if (_maritalServices.Create(year.Text, txtstatus, amountnumber, Session["userLog"].ToString(), timeStamp, Session["userLog"].ToString(), timeStamp, dependantmount))
                    {
                        loadalldata();
                        SetSuccesstMessage("Data has been saved");
                    }
                }
            }
            catch (Exception ex)
            {

                SetErrorMessage(ex.Message);
            }
        }

    }
}