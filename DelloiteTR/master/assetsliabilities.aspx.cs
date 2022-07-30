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
    public partial class Assetsliabilities : System.Web.UI.Page
    {
        private AssetsliabilitiesServices _assetsliabilitiesServices;

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

            _assetsliabilitiesServices = ServicesFactory.CreateAssetsliabilitiesServices(ConnectionString.Value);
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
                List<vm.Assetsliabilities> assetsliabilitiess = _assetsliabilitiesServices.GetAll();
                string htmltext = "";
                int i = 1;
                foreach (vm.Assetsliabilities assetsliabilities in assetsliabilitiess)
                {
                    string theform = "";
                    if (assetsliabilities.form == "form1770")
                    {
                        theform = "Form 1770";
                    }
                    else if (assetsliabilities.form == "formNonUs")
                    {
                        theform = "Form Non Us";
                    }
                    else if (assetsliabilities.form == "formUs")
                    {
                        theform = "Form Us";
                    }
                    else if (assetsliabilities.form == "formJapan")
                    {
                        theform = "Form Japan";
                    }

                    string thegroup = "";
                    if (assetsliabilities.code.StartsWith("01"))
                    {
                        thegroup = "Cash And Cash Equivalent";
                    }
                    else if (assetsliabilities.code.StartsWith("02"))
                    {
                        thegroup = "Account Receivables";
                    }
                    else if (assetsliabilities.code.StartsWith("03"))
                    {
                        thegroup = "Investments";
                    }
                    else if (assetsliabilities.code.StartsWith("04"))
                    {
                        thegroup = "Vehicles";
                    }
                    else if (assetsliabilities.code.StartsWith("05"))
                    {
                        thegroup = "Moveable Assets";
                    }
                    else if (assetsliabilities.code.StartsWith("06"))
                    {
                        thegroup = "Immoveable Assets";
                    }
                    else if (assetsliabilities.code.StartsWith("10"))
                    {
                        thegroup = "Liabilities";
                    }

                    string code = assetsliabilities.code;
                    //string code = assetsliabilities.code.Substring(2, assetsliabilities.code.Length-2);
                    htmltext += "<tr><td>" + i + "</td><td>" + theform + "</td><td>" + thegroup + "</td><td>" + code + "</td><td>" + assetsliabilities.account + "</td><td><ul class=\"icons-list\"><li><a href='?a=2&id=" + assetsliabilities.id + "' ><i class=\"icon-pencil7\"></i></a></li><li><a href='?a=1&id=" + assetsliabilities.id + "' OnClick=\"return confirm('Are you sure?')\"><i class='icon-trash'></i></a></li></ul></td></tr>";
                    dataTableAsset.Text = htmltext;
                    i++;
                }
            }
            catch (Exception ex)
            {
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
                        if (_assetsliabilitiesServices.Delete(id))
                        {
                            loadalldata();
                            SetSuccesstMessage("Data has been deleted");
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                        vm.Assetsliabilities assetsliabilities = _assetsliabilitiesServices.GetByID(id);
                        assetid.Value = assetsliabilities.id.ToString();
                        cbForm.Value = assetsliabilities.form;
                        string thegroup = assetsliabilities.code.Substring(0, 2);
                        string thecode = assetsliabilities.code.Substring(2, assetsliabilities.code.Length - 2);
                        cbGroup.Value = thegroup;
                        tbgroup.Text = thegroup;
                        code.Text = thecode;
                        account.Text = assetsliabilities.account;

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
            Response.Redirect("~/master/assetsliabilities.aspx");
        }

        protected void btnSaveAsset_Click(object sender, EventArgs e)
        {
            try
            {
                String timeStamp = Hash.UnixTimeNow().ToString();
                IFormatProvider provider = CultureInfo.CreateSpecificCulture("en-US");

                if (assetid.Value != "")
                {
                    if (_assetsliabilitiesServices.GetAllBy(cbGroup.Value + code.Text, account.Text).Count == 0)
                    {
                        if (_assetsliabilitiesServices.Update(int.Parse(assetid.Value), cbForm.Value, cbGroup.Value + code.Text, account.Text, "admin", timeStamp, "admin", timeStamp))
                        {
                            loadalldata();
                            SetSuccesstMessage("Data has been updated");
                        }
                    }
                    else
                    {
                        SetSuccesstMessage("Data has been exist");
                    }
                }
                else
                {
                    if (_assetsliabilitiesServices.GetAllBy(cbGroup.Value + code.Text, account.Text).Count == 0)
                    {
                        if (_assetsliabilitiesServices.Create(cbForm.Value, cbGroup.Value + code.Text, account.Text, Session["userLog"].ToString(), timeStamp, Session["userLog"].ToString(), timeStamp))
                        {
                            loadalldata();
                            SetSuccesstMessage("Data has been saved");
                        }
                    }
                    else
                    {
                        SetSuccesstMessage("Data has been exist");
                    }
                    
                }

                cbForm.Value = "";
                cbGroup.Value = "";
                code.Text = "";
                account.Text = "";
                tbgroup.Text = "";
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}