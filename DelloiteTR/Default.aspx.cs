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
using System.IO;

namespace DelloiteTR
{
    public partial class _Default : System.Web.UI.Page
    {
        private TaxPlayerServices _services;
        private ecServices _ecservices;
        private comServices _comservices;
        private etServices _etservices;
        public string messagetext;
        int i = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            //string path = @"d:\test.txt";
            //string output = "";
            //using (StreamReader sr = File.OpenText(path))
            //{
            //    string s = String.Empty;
            //    while ((s = sr.ReadLine()) != null)
            //    {
            //        output += "model." + s + " = sqlDataReader[\"" + s + "\"].ToString();\n";
            //    }
            //}
            //string output = "";
            //for (int i = 1; i <= 73; i++)
            //{

            //    output += "calc_rounded_" + i + ".Value = data_calc_rounded_" + i + ".ToString();\n";
            //}
            //for (int i = 1; i <= 73; i++)
            //{
            //    output += "calc_not_" + i + ".Value = data_calc_rounded_" + i + ".ToString();\n";
            //}

            _services = ServicesFactory.CreateTaxPlayerServices(ConnectionString.Value);
            _ecservices = ServicesFactory.CreateECServices(ConnectionString.Value);
            _comservices = ServicesFactory.CreateCOMServices(ConnectionString.Value);
            _etservices = ServicesFactory.CreateETServices(ConnectionString.Value);
            if (!this.IsPostBack)
            {
                this.loadData();
            }
        }

        private void loadData()
        {
            try
            {
                errorBox.Visible = false;
                messagetext = "-";
                if (!string.IsNullOrEmpty(Session["userLog"] as string))
                {
                    string userlogon = Session["userLog"] as string;
                    List<vm.TaxPlayer> taxPlayers = _services.GetAllBy(userlogon);
                    messagetext = taxPlayers.Count().ToString();
                    string htmltext = "";
                    i = 1;

                    foreach (vm.TaxPlayer taxPlayer in taxPlayers)
                    {
                        messagetext = " - " + taxPlayer.ParticularId;
                        vm.ec ecdata = _ecservices.getData(taxPlayer.ParticularId);
                        vm.com comdata = _comservices.getData(ecdata.Company_Key);
                        List<vm.et> etdatas = _etservices.GetAllBy(ecdata.Company_Key, userlogon);
                        if (etdatas.Count()>0)
                        {
                            htmltext += "<tr><td>" + i + "</td>";
                            htmltext += "<td>" + taxPlayer.TaxRefNo + "</td>";
                            htmltext += "<td>" + taxPlayer.TaxPayerName + "</td>";
                            htmltext += "<td>" + comdata.COY_NAME_Key + "</td>";

                            htmltext += "<td><ul class=\"icons-list\"><li><a href='taxform.aspx?id=" + taxPlayer.TaxPayerNumber + "' ><i class=\"icon-eye\"></i> View</a></li></ul></td></tr>";

                            dataTable.Text = htmltext;
                            i++;
                        }
                    }
                    
                }
                //errorMsg.Text = messagetext;
            }
            catch (Exception ex)
            {
                errorBox.Visible = true;
                errorMsg.Text = ex.Message;
                //throw ex;
            }
        }
    }
}
