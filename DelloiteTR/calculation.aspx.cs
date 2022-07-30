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

using System.Web.UI.HtmlControls;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;
using System.IO;
using System.IO.Compression;
using System.Web.Script.Serialization;
using ss = Spire.Xls;
using sp = Spire.Pdf;

namespace DelloiteTR
{
    public partial class calculation : System.Web.UI.Page
    {
        private CalculationServices _services;
        System.Web.UI.ServiceReference svc = new System.Web.UI.ServiceReference();
        ServiceReference2.CalculationSoapClient client;
        ServiceReference2.TaxForm[] datas;
        private etServices _etservices;

        private string templatePath = HttpContext.Current.Server.MapPath("~/templates/");
        private string exportPath = "~/App_Data/";
        private string formType = "form1770";
        private double period = 12;
        private int reportCount = 19;
        string[] cols;

        private TaxFormServices _servicesTaxForm;
        private IEIncomeServices _servicesIncome;
        private FamilyServices _servicesFamily;
        private MaritalServices _servicesMarital;
        private AssetServices _servicesAsset;
        private OverseaIncomeServices _servicesOvIncome;
        private OverseaRentalServices _servicesOvRental;
        private OverseasCapitalServices _servicesOvCapital;
        private CalculationServices _servicesCalculation;
        private IrregularServices _servicesIrregular;

        private string thename = "";
        string[] files;
        string outputFile = "";
        string outputname = "";
        string outputFileexcel = "";
        string outputnameexcel = "";

        string debugtext = "";
        string sessionLog = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            hdid.Value = Request.QueryString["id"];
            _services = ServicesFactory.CreateCalculationServices(ConnectionString.Value);
            _etservices = ServicesFactory.CreateETServices(ConnectionString.Value);

            _servicesTaxForm = ServicesFactory.CreateTaxFormServices(ConnectionString.Value);
            _servicesIncome = ServicesFactory.CreateIEIncomeServices(ConnectionString.Value);
            _servicesFamily = ServicesFactory.CreateFamilyServices(ConnectionString.Value);
            _servicesMarital = ServicesFactory.CreateMaritalServices(ConnectionString.Value);
            _servicesAsset = ServicesFactory.CreateAssetServices(ConnectionString.Value);
            _servicesOvIncome = ServicesFactory.CreateOvIncomeServices(ConnectionString.Value);
            _servicesOvRental = ServicesFactory.CreateOvRentalServices(ConnectionString.Value);
            _servicesOvCapital = ServicesFactory.CreateOvCapitalServices(ConnectionString.Value);
            _servicesCalculation = ServicesFactory.CreateCalculationServices(ConnectionString.Value);
            _servicesIrregular = ServicesFactory.CreateIrregularServices(ConnectionString.Value);

            if (!this.IsPostBack)
            {
                SetMessage("");
                this.loadData();
            }
        }

        private void SetMessage(string message)
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

        private void loadData()
        {
            try
            {
                SetMessage("");
                hdid.Value = Request.QueryString["id"];
                sessionLog = Session["userLog"].ToString();

                string userlogon = Session["userLog"] as string;
                List<vm.et> etdatas = _etservices.CheckAdminCalculation(userlogon);

                if (Session["userRole"].ToString() == "1" || etdatas.Count()>0)
                {
                    SetEditable(true);
                }
                else if (Session["userRole"].ToString() == "2" || etdatas.Count() == 0)
                {
                    SetEditable(false);
                }

                //cek if exist load if no calculate
                client = new ServiceReference2.CalculationSoapClient();
                var datas = client.GetTaxFormByID(Convert.ToInt32(hdid.Value));
                
                List<vm.Calculation> calculations = _services.GetAllBy(datas[0].TaxPayerNumber, datas[0].type, datas[0].year, datas[0].ammend);
                int total = calculations.Count();
                total = 0;
                if (total == 0)
                {
                    //calculate
                        foreach(ServiceReference2.TaxForm data in datas){
                            hdtaxidnumber.Value = data.taxidnumber;
                            hdtaxyear.Value = data.year;

                            double netbusiness = 0;
                            if (data.t1s8f1 == "True")
                            {
                                double var_1a = 0;
                                double var_1b = 0;
                                double var_1c = 0;
                                double var_1d = 0;
                                double var_1e = 0;
                                if (!string.IsNullOrEmpty(data.t1s8f14))
                                {
                                    var_1a = Convert.ToDouble(data.t1s8f14);
                                }
                                if (!string.IsNullOrEmpty(data.t1s8f15))
                                {
                                    var_1b = Convert.ToDouble(data.t1s8f15);
                                }
                                if (!string.IsNullOrEmpty(data.t1s8f16))
                                {
                                    var_1d = Convert.ToDouble(data.t1s8f16);
                                }
                                var_1c = var_1a - var_1b;
                                var_1e = var_1c - var_1d;

                                double var_2a = 0;
                                double var_2b = 0;
                                double var_2c = 0;
                                double var_2d = 0;
                                double var_2e = 0;
                                double var_2f = 0;
                                double var_2g = 0;
                                double var_2h = 0;
                                double var_2i = 0;
                                double var_2j = 0;
                                double var_2k = 0;
                                double var_2l = 0;
                                if (!string.IsNullOrEmpty(data.t1s8f17))
                                {
                                    var_2a = Convert.ToDouble(data.t1s8f17);
                                }
                                if (!string.IsNullOrEmpty(data.t1s8f18))
                                {
                                    var_2b = Convert.ToDouble(data.t1s8f18);
                                }
                                if (!string.IsNullOrEmpty(data.t1s8f19))
                                {
                                    var_2c = Convert.ToDouble(data.t1s8f19);
                                }
                                if (!string.IsNullOrEmpty(data.t1s8f20))
                                {
                                    var_2d = Convert.ToDouble(data.t1s8f20);
                                }
                                if (!string.IsNullOrEmpty(data.t1s8f21))
                                {
                                    var_2e = Convert.ToDouble(data.t1s8f21);
                                }
                                if (!string.IsNullOrEmpty(data.t1s8f22))
                                {
                                    var_2f = Convert.ToDouble(data.t1s8f22);
                                }
                                if (!string.IsNullOrEmpty(data.t1s8f23))
                                {
                                    var_2g = Convert.ToDouble(data.t1s8f23);
                                }
                                if (!string.IsNullOrEmpty(data.t1s8f24))
                                {
                                    var_2h = Convert.ToDouble(data.t1s8f24);
                                }
                                if (!string.IsNullOrEmpty(data.t1s8f25))
                                {
                                    var_2i = Convert.ToDouble(data.t1s8f25);
                                }
                                if (!string.IsNullOrEmpty(data.t1s8f26))
                                {
                                    var_2j = Convert.ToDouble(data.t1s8f26);
                                }
                                if (!string.IsNullOrEmpty(data.t1s8f27))
                                {
                                    var_2k = Convert.ToDouble(data.t1s8f27);
                                }
                                var_2l = var_2a + var_2b + var_2c + var_2d + var_2e + var_2f + var_2g + var_2h + var_2i + var_2j + var_2k;

                                double var_3a = 0;
                                double var_3b = 0;
                                double var_3c = 0;
                                double var_3d = 0;
                                if (!string.IsNullOrEmpty(data.t1s8f28))
                                {
                                    var_3a = Convert.ToDouble(data.t1s8f28);
                                }
                                if (!string.IsNullOrEmpty(data.t1s8f29))
                                {
                                    var_3b = Convert.ToDouble(data.t1s8f29);
                                }
                                if (!string.IsNullOrEmpty(data.t1s8f30))
                                {
                                    var_3c = Convert.ToDouble(data.t1s8f30);
                                }
                                var_3d = var_3a + var_3b + var_3c;

                                netbusiness = (var_1e + var_2l) - var_3d;
                            }
                            else if (data.t1s8f32 == "True")
                            {
                                double l245 = 0;
                                double q245 = 0;
                                double l246 = 0;
                                double q246 = 0;
                                double l247 = 0;
                                double q247 = 0;
                                double l248 = 0;
                                double q248 = 0;
                                double l249 = 0;
                                double q249 = 0;

                                double val1 = 0;
                                double val2 = 0;
                                double val3 = 0;
                                double val4 = 0;
                                double val5 = 0;

                                if (!string.IsNullOrEmpty(data.t1s8f33))
                                {
                                    l245 = Convert.ToDouble(data.t1s8f33);
                                }
                                if (!string.IsNullOrEmpty(data.t1s8f34))
                                {
                                    q245 = Convert.ToDouble(data.t1s8f34) / 100;
                                }

                                if (!string.IsNullOrEmpty(data.t1s8f35))
                                {
                                    l246 = Convert.ToDouble(data.t1s8f35);
                                }
                                if (!string.IsNullOrEmpty(data.t1s8f36))
                                {
                                    q246 = Convert.ToDouble(data.t1s8f36) / 100;
                                }

                                if (!string.IsNullOrEmpty(data.t1s8f37))
                                {
                                    l247 = Convert.ToDouble(data.t1s8f37);
                                }
                                if (!string.IsNullOrEmpty(data.t1s8f38))
                                {
                                    q247 = Convert.ToDouble(data.t1s8f38) / 100;
                                }

                                if (!string.IsNullOrEmpty(data.t1s8f39))
                                {
                                    l248 = Convert.ToDouble(data.t1s8f39);
                                }
                                if (!string.IsNullOrEmpty(data.t1s8f40))
                                {
                                    q248 = Convert.ToDouble(data.t1s8f40) / 100;
                                }

                                if (!string.IsNullOrEmpty(data.t1s8f41))
                                {
                                    l249 = Convert.ToDouble(data.t1s8f41);
                                }
                                if (!string.IsNullOrEmpty(data.t1s8f42))
                                {
                                    q249 = Convert.ToDouble(data.t1s8f42) / 100;
                                }

                                val1 = l245 * q245;
                                val2 = l246 * q246;
                                val3 = l247 * q247;
                                val4 = l248 * q248;
                                val5 = l249 * q249;

                                netbusiness = val1 + val2 + val3 + val4 + val5;

                            }

                            double netincomeroundedyes = 0;
                            if (!string.IsNullOrEmpty(data.netincomeroundedyes))
                            {
                                netincomeroundedyes = Convert.ToDouble(data.netincomeroundedyes);
                            }
                            double netincomeroundednot = 0;
                            if (!string.IsNullOrEmpty(data.netincomeroundedyes))
                            {
                                netincomeroundednot = Convert.ToDouble(data.netincomeroundedyes);
                            }
                            double bonusroundedyes = 0;
                            if (!string.IsNullOrEmpty(data.bonusroundedyes))
                            {
                                bonusroundedyes = Convert.ToDouble(data.bonusroundedyes);
                            }
                            double bonusroundednot = 0;
                            if (!string.IsNullOrEmpty(data.bonusroundedyes))
                            {
                                bonusroundednot = Convert.ToDouble(data.bonusroundedyes);
                            }
                            double t1s6f21 = 0;
                            if (!string.IsNullOrEmpty(data.t1s6f21))
                            {
                                t1s6f21 = Convert.ToDouble(data.t1s6f21);
                            }
                            double lbltotalsummary1 = 0;
                            if (!string.IsNullOrEmpty(data.lbltotalsummary1))
                            {
                                lbltotalsummary1 = Convert.ToDouble(data.lbltotalsummary1);
                            }
                            double totalperiodroundedyes = 0;
                            if (!string.IsNullOrEmpty(data.totalperiodroundedyes))
                            {
                                totalperiodroundedyes = Convert.ToDouble(data.totalperiodroundedyes);
                            }
                            if (totalperiodroundedyes>12)
                            {
                                totalperiodroundedyes = 12;
                            }
                            double totalperiodroundednot = 0;
                            if (!string.IsNullOrEmpty(data.totalperiodroundedyes))
                            {
                                totalperiodroundednot = Convert.ToDouble(data.totalperiodroundedyes);
                            }
                            if (totalperiodroundednot > 12)
                            {
                                totalperiodroundednot = 12;
                            }
                            double t1s3f3 = 0;
                            if (!string.IsNullOrEmpty(data.t1s3f3))
                            {
                                t1s3f3 = Convert.ToDouble(data.t1s3f3);
                            }
                            double t1s6f24 = 0;
                            if (!string.IsNullOrEmpty(data.t1s6f24))
                            {
                                t1s6f24 = Convert.ToDouble(data.t1s6f24);
                            }
                            double tabirregulartotal1 = 0;
                            if (!string.IsNullOrEmpty(data.tabirregulartotal1))
                            {
                                tabirregulartotal1 = Convert.ToDouble(data.tabirregulartotal1);
                            }
                            double totalincometax = 0;
                            if (!string.IsNullOrEmpty(data.totalincometax))
                            {
                                totalincometax = Convert.ToDouble(data.totalincometax);
                            }
                            double lbltotalsummary2 = 0;
                            if (!string.IsNullOrEmpty(data.lbltotalsummary2))
                            {
                                lbltotalsummary2 = Convert.ToDouble(data.lbltotalsummary2);
                            }
                            double tabirregulartotal2 = 0;
                            if (!string.IsNullOrEmpty(data.tabirregulartotal2))
                            {
                                tabirregulartotal2 = Convert.ToDouble(data.tabirregulartotal2);
                            }
                            double t1s6f25 = 0;
                            if (!string.IsNullOrEmpty(data.t1s6f25))
                            {
                                t1s6f25 = Convert.ToDouble(data.t1s6f25);
                            }
                            
                            double data_calc_rounded_1 = netincomeroundedyes - bonusroundedyes;
                            if (double.IsNaN(data_calc_rounded_1))
                            {
                                data_calc_rounded_1 = 0;
                            }

                            double data_calc_rounded_2 = bonusroundedyes;
                            if (double.IsNaN(data_calc_rounded_2))
                            {
                                data_calc_rounded_2 = 0;
                            }
                            double data_calc_rounded_3 = data_calc_rounded_1 + data_calc_rounded_2;
                            if (double.IsNaN(data_calc_rounded_3))
                            {
                                data_calc_rounded_3 = 0;
                            }
                            double data_calc_rounded_4 = t1s6f21;

                            if (double.IsNaN(data_calc_rounded_4))
                            {
                                data_calc_rounded_4 = 0;
                            }
                            double data_calc_rounded_5 = lbltotalsummary1;
                            if (data_calc_rounded_5 < 0)
                            {
                                data_calc_rounded_5 = 0;
                            }
                            if (double.IsNaN(data_calc_rounded_5))
                            {
                                data_calc_rounded_5 = 0;
                            }

                            double data_calc_rounded_6 = data_calc_rounded_3 + data_calc_rounded_4 + data_calc_rounded_5 + netbusiness;
                            if (double.IsNaN(data_calc_rounded_6))
                            {
                                data_calc_rounded_6 = 0;
                            }
                            double annualizenetbusiness = 0;
                            if (netbusiness>0)
                            {
                                annualizenetbusiness = (netbusiness / totalperiodroundedyes) * 12;
                            }
                            double data_calc_rounded_7 = (data_calc_rounded_1 / totalperiodroundedyes) * 12;
                            if (double.IsNaN(data_calc_rounded_7))
                            {
                                data_calc_rounded_7 = 0;
                            }
                            double data_calc_rounded_8 = (data_calc_rounded_2 / totalperiodroundedyes) * 12;
                            if (double.IsNaN(data_calc_rounded_8))
                            {
                                data_calc_rounded_8 = 0;
                            }
                            double data_calc_rounded_9 = data_calc_rounded_7 + data_calc_rounded_8;
                            if (double.IsNaN(data_calc_rounded_9))
                            {
                                data_calc_rounded_9 = 0;
                            }
                            double data_calc_rounded_10 = (data_calc_rounded_4 / totalperiodroundedyes) * 12;
                            if (double.IsNaN(data_calc_rounded_10))
                            {
                                data_calc_rounded_10 = 0;
                            }
                            double data_calc_rounded_11 = (data_calc_rounded_5 / totalperiodroundedyes) * 12;
                            if (double.IsNaN(data_calc_rounded_11))
                            {
                                data_calc_rounded_11 = 0;
                            }
                            double data_calc_rounded_12 = data_calc_rounded_9 + data_calc_rounded_10 + data_calc_rounded_11 + annualizenetbusiness;
                            if (double.IsNaN(data_calc_rounded_12))
                            {
                                data_calc_rounded_12 = 0;
                            }
                            double data_calc_rounded_13 = 0;
                            if (data_calc_rounded_7 > 0)
                            {
                                data_calc_rounded_13 = Convert.ToDouble(data_calc_rounded_7) - t1s3f3;
                            }
                            if (double.IsNaN(data_calc_rounded_13))
                            {
                                data_calc_rounded_13 = 0;
                            }
                            double data_calc_rounded_14 = data_calc_rounded_8;
                            if (double.IsNaN(data_calc_rounded_14))
                            {
                                data_calc_rounded_14 = 0;
                            }
                            double data_calc_rounded_15 = 0;
                            if (data_calc_rounded_9 > 0)
                            {
                                data_calc_rounded_15 = Convert.ToDouble(data_calc_rounded_9) - t1s3f3;
                            }
                            if (double.IsNaN(data_calc_rounded_15))
                            {
                                data_calc_rounded_15 = 0;
                            }
                            double data_calc_rounded_16 = t1s3f3;
                            if (double.IsNaN(data_calc_rounded_16))
                            {
                                data_calc_rounded_16 = 0;
                            }
                            double data_calc_rounded_18 = data_calc_rounded_7 - t1s3f3;
                            if (double.IsNaN(data_calc_rounded_18))
                            {
                                data_calc_rounded_18 = 0;
                            }
                            double data_calc_rounded_19 = data_calc_rounded_8;
                            if (double.IsNaN(data_calc_rounded_19))
                            {
                                data_calc_rounded_19 = 0;
                            }
                            double data_calc_rounded_20 = data_calc_rounded_18 + data_calc_rounded_19;
                            if (double.IsNaN(data_calc_rounded_20))
                            {
                                data_calc_rounded_20 = 0;
                            }
                            double data_calc_rounded_21 = data_calc_rounded_10;
                            if (double.IsNaN(data_calc_rounded_21))
                            {
                                data_calc_rounded_21 = 0;
                            }
                            double data_calc_rounded_22 = data_calc_rounded_11;
                            if (double.IsNaN(data_calc_rounded_22))
                            {
                                data_calc_rounded_22 = 0;
                            }
                            double data_calc_rounded_23 = data_calc_rounded_20 + data_calc_rounded_21 + data_calc_rounded_22 + annualizenetbusiness;
                            if (double.IsNaN(data_calc_rounded_23))
                            {
                                data_calc_rounded_23 = 0;
                            }
                            double data_calc_rounded_24 = 0;
                            if (data_calc_rounded_23 > 0)
                            {
                                data_calc_rounded_24 = Convert.ToDouble(data_calc_rounded_23);
                                data_calc_rounded_24 = Math.Floor(data_calc_rounded_24 / 1000) * 1000;
                            }
                            if (double.IsNaN(data_calc_rounded_24))
                            {
                                data_calc_rounded_24 = 0;
                            }
                            double data_calc_rounded_17 = 0;
                            if (data_calc_rounded_23 > 0)
                            {
                                data_calc_rounded_17 = data_calc_rounded_23;
                            }
                            if (double.IsNaN(data_calc_rounded_17))
                            {
                                data_calc_rounded_17 = 0;
                            }
                            double data_calc_rounded_25 = 0;
                            if (data_calc_rounded_18 <= 0)
                            {
                                data_calc_rounded_25 = 0;
                            }
                            else if (data_calc_rounded_18 > 0 && data_calc_rounded_18 <= 50000000)
                            {
                                data_calc_rounded_25 = (0.05 * data_calc_rounded_13);
                            }
                            else if (data_calc_rounded_18 > 50000000 && data_calc_rounded_18 <= 250000000)
                            {
                                data_calc_rounded_25 = 0.15 * data_calc_rounded_13 - 5000000;
                            }
                            else if (data_calc_rounded_18 > 250000000 && data_calc_rounded_18 <= 500000000)
                            {
                                data_calc_rounded_25 = 0.25 * data_calc_rounded_13 - 55000000;
                            }
                            else
                            {
                                data_calc_rounded_25 = 0.3 * data_calc_rounded_13 - 55000000;
                            }
                            if (data_calc_rounded_13 <= 0)
                            {
                                data_calc_rounded_25 = 0;
                            }
                            else if (data_calc_rounded_13 > 0 && data_calc_rounded_13 <= 50000000)
                            {
                                data_calc_rounded_25 = (0.05 * data_calc_rounded_13);
                            }
                            else if (data_calc_rounded_13 > 50000000 && data_calc_rounded_13 <= 250000000)
                            {
                                data_calc_rounded_25 = 0.15 * data_calc_rounded_13 - 5000000;
                            }
                            else if (data_calc_rounded_13 > 250000000 && data_calc_rounded_13 <= 500000000)
                            {
                                data_calc_rounded_25 = 0.25 * data_calc_rounded_13 - 55000000;
                            }
                            else
                            {
                                data_calc_rounded_25 = 0.3 * data_calc_rounded_13 - 55000000;
                            }

                            if (double.IsNaN(data_calc_rounded_25))
                            {
                                data_calc_rounded_25 = 0;
                            }
                            double data_calc_rounded_27 = 0;
                            if (data_calc_rounded_15 <= 0)
                            {
                                data_calc_rounded_27 = 0;
                            }
                            else if (data_calc_rounded_15 > 0 && data_calc_rounded_15 <= 50000000)
                            {
                                data_calc_rounded_27 = (0.05 * data_calc_rounded_15);
                            }
                            else if (data_calc_rounded_15 > 50000000 && data_calc_rounded_15 <= 250000000)
                            {
                                data_calc_rounded_27 = 0.15 * data_calc_rounded_15 - 5000000;
                            }
                            else if (data_calc_rounded_15 > 250000000 && data_calc_rounded_15 <= 500000000)
                            {
                                data_calc_rounded_27 = 0.25 * data_calc_rounded_15 - 55000000;
                            }
                            else
                            {
                                data_calc_rounded_27 = 0.3 * data_calc_rounded_15 - 55000000;
                            }
                            if (double.IsNaN(data_calc_rounded_27))
                            {
                                data_calc_rounded_27 = 0;
                            }
                            double data_calc_rounded_26 = data_calc_rounded_27 - data_calc_rounded_25;
                            if (double.IsNaN(data_calc_rounded_26))
                            {
                                data_calc_rounded_26 = 0;
                            }

                            double data_calc_rounded_29 = 0;
                            if (data_calc_rounded_24 <= 0)
                            {
                                data_calc_rounded_29 = 0;
                            }
                            else if (data_calc_rounded_24 > 0 && data_calc_rounded_24 <= 50000000)
                            {
                                data_calc_rounded_29 = (0.05 * data_calc_rounded_24);
                            }
                            else if (data_calc_rounded_24 > 50000000 && data_calc_rounded_24 <= 250000000)
                            {
                                data_calc_rounded_29 = 0.15 * data_calc_rounded_24 - 5000000;
                            }
                            else if (data_calc_rounded_24 > 250000000 && data_calc_rounded_24 <= 500000000)
                            {
                                data_calc_rounded_29 = 0.25 * data_calc_rounded_24 - 55000000;
                            }
                            else
                            {
                                data_calc_rounded_29 = 0.3 * data_calc_rounded_24 - 55000000;
                            }

                            if (double.IsNaN(data_calc_rounded_29))
                            {
                                data_calc_rounded_29 = 0;
                            }
                            double data_calc_rounded_28 = data_calc_rounded_29 - data_calc_rounded_27;
                            double data_calc_rounded_30 = (data_calc_rounded_25 / 12) * totalperiodroundedyes;
                            double data_calc_rounded_31 = (data_calc_rounded_26 / 12) * totalperiodroundedyes;
                            double data_calc_rounded_32 = data_calc_rounded_30 + data_calc_rounded_31;
                            double data_calc_rounded_33 = (data_calc_rounded_28 / 12) * totalperiodroundedyes;
                            double data_calc_rounded_34 = data_calc_rounded_32 + data_calc_rounded_33;

                            double data_calc_rounded_35 = 0;
                            double data_calc_rounded_36 = 0;
                            double data_calc_rounded_38 = 0;
                            double data_calc_rounded_39 = 0;
                            double data_calc_rounded_41 = 0;
                            double data_calc_rounded_42 = 0;
                            double data_calc_rounded_45 = 0;
                            double data_calc_rounded_47 = 0;
                            double data_calc_rounded_37 = 0;
                            double t1s2f1minyearend = 0;
                            if(!string.IsNullOrEmpty(data.t1s2f1) && !string.IsNullOrEmpty(data.year)){
                                string year = data.t1s2f1.Split('/')[2];
                                if (year.Length == 4)
                                {
                                    year = year.Substring(2, 2);
                                }
                                string t1s2f1 = data.t1s2f1.Split('/')[1] + "/" + data.t1s2f1.Split('/')[0] + "/" + year;
                                t1s2f1minyearend = (Convert.ToDateTime(t1s2f1) - Convert.ToDateTime("12/31/" + data.year)).TotalDays;
                            }

                            if (string.IsNullOrEmpty(data.t1s2f1) || t1s2f1minyearend>0)
                            {
                                data_calc_rounded_35 = data_calc_rounded_7;
                                data_calc_rounded_36 = data_calc_rounded_8;
                                data_calc_rounded_38 = data_calc_rounded_10;
                                data_calc_rounded_39 = t1s6f24 / 12 * totalperiodroundedyes;
                                data_calc_rounded_41 = data_calc_rounded_11;
                                data_calc_rounded_42 = tabirregulartotal1 / totalperiodroundedyes * 12;
                                data_calc_rounded_42 = data_calc_rounded_42 * -1;
                                data_calc_rounded_45 = (Math.Floor(Convert.ToDouble(data_calc_rounded_35)/1000) *1000) - t1s3f3;
                                data_calc_rounded_37 = data_calc_rounded_35 + data_calc_rounded_36;
                                data_calc_rounded_47 = (Math.Floor(Convert.ToDouble(data_calc_rounded_37) / 1000) * 1000) - t1s3f3;
                            }
                            
                            data_calc_rounded_37 = data_calc_rounded_35 + data_calc_rounded_36;
                            double data_calc_rounded_40 = data_calc_rounded_38 + data_calc_rounded_39;
                            
                            if (double.IsNaN(data_calc_rounded_42))
                            {
                                data_calc_rounded_42 = 0;
                            }
                            double data_calc_rounded_43 = data_calc_rounded_41 + data_calc_rounded_42;
                            double data_calc_rounded_44 = 0;
                            if (data_calc_rounded_43 > 0)
                            {
                                data_calc_rounded_44 = data_calc_rounded_37 + data_calc_rounded_40 + data_calc_rounded_43;
                            }
                            else
                            {
                                data_calc_rounded_44 = netbusiness + data_calc_rounded_37 + data_calc_rounded_40;
                            }

                            
                            double data_calc_rounded_46 = data_calc_rounded_36;
                            double data_calc_rounded_48 = t1s3f3;
                            double data_calc_rounded_49 = 0;
                            double data_calc_rounded_50 = Convert.ToDouble(data_calc_rounded_35) - t1s3f3;
                            double data_calc_rounded_51 = data_calc_rounded_36;
                            double data_calc_rounded_52 = data_calc_rounded_50 + data_calc_rounded_51;
                            double data_calc_rounded_53 = data_calc_rounded_40;
                            double data_calc_rounded_54 = data_calc_rounded_43;
                            double data_calc_rounded_55 = data_calc_rounded_52 + data_calc_rounded_53 + data_calc_rounded_54 + netbusiness;
                            double data_calc_rounded_56 = 0;
                            if (data_calc_rounded_55 > 0)
                            {
                                data_calc_rounded_56 = Math.Floor(Convert.ToDouble(data_calc_rounded_55) /1000)*1000;
                            }

                            if (data_calc_rounded_55 > 0)
                            {
                                data_calc_rounded_49 = data_calc_rounded_55;
                            }

                            double af86 = 0;
                            if (data_calc_rounded_45 <= 0)
                            {
                                af86 = 0;
                            }
                            else if (data_calc_rounded_45 > 0 && data_calc_rounded_45 <= 50000000)
                            {
                                af86 = (0.05 * data_calc_rounded_45);
                            }
                            else if (data_calc_rounded_45 > 50000000 && data_calc_rounded_45 <= 250000000)
                            {
                                af86 = 0.15 * data_calc_rounded_45 - 5000000;
                            }
                            else if (data_calc_rounded_45 > 250000000 && data_calc_rounded_45 <= 500000000)
                            {
                                af86 = 0.25 * data_calc_rounded_45 - 30000000;
                            }
                            else
                            {
                                af86 = 0.3 * data_calc_rounded_45 - 55000000;
                            }

                            double af87 = 0;
                            double af88 = 0;
                            if (string.IsNullOrEmpty(data.t1s2f1) || t1s2f1minyearend > 0)
                            {
                                if (data_calc_rounded_47 <= 0)
                                {
                                    af87 = 0;
                                }
                                else if (data_calc_rounded_47 > 0 && data_calc_rounded_47 <= 50000000)
                                {
                                    af87 = (0.05 * data_calc_rounded_47);
                                }
                                else if (data_calc_rounded_47 > 50000000 && data_calc_rounded_47 <= 250000000)
                                {
                                    af87 = 0.15 * data_calc_rounded_47 - 5000000;
                                }
                                else if (data_calc_rounded_47 > 250000000 && data_calc_rounded_47 <= 500000000)
                                {
                                    af87 = 0.25 * data_calc_rounded_47 - 30000000;
                                }
                                else
                                {
                                    af87 = 0.3 * data_calc_rounded_47 - 55000000;
                                }

                                if (data_calc_rounded_56 <= 0)
                                {
                                    af88 = 0;
                                }
                                else if (data_calc_rounded_56 > 0 && data_calc_rounded_56 <= 50000000)
                                {
                                    af88 = (0.05 * data_calc_rounded_56);
                                }
                                else if (data_calc_rounded_56 > 50000000 && data_calc_rounded_56 <= 250000000)
                                {
                                    af88 = 0.15 * data_calc_rounded_56 - 5000000;
                                }
                                else if (data_calc_rounded_56 > 250000000 && data_calc_rounded_56 <= 500000000)
                                {
                                    af88 = 0.25 * data_calc_rounded_56 - 30000000;
                                }
                                else
                                {
                                    af88 = 0.3 * data_calc_rounded_56 - 55000000;
                                }
                            }

                            double data_calc_rounded_57 = af86;
                            double data_calc_rounded_59 = af87;
                            double data_calc_rounded_58 = data_calc_rounded_59 - data_calc_rounded_57;
                            double data_calc_rounded_61 = af88;
                            double data_calc_rounded_60 = data_calc_rounded_61 - data_calc_rounded_59;

                            double data_calc_rounded_62 = data_calc_rounded_57 / 12 * totalperiodroundedyes;
                            double data_calc_rounded_63 = data_calc_rounded_58 / totalperiodroundedyes * 12;
                            double data_calc_rounded_64 = data_calc_rounded_62 + data_calc_rounded_63;
                            double data_calc_rounded_65 = data_calc_rounded_60 / 12 * totalperiodroundedyes;

                            double data_calc_rounded_66 = data_calc_rounded_64 + data_calc_rounded_65;

                            double data_calc_rounded_67 = 0;
                            double data_calc_rounded_68 = 0;
                            double data_calc_rounded_69 = 0;
                            double art29 = 0;
                            if (string.IsNullOrEmpty(data.t1s2f1) || t1s2f1minyearend > 0)
                            {
                                data_calc_rounded_67 = totalincometax;
                                data_calc_rounded_68 = lbltotalsummary2;
                                data_calc_rounded_69 = (tabirregulartotal2 - t1s6f25) * -1;
                                if (!string.IsNullOrEmpty(data.irregulartaxcredit))
                                {
                                    art29 = Convert.ToDouble(data.irregulartaxcredit);
                                }
                            }
                           
                            double data_calc_rounded_70 = data_calc_rounded_67 + data_calc_rounded_68 + data_calc_rounded_69;
                            
                            double data_calc_rounded_71 = data_calc_rounded_66 - data_calc_rounded_70 - art29;
                            double data_calc_rounded_72 = 12;
                            if (totalperiodroundedyes < 12)
                            {
                                data_calc_rounded_72 = totalperiodroundedyes;
                            }
                            double data_calc_rounded_73 = data_calc_rounded_71 / data_calc_rounded_72;
                            if (double.IsNaN(data_calc_rounded_73))
                            {
                                data_calc_rounded_73 = 0;
                            }

                            double data_calc_not_1 = netincomeroundednot - bonusroundednot;
                            double data_calc_not_2 = bonusroundednot;
                            double data_calc_not_3 = data_calc_not_1 + data_calc_not_2;
                            double data_calc_not_4 = t1s6f21;

                            double data_calc_not_5 = lbltotalsummary1;
                            if (data_calc_not_5 < 0)
                            {
                                data_calc_not_5 = 0;
                            }

                            double data_calc_not_6 = data_calc_not_3 + data_calc_not_4 + data_calc_not_5 + netbusiness;
                            double data_calc_not_7 = (data_calc_not_1 / totalperiodroundednot) * 12;
                            double data_calc_not_8 = (data_calc_not_2 / totalperiodroundednot) * 12;
                            double data_calc_not_9 = data_calc_not_7 + data_calc_not_8;
                            double data_calc_not_10 = (data_calc_not_4 / totalperiodroundednot) * 12;
                            double data_calc_not_11 = (data_calc_not_5 / totalperiodroundednot) * 12;
                            double data_calc_not_12 = data_calc_not_9 + data_calc_not_10 + data_calc_not_11 + annualizenetbusiness;
                            double data_calc_not_13 = 0;
                            if (data_calc_not_7 > 0)
                            {
                                data_calc_not_13 = Convert.ToDouble(data_calc_not_7) - t1s3f3;
                            }
                            double data_calc_not_14 = data_calc_not_8;
                            double data_calc_not_15 = 0;
                            if (data_calc_not_9 > 0)
                            {
                                data_calc_not_15 = Convert.ToDouble(data_calc_not_9) - t1s3f3;
                            }
                            double data_calc_not_16 = t1s3f3;
                            double data_calc_not_18 = data_calc_not_7 - t1s3f3;
                            double data_calc_not_19 = data_calc_not_8;
                            double data_calc_not_20 = data_calc_not_18 + data_calc_not_19;
                            double data_calc_not_21 = data_calc_not_10;
                            double data_calc_not_22 = data_calc_not_11;
                            double data_calc_not_23 = data_calc_not_20 + data_calc_not_21 + data_calc_not_22 + annualizenetbusiness;
                            double data_calc_not_24 = 0;
                            if (data_calc_not_23 > 0)
                            {
                                data_calc_not_24 = Convert.ToDouble(data_calc_not_23);
                                data_calc_not_24 = Math.Floor(data_calc_not_24 /1000) * 1000;
                            }
                            double data_calc_not_17 = 0;
                            if (data_calc_not_23 > 0)
                            {
                                data_calc_not_17 = data_calc_not_23;
                            }
                            double data_calc_not_25 = 0;
                            if (data_calc_not_18 <= 0)
                            {
                                data_calc_not_25 = 0;
                            }
                            else if (data_calc_not_18 > 0 && data_calc_not_18 <= 50000000)
                            {
                                data_calc_not_25 = (0.05 * data_calc_not_13);
                            }
                            else if (data_calc_not_18 > 50000000 && data_calc_not_18 <= 250000000)
                            {
                                data_calc_not_25 = 0.15 * data_calc_not_13 - 5000000;
                            }
                            else if (data_calc_not_18 > 250000000 && data_calc_not_18 <= 500000000)
                            {
                                data_calc_not_25 = 0.25 * data_calc_not_13 - 55000000;
                            }
                            else
                            {
                                data_calc_not_25 = 0.3 * data_calc_not_13 - 55000000;
                            }
                            //double data_calc_not_25 = 0;
                            if (data_calc_not_13 <= 0)
                            {
                                data_calc_not_25 = 0;
                            }
                            else if (data_calc_not_13 > 0 && data_calc_not_13 <= 50000000)
                            {
                                data_calc_not_25 = (0.05 * data_calc_not_13);
                            }
                            else if (data_calc_not_13 > 50000000 && data_calc_not_13 <= 250000000)
                            {
                                data_calc_not_25 = 0.15 * data_calc_not_13 - 5000000;
                            }
                            else if (data_calc_not_13 > 250000000 && data_calc_not_13 <= 500000000)
                            {
                                data_calc_not_25 = 0.25 * data_calc_not_13 - 55000000;
                            }
                            else
                            {
                                data_calc_not_25 = 0.3 * data_calc_not_13 - 55000000;
                            }
                            double data_calc_not_27 = 0;
                            if (data_calc_not_15 <= 0)
                            {
                                data_calc_not_27 = 0;
                            }
                            else if (data_calc_not_15 > 0 && data_calc_not_15 <= 50000000)
                            {
                                data_calc_not_27 = (0.05 * data_calc_not_15);
                            }
                            else if (data_calc_not_15 > 50000000 && data_calc_not_15 <= 250000000)
                            {
                                data_calc_not_27 = 0.15 * data_calc_not_15 - 5000000;
                            }
                            else if (data_calc_not_15 > 250000000 && data_calc_not_15 <= 500000000)
                            {
                                data_calc_not_27 = 0.25 * data_calc_not_15 - 55000000;
                            }
                            else
                            {
                                data_calc_not_27 = 0.3 * data_calc_not_15 - 55000000;
                            }
                            double data_calc_not_26 = data_calc_not_27 - data_calc_not_25;

                            double data_calc_not_29 = 0;
                            if (data_calc_not_24 <= 0)
                            {
                                data_calc_not_29 = 0;
                            }
                            else if (data_calc_not_24 > 0 && data_calc_not_24 <= 50000000)
                            {
                                data_calc_not_29 = (0.05 * data_calc_not_24);
                            }
                            else if (data_calc_not_24 > 50000000 && data_calc_not_24 <= 250000000)
                            {
                                data_calc_not_29 = 0.15 * data_calc_not_24 - 5000000;
                            }
                            else if (data_calc_not_24 > 250000000 && data_calc_not_24 <= 500000000)
                            {
                                data_calc_not_29 = 0.25 * data_calc_not_24 - 55000000;
                            }
                            else
                            {
                                data_calc_not_29 = 0.3 * data_calc_not_24 - 55000000;
                            }
                            double data_calc_not_28 = data_calc_not_29 - data_calc_not_27;
                            double data_calc_not_30 = (data_calc_not_25 / 12) * totalperiodroundednot;
                            double data_calc_not_31 = (data_calc_not_26 / 12) * totalperiodroundednot;
                            double data_calc_not_32 = data_calc_not_30 + data_calc_not_31;
                            double data_calc_not_33 = (data_calc_not_28 / 12) * totalperiodroundednot;
                            double data_calc_not_34 = data_calc_not_32 + data_calc_not_33;

                            double data_calc_not_35 = 0;
                            double data_calc_not_36 = 0;
                            double data_calc_not_38 = 0;
                            double data_calc_not_39 = 0;
                            double data_calc_not_41 = 0;
                            double data_calc_not_42 = 0;
                            double data_calc_not_45 = 0;
                            double data_calc_not_47 = 0;
                            double data_calc_not_37 = 0;
                            double netbusiness2 = 0;
                            if (string.IsNullOrEmpty(data.t1s2f1) || t1s2f1minyearend > 0)
                            {
                                netbusiness2 = netbusiness;
                                data_calc_not_35 = data_calc_not_7;
                                data_calc_not_36 = data_calc_not_8;
                                data_calc_not_38 = data_calc_not_10;
                                data_calc_not_39 = t1s6f24 / 12 * totalperiodroundedyes;
                                data_calc_not_41 = data_calc_not_11;
                                data_calc_not_42 = tabirregulartotal1 / totalperiodroundedyes * 12;
                                data_calc_not_42 = data_calc_not_42 * -1;
                                data_calc_not_45 = (Math.Floor(Convert.ToDouble(data_calc_not_35) / 1000) * 1000) - t1s3f3;
                                data_calc_not_37 = data_calc_rounded_35 + data_calc_rounded_36;
                                data_calc_not_47 = (Math.Floor(Convert.ToDouble(data_calc_not_37) / 1000) * 1000) - t1s3f3;
                            }

                            data_calc_not_37 = data_calc_not_35 + data_calc_not_36;
                            double data_calc_not_40 = data_calc_not_38 + data_calc_not_39;

                            if (double.IsNaN(data_calc_not_42))
                            {
                                data_calc_not_42 = 0;
                            }
                            double data_calc_not_43 = data_calc_not_41 + data_calc_not_42;
                            double data_calc_not_44 = 0;
                            if (data_calc_not_43 > 0)
                            {
                                data_calc_not_44 = data_calc_not_37 + data_calc_not_40 + data_calc_not_43;
                            }
                            else
                            {
                                data_calc_not_44 = netbusiness2 + data_calc_not_37 + data_calc_not_40;
                            }


                            double data_calc_not_46 = data_calc_not_36;
                            double data_calc_not_48 = t1s3f3;
                            double data_calc_not_49 = 0;
                            double data_calc_not_50 = Convert.ToDouble(data_calc_not_35) - t1s3f3;
                            double data_calc_not_51 = data_calc_not_36;
                            double data_calc_not_52 = data_calc_not_50 + data_calc_not_51;
                            double data_calc_not_53 = data_calc_not_40;
                            double data_calc_not_54 = data_calc_not_43;
                            double data_calc_not_55 = data_calc_not_52 + data_calc_not_53 + data_calc_not_54 + netbusiness2;
                            double data_calc_not_56 = 0;
                            if (data_calc_not_55 > 0)
                            {
                                data_calc_not_56 = Math.Floor(Convert.ToDouble(data_calc_not_55) / 1000) * 1000;
                            }

                            if (data_calc_not_55 > 0)
                            {
                                data_calc_not_49 = data_calc_not_55;
                            }

                            af86 = 0;
                            if (data_calc_not_45 <= 0)
                            {
                                af86 = 0;
                            }
                            else if (data_calc_not_45 > 0 && data_calc_not_45 <= 50000000)
                            {
                                af86 = (0.05 * data_calc_not_45);
                            }
                            else if (data_calc_not_45 > 50000000 && data_calc_not_45 <= 250000000)
                            {
                                af86 = 0.15 * data_calc_not_45 - 5000000;
                            }
                            else if (data_calc_not_45 > 250000000 && data_calc_not_45 <= 500000000)
                            {
                                af86 = 0.25 * data_calc_not_45 - 30000000;
                            }
                            else
                            {
                                af86 = 0.3 * data_calc_not_45 - 55000000;
                            }

                            af87 = 0;
                            af88 = 0;
                            if (string.IsNullOrEmpty(data.t1s2f1) || t1s2f1minyearend > 0)
                            {
                                if (data_calc_not_47 <= 0)
                                {
                                    af87 = 0;
                                }
                                else if (data_calc_not_47 > 0 && data_calc_not_47 <= 50000000)
                                {
                                    af87 = (0.05 * data_calc_not_47);
                                }
                                else if (data_calc_not_47 > 50000000 && data_calc_not_47 <= 250000000)
                                {
                                    af87 = 0.15 * data_calc_not_47 - 5000000;
                                }
                                else if (data_calc_not_47 > 250000000 && data_calc_not_47 <= 500000000)
                                {
                                    af87 = 0.25 * data_calc_not_47 - 30000000;
                                }
                                else
                                {
                                    af87 = 0.3 * data_calc_not_47 - 55000000;
                                }

                                if (data_calc_not_56 <= 0)
                                {
                                    af88 = 0;
                                }
                                else if (data_calc_not_56 > 0 && data_calc_not_56 <= 50000000)
                                {
                                    af88 = (0.05 * data_calc_not_56);
                                }
                                else if (data_calc_not_56 > 50000000 && data_calc_not_56 <= 250000000)
                                {
                                    af88 = 0.15 * data_calc_not_56 - 5000000;
                                }
                                else if (data_calc_not_56 > 250000000 && data_calc_not_56 <= 500000000)
                                {
                                    af88 = 0.25 * data_calc_not_56 - 30000000;
                                }
                                else
                                {
                                    af88 = 0.3 * data_calc_not_56 - 55000000;
                                }
                            }

                            double data_calc_not_57 = af86;
                            double data_calc_not_59 = af87;
                            double data_calc_not_58 = data_calc_not_59 - data_calc_not_57;
                            double data_calc_not_61 = af88;
                            double data_calc_not_60 = data_calc_not_61 - data_calc_not_59;

                            double data_calc_not_62 = data_calc_not_57 / 12 * totalperiodroundedyes;
                            double data_calc_not_63 = data_calc_not_58 / totalperiodroundedyes * 12;
                            double data_calc_not_64 = data_calc_not_62 + data_calc_not_63;
                            double data_calc_not_65 = data_calc_not_60 / 12 * totalperiodroundedyes;

                            double data_calc_not_66 = data_calc_not_64 + data_calc_not_65;

                            double data_calc_not_67 = 0;
                            double data_calc_not_68 = 0;
                            double data_calc_not_69 = 0;
                            art29 = 0;
                            if (string.IsNullOrEmpty(data.t1s2f1) || t1s2f1minyearend > 0)
                            {
                                data_calc_not_67 = totalincometax;
                                data_calc_not_68 = lbltotalsummary2;
                                data_calc_not_69 = (tabirregulartotal2 - t1s6f25) * -1;
                                if (!string.IsNullOrEmpty(data.irregulartaxcredit))
                                {
                                    art29 = Convert.ToDouble(data.irregulartaxcredit);
                                }
                            }

                            double data_calc_not_70 = data_calc_not_67 + data_calc_not_68 + data_calc_not_69;

                            double data_calc_not_71 = data_calc_not_66 - data_calc_not_70 - art29;
                            double data_calc_not_72 = 12;
                            if (totalperiodroundedyes < 12)
                            {
                                data_calc_not_72 = totalperiodroundedyes;
                            }
                            double data_calc_not_73 = data_calc_not_71 / data_calc_not_72;
                            if (double.IsNaN(data_calc_not_73))
                            {
                                data_calc_not_73 = 0;
                            }

                            var data_calc_not_b9 = 0;
                            
                            if (data.t1s3f1.ToUpper() == "MARRIED1")
                            {
                                var t1s3f2 = 0;
                                if (data.t1s3f2 != "")
                                {
                                    t1s3f2 = Convert.ToInt32(t1s3f2);
                                }
                                data_calc_not_b9 = 17160000 + (t1s3f2 * 1320000);
                            }
                            else if (data.t1s3f1.ToUpper() == "MARRIED2")
                            {
                                var t1s3f2 = 0;
                                if (data.t1s3f2 != "")
                                {
                                    t1s3f2 = Convert.ToInt32(t1s3f2);
                                }
                                data_calc_not_b9 = 31680000 + (t1s3f2 * 1320000);
                            }
                            else
                            {
                                var t1s3f2 = 0;
                                if (data.t1s3f2!="")
                                {
                                    t1s3f2 = Convert.ToInt32(t1s3f2);
                                }
                                data_calc_not_b9 = 15840000 + (t1s3f2 * 1320000);
                            }

                            calc_rounded_b1.Value = String.Format("{0:#,##0}", netbusiness);
                            calc_rounded_b2.Value = String.Format("{0:#,##0}", 0);
                            calc_rounded_b3.Value = String.Format("{0:#,##0}", netbusiness);
                            calc_rounded_b4.Value = String.Format("{0:#,##0}", netbusiness);
                            calc_rounded_b5.Value = String.Format("{0:#,##0}", art29);
                            calc_rounded_b6.Value = String.Format("{0:#,##0}", data_calc_rounded_57);
                            calc_rounded_b7.Value = String.Format("{0:#,##0}", data_calc_rounded_59);
                            calc_rounded_b8.Value = String.Format("{0:#,##0}", data_calc_rounded_61);

                            calc_not_b1.Value = String.Format("{0:#,##0}", netbusiness);
                            calc_not_b2.Value = String.Format("{0:#,##0}", 0);
                            calc_not_b3.Value = String.Format("{0:#,##0}", netbusiness);
                            calc_not_b4.Value = String.Format("{0:#,##0}", netbusiness);
                            calc_not_b5.Value = String.Format("{0:#,##0}", art29);
                            calc_not_b6.Value = String.Format("{0:#,##0}", data_calc_not_57);
                            calc_not_b7.Value = String.Format("{0:#,##0}", data_calc_not_59);
                            calc_not_b8.Value = String.Format("{0:#,##0}", data_calc_not_61);
                            calc_not_b9.Value = String.Format("{0:#,##0}", data_calc_not_b9);

                            calc_rounded_0.Value = String.Format("{0:#,##0}", netbusiness);
                            calc_rounded_01.Value = String.Format("{0:#,##0}", annualizenetbusiness);
                            calc_rounded_1.Value = String.Format("{0:#,##0}", data_calc_rounded_1);
                            calc_rounded_2.Value = String.Format("{0:#,##0}", data_calc_rounded_2);
                            calc_rounded_3.Value = String.Format("{0:#,##0}", data_calc_rounded_3);
                            calc_rounded_4.Value = String.Format("{0:#,##0}", data_calc_rounded_4);
                            calc_rounded_5.Value = String.Format("{0:#,##0}", data_calc_rounded_5);
                            calc_rounded_6.Value = String.Format("{0:#,##0}", data_calc_rounded_6);
                            calc_rounded_7.Value = String.Format("{0:#,##0}", data_calc_rounded_7);
                            calc_rounded_8.Value = String.Format("{0:#,##0}", data_calc_rounded_8);
                            calc_rounded_9.Value = String.Format("{0:#,##0}", data_calc_rounded_9);
                            calc_rounded_10.Value = String.Format("{0:#,##0}", data_calc_rounded_10);
                            calc_rounded_11.Value = String.Format("{0:#,##0}", data_calc_rounded_11);
                            calc_rounded_12.Value = String.Format("{0:#,##0}", data_calc_rounded_12);
                            calc_rounded_13.Value = String.Format("{0:#,##0}", data_calc_rounded_13);
                            calc_rounded_14.Value = String.Format("{0:#,##0}", data_calc_rounded_14);
                            calc_rounded_15.Value = String.Format("{0:#,##0}", data_calc_rounded_15);
                            calc_rounded_16.Value = String.Format("{0:#,##0}", data_calc_rounded_16);
                            calc_rounded_17.Value = String.Format("{0:#,##0}", data_calc_rounded_17);
                            calc_rounded_18.Value = String.Format("{0:#,##0}", data_calc_rounded_18);
                            calc_rounded_19.Value = String.Format("{0:#,##0}", data_calc_rounded_19);
                            calc_rounded_20.Value = String.Format("{0:#,##0}", data_calc_rounded_20);
                            calc_rounded_21.Value = String.Format("{0:#,##0}", data_calc_rounded_21);
                            calc_rounded_22.Value = String.Format("{0:#,##0}", data_calc_rounded_22);
                            calc_rounded_23.Value = String.Format("{0:#,##0}", data_calc_rounded_23);
                            calc_rounded_24.Value = String.Format("{0:#,##0}", data_calc_rounded_24);
                            calc_rounded_25.Value = String.Format("{0:#,##0}", data_calc_rounded_25);
                            calc_rounded_26.Value = String.Format("{0:#,##0}", data_calc_rounded_26);
                            calc_rounded_27.Value = String.Format("{0:#,##0}", data_calc_rounded_27);
                            calc_rounded_28.Value = String.Format("{0:#,##0}", data_calc_rounded_28);
                            calc_rounded_29.Value = String.Format("{0:#,##0}", data_calc_rounded_29);
                            calc_rounded_30.Value = String.Format("{0:#,##0}", data_calc_rounded_30);
                            calc_rounded_31.Value = String.Format("{0:#,##0}", data_calc_rounded_31);
                            calc_rounded_32.Value = String.Format("{0:#,##0}", data_calc_rounded_32);
                            calc_rounded_33.Value = String.Format("{0:#,##0}", data_calc_rounded_33);
                            calc_rounded_34.Value = String.Format("{0:#,##0}", data_calc_rounded_34);
                            calc_rounded_35.Value = String.Format("{0:#,##0}", data_calc_rounded_35);
                            calc_rounded_36.Value = String.Format("{0:#,##0}", data_calc_rounded_36);
                            calc_rounded_37.Value = String.Format("{0:#,##0}", data_calc_rounded_37);
                            calc_rounded_38.Value = String.Format("{0:#,##0}", data_calc_rounded_38);
                            calc_rounded_39.Value = String.Format("{0:#,##0}", data_calc_rounded_39);
                            calc_rounded_40.Value = String.Format("{0:#,##0}", data_calc_rounded_40);
                            calc_rounded_41.Value = String.Format("{0:#,##0}", data_calc_rounded_41);
                            calc_rounded_42.Value = String.Format("{0:#,##0}", data_calc_rounded_42);
                            calc_rounded_43.Value = String.Format("{0:#,##0}", data_calc_rounded_43);
                            calc_rounded_44.Value = String.Format("{0:#,##0}", data_calc_rounded_44);
                            calc_rounded_45.Value = String.Format("{0:#,##0}", data_calc_rounded_45);
                            calc_rounded_46.Value = String.Format("{0:#,##0}", data_calc_rounded_46);
                            calc_rounded_47.Value = String.Format("{0:#,##0}", data_calc_rounded_47);
                            calc_rounded_48.Value = String.Format("{0:#,##0}", data_calc_rounded_48);
                            calc_rounded_49.Value = String.Format("{0:#,##0}", data_calc_rounded_49);
                            calc_rounded_50.Value = String.Format("{0:#,##0}", data_calc_rounded_50);
                            calc_rounded_51.Value = String.Format("{0:#,##0}", data_calc_rounded_51);
                            calc_rounded_52.Value = String.Format("{0:#,##0}", data_calc_rounded_52);
                            calc_rounded_53.Value = String.Format("{0:#,##0}", data_calc_rounded_53);
                            calc_rounded_54.Value = String.Format("{0:#,##0}", data_calc_rounded_54);
                            calc_rounded_55.Value = String.Format("{0:#,##0}", data_calc_rounded_55);
                            calc_rounded_56.Value = String.Format("{0:#,##0}", data_calc_rounded_56);
                            calc_rounded_57.Value = String.Format("{0:#,##0}", data_calc_rounded_57);
                            calc_rounded_58.Value = String.Format("{0:#,##0}", data_calc_rounded_58);
                            calc_rounded_59.Value = String.Format("{0:#,##0}", data_calc_rounded_59);
                            calc_rounded_60.Value = String.Format("{0:#,##0}", data_calc_rounded_60);
                            calc_rounded_61.Value = String.Format("{0:#,##0}", data_calc_rounded_61);
                            calc_rounded_62.Value = String.Format("{0:#,##0}", data_calc_rounded_62);
                            calc_rounded_63.Value = String.Format("{0:#,##0}", data_calc_rounded_63);
                            calc_rounded_64.Value = String.Format("{0:#,##0}", data_calc_rounded_64);
                            calc_rounded_65.Value = String.Format("{0:#,##0}", data_calc_rounded_65);
                            calc_rounded_66.Value = String.Format("{0:#,##0}", data_calc_rounded_66);
                            calc_rounded_67.Value = String.Format("{0:#,##0}", data_calc_rounded_67);
                            calc_rounded_68.Value = String.Format("{0:#,##0}", data_calc_rounded_68);
                            calc_rounded_69.Value = String.Format("{0:#,##0}", data_calc_rounded_69);
                            calc_rounded_70.Value = String.Format("{0:#,##0}", data_calc_rounded_70);
                            calc_rounded_71.Value = String.Format("{0:#,##0}", data_calc_rounded_71);
                            calc_rounded_72.Value = String.Format("{0:#,##0}", data_calc_rounded_72);
                            calc_rounded_73.Value = String.Format("{0:#,##0}", data_calc_rounded_73);

                            calc_not_0.Value = String.Format("{0:#,##0}", netbusiness);
                            calc_not_01.Value = String.Format("{0:#,##0}", annualizenetbusiness);
                            calc_not_1.Value = String.Format("{0:#,##0}", data_calc_not_1);
                            calc_not_2.Value = String.Format("{0:#,##0}", data_calc_not_2);
                            calc_not_3.Value = String.Format("{0:#,##0}", data_calc_not_3);
                            calc_not_4.Value = String.Format("{0:#,##0}", data_calc_not_4);
                            calc_not_5.Value = String.Format("{0:#,##0}", data_calc_not_5);
                            calc_not_6.Value = String.Format("{0:#,##0}", data_calc_not_6);
                            calc_not_7.Value = String.Format("{0:#,##0}", data_calc_not_7);
                            calc_not_8.Value = String.Format("{0:#,##0}", data_calc_not_8);
                            calc_not_9.Value = String.Format("{0:#,##0}", data_calc_not_9);
                            calc_not_10.Value = String.Format("{0:#,##0}", data_calc_not_10);
                            calc_not_11.Value = String.Format("{0:#,##0}", data_calc_not_11);
                            calc_not_12.Value = String.Format("{0:#,##0}", data_calc_not_12);
                            calc_not_13.Value = String.Format("{0:#,##0}", data_calc_not_13);
                            calc_not_14.Value = String.Format("{0:#,##0}", data_calc_not_14);
                            calc_not_15.Value = String.Format("{0:#,##0}", data_calc_not_15);
                            calc_not_16.Value = String.Format("{0:#,##0}", data_calc_not_16);
                            calc_not_17.Value = String.Format("{0:#,##0}", data_calc_not_17);
                            calc_not_18.Value = String.Format("{0:#,##0}", data_calc_not_18);
                            calc_not_19.Value = String.Format("{0:#,##0}", data_calc_not_19);
                            calc_not_20.Value = String.Format("{0:#,##0}", data_calc_not_20);
                            calc_not_21.Value = String.Format("{0:#,##0}", data_calc_not_21);
                            calc_not_22.Value = String.Format("{0:#,##0}", data_calc_not_22);
                            calc_not_23.Value = String.Format("{0:#,##0}", data_calc_not_23);
                            calc_not_24.Value = String.Format("{0:#,##0}", data_calc_not_24);
                            calc_not_25.Value = String.Format("{0:#,##0}", data_calc_not_25);
                            calc_not_26.Value = String.Format("{0:#,##0}", data_calc_not_26);
                            calc_not_27.Value = String.Format("{0:#,##0}", data_calc_not_27);
                            calc_not_28.Value = String.Format("{0:#,##0}", data_calc_not_28);
                            calc_not_29.Value = String.Format("{0:#,##0}", data_calc_not_29);
                            calc_not_30.Value = String.Format("{0:#,##0}", data_calc_not_30);
                            calc_not_31.Value = String.Format("{0:#,##0}", data_calc_not_31);
                            calc_not_32.Value = String.Format("{0:#,##0}", data_calc_not_32);
                            calc_not_33.Value = String.Format("{0:#,##0}", data_calc_not_33);
                            calc_not_34.Value = String.Format("{0:#,##0}", data_calc_not_34);
                            calc_not_35.Value = String.Format("{0:#,##0}", data_calc_not_35);
                            calc_not_36.Value = String.Format("{0:#,##0}", data_calc_not_36);
                            calc_not_37.Value = String.Format("{0:#,##0}", data_calc_not_37);
                            calc_not_38.Value = String.Format("{0:#,##0}", data_calc_not_38);
                            calc_not_39.Value = String.Format("{0:#,##0}", data_calc_not_39);
                            calc_not_40.Value = String.Format("{0:#,##0}", data_calc_not_40);
                            calc_not_41.Value = String.Format("{0:#,##0}", data_calc_not_41);
                            calc_not_42.Value = String.Format("{0:#,##0}", data_calc_not_42);
                            calc_not_43.Value = String.Format("{0:#,##0}", data_calc_not_43);
                            calc_not_44.Value = String.Format("{0:#,##0}", data_calc_not_44);
                            calc_not_45.Value = String.Format("{0:#,##0}", data_calc_not_45);
                            calc_not_46.Value = String.Format("{0:#,##0}", data_calc_not_46);
                            calc_not_47.Value = String.Format("{0:#,##0}", data_calc_not_47);
                            calc_not_48.Value = String.Format("{0:#,##0}", data_calc_not_48);
                            calc_not_49.Value = String.Format("{0:#,##0}", data_calc_not_49);
                            calc_not_50.Value = String.Format("{0:#,##0}", data_calc_not_50);
                            calc_not_51.Value = String.Format("{0:#,##0}", data_calc_not_51);
                            calc_not_52.Value = String.Format("{0:#,##0}", data_calc_not_52);
                            calc_not_53.Value = String.Format("{0:#,##0}", data_calc_not_53);
                            calc_not_54.Value = String.Format("{0:#,##0}", data_calc_not_54);
                            calc_not_55.Value = String.Format("{0:#,##0}", data_calc_not_55);
                            calc_not_56.Value = String.Format("{0:#,##0}", data_calc_not_56);
                            calc_not_57.Value = String.Format("{0:#,##0}", data_calc_not_57);
                            calc_not_58.Value = String.Format("{0:#,##0}", data_calc_not_58);
                            calc_not_59.Value = String.Format("{0:#,##0}", data_calc_not_59);
                            calc_not_60.Value = String.Format("{0:#,##0}", data_calc_not_60);
                            calc_not_61.Value = String.Format("{0:#,##0}", data_calc_not_61);
                            calc_not_62.Value = String.Format("{0:#,##0}", data_calc_not_62);
                            calc_not_63.Value = String.Format("{0:#,##0}", data_calc_not_63);
                            calc_not_64.Value = String.Format("{0:#,##0}", data_calc_not_64);
                            calc_not_65.Value = String.Format("{0:#,##0}", data_calc_not_65);
                            calc_not_66.Value = String.Format("{0:#,##0}", data_calc_not_66);
                            calc_not_67.Value = String.Format("{0:#,##0}", data_calc_not_67);
                            calc_not_68.Value = String.Format("{0:#,##0}", data_calc_not_68);
                            calc_not_69.Value = String.Format("{0:#,##0}", data_calc_not_69);
                            calc_not_70.Value = String.Format("{0:#,##0}", data_calc_not_70);
                            calc_not_71.Value = String.Format("{0:#,##0}", data_calc_not_71);
                            calc_not_72.Value = String.Format("{0:#,##0}", data_calc_not_72);
                            calc_not_73.Value = String.Format("{0:#,##0}", data_calc_not_73);

                        }
                }
                else{
                    //load from database
                    foreach (vm.Calculation calculation in calculations)
                    {
                        calc_rounded_b1.Value = String.Format("{0:#,##0}", calculation.calc_rounded_b1);
                        calc_rounded_b2.Value = String.Format("{0:#,##0}", calculation.calc_rounded_b2);
                        calc_rounded_b3.Value = String.Format("{0:#,##0}", calculation.calc_rounded_b3);
                        calc_rounded_b4.Value = String.Format("{0:#,##0}", calculation.calc_rounded_b4);
                        calc_rounded_b5.Value = String.Format("{0:#,##0}", calculation.calc_rounded_b5);
                        calc_rounded_b6.Value = String.Format("{0:#,##0}", calculation.calc_rounded_b6);
                        calc_rounded_b7.Value = String.Format("{0:#,##0}", calculation.calc_rounded_b7);
                        calc_rounded_b8.Value = String.Format("{0:#,##0}", calculation.calc_rounded_b8);
                        calc_not_b1.Value = String.Format("{0:#,##0}", calculation.calc_not_b1);
                        calc_not_b2.Value = String.Format("{0:#,##0}", calculation.calc_not_b2);
                        calc_not_b3.Value = String.Format("{0:#,##0}", calculation.calc_not_b3);
                        calc_not_b4.Value = String.Format("{0:#,##0}", calculation.calc_not_b4);
                        calc_not_b5.Value = String.Format("{0:#,##0}", calculation.calc_not_b5);
                        calc_not_b6.Value = String.Format("{0:#,##0}", calculation.calc_not_b6);
                        calc_not_b7.Value = String.Format("{0:#,##0}", calculation.calc_not_b7);
                        calc_not_b8.Value = String.Format("{0:#,##0}", calculation.calc_not_b8);
                        calc_not_b9.Value = String.Format("{0:#,##0}", calculation.calc_not_b9);
                        calc_rounded_0.Value = String.Format("{0:#,##0}", calculation.calc_rounded_0);
                        calc_rounded_01.Value = String.Format("{0:#,##0}", calculation.calc_rounded_01);
                        calc_not_0.Value = String.Format("{0:#,##0}", calculation.calc_not_0);
                        calc_not_01.Value = String.Format("{0:#,##0}", calculation.calc_not_01);

                        calc_rounded_1.Value = String.Format("{0:#,##0}", calculation.calc_rounded_1);
                        calc_rounded_2.Value = String.Format("{0:#,##0}", calculation.calc_rounded_2);
                        calc_rounded_3.Value = String.Format("{0:#,##0}", calculation.calc_rounded_3);
                        calc_rounded_4.Value = String.Format("{0:#,##0}", calculation.calc_rounded_4);
                        calc_rounded_5.Value = String.Format("{0:#,##0}", calculation.calc_rounded_5);
                        calc_rounded_6.Value = String.Format("{0:#,##0}", calculation.calc_rounded_6);
                        calc_rounded_7.Value = String.Format("{0:#,##0}", calculation.calc_rounded_7);
                        calc_rounded_8.Value = String.Format("{0:#,##0}", calculation.calc_rounded_8);
                        calc_rounded_9.Value = String.Format("{0:#,##0}", calculation.calc_rounded_9);
                        calc_rounded_10.Value = String.Format("{0:#,##0}", calculation.calc_rounded_10);
                        calc_rounded_11.Value = String.Format("{0:#,##0}", calculation.calc_rounded_11);
                        calc_rounded_12.Value = String.Format("{0:#,##0}", calculation.calc_rounded_12);
                        calc_rounded_13.Value = String.Format("{0:#,##0}", calculation.calc_rounded_13);
                        calc_rounded_14.Value = String.Format("{0:#,##0}", calculation.calc_rounded_14);
                        calc_rounded_15.Value = String.Format("{0:#,##0}", calculation.calc_rounded_15);
                        calc_rounded_16.Value = String.Format("{0:#,##0}", calculation.calc_rounded_16);
                        calc_rounded_17.Value = String.Format("{0:#,##0}", calculation.calc_rounded_17);
                        calc_rounded_18.Value = String.Format("{0:#,##0}", calculation.calc_rounded_18);
                        calc_rounded_19.Value = String.Format("{0:#,##0}", calculation.calc_rounded_19);
                        calc_rounded_20.Value = String.Format("{0:#,##0}", calculation.calc_rounded_20);
                        calc_rounded_21.Value = String.Format("{0:#,##0}", calculation.calc_rounded_21);
                        calc_rounded_22.Value = String.Format("{0:#,##0}", calculation.calc_rounded_22);
                        calc_rounded_23.Value = String.Format("{0:#,##0}", calculation.calc_rounded_23);
                        calc_rounded_24.Value = String.Format("{0:#,##0}", calculation.calc_rounded_24);
                        calc_rounded_25.Value = String.Format("{0:#,##0}", calculation.calc_rounded_25);
                        calc_rounded_26.Value = String.Format("{0:#,##0}", calculation.calc_rounded_26);
                        calc_rounded_27.Value = String.Format("{0:#,##0}", calculation.calc_rounded_27);
                        calc_rounded_28.Value = String.Format("{0:#,##0}", calculation.calc_rounded_28);
                        calc_rounded_29.Value = String.Format("{0:#,##0}", calculation.calc_rounded_29);
                        calc_rounded_30.Value = String.Format("{0:#,##0}", calculation.calc_rounded_30);
                        calc_rounded_31.Value = String.Format("{0:#,##0}", calculation.calc_rounded_31);
                        calc_rounded_32.Value = String.Format("{0:#,##0}", calculation.calc_rounded_32);
                        calc_rounded_33.Value = String.Format("{0:#,##0}", calculation.calc_rounded_33);
                        calc_rounded_34.Value = String.Format("{0:#,##0}", calculation.calc_rounded_34);
                        calc_rounded_35.Value = String.Format("{0:#,##0}", calculation.calc_rounded_35);
                        calc_rounded_36.Value = String.Format("{0:#,##0}", calculation.calc_rounded_36);
                        calc_rounded_37.Value = String.Format("{0:#,##0}", calculation.calc_rounded_37);
                        calc_rounded_38.Value = String.Format("{0:#,##0}", calculation.calc_rounded_38);
                        calc_rounded_39.Value = String.Format("{0:#,##0}", calculation.calc_rounded_39);
                        calc_rounded_40.Value = String.Format("{0:#,##0}", calculation.calc_rounded_40);
                        calc_rounded_41.Value = String.Format("{0:#,##0}", calculation.calc_rounded_41);
                        calc_rounded_42.Value = String.Format("{0:#,##0}", calculation.calc_rounded_42);
                        calc_rounded_43.Value = String.Format("{0:#,##0}", calculation.calc_rounded_43);
                        calc_rounded_44.Value = String.Format("{0:#,##0}", calculation.calc_rounded_44);
                        calc_rounded_45.Value = String.Format("{0:#,##0}", calculation.calc_rounded_45);
                        calc_rounded_46.Value = String.Format("{0:#,##0}", calculation.calc_rounded_46);
                        calc_rounded_47.Value = String.Format("{0:#,##0}", calculation.calc_rounded_47);
                        calc_rounded_48.Value = String.Format("{0:#,##0}", calculation.calc_rounded_48);
                        calc_rounded_49.Value = String.Format("{0:#,##0}", calculation.calc_rounded_49);
                        calc_rounded_50.Value = String.Format("{0:#,##0}", calculation.calc_rounded_50);
                        calc_rounded_51.Value = String.Format("{0:#,##0}", calculation.calc_rounded_51);
                        calc_rounded_52.Value = String.Format("{0:#,##0}", calculation.calc_rounded_52);
                        calc_rounded_53.Value = String.Format("{0:#,##0}", calculation.calc_rounded_53);
                        calc_rounded_54.Value = String.Format("{0:#,##0}", calculation.calc_rounded_54);
                        calc_rounded_55.Value = String.Format("{0:#,##0}", calculation.calc_rounded_55);
                        calc_rounded_56.Value = String.Format("{0:#,##0}", calculation.calc_rounded_56);
                        calc_rounded_57.Value = String.Format("{0:#,##0}", calculation.calc_rounded_57);
                        calc_rounded_58.Value = String.Format("{0:#,##0}", calculation.calc_rounded_58);
                        calc_rounded_59.Value = String.Format("{0:#,##0}", calculation.calc_rounded_59);
                        calc_rounded_60.Value = String.Format("{0:#,##0}", calculation.calc_rounded_60);
                        calc_rounded_61.Value = String.Format("{0:#,##0}", calculation.calc_rounded_61);
                        calc_rounded_62.Value = String.Format("{0:#,##0}", calculation.calc_rounded_62);
                        calc_rounded_63.Value = String.Format("{0:#,##0}", calculation.calc_rounded_63);
                        calc_rounded_64.Value = String.Format("{0:#,##0}", calculation.calc_rounded_64);
                        calc_rounded_65.Value = String.Format("{0:#,##0}", calculation.calc_rounded_65);
                        calc_rounded_66.Value = String.Format("{0:#,##0}", calculation.calc_rounded_66);
                        calc_rounded_67.Value = String.Format("{0:#,##0}", calculation.calc_rounded_67);
                        calc_rounded_68.Value = String.Format("{0:#,##0}", calculation.calc_rounded_68);
                        calc_rounded_69.Value = String.Format("{0:#,##0}", calculation.calc_rounded_69);
                        calc_rounded_70.Value = String.Format("{0:#,##0}", calculation.calc_rounded_70);
                        calc_rounded_71.Value = String.Format("{0:#,##0}", calculation.calc_rounded_71);
                        calc_rounded_72.Value = String.Format("{0:#,##0}", calculation.calc_rounded_72);
                        calc_rounded_73.Value = String.Format("{0:#,##0}", calculation.calc_rounded_73);
                        calc_not_1.Value = String.Format("{0:#,##0}", calculation.calc_not_1);
                        calc_not_2.Value = String.Format("{0:#,##0}", calculation.calc_not_2);
                        calc_not_3.Value = String.Format("{0:#,##0}", calculation.calc_not_3);
                        calc_not_4.Value = String.Format("{0:#,##0}", calculation.calc_not_4);
                        calc_not_5.Value = String.Format("{0:#,##0}", calculation.calc_not_5);
                        calc_not_6.Value = String.Format("{0:#,##0}", calculation.calc_not_6);
                        calc_not_7.Value = String.Format("{0:#,##0}", calculation.calc_not_7);
                        calc_not_8.Value = String.Format("{0:#,##0}", calculation.calc_not_8);
                        calc_not_9.Value = String.Format("{0:#,##0}", calculation.calc_not_9);
                        calc_not_10.Value = String.Format("{0:#,##0}", calculation.calc_not_10);
                        calc_not_11.Value = String.Format("{0:#,##0}", calculation.calc_not_11);
                        calc_not_12.Value = String.Format("{0:#,##0}", calculation.calc_not_12);
                        calc_not_13.Value = String.Format("{0:#,##0}", calculation.calc_not_13);
                        calc_not_14.Value = String.Format("{0:#,##0}", calculation.calc_not_14);
                        calc_not_15.Value = String.Format("{0:#,##0}", calculation.calc_not_15);
                        calc_not_16.Value = String.Format("{0:#,##0}", calculation.calc_not_16);
                        calc_not_17.Value = String.Format("{0:#,##0}", calculation.calc_not_17);
                        calc_not_18.Value = String.Format("{0:#,##0}", calculation.calc_not_18);
                        calc_not_19.Value = String.Format("{0:#,##0}", calculation.calc_not_19);
                        calc_not_20.Value = String.Format("{0:#,##0}", calculation.calc_not_20);
                        calc_not_21.Value = String.Format("{0:#,##0}", calculation.calc_not_21);
                        calc_not_22.Value = String.Format("{0:#,##0}", calculation.calc_not_22);
                        calc_not_23.Value = String.Format("{0:#,##0}", calculation.calc_not_23);
                        calc_not_24.Value = String.Format("{0:#,##0}", calculation.calc_not_24);
                        calc_not_25.Value = String.Format("{0:#,##0}", calculation.calc_not_25);
                        calc_not_26.Value = String.Format("{0:#,##0}", calculation.calc_not_26);
                        calc_not_27.Value = String.Format("{0:#,##0}", calculation.calc_not_27);
                        calc_not_28.Value = String.Format("{0:#,##0}", calculation.calc_not_28);
                        calc_not_29.Value = String.Format("{0:#,##0}", calculation.calc_not_29);
                        calc_not_30.Value = String.Format("{0:#,##0}", calculation.calc_not_30);
                        calc_not_31.Value = String.Format("{0:#,##0}", calculation.calc_not_31);
                        calc_not_32.Value = String.Format("{0:#,##0}", calculation.calc_not_32);
                        calc_not_33.Value = String.Format("{0:#,##0}", calculation.calc_not_33);
                        calc_not_34.Value = String.Format("{0:#,##0}", calculation.calc_not_34);
                        calc_not_35.Value = String.Format("{0:#,##0}", calculation.calc_not_35);
                        calc_not_36.Value = String.Format("{0:#,##0}", calculation.calc_not_36);
                        calc_not_37.Value = String.Format("{0:#,##0}", calculation.calc_not_37);
                        calc_not_38.Value = String.Format("{0:#,##0}", calculation.calc_not_38);
                        calc_not_39.Value = String.Format("{0:#,##0}", calculation.calc_not_39);
                        calc_not_40.Value = String.Format("{0:#,##0}", calculation.calc_not_40);
                        calc_not_41.Value = String.Format("{0:#,##0}", calculation.calc_not_41);
                        calc_not_42.Value = String.Format("{0:#,##0}", calculation.calc_not_42);
                        calc_not_43.Value = String.Format("{0:#,##0}", calculation.calc_not_43);
                        calc_not_44.Value = String.Format("{0:#,##0}", calculation.calc_not_44);
                        calc_not_45.Value = String.Format("{0:#,##0}", calculation.calc_not_45);
                        calc_not_46.Value = String.Format("{0:#,##0}", calculation.calc_not_46);
                        calc_not_47.Value = String.Format("{0:#,##0}", calculation.calc_not_47);
                        calc_not_48.Value = String.Format("{0:#,##0}", calculation.calc_not_48);
                        calc_not_49.Value = String.Format("{0:#,##0}", calculation.calc_not_49);
                        calc_not_50.Value = String.Format("{0:#,##0}", calculation.calc_not_50);
                        calc_not_51.Value = String.Format("{0:#,##0}", calculation.calc_not_51);
                        calc_not_52.Value = String.Format("{0:#,##0}", calculation.calc_not_52);
                        calc_not_53.Value = String.Format("{0:#,##0}", calculation.calc_not_53);
                        calc_not_54.Value = String.Format("{0:#,##0}", calculation.calc_not_54);
                        calc_not_55.Value = String.Format("{0:#,##0}", calculation.calc_not_55);
                        calc_not_56.Value = String.Format("{0:#,##0}", calculation.calc_not_56);
                        calc_not_57.Value = String.Format("{0:#,##0}", calculation.calc_not_57);
                        calc_not_58.Value = String.Format("{0:#,##0}", calculation.calc_not_58);
                        calc_not_59.Value = String.Format("{0:#,##0}", calculation.calc_not_59);
                        calc_not_60.Value = String.Format("{0:#,##0}", calculation.calc_not_60);
                        calc_not_61.Value = String.Format("{0:#,##0}", calculation.calc_not_61);
                        calc_not_62.Value = String.Format("{0:#,##0}", calculation.calc_not_62);
                        calc_not_63.Value = String.Format("{0:#,##0}", calculation.calc_not_63);
                        calc_not_64.Value = String.Format("{0:#,##0}", calculation.calc_not_64);
                        calc_not_65.Value = String.Format("{0:#,##0}", calculation.calc_not_65);
                        calc_not_66.Value = String.Format("{0:#,##0}", calculation.calc_not_66);
                        calc_not_67.Value = String.Format("{0:#,##0}", calculation.calc_not_67);
                        calc_not_68.Value = String.Format("{0:#,##0}", calculation.calc_not_68);
                        calc_not_69.Value = String.Format("{0:#,##0}", calculation.calc_not_69);
                        calc_not_70.Value = String.Format("{0:#,##0}", calculation.calc_not_70);
                        calc_not_71.Value = String.Format("{0:#,##0}", calculation.calc_not_71);
                        calc_not_72.Value = String.Format("{0:#,##0}", calculation.calc_not_72);
                        calc_not_73.Value = String.Format("{0:#,##0}", calculation.calc_not_73);
                    }
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        private void SetEditable(bool isEnabled)
        {
            isEnabled = !isEnabled;
            calc_rounded_0.Disabled = isEnabled;
            calc_rounded_01.Disabled = isEnabled;

            calc_rounded_1.Disabled = isEnabled;
            calc_rounded_2.Disabled = isEnabled;
            calc_rounded_3.Disabled = isEnabled;
            calc_rounded_4.Disabled = isEnabled;
            calc_rounded_5.Disabled = isEnabled;
            calc_rounded_6.Disabled = isEnabled;
            calc_rounded_7.Disabled = isEnabled;
            calc_rounded_8.Disabled = isEnabled;
            calc_rounded_9.Disabled = isEnabled;
            calc_rounded_10.Disabled = isEnabled;
            calc_rounded_11.Disabled = isEnabled;
            calc_rounded_12.Disabled = isEnabled;
            calc_rounded_13.Disabled = isEnabled;
            calc_rounded_14.Disabled = isEnabled;
            calc_rounded_15.Disabled = isEnabled;
            calc_rounded_16.Disabled = isEnabled;
            calc_rounded_17.Disabled = isEnabled;
            calc_rounded_18.Disabled = isEnabled;
            calc_rounded_19.Disabled = isEnabled;
            calc_rounded_20.Disabled = isEnabled;
            calc_rounded_21.Disabled = isEnabled;
            calc_rounded_22.Disabled = isEnabled;
            calc_rounded_23.Disabled = isEnabled;
            calc_rounded_24.Disabled = isEnabled;
            calc_rounded_25.Disabled = isEnabled;
            calc_rounded_26.Disabled = isEnabled;
            calc_rounded_27.Disabled = isEnabled;
            calc_rounded_28.Disabled = isEnabled;
            calc_rounded_29.Disabled = isEnabled;
            calc_rounded_30.Disabled = isEnabled;
            calc_rounded_31.Disabled = isEnabled;
            calc_rounded_32.Disabled = isEnabled;
            calc_rounded_33.Disabled = isEnabled;
            calc_rounded_34.Disabled = isEnabled;
            calc_rounded_35.Disabled = isEnabled;
            calc_rounded_36.Disabled = isEnabled;
            calc_rounded_37.Disabled = isEnabled;
            calc_rounded_38.Disabled = isEnabled;
            calc_rounded_39.Disabled = isEnabled;
            calc_rounded_40.Disabled = isEnabled;
            calc_rounded_41.Disabled = isEnabled;
            calc_rounded_42.Disabled = isEnabled;
            calc_rounded_43.Disabled = isEnabled;
            calc_rounded_44.Disabled = isEnabled;
            calc_rounded_45.Disabled = isEnabled;
            calc_rounded_46.Disabled = isEnabled;
            calc_rounded_47.Disabled = isEnabled;
            calc_rounded_48.Disabled = isEnabled;
            calc_rounded_49.Disabled = isEnabled;
            calc_rounded_50.Disabled = isEnabled;
            calc_rounded_51.Disabled = isEnabled;
            calc_rounded_52.Disabled = isEnabled;
            calc_rounded_53.Disabled = isEnabled;
            calc_rounded_54.Disabled = isEnabled;
            calc_rounded_55.Disabled = isEnabled;
            calc_rounded_56.Disabled = isEnabled;
            calc_rounded_57.Disabled = isEnabled;
            calc_rounded_58.Disabled = isEnabled;
            calc_rounded_59.Disabled = isEnabled;
            calc_rounded_60.Disabled = isEnabled;
            calc_rounded_61.Disabled = isEnabled;
            calc_rounded_62.Disabled = isEnabled;
            calc_rounded_63.Disabled = isEnabled;
            calc_rounded_64.Disabled = isEnabled;
            calc_rounded_65.Disabled = isEnabled;
            calc_rounded_66.Disabled = isEnabled;
            calc_rounded_67.Disabled = isEnabled;
            calc_rounded_68.Disabled = isEnabled;
            calc_rounded_69.Disabled = isEnabled;
            calc_rounded_70.Disabled = isEnabled;
            calc_rounded_71.Disabled = isEnabled;
            calc_rounded_72.Disabled = isEnabled;
            calc_rounded_73.Disabled = isEnabled;

            calc_not_0.Disabled = isEnabled;
            calc_not_01.Disabled = isEnabled;
            calc_not_1.Disabled = isEnabled;
            calc_not_2.Disabled = isEnabled;
            calc_not_3.Disabled = isEnabled;
            calc_not_4.Disabled = isEnabled;
            calc_not_5.Disabled = isEnabled;
            calc_not_6.Disabled = isEnabled;
            calc_not_7.Disabled = isEnabled;
            calc_not_8.Disabled = isEnabled;
            calc_not_9.Disabled = isEnabled;
            calc_not_10.Disabled = isEnabled;
            calc_not_11.Disabled = isEnabled;
            calc_not_12.Disabled = isEnabled;
            calc_not_13.Disabled = isEnabled;
            calc_not_14.Disabled = isEnabled;
            calc_not_15.Disabled = isEnabled;
            calc_not_16.Disabled = isEnabled;
            calc_not_17.Disabled = isEnabled;
            calc_not_18.Disabled = isEnabled;
            calc_not_19.Disabled = isEnabled;
            calc_not_20.Disabled = isEnabled;
            calc_not_21.Disabled = isEnabled;
            calc_not_22.Disabled = isEnabled;
            calc_not_23.Disabled = isEnabled;
            calc_not_24.Disabled = isEnabled;
            calc_not_25.Disabled = isEnabled;
            calc_not_26.Disabled = isEnabled;
            calc_not_27.Disabled = isEnabled;
            calc_not_28.Disabled = isEnabled;
            calc_not_29.Disabled = isEnabled;
            calc_not_30.Disabled = isEnabled;
            calc_not_31.Disabled = isEnabled;
            calc_not_32.Disabled = isEnabled;
            calc_not_33.Disabled = isEnabled;
            calc_not_34.Disabled = isEnabled;
            calc_not_35.Disabled = isEnabled;
            calc_not_36.Disabled = isEnabled;
            calc_not_37.Disabled = isEnabled;
            calc_not_38.Disabled = isEnabled;
            calc_not_39.Disabled = isEnabled;
            calc_not_40.Disabled = isEnabled;
            calc_not_41.Disabled = isEnabled;
            calc_not_42.Disabled = isEnabled;
            calc_not_43.Disabled = isEnabled;
            calc_not_44.Disabled = isEnabled;
            calc_not_45.Disabled = isEnabled;
            calc_not_46.Disabled = isEnabled;
            calc_not_47.Disabled = isEnabled;
            calc_not_48.Disabled = isEnabled;
            calc_not_49.Disabled = isEnabled;
            calc_not_50.Disabled = isEnabled;
            calc_not_51.Disabled = isEnabled;
            calc_not_52.Disabled = isEnabled;
            calc_not_53.Disabled = isEnabled;
            calc_not_54.Disabled = isEnabled;
            calc_not_55.Disabled = isEnabled;
            calc_not_56.Disabled = isEnabled;
            calc_not_57.Disabled = isEnabled;
            calc_not_58.Disabled = isEnabled;
            calc_not_59.Disabled = isEnabled;
            calc_not_60.Disabled = isEnabled;
            calc_not_61.Disabled = isEnabled;
            calc_not_62.Disabled = isEnabled;
            calc_not_63.Disabled = isEnabled;
            calc_not_64.Disabled = isEnabled;
            calc_not_65.Disabled = isEnabled;
            calc_not_66.Disabled = isEnabled;
            calc_not_67.Disabled = isEnabled;
            calc_not_68.Disabled = isEnabled;
            calc_not_69.Disabled = isEnabled;
            calc_not_70.Disabled = isEnabled;
            calc_not_71.Disabled = isEnabled;
            calc_not_72.Disabled = isEnabled;
            calc_not_73.Disabled = isEnabled;
        }

        public static string getLastNameCommaFirstName(String fullName)
        {
            List<string> names = fullName.Split(' ').ToList();
            string firstName = names.First();
            names.RemoveAt(0);

            string _name = "";
            if (names.Count == 0)
            {
                _name = firstName;
            }
            else
            {
                _name = String.Join(" ", names.ToArray()) + ", " + firstName;
            }
            return _name;
        }

        protected void lbBacktoTaxform_Click(object sender, EventArgs e)
        {
            try
            {
                List<vm.TaxForm> taxforms = _servicesTaxForm.GetAllBy(hdtaxidnumber.Value, formType, hdtaxyear.Value, 1);
                string backid = taxforms[0].TaxPayerNumber;
                Response.Redirect("~/taxform.aspx?id=" + backid);
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        protected void lbBacktoForm_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/form1770.aspx?id=" + hdid.Value);
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        protected void lbDownload_pdf_Click(object sender, EventArgs e)
        {
            SaveCalculation();

            SetMessage("");

            string foldername = hdid.Value + "-report/";
            string zipPath = hdid.Value + "-report.zip";

            List<int> selectedarr = new List<int>();
            List<string> selectedfilenamearr = new List<string>();

            try
            {
                if (Directory.Exists(HttpContext.Current.Server.MapPath(exportPath + sessionLog + "/" + foldername)))
                {
                    Directory.Delete(HttpContext.Current.Server.MapPath(exportPath + sessionLog + "/" + foldername), true);
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(exportPath + sessionLog + "/" + foldername));
                }
                else
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(exportPath + sessionLog + "/" + foldername));
                }

                for (int i = 1; i <= reportCount; i++)
                {
                    if (i == 1)
                    {
                        selectedarr.Add(4);
                        selectedfilenamearr.Add("FE-1770");
                    }
                    else if (i == 2)
                    {
                        selectedarr.Add(5);
                        selectedfilenamearr.Add("FE-1770-I-hal1");
                    }
                    else if (i == 3)
                    {
                        selectedarr.Add(6);
                        selectedfilenamearr.Add("FE-1770-II");
                    }
                    else if (i == 4)
                    {
                        selectedarr.Add(7);
                        selectedfilenamearr.Add("FE-1770-I-hal2");
                    }
                    else if (i == 5)
                    {
                        selectedarr.Add(8);
                        selectedfilenamearr.Add("FE-1770-III");
                    }
                    else if (i == 6)
                    {
                        selectedarr.Add(9);
                        selectedfilenamearr.Add("FE-1770-IV");
                    }
                    else if (i == 7)
                    {
                        selectedarr.Add(10);
                        selectedfilenamearr.Add("Attachment");
                    }
                    else if (i == 8)
                    {
                        selectedarr.Add(11);
                        selectedfilenamearr.Add("SUMMARY-NOTEKEEPING");
                    }
                    else if (i == 9)
                    {
                        selectedarr.Add(12);
                        selectedfilenamearr.Add("1770");
                    }
                    else if (i == 10)
                    {
                        selectedarr.Add(13);
                        selectedfilenamearr.Add("1770-I-hal1");
                    }
                    else if (i == 11)
                    {
                        selectedarr.Add(14);
                        selectedfilenamearr.Add("1770-I-hal2");
                    }
                    else if (i == 12)
                    {
                        selectedarr.Add(15);
                        selectedfilenamearr.Add("1770-II");
                    }
                    else if (i == 13)
                    {
                        selectedarr.Add(16);
                        selectedfilenamearr.Add("1770-III");
                    }
                    else if (i == 14)
                    {
                        selectedarr.Add(17);
                        selectedfilenamearr.Add("1770-IV");
                    }
                    else if (i == 15)
                    {
                        selectedarr.Add(18);
                        selectedfilenamearr.Add("LAMPIRAN");
                    }
                    else if (i == 16)
                    {
                        selectedarr.Add(19);
                        selectedfilenamearr.Add("RINGKASAN-CATATAN");
                    }
                    else if (i == 17)
                    {
                        selectedarr.Add(20);
                        selectedfilenamearr.Add("Daftar_Pembayaran_PP-46-2013");
                    }
                    else if (i == 18)
                    {
                        selectedarr.Add(21);
                        selectedfilenamearr.Add("Daftar_Pembayaran_OPPT");
                    }
                    else if (i == 19)
                    {
                        selectedarr.Add(0);
                        selectedfilenamearr.Add("Form1770");
                    }
                }

                if (selectedarr.Count > 0)
                {
                    SaveasPDF(selectedfilenamearr, selectedarr, true);
                }
                else
                {
                    SetMessage("PLease select at least one report!");
                }


            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
            finally
            {
                try
                {
                    Response.AddHeader("Content-Disposition", "attachment;filename=\"" + outputname + "\"");
                    Response.ContentType = "application/pdf";
                    Response.Charset = "";
                    Response.AddHeader("Content-Length", (new System.IO.FileInfo(HttpContext.Current.Server.MapPath("~/App_Data/" + sessionLog + "/" + foldername + outputname)).Length).ToString());
                    Response.TransmitFile("~/App_Data/" + sessionLog + "/" + foldername + outputname);

                    Response.End();
                }
                catch (Exception ex)
                {

                    SetMessage(ex.Message);
                }

            }
        }

        protected void lbDownload_excel_Click(object sender, EventArgs e)
        {
            SaveCalculation();

            SetMessage("");

            string foldername = hdid.Value + "-report/";
            string zipPath = hdid.Value + "-report.zip";

            List<int> selectedarr = new List<int>();
            List<string> selectedfilenamearr = new List<string>();

            try
            {
                if (Directory.Exists(HttpContext.Current.Server.MapPath(exportPath + sessionLog + "/" + foldername)))
                {
                    Directory.Delete(HttpContext.Current.Server.MapPath(exportPath + sessionLog + "/" + foldername), true);
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(exportPath + sessionLog + "/" + foldername));
                }
                else
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(exportPath + sessionLog + "/" + foldername));
                }

                selectedarr.Add(0);
                selectedfilenamearr.Add("Form1770");
                SaveasPDF(selectedfilenamearr, selectedarr, false);
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
            finally
            {
                try
                {
                    Response.AddHeader("Content-Disposition", "attachment;filename=\"" + outputnameexcel + "\"");
                    Response.ContentType = "application/xlsx";
                    Response.Charset = "";
                    Response.AddHeader("Content-Length", (new System.IO.FileInfo(HttpContext.Current.Server.MapPath("~/App_Data/" + sessionLog + "/" + foldername + outputnameexcel)).Length).ToString());
                    Response.TransmitFile("~/App_Data/" + sessionLog + "/" + foldername + outputnameexcel);

                    Response.End();
                }
                catch (Exception ex)
                {

                    SetMessage(ex.Message);
                }

            }
        }

        private void SaveasPDF(List<string> filename, List<int> selectedsheet, bool selected)
        {
            string templatename = "Form1770";

            try
            {
                SLDocument slDoc = new SLDocument(templatePath + templatename + ".xlsx", "GENERAL INFO");

                debugtext = "DEBUG 1 ";
                List<vm.TaxForm> taxforms = _servicesTaxForm.GetAllBy(hdtaxidnumber.Value, formType, hdtaxyear.Value, 1, Convert.ToInt32(hdid.Value));

                debugtext = "DEBUG 2 ";
                foreach (vm.TaxForm taxform in taxforms)
                {
                    if (!string.IsNullOrEmpty(taxform.t1s1f2))
                    {
                        thename = getLastNameCommaFirstName(taxform.t1s1f2);
                    }
                    debugtext = "DEBUG 3 ";
                    //======================================
                    slDoc.SelectWorksheet("GENERAL INFO");
                    int a = 0;
                    string taxidnumber = taxform.taxidnumber.Replace(".", "");
                    taxidnumber = taxidnumber.Replace("-", "");

                    string t1s1f4 = taxform.t1s1f4.Replace(" ", "");
                    t1s1f4 = t1s1f4.Replace("-", "");
                    string t1s1f6 = taxform.t1s1f6.Replace(".", "");
                    t1s1f6 = t1s1f6.Replace("-", "");
                    string t1s1f8 = taxform.t1s1f8.Replace(" ", "");
                    t1s1f8 = t1s1f8.Replace("-", "");

                    slDoc.SetCellValue("G19", taxidnumber);
                    slDoc.SetCellValue("G21", taxform.t1s1f2);
                    slDoc.SetCellValue("G23", taxform.t1s1f5);
                    if (t1s1f8.Length > 3)
                    {
                        slDoc.SetCellValue("G25", t1s1f8.Substring(0, 3));
                        slDoc.SetCellValue("L25", t1s1f8.Substring(3, t1s1f8.Length - 3));
                    }
                    else
                    {
                        slDoc.SetCellValue("L25", taxform.t1s1f8);
                    }

                    slDoc.SetCellValue("G27", t1s1f4);
                    slDoc.SetCellValue("G33", t1s1f6);

                    if (taxform.t1s1f7 == "Married File Jointly")
                    {
                        slDoc.SetCellValue("G29", "X");
                    }
                    else if (taxform.t1s1f7 == "Separated By Law")
                    {
                        slDoc.SetCellValue("G31", "X");
                    }
                    else if (taxform.t1s1f7 == "Prenuptial Agreement")
                    {
                        slDoc.SetCellValue("N29", "X");
                    }
                    else if (taxform.t1s1f7 == "Married File Separately")
                    {
                        slDoc.SetCellValue("N31", "X");
                    }

                    if (taxform.year.Length >= 4)
                    {
                        //year
                        slDoc.SetCellValue("F37", taxform.year.Substring(0, 1).ToString());
                        slDoc.SetCellValue("G37", taxform.year.Substring(1, 1).ToString());
                        slDoc.SetCellValue("H37", taxform.year.Substring(2, 1).ToString());
                        slDoc.SetCellValue("I37", taxform.year.Substring(3, 1).ToString());
                    }
                    string t1s2f1 = "";
                    if (taxform.t1s2f1 != "")
                    {
                        string year = taxform.t1s2f1.Split('/')[2];
                        if (year.Length == 4)
                        {
                            year = year.Substring(2, 2);
                        }
                        t1s2f1 = taxform.t1s2f1.Split('/')[1] + "/" + taxform.t1s2f1.Split('/')[0] + "/" + year;
                    }
                    if (!string.IsNullOrEmpty(t1s2f1))
                    {
                        slDoc.SetCellValue("F39", Convert.ToDateTime(t1s2f1));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s2f2))
                    {
                        slDoc.SetCellValue("T39", Convert.ToInt32(taxform.t1s2f2));
                    }


                    if (taxform.t1s2f3 == "EPO")
                    {
                        slDoc.SetCellValue("F42", "X");
                    }
                    else if (taxform.t1s2f3 == "ERP Tidak Kembali")
                    {
                        slDoc.SetCellValue("J42", "X");
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s2f4))
                    {
                        slDoc.SetCellValue("T44", Convert.ToDouble(taxform.t1s2f4));
                    }
                    if (taxform.t1s2f5.Length == 10)
                    {
                        slDoc.SetCellValue("F44", taxform.t1s2f5.Substring(0, 1).ToString());
                        slDoc.SetCellValue("G44", taxform.t1s2f5.Substring(1, 1).ToString());
                        slDoc.SetCellValue("H44", taxform.t1s2f5.Substring(3, 1).ToString());
                        slDoc.SetCellValue("I44", taxform.t1s2f5.Substring(4, 1).ToString());
                        slDoc.SetCellValue("J44", taxform.t1s2f5.Substring(8, 1).ToString());
                        slDoc.SetCellValue("K44", taxform.t1s2f5.Substring(9, 1).ToString());
                    }
                    if (taxform.t1s2f6 == "Refund")
                    {
                        slDoc.SetCellValue("F46", "X");
                    }
                    else if (taxform.t1s2f6 == "Offset Against The Tax Liabilites")
                    {
                        slDoc.SetCellValue("F48", "X");
                    }
                    else if (taxform.t1s2f6 == "Return With SKPPKP Art. 17 C (obedient Taxpayer)")
                    {
                        slDoc.SetCellValue("O46", "X");
                    }
                    else if (taxform.t1s2f6 == "Return With SKKPP Art. 17 D (certain Taxpayer)")
                    {
                        slDoc.SetCellValue("O48", "X");
                    }

                    if (taxform.t1s2f11 == "True")
                    {
                        slDoc.SetCellValue("F51", "X");
                    }

                    if (taxform.t1s2f12 == "True")
                    {
                        slDoc.SetCellValue("F53", "X");
                    }

                    if (taxform.t1s2f13 == "True")
                    {
                        slDoc.SetCellValue("F55", "X");
                    }

                    if (taxform.t1s2f14 == "True")
                    {
                        slDoc.SetCellValue("F57", "X");
                    }

                    if (taxform.t1s2f15 == "True")
                    {
                        slDoc.SetCellValue("F59", "X");
                    }

                    if (taxform.t1s2f16 == "True")
                    {
                        slDoc.SetCellValue("F61", "X");
                    }

                    if (taxform.t1s2f17 == "True")
                    {
                        slDoc.SetCellValue("F63", "X");
                    }

                    slDoc.SetCellValue("H66", taxform.t1s2f18);
                    slDoc.SetCellValue("Q66", taxform.t1s2f19);
                    if (!string.IsNullOrEmpty(taxform.t1s2f18) || !string.IsNullOrEmpty(taxform.t1s2f19))
                    {
                        slDoc.SetCellValue("F66", "X");
                    }

                    if (taxform.t1s2f20 == "True")
                    {
                        slDoc.SetCellValue("F68", "X");
                    }

                    if (taxform.t1s2f21 == "True")
                    {
                        slDoc.SetCellValue("F70", "X");
                    }

                    if (taxform.t1s2f22 == "True")
                    {
                        slDoc.SetCellValue("F72", "X");
                    }

                    if (taxform.t1s2f10 == "True")
                    {
                        slDoc.SetCellValue("W77", "X");
                    }

                    if (taxform.t1s2f7 == "Taxpayer")
                    {
                        slDoc.SetCellValue("B80", "X");
                    }
                    else if (taxform.t1s2f7 == "Proxy")
                    {
                        slDoc.SetCellValue("B81", "X");
                    }
                    slDoc.SetCellValue("D81", taxform.t1s2f8);
                    slDoc.SetCellValue("D81", taxform.t1s2f9);

                    slDoc.SetCellValue("H75", taxform.t1s2f23);
                    slDoc.SetCellValue("Q75", taxform.t1s2f24);

                    if (!string.IsNullOrEmpty(taxform.t1s2f23) || !string.IsNullOrEmpty(taxform.t1s2f24))
                    {
                        slDoc.SetCellValue("F75", "X");
                    }

                    if (taxform.t1s3f1.ToUpper() == "MARRIED1")
                    {
                        slDoc.SetCellValue("F86", "MARRIED");
                    }
                    else if (taxform.t1s3f1.ToUpper() == "MARRIED2")
                    {
                        slDoc.SetCellValue("F86", "MARRIED+");
                    }
                    else
                    {
                        slDoc.SetCellValue("F86", taxform.t1s3f1.ToUpper());
                    }

                    slDoc.SetCellValue("F87", taxform.t1s3f2);
                    if (!string.IsNullOrEmpty(taxform.t1s3f3) && taxform.t1s3f3 != "0")
                    {
                        slDoc.SetCellValue("F88", Convert.ToDouble(taxform.t1s3f3));
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(taxform.t1s3f1) || taxform.t1s3f1 == "")
                        {
                            debugtext = "Please set Marital Status on step 3 general information ";
                        }
                        else
                        {
                            vm.Marital _marital = _servicesMarital.GetByYearAndStatus(taxform.year, taxform.t1s3f1);
                            var t1s3f3 = 0;
                            var t1s3f2 = 0;
                            if (!string.IsNullOrEmpty(taxform.t1s3f2))
                            {
                                t1s3f2 = Convert.ToInt32(taxform.t1s3f2);
                            }
                            t1s3f3 = _marital.amount + (t1s3f2 * _marital.dependant);
                            slDoc.SetCellValue("F88", Convert.ToDouble(t1s3f3));
                        }
                    }
                    //loop family

                    debugtext = "DEBUG 4 ";
                    if (!string.IsNullOrEmpty(taxform.t1s4f1))
                    {
                        slDoc.SetCellValue("D106", Convert.ToDouble(taxform.t1s4f1));
                    }
                    slDoc.SetCellValue("H106", taxform.t1s4f2);
                    if (!string.IsNullOrEmpty(taxform.t1s4f3))
                    {
                        slDoc.SetCellValue("K106", Convert.ToDouble(taxform.t1s4f3));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f4))
                    {
                        slDoc.SetCellValue("O106", Convert.ToDouble(taxform.t1s4f4));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f5))
                    {
                        slDoc.SetCellValue("D107", Convert.ToDouble(taxform.t1s4f5));
                    }
                    slDoc.SetCellValue("H107", taxform.t1s4f6);
                    if (!string.IsNullOrEmpty(taxform.t1s4f7))
                    {
                        slDoc.SetCellValue("K107", Convert.ToDouble(taxform.t1s4f7));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f8))
                    {
                        slDoc.SetCellValue("O107", Convert.ToDouble(taxform.t1s4f8));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f9))
                    {
                        slDoc.SetCellValue("D108", Convert.ToDouble(taxform.t1s4f9));
                    }
                    slDoc.SetCellValue("H108", taxform.t1s4f10);
                    if (!string.IsNullOrEmpty(taxform.t1s4f9))
                    {
                        slDoc.SetCellValue("K108", Convert.ToDouble(taxform.t1s4f11));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f12))
                    {
                        slDoc.SetCellValue("O108", Convert.ToDouble(taxform.t1s4f12));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f13))
                    {
                        slDoc.SetCellValue("D109", Convert.ToDouble(taxform.t1s4f13));
                    }
                    slDoc.SetCellValue("H109", taxform.t1s4f14);
                    if (!string.IsNullOrEmpty(taxform.t1s4f15))
                    {
                        slDoc.SetCellValue("K109", Convert.ToDouble(taxform.t1s4f15));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f16))
                    {
                        slDoc.SetCellValue("O109", Convert.ToDouble(taxform.t1s4f16));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f17))
                    {
                        slDoc.SetCellValue("D110", Convert.ToDouble(taxform.t1s4f17));
                    }
                    slDoc.SetCellValue("H110", taxform.t1s4f18);
                    if (!string.IsNullOrEmpty(taxform.t1s4f19))
                    {
                        slDoc.SetCellValue("K110", Convert.ToDouble(taxform.t1s4f19));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f20))
                    {
                        slDoc.SetCellValue("O110", Convert.ToDouble(taxform.t1s4f20));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f21))
                    {
                        slDoc.SetCellValue("D111", Convert.ToDouble(taxform.t1s4f21));
                    }
                    slDoc.SetCellValue("H111", taxform.t1s4f22);
                    if (!string.IsNullOrEmpty(taxform.t1s4f23))
                    {
                        slDoc.SetCellValue("K111", Convert.ToDouble(taxform.t1s4f23));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f24))
                    {
                        slDoc.SetCellValue("O111", Convert.ToDouble(taxform.t1s4f24));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f25))
                    {
                        slDoc.SetCellValue("D112", Convert.ToDouble(taxform.t1s4f25));
                    }
                    slDoc.SetCellValue("H112", taxform.t1s4f26);
                    if (!string.IsNullOrEmpty(taxform.t1s4f27))
                    {
                        slDoc.SetCellValue("K112", Convert.ToDouble(taxform.t1s4f27));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f28))
                    {
                        slDoc.SetCellValue("O112", Convert.ToDouble(taxform.t1s4f28));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f29))
                    {
                        slDoc.SetCellValue("D113", Convert.ToDouble(taxform.t1s4f29));
                    }
                    slDoc.SetCellValue("H113", taxform.t1s4f30);
                    if (!string.IsNullOrEmpty(taxform.t1s4f31))
                    {
                        slDoc.SetCellValue("K113", Convert.ToDouble(taxform.t1s4f31));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f32))
                    {
                        slDoc.SetCellValue("O113", Convert.ToDouble(taxform.t1s4f32));
                    }


                    if (!string.IsNullOrEmpty(taxform.t1s4f33))
                    {
                        slDoc.SetCellValue("D114", Convert.ToDouble(taxform.t1s4f33));
                    }
                    slDoc.SetCellValue("H114", taxform.t1s4f34);
                    if (!string.IsNullOrEmpty(taxform.t1s4f35))
                    {
                        slDoc.SetCellValue("K114", Convert.ToDouble(taxform.t1s4f35));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f36))
                    {
                        slDoc.SetCellValue("O114", Convert.ToDouble(taxform.t1s4f36));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f37))
                    {
                        slDoc.SetCellValue("D115", Convert.ToDouble(taxform.t1s4f37));
                    }
                    slDoc.SetCellValue("H115", taxform.t1s4f38);
                    if (!string.IsNullOrEmpty(taxform.t1s4f39))
                    {
                        slDoc.SetCellValue("K115", Convert.ToDouble(taxform.t1s4f39));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f40))
                    {
                        slDoc.SetCellValue("O115", Convert.ToDouble(taxform.t1s4f40));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f41))
                    {
                        slDoc.SetCellValue("D116", Convert.ToDouble(taxform.t1s4f41));
                    }
                    slDoc.SetCellValue("H116", taxform.t1s4f42);

                    if (!string.IsNullOrEmpty(taxform.t1s4f43))
                    {
                        slDoc.SetCellValue("K116", Convert.ToDouble(taxform.t1s4f43));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f44))
                    {
                        slDoc.SetCellValue("O116", Convert.ToDouble(taxform.t1s4f44));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f45))
                    {
                        slDoc.SetCellValue("D117", Convert.ToDouble(taxform.t1s4f45));
                    }
                    slDoc.SetCellValue("H117", taxform.t1s4f46);
                    if (!string.IsNullOrEmpty(taxform.t1s4f47))
                    {
                        slDoc.SetCellValue("K117", Convert.ToDouble(taxform.t1s4f47));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f48))
                    {
                        slDoc.SetCellValue("O117", Convert.ToDouble(taxform.t1s4f48));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f55))
                    {
                        slDoc.SetCellValue("K123", Convert.ToDouble(taxform.t1s4f55));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s6f1))
                    {
                        slDoc.SetCellValue("L164", Convert.ToDouble(taxform.t1s6f1));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f2))
                    {
                        slDoc.SetCellValue("Q164", Convert.ToDouble(taxform.t1s6f2));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f4))
                    {
                        slDoc.SetCellValue("L165", Convert.ToDouble(taxform.t1s6f4));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f5))
                    {
                        slDoc.SetCellValue("Q165", Convert.ToDouble(taxform.t1s6f5));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f7))
                    {
                        slDoc.SetCellValue("L166", Convert.ToDouble(taxform.t1s6f7));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f8))
                    {
                        slDoc.SetCellValue("Q166", Convert.ToDouble(taxform.t1s6f8));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f10))
                    {
                        slDoc.SetCellValue("L167", Convert.ToDouble(taxform.t1s6f10));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f11))
                    {
                        slDoc.SetCellValue("Q167", Convert.ToDouble(taxform.t1s6f11));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f13))
                    {
                        slDoc.SetCellValue("L168", Convert.ToDouble(taxform.t1s6f13));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f14))
                    {
                        slDoc.SetCellValue("Q168", Convert.ToDouble(taxform.t1s6f14));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f16))
                    {
                        slDoc.SetCellValue("L169", Convert.ToDouble(taxform.t1s6f16));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f17))
                    {
                        slDoc.SetCellValue("Q169", Convert.ToDouble(taxform.t1s6f17));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f22))
                    {
                        slDoc.SetCellValue("L173", Convert.ToDouble(taxform.t1s6f22));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f23))
                    {
                        slDoc.SetCellValue("Q173", Convert.ToDouble(taxform.t1s6f23));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f25))
                    {
                        slDoc.SetCellValue("V174", Convert.ToDouble(taxform.t1s6f25));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f1))
                    {
                        slDoc.SetCellValue("O180", Convert.ToDouble(taxform.t1s7f1));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f2))
                    {
                        slDoc.SetCellValue("T180", Convert.ToDouble(taxform.t1s7f2));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f3))
                    {
                        slDoc.SetCellValue("O181", Convert.ToDouble(taxform.t1s7f3));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f4))
                    {
                        slDoc.SetCellValue("T181", Convert.ToDouble(taxform.t1s7f4));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f5))
                    {
                        slDoc.SetCellValue("O182", Convert.ToDouble(taxform.t1s7f5));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f6))
                    {
                        slDoc.SetCellValue("T182", Convert.ToDouble(taxform.t1s7f6));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f7))
                    {
                        slDoc.SetCellValue("O183", Convert.ToDouble(taxform.t1s7f7));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f8))
                    {
                        slDoc.SetCellValue("T183", Convert.ToDouble(taxform.t1s7f8));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f9))
                    {
                        slDoc.SetCellValue("O184", Convert.ToDouble(taxform.t1s7f9));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f10))
                    {
                        slDoc.SetCellValue("T184", Convert.ToDouble(taxform.t1s7f10));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f11))
                    {
                        slDoc.SetCellValue("O185", Convert.ToDouble(taxform.t1s7f11));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f12))
                    {
                        slDoc.SetCellValue("T185", Convert.ToDouble(taxform.t1s7f12));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f13))
                    {
                        slDoc.SetCellValue("O186", Convert.ToDouble(taxform.t1s7f13));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f14))
                    {
                        slDoc.SetCellValue("T186", Convert.ToDouble(taxform.t1s7f14));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f15))
                    {
                        slDoc.SetCellValue("O187", Convert.ToDouble(taxform.t1s7f15));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f16))
                    {
                        slDoc.SetCellValue("T187", Convert.ToDouble(taxform.t1s7f16));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f17))
                    {
                        slDoc.SetCellValue("O188", Convert.ToDouble(taxform.t1s7f17));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f18))
                    {
                        slDoc.SetCellValue("T188", Convert.ToDouble(taxform.t1s7f18));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f19))
                    {
                        slDoc.SetCellValue("O189", Convert.ToDouble(taxform.t1s7f19));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f20))
                    {
                        slDoc.SetCellValue("T189", Convert.ToDouble(taxform.t1s7f20));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f21))
                    {
                        slDoc.SetCellValue("O191", Convert.ToDouble(taxform.t1s7f21));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f22))
                    {
                        slDoc.SetCellValue("T191", Convert.ToDouble(taxform.t1s7f22));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f23))
                    {
                        slDoc.SetCellValue("O192", Convert.ToDouble(taxform.t1s7f23));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f24))
                    {
                        slDoc.SetCellValue("T192", Convert.ToDouble(taxform.t1s7f24));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f25))
                    {
                        slDoc.SetCellValue("O193", Convert.ToDouble(taxform.t1s7f25));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f26))
                    {
                        slDoc.SetCellValue("T193", Convert.ToDouble(taxform.t1s7f26));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f27))
                    {
                        slDoc.SetCellValue("O194", Convert.ToDouble(taxform.t1s7f27));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f28))
                    {
                        slDoc.SetCellValue("T194", Convert.ToDouble(taxform.t1s7f28));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f29))
                    {
                        slDoc.SetCellValue("O195", Convert.ToDouble(taxform.t1s7f29));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f30))
                    {
                        slDoc.SetCellValue("T195", Convert.ToDouble(taxform.t1s7f30));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s7f33))
                    {
                        slDoc.SetCellValue("O201", Convert.ToDouble(taxform.t1s7f33));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f34))
                    {
                        slDoc.SetCellValue("O202", Convert.ToDouble(taxform.t1s7f34));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f35))
                    {
                        slDoc.SetCellValue("O203", Convert.ToDouble(taxform.t1s7f35));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f36))
                    {
                        slDoc.SetCellValue("O204", Convert.ToDouble(taxform.t1s7f36));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f37))
                    {
                        slDoc.SetCellValue("O205", Convert.ToDouble(taxform.t1s7f37));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f38))
                    {
                        slDoc.SetCellValue("O206", Convert.ToDouble(taxform.t1s7f38));
                    }


                    debugtext = "DEBUG 5 ";
                    if (taxform.t1s8f1 == "True")
                    {
                        slDoc.SetCellValue("B212", "X");
                    }
                    if (taxform.t1s8f2 == "True")
                    {
                        slDoc.SetCellValue("G212", "X");
                    }
                    if (taxform.t1s8f3 == "True")
                    {
                        slDoc.SetCellValue("K212", "X");
                    }
                    if (taxform.t1s8f4 == "True")
                    {
                        slDoc.SetCellValue("P212", "X");
                    }
                    if (taxform.t1s8f5 == "True")
                    {
                        slDoc.SetCellValue("U212", "X");
                    }
                    if (taxform.t1s8f32 == "True")
                    {
                        slDoc.SetCellValue("B243", "X");
                    }

                    string t1s8f11 = taxform.t1s8f11.Replace(".", "");
                    t1s8f11 = t1s8f11.Replace("-", "");
                    string t1s8f13 = taxform.t1s8f13.Replace(".", "");
                    t1s8f13 = t1s8f13.Replace("-", "");

                    slDoc.SetCellValue("G213", taxform.t1s8f10);
                    slDoc.SetCellValue("G214", t1s8f11);
                    slDoc.SetCellValue("G215", taxform.t1s8f12);
                    slDoc.SetCellValue("G216", t1s8f13);


                    if (!string.IsNullOrEmpty(taxform.t1s8f14))
                    {
                        slDoc.SetCellValue("Q219", Convert.ToDouble(taxform.t1s8f14));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f15))
                    {
                        slDoc.SetCellValue("Q220", Convert.ToDouble(taxform.t1s8f15));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f16))
                    {
                        slDoc.SetCellValue("Q221", Convert.ToDouble(taxform.t1s8f16));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s8f17))
                    {
                        slDoc.SetCellValue("Q224", Convert.ToDouble(taxform.t1s8f17));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f18))
                    {
                        slDoc.SetCellValue("Q225", Convert.ToDouble(taxform.t1s8f18));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f19))
                    {
                        slDoc.SetCellValue("Q226", Convert.ToDouble(taxform.t1s8f19));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f20))
                    {
                        slDoc.SetCellValue("Q227", Convert.ToDouble(taxform.t1s8f20));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f21))
                    {
                        slDoc.SetCellValue("Q228", Convert.ToDouble(taxform.t1s8f21));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f22))
                    {
                        slDoc.SetCellValue("Q229", Convert.ToDouble(taxform.t1s8f22));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f23))
                    {
                        slDoc.SetCellValue("Q230", Convert.ToDouble(taxform.t1s8f23));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f24))
                    {
                        slDoc.SetCellValue("Q231", Convert.ToDouble(taxform.t1s8f24));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f25))
                    {
                        slDoc.SetCellValue("Q232", Convert.ToDouble(taxform.t1s8f25));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f26))
                    {
                        slDoc.SetCellValue("Q233", Convert.ToDouble(taxform.t1s8f26));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f27))
                    {
                        slDoc.SetCellValue("Q234", Convert.ToDouble(taxform.t1s8f27));
                    }


                    if (!string.IsNullOrEmpty(taxform.t1s8f28))
                    {
                        slDoc.SetCellValue("Q237", Convert.ToDouble(taxform.t1s8f28));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f29))
                    {
                        slDoc.SetCellValue("Q238", Convert.ToDouble(taxform.t1s8f29));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f30))
                    {
                        slDoc.SetCellValue("Q239", Convert.ToDouble(taxform.t1s8f30));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f31))
                    {
                        slDoc.SetCellValue("Q241", Convert.ToDouble(taxform.t1s8f31));
                    }


                    if (!string.IsNullOrEmpty(taxform.t1s8f33))
                    {
                        slDoc.SetCellValue("L245", Convert.ToDouble(taxform.t1s8f33));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f34))
                    {
                        slDoc.SetCellValue("Q245", Convert.ToDouble(taxform.t1s8f34) / 100);
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f35))
                    {
                        slDoc.SetCellValue("L246", Convert.ToDouble(taxform.t1s8f35));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f36))
                    {
                        slDoc.SetCellValue("Q246", Convert.ToDouble(taxform.t1s8f36) / 100);
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f37))
                    {
                        slDoc.SetCellValue("L247", Convert.ToDouble(taxform.t1s8f37));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f38))
                    {
                        slDoc.SetCellValue("Q247", Convert.ToDouble(taxform.t1s8f38) / 100);
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f39))
                    {
                        slDoc.SetCellValue("L248", Convert.ToDouble(taxform.t1s8f39));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f40))
                    {
                        slDoc.SetCellValue("Q248", Convert.ToDouble(taxform.t1s8f40) / 100);
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f41))
                    {
                        slDoc.SetCellValue("L249", Convert.ToDouble(taxform.t1s8f41));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f42))
                    {
                        slDoc.SetCellValue("Q249", Convert.ToDouble(taxform.t1s8f42) / 100);
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f43))
                    {
                        slDoc.SetCellValue("Q251", Convert.ToDouble(taxform.t1s8f43));
                    }

                    debugtext = "DEBUG 6 ";
                    List<vm.Family> families = _servicesFamily.GetAllBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, taxform.ammend);
                    a = 0;
                    foreach (vm.Family data in families)
                    {
                        if (a < 5)
                        {
                            slDoc.SetCellValue("C" + ((a * 1) + 93), data.Name);
                            slDoc.SetCellValue("E" + ((a * 1) + 93), data.Relationship);
                            slDoc.SetCellValue("J" + ((a * 1) + 93), data.Birthdate);
                            slDoc.SetCellValue("N" + ((a * 1) + 93), data.Occupation);
                            slDoc.SetCellValue("R" + ((a * 1) + 93), data.NIK);
                        }
                        a++;
                    }

                    debugtext = "DEBUG 7 ";
                    List<vm.IEIncome> ieincome = _servicesIncome.GetAllBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, taxform.ammend);
                    a = 0;
                    debugtext = "DEBUG 7a ";
                    foreach (vm.IEIncome data in ieincome)
                    {
                        if (a < 3)
                        {
                            string col = "";
                            string col2 = "";
                            if (a == 0)
                            {
                                col = "G";
                                col2 = "J";
                            }
                            else if (a == 1)
                            {
                                col = "L";
                                col2 = "O";
                            }
                            else if (a == 2)
                            {
                                col = "Q";
                                col2 = "T";
                            }

                            string dataf1 = "";
                            string dataf2 = "";

                            if (!string.IsNullOrEmpty(data.field1))
                            {
                                string[] f1 = data.field1.ToString().Split('/');
                                dataf1 = f1[1] + "/" + f1[0] + "/" + f1[2];
                            }
                            if (!string.IsNullOrEmpty(data.field2))
                            {
                                string[] f2 = data.field2.ToString().Split('/');
                                dataf2 = f2[1] + "/" + f2[0] + "/" + f2[2];
                            }

                            debugtext = "DEBUG 7b " + data.field1 + "-" + data.field2;
                            if (dataf1 != "")
                            {
                                slDoc.SetCellValue(col + "129", Convert.ToDateTime(dataf1));
                            }
                            if (dataf2 != "")
                            {
                                slDoc.SetCellValue(col2 + "129", Convert.ToDateTime(dataf2));
                            }

                            string field5 = data.field5.Replace(".", "");
                            field5 = field5.Replace("-", "");
                            string field6 = data.field6.Replace(".", "");
                            field6 = field6.Replace("-", "");

                            slDoc.SetCellValue(col + "131", data.field4);
                            slDoc.SetCellValue(col + "132", field5);
                            slDoc.SetCellValue(col + "133", field6);
                            string dataf7 = "";
                            if (!string.IsNullOrEmpty(data.field7))
                            {
                                string[] f7 = data.field7.ToString().Split('/');
                                dataf7 = f7[1] + "/" + f7[0] + "/" + f7[2];
                            }
                            if (dataf7 != "")
                            {
                                slDoc.SetCellValue(col + "134", Convert.ToDateTime(dataf7));
                            }
                            if (data.field8 == "Yes")
                            {
                                slDoc.SetCellValue(col + "135", "X");
                            }

                            debugtext = "DEBUG 7c ";
                            if (!string.IsNullOrEmpty(data.field9))
                            {
                                slDoc.SetCellValue(col + "139", Convert.ToDouble(data.field9));
                            }
                            debugtext = "DEBUG 7d ";
                            if (!string.IsNullOrEmpty(data.field10))
                            {
                                slDoc.SetCellValue(col + "140", Convert.ToDouble(data.field10));
                            }
                            if (!string.IsNullOrEmpty(data.field11))
                            {
                                slDoc.SetCellValue(col + "141", Convert.ToDouble(data.field11));
                            }
                            if (!string.IsNullOrEmpty(data.field12))
                            {
                                slDoc.SetCellValue(col + "142", Convert.ToDouble(data.field12));
                            }
                            if (!string.IsNullOrEmpty(data.field13))
                            {
                                slDoc.SetCellValue(col + "143", Convert.ToDouble(data.field13));
                            }
                            if (!string.IsNullOrEmpty(data.field14))
                            {
                                slDoc.SetCellValue(col + "144", Convert.ToDouble(data.field14));
                            }
                            if (!string.IsNullOrEmpty(data.field15))
                            {
                                slDoc.SetCellValue(col + "145", Convert.ToDouble(data.field15));
                            }
                            if (!string.IsNullOrEmpty(data.field17))
                            {
                                slDoc.SetCellValue(col + "149", Convert.ToDouble(data.field17));
                            }
                            if (!string.IsNullOrEmpty(data.field18))
                            {
                                slDoc.SetCellValue(col + "150", Convert.ToDouble(data.field18));
                            }
                            if (!string.IsNullOrEmpty(data.field21))
                            {
                                slDoc.SetCellValue(col + "155", Convert.ToDouble(data.field21));
                            }
                            if (!string.IsNullOrEmpty(data.field22))
                            {
                                slDoc.SetCellValue(col + "158", Convert.ToDouble(data.field22));
                            }

                            if (!string.IsNullOrEmpty(data.field23))
                            {
                                slDoc.SetCellValue(col + "159", Convert.ToDouble(data.field23));
                            }

                        }
                        a++;
                    }

                    debugtext = "DEBUG 8 ";
                    //======================================
                    slDoc.SelectWorksheet("OVERSEAS INCOME");

                    List<string> countryList = new List<string>();
                    countryList.Add("Afganistan");
                    countryList.Add("Albania");
                    countryList.Add("Algeria");
                    countryList.Add("American Samoa");
                    countryList.Add("Andorra");
                    countryList.Add("Angola");
                    countryList.Add("Anguilla");
                    countryList.Add("Antigua &amp; Barbuda");
                    countryList.Add("Argentina");
                    countryList.Add("Armenia");
                    countryList.Add("Aruba");
                    countryList.Add("Australia");
                    countryList.Add("Austria");
                    countryList.Add("Azerbaijan");
                    countryList.Add("Bahamas");
                    countryList.Add("Bahrain");
                    countryList.Add("Bangladesh");
                    countryList.Add("Barbados");
                    countryList.Add("Belarus");
                    countryList.Add("Belgium");
                    countryList.Add("Belize");
                    countryList.Add("Benin");
                    countryList.Add("Bermuda");
                    countryList.Add("Bhutan");
                    countryList.Add("Bolivia");
                    countryList.Add("Bonaire");
                    countryList.Add("Bosnia &amp; Herzegovina");
                    countryList.Add("Botswana");
                    countryList.Add("Brazil");
                    countryList.Add("British Indian Ocean Ter");
                    countryList.Add("Brunei");
                    countryList.Add("Bulgaria");
                    countryList.Add("Burkina Faso");
                    countryList.Add("Burundi");
                    countryList.Add("Cambodia");
                    countryList.Add("Cameroon");
                    countryList.Add("Canada");
                    countryList.Add("Canary Islands");
                    countryList.Add("Cape Verde");
                    countryList.Add("Cayman Islands");
                    countryList.Add("Central African Republic");
                    countryList.Add("Chad");
                    countryList.Add("Channel Islands");
                    countryList.Add("Chile");
                    countryList.Add("China");
                    countryList.Add("Christmas Island");
                    countryList.Add("Cocos Island");
                    countryList.Add("Colombia");
                    countryList.Add("Comoros");
                    countryList.Add("Congo");
                    countryList.Add("Cook Islands");
                    countryList.Add("Costa Rica");
                    countryList.Add("Cote DIvoire");
                    countryList.Add("Croatia");
                    countryList.Add("Cuba");
                    countryList.Add("Curaco");
                    countryList.Add("Cyprus");
                    countryList.Add("Czech Republic");
                    countryList.Add("Denmark");
                    countryList.Add("Djibouti");
                    countryList.Add("Dominica");
                    countryList.Add("Dominican Republic");
                    countryList.Add("East Timor");
                    countryList.Add("Ecuador");
                    countryList.Add("Egypt");
                    countryList.Add("El Salvador");
                    countryList.Add("Equatorial Guinea");
                    countryList.Add("Eritrea");
                    countryList.Add("Estonia");
                    countryList.Add("Ethiopia");
                    countryList.Add("Falkland Islands");
                    countryList.Add("Faroe Islands");
                    countryList.Add("Fiji");
                    countryList.Add("Finland");
                    countryList.Add("France");
                    countryList.Add("French Guiana");
                    countryList.Add("French Polynesia");
                    countryList.Add("French Southern Ter");
                    countryList.Add("Gabon");
                    countryList.Add("Gambia");
                    countryList.Add("Georgia");
                    countryList.Add("Germany");
                    countryList.Add("Ghana");
                    countryList.Add("Gibraltar");
                    countryList.Add("Great Britain");
                    countryList.Add("Greece");
                    countryList.Add("Greenland");
                    countryList.Add("Grenada");
                    countryList.Add("Guadeloupe");
                    countryList.Add("Guam");
                    countryList.Add("Guatemala");
                    countryList.Add("Guinea");
                    countryList.Add("Guyana");
                    countryList.Add("Haiti");
                    countryList.Add("Hawaii");
                    countryList.Add("Honduras");
                    countryList.Add("Hong Kong");
                    countryList.Add("Hungary");
                    countryList.Add("Iceland");
                    countryList.Add("India");
                    countryList.Add("Indonesia");
                    countryList.Add("Iran");
                    countryList.Add("Iraq");
                    countryList.Add("Ireland");
                    countryList.Add("Isle of Man");
                    countryList.Add("Israel");
                    countryList.Add("Italy");
                    countryList.Add("Jamaica");
                    countryList.Add("Japan");
                    countryList.Add("Jordan");
                    countryList.Add("Kazakhstan");
                    countryList.Add("Kenya");
                    countryList.Add("Kiribati");
                    countryList.Add("Korea North");
                    countryList.Add("Korea Sout");
                    countryList.Add("Kuwait");
                    countryList.Add("Kyrgyzstan");
                    countryList.Add("Laos");
                    countryList.Add("Latvia");
                    countryList.Add("Lebanon");
                    countryList.Add("Lesotho");
                    countryList.Add("Liberia");
                    countryList.Add("Libya");
                    countryList.Add("Liechtenstein");
                    countryList.Add("Lithuania");
                    countryList.Add("Luxembourg");
                    countryList.Add("Macau");
                    countryList.Add("Macedonia");
                    countryList.Add("Madagascar");
                    countryList.Add("Malaysia");
                    countryList.Add("Malawi");
                    countryList.Add("Maldives");
                    countryList.Add("Mali");
                    countryList.Add("Malta");
                    countryList.Add("Marshall Islands");
                    countryList.Add("Martinique");
                    countryList.Add("Mauritania");
                    countryList.Add("Mauritius");
                    countryList.Add("Mayotte");
                    countryList.Add("Mexico");
                    countryList.Add("Midway Islands");
                    countryList.Add("Moldova");
                    countryList.Add("Monaco");
                    countryList.Add("Mongolia");
                    countryList.Add("Montserrat");
                    countryList.Add("Morocco");
                    countryList.Add("Mozambique");
                    countryList.Add("Myanmar");
                    countryList.Add("Nambia");
                    countryList.Add("Nauru");
                    countryList.Add("Nepal");
                    countryList.Add("Netherland Antilles");
                    countryList.Add("Netherlands");
                    countryList.Add("Nevis");
                    countryList.Add("New Caledonia");
                    countryList.Add("New Zealand");
                    countryList.Add("Nicaragua");
                    countryList.Add("Niger");
                    countryList.Add("Nigeria");
                    countryList.Add("Niue");
                    countryList.Add("Norfolk Island");
                    countryList.Add("Norway");
                    countryList.Add("Oman");
                    countryList.Add("Pakistan");
                    countryList.Add("Palau Island");
                    countryList.Add("Palestine");
                    countryList.Add("Panama");
                    countryList.Add("Papua New Guinea");
                    countryList.Add("Paraguay");
                    countryList.Add("Peru");
                    countryList.Add("Phillipines");
                    countryList.Add("Pitcairn Island");
                    countryList.Add("Poland");
                    countryList.Add("Portugal");
                    countryList.Add("Puerto Rico");
                    countryList.Add("Qatar");
                    countryList.Add("Republic of Montenegro");
                    countryList.Add("Republic of Serbia");
                    countryList.Add("Reunion");
                    countryList.Add("Romania");
                    countryList.Add("Russia");
                    countryList.Add("Rwanda");
                    countryList.Add("St Barthelemy");
                    countryList.Add("St Eustatius");
                    countryList.Add("St Helena");
                    countryList.Add("St Kitts-Nevis");
                    countryList.Add("St Lucia");
                    countryList.Add("St Maarten");
                    countryList.Add("St Pierre &amp; Miquelon");
                    countryList.Add("St Vincent &amp; Grenadines");
                    countryList.Add("Saipan");
                    countryList.Add("Samoa");
                    countryList.Add("Samoa American");
                    countryList.Add("San Marino");
                    countryList.Add("Sao Tome &amp; Principe");
                    countryList.Add("Saudi Arabia");
                    countryList.Add("Senegal");
                    countryList.Add("Serbia");
                    countryList.Add("Seychelles");
                    countryList.Add("Sierra Leone");
                    countryList.Add("Singapore");
                    countryList.Add("Slovakia");
                    countryList.Add("Slovenia");
                    countryList.Add("Solomon Islands");
                    countryList.Add("Somalia");
                    countryList.Add("South Africa");
                    countryList.Add("Spain");
                    countryList.Add("Sri Lanka");
                    countryList.Add("Sudan");
                    countryList.Add("Suriname");
                    countryList.Add("Swaziland");
                    countryList.Add("Sweden");
                    countryList.Add("Switzerland");
                    countryList.Add("Syria");
                    countryList.Add("Tahiti");
                    countryList.Add("Taiwan");
                    countryList.Add("Tajikistan");
                    countryList.Add("Tanzania");
                    countryList.Add("Thailand");
                    countryList.Add("Togo");
                    countryList.Add("Tokelau");
                    countryList.Add("Tonga");
                    countryList.Add("Trinidad &amp; Tobago");
                    countryList.Add("Tunisia");
                    countryList.Add("Turkey");
                    countryList.Add("Turkmenistan");
                    countryList.Add("Turks &amp; Caicos Is");
                    countryList.Add("Tuvalu");
                    countryList.Add("Uganda");
                    countryList.Add("Ukraine");
                    countryList.Add("United Arab Erimates");
                    countryList.Add("United Kingdom");
                    countryList.Add("United States of America");
                    countryList.Add("Uraguay");
                    countryList.Add("Uzbekistan");
                    countryList.Add("Vanuatu");
                    countryList.Add("Vatican City State");
                    countryList.Add("Venezuela");
                    countryList.Add("Vietnam");
                    countryList.Add("Virgin Islands (Brit)");
                    countryList.Add("Virgin Islands (USA)");
                    countryList.Add("Wake Island");
                    countryList.Add("Wallis &amp; Futana Is");
                    countryList.Add("Yemen");
                    countryList.Add("Zaire");
                    countryList.Add("Zambia");
                    countryList.Add("Zimbabwe");

                    List<vm.Irregulardata> Irregulardatas = new List<vm.Irregulardata>();

                    List<vm.OverseasIncome> ovincome;
                    List<string> countries = new List<string>();
                    var ir = 0;
                    foreach (string country in countryList)
                    {
                        ovincome = _servicesOvIncome.GetAllBy3(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, country, 1, taxform.ammend);
                        int b = 0;
                        if (ovincome.Count > 0)
                        {
                            if (!countries.Any(f => f == ovincome[0].country) && countries.Count < 4)
                            {
                                countries.Add(ovincome[0].country);
                            }
                        }
                        foreach (vm.OverseasIncome data in ovincome)
                        {
                            a = countries.FindIndex(z => z == data.country);
                            if (a >= 0 && a < 4)
                            {
                                slDoc.SetCellValue("K" + ((a * 151) + 8), data.country);
                                string datereceipt = "";
                                string year = "";
                                string month = "";
                                if (data.dateofreceipt != "" && data.interval != "4")
                                {
                                    year = data.dateofreceipt.Split('/')[2];
                                    if (year.Length == 4)
                                    {
                                        year = year.Substring(2, 2);
                                    }
                                    month = data.dateofreceipt.Split('/')[1];
                                    datereceipt = data.dateofreceipt.Split('/')[1] + "/" + data.dateofreceipt.Split('/')[0] + "/" + year;
                                    //datereceipt = data.dateofreceipt;
                                }

                                if (data.interval == "4")
                                {
                                    string thedate = data.dateofreceipt;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("B" + ((a * 151) + (b + 15)), thedate);
                                }
                                else if (data.interval == "3")
                                {
                                    slDoc.SetCellValue("B" + ((a * 151) + (b + 15)), "JanDec" + year);
                                }
                                else if (data.interval == "2")
                                {
                                    string mnt = "";
                                    if (month == "01")
                                    {
                                        mnt = "Jan";
                                    }
                                    else if (month == "02")
                                    {
                                        mnt = "Feb";
                                    }
                                    else if (month == "03")
                                    {
                                        mnt = "Mar";
                                    }
                                    else if (month == "04")
                                    {
                                        mnt = "Apr";
                                    }
                                    else if (month == "05")
                                    {
                                        mnt = "May";
                                    }
                                    else if (month == "06")
                                    {
                                        mnt = "Jun";
                                    }
                                    else if (month == "07")
                                    {
                                        mnt = "Jul";
                                    }
                                    else if (month == "08")
                                    {
                                        mnt = "Aug";
                                    }
                                    else if (month == "09")
                                    {
                                        mnt = "Sep";
                                    }
                                    else if (month == "10")
                                    {
                                        mnt = "Oct";
                                    }
                                    else if (month == "11")
                                    {
                                        mnt = "Nov";
                                    }
                                    else if (month == "12")
                                    {
                                        mnt = "Dec";
                                    }
                                    slDoc.SetCellValue("B" + ((a * 151) + (b + 15)), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("B" + ((a * 151) + (b + 15)), Convert.ToDateTime(datereceipt));
                                }
                                slDoc.SetCellValue("E" + ((a * 151) + (b + 15)), data.currency);
                                if (!string.IsNullOrEmpty(data.incomecurrency))
                                {
                                    slDoc.SetCellValue("G" + ((a * 151) + (b + 15)), Convert.ToDouble(data.incomecurrency));
                                }
                                if (!string.IsNullOrEmpty(data.taxpaidcurrency))
                                {
                                    slDoc.SetCellValue("K" + ((a * 151) + (b + 15)), Convert.ToDouble(data.taxpaidcurrency));
                                }
                                if (!string.IsNullOrEmpty(data.exchrate))
                                {
                                    slDoc.SetCellValue("O" + ((a * 151) + (b + 15)), Convert.ToDouble(data.exchrate));
                                }
                                if (!string.IsNullOrEmpty(data.treatyrate))
                                {
                                    slDoc.SetCellValue("Y" + ((a * 151) + (b + 15)), Convert.ToDouble(data.treatyrate));
                                }

                                if (data.irregularincome == "yes" && ir <= 15)
                                {
                                    vm.Irregulardata dataexist = Irregulardatas.Find(x => x.country == data.country && x.typeincome == "Dividend Income");
                                    if (dataexist == null)
                                    {
                                        vm.Irregulardata irregulardata = new vm.Irregulardata();
                                        irregulardata.ir = ir;
                                        irregulardata.country = data.country;
                                        irregulardata.typeincome = "Dividend Income";
                                        irregulardata.bil1 = Convert.ToDouble(data.incomerp);
                                        irregulardata.bil2 = Convert.ToDouble(data.taxpaidrp);

                                        Irregulardatas.Add(irregulardata);
                                        ir++;
                                    }
                                    else
                                    {
                                        vm.Irregulardata irregulardata = new vm.Irregulardata();
                                        irregulardata.ir = dataexist.ir;
                                        irregulardata.country = dataexist.country;
                                        irregulardata.typeincome = dataexist.typeincome;
                                        irregulardata.bil1 = dataexist.bil1 + Convert.ToDouble(data.incomerp);
                                        irregulardata.bil2 = dataexist.bil2 + Convert.ToDouble(data.taxpaidrp);

                                        Irregulardatas[dataexist.ir] = irregulardata;
                                    }
                                }
                                b++;
                            }
                        }
                    }


                    foreach (string country in countryList)
                    {
                        ovincome = _servicesOvIncome.GetAllBy3(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, country, 2, taxform.ammend);
                        int b = 0;
                        if (ovincome.Count > 0)
                        {
                            if (!countries.Any(f => f == ovincome[0].country) && countries.Count < 4)
                            {
                                countries.Add(ovincome[0].country);
                            }
                        }
                        foreach (vm.OverseasIncome data in ovincome)
                        {
                            a = countries.FindIndex(z => z == data.country);
                            if (a >= 0 && a < 4)
                            {
                                slDoc.SetCellValue("K" + ((a * 151) + 8), data.country);
                                string datereceipt = "";
                                string year = "";
                                string month = "";
                                if (data.dateofreceipt != "" && data.interval != "4")
                                {
                                    year = data.dateofreceipt.Split('/')[2];
                                    if (year.Length == 4)
                                    {
                                        year = year.Substring(2, 2);
                                    }
                                    month = data.dateofreceipt.Split('/')[1];
                                    datereceipt = data.dateofreceipt.Split('/')[1] + "/" + data.dateofreceipt.Split('/')[0] + "/" + year;
                                    //datereceipt = data.dateofreceipt;
                                }

                                if (data.interval == "4")
                                {
                                    string thedate = data.dateofreceipt;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("B" + ((a * 151) + (b + 40)), thedate);
                                }
                                else if (data.interval == "3")
                                {
                                    slDoc.SetCellValue("B" + ((a * 151) + (b + 40)), "JanDec" + year);
                                }
                                else if (data.interval == "2")
                                {
                                    string mnt = "";
                                    if (month == "01")
                                    {
                                        mnt = "Jan";
                                    }
                                    else if (month == "02")
                                    {
                                        mnt = "Feb";
                                    }
                                    else if (month == "03")
                                    {
                                        mnt = "Mar";
                                    }
                                    else if (month == "04")
                                    {
                                        mnt = "Apr";
                                    }
                                    else if (month == "05")
                                    {
                                        mnt = "May";
                                    }
                                    else if (month == "06")
                                    {
                                        mnt = "Jun";
                                    }
                                    else if (month == "07")
                                    {
                                        mnt = "Jul";
                                    }
                                    else if (month == "08")
                                    {
                                        mnt = "Aug";
                                    }
                                    else if (month == "09")
                                    {
                                        mnt = "Sep";
                                    }
                                    else if (month == "10")
                                    {
                                        mnt = "Oct";
                                    }
                                    else if (month == "11")
                                    {
                                        mnt = "Nov";
                                    }
                                    else if (month == "12")
                                    {
                                        mnt = "Dec";
                                    }
                                    slDoc.SetCellValue("B" + ((a * 151) + (b + 40)), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("B" + ((a * 151) + (b + 40)), Convert.ToDateTime(datereceipt));
                                }

                                slDoc.SetCellValue("E" + ((a * 151) + (b + 40)), data.currency);
                                if (!string.IsNullOrEmpty(data.incomecurrency))
                                {
                                    slDoc.SetCellValue("G" + ((a * 151) + (b + 40)), Convert.ToDouble(data.incomecurrency));
                                }
                                if (!string.IsNullOrEmpty(data.taxpaidcurrency))
                                {
                                    slDoc.SetCellValue("K" + ((a * 151) + (b + 40)), Convert.ToDouble(data.taxpaidcurrency));
                                }
                                if (!string.IsNullOrEmpty(data.exchrate))
                                {
                                    slDoc.SetCellValue("O" + ((a * 151) + (b + 40)), Convert.ToDouble(data.exchrate));
                                }
                                if (!string.IsNullOrEmpty(data.treatyrate))
                                {
                                    slDoc.SetCellValue("Y" + ((a * 151) + (b + 40)), Convert.ToDouble(data.treatyrate));
                                }

                                if (data.irregularincome == "yes" && ir <= 15)
                                {
                                    vm.Irregulardata dataexist = Irregulardatas.Find(x => x.country == data.country && x.typeincome == "Interest Income");
                                    if (dataexist == null)
                                    {
                                        vm.Irregulardata irregulardata = new vm.Irregulardata();
                                        irregulardata.ir = ir;
                                        irregulardata.country = data.country;
                                        irregulardata.typeincome = "Interest Income";
                                        irregulardata.bil1 = Convert.ToDouble(data.incomerp);
                                        irregulardata.bil2 = Convert.ToDouble(data.taxpaidrp);

                                        Irregulardatas.Add(irregulardata);
                                        ir++;
                                    }
                                    else
                                    {
                                        vm.Irregulardata irregulardata = new vm.Irregulardata();
                                        irregulardata.ir = dataexist.ir;
                                        irregulardata.country = dataexist.country;
                                        irregulardata.typeincome = dataexist.typeincome;
                                        irregulardata.bil1 = dataexist.bil1 + Convert.ToDouble(data.incomerp);
                                        irregulardata.bil2 = dataexist.bil2 + Convert.ToDouble(data.taxpaidrp);

                                        Irregulardatas[dataexist.ir] = irregulardata;
                                    }
                                }
                                b++;
                            }

                        }
                    }


                    foreach (string country in countryList)
                    {
                        ovincome = _servicesOvIncome.GetAllBy3(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, country, 3, taxform.ammend);
                        int b = 0;

                        if (ovincome.Count > 0)
                        {
                            if (!countries.Any(f => f == ovincome[0].country) && countries.Count < 4)
                            {
                                countries.Add(ovincome[0].country);
                            }
                        }

                        foreach (vm.OverseasIncome data in ovincome)
                        {
                            a = countries.FindIndex(z => z == data.country);
                            if (a >= 0 && a < 4)
                            {
                                slDoc.SetCellValue("K" + ((a * 151) + 8), data.country);
                                string datereceipt = "";
                                string year = "";
                                string month = "";
                                if (data.dateofreceipt != "" && data.interval != "4")
                                {
                                    year = data.dateofreceipt.Split('/')[2];
                                    if (year.Length == 4)
                                    {
                                        year = year.Substring(2, 2);
                                    }
                                    month = data.dateofreceipt.Split('/')[1];
                                    datereceipt = data.dateofreceipt.Split('/')[1] + "/" + data.dateofreceipt.Split('/')[0] + "/" + year;
                                    //datereceipt = data.dateofreceipt;
                                }

                                if (data.interval == "4")
                                {
                                    string thedate = data.dateofreceipt;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("B" + ((a * 151) + (b + 65)), thedate);
                                }
                                else if (data.interval == "3")
                                {
                                    slDoc.SetCellValue("B" + ((a * 151) + (b + 65)), "JanDec" + year);
                                }
                                else if (data.interval == "2")
                                {
                                    string mnt = "";
                                    if (month == "01")
                                    {
                                        mnt = "Jan";
                                    }
                                    else if (month == "02")
                                    {
                                        mnt = "Feb";
                                    }
                                    else if (month == "03")
                                    {
                                        mnt = "Mar";
                                    }
                                    else if (month == "04")
                                    {
                                        mnt = "Apr";
                                    }
                                    else if (month == "05")
                                    {
                                        mnt = "May";
                                    }
                                    else if (month == "06")
                                    {
                                        mnt = "Jun";
                                    }
                                    else if (month == "07")
                                    {
                                        mnt = "Jul";
                                    }
                                    else if (month == "08")
                                    {
                                        mnt = "Aug";
                                    }
                                    else if (month == "09")
                                    {
                                        mnt = "Sep";
                                    }
                                    else if (month == "10")
                                    {
                                        mnt = "Oct";
                                    }
                                    else if (month == "11")
                                    {
                                        mnt = "Nov";
                                    }
                                    else if (month == "12")
                                    {
                                        mnt = "Dec";
                                    }
                                    slDoc.SetCellValue("B" + ((a * 151) + (b + 65)), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("B" + ((a * 151) + (b + 65)), Convert.ToDateTime(datereceipt));
                                }

                                slDoc.SetCellValue("E" + ((a * 151) + (b + 65)), data.currency);
                                if (!string.IsNullOrEmpty(data.incomecurrency))
                                {
                                    slDoc.SetCellValue("G" + ((a * 151) + (b + 65)), Convert.ToDouble(data.incomecurrency));
                                }
                                if (!string.IsNullOrEmpty(data.taxpaidcurrency))
                                {
                                    slDoc.SetCellValue("K" + ((a * 151) + (b + 65)), Convert.ToDouble(data.taxpaidcurrency));
                                }
                                if (!string.IsNullOrEmpty(data.exchrate))
                                {
                                    slDoc.SetCellValue("O" + ((a * 151) + (b + 65)), Convert.ToDouble(data.exchrate));
                                }
                                if (!string.IsNullOrEmpty(data.treatyrate))
                                {
                                    slDoc.SetCellValue("Y" + ((a * 151) + (b + 65)), Convert.ToDouble(data.treatyrate));
                                }

                                if (data.irregularincome == "yes" && ir <= 15)
                                {
                                    vm.Irregulardata dataexist = Irregulardatas.Find(x => x.country == data.country && x.typeincome == "Other Income");
                                    if (dataexist == null)
                                    {
                                        vm.Irregulardata irregulardata = new vm.Irregulardata();
                                        irregulardata.ir = ir;
                                        irregulardata.country = data.country;
                                        irregulardata.typeincome = "Other Income";
                                        irregulardata.bil1 = Convert.ToDouble(data.incomerp);
                                        irregulardata.bil2 = Convert.ToDouble(data.taxpaidrp);

                                        Irregulardatas.Add(irregulardata);
                                        ir++;
                                    }
                                    else
                                    {
                                        vm.Irregulardata irregulardata = new vm.Irregulardata();
                                        irregulardata.ir = dataexist.ir;
                                        irregulardata.country = dataexist.country;
                                        irregulardata.typeincome = dataexist.typeincome;
                                        irregulardata.bil1 = dataexist.bil1 + Convert.ToDouble(data.incomerp);
                                        irregulardata.bil2 = dataexist.bil2 + Convert.ToDouble(data.taxpaidrp);

                                        Irregulardatas[dataexist.ir] = irregulardata;
                                    }
                                }
                                b++;
                            }

                        }

                    }


                    foreach (string country in countryList)
                    {
                        int b = 0;
                        List<vm.OverseasCapital> ovcapital = _servicesOvCapital.GetAllBy2(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, country, taxform.ammend);

                        if (ovcapital.Count > 0)
                        {
                            if (!countries.Any(f => f == ovcapital[0].cap_country) && countries.Count < 4)
                            {
                                countries.Add(ovcapital[0].cap_country);
                            }
                        }

                        foreach (vm.OverseasCapital data in ovcapital)
                        {
                            a = countries.FindIndex(z => z == data.cap_country);
                            if (a >= 0 && a < 4)
                            {
                                slDoc.SetCellValue("K" + ((a * 151) + 8), data.cap_country);
                                string datereceipt = "";
                                string year = "";
                                string month = "";
                                if (data.cap_sellingdate != "" && data.cap_interval != "4")
                                {
                                    year = data.cap_sellingdate.Split('/')[2];
                                    if (year.Length == 4)
                                    {
                                        year = year.Substring(2, 2);
                                    }
                                    month = data.cap_sellingdate.Split('/')[1];
                                    datereceipt = data.cap_sellingdate.Split('/')[1] + "/" + data.cap_sellingdate.Split('/')[0] + "/" + year;
                                    //datereceipt = data.cap_sellingdate;
                                }
                                slDoc.SetCellValue("B" + ((a * 151) + (b + 90)), data.cap_description);
                                slDoc.SetCellValue("F" + ((a * 151) + (b + 90)), data.cap_currency);

                                if (data.cap_interval == "4")
                                {
                                    string thedate = data.cap_sellingdate;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("H" + ((a * 151) + (b + 90)), thedate);
                                }
                                else if (data.cap_interval == "3")
                                {
                                    slDoc.SetCellValue("H" + ((a * 151) + (b + 90)), "JanDec" + year);
                                }
                                else if (data.cap_interval == "2")
                                {
                                    string mnt = "";
                                    if (month == "01")
                                    {
                                        mnt = "Jan";
                                    }
                                    else if (month == "02")
                                    {
                                        mnt = "Feb";
                                    }
                                    else if (month == "03")
                                    {
                                        mnt = "Mar";
                                    }
                                    else if (month == "04")
                                    {
                                        mnt = "Apr";
                                    }
                                    else if (month == "05")
                                    {
                                        mnt = "May";
                                    }
                                    else if (month == "06")
                                    {
                                        mnt = "Jun";
                                    }
                                    else if (month == "07")
                                    {
                                        mnt = "Jul";
                                    }
                                    else if (month == "08")
                                    {
                                        mnt = "Aug";
                                    }
                                    else if (month == "09")
                                    {
                                        mnt = "Sep";
                                    }
                                    else if (month == "10")
                                    {
                                        mnt = "Oct";
                                    }
                                    else if (month == "11")
                                    {
                                        mnt = "Nov";
                                    }
                                    else if (month == "12")
                                    {
                                        mnt = "Dec";
                                    }
                                    slDoc.SetCellValue("H" + ((a * 151) + (b + 90)), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("H" + ((a * 151) + (b + 90)), Convert.ToDateTime(datereceipt));
                                }

                                if (!string.IsNullOrEmpty(data.cap_proceeds))
                                {
                                    slDoc.SetCellValue("K" + ((a * 151) + (b + 90)), Convert.ToDouble(data.cap_proceeds));
                                }
                                if (!string.IsNullOrEmpty(data.cap_cost))
                                {
                                    slDoc.SetCellValue("O" + ((a * 151) + (b + 90)), Convert.ToDouble(data.cap_cost));
                                }
                                if (!string.IsNullOrEmpty(data.cap_taxpaid))
                                {
                                    slDoc.SetCellValue("V" + ((a * 151) + (b + 90)), Convert.ToDouble(data.cap_taxpaid));
                                }
                                if (!string.IsNullOrEmpty(data.cap_exchrate))
                                {
                                    slDoc.SetCellValue("Z" + ((a * 151) + (b + 90)), Convert.ToDouble(data.cap_exchrate));
                                }

                                if (data.cap_irregularincome == "yes" && ir <= 15)
                                {
                                    vm.Irregulardata dataexist = Irregulardatas.Find(x => x.country == data.cap_country && x.typeincome == "Capital Income");
                                    if (dataexist == null)
                                    {
                                        vm.Irregulardata irregulardata = new vm.Irregulardata();
                                        irregulardata.ir = ir;
                                        irregulardata.country = data.cap_country;
                                        irregulardata.typeincome = "Capital Income";
                                        irregulardata.bil1 = Convert.ToDouble(data.cap_gainlossrp);
                                        irregulardata.bil2 = Convert.ToDouble(data.cap_taxpaidrp);

                                        Irregulardatas.Add(irregulardata);
                                        ir++;
                                    }
                                    else
                                    {
                                        vm.Irregulardata irregulardata = new vm.Irregulardata();
                                        irregulardata.ir = dataexist.ir;
                                        irregulardata.country = dataexist.country;
                                        irregulardata.typeincome = dataexist.typeincome;
                                        irregulardata.bil1 = dataexist.bil1 + Convert.ToDouble(data.cap_gainlossrp);
                                        irregulardata.bil2 = dataexist.bil2 + Convert.ToDouble(data.cap_taxpaidrp);

                                        Irregulardatas[dataexist.ir] = irregulardata;
                                    }
                                }

                                b++;
                            }

                        }

                    }


                    foreach (string country in countryList)
                    {
                        int b = 0;
                        int c = 0;
                        List<vm.OverseasRental> ovrental = _servicesOvRental.GetAllBy2(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, country, taxform.ammend);

                        if (ovrental.Count > 0)
                        {
                            if (!countries.Any(f => f == ovrental[0].ren_country) && countries.Count < 4)
                            {
                                countries.Add(ovrental[0].ren_country);
                            }
                        }

                        foreach (vm.OverseasRental data in ovrental)
                        {
                            a = countries.FindIndex(z => z == data.ren_country);
                            if (a >= 0 && a < 4)
                            {
                                slDoc.SetCellValue("K" + ((a * 151) + 8), data.ren_country);
                                string datereceipt = "";
                                string year = "";
                                string month = "";
                                if (data.ren_dateofreceipt != "" && data.type != 3 && data.ren_interval != "4")
                                {
                                    year = data.ren_dateofreceipt.Split('/')[2];
                                    if (year.Length == 4)
                                    {
                                        year = year.Substring(2, 2);
                                    }
                                    month = data.ren_dateofreceipt.Split('/')[1];
                                    datereceipt = data.ren_dateofreceipt.Split('/')[1] + "/" + data.ren_dateofreceipt.Split('/')[0] + "/" + year;
                                    //datereceipt = data.ren_dateofreceipt;
                                }
                                if (data.type == 1)
                                {
                                    slDoc.SetCellValue("C" + ((a * 151) + (b + 117)), data.ren_information);
                                    slDoc.SetCellValue("K" + ((a * 151) + (b + 117)), data.ren_currency);


                                    if (data.ren_interval == "4")
                                    {
                                        string thedate = data.ren_dateofreceipt;
                                        string aa = thedate.Split('-')[0].Substring(0, 3);
                                        string bb = thedate.Split('-')[1].Substring(1, 3);
                                        string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                        thedate = aa + "-" + bb + cc;
                                        slDoc.SetCellValue("M" + ((a * 151) + (b + 117)), thedate);
                                    }
                                    else if (data.ren_interval == "3")
                                    {
                                        slDoc.SetCellValue("M" + ((a * 151) + (b + 117)), "JanDec" + year);
                                    }
                                    else if (data.ren_interval == "2")
                                    {
                                        string mnt = "";
                                        if (month == "01")
                                        {
                                            mnt = "Jan";
                                        }
                                        else if (month == "02")
                                        {
                                            mnt = "Feb";
                                        }
                                        else if (month == "03")
                                        {
                                            mnt = "Mar";
                                        }
                                        else if (month == "04")
                                        {
                                            mnt = "Apr";
                                        }
                                        else if (month == "05")
                                        {
                                            mnt = "May";
                                        }
                                        else if (month == "06")
                                        {
                                            mnt = "Jun";
                                        }
                                        else if (month == "07")
                                        {
                                            mnt = "Jul";
                                        }
                                        else if (month == "08")
                                        {
                                            mnt = "Aug";
                                        }
                                        else if (month == "09")
                                        {
                                            mnt = "Sep";
                                        }
                                        else if (month == "10")
                                        {
                                            mnt = "Oct";
                                        }
                                        else if (month == "11")
                                        {
                                            mnt = "Nov";
                                        }
                                        else if (month == "12")
                                        {
                                            mnt = "Dec";
                                        }
                                        slDoc.SetCellValue("M" + ((a * 151) + (b + 117)), "avg" + mnt + year);
                                    }
                                    else
                                    {
                                        slDoc.SetCellValue("M" + ((a * 151) + (b + 117)), Convert.ToDateTime(datereceipt));
                                    }

                                    if (!string.IsNullOrEmpty(data.ren_amountcurrency))
                                    {
                                        slDoc.SetCellValue("P" + ((a * 151) + (b + 117)), Convert.ToDouble(data.ren_amountcurrency));
                                    }
                                    if (!string.IsNullOrEmpty(data.ren_exchrate))
                                    {
                                        slDoc.SetCellValue("U" + ((a * 151) + (b + 117)), Convert.ToDouble(data.ren_exchrate));
                                    }

                                    if (data.ren_irregularincome == "yes" && ir <= 15)
                                    {
                                        vm.Irregulardata dataexist = Irregulardatas.Find(x => x.country == data.ren_country && x.typeincome == "Rental Income/Loss");
                                        if (dataexist == null)
                                        {
                                            vm.Irregulardata irregulardata = new vm.Irregulardata();
                                            irregulardata.ir = ir;
                                            irregulardata.country = data.ren_country;
                                            irregulardata.typeincome = "Rental Income/Loss";
                                            irregulardata.bil1 = Convert.ToDouble(data.ren_amountrp);
                                            irregulardata.bil2 = Convert.ToDouble(0);

                                            Irregulardatas.Add(irregulardata);
                                            ir++;
                                        }
                                        else
                                        {
                                            vm.Irregulardata irregulardata = new vm.Irregulardata();
                                            irregulardata.ir = dataexist.ir;
                                            irregulardata.country = dataexist.country;
                                            irregulardata.typeincome = dataexist.typeincome;
                                            irregulardata.bil1 = dataexist.bil1 + Convert.ToDouble(data.ren_amountrp);
                                            irregulardata.bil2 = dataexist.bil2 + Convert.ToDouble(0);

                                            Irregulardatas[dataexist.ir] = irregulardata;
                                        }
                                    }
                                    b++;
                                }
                                else if (data.type == 2)
                                {
                                    slDoc.SetCellValue("C" + ((a * 151) + (c + 133)), data.ren_information);
                                    slDoc.SetCellValue("K" + ((a * 151) + (c + 133)), data.ren_currency);
                                    if (data.ren_interval == "4")
                                    {
                                        string thedate = data.ren_dateofreceipt;
                                        string aa = thedate.Split('-')[0].Substring(0, 3);
                                        string bb = thedate.Split('-')[1].Substring(1, 3);
                                        string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                        thedate = aa + "-" + bb + cc;
                                        slDoc.SetCellValue("M" + ((a * 151) + (c + 133)), thedate);
                                    }
                                    else if (data.ren_interval == "3")
                                    {
                                        slDoc.SetCellValue("M" + ((a * 151) + (c + 133)), "JanDec" + year);
                                    }
                                    else if (data.ren_interval == "2")
                                    {
                                        string mnt = "";
                                        if (month == "01")
                                        {
                                            mnt = "Jan";
                                        }
                                        else if (month == "02")
                                        {
                                            mnt = "Feb";
                                        }
                                        else if (month == "03")
                                        {
                                            mnt = "Mar";
                                        }
                                        else if (month == "04")
                                        {
                                            mnt = "Apr";
                                        }
                                        else if (month == "05")
                                        {
                                            mnt = "May";
                                        }
                                        else if (month == "06")
                                        {
                                            mnt = "Jun";
                                        }
                                        else if (month == "07")
                                        {
                                            mnt = "Jul";
                                        }
                                        else if (month == "08")
                                        {
                                            mnt = "Aug";
                                        }
                                        else if (month == "09")
                                        {
                                            mnt = "Sep";
                                        }
                                        else if (month == "10")
                                        {
                                            mnt = "Oct";
                                        }
                                        else if (month == "11")
                                        {
                                            mnt = "Nov";
                                        }
                                        else if (month == "12")
                                        {
                                            mnt = "Dec";
                                        }
                                        slDoc.SetCellValue("M" + ((a * 151) + (c + 133)), "avg" + mnt + year);
                                    }
                                    else
                                    {
                                        slDoc.SetCellValue("M" + ((a * 151) + (c + 133)), Convert.ToDateTime(datereceipt));
                                    }

                                    if (!string.IsNullOrEmpty(data.ren_amountcurrency))
                                    {
                                        slDoc.SetCellValue("P" + ((a * 151) + (c + 133)), Convert.ToDouble(data.ren_amountcurrency));
                                    }
                                    if (!string.IsNullOrEmpty(data.ren_exchrate))
                                    {
                                        slDoc.SetCellValue("U" + ((a * 151) + (c + 133)), Convert.ToDouble(data.ren_exchrate));
                                    }

                                    if (data.ren_irregularincome == "yes" && ir <= 15)
                                    {
                                        vm.Irregulardata dataexist = Irregulardatas.Find(x => x.country == data.ren_country && x.typeincome == "Rental Income/Loss");
                                        if (dataexist == null)
                                        {
                                            vm.Irregulardata irregulardata = new vm.Irregulardata();
                                            irregulardata.ir = ir;
                                            irregulardata.country = data.ren_country;
                                            irregulardata.typeincome = "Rental Income/Loss";
                                            irregulardata.bil1 = Convert.ToDouble(data.ren_amountrp) * -1;
                                            irregulardata.bil2 = Convert.ToDouble(0);

                                            Irregulardatas.Add(irregulardata);
                                            ir++;
                                        }
                                        else
                                        {
                                            vm.Irregulardata irregulardata = new vm.Irregulardata();
                                            irregulardata.ir = dataexist.ir;
                                            irregulardata.country = dataexist.country;
                                            irregulardata.typeincome = dataexist.typeincome;
                                            irregulardata.bil1 = dataexist.bil1 + (Convert.ToDouble(data.ren_amountrp) * -1);
                                            irregulardata.bil2 = dataexist.bil2 + Convert.ToDouble(0);

                                            Irregulardatas[dataexist.ir] = irregulardata;
                                        }
                                    }
                                    c++;
                                }
                                else if (data.type == 3)
                                {
                                    if (!string.IsNullOrEmpty(data.ren_amountcurrency))
                                    {
                                        slDoc.SetCellValue("P" + ((a * 151) + 156), Convert.ToDouble(data.ren_amountcurrency));
                                    }

                                    if (!string.IsNullOrEmpty(data.ren_exchrate))
                                    {
                                        slDoc.SetCellValue("U" + ((a * 151) + 156), Convert.ToDouble(data.ren_exchrate));
                                    }
                                }
                            }

                        }
                    }

                    debugtext = "DEBUG 9 ";
                    List<vm.Irregular> Irregulardatasnew = _servicesIrregular.GetAllBy(taxform.TaxPayerNumber, taxform.type, taxform.year, taxform.ammend);
                    debugtext = Irregulardatasnew.Count().ToString();

                    int ino = 0;
                    foreach (vm.Irregulardata Irregulardata in Irregulardatas)
                    {
                        slDoc.SetCellValue("B" + ((ino) + 619), Irregulardata.country);
                        slDoc.SetCellValue("K" + ((ino) + 619), Irregulardata.typeincome);
                        slDoc.SetCellValue("T" + ((ino) + 619), Convert.ToDouble(Irregulardata.bil1));
                        slDoc.SetCellValue("X" + ((ino) + 619), Convert.ToDouble(Irregulardata.bil2));
                        ino++;
                    }


                    if (!string.IsNullOrEmpty(taxform.irregulartaxcredit))
                    {
                        slDoc.SetCellValue("W474", Convert.ToDouble(taxform.irregulartaxcredit));
                    }

                    debugtext = "DEBUG 10 ";
                    //======================================
                    int totalasset = 0;

                    slDoc.SelectWorksheet("A&L");
                    List<vm.Asset> dataassets = _servicesAsset.GetAllAssetBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, 1, taxform.ammend);

                    a = 0;
                    foreach (vm.Asset data in dataassets)
                    {
                        string as_balancedate = "";
                        string year = "";
                        string month = "";
                        if (data.as_balancedate != "" && data.as_interval != "4")
                        {
                            year = data.as_balancedate.Split('/')[2];
                            if (year.Length == 4)
                            {
                                year = year.Substring(2, 2);
                            }
                            month = data.as_balancedate.Split('/')[1];
                            as_balancedate = data.as_balancedate.Split('/')[1] + "/" + data.as_balancedate.Split('/')[0] + "/" + year;
                            //as_balancedate = data.as_balancedate;
                        }
                        else
                        {
                            as_balancedate = data.as_balancedate;
                        }
                        if (a < 15)
                        {
                            slDoc.SetCellValue("C" + ((a * 1) + 9), data.as_description);
                            slDoc.SetCellValue("D" + ((a * 1) + 9), data.as_details);
                            if (as_balancedate != "")
                            {
                                if (data.as_interval == "4")
                                {
                                    string thedate = data.as_balancedate;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("E" + ((a * 1) + 9), thedate);
                                }
                                else if (data.as_interval == "3")
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 9), data.as_balancedate.Split('/')[2]);
                                }
                                else if (data.as_interval == "2")
                                {
                                    string mnt = "";
                                    if (month == "01")
                                    {
                                        mnt = "Jan";
                                    }
                                    else if (month == "02")
                                    {
                                        mnt = "Feb";
                                    }
                                    else if (month == "03")
                                    {
                                        mnt = "Mar";
                                    }
                                    else if (month == "04")
                                    {
                                        mnt = "Apr";
                                    }
                                    else if (month == "05")
                                    {
                                        mnt = "May";
                                    }
                                    else if (month == "06")
                                    {
                                        mnt = "Jun";
                                    }
                                    else if (month == "07")
                                    {
                                        mnt = "Jul";
                                    }
                                    else if (month == "08")
                                    {
                                        mnt = "Aug";
                                    }
                                    else if (month == "09")
                                    {
                                        mnt = "Sep";
                                    }
                                    else if (month == "10")
                                    {
                                        mnt = "Oct";
                                    }
                                    else if (month == "11")
                                    {
                                        mnt = "Nov";
                                    }
                                    else if (month == "12")
                                    {
                                        mnt = "Dec";
                                    }
                                    slDoc.SetCellValue("E" + ((a * 1) + 9), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 9), Convert.ToDateTime(as_balancedate));
                                }
                            }
                            slDoc.SetCellValue("F" + ((a * 1) + 9), data.as_currency);
                            slDoc.SetCellValue("G" + ((a * 1) + 9), data.as_originalcurrency);
                            slDoc.SetCellValue("H" + ((a * 1) + 9), data.as_exchrate);
                            //slDoc.SetCellValue("I" + ((a * 1) + 9), Convert.ToDouble(data.as_inrupiah));
                        }
                        a++;
                    }

                    dataassets = _servicesAsset.GetAllAssetBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, 2, taxform.ammend);
                    a = 0;
                    foreach (vm.Asset data in dataassets)
                    {
                        string as_balancedate = "";
                        string year = "";
                        string month = "";
                        if (data.as_balancedate != "" && data.as_interval != "4")
                        {
                            year = data.as_balancedate.Split('/')[2];
                            if (year.Length == 4)
                            {
                                year = year.Substring(2, 2);
                            }
                            month = data.as_balancedate.Split('/')[1];
                            as_balancedate = data.as_balancedate.Split('/')[1] + "/" + data.as_balancedate.Split('/')[0] + "/" + year;
                            //as_balancedate = data.as_balancedate;
                        }
                        else
                        {
                            as_balancedate = data.as_balancedate;
                        }
                        if (a < 15)
                        {
                            slDoc.SetCellValue("C" + ((a * 1) + 30), data.as_description);
                            slDoc.SetCellValue("D" + ((a * 1) + 30), data.as_details);
                            if (as_balancedate != "")
                            {
                                if (data.as_interval == "4")
                                {
                                    string thedate = data.as_balancedate;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("E" + ((a * 1) + 30), thedate);
                                }
                                else if (data.as_interval == "3")
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 30), data.as_balancedate.Split('/')[2]);
                                }
                                else if (data.as_interval == "2")
                                {
                                    string mnt = "";
                                    if (month == "01")
                                    {
                                        mnt = "Jan";
                                    }
                                    else if (month == "02")
                                    {
                                        mnt = "Feb";
                                    }
                                    else if (month == "03")
                                    {
                                        mnt = "Mar";
                                    }
                                    else if (month == "04")
                                    {
                                        mnt = "Apr";
                                    }
                                    else if (month == "05")
                                    {
                                        mnt = "May";
                                    }
                                    else if (month == "06")
                                    {
                                        mnt = "Jun";
                                    }
                                    else if (month == "07")
                                    {
                                        mnt = "Jul";
                                    }
                                    else if (month == "08")
                                    {
                                        mnt = "Aug";
                                    }
                                    else if (month == "09")
                                    {
                                        mnt = "Sep";
                                    }
                                    else if (month == "10")
                                    {
                                        mnt = "Oct";
                                    }
                                    else if (month == "11")
                                    {
                                        mnt = "Nov";
                                    }
                                    else if (month == "12")
                                    {
                                        mnt = "Dec";
                                    }
                                    slDoc.SetCellValue("E" + ((a * 1) + 30), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 30), Convert.ToDateTime(as_balancedate));
                                }
                            }
                            slDoc.SetCellValue("F" + ((a * 1) + 30), data.as_currency);
                            slDoc.SetCellValue("G" + ((a * 1) + 30), data.as_originalcurrency);
                            slDoc.SetCellValue("H" + ((a * 1) + 30), data.as_exchrate);
                            //slDoc.SetCellValue("Y" + ((a * 1) + 197), Convert.ToDouble(data.as_inrupiah));
                        }
                        a++;
                    }

                    dataassets = _servicesAsset.GetAllAssetBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, 3, taxform.ammend);
                    a = 0;
                    foreach (vm.Asset data in dataassets)
                    {
                        string as_balancedate = "";
                        string year = "";
                        string month = "";
                        if (data.as_balancedate != "" && data.as_interval != "4")
                        {
                            year = data.as_balancedate.Split('/')[2];
                            if (year.Length == 4)
                            {
                                year = year.Substring(2, 2);
                            }
                            month = data.as_balancedate.Split('/')[1];
                            as_balancedate = data.as_balancedate.Split('/')[1] + "/" + data.as_balancedate.Split('/')[0] + "/" + year;
                            //as_balancedate = data.as_balancedate;
                        }
                        else
                        {
                            as_balancedate = data.as_balancedate;
                        }
                        if (a < 15)
                        {
                            slDoc.SetCellValue("C" + ((a * 1) + 51), data.as_description);
                            slDoc.SetCellValue("D" + ((a * 1) + 51), data.as_details);
                            if (as_balancedate != "")
                            {
                                if (data.as_interval == "4")
                                {
                                    string thedate = data.as_balancedate;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("E" + ((a * 1) + 51), thedate);
                                }
                                else if (data.as_interval == "3")
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 51), data.as_balancedate.Split('/')[2]);
                                }
                                else if (data.as_interval == "2")
                                {
                                    string mnt = "";
                                    if (month == "01")
                                    {
                                        mnt = "Jan";
                                    }
                                    else if (month == "02")
                                    {
                                        mnt = "Feb";
                                    }
                                    else if (month == "03")
                                    {
                                        mnt = "Mar";
                                    }
                                    else if (month == "04")
                                    {
                                        mnt = "Apr";
                                    }
                                    else if (month == "05")
                                    {
                                        mnt = "May";
                                    }
                                    else if (month == "06")
                                    {
                                        mnt = "Jun";
                                    }
                                    else if (month == "07")
                                    {
                                        mnt = "Jul";
                                    }
                                    else if (month == "08")
                                    {
                                        mnt = "Aug";
                                    }
                                    else if (month == "09")
                                    {
                                        mnt = "Sep";
                                    }
                                    else if (month == "10")
                                    {
                                        mnt = "Oct";
                                    }
                                    else if (month == "11")
                                    {
                                        mnt = "Nov";
                                    }
                                    else if (month == "12")
                                    {
                                        mnt = "Dec";
                                    }
                                    slDoc.SetCellValue("E" + ((a * 1) + 51), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 51), Convert.ToDateTime(as_balancedate));
                                }
                            }
                            slDoc.SetCellValue("F" + ((a * 1) + 51), data.as_currency);
                            slDoc.SetCellValue("G" + ((a * 1) + 51), data.as_originalcurrency);
                            slDoc.SetCellValue("H" + ((a * 1) + 51), data.as_exchrate);
                            //slDoc.SetCellValue("Y" + ((a * 1) + 214), Convert.ToDouble(data.as_inrupiah));
                        }
                        a++;
                    }

                    dataassets = _servicesAsset.GetAllAssetBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, 4, taxform.ammend);
                    a = 0;
                    foreach (vm.Asset data in dataassets)
                    {
                        string as_balancedate = "";
                        string year = "";
                        string month = "";
                        if (data.as_balancedate != "" && data.as_interval != "4")
                        {
                            year = data.as_balancedate.Split('/')[2];
                            if (year.Length == 4)
                            {
                                year = year.Substring(2, 2);
                            }
                            month = data.as_balancedate.Split('/')[1];
                            as_balancedate = data.as_balancedate.Split('/')[1] + "/" + data.as_balancedate.Split('/')[0] + "/" + year;
                            //as_balancedate = data.as_balancedate;
                        }
                        else
                        {
                            as_balancedate = data.as_balancedate;
                        }
                        if (a < 15)
                        {
                            slDoc.SetCellValue("C" + ((a * 1) + 72), data.as_description);
                            slDoc.SetCellValue("D" + ((a * 1) + 72), data.as_details);
                            if (as_balancedate != "")
                            {
                                if (data.as_interval == "4")
                                {
                                    string thedate = data.as_balancedate;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("E" + ((a * 1) + 72), thedate);
                                }
                                else if (data.as_interval == "3")
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 72), data.as_balancedate.Split('/')[2]);
                                }
                                else if (data.as_interval == "2")
                                {
                                    string mnt = "";
                                    if (month == "01")
                                    {
                                        mnt = "Jan";
                                    }
                                    else if (month == "02")
                                    {
                                        mnt = "Feb";
                                    }
                                    else if (month == "03")
                                    {
                                        mnt = "Mar";
                                    }
                                    else if (month == "04")
                                    {
                                        mnt = "Apr";
                                    }
                                    else if (month == "05")
                                    {
                                        mnt = "May";
                                    }
                                    else if (month == "06")
                                    {
                                        mnt = "Jun";
                                    }
                                    else if (month == "07")
                                    {
                                        mnt = "Jul";
                                    }
                                    else if (month == "08")
                                    {
                                        mnt = "Aug";
                                    }
                                    else if (month == "09")
                                    {
                                        mnt = "Sep";
                                    }
                                    else if (month == "10")
                                    {
                                        mnt = "Oct";
                                    }
                                    else if (month == "11")
                                    {
                                        mnt = "Nov";
                                    }
                                    else if (month == "12")
                                    {
                                        mnt = "Dec";
                                    }
                                    slDoc.SetCellValue("E" + ((a * 1) + 72), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 72), Convert.ToDateTime(as_balancedate));
                                }
                            }
                            slDoc.SetCellValue("F" + ((a * 1) + 72), data.as_currency);
                            slDoc.SetCellValue("G" + ((a * 1) + 72), data.as_originalcurrency);
                            slDoc.SetCellValue("H" + ((a * 1) + 72), data.as_exchrate);
                            //slDoc.SetCellValue("Y" + ((a * 1) + 232), Convert.ToDouble(data.as_inrupiah));
                        }
                        a++;
                    }

                    dataassets = _servicesAsset.GetAllAssetBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, 5, taxform.ammend);
                    a = 0;
                    foreach (vm.Asset data in dataassets)
                    {
                        string as_balancedate = "";
                        string year = "";
                        string month = "";
                        if (data.as_balancedate != "" && data.as_interval != "4")
                        {
                            year = data.as_balancedate.Split('/')[2];
                            if (year.Length == 4)
                            {
                                year = year.Substring(2, 2);
                            }
                            month = data.as_balancedate.Split('/')[1];
                            as_balancedate = data.as_balancedate.Split('/')[1] + "/" + data.as_balancedate.Split('/')[0] + "/" + year;
                            //as_balancedate = data.as_balancedate;
                        }
                        else
                        {
                            as_balancedate = data.as_balancedate;
                        }
                        if (a < 15)
                        {
                            slDoc.SetCellValue("C" + ((a * 1) + 93), data.as_description);
                            slDoc.SetCellValue("D" + ((a * 1) + 93), data.as_details);
                            if (as_balancedate != "")
                            {
                                if (data.as_interval == "4")
                                {
                                    string thedate = data.as_balancedate;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("E" + ((a * 1) + 93), thedate);
                                }
                                else if (data.as_interval == "3")
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 93), data.as_balancedate.Split('/')[2]);
                                }
                                else if (data.as_interval == "2")
                                {
                                    string mnt = "";
                                    if (month == "01")
                                    {
                                        mnt = "Jan";
                                    }
                                    else if (month == "02")
                                    {
                                        mnt = "Feb";
                                    }
                                    else if (month == "03")
                                    {
                                        mnt = "Mar";
                                    }
                                    else if (month == "04")
                                    {
                                        mnt = "Apr";
                                    }
                                    else if (month == "05")
                                    {
                                        mnt = "May";
                                    }
                                    else if (month == "06")
                                    {
                                        mnt = "Jun";
                                    }
                                    else if (month == "07")
                                    {
                                        mnt = "Jul";
                                    }
                                    else if (month == "08")
                                    {
                                        mnt = "Aug";
                                    }
                                    else if (month == "09")
                                    {
                                        mnt = "Sep";
                                    }
                                    else if (month == "10")
                                    {
                                        mnt = "Oct";
                                    }
                                    else if (month == "11")
                                    {
                                        mnt = "Nov";
                                    }
                                    else if (month == "12")
                                    {
                                        mnt = "Dec";
                                    }
                                    slDoc.SetCellValue("E" + ((a * 1) + 93), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 93), Convert.ToDateTime(as_balancedate));
                                }
                            }
                            slDoc.SetCellValue("F" + ((a * 1) + 93), data.as_currency);
                            slDoc.SetCellValue("G" + ((a * 1) + 93), data.as_originalcurrency);
                            slDoc.SetCellValue("H" + ((a * 1) + 93), data.as_exchrate);
                            //slDoc.SetCellValue("Y" + ((a * 1) + 248), Convert.ToDouble(data.as_inrupiah));
                        }
                        a++;
                    }

                    dataassets = _servicesAsset.GetAllAssetBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, 6, taxform.ammend);
                    a = 0;
                    foreach (vm.Asset data in dataassets)
                    {
                        string as_balancedate = "";
                        string year = "";
                        string month = "";
                        if (data.as_balancedate != "" && data.as_interval != "4")
                        {
                            year = data.as_balancedate.Split('/')[2];
                            if (year.Length == 4)
                            {
                                year = year.Substring(2, 2);
                            }
                            month = data.as_balancedate.Split('/')[1];
                            as_balancedate = data.as_balancedate.Split('/')[1] + "/" + data.as_balancedate.Split('/')[0] + "/" + year;
                            //as_balancedate = data.as_balancedate;
                        }
                        else
                        {
                            as_balancedate = data.as_balancedate;
                        }
                        if (a < 15)
                        {
                            slDoc.SetCellValue("C" + ((a * 1) + 114), data.as_description);
                            slDoc.SetCellValue("D" + ((a * 1) + 114), data.as_details);
                            if (as_balancedate != "")
                            {
                                if (data.as_interval == "4")
                                {
                                    string thedate = data.as_balancedate;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("E" + ((a * 1) + 114), thedate);
                                }
                                else if (data.as_interval == "3")
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 114), data.as_balancedate.Split('/')[2]);
                                }
                                else if (data.as_interval == "2")
                                {
                                    string mnt = "";
                                    if (month == "01")
                                    {
                                        mnt = "Jan";
                                    }
                                    else if (month == "02")
                                    {
                                        mnt = "Feb";
                                    }
                                    else if (month == "03")
                                    {
                                        mnt = "Mar";
                                    }
                                    else if (month == "04")
                                    {
                                        mnt = "Apr";
                                    }
                                    else if (month == "05")
                                    {
                                        mnt = "May";
                                    }
                                    else if (month == "06")
                                    {
                                        mnt = "Jun";
                                    }
                                    else if (month == "07")
                                    {
                                        mnt = "Jul";
                                    }
                                    else if (month == "08")
                                    {
                                        mnt = "Aug";
                                    }
                                    else if (month == "09")
                                    {
                                        mnt = "Sep";
                                    }
                                    else if (month == "10")
                                    {
                                        mnt = "Oct";
                                    }
                                    else if (month == "11")
                                    {
                                        mnt = "Nov";
                                    }
                                    else if (month == "12")
                                    {
                                        mnt = "Dec";
                                    }
                                    slDoc.SetCellValue("E" + ((a * 1) + 114), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 114), Convert.ToDateTime(as_balancedate));
                                }
                            }
                            slDoc.SetCellValue("F" + ((a * 1) + 114), data.as_currency);
                            slDoc.SetCellValue("G" + ((a * 1) + 114), data.as_originalcurrency);
                            slDoc.SetCellValue("H" + ((a * 1) + 114), data.as_exchrate);
                            //slDoc.SetCellValue("I" + ((a * 1) + 266), Convert.ToDouble(data.as_inrupiah));
                        }
                        a++;
                    }

                    dataassets = _servicesAsset.GetAllAssetBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, 10, taxform.ammend);
                    a = 0;
                    foreach (vm.Asset data in dataassets)
                    {
                        string as_balancedate = "";
                        string year = "";
                        string month = "";
                        if (data.as_balancedate != "" && data.as_interval != "4")
                        {
                            year = data.as_balancedate.Split('/')[2];
                            if (year.Length == 4)
                            {
                                year = year.Substring(2, 2);
                            }
                            month = data.as_balancedate.Split('/')[1];
                            as_balancedate = data.as_balancedate.Split('/')[1] + "/" + data.as_balancedate.Split('/')[0] + "/" + year;
                            //as_balancedate = data.as_balancedate;
                        }
                        else
                        {
                            as_balancedate = data.as_balancedate;
                        }
                        if (a < 15)
                        {
                            slDoc.SetCellValue("C" + ((a * 1) + 135), data.as_description);
                            slDoc.SetCellValue("D" + ((a * 1) + 135), data.as_details);
                            if (as_balancedate != "")
                            {
                                if (data.as_interval == "4")
                                {
                                    string thedate = data.as_balancedate;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("E" + ((a * 1) + 135), thedate);
                                }
                                else if (data.as_interval == "3")
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 135), data.as_balancedate.Split('/')[2]);
                                }
                                else if (data.as_interval == "2")
                                {
                                    string mnt = "";
                                    if (month == "01")
                                    {
                                        mnt = "Jan";
                                    }
                                    else if (month == "02")
                                    {
                                        mnt = "Feb";
                                    }
                                    else if (month == "03")
                                    {
                                        mnt = "Mar";
                                    }
                                    else if (month == "04")
                                    {
                                        mnt = "Apr";
                                    }
                                    else if (month == "05")
                                    {
                                        mnt = "May";
                                    }
                                    else if (month == "06")
                                    {
                                        mnt = "Jun";
                                    }
                                    else if (month == "07")
                                    {
                                        mnt = "Jul";
                                    }
                                    else if (month == "08")
                                    {
                                        mnt = "Aug";
                                    }
                                    else if (month == "09")
                                    {
                                        mnt = "Sep";
                                    }
                                    else if (month == "10")
                                    {
                                        mnt = "Oct";
                                    }
                                    else if (month == "11")
                                    {
                                        mnt = "Nov";
                                    }
                                    else if (month == "12")
                                    {
                                        mnt = "Dec";
                                    }
                                    slDoc.SetCellValue("E" + ((a * 1) + 135), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 135), Convert.ToDateTime(as_balancedate));
                                }
                            }
                            slDoc.SetCellValue("F" + ((a * 1) + 135), data.as_currency);
                            slDoc.SetCellValue("G" + ((a * 1) + 135), data.as_originalcurrency);
                            slDoc.SetCellValue("H" + ((a * 1) + 135), data.as_exchrate);
                            //slDoc.SetCellValue("I" + ((a * 1) + 282), Convert.ToDouble(data.as_inrupiah));
                        }
                        a++;
                    }


                    //draft All A&L
                    slDoc.SelectWorksheet("DRAFT A&L");
                    dataassets = _servicesAsset.GetAllAssetBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, -1, taxform.ammend);
                    a = 0;
                    foreach (vm.Asset data in dataassets)
                    {
                        string year = "";
                        if (data.as_balancedate != "" && data.as_interval != "4")
                        {
                            year = data.as_balancedate.Split('/')[2];
                            slDoc.SetCellValue("E" + ((a * 1) + 7), year);
                        }
                        else if (data.as_balancedate != "" && data.as_interval == "4")
                        {
                            string thedate = data.as_balancedate;
                            string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 4, 4);
                            thedate = cc;
                            slDoc.SetCellValue("E" + ((a * 1) + 7), thedate);
                        }

                        slDoc.SetCellValue("A" + ((a * 1) + 7), a + 1);
                        slDoc.SetCellValue("B" + ((a * 1) + 7), data.as_refnumber);
                        slDoc.SetCellValue("D" + ((a * 1) + 7), data.as_description);
                        slDoc.SetCellValue("F" + ((a * 1) + 7), data.as_inrupiah);
                        slDoc.SetCellValue("G" + ((a * 1) + 7), data.as_details);
                        a++;
                    }

                }




                debugtext = "DEBUG 11 ";
                //======================================
                //calculation
                client = new ServiceReference2.CalculationSoapClient();
                var datas = client.GetTaxFormByID(Convert.ToInt32(hdid.Value));

                List<vm.Calculation> calculations = _services.GetAllBy(datas[0].TaxPayerNumber, datas[0].type, datas[0].year, datas[0].ammend);
                int total = calculations.Count();
                if (total > 0)
                {
                    slDoc.SelectWorksheet("CalculationSheet");

                    foreach (vm.Calculation calculation in calculations)
                    {
                        slDoc.SetCellValue("N" + 13, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_0)));
                        slDoc.SetCellValue("N" + 22, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_01)));
                        slDoc.SetCellValue("N" + 97, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_0)));
                        slDoc.SetCellValue("N" + 119, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_01)));
                        slDoc.SetCellValue("J" + 55, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_b1)));
                        slDoc.SetCellValue("J" + 56, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_b2)));
                        slDoc.SetCellValue("N" + 57, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_b3)));
                        slDoc.SetCellValue("AF" + 75, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_b4)));
                        slDoc.SetCellValue("R" + 97, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_b5)));
                        slDoc.SetCellValue("AF" + 86, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_b6)));
                        slDoc.SetCellValue("AF" + 87, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_b7)));
                        slDoc.SetCellValue("AF" + 88, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_b8)));
                        slDoc.SetCellValue("J" + (55 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_b1)));
                        slDoc.SetCellValue("J" + (56 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_b2)));
                        slDoc.SetCellValue("N" + (57 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_b3)));
                        slDoc.SetCellValue("AF" + (75 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_b4)));
                        slDoc.SetCellValue("R" + (97 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_b5)));
                        slDoc.SetCellValue("AF" + (86 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_b6)));
                        slDoc.SetCellValue("AF" + (87 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_b7)));
                        slDoc.SetCellValue("AF" + (88 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_b8)));
                        slDoc.SetCellValue("AF" + (158), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_b9)));

                        slDoc.SetCellValue("J" + 14, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_1)));
                        slDoc.SetCellValue("J" + 15, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_2)));
                        slDoc.SetCellValue("N" + 16, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_3)));
                        slDoc.SetCellValue("N" + 17, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_4)));
                        slDoc.SetCellValue("N" + 18, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_5)));
                        slDoc.SetCellValue("R" + 19, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_6)));
                        slDoc.SetCellValue("J" + 23, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_7)));
                        slDoc.SetCellValue("J" + 24, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_8)));
                        slDoc.SetCellValue("N" + 25, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_9)));
                        slDoc.SetCellValue("N" + 26, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_10)));

                        slDoc.SetCellValue("N" + 27, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_11)));
                        slDoc.SetCellValue("R" + 28, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_12)));
                        slDoc.SetCellValue("AF" + 23, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_13)));
                        slDoc.SetCellValue("AF" + 24, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_14)));
                        slDoc.SetCellValue("AF" + 25, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_15)));
                        slDoc.SetCellValue("R" + 30, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_16)));
                        slDoc.SetCellValue("R" + 32, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_17)));
                        slDoc.SetCellValue("AF" + 33, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_18)));
                        slDoc.SetCellValue("AF" + 34, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_19)));
                        slDoc.SetCellValue("AF" + 35, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_20)));

                        slDoc.SetCellValue("AF" + 36, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_21)));
                        slDoc.SetCellValue("AF" + 37, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_22)));
                        slDoc.SetCellValue("AF" + 38, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_23)));
                        slDoc.SetCellValue("AF" + 39, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_24)));
                        slDoc.SetCellValue("J" + 35, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_25)));
                        slDoc.SetCellValue("J" + 36, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_26)));
                        slDoc.SetCellValue("N" + 37, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_27)));
                        slDoc.SetCellValue("N" + 38, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_28)));
                        slDoc.SetCellValue("R" + 39, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_29)));
                        slDoc.SetCellValue("J" + 42, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_30)));

                        slDoc.SetCellValue("J" + 43, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_31)));
                        slDoc.SetCellValue("N" + 44, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_32)));
                        slDoc.SetCellValue("N" + 45, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_33)));
                        slDoc.SetCellValue("R" + 46, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_34)));
                        slDoc.SetCellValue("J" + 59, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_35)));
                        slDoc.SetCellValue("J" + 60, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_36)));
                        slDoc.SetCellValue("N" + 61, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_37)));
                        slDoc.SetCellValue("J" + 63, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_38)));
                        slDoc.SetCellValue("J" + 64, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_39)));
                        slDoc.SetCellValue("N" + 65, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_40)));

                        slDoc.SetCellValue("J" + 67, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_41)));
                        slDoc.SetCellValue("J" + 68, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_42)));
                        slDoc.SetCellValue("N" + 69, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_43)));
                        slDoc.SetCellValue("R" + 71, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_44)));
                        slDoc.SetCellValue("AF" + 66, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_45)));
                        slDoc.SetCellValue("AF" + 67, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_46)));
                        slDoc.SetCellValue("AF" + 68, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_47)));
                        slDoc.SetCellValue("R" + 73, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_48)));
                        slDoc.SetCellValue("R" + 75, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_49)));
                        slDoc.SetCellValue("AF" + 76, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_50)));

                        slDoc.SetCellValue("AF" + 77, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_51)));
                        slDoc.SetCellValue("AF" + 78, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_52)));
                        slDoc.SetCellValue("AF" + 79, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_53)));
                        slDoc.SetCellValue("AF" + 80, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_54)));
                        slDoc.SetCellValue("AF" + 81, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_55)));
                        slDoc.SetCellValue("AF" + 82, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_56)));
                        slDoc.SetCellValue("J" + 78, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_57)));
                        slDoc.SetCellValue("J" + 79, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_58)));
                        slDoc.SetCellValue("N" + 80, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_59)));
                        slDoc.SetCellValue("N" + 81, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_60)));

                        slDoc.SetCellValue("R" + 82, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_61)));
                        slDoc.SetCellValue("J" + 85, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_62)));
                        slDoc.SetCellValue("J" + 86, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_63)));
                        slDoc.SetCellValue("N" + 87, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_64)));
                        slDoc.SetCellValue("N" + 88, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_65)));
                        slDoc.SetCellValue("R" + 89, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_66)));
                        slDoc.SetCellValue("N" + 92, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_67)));
                        slDoc.SetCellValue("N" + 93, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_68)));
                        slDoc.SetCellValue("N" + 94, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_69)));
                        slDoc.SetCellValue("R" + 95, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_70)));

                        slDoc.SetCellValue("R" + 99, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_71)));
                        slDoc.SetCellValue("R" + 101, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_72)));
                        slDoc.SetCellValue("R" + 103, Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_73)));

                        slDoc.SetCellValue("J" + (14 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_1)));
                        slDoc.SetCellValue("J" + (15 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_2)));
                        slDoc.SetCellValue("N" + (16 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_3)));
                        slDoc.SetCellValue("N" + (17 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_4)));
                        slDoc.SetCellValue("N" + (18 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_5)));
                        slDoc.SetCellValue("R" + (19 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_6)));
                        slDoc.SetCellValue("J" + (23 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_7)));
                        slDoc.SetCellValue("J" + (24 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_8)));
                        slDoc.SetCellValue("N" + (25 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_9)));
                        slDoc.SetCellValue("N" + (26 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_10)));

                        slDoc.SetCellValue("N" + (27 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_11)));
                        slDoc.SetCellValue("R" + (28 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_12)));
                        slDoc.SetCellValue("AF" + (23 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_13)));
                        slDoc.SetCellValue("AF" + (24 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_14)));
                        slDoc.SetCellValue("AF" + (25 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_15)));
                        slDoc.SetCellValue("R" + (30 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_16)));
                        slDoc.SetCellValue("R" + (32 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_17)));
                        slDoc.SetCellValue("AF" + (33 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_18)));
                        slDoc.SetCellValue("AF" + (34 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_19)));
                        slDoc.SetCellValue("AF" + (35 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_20)));

                        slDoc.SetCellValue("AF" + (36 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_21)));
                        slDoc.SetCellValue("AF" + (37 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_22)));
                        slDoc.SetCellValue("AF" + (38 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_23)));
                        slDoc.SetCellValue("AF" + (39 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_24)));
                        slDoc.SetCellValue("J" + (35 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_25)));
                        slDoc.SetCellValue("J" + (36 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_26)));
                        slDoc.SetCellValue("N" + (37 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_27)));
                        slDoc.SetCellValue("N" + (38 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_28)));
                        slDoc.SetCellValue("R" + (39 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_29)));
                        slDoc.SetCellValue("J" + (42 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_30)));

                        slDoc.SetCellValue("J" + (43 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_31)));
                        slDoc.SetCellValue("N" + (44 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_32)));
                        slDoc.SetCellValue("N" + (45 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_33)));
                        slDoc.SetCellValue("R" + (46 + 97), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_34)));
                        slDoc.SetCellValue("J" + (59 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_35)));
                        slDoc.SetCellValue("J" + (60 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_36)));
                        slDoc.SetCellValue("N" + (61 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_37)));
                        slDoc.SetCellValue("J" + (63 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_38)));
                        slDoc.SetCellValue("J" + (64 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_39)));
                        slDoc.SetCellValue("N" + (65 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_40)));

                        slDoc.SetCellValue("J" + (67 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_41)));
                        slDoc.SetCellValue("J" + (68 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_42)));
                        slDoc.SetCellValue("N" + (69 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_43)));
                        slDoc.SetCellValue("R" + (71 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_44)));
                        slDoc.SetCellValue("AF" + (66 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_45)));
                        slDoc.SetCellValue("AF" + (67 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_46)));
                        slDoc.SetCellValue("AF" + (68 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_47)));
                        slDoc.SetCellValue("R" + (73 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_48)));
                        slDoc.SetCellValue("R" + (75 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_49)));
                        slDoc.SetCellValue("AF" + (76 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_50)));

                        slDoc.SetCellValue("AF" + (77 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_51)));
                        slDoc.SetCellValue("AF" + (78 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_52)));
                        slDoc.SetCellValue("AF" + (79 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_53)));
                        slDoc.SetCellValue("AF" + (80 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_54)));
                        slDoc.SetCellValue("AF" + (81 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_55)));
                        slDoc.SetCellValue("AF" + (82 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_56)));
                        slDoc.SetCellValue("J" + (78 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_57)));
                        slDoc.SetCellValue("J" + (79 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_58)));
                        slDoc.SetCellValue("N" + (80 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_59)));
                        slDoc.SetCellValue("N" + (81 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_60)));

                        slDoc.SetCellValue("R" + (82 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_61)));
                        slDoc.SetCellValue("J" + (85 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_62)));
                        slDoc.SetCellValue("J" + (86 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_63)));
                        slDoc.SetCellValue("N" + (87 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_64)));
                        slDoc.SetCellValue("N" + (88 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_65)));
                        slDoc.SetCellValue("R" + (89 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_66)));
                        slDoc.SetCellValue("N" + (92 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_67)));
                        slDoc.SetCellValue("N" + (93 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_68)));
                        slDoc.SetCellValue("N" + (94 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_69)));
                        slDoc.SetCellValue("R" + (95 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_70)));

                        slDoc.SetCellValue("R" + (99 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_71)));
                        slDoc.SetCellValue("R" + (101 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_72)));
                        slDoc.SetCellValue("R" + (103 + 96), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_73)));
                    }
                }


                debugtext = "DEBUG 12 ";
                slDoc.SelectWorksheet("GENERAL INFO");
                string excelfile = HttpContext.Current.Server.MapPath(exportPath + sessionLog + "/" + hdid.Value + "-report/") + hdid.Value + "-" + templatename + ".xlsx";
                slDoc.SaveAs(excelfile);


                debugtext = "DEBUG 13 ";
                try
                {
                    ss.Workbook workbook = new ss.Workbook();
                    workbook.LoadFromFile(HttpContext.Current.Server.MapPath(exportPath + sessionLog + "/" + hdid.Value + "-report/") + hdid.Value + "-" + templatename + ".xlsx", ss.ExcelVersion.Version2013);


                    ss.Worksheet sheetselected = workbook.Worksheets[0];

                    for (int aa = 4; aa <= 21; aa++)
                    {
                        sheetselected = workbook.Worksheets[aa];
                        sheetselected.Protect("tanyaIRA", ss.SheetProtectionType.None);
                    }

                    sheetselected = workbook.Worksheets[0];

                    outputname = thename + "_" + hdtaxyear.Value + "_" + formType + ".pdf";
                    outputFile = HttpContext.Current.Server.MapPath(exportPath + sessionLog + "/" + hdid.Value + "-report/") + outputname;
                    outputnameexcel = thename + "_" + hdtaxyear.Value + "_" + formType + ".xlsx";
                    outputFileexcel = HttpContext.Current.Server.MapPath(exportPath + sessionLog + "/" + hdid.Value + "-report/") + outputnameexcel;
                    if (selected)
                    {
                        workbook.SaveToFile(outputFile, ss.FileFormat.PDF);
                    }
                    else
                    {
                        debugtext = "DEBUG 15 ";
                        workbook.SaveToFile(outputFileexcel, ss.ExcelVersion.Version2013);
                    }
                }
                catch (Exception ex)
                {
                    SetMessage(ex.Message);
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        protected void SaveCalculation()
        {
            try
            {
                client = new ServiceReference2.CalculationSoapClient();
                datas = client.GetTaxFormByID(Convert.ToInt32(hdid.Value));
                List<vm.Calculation> calculations = _services.GetAllBy(datas[0].TaxPayerNumber, datas[0].type, datas[0].year, datas[0].ammend);
                var createdby = Session["userLog"].ToString();
                var createddate = Hash.UnixTimeNow().ToString();

                double var_calc_rounded_b1 = 0;
                double var_calc_rounded_b2 = 0;
                double var_calc_rounded_b3 = 0;
                double var_calc_rounded_b4 = 0;
                double var_calc_rounded_b5 = 0;
                double var_calc_rounded_b6 = 0;
                double var_calc_rounded_b7 = 0;
                double var_calc_rounded_b8 = 0;
                double var_calc_not_b1 = 0;
                double var_calc_not_b2 = 0;
                double var_calc_not_b3 = 0;
                double var_calc_not_b4 = 0;
                double var_calc_not_b5 = 0;
                double var_calc_not_b6 = 0;
                double var_calc_not_b7 = 0;
                double var_calc_not_b8 = 0;
                double var_calc_not_b9 = 0;
                double var_calc_rounded_0 = 0;
                double var_calc_rounded_01 = 0;
                double var_calc_not_0 = 0;
                double var_calc_not_01 = 0;

                double var_calc_rounded_1 = 0;
                double var_calc_rounded_2 = 0;
                double var_calc_rounded_3 = 0;
                double var_calc_rounded_4 = 0;
                double var_calc_rounded_5 = 0;
                double var_calc_rounded_6 = 0;
                double var_calc_rounded_7 = 0;
                double var_calc_rounded_8 = 0;
                double var_calc_rounded_9 = 0;
                double var_calc_rounded_10 = 0;
                double var_calc_rounded_11 = 0;
                double var_calc_rounded_12 = 0;
                double var_calc_rounded_13 = 0;
                double var_calc_rounded_14 = 0;
                double var_calc_rounded_15 = 0;
                double var_calc_rounded_16 = 0;
                double var_calc_rounded_17 = 0;
                double var_calc_rounded_18 = 0;
                double var_calc_rounded_19 = 0;
                double var_calc_rounded_20 = 0;
                double var_calc_rounded_21 = 0;
                double var_calc_rounded_22 = 0;
                double var_calc_rounded_23 = 0;
                double var_calc_rounded_24 = 0;
                double var_calc_rounded_25 = 0;
                double var_calc_rounded_26 = 0;
                double var_calc_rounded_27 = 0;
                double var_calc_rounded_28 = 0;
                double var_calc_rounded_29 = 0;
                double var_calc_rounded_30 = 0;
                double var_calc_rounded_31 = 0;
                double var_calc_rounded_32 = 0;
                double var_calc_rounded_33 = 0;
                double var_calc_rounded_34 = 0;
                double var_calc_rounded_35 = 0;
                double var_calc_rounded_36 = 0;
                double var_calc_rounded_37 = 0;
                double var_calc_rounded_38 = 0;
                double var_calc_rounded_39 = 0;
                double var_calc_rounded_40 = 0;
                double var_calc_rounded_41 = 0;
                double var_calc_rounded_42 = 0;
                double var_calc_rounded_43 = 0;
                double var_calc_rounded_44 = 0;
                double var_calc_rounded_45 = 0;
                double var_calc_rounded_46 = 0;
                double var_calc_rounded_47 = 0;
                double var_calc_rounded_48 = 0;
                double var_calc_rounded_49 = 0;
                double var_calc_rounded_50 = 0;
                double var_calc_rounded_51 = 0;
                double var_calc_rounded_52 = 0;
                double var_calc_rounded_53 = 0;
                double var_calc_rounded_54 = 0;
                double var_calc_rounded_55 = 0;
                double var_calc_rounded_56 = 0;
                double var_calc_rounded_57 = 0;
                double var_calc_rounded_58 = 0;
                double var_calc_rounded_59 = 0;
                double var_calc_rounded_60 = 0;
                double var_calc_rounded_61 = 0;
                double var_calc_rounded_62 = 0;
                double var_calc_rounded_63 = 0;
                double var_calc_rounded_64 = 0;
                double var_calc_rounded_65 = 0;
                double var_calc_rounded_66 = 0;
                double var_calc_rounded_67 = 0;
                double var_calc_rounded_68 = 0;
                double var_calc_rounded_69 = 0;
                double var_calc_rounded_70 = 0;
                double var_calc_rounded_71 = 0;
                double var_calc_rounded_72 = 0;
                double var_calc_rounded_73 = 0;
                double var_calc_not_1 = 0;
                double var_calc_not_2 = 0;
                double var_calc_not_3 = 0;
                double var_calc_not_4 = 0;
                double var_calc_not_5 = 0;
                double var_calc_not_6 = 0;
                double var_calc_not_7 = 0;
                double var_calc_not_8 = 0;
                double var_calc_not_9 = 0;
                double var_calc_not_10 = 0;
                double var_calc_not_11 = 0;
                double var_calc_not_12 = 0;
                double var_calc_not_13 = 0;
                double var_calc_not_14 = 0;
                double var_calc_not_15 = 0;
                double var_calc_not_16 = 0;
                double var_calc_not_17 = 0;
                double var_calc_not_18 = 0;
                double var_calc_not_19 = 0;
                double var_calc_not_20 = 0;
                double var_calc_not_21 = 0;
                double var_calc_not_22 = 0;
                double var_calc_not_23 = 0;
                double var_calc_not_24 = 0;
                double var_calc_not_25 = 0;
                double var_calc_not_26 = 0;
                double var_calc_not_27 = 0;
                double var_calc_not_28 = 0;
                double var_calc_not_29 = 0;
                double var_calc_not_30 = 0;
                double var_calc_not_31 = 0;
                double var_calc_not_32 = 0;
                double var_calc_not_33 = 0;
                double var_calc_not_34 = 0;
                double var_calc_not_35 = 0;
                double var_calc_not_36 = 0;
                double var_calc_not_37 = 0;
                double var_calc_not_38 = 0;
                double var_calc_not_39 = 0;
                double var_calc_not_40 = 0;
                double var_calc_not_41 = 0;
                double var_calc_not_42 = 0;
                double var_calc_not_43 = 0;
                double var_calc_not_44 = 0;
                double var_calc_not_45 = 0;
                double var_calc_not_46 = 0;
                double var_calc_not_47 = 0;
                double var_calc_not_48 = 0;
                double var_calc_not_49 = 0;
                double var_calc_not_50 = 0;
                double var_calc_not_51 = 0;
                double var_calc_not_52 = 0;
                double var_calc_not_53 = 0;
                double var_calc_not_54 = 0;
                double var_calc_not_55 = 0;
                double var_calc_not_56 = 0;
                double var_calc_not_57 = 0;
                double var_calc_not_58 = 0;
                double var_calc_not_59 = 0;
                double var_calc_not_60 = 0;
                double var_calc_not_61 = 0;
                double var_calc_not_62 = 0;
                double var_calc_not_63 = 0;
                double var_calc_not_64 = 0;
                double var_calc_not_65 = 0;
                double var_calc_not_66 = 0;
                double var_calc_not_67 = 0;
                double var_calc_not_68 = 0;
                double var_calc_not_69 = 0;
                double var_calc_not_70 = 0;
                double var_calc_not_71 = 0;
                double var_calc_not_72 = 0;
                double var_calc_not_73 = 0;

                if (!string.IsNullOrEmpty(calc_rounded_b1.Value)) { var_calc_rounded_b1 = Convert.ToDouble(calc_rounded_b1.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_b2.Value)) { var_calc_rounded_b2 = Convert.ToDouble(calc_rounded_b2.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_b3.Value)) { var_calc_rounded_b3 = Convert.ToDouble(calc_rounded_b3.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_b4.Value)) { var_calc_rounded_b4 = Convert.ToDouble(calc_rounded_b4.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_b5.Value)) { var_calc_rounded_b5 = Convert.ToDouble(calc_rounded_b5.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_b6.Value)) { var_calc_rounded_b6 = Convert.ToDouble(calc_rounded_b6.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_b7.Value)) { var_calc_rounded_b7 = Convert.ToDouble(calc_rounded_b7.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_b8.Value)) { var_calc_rounded_b8 = Convert.ToDouble(calc_rounded_b8.Value); }
                if (!string.IsNullOrEmpty(calc_not_b1.Value)) { var_calc_not_b1 = Convert.ToDouble(calc_not_b1.Value); }
                if (!string.IsNullOrEmpty(calc_not_b2.Value)) { var_calc_not_b2 = Convert.ToDouble(calc_not_b2.Value); }
                if (!string.IsNullOrEmpty(calc_not_b3.Value)) { var_calc_not_b3 = Convert.ToDouble(calc_not_b3.Value); }
                if (!string.IsNullOrEmpty(calc_not_b4.Value)) { var_calc_not_b4 = Convert.ToDouble(calc_not_b4.Value); }
                if (!string.IsNullOrEmpty(calc_not_b5.Value)) { var_calc_not_b5 = Convert.ToDouble(calc_not_b5.Value); }
                if (!string.IsNullOrEmpty(calc_not_b6.Value)) { var_calc_not_b6 = Convert.ToDouble(calc_not_b6.Value); }
                if (!string.IsNullOrEmpty(calc_not_b7.Value)) { var_calc_not_b7 = Convert.ToDouble(calc_not_b7.Value); }
                if (!string.IsNullOrEmpty(calc_not_b8.Value)) { var_calc_not_b8 = Convert.ToDouble(calc_not_b8.Value); }
                if (!string.IsNullOrEmpty(calc_not_b9.Value)) { var_calc_not_b9 = Convert.ToDouble(calc_not_b9.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_0.Value)) { var_calc_rounded_0 = Convert.ToDouble(calc_rounded_0.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_01.Value)) { var_calc_rounded_01 = Convert.ToDouble(calc_rounded_01.Value); }
                if (!string.IsNullOrEmpty(calc_not_0.Value)) { var_calc_not_0 = Convert.ToDouble(calc_not_0.Value); }
                if (!string.IsNullOrEmpty(calc_not_01.Value)) { var_calc_not_01 = Convert.ToDouble(calc_not_01.Value); }


                if (!string.IsNullOrEmpty(calc_rounded_1.Value)) { var_calc_rounded_1 = Convert.ToDouble(calc_rounded_1.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_2.Value)) { var_calc_rounded_2 = Convert.ToDouble(calc_rounded_2.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_3.Value)) { var_calc_rounded_3 = Convert.ToDouble(calc_rounded_3.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_4.Value)) { var_calc_rounded_4 = Convert.ToDouble(calc_rounded_4.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_5.Value)) { var_calc_rounded_5 = Convert.ToDouble(calc_rounded_5.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_6.Value)) { var_calc_rounded_6 = Convert.ToDouble(calc_rounded_6.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_7.Value)) { var_calc_rounded_7 = Convert.ToDouble(calc_rounded_7.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_8.Value)) { var_calc_rounded_8 = Convert.ToDouble(calc_rounded_8.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_9.Value)) { var_calc_rounded_9 = Convert.ToDouble(calc_rounded_9.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_10.Value)) { var_calc_rounded_10 = Convert.ToDouble(calc_rounded_10.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_11.Value)) { var_calc_rounded_11 = Convert.ToDouble(calc_rounded_11.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_12.Value)) { var_calc_rounded_12 = Convert.ToDouble(calc_rounded_12.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_13.Value)) { var_calc_rounded_13 = Convert.ToDouble(calc_rounded_13.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_14.Value)) { var_calc_rounded_14 = Convert.ToDouble(calc_rounded_14.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_15.Value)) { var_calc_rounded_15 = Convert.ToDouble(calc_rounded_15.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_16.Value)) { var_calc_rounded_16 = Convert.ToDouble(calc_rounded_16.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_17.Value)) { var_calc_rounded_17 = Convert.ToDouble(calc_rounded_17.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_18.Value)) { var_calc_rounded_18 = Convert.ToDouble(calc_rounded_18.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_19.Value)) { var_calc_rounded_19 = Convert.ToDouble(calc_rounded_19.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_20.Value)) { var_calc_rounded_20 = Convert.ToDouble(calc_rounded_20.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_21.Value)) { var_calc_rounded_21 = Convert.ToDouble(calc_rounded_21.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_22.Value)) { var_calc_rounded_22 = Convert.ToDouble(calc_rounded_22.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_23.Value)) { var_calc_rounded_23 = Convert.ToDouble(calc_rounded_23.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_24.Value)) { var_calc_rounded_24 = Convert.ToDouble(calc_rounded_24.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_25.Value)) { var_calc_rounded_25 = Convert.ToDouble(calc_rounded_25.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_26.Value)) { var_calc_rounded_26 = Convert.ToDouble(calc_rounded_26.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_27.Value)) { var_calc_rounded_27 = Convert.ToDouble(calc_rounded_27.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_28.Value)) { var_calc_rounded_28 = Convert.ToDouble(calc_rounded_28.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_29.Value)) { var_calc_rounded_29 = Convert.ToDouble(calc_rounded_29.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_30.Value)) { var_calc_rounded_30 = Convert.ToDouble(calc_rounded_30.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_31.Value)) { var_calc_rounded_31 = Convert.ToDouble(calc_rounded_31.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_32.Value)) { var_calc_rounded_32 = Convert.ToDouble(calc_rounded_32.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_33.Value)) { var_calc_rounded_33 = Convert.ToDouble(calc_rounded_33.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_34.Value)) { var_calc_rounded_34 = Convert.ToDouble(calc_rounded_34.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_35.Value)) { var_calc_rounded_35 = Convert.ToDouble(calc_rounded_35.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_36.Value)) { var_calc_rounded_36 = Convert.ToDouble(calc_rounded_36.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_37.Value)) { var_calc_rounded_37 = Convert.ToDouble(calc_rounded_37.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_38.Value)) { var_calc_rounded_38 = Convert.ToDouble(calc_rounded_38.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_39.Value)) { var_calc_rounded_39 = Convert.ToDouble(calc_rounded_39.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_40.Value)) { var_calc_rounded_40 = Convert.ToDouble(calc_rounded_40.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_41.Value)) { var_calc_rounded_41 = Convert.ToDouble(calc_rounded_41.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_42.Value)) { var_calc_rounded_42 = Convert.ToDouble(calc_rounded_42.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_43.Value)) { var_calc_rounded_43 = Convert.ToDouble(calc_rounded_43.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_44.Value)) { var_calc_rounded_44 = Convert.ToDouble(calc_rounded_44.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_45.Value)) { var_calc_rounded_45 = Convert.ToDouble(calc_rounded_45.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_46.Value)) { var_calc_rounded_46 = Convert.ToDouble(calc_rounded_46.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_47.Value)) { var_calc_rounded_47 = Convert.ToDouble(calc_rounded_47.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_48.Value)) { var_calc_rounded_48 = Convert.ToDouble(calc_rounded_48.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_49.Value)) { var_calc_rounded_49 = Convert.ToDouble(calc_rounded_49.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_50.Value)) { var_calc_rounded_50 = Convert.ToDouble(calc_rounded_50.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_51.Value)) { var_calc_rounded_51 = Convert.ToDouble(calc_rounded_51.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_52.Value)) { var_calc_rounded_52 = Convert.ToDouble(calc_rounded_52.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_53.Value)) { var_calc_rounded_53 = Convert.ToDouble(calc_rounded_53.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_54.Value)) { var_calc_rounded_54 = Convert.ToDouble(calc_rounded_54.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_55.Value)) { var_calc_rounded_55 = Convert.ToDouble(calc_rounded_55.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_56.Value)) { var_calc_rounded_56 = Convert.ToDouble(calc_rounded_56.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_57.Value)) { var_calc_rounded_57 = Convert.ToDouble(calc_rounded_57.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_58.Value)) { var_calc_rounded_58 = Convert.ToDouble(calc_rounded_58.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_59.Value)) { var_calc_rounded_59 = Convert.ToDouble(calc_rounded_59.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_60.Value)) { var_calc_rounded_60 = Convert.ToDouble(calc_rounded_60.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_61.Value)) { var_calc_rounded_61 = Convert.ToDouble(calc_rounded_61.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_62.Value)) { var_calc_rounded_62 = Convert.ToDouble(calc_rounded_62.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_63.Value)) { var_calc_rounded_63 = Convert.ToDouble(calc_rounded_63.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_64.Value)) { var_calc_rounded_64 = Convert.ToDouble(calc_rounded_64.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_65.Value)) { var_calc_rounded_65 = Convert.ToDouble(calc_rounded_65.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_66.Value)) { var_calc_rounded_66 = Convert.ToDouble(calc_rounded_66.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_67.Value)) { var_calc_rounded_67 = Convert.ToDouble(calc_rounded_67.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_68.Value)) { var_calc_rounded_68 = Convert.ToDouble(calc_rounded_68.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_69.Value)) { var_calc_rounded_69 = Convert.ToDouble(calc_rounded_69.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_70.Value)) { var_calc_rounded_70 = Convert.ToDouble(calc_rounded_70.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_71.Value)) { var_calc_rounded_71 = Convert.ToDouble(calc_rounded_71.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_72.Value)) { var_calc_rounded_72 = Convert.ToDouble(calc_rounded_72.Value); }
                if (!string.IsNullOrEmpty(calc_rounded_73.Value)) { var_calc_rounded_73 = Convert.ToDouble(calc_rounded_73.Value); }
                if (!string.IsNullOrEmpty(calc_not_1.Value)) { var_calc_not_1 = Convert.ToDouble(calc_not_1.Value); }
                if (!string.IsNullOrEmpty(calc_not_2.Value)) { var_calc_not_2 = Convert.ToDouble(calc_not_2.Value); }
                if (!string.IsNullOrEmpty(calc_not_3.Value)) { var_calc_not_3 = Convert.ToDouble(calc_not_3.Value); }
                if (!string.IsNullOrEmpty(calc_not_4.Value)) { var_calc_not_4 = Convert.ToDouble(calc_not_4.Value); }
                if (!string.IsNullOrEmpty(calc_not_5.Value)) { var_calc_not_5 = Convert.ToDouble(calc_not_5.Value); }
                if (!string.IsNullOrEmpty(calc_not_6.Value)) { var_calc_not_6 = Convert.ToDouble(calc_not_6.Value); }
                if (!string.IsNullOrEmpty(calc_not_7.Value)) { var_calc_not_7 = Convert.ToDouble(calc_not_7.Value); }
                if (!string.IsNullOrEmpty(calc_not_8.Value)) { var_calc_not_8 = Convert.ToDouble(calc_not_8.Value); }
                if (!string.IsNullOrEmpty(calc_not_9.Value)) { var_calc_not_9 = Convert.ToDouble(calc_not_9.Value); }
                if (!string.IsNullOrEmpty(calc_not_10.Value)) { var_calc_not_10 = Convert.ToDouble(calc_not_10.Value); }
                if (!string.IsNullOrEmpty(calc_not_11.Value)) { var_calc_not_11 = Convert.ToDouble(calc_not_11.Value); }
                if (!string.IsNullOrEmpty(calc_not_12.Value)) { var_calc_not_12 = Convert.ToDouble(calc_not_12.Value); }
                if (!string.IsNullOrEmpty(calc_not_13.Value)) { var_calc_not_13 = Convert.ToDouble(calc_not_13.Value); }
                if (!string.IsNullOrEmpty(calc_not_14.Value)) { var_calc_not_14 = Convert.ToDouble(calc_not_14.Value); }
                if (!string.IsNullOrEmpty(calc_not_15.Value)) { var_calc_not_15 = Convert.ToDouble(calc_not_15.Value); }
                if (!string.IsNullOrEmpty(calc_not_16.Value)) { var_calc_not_16 = Convert.ToDouble(calc_not_16.Value); }
                if (!string.IsNullOrEmpty(calc_not_17.Value)) { var_calc_not_17 = Convert.ToDouble(calc_not_17.Value); }
                if (!string.IsNullOrEmpty(calc_not_18.Value)) { var_calc_not_18 = Convert.ToDouble(calc_not_18.Value); }
                if (!string.IsNullOrEmpty(calc_not_19.Value)) { var_calc_not_19 = Convert.ToDouble(calc_not_19.Value); }
                if (!string.IsNullOrEmpty(calc_not_20.Value)) { var_calc_not_20 = Convert.ToDouble(calc_not_20.Value); }
                if (!string.IsNullOrEmpty(calc_not_21.Value)) { var_calc_not_21 = Convert.ToDouble(calc_not_21.Value); }
                if (!string.IsNullOrEmpty(calc_not_22.Value)) { var_calc_not_22 = Convert.ToDouble(calc_not_22.Value); }
                if (!string.IsNullOrEmpty(calc_not_23.Value)) { var_calc_not_23 = Convert.ToDouble(calc_not_23.Value); }
                if (!string.IsNullOrEmpty(calc_not_24.Value)) { var_calc_not_24 = Convert.ToDouble(calc_not_24.Value); }
                if (!string.IsNullOrEmpty(calc_not_25.Value)) { var_calc_not_25 = Convert.ToDouble(calc_not_25.Value); }
                if (!string.IsNullOrEmpty(calc_not_26.Value)) { var_calc_not_26 = Convert.ToDouble(calc_not_26.Value); }
                if (!string.IsNullOrEmpty(calc_not_27.Value)) { var_calc_not_27 = Convert.ToDouble(calc_not_27.Value); }
                if (!string.IsNullOrEmpty(calc_not_28.Value)) { var_calc_not_28 = Convert.ToDouble(calc_not_28.Value); }
                if (!string.IsNullOrEmpty(calc_not_29.Value)) { var_calc_not_29 = Convert.ToDouble(calc_not_29.Value); }
                if (!string.IsNullOrEmpty(calc_not_30.Value)) { var_calc_not_30 = Convert.ToDouble(calc_not_30.Value); }
                if (!string.IsNullOrEmpty(calc_not_31.Value)) { var_calc_not_31 = Convert.ToDouble(calc_not_31.Value); }
                if (!string.IsNullOrEmpty(calc_not_32.Value)) { var_calc_not_32 = Convert.ToDouble(calc_not_32.Value); }
                if (!string.IsNullOrEmpty(calc_not_33.Value)) { var_calc_not_33 = Convert.ToDouble(calc_not_33.Value); }
                if (!string.IsNullOrEmpty(calc_not_34.Value)) { var_calc_not_34 = Convert.ToDouble(calc_not_34.Value); }
                if (!string.IsNullOrEmpty(calc_not_35.Value)) { var_calc_not_35 = Convert.ToDouble(calc_not_35.Value); }
                if (!string.IsNullOrEmpty(calc_not_36.Value)) { var_calc_not_36 = Convert.ToDouble(calc_not_36.Value); }
                if (!string.IsNullOrEmpty(calc_not_37.Value)) { var_calc_not_37 = Convert.ToDouble(calc_not_37.Value); }
                if (!string.IsNullOrEmpty(calc_not_38.Value)) { var_calc_not_38 = Convert.ToDouble(calc_not_38.Value); }
                if (!string.IsNullOrEmpty(calc_not_39.Value)) { var_calc_not_39 = Convert.ToDouble(calc_not_39.Value); }
                if (!string.IsNullOrEmpty(calc_not_40.Value)) { var_calc_not_40 = Convert.ToDouble(calc_not_40.Value); }
                if (!string.IsNullOrEmpty(calc_not_41.Value)) { var_calc_not_41 = Convert.ToDouble(calc_not_41.Value); }
                if (!string.IsNullOrEmpty(calc_not_42.Value)) { var_calc_not_42 = Convert.ToDouble(calc_not_42.Value); }
                if (!string.IsNullOrEmpty(calc_not_43.Value)) { var_calc_not_43 = Convert.ToDouble(calc_not_43.Value); }
                if (!string.IsNullOrEmpty(calc_not_44.Value)) { var_calc_not_44 = Convert.ToDouble(calc_not_44.Value); }
                if (!string.IsNullOrEmpty(calc_not_45.Value)) { var_calc_not_45 = Convert.ToDouble(calc_not_45.Value); }
                if (!string.IsNullOrEmpty(calc_not_46.Value)) { var_calc_not_46 = Convert.ToDouble(calc_not_46.Value); }
                if (!string.IsNullOrEmpty(calc_not_47.Value)) { var_calc_not_47 = Convert.ToDouble(calc_not_47.Value); }
                if (!string.IsNullOrEmpty(calc_not_48.Value)) { var_calc_not_48 = Convert.ToDouble(calc_not_48.Value); }
                if (!string.IsNullOrEmpty(calc_not_49.Value)) { var_calc_not_49 = Convert.ToDouble(calc_not_49.Value); }
                if (!string.IsNullOrEmpty(calc_not_50.Value)) { var_calc_not_50 = Convert.ToDouble(calc_not_50.Value); }
                if (!string.IsNullOrEmpty(calc_not_51.Value)) { var_calc_not_51 = Convert.ToDouble(calc_not_51.Value); }
                if (!string.IsNullOrEmpty(calc_not_52.Value)) { var_calc_not_52 = Convert.ToDouble(calc_not_52.Value); }
                if (!string.IsNullOrEmpty(calc_not_53.Value)) { var_calc_not_53 = Convert.ToDouble(calc_not_53.Value); }
                if (!string.IsNullOrEmpty(calc_not_54.Value)) { var_calc_not_54 = Convert.ToDouble(calc_not_54.Value); }
                if (!string.IsNullOrEmpty(calc_not_55.Value)) { var_calc_not_55 = Convert.ToDouble(calc_not_55.Value); }
                if (!string.IsNullOrEmpty(calc_not_56.Value)) { var_calc_not_56 = Convert.ToDouble(calc_not_56.Value); }
                if (!string.IsNullOrEmpty(calc_not_57.Value)) { var_calc_not_57 = Convert.ToDouble(calc_not_57.Value); }
                if (!string.IsNullOrEmpty(calc_not_58.Value)) { var_calc_not_58 = Convert.ToDouble(calc_not_58.Value); }
                if (!string.IsNullOrEmpty(calc_not_59.Value)) { var_calc_not_59 = Convert.ToDouble(calc_not_59.Value); }
                if (!string.IsNullOrEmpty(calc_not_60.Value)) { var_calc_not_60 = Convert.ToDouble(calc_not_60.Value); }
                if (!string.IsNullOrEmpty(calc_not_61.Value)) { var_calc_not_61 = Convert.ToDouble(calc_not_61.Value); }
                if (!string.IsNullOrEmpty(calc_not_62.Value)) { var_calc_not_62 = Convert.ToDouble(calc_not_62.Value); }
                if (!string.IsNullOrEmpty(calc_not_63.Value)) { var_calc_not_63 = Convert.ToDouble(calc_not_63.Value); }
                if (!string.IsNullOrEmpty(calc_not_64.Value)) { var_calc_not_64 = Convert.ToDouble(calc_not_64.Value); }
                if (!string.IsNullOrEmpty(calc_not_65.Value)) { var_calc_not_65 = Convert.ToDouble(calc_not_65.Value); }
                if (!string.IsNullOrEmpty(calc_not_66.Value)) { var_calc_not_66 = Convert.ToDouble(calc_not_66.Value); }
                if (!string.IsNullOrEmpty(calc_not_67.Value)) { var_calc_not_67 = Convert.ToDouble(calc_not_67.Value); }
                if (!string.IsNullOrEmpty(calc_not_68.Value)) { var_calc_not_68 = Convert.ToDouble(calc_not_68.Value); }
                if (!string.IsNullOrEmpty(calc_not_69.Value)) { var_calc_not_69 = Convert.ToDouble(calc_not_69.Value); }
                if (!string.IsNullOrEmpty(calc_not_70.Value)) { var_calc_not_70 = Convert.ToDouble(calc_not_70.Value); }
                if (!string.IsNullOrEmpty(calc_not_71.Value)) { var_calc_not_71 = Convert.ToDouble(calc_not_71.Value); }
                if (!string.IsNullOrEmpty(calc_not_72.Value)) { var_calc_not_72 = Convert.ToDouble(calc_not_72.Value); }
                if (!string.IsNullOrEmpty(calc_not_73.Value)) { var_calc_not_73 = Convert.ToDouble(calc_not_73.Value); }


                if (calculations.Count() == 0)
                {
                    _services.Save(true, 0, datas[0].TaxPayerNumber, datas[0].type, datas[0].year, datas[0].ammend, Convert.ToDouble(var_calc_rounded_b1.ToString()), Convert.ToDouble(var_calc_rounded_b2.ToString()), Convert.ToDouble(var_calc_rounded_b3.ToString()), Convert.ToDouble(var_calc_rounded_b4.ToString()), Convert.ToDouble(var_calc_rounded_b5.ToString()), Convert.ToDouble(var_calc_rounded_b6.ToString()), Convert.ToDouble(var_calc_rounded_b7.ToString()), Convert.ToDouble(var_calc_rounded_b8.ToString()), Convert.ToDouble(var_calc_not_b1.ToString()), Convert.ToDouble(var_calc_not_b2.ToString()), Convert.ToDouble(var_calc_not_b3.ToString()), Convert.ToDouble(var_calc_not_b4.ToString()), Convert.ToDouble(var_calc_not_b5.ToString()), Convert.ToDouble(var_calc_not_b6.ToString()), Convert.ToDouble(var_calc_not_b7.ToString()), Convert.ToDouble(var_calc_not_b8.ToString()), Convert.ToDouble(var_calc_not_b9.ToString()), Convert.ToDouble(var_calc_rounded_0.ToString()), Convert.ToDouble(var_calc_rounded_01.ToString()), Convert.ToDouble(var_calc_not_0.ToString()), Convert.ToDouble(var_calc_not_01.ToString()), Convert.ToDouble(var_calc_rounded_1.ToString()), Convert.ToDouble(var_calc_rounded_2), Convert.ToDouble(var_calc_rounded_3), Convert.ToDouble(var_calc_rounded_4), Convert.ToDouble(var_calc_rounded_5), Convert.ToDouble(var_calc_rounded_6), Convert.ToDouble(var_calc_rounded_7), Convert.ToDouble(var_calc_rounded_8), Convert.ToDouble(var_calc_rounded_9), Convert.ToDouble(var_calc_rounded_10), Convert.ToDouble(var_calc_rounded_11), Convert.ToDouble(var_calc_rounded_12), Convert.ToDouble(var_calc_rounded_13), Convert.ToDouble(var_calc_rounded_14), Convert.ToDouble(var_calc_rounded_15), Convert.ToDouble(var_calc_rounded_16), Convert.ToDouble(var_calc_rounded_17), Convert.ToDouble(var_calc_rounded_18), Convert.ToDouble(var_calc_rounded_19), Convert.ToDouble(var_calc_rounded_20), Convert.ToDouble(var_calc_rounded_21), Convert.ToDouble(var_calc_rounded_22), Convert.ToDouble(var_calc_rounded_23), Convert.ToDouble(var_calc_rounded_24), Convert.ToDouble(var_calc_rounded_25), Convert.ToDouble(var_calc_rounded_26), Convert.ToDouble(var_calc_rounded_27), Convert.ToDouble(var_calc_rounded_28), Convert.ToDouble(var_calc_rounded_29), Convert.ToDouble(var_calc_rounded_30), Convert.ToDouble(var_calc_rounded_31), Convert.ToDouble(var_calc_rounded_32), Convert.ToDouble(var_calc_rounded_33), Convert.ToDouble(var_calc_rounded_34), Convert.ToDouble(var_calc_rounded_35), Convert.ToDouble(var_calc_rounded_36), Convert.ToDouble(var_calc_rounded_37), Convert.ToDouble(var_calc_rounded_38), Convert.ToDouble(var_calc_rounded_39), Convert.ToDouble(var_calc_rounded_40), Convert.ToDouble(var_calc_rounded_41), Convert.ToDouble(var_calc_rounded_42), Convert.ToDouble(var_calc_rounded_43), Convert.ToDouble(var_calc_rounded_44), Convert.ToDouble(var_calc_rounded_45), Convert.ToDouble(var_calc_rounded_46), Convert.ToDouble(var_calc_rounded_47), Convert.ToDouble(var_calc_rounded_48), Convert.ToDouble(var_calc_rounded_49), Convert.ToDouble(var_calc_rounded_50), Convert.ToDouble(var_calc_rounded_51), Convert.ToDouble(var_calc_rounded_52), Convert.ToDouble(var_calc_rounded_53), Convert.ToDouble(var_calc_rounded_54), Convert.ToDouble(var_calc_rounded_55), Convert.ToDouble(var_calc_rounded_56), Convert.ToDouble(var_calc_rounded_57), Convert.ToDouble(var_calc_rounded_58), Convert.ToDouble(var_calc_rounded_59), Convert.ToDouble(var_calc_rounded_60), Convert.ToDouble(var_calc_rounded_61), Convert.ToDouble(var_calc_rounded_62), Convert.ToDouble(var_calc_rounded_63), Convert.ToDouble(var_calc_rounded_64), Convert.ToDouble(var_calc_rounded_65), Convert.ToDouble(var_calc_rounded_66), Convert.ToDouble(var_calc_rounded_67), Convert.ToDouble(var_calc_rounded_68), Convert.ToDouble(var_calc_rounded_69), Convert.ToDouble(var_calc_rounded_70), Convert.ToDouble(var_calc_rounded_71), Convert.ToDouble(var_calc_rounded_72), Convert.ToDouble(var_calc_rounded_73), Convert.ToDouble(var_calc_not_1), Convert.ToDouble(var_calc_not_2), Convert.ToDouble(var_calc_not_3), Convert.ToDouble(var_calc_not_4), Convert.ToDouble(var_calc_not_5), Convert.ToDouble(var_calc_not_6), Convert.ToDouble(var_calc_not_7), Convert.ToDouble(var_calc_not_8), Convert.ToDouble(var_calc_not_9), Convert.ToDouble(var_calc_not_10), Convert.ToDouble(var_calc_not_11), Convert.ToDouble(var_calc_not_12), Convert.ToDouble(var_calc_not_13), Convert.ToDouble(var_calc_not_14), Convert.ToDouble(var_calc_not_15), Convert.ToDouble(var_calc_not_16), Convert.ToDouble(var_calc_not_17), Convert.ToDouble(var_calc_not_18), Convert.ToDouble(var_calc_not_19), Convert.ToDouble(var_calc_not_20), Convert.ToDouble(var_calc_not_21), Convert.ToDouble(var_calc_not_22), Convert.ToDouble(var_calc_not_23), Convert.ToDouble(var_calc_not_24), Convert.ToDouble(var_calc_not_25), Convert.ToDouble(var_calc_not_26), Convert.ToDouble(var_calc_not_27), Convert.ToDouble(var_calc_not_28), Convert.ToDouble(var_calc_not_29), Convert.ToDouble(var_calc_not_30), Convert.ToDouble(var_calc_not_31), Convert.ToDouble(var_calc_not_32), Convert.ToDouble(var_calc_not_33), Convert.ToDouble(var_calc_not_34), Convert.ToDouble(var_calc_not_35), Convert.ToDouble(var_calc_not_36), Convert.ToDouble(var_calc_not_37), Convert.ToDouble(var_calc_not_38), Convert.ToDouble(var_calc_not_39), Convert.ToDouble(var_calc_not_40), Convert.ToDouble(var_calc_not_41), Convert.ToDouble(var_calc_not_42), Convert.ToDouble(var_calc_not_43), Convert.ToDouble(var_calc_not_44), Convert.ToDouble(var_calc_not_45), Convert.ToDouble(var_calc_not_46), Convert.ToDouble(var_calc_not_47), Convert.ToDouble(var_calc_not_48), Convert.ToDouble(var_calc_not_49), Convert.ToDouble(var_calc_not_50), Convert.ToDouble(var_calc_not_51), Convert.ToDouble(var_calc_not_52), Convert.ToDouble(var_calc_not_53), Convert.ToDouble(var_calc_not_54), Convert.ToDouble(var_calc_not_55), Convert.ToDouble(var_calc_not_56), Convert.ToDouble(var_calc_not_57), Convert.ToDouble(var_calc_not_58), Convert.ToDouble(var_calc_not_59), Convert.ToDouble(var_calc_not_60), Convert.ToDouble(var_calc_not_61), Convert.ToDouble(var_calc_not_62), Convert.ToDouble(var_calc_not_63), Convert.ToDouble(var_calc_not_64), Convert.ToDouble(var_calc_not_65), Convert.ToDouble(var_calc_not_66), Convert.ToDouble(var_calc_not_67), Convert.ToDouble(var_calc_not_68), Convert.ToDouble(var_calc_not_69), Convert.ToDouble(var_calc_not_70), Convert.ToDouble(var_calc_not_71), Convert.ToDouble(var_calc_not_72), Convert.ToDouble(var_calc_not_73), createdby, createddate, createdby, createddate);
                }
                else
                {
                    _services.Save(false, calculations[0].id, datas[0].TaxPayerNumber, datas[0].type, datas[0].year, datas[0].ammend, Convert.ToDouble(var_calc_rounded_b1.ToString()), Convert.ToDouble(var_calc_rounded_b2.ToString()), Convert.ToDouble(var_calc_rounded_b3.ToString()), Convert.ToDouble(var_calc_rounded_b4.ToString()), Convert.ToDouble(var_calc_rounded_b5.ToString()), Convert.ToDouble(var_calc_rounded_b6.ToString()), Convert.ToDouble(var_calc_rounded_b7.ToString()), Convert.ToDouble(var_calc_rounded_b8.ToString()), Convert.ToDouble(var_calc_not_b1.ToString()), Convert.ToDouble(var_calc_not_b2.ToString()), Convert.ToDouble(var_calc_not_b3.ToString()), Convert.ToDouble(var_calc_not_b4.ToString()), Convert.ToDouble(var_calc_not_b5.ToString()), Convert.ToDouble(var_calc_not_b6.ToString()), Convert.ToDouble(var_calc_not_b7.ToString()), Convert.ToDouble(var_calc_not_b8.ToString()), Convert.ToDouble(var_calc_not_b9.ToString()), Convert.ToDouble(var_calc_rounded_0.ToString()), Convert.ToDouble(var_calc_rounded_01.ToString()), Convert.ToDouble(var_calc_not_0.ToString()), Convert.ToDouble(var_calc_not_01.ToString()), Convert.ToDouble(var_calc_rounded_1.ToString()), Convert.ToDouble(var_calc_rounded_2), Convert.ToDouble(var_calc_rounded_3), Convert.ToDouble(var_calc_rounded_4), Convert.ToDouble(var_calc_rounded_5), Convert.ToDouble(var_calc_rounded_6), Convert.ToDouble(var_calc_rounded_7), Convert.ToDouble(var_calc_rounded_8), Convert.ToDouble(var_calc_rounded_9), Convert.ToDouble(var_calc_rounded_10), Convert.ToDouble(var_calc_rounded_11), Convert.ToDouble(var_calc_rounded_12), Convert.ToDouble(var_calc_rounded_13), Convert.ToDouble(var_calc_rounded_14), Convert.ToDouble(var_calc_rounded_15), Convert.ToDouble(var_calc_rounded_16), Convert.ToDouble(var_calc_rounded_17), Convert.ToDouble(var_calc_rounded_18), Convert.ToDouble(var_calc_rounded_19), Convert.ToDouble(var_calc_rounded_20), Convert.ToDouble(var_calc_rounded_21), Convert.ToDouble(var_calc_rounded_22), Convert.ToDouble(var_calc_rounded_23), Convert.ToDouble(var_calc_rounded_24), Convert.ToDouble(var_calc_rounded_25), Convert.ToDouble(var_calc_rounded_26), Convert.ToDouble(var_calc_rounded_27), Convert.ToDouble(var_calc_rounded_28), Convert.ToDouble(var_calc_rounded_29), Convert.ToDouble(var_calc_rounded_30), Convert.ToDouble(var_calc_rounded_31), Convert.ToDouble(var_calc_rounded_32), Convert.ToDouble(var_calc_rounded_33), Convert.ToDouble(var_calc_rounded_34), Convert.ToDouble(var_calc_rounded_35), Convert.ToDouble(var_calc_rounded_36), Convert.ToDouble(var_calc_rounded_37), Convert.ToDouble(var_calc_rounded_38), Convert.ToDouble(var_calc_rounded_39), Convert.ToDouble(var_calc_rounded_40), Convert.ToDouble(var_calc_rounded_41), Convert.ToDouble(var_calc_rounded_42), Convert.ToDouble(var_calc_rounded_43), Convert.ToDouble(var_calc_rounded_44), Convert.ToDouble(var_calc_rounded_45), Convert.ToDouble(var_calc_rounded_46), Convert.ToDouble(var_calc_rounded_47), Convert.ToDouble(var_calc_rounded_48), Convert.ToDouble(var_calc_rounded_49), Convert.ToDouble(var_calc_rounded_50), Convert.ToDouble(var_calc_rounded_51), Convert.ToDouble(var_calc_rounded_52), Convert.ToDouble(var_calc_rounded_53), Convert.ToDouble(var_calc_rounded_54), Convert.ToDouble(var_calc_rounded_55), Convert.ToDouble(var_calc_rounded_56), Convert.ToDouble(var_calc_rounded_57), Convert.ToDouble(var_calc_rounded_58), Convert.ToDouble(var_calc_rounded_59), Convert.ToDouble(var_calc_rounded_60), Convert.ToDouble(var_calc_rounded_61), Convert.ToDouble(var_calc_rounded_62), Convert.ToDouble(var_calc_rounded_63), Convert.ToDouble(var_calc_rounded_64), Convert.ToDouble(var_calc_rounded_65), Convert.ToDouble(var_calc_rounded_66), Convert.ToDouble(var_calc_rounded_67), Convert.ToDouble(var_calc_rounded_68), Convert.ToDouble(var_calc_rounded_69), Convert.ToDouble(var_calc_rounded_70), Convert.ToDouble(var_calc_rounded_71), Convert.ToDouble(var_calc_rounded_72), Convert.ToDouble(var_calc_rounded_73), Convert.ToDouble(var_calc_not_1), Convert.ToDouble(var_calc_not_2), Convert.ToDouble(var_calc_not_3), Convert.ToDouble(var_calc_not_4), Convert.ToDouble(var_calc_not_5), Convert.ToDouble(var_calc_not_6), Convert.ToDouble(var_calc_not_7), Convert.ToDouble(var_calc_not_8), Convert.ToDouble(var_calc_not_9), Convert.ToDouble(var_calc_not_10), Convert.ToDouble(var_calc_not_11), Convert.ToDouble(var_calc_not_12), Convert.ToDouble(var_calc_not_13), Convert.ToDouble(var_calc_not_14), Convert.ToDouble(var_calc_not_15), Convert.ToDouble(var_calc_not_16), Convert.ToDouble(var_calc_not_17), Convert.ToDouble(var_calc_not_18), Convert.ToDouble(var_calc_not_19), Convert.ToDouble(var_calc_not_20), Convert.ToDouble(var_calc_not_21), Convert.ToDouble(var_calc_not_22), Convert.ToDouble(var_calc_not_23), Convert.ToDouble(var_calc_not_24), Convert.ToDouble(var_calc_not_25), Convert.ToDouble(var_calc_not_26), Convert.ToDouble(var_calc_not_27), Convert.ToDouble(var_calc_not_28), Convert.ToDouble(var_calc_not_29), Convert.ToDouble(var_calc_not_30), Convert.ToDouble(var_calc_not_31), Convert.ToDouble(var_calc_not_32), Convert.ToDouble(var_calc_not_33), Convert.ToDouble(var_calc_not_34), Convert.ToDouble(var_calc_not_35), Convert.ToDouble(var_calc_not_36), Convert.ToDouble(var_calc_not_37), Convert.ToDouble(var_calc_not_38), Convert.ToDouble(var_calc_not_39), Convert.ToDouble(var_calc_not_40), Convert.ToDouble(var_calc_not_41), Convert.ToDouble(var_calc_not_42), Convert.ToDouble(var_calc_not_43), Convert.ToDouble(var_calc_not_44), Convert.ToDouble(var_calc_not_45), Convert.ToDouble(var_calc_not_46), Convert.ToDouble(var_calc_not_47), Convert.ToDouble(var_calc_not_48), Convert.ToDouble(var_calc_not_49), Convert.ToDouble(var_calc_not_50), Convert.ToDouble(var_calc_not_51), Convert.ToDouble(var_calc_not_52), Convert.ToDouble(var_calc_not_53), Convert.ToDouble(var_calc_not_54), Convert.ToDouble(var_calc_not_55), Convert.ToDouble(var_calc_not_56), Convert.ToDouble(var_calc_not_57), Convert.ToDouble(var_calc_not_58), Convert.ToDouble(var_calc_not_59), Convert.ToDouble(var_calc_not_60), Convert.ToDouble(var_calc_not_61), Convert.ToDouble(var_calc_not_62), Convert.ToDouble(var_calc_not_63), Convert.ToDouble(var_calc_not_64), Convert.ToDouble(var_calc_not_65), Convert.ToDouble(var_calc_not_66), Convert.ToDouble(var_calc_not_67), Convert.ToDouble(var_calc_not_68), Convert.ToDouble(var_calc_not_69), Convert.ToDouble(var_calc_not_70), Convert.ToDouble(var_calc_not_71), Convert.ToDouble(var_calc_not_72), Convert.ToDouble(var_calc_not_73), createdby, createddate, createdby, createddate);
                }

            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }
    }
}