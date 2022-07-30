using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DelloiteTRLib.Services;
using DelloiteTRLib;
using vm = DelloiteTRLib.Model;
using System.Globalization;

namespace DelloiteTR
{
    public partial class Exchange : System.Web.UI.Page
    {
        private ExchangeServices _services;
        private String timeStamp;

        protected void Page_Load(object sender, EventArgs e)
        {
            SetErrorMessage("");
            SetSuccesstMessage(1, "");
            SetSuccesstMessage(2, "");
            SetSuccesstMessage(3, "");
            SetSuccesstMessage(4, "");
            if (string.IsNullOrEmpty(Session["userLog"] as string))
            {
                Response.Redirect("~/login/login.aspx?t=1");
            }

            if (Session["userRole"].ToString() == "2")
            {
                Response.Redirect("~/default.aspx");
            }

            _services = ServicesFactory.CreateExchangeServices(ConnectionString.Value);

            timeStamp = Hash.UnixTimeNow().ToString();

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

        private void SetSuccesstMessage(int box,string message)
        {
            if (message == "")
            {
                if (box==1)
                {
                    successBox1.Visible = false;
                    successMsg1.Text = "";
                }
                else if (box == 2)
                {
                    successBox2.Visible = false;
                    successMsg2.Text = "";
                }
                else if (box == 3)
                {
                    successBox3.Visible = false;
                    successMsg3.Text = "";
                }
                else if (box == 4)
                {
                    successBox4.Visible = false;
                    successMsg4.Text = "";
                }
            }
            else
            {
                if (box == 1)
                {
                    successBox1.Visible = true;
                    successMsg1.Text = message;
                }
                else if (box == 2)
                {
                    successBox2.Visible = true;
                    successMsg2.Text = message;
                }
                else if (box == 3)
                {
                    successBox3.Visible = true;
                    successMsg3.Text = message;
                }
                else if (box == 4)
                {
                    successBox4.Visible = true;
                    successMsg4.Text = message;
                }
            }
        }

        private void loadalldata()
        {
            try
            {
                List<vm.Exchange> exchanges = _services.GetAllBy("", "", "", "", 0, 1);
                string htmltext = "";
                int i = 1;
                foreach (vm.Exchange exchange in exchanges)
                {
                    string amount = exchange.amount.ToString("#,###.##");
                    if (!amount.Contains('.'))
                    {
                        amount = amount + ".00";
                    }
                    htmltext += "<tr><td>" + i + "</td><td>" + exchange.country + "</td><td>" + exchange.currency + "</td><td>" + exchange.year + "</td><td>" + exchange.interval + "</td><td style='text-align:right;'>" + amount + "</td><td><ul class=\"icons-list\"><li><a href='?a=2&id=" + exchange.id + "&t=" + exchange.type + "' ><i class=\"icon-pencil7\"></i></a></li><li><a href='?a=1&id=" + exchange.id + "&t=" + exchange.type + "' OnClick=\"return confirm('Are you sure?')\"><i class='icon-trash'></i></a></li></ul></td></tr>";
                    dataTable1.Text = htmltext;
                    i++;
                }

                exchanges = _services.GetAllBy("", "", "", "", 0, 2);
                htmltext = "";
                i = 1;
                foreach (vm.Exchange exchange in exchanges)
                {
                    string amount = exchange.amount.ToString("#,###.##");
                    if (!amount.Contains('.'))
                    {
                        amount = amount + ".00";
                    }
                    htmltext += "<tr><td>" + i + "</td><td>" + exchange.country + "</td><td>" + exchange.currency + "</td><td>" + exchange.year + "</td><td>" + exchange.interval + "</td><td style='text-align:right;'>" + amount + "</td><td><ul class=\"icons-list\"><li><a href='?a=2&id=" + exchange.id + "&t=" + exchange.type + "' ><i class=\"icon-pencil7\"></i></a></li><li><a href='?a=1&id=" + exchange.id + "&t=" + exchange.type + "' OnClick=\"return confirm('Are you sure?')\"><i class='icon-trash'></i></a></li></ul></td></tr>";
                    dataTable2.Text = htmltext;
                    i++;
                }

                exchanges = _services.GetAllBy("", "", "", "", 0, 3);
                htmltext = "";
                i = 1;
                foreach (vm.Exchange exchange in exchanges)
                {
                    string amount = exchange.amount.ToString("#,###.##");
                    if (!amount.Contains('.'))
                    {
                        amount = amount + ".00";
                    }
                    htmltext += "<tr><td>" + i + "</td><td>" + exchange.country + "</td><td>" + exchange.currency + "</td><td>" + exchange.year + "</td><td>" + exchange.interval + "</td><td style='text-align:right;'>" + amount + "</td><td><ul class=\"icons-list\"><li><a href='?a=2&id=" + exchange.id + "&t=" + exchange.type + "' ><i class=\"icon-pencil7\"></i></a></li><li><a href='?a=1&id=" + exchange.id + "&t=" + exchange.type + "' OnClick=\"return confirm('Are you sure?')\"><i class='icon-trash'></i></a></li></ul></td></tr>";
                    dataTable3.Text = htmltext;
                    i++;
                }

                exchanges = _services.GetAllBy("", "", "", "", 0, 4);
                htmltext = "";
                i = 1;
                foreach (vm.Exchange exchange in exchanges)
                {
                    string amount = exchange.amount.ToString("#,###.##");
                    if (!amount.Contains('.'))
                    {
                        amount = amount + ".00";
                    }
                    htmltext += "<tr><td>" + i + "</td><td>" + exchange.country + "</td><td>" + exchange.currency + "</td><td>" + exchange.year + "</td><td>" + exchange.interval + "</td><td style='text-align:right;'>" + amount + "</td><td><ul class=\"icons-list\"><li><a href='?a=2&id=" + exchange.id + "&t=" + exchange.type + "' ><i class=\"icon-pencil7\"></i></a></li><li><a href='?a=1&id=" + exchange.id + "&t=" + exchange.type + "' OnClick=\"return confirm('Are you sure?')\"><i class='icon-trash'></i></a></li></ul></td></tr>";
                    dataTable4.Text = htmltext;
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
                        if (_services.Delete(id))
                        {
                            loadalldata();
                            int box = 1;
                            if (Request.QueryString["t"]=="1")
                            {
                                box = 1;
                            }
                            else if (Request.QueryString["t"] == "2")
                            {
                                box = 2;
                            }
                            else if (Request.QueryString["t"] == "3")
                            {
                                box = 3;
                            }
                            else if (Request.QueryString["t"] == "4")
                            {
                                box = 4;
                            }
                            SetSuccesstMessage(box, "Data has been deleted");
                        }
                    }
                    else
                    {
                        if (Request.QueryString["t"] == "1")
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup1();", true);
                            vm.Exchange exchange = _services.GetByID(id);
                            exchangeweeklyid.Value = exchange.id.ToString();
                            country.Value = exchange.country;
                            currency.Value = exchange.currency;
                            year.Value = exchange.year;
                            string[] interval = exchange.interval.Split('-');
                            intervalfrom.Value = interval[0];
                            intervalto.Value = interval[1];
                            amount.Value = exchange.amount.ToString("#,###.##");
                            if (!amount.Value.Contains('.'))
                            {
                                amount.Value = amount.Value + ".00";
                            }

                        }
                        else if (Request.QueryString["t"] == "2")
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup2();", true);
                            vm.Exchange exchange = _services.GetByID(id);
                            exchangemonthlyid.Value = exchange.id.ToString();
                            country2.Value = exchange.country;
                            currency2.Value = exchange.currency;
                            year2.Value = exchange.year;
                            interval2.Value = exchange.interval;
                            amount2.Value = exchange.amount.ToString("#,###.##");
                            if (!amount2.Value.Contains('.'))
                            {
                                amount2.Value = amount2.Value + ".00";
                            }
                        }
                        else if (Request.QueryString["t"] == "3")
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup3();", true);
                            vm.Exchange exchange = _services.GetByID(id);
                            exchangeyearlyid.Value = exchange.id.ToString();
                            country3.Value = exchange.country;
                            currency3.Value = exchange.currency;
                            year3.Value = exchange.year;
                            interval3.Value = exchange.interval;
                            amount3.Value = exchange.amount.ToString("#,###.##");
                            if (!amount3.Value.Contains('.'))
                            {
                                amount3.Value = amount3.Value + ".00";
                            }
                        }
                        else if (Request.QueryString["t"] == "4")
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup4();", true);
                            vm.Exchange exchange = _services.GetByID(id);
                            exchangebrokenyearlyid.Value = exchange.id.ToString();
                            country4.Value = exchange.country;
                            currency4.Value = exchange.currency;
                            year4.Value = exchange.year;
                            interval4.Value = exchange.interval;
                            amount4.Value = exchange.amount.ToString("#,###.##");
                            if (!amount4.Value.Contains('.'))
                            {
                                amount4.Value = amount4.Value + ".00";
                            }
                        }
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
            Response.Redirect("~/master/exchange.aspx");
        }

        protected void LBSaveWeekly_Click(object sender, EventArgs e)
        {
            try
            {
                string textCountry = country.Value;
                string textCurrency = currency.Value;
                string textYear = year.Value;
                string textInterval = intervalfrom.Value + "-" + intervalto.Value;
                var a = amount.Value.Replace(",", "").ToString();
                double textAmount = double.Parse(a);
                int textType = 1;

                if (exchangeweeklyid.Value != "")
                {
                    if (_services.Update(int.Parse(exchangeweeklyid.Value), textCountry, textCurrency, textYear, textInterval, textAmount, textType, Session["userLog"].ToString(), timeStamp, Session["userLog"].ToString(), timeStamp))
                    {
                        loadalldata();
                        SetSuccesstMessage(1, "Data has been updated");
                    }
                }
                else
                {
                    if (_services.Create(textCountry, textCurrency, textYear, textInterval, textAmount, textType, Session["userLog"].ToString(), timeStamp, Session["userLog"].ToString(), timeStamp))
                    {
                        loadalldata();
                        SetSuccesstMessage(1, "Data has been saved");
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        protected void LBSaveMonthly_Click(object sender, EventArgs e)
        {
            try
            {
                string textCountry = country2.Value;
                string textCurrency = currency2.Value;
                string textYear = year2.Value;
                string textInterval = interval2.Value;
                //int textAmount = int.Parse(amount2.Value.Replace(",", ""));
                var a = amount2.Value.Replace(",", "").ToString();
                double textAmount = double.Parse(a);
                int textType = 2;

                if (exchangemonthlyid.Value != "")
                {
                    if (_services.Update(int.Parse(exchangemonthlyid.Value), textCountry, textCurrency, textYear, textInterval, textAmount, textType, Session["userLog"].ToString(), timeStamp, Session["userLog"].ToString(), timeStamp))
                    {
                        loadalldata();
                        SetSuccesstMessage(2, "Data has been updated");
                    }
                }
                else
                {
                    if (_services.Create(textCountry, textCurrency, textYear, textInterval, textAmount, textType, Session["userLog"].ToString(), timeStamp, Session["userLog"].ToString(), timeStamp))
                    {
                        loadalldata();
                        SetSuccesstMessage(2, "Data has been saved");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void LBSaveYearly_Click(object sender, EventArgs e)
        {
            try
            {
                string textCountry = country3.Value;
                string textCurrency = currency3.Value;
                string textYear = year3.Value;
                string textInterval = interval3.Value;
                //int textAmount = int.Parse(amount3.Value.Replace(",", ""));
                var a = amount3.Value.Replace(",", "").ToString();
                double textAmount = double.Parse(a);
                int textType = 3;

                if (exchangeyearlyid.Value != "")
                {
                    if (_services.Update(int.Parse(exchangeyearlyid.Value), textCountry, textCurrency, textYear, textInterval, textAmount, textType, Session["userLog"].ToString(), timeStamp, Session["userLog"].ToString(), timeStamp))
                    {
                        loadalldata();
                        SetSuccesstMessage(3, "Data has been updated");
                    }
                }
                else
                {
                    if (_services.Create(textCountry, textCurrency, textYear, textInterval, textAmount, textType, Session["userLog"].ToString(), timeStamp, Session["userLog"].ToString(), timeStamp))
                    {
                        loadalldata();
                        SetSuccesstMessage(3, "Data has been saved");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void LBSaveBrokenYear_Click(object sender, EventArgs e)
        {
            try
            {
                string textCountry = country4.Value;
                string textCurrency = currency4.Value;
                string textYear = year4.Value;
                string textInterval = interval4.Value;
                //int textAmount = int.Parse(amount3.Value.Replace(",", ""));
                var a = amount4.Value.Replace(",", "").ToString();
                double textAmount = double.Parse(a);
                int textType = 4;

                if (exchangeyearlyid.Value != "")
                {
                    if (_services.Update(int.Parse(exchangebrokenyearlyid.Value), textCountry, textCurrency, textYear, textInterval, textAmount, textType, Session["userLog"].ToString(), timeStamp, Session["userLog"].ToString(), timeStamp))
                    {
                        loadalldata();
                        SetSuccesstMessage(4, "Data has been updated");
                    }
                }
                else
                {
                    if (_services.Create(textCountry, textCurrency, textYear, textInterval, textAmount, textType, Session["userLog"].ToString(), timeStamp, Session["userLog"].ToString(), timeStamp))
                    {
                        loadalldata();
                        SetSuccesstMessage(4, "Data has been saved");
                    }
                }

                exchangebrokenyearlyid.Value = "";
                country4.Value = "";
                currency4.Value = "";
                year4.Value = "";
                interval4.Value = "";
                amount4.Value = "";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}