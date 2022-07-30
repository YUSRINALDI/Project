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
    public partial class calculation_japan : System.Web.UI.Page
    {
        private CalculationServices _services;
        ServiceReference2.CalculationSoapClient client;
        ServiceReference2.TaxForm[] datas;

        private string templatePath = HttpContext.Current.Server.MapPath("~/templates/");
        private string exportPath = "~/App_Data/";
        private string formType = "formJapan";
        private double period = 12;
        private int reportCount = 10;
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
        bool generatenext;
        int totalasset = 0;
        List<vm.IEIncome> ieincome;
        string debugtext = "";
        string sessionLog = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            hdid.Value = Request.QueryString["id"];
            _services = ServicesFactory.CreateCalculationServices(ConnectionString.Value);

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
                if (Session["userRole"].ToString() == "1")
                {
                    SetEditable(true);
                }
                else if (Session["userRole"].ToString() == "2")
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

                            double netincomeroundedyes = 0;
                            if (!string.IsNullOrEmpty(data.netincomeroundedyes))
                            {
                                netincomeroundedyes = Convert.ToDouble(data.netincomeroundedyes);
                            }
                            double netincomeroundednot = 0;
                            if (!string.IsNullOrEmpty(data.netincomeroundednot))
                            {
                                netincomeroundednot = Convert.ToDouble(data.netincomeroundednot);
                            }
                            double bonusroundedyes = 0;
                            if (!string.IsNullOrEmpty(data.bonusroundedyes))
                            {
                                bonusroundedyes = Convert.ToDouble(data.bonusroundedyes);
                            }
                            double bonusroundednot = 0;
                            if (!string.IsNullOrEmpty(data.bonusroundednot))
                            {
                                bonusroundednot = Convert.ToDouble(data.bonusroundednot);
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
                            if (!string.IsNullOrEmpty(data.totalperiodroundednot))
                            {
                                totalperiodroundednot = Convert.ToDouble(data.totalperiodroundednot);
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
                            double data_calc_rounded_2 = bonusroundedyes;
                            double data_calc_rounded_3 = data_calc_rounded_1 + data_calc_rounded_2;
                            double data_calc_rounded_4 = t1s6f21;

                            double data_calc_rounded_5 = lbltotalsummary1;
                            if (data_calc_rounded_5 < 0)
                            {
                                data_calc_rounded_5 = 0;
                            }

                            double data_calc_rounded_6 = data_calc_rounded_3 + data_calc_rounded_4 + data_calc_rounded_5;
                            double data_calc_rounded_7 = (data_calc_rounded_1 / totalperiodroundedyes) * 12;
                            double data_calc_rounded_8 = (data_calc_rounded_2 / totalperiodroundedyes) * 12;
                            double data_calc_rounded_9 = data_calc_rounded_7 + data_calc_rounded_8;
                            double data_calc_rounded_10 = (data_calc_rounded_4 / totalperiodroundedyes) * 12;
                            double data_calc_rounded_11 = (data_calc_rounded_5 / totalperiodroundedyes) * 12;
                            double data_calc_rounded_12 = data_calc_rounded_9 + data_calc_rounded_10 + data_calc_rounded_11;
                            double data_calc_rounded_13 = 0;
                            if (data_calc_rounded_7 > 0)
                            {
                                data_calc_rounded_13 = Convert.ToDouble(data_calc_rounded_7) - t1s3f3;
                            }
                            double data_calc_rounded_14 = data_calc_rounded_8;
                            double data_calc_rounded_15 = 0;
                            if (data_calc_rounded_9 > 0)
                            {
                                data_calc_rounded_15 = Convert.ToDouble(data_calc_rounded_9) - t1s3f3;
                            }
                            double data_calc_rounded_16 = t1s3f3;
                            double data_calc_rounded_18 = data_calc_rounded_7 - t1s3f3;
                            double data_calc_rounded_19 = data_calc_rounded_8;
                            double data_calc_rounded_20 = data_calc_rounded_18 + data_calc_rounded_19;
                            double data_calc_rounded_21 = data_calc_rounded_10;
                            double data_calc_rounded_22 = data_calc_rounded_11;
                            double data_calc_rounded_23 = data_calc_rounded_20 + data_calc_rounded_21 + data_calc_rounded_22;
                            double data_calc_rounded_24 = 0;
                            if (data_calc_rounded_23 > 0)
                            {
                                data_calc_rounded_24 = Convert.ToDouble(data_calc_rounded_23);
                            }
                            double data_calc_rounded_17 = 0;
                            if (data_calc_rounded_23 > 0)
                            {
                                data_calc_rounded_17 = data_calc_rounded_23;
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
                            //double data_calc_rounded_25 = 0;
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
                            double data_calc_rounded_26 = data_calc_rounded_27 - data_calc_rounded_25;

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
                            if (string.IsNullOrEmpty(data.t1s2f1))
                            {
                                data_calc_rounded_35 = data_calc_rounded_7;
                                data_calc_rounded_36 = data_calc_rounded_8;
                                data_calc_rounded_38 = data_calc_rounded_10;
                                data_calc_rounded_39 = t1s6f24 / 12 * totalperiodroundedyes;
                                data_calc_rounded_41 = data_calc_rounded_11;
                                data_calc_rounded_42 = tabirregulartotal1 / totalperiodroundedyes * 12;
                            }
                            
                            double data_calc_rounded_37 = data_calc_rounded_35 + data_calc_rounded_36;
                            
                            double data_calc_rounded_40 = data_calc_rounded_38 + data_calc_rounded_39;
                            data_calc_rounded_42 = data_calc_rounded_42 * -1;
                            double data_calc_rounded_43 = data_calc_rounded_41 + data_calc_rounded_42;
                            double data_calc_rounded_44 = 0;

                            if (string.IsNullOrEmpty(data.t1s2f1))
                            {
                                if (data_calc_rounded_43 > 0)
                                {
                                    data_calc_rounded_44 = data_calc_rounded_34 + data_calc_rounded_37 + data_calc_rounded_40 + data_calc_rounded_43;
                                }
                                else
                                {
                                    data_calc_rounded_44 = data_calc_rounded_34 + data_calc_rounded_37 + data_calc_rounded_40;
                                }
                            }

                            double data_calc_rounded_45 = 0;
                            double data_calc_rounded_47 = 0;
                            if (string.IsNullOrEmpty(data.t1s2f1))
                            {
                                data_calc_rounded_45 = Convert.ToDouble(data_calc_rounded_35) - t1s3f3;
                                data_calc_rounded_47 = Convert.ToDouble(data_calc_rounded_37) - t1s3f3;
                            }
                            double data_calc_rounded_46 = data_calc_rounded_36;

                            double data_calc_rounded_48 = t1s3f3;
                            double data_calc_rounded_49 = 0;

                            double data_calc_rounded_50 = 0;
                            double data_calc_rounded_51 = data_calc_rounded_36;
                            double data_calc_rounded_52 = 0;
                            double data_calc_rounded_53 = data_calc_rounded_40;
                            double data_calc_rounded_54 = 0;
                            if (string.IsNullOrEmpty(data.t1s2f1))
                            {
                                data_calc_rounded_50 = Convert.ToDouble(data_calc_rounded_35) - t1s3f3; 
                                data_calc_rounded_51 = data_calc_rounded_36;
                                data_calc_rounded_52 = data_calc_rounded_50 + data_calc_rounded_51;
                                data_calc_rounded_53 = data_calc_rounded_40;
                                data_calc_rounded_54 = data_calc_rounded_43;
                            }
                            double data_calc_rounded_55 = data_calc_rounded_52 + data_calc_rounded_53 + data_calc_rounded_54 + data_calc_rounded_50;
                            double data_calc_rounded_56 = 0;
                            if (data_calc_rounded_55 > 0)
                            {
                                data_calc_rounded_56 = Convert.ToDouble(data_calc_rounded_55);
                            }

                            if (data_calc_rounded_55 > 0)
                            {
                                data_calc_rounded_49 = data_calc_rounded_55;
                            }
                            double data_calc_rounded_58 = data_calc_rounded_46 * totalperiodroundedyes / 12;
                            double data_calc_rounded_57 = data_calc_rounded_58 - data_calc_rounded_56;
                            double data_calc_rounded_60 = 0;
                            if (data_calc_rounded_56 <= 0)
                            {
                                data_calc_rounded_60 = 0;
                            }
                            else if (data_calc_rounded_56 > 0 && data_calc_rounded_56 <= 50000000)
                            {
                                data_calc_rounded_60 = (0.05 * data_calc_rounded_56);
                            }
                            else if (data_calc_rounded_56 > 50000000 && data_calc_rounded_56 <= 250000000)
                            {
                                data_calc_rounded_60 = 0.15 * data_calc_rounded_56 - 5000000;
                            }
                            else if (data_calc_rounded_56 > 250000000 && data_calc_rounded_56 <= 500000000)
                            {
                                data_calc_rounded_60 = 0.25 * data_calc_rounded_56 - 30000000;
                            }
                            else
                            {
                                data_calc_rounded_60 = 0.3 * data_calc_rounded_56 - 55000000;
                            }
                            double data_calc_rounded_59 = data_calc_rounded_60 - data_calc_rounded_58;
                            double data_calc_rounded_61 = data_calc_rounded_57 / 12 * totalperiodroundedyes;
                            double data_calc_rounded_62 = data_calc_rounded_58 / totalperiodroundedyes * 12;
                            double data_calc_rounded_63 = data_calc_rounded_61 + data_calc_rounded_62;
                            double data_calc_rounded_64 = data_calc_rounded_59 / 12 * totalperiodroundedyes;
                            double data_calc_rounded_65 = data_calc_rounded_63 + data_calc_rounded_64;
                            double data_calc_rounded_66 = data_calc_rounded_64 + data_calc_rounded_65;

                            double data_calc_rounded_67 = 0;
                            double data_calc_rounded_68 = 0;
                            double data_calc_rounded_69 = 0;
                            if (string.IsNullOrEmpty(data.t1s2f1))
                            {
                                data_calc_rounded_67 = totalincometax;
                                data_calc_rounded_68 = lbltotalsummary2;
                                data_calc_rounded_69 = (tabirregulartotal2 - t1s6f25) * -1;
                            }

                            double data_calc_rounded_70 = data_calc_rounded_67 + data_calc_rounded_68 + data_calc_rounded_69;
                            double data_calc_rounded_71 = data_calc_rounded_65 - data_calc_rounded_69 - data_calc_rounded_70;
                            double data_calc_rounded_72 = 12;
                            if (totalperiodroundedyes < 12)
                            {
                                data_calc_rounded_72 = totalperiodroundedyes;
                            }
                            double data_calc_rounded_73 = data_calc_rounded_71 / data_calc_rounded_72;

                            double data_calc_not_1 = netincomeroundednot - bonusroundednot;
                            double data_calc_not_2 = bonusroundednot;
                            double data_calc_not_3 = data_calc_not_1 + data_calc_not_2;
                            double data_calc_not_4 = t1s6f21;

                            double data_calc_not_5 = lbltotalsummary1;
                            if (data_calc_not_5 < 0)
                            {
                                data_calc_not_5 = 0;
                            }

                            double data_calc_not_6 = data_calc_not_3 + data_calc_not_4 + data_calc_not_5;
                            double data_calc_not_7 = (data_calc_not_1 / totalperiodroundednot) * 12;
                            double data_calc_not_8 = (data_calc_not_2 / totalperiodroundednot) * 12;
                            double data_calc_not_9 = data_calc_not_7 + data_calc_not_8;
                            double data_calc_not_10 = (data_calc_not_4 / totalperiodroundednot) * 12;
                            double data_calc_not_11 = (data_calc_not_5 / totalperiodroundednot) * 12;
                            double data_calc_not_12 = data_calc_not_9 + data_calc_not_10 + data_calc_not_11;
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
                            double data_calc_not_23 = data_calc_not_20 + data_calc_not_21 + data_calc_not_22;
                            double data_calc_not_24 = 0;
                            if (data_calc_not_23 > 0)
                            {
                                data_calc_not_24 = Convert.ToDouble(data_calc_not_23);
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
                            if (data_calc_not_14 <= 0)
                            {
                                data_calc_not_27 = 0;
                            }
                            else if (data_calc_not_14 > 0 && data_calc_not_14 <= 50000000)
                            {
                                data_calc_not_27 = (0.05 * data_calc_not_14);
                            }
                            else if (data_calc_not_14 > 50000000 && data_calc_not_14 <= 250000000)
                            {
                                data_calc_not_27 = 0.15 * data_calc_not_14 - 5000000;
                            }
                            else if (data_calc_not_14 > 250000000 && data_calc_not_14 <= 500000000)
                            {
                                data_calc_not_27 = 0.25 * data_calc_not_14 - 55000000;
                            }
                            else
                            {
                                data_calc_not_27 = 0.3 * data_calc_not_14 - 55000000;
                            }
                            double data_calc_not_26 = data_calc_not_27 - data_calc_not_25;

                            double data_calc_not_29 = 0;
                            if (data_calc_not_15 <= 0)
                            {
                                data_calc_not_29 = 0;
                            }
                            else if (data_calc_not_15 > 0 && data_calc_not_15 <= 50000000)
                            {
                                data_calc_not_29 = (0.05 * data_calc_not_15);
                            }
                            else if (data_calc_not_15 > 50000000 && data_calc_not_15 <= 250000000)
                            {
                                data_calc_not_29 = 0.15 * data_calc_not_15 - 5000000;
                            }
                            else if (data_calc_not_14 > 250000000 && data_calc_not_14 <= 500000000)
                            {
                                data_calc_not_29 = 0.25 * data_calc_not_15 - 55000000;
                            }
                            else
                            {
                                data_calc_not_29 = 0.3 * data_calc_not_15 - 55000000;
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
                            if (string.IsNullOrEmpty(data.t1s2f1))
                            {
                                data_calc_not_35 = data_calc_not_7;
                                data_calc_not_36 = data_calc_not_8;
                                data_calc_not_38 = data_calc_not_10;
                                data_calc_not_39 = t1s6f24 / 12 * totalperiodroundednot;
                                data_calc_not_41 = data_calc_not_11;
                                data_calc_not_42 = tabirregulartotal1 / totalperiodroundednot * 12;
                            }

                            double data_calc_not_37 = data_calc_not_35 + data_calc_not_36;
                            double data_calc_not_40 = data_calc_not_38 + data_calc_not_39;
                            data_calc_not_42 = data_calc_not_42 * -1;
                            double data_calc_not_43 = data_calc_not_41 + data_calc_not_42;
                            double data_calc_not_44 = 0;
                            

                            if (string.IsNullOrEmpty(data.t1s2f1))
                            {
                                if (data_calc_not_43 > 0)
                                {
                                    data_calc_not_44 = data_calc_not_34 + data_calc_not_37 + data_calc_not_40 + data_calc_not_43;
                                }
                                else
                                {
                                    data_calc_not_44 = data_calc_not_34 + data_calc_not_37 + data_calc_not_40;
                                }
                            }

                            double data_calc_not_45 = 0;
                            double data_calc_not_47 = 0;
                            if (string.IsNullOrEmpty(data.t1s2f1))
                            {
                                data_calc_not_45 = Convert.ToDouble(data_calc_not_35) - t1s3f3;
                                data_calc_not_47 = Convert.ToDouble(data_calc_not_37) - t1s3f3;
                            }
                            double data_calc_not_46 = data_calc_not_36;
                            double data_calc_not_48 = t1s3f3;
                            double data_calc_not_49 = 0;

                            double data_calc_not_50 = 0;
                            double data_calc_not_51 = data_calc_not_36;
                            double data_calc_not_52 = 0;
                            double data_calc_not_53 = data_calc_not_40;
                            double data_calc_not_54 = 0;
                            if (string.IsNullOrEmpty(data.t1s2f1))
                            {
                                data_calc_not_50 = Convert.ToDouble(data_calc_not_35) - t1s3f3;
                                data_calc_not_51 = data_calc_not_36;
                                data_calc_not_52 = data_calc_not_50 + data_calc_not_51;
                                data_calc_not_53 = data_calc_not_40;
                                data_calc_not_54 = data_calc_not_43;
                            }

                            
                            double data_calc_not_55 = data_calc_not_52 + data_calc_not_53 + data_calc_not_54 + data_calc_not_50;
                            double data_calc_not_56 = 0;
                            if (data_calc_not_55 > 0)
                            {
                                data_calc_not_56 = Convert.ToDouble(data_calc_not_55);
                            }

                            if (data_calc_not_55 > 0)
                            {
                                data_calc_not_49 = data_calc_not_55;
                            }
                            double data_calc_not_58 = data_calc_not_46 * totalperiodroundednot / 12;
                            double data_calc_not_57 = data_calc_not_58 - data_calc_not_56;
                            double data_calc_not_60 = 0;
                            if (data_calc_not_56 <= 0)
                            {
                                data_calc_not_60 = 0;
                            }
                            else if (data_calc_not_56 > 0 && data_calc_not_56 <= 50000000)
                            {
                                data_calc_not_60 = (0.05 * data_calc_not_56);
                            }
                            else if (data_calc_not_56 > 50000000 && data_calc_not_56 <= 250000000)
                            {
                                data_calc_not_60 = 0.15 * data_calc_not_56 - 5000000;
                            }
                            else if (data_calc_not_56 > 250000000 && data_calc_not_56 <= 500000000)
                            {
                                data_calc_not_60 = 0.25 * data_calc_not_56 - 30000000;
                            }
                            else
                            {
                                data_calc_not_60 = 0.3 * data_calc_not_56 - 55000000;
                            }
                            double data_calc_not_59 = data_calc_not_60 - data_calc_not_58;
                            double data_calc_not_61 = data_calc_not_57 / 12 * totalperiodroundednot;
                            double data_calc_not_62 = data_calc_not_58 / totalperiodroundednot * 12;
                            double data_calc_not_63 = data_calc_not_61 + data_calc_not_62;
                            double data_calc_not_64 = data_calc_not_59 / 12 * totalperiodroundednot;
                            double data_calc_not_65 = data_calc_not_63 + data_calc_not_64;
                            double data_calc_not_66 = data_calc_not_64 + data_calc_not_65;

                            double data_calc_not_67 = 0;
                            double data_calc_not_68 = 0;
                            double data_calc_not_69 = 0;
                            if (string.IsNullOrEmpty(data.t1s2f1))
                            {
                                data_calc_not_67 = totalincometax;
                                data_calc_not_68 = lbltotalsummary2;
                                data_calc_not_69 = (tabirregulartotal2 - t1s6f25) * -1;
                            }

                            
                            double data_calc_not_70 = data_calc_not_67 + data_calc_not_68 + data_calc_not_69;
                            double data_calc_not_71 = data_calc_not_65 - data_calc_not_69 - data_calc_not_70;
                            double data_calc_not_72 = 12;
                            if (totalperiodroundednot < 12)
                            {
                                data_calc_not_72 = totalperiodroundednot;
                            }
                            double data_calc_not_73 = data_calc_not_71 / data_calc_not_72;

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
                            calc_not_1.Value = String.Format("{0:#,##0}", data_calc_rounded_1);
                            calc_not_2.Value = String.Format("{0:#,##0}", data_calc_rounded_2);
                            calc_not_3.Value = String.Format("{0:#,##0}", data_calc_rounded_3);
                            calc_not_4.Value = String.Format("{0:#,##0}", data_calc_rounded_4);
                            calc_not_5.Value = String.Format("{0:#,##0}", data_calc_rounded_5);
                            calc_not_6.Value = String.Format("{0:#,##0}", data_calc_rounded_6);
                            calc_not_7.Value = String.Format("{0:#,##0}", data_calc_rounded_7);
                            calc_not_8.Value = String.Format("{0:#,##0}", data_calc_rounded_8);
                            calc_not_9.Value = String.Format("{0:#,##0}", data_calc_rounded_9);
                            calc_not_10.Value = String.Format("{0:#,##0}", data_calc_rounded_10);
                            calc_not_11.Value = String.Format("{0:#,##0}", data_calc_rounded_11);
                            calc_not_12.Value = String.Format("{0:#,##0}", data_calc_rounded_12);
                            calc_not_13.Value = String.Format("{0:#,##0}", data_calc_rounded_13);
                            calc_not_14.Value = String.Format("{0:#,##0}", data_calc_rounded_14);
                            calc_not_15.Value = String.Format("{0:#,##0}", data_calc_rounded_15);
                            calc_not_16.Value = String.Format("{0:#,##0}", data_calc_rounded_16);
                            calc_not_17.Value = String.Format("{0:#,##0}", data_calc_rounded_17);
                            calc_not_18.Value = String.Format("{0:#,##0}", data_calc_rounded_18);
                            calc_not_19.Value = String.Format("{0:#,##0}", data_calc_rounded_19);
                            calc_not_20.Value = String.Format("{0:#,##0}", data_calc_rounded_20);
                            calc_not_21.Value = String.Format("{0:#,##0}", data_calc_rounded_21);
                            calc_not_22.Value = String.Format("{0:#,##0}", data_calc_rounded_22);
                            calc_not_23.Value = String.Format("{0:#,##0}", data_calc_rounded_23);
                            calc_not_24.Value = String.Format("{0:#,##0}", data_calc_rounded_24);
                            calc_not_25.Value = String.Format("{0:#,##0}", data_calc_rounded_25);
                            calc_not_26.Value = String.Format("{0:#,##0}", data_calc_rounded_26);
                            calc_not_27.Value = String.Format("{0:#,##0}", data_calc_rounded_27);
                            calc_not_28.Value = String.Format("{0:#,##0}", data_calc_rounded_28);
                            calc_not_29.Value = String.Format("{0:#,##0}", data_calc_rounded_29);
                            calc_not_30.Value = String.Format("{0:#,##0}", data_calc_rounded_30);
                            calc_not_31.Value = String.Format("{0:#,##0}", data_calc_rounded_31);
                            calc_not_32.Value = String.Format("{0:#,##0}", data_calc_rounded_32);
                            calc_not_33.Value = String.Format("{0:#,##0}", data_calc_rounded_33);
                            calc_not_34.Value = String.Format("{0:#,##0}", data_calc_rounded_34);
                            calc_not_35.Value = String.Format("{0:#,##0}", data_calc_rounded_35);
                            calc_not_36.Value = String.Format("{0:#,##0}", data_calc_rounded_36);
                            calc_not_37.Value = String.Format("{0:#,##0}", data_calc_rounded_37);
                            calc_not_38.Value = String.Format("{0:#,##0}", data_calc_rounded_38);
                            calc_not_39.Value = String.Format("{0:#,##0}", data_calc_rounded_39);
                            calc_not_40.Value = String.Format("{0:#,##0}", data_calc_rounded_40);
                            calc_not_41.Value = String.Format("{0:#,##0}", data_calc_rounded_41);
                            calc_not_42.Value = String.Format("{0:#,##0}", data_calc_rounded_42);
                            calc_not_43.Value = String.Format("{0:#,##0}", data_calc_rounded_43);
                            calc_not_44.Value = String.Format("{0:#,##0}", data_calc_rounded_44);
                            calc_not_45.Value = String.Format("{0:#,##0}", data_calc_rounded_45);
                            calc_not_46.Value = String.Format("{0:#,##0}", data_calc_rounded_46);
                            calc_not_47.Value = String.Format("{0:#,##0}", data_calc_rounded_47);
                            calc_not_48.Value = String.Format("{0:#,##0}", data_calc_rounded_48);
                            calc_not_49.Value = String.Format("{0:#,##0}", data_calc_rounded_49);
                            calc_not_50.Value = String.Format("{0:#,##0}", data_calc_rounded_50);
                            calc_not_51.Value = String.Format("{0:#,##0}", data_calc_rounded_51);
                            calc_not_52.Value = String.Format("{0:#,##0}", data_calc_rounded_52);
                            calc_not_53.Value = String.Format("{0:#,##0}", data_calc_rounded_53);
                            calc_not_54.Value = String.Format("{0:#,##0}", data_calc_rounded_54);
                            calc_not_55.Value = String.Format("{0:#,##0}", data_calc_rounded_55);
                            calc_not_56.Value = String.Format("{0:#,##0}", data_calc_rounded_56);
                            calc_not_57.Value = String.Format("{0:#,##0}", data_calc_rounded_57);
                            calc_not_58.Value = String.Format("{0:#,##0}", data_calc_rounded_58);
                            calc_not_59.Value = String.Format("{0:#,##0}", data_calc_rounded_59);
                            calc_not_60.Value = String.Format("{0:#,##0}", data_calc_rounded_60);
                            calc_not_61.Value = String.Format("{0:#,##0}", data_calc_rounded_61);
                            calc_not_62.Value = String.Format("{0:#,##0}", data_calc_rounded_62);
                            calc_not_63.Value = String.Format("{0:#,##0}", data_calc_rounded_63);
                            calc_not_64.Value = String.Format("{0:#,##0}", data_calc_rounded_64);
                            calc_not_65.Value = String.Format("{0:#,##0}", data_calc_rounded_65);
                            calc_not_66.Value = String.Format("{0:#,##0}", data_calc_rounded_66);
                            calc_not_67.Value = String.Format("{0:#,##0}", data_calc_rounded_67);
                            calc_not_68.Value = String.Format("{0:#,##0}", data_calc_rounded_68);
                            calc_not_69.Value = String.Format("{0:#,##0}", data_calc_rounded_69);
                            calc_not_70.Value = String.Format("{0:#,##0}", data_calc_rounded_70);
                            calc_not_71.Value = String.Format("{0:#,##0}", data_calc_rounded_71);
                            calc_not_72.Value = String.Format("{0:#,##0}", data_calc_rounded_72);
                            calc_not_73.Value = String.Format("{0:#,##0}", data_calc_rounded_73);

                        }
                }
                else{
                    //load from database
                    foreach(vm.Calculation calculation in calculations){
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
                Response.Redirect("~/formjapan.aspx?id=" + hdid.Value);
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
                        selectedarr.Add(6);
                        selectedfilenamearr.Add("1770SJP");
                    }
                    else if (i == 2)
                    {
                        selectedarr.Add(7);
                        selectedfilenamearr.Add("1770 S-1JP");
                    }
                    else if (i == 3)
                    {
                        selectedarr.Add(8);
                        selectedfilenamearr.Add("1770 S-IIJP");
                        selectedarr.Add(9);
                        selectedfilenamearr.Add("1770 S-II JP (2)");
                    }
                    else if (i == 4)
                    {
                        selectedarr.Add(12);
                        selectedfilenamearr.Add("Attachment");
                    }
                    else if (i == 5)
                    {
                        selectedarr.Add(13);
                        selectedfilenamearr.Add("1770S");
                    }
                    else if (i == 6)
                    {
                        selectedarr.Add(14);
                        selectedfilenamearr.Add("1770 S-I");
                    }
                    else if (i == 7)
                    {
                        selectedarr.Add(15);
                        selectedfilenamearr.Add("1770 S-II");
                        selectedarr.Add(16);
                        selectedfilenamearr.Add("1770 S-II (2)");
                    }
                    else if (i == 8)
                    {
                        selectedarr.Add(17);
                        selectedfilenamearr.Add("Lampiran");
                    }
                    else if (i == 9)
                    {
                        selectedarr.Add(10);
                        selectedfilenamearr.Add("1721-A1-JP (1)");
                        selectedarr.Add(11);
                        selectedfilenamearr.Add("1721-A1-JP (2)");
                    }
                    else if (i == 10)
                    {
                        selectedarr.Add(0);
                        selectedfilenamearr.Add("Form1770Japan");
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
                selectedfilenamearr.Add("Form1770Japan");
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
            string templatename = "Form1770SJapan";
            try
            {
                debugtext = "DEBUG 1 ";
                SLDocument slDoc = new SLDocument(templatePath + templatename + ".xlsx", "GENERAL INFO");

                List<vm.TaxForm> taxforms = _servicesTaxForm.GetAllBy(hdtaxidnumber.Value, formType, hdtaxyear.Value, 1, Convert.ToInt32(hdid.Value));

                debugtext = "DEBUG 2 ";
                foreach (vm.TaxForm taxform in taxforms)
                {
                    if (!string.IsNullOrEmpty(taxform.t1s1f2))
                    {
                        thename = getLastNameCommaFirstName(taxform.t1s1f2);
                    }
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

                    slDoc.SetCellValue("G14", taxidnumber);
                    slDoc.SetCellValue("G16", taxform.t1s1f2.ToUpper());
                    slDoc.SetCellValue("G18", taxform.t1s1f5);


                    if (t1s1f8.Length > 3)
                    {
                        slDoc.SetCellValue("G20", t1s1f8.Substring(0, 3));
                        slDoc.SetCellValue("K20", t1s1f8.Substring(3, t1s1f8.Length - 3));
                    }
                    else
                    {
                        slDoc.SetCellValue("K20", t1s1f8);
                    }

                    if (t1s1f4.Length > 3)
                    {
                        slDoc.SetCellValue("G22", t1s1f4.Substring(0, 3));
                        slDoc.SetCellValue("K22", t1s1f4.Substring(3, t1s1f4.Length - 3));
                    }
                    else
                    {
                        slDoc.SetCellValue("K22", t1s1f4);
                    }

                    slDoc.SetCellValue("G24", taxform.t1s1f7);
                    slDoc.SetCellValue("G26", t1s1f6);

                    if (taxform.year.Length >= 4)
                    {
                        //year
                        slDoc.SetCellValue("F31", taxform.year.Substring(0, 1).ToString());
                        slDoc.SetCellValue("G31", taxform.year.Substring(1, 1).ToString());
                        slDoc.SetCellValue("H31", taxform.year.Substring(2, 1).ToString());
                        slDoc.SetCellValue("I31", taxform.year.Substring(3, 1).ToString());
                    }

                    string t1s2f1 = "";
                    if (taxform.t1s2f1 != "")
                    {
                        if (taxform.t1s2f1.Contains("/"))
                        {
                            string year = taxform.t1s2f1.Split('/')[2];
                            if (year.Length == 4)
                            {
                                year = year.Substring(2, 2);
                            }
                            t1s2f1 = taxform.t1s2f1.Split('/')[1] + "/" + taxform.t1s2f1.Split('/')[0] + "/" + year;
                        }

                    }
                    if (!string.IsNullOrEmpty(t1s2f1))
                    {
                        slDoc.SetCellValue("F33", Convert.ToDateTime(t1s2f1));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s2f2))
                    {
                        slDoc.SetCellValue("T33", Convert.ToInt32(taxform.t1s2f2));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s2f4))
                    {
                        slDoc.SetCellValue("T36", Convert.ToDouble(taxform.t1s2f4));
                    }
                    if (taxform.t1s2f5.Length == 10)
                    {
                        slDoc.SetCellValue("F36", taxform.t1s2f5.Substring(0, 1).ToString());
                        slDoc.SetCellValue("G36", taxform.t1s2f5.Substring(1, 1).ToString());
                        slDoc.SetCellValue("H36", taxform.t1s2f5.Substring(3, 1).ToString());
                        slDoc.SetCellValue("I36", taxform.t1s2f5.Substring(4, 1).ToString());
                        slDoc.SetCellValue("J36", taxform.t1s2f5.Substring(8, 1).ToString());
                        slDoc.SetCellValue("K36", taxform.t1s2f5.Substring(9, 1).ToString());
                    }
                    if (taxform.t1s2f6 == "Refund")
                    {
                        slDoc.SetCellValue("F38", "X");
                    }
                    else if (taxform.t1s2f6 == "Offset Against The Tax Liabilites")
                    {
                        slDoc.SetCellValue("F40", "X");
                    }
                    else if (taxform.t1s2f6 == "Return With SKPPKP Art. 17 C (obedient Taxpayer)")
                    {
                        slDoc.SetCellValue("O38", "X");
                    }
                    else if (taxform.t1s2f6 == "Return With SKKPP Art. 17 D (certain Taxpayer)")
                    {
                        slDoc.SetCellValue("O40", "X");
                    }

                    if (taxform.t1s2f16 == "True")
                    {
                        slDoc.SetCellValue("F43", "X");
                    }

                    if (taxform.t1s2f12 == "True")
                    {
                        slDoc.SetCellValue("F45", "X");
                    }

                    if (taxform.t1s2f11 == "True")
                    {
                        slDoc.SetCellValue("F47", "X");
                    }

                    if (taxform.t1s2f20 == "True")
                    {
                        slDoc.SetCellValue("F49", "X");
                    }

                    if (taxform.t1s2f13 == "True")
                    {
                        slDoc.SetCellValue("F52", "X");
                    }

                    if (taxform.t1s2f10 == "True")
                    {
                        slDoc.SetCellValue("W55", "X");
                    }

                    slDoc.SetCellValue("H52", taxform.t1s2f18);
                    slDoc.SetCellValue("Q52", taxform.t1s2f19);
                    slDoc.SetCellValue("H54", taxform.t1s2f23);
                    slDoc.SetCellValue("Q54", taxform.t1s2f24);



                    if (taxform.t1s2f7 == "Taxpayer")
                    {
                        slDoc.SetCellValue("B58", "X");
                    }
                    else if (taxform.t1s2f7 == "Proxy")
                    {
                        slDoc.SetCellValue("B59", "X");
                    }
                    slDoc.SetCellValue("D59", taxform.t1s2f8);
                    slDoc.SetCellValue("D60", taxform.t1s2f9);


                    if (taxform.t1s3f1.ToUpper() == "MARRIED1")
                    {
                        slDoc.SetCellValue("F64", "MARRIED");
                    }
                    else if (taxform.t1s3f1.ToUpper() == "MARRIED2")
                    {
                        slDoc.SetCellValue("F64", "MARRIED+");
                    }
                    else
                    {
                        slDoc.SetCellValue("F64", taxform.t1s3f1.ToUpper());
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s3f2))
                    {
                        slDoc.SetCellValue("F65", Convert.ToInt32(taxform.t1s3f2));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s3f3) && taxform.t1s3f3 != "0")
                    {
                        slDoc.SetCellValue("F66", Convert.ToDouble(taxform.t1s3f3));
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
                            slDoc.SetCellValue("F66", Convert.ToDouble(t1s3f3));
                        }
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f1))
                    {
                        slDoc.SetCellValue("D84", Convert.ToDouble(taxform.t1s4f1));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f3))
                    {
                        slDoc.SetCellValue("H84", Convert.ToDouble(taxform.t1s4f3));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f5))
                    {
                        slDoc.SetCellValue("D85", Convert.ToDouble(taxform.t1s4f5));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f7))
                    {
                        slDoc.SetCellValue("H85", Convert.ToDouble(taxform.t1s4f7));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f9))
                    {
                        slDoc.SetCellValue("D86", Convert.ToDouble(taxform.t1s4f9));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f11))
                    {
                        slDoc.SetCellValue("H86", Convert.ToDouble(taxform.t1s4f11));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f13))
                    {
                        slDoc.SetCellValue("D87", Convert.ToDouble(taxform.t1s4f13));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f15))
                    {
                        slDoc.SetCellValue("H87", Convert.ToDouble(taxform.t1s4f15));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f17))
                    {
                        slDoc.SetCellValue("D88", Convert.ToDouble(taxform.t1s4f17));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f19))
                    {
                        slDoc.SetCellValue("H88", Convert.ToDouble(taxform.t1s4f19));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f21))
                    {
                        slDoc.SetCellValue("D89", Convert.ToDouble(taxform.t1s4f21));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f23))
                    {
                        slDoc.SetCellValue("H89", Convert.ToDouble(taxform.t1s4f23));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f25))
                    {
                        slDoc.SetCellValue("D90", Convert.ToDouble(taxform.t1s4f25));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f27))
                    {
                        slDoc.SetCellValue("H90", Convert.ToDouble(taxform.t1s4f27));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f29))
                    {
                        slDoc.SetCellValue("D91", Convert.ToDouble(taxform.t1s4f29));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f31))
                    {
                        slDoc.SetCellValue("H91", Convert.ToDouble(taxform.t1s4f31));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f33))
                    {
                        slDoc.SetCellValue("D92", Convert.ToDouble(taxform.t1s4f33));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f35))
                    {
                        slDoc.SetCellValue("H92", Convert.ToDouble(taxform.t1s4f35));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f37))
                    {
                        slDoc.SetCellValue("D93", Convert.ToDouble(taxform.t1s4f37));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f39))
                    {
                        slDoc.SetCellValue("H93", Convert.ToDouble(taxform.t1s4f39));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f41))
                    {
                        slDoc.SetCellValue("D94", Convert.ToDouble(taxform.t1s4f41));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f43))
                    {
                        slDoc.SetCellValue("H94", Convert.ToDouble(taxform.t1s4f43));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f45))
                    {
                        slDoc.SetCellValue("D95", Convert.ToDouble(taxform.t1s4f45));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f47))
                    {
                        slDoc.SetCellValue("H95", Convert.ToDouble(taxform.t1s4f47));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f53))
                    {
                        slDoc.SetCellValue("H99", Convert.ToDouble(taxform.t1s4f53));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s4f54))
                    {
                        slDoc.SetCellValue("L99", Convert.ToDouble(taxform.t1s4f54));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s8f1))
                    {
                        slDoc.SetCellValue("K101", Convert.ToDouble(taxform.t1s8f1));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s4f55))
                    {
                        slDoc.SetCellValue("K102", Convert.ToDouble(taxform.t1s4f55));
                    }


                    if (!string.IsNullOrEmpty(taxform.t1s6f1))
                    {
                        slDoc.SetCellValue("L156", Convert.ToDouble(taxform.t1s6f1));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f2))
                    {
                        slDoc.SetCellValue("Q156", Convert.ToDouble(taxform.t1s6f2));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f4))
                    {
                        slDoc.SetCellValue("L157", Convert.ToDouble(taxform.t1s6f4));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f5))
                    {
                        slDoc.SetCellValue("Q157", Convert.ToDouble(taxform.t1s6f5));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f7))
                    {
                        slDoc.SetCellValue("L158", Convert.ToDouble(taxform.t1s6f7));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f8))
                    {
                        slDoc.SetCellValue("Q158", Convert.ToDouble(taxform.t1s6f8));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f10))
                    {
                        slDoc.SetCellValue("L159", Convert.ToDouble(taxform.t1s6f10));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f11))
                    {
                        slDoc.SetCellValue("Q159", Convert.ToDouble(taxform.t1s6f11));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f13))
                    {
                        slDoc.SetCellValue("L160", Convert.ToDouble(taxform.t1s6f13));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f14))
                    {
                        slDoc.SetCellValue("Q160", Convert.ToDouble(taxform.t1s6f14));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f16))
                    {
                        slDoc.SetCellValue("L161", Convert.ToDouble(taxform.t1s6f16));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f17))
                    {
                        slDoc.SetCellValue("Q161", Convert.ToDouble(taxform.t1s6f17));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f22))
                    {
                        slDoc.SetCellValue("L165", Convert.ToDouble(taxform.t1s6f22));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f23))
                    {
                        slDoc.SetCellValue("Q165", Convert.ToDouble(taxform.t1s6f23));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s6f25))
                    {
                        slDoc.SetCellValue("V166", Convert.ToDouble(taxform.t1s6f25));
                    }


                    if (!string.IsNullOrEmpty(taxform.t1s7f1))
                    {
                        slDoc.SetCellValue("O172", Convert.ToDouble(taxform.t1s7f1));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f2))
                    {
                        slDoc.SetCellValue("T172", Convert.ToDouble(taxform.t1s7f2));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f3))
                    {
                        slDoc.SetCellValue("O173", Convert.ToDouble(taxform.t1s7f3));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f4))
                    {
                        slDoc.SetCellValue("T173", Convert.ToDouble(taxform.t1s7f4));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f5))
                    {
                        slDoc.SetCellValue("O174", Convert.ToDouble(taxform.t1s7f5));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f6))
                    {
                        slDoc.SetCellValue("T174", Convert.ToDouble(taxform.t1s7f6));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f7))
                    {
                        slDoc.SetCellValue("O175", Convert.ToDouble(taxform.t1s7f7));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f8))
                    {
                        slDoc.SetCellValue("T175", Convert.ToDouble(taxform.t1s7f8));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f9))
                    {
                        slDoc.SetCellValue("O176", Convert.ToDouble(taxform.t1s7f9));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f10))
                    {
                        slDoc.SetCellValue("T176", Convert.ToDouble(taxform.t1s7f10));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f11))
                    {
                        slDoc.SetCellValue("O177", Convert.ToDouble(taxform.t1s7f11));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f12))
                    {
                        slDoc.SetCellValue("T177", Convert.ToDouble(taxform.t1s7f12));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f13))
                    {
                        slDoc.SetCellValue("O178", Convert.ToDouble(taxform.t1s7f13));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f14))
                    {
                        slDoc.SetCellValue("T178", Convert.ToDouble(taxform.t1s7f14));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f15))
                    {
                        slDoc.SetCellValue("O179", Convert.ToDouble(taxform.t1s7f15));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f16))
                    {
                        slDoc.SetCellValue("T179", Convert.ToDouble(taxform.t1s7f16));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f17))
                    {
                        slDoc.SetCellValue("O180", Convert.ToDouble(taxform.t1s7f17));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f18))
                    {
                        slDoc.SetCellValue("T180", Convert.ToDouble(taxform.t1s7f18));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f19))
                    {
                        slDoc.SetCellValue("O181", Convert.ToDouble(taxform.t1s7f19));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f20))
                    {
                        slDoc.SetCellValue("T181", Convert.ToDouble(taxform.t1s7f20));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f21))
                    {
                        slDoc.SetCellValue("O183", Convert.ToDouble(taxform.t1s7f21));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f22))
                    {
                        slDoc.SetCellValue("T183", Convert.ToDouble(taxform.t1s7f22));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f23))
                    {
                        slDoc.SetCellValue("O184", Convert.ToDouble(taxform.t1s7f23));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f24))
                    {
                        slDoc.SetCellValue("T184", Convert.ToDouble(taxform.t1s7f24));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f25))
                    {
                        slDoc.SetCellValue("O185", Convert.ToDouble(taxform.t1s7f25));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f26))
                    {
                        slDoc.SetCellValue("T185", Convert.ToDouble(taxform.t1s7f26));
                    }


                    if (!string.IsNullOrEmpty(taxform.t1s7f33))
                    {
                        slDoc.SetCellValue("O191", Convert.ToDouble(taxform.t1s7f33));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f34))
                    {
                        slDoc.SetCellValue("O192", Convert.ToDouble(taxform.t1s7f34));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f35))
                    {
                        slDoc.SetCellValue("O193", Convert.ToDouble(taxform.t1s7f35));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f36))
                    {
                        slDoc.SetCellValue("O194", Convert.ToDouble(taxform.t1s7f36));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f37))
                    {
                        slDoc.SetCellValue("O195", Convert.ToDouble(taxform.t1s7f37));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s7f38))
                    {
                        slDoc.SetCellValue("O196", Convert.ToDouble(taxform.t1s7f38));
                    }


                    debugtext = "DEBUG 3 ";
                    List<vm.Family> families = _servicesFamily.GetAllBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, taxform.ammend);
                    a = 0;
                    foreach (vm.Family data in families)
                    {
                        if (a < 5)
                        {
                            slDoc.SetCellValue("C" + ((a * 1) + 71), data.Name);
                            slDoc.SetCellValue("E" + ((a * 1) + 71), data.Relationship);
                            slDoc.SetCellValue("J" + ((a * 1) + 71), data.NIK);
                            slDoc.SetCellValue("N" + ((a * 1) + 71), data.Occupation);
                        }
                        a++;
                    }

                    debugtext = "DEBUG 4 ";
                    ieincome = _servicesIncome.GetAllBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, taxform.ammend);
                    a = 0;
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

                            if (!string.IsNullOrEmpty(data.field1))
                            {
                                slDoc.SetCellValue(col + "108", Convert.ToDateTime(dataf1.ToString()));
                            }
                            if (!string.IsNullOrEmpty(data.field2))
                            {
                                slDoc.SetCellValue(col2 + "108", Convert.ToDateTime(dataf2.ToString()));
                            }

                            string field5 = data.field5.Replace(".", "");
                            field5 = field5.Replace("-", "");
                            string field6 = data.field6.Replace(".", "");
                            field6 = field6.Replace("-", "");

                            slDoc.SetCellValue(col + "110", data.field4);
                            slDoc.SetCellValue(col + "111", field5);
                            slDoc.SetCellValue(col + "112", field6);
                            string dataf7 = "";
                            if (!string.IsNullOrEmpty(data.field7))
                            {
                                string[] f7 = data.field7.ToString().Split('/');
                                dataf7 = f7[1] + "/" + f7[0] + "/" + f7[2];
                            }
                            if (dataf7 != "")
                            {
                                slDoc.SetCellValue(col + "113", Convert.ToDateTime(dataf7));
                            }
                            if (data.field8 == "Yes")
                            {
                                slDoc.SetCellValue(col + "114", "X");
                            }

                            if (!string.IsNullOrEmpty(data.field9))
                            {
                                slDoc.SetCellValue(col + "118", Convert.ToDouble(data.field9));
                            }
                            if (!string.IsNullOrEmpty(data.field10))
                            {
                                slDoc.SetCellValue(col + "119", Convert.ToDouble(data.field10));
                            }
                            if (!string.IsNullOrEmpty(data.field11))
                            {
                                slDoc.SetCellValue(col + "120", Convert.ToDouble(data.field11));
                            }
                            if (!string.IsNullOrEmpty(data.field12))
                            {
                                slDoc.SetCellValue(col + "121", Convert.ToDouble(data.field12));
                            }
                            if (!string.IsNullOrEmpty(data.field13))
                            {
                                slDoc.SetCellValue(col + "122", Convert.ToDouble(data.field13));
                            }
                            if (!string.IsNullOrEmpty(data.field14))
                            {
                                slDoc.SetCellValue(col + "123", Convert.ToDouble(data.field14));
                            }
                            if (!string.IsNullOrEmpty(data.field15))
                            {
                                slDoc.SetCellValue(col + "124", Convert.ToDouble(data.field15));
                            }
                            if (!string.IsNullOrEmpty(data.field17))
                            {
                                slDoc.SetCellValue(col + "128", Convert.ToDouble(data.field17));
                            }
                            if (!string.IsNullOrEmpty(data.field24))
                            {
                                slDoc.SetCellValue(col + "129", Convert.ToDouble(data.field24));
                            }
                            if (!string.IsNullOrEmpty(data.field18))
                            {
                                slDoc.SetCellValue(col + "130", Convert.ToDouble(data.field18));
                            }
                            if (!string.IsNullOrEmpty(data.field22))
                            {
                                slDoc.SetCellValue(col + "136", Convert.ToDouble(data.field22));
                            }

                            if (!string.IsNullOrEmpty(data.field23))
                            {
                                slDoc.SetCellValue(col + "137", Convert.ToDouble(data.field23));
                            }

                            if (!string.IsNullOrEmpty(data.field25))
                            {
                                slDoc.SetCellValue(col + "139", Convert.ToDouble(data.field25));
                            }

                            if (!string.IsNullOrEmpty(data.field26))
                            {
                                slDoc.SetCellValue(col + "141", Convert.ToDouble(data.field26));
                            }

                            if (!string.IsNullOrEmpty(data.field27))
                            {
                                slDoc.SetCellValue(col + "145", Convert.ToDouble(data.field27));
                            }

                            if (!string.IsNullOrEmpty(data.field21))
                            {
                                slDoc.SetCellValue(col + "147", Convert.ToDouble(data.field21));
                            }

                            if (!string.IsNullOrEmpty(data.field28))
                            {
                                slDoc.SetCellValue(col + "150", Convert.ToDouble(data.field28));
                            }

                            if (!string.IsNullOrEmpty(data.field29))
                            {
                                slDoc.SetCellValue(col + "151", Convert.ToDouble(data.field29));
                            }

                        }
                        a++;
                    }

                    debugtext = "DEBUG 5 ";
                    //======================================
                    slDoc.SelectWorksheet("JAPANESE INCOME");

                    if (!string.IsNullOrEmpty(taxform.t1s8f2))
                    {
                        slDoc.SetCellValue("F" + "115", Convert.ToDouble(taxform.t1s8f2));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f4))
                    {
                        slDoc.SetCellValue("F" + "116", Convert.ToDouble(taxform.t1s8f4));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f6))
                    {
                        slDoc.SetCellValue("F" + "117", Convert.ToDouble(taxform.t1s8f6));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f8))
                    {
                        slDoc.SetCellValue("F" + "118", Convert.ToDouble(taxform.t1s8f8));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f10))
                    {
                        slDoc.SetCellValue("F" + "119", Convert.ToDouble(taxform.t1s8f10));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f12))
                    {
                        slDoc.SetCellValue("F" + "120", Convert.ToDouble(taxform.t1s8f12));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f14))
                    {
                        slDoc.SetCellValue("F" + "121", Convert.ToDouble(taxform.t1s8f14));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f16))
                    {
                        slDoc.SetCellValue("F" + "122", Convert.ToDouble(taxform.t1s8f16));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f18))
                    {
                        slDoc.SetCellValue("F" + "123", Convert.ToDouble(taxform.t1s8f18));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f20))
                    {
                        slDoc.SetCellValue("F" + "124", Convert.ToDouble(taxform.t1s8f20));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f22))
                    {
                        slDoc.SetCellValue("F" + "125", Convert.ToDouble(taxform.t1s8f22));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f24))
                    {
                        slDoc.SetCellValue("F" + "126", Convert.ToDouble(taxform.t1s8f24));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f26))
                    {
                        slDoc.SetCellValue("F" + "127", Convert.ToDouble(taxform.t1s8f26));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f28))
                    {
                        slDoc.SetCellValue("F" + "128", Convert.ToDouble(taxform.t1s8f28));
                    }
                    if (!string.IsNullOrEmpty(taxform.t1s8f30))
                    {
                        slDoc.SetCellValue("F" + "129", Convert.ToDouble(taxform.t1s8f30));
                    }

                    List<string> countryList = new List<string>();
                    countryList.Add("Japan");

                    List<vm.Irregulardata> Irregulardatas = new List<vm.Irregulardata>();

                    debugtext = "DEBUG 5 ";
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
                                    slDoc.SetCellValue("B" + ((a * 111) + (b + 8)), thedate);
                                }
                                else if (data.interval == "3")
                                {
                                    slDoc.SetCellValue("B" + ((a * 111) + (b + 8)), "JanDec" + year);
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
                                    slDoc.SetCellValue("B" + ((a * 111) + (b + 8)), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("B" + ((a * 111) + (b + 8)), Convert.ToDateTime(datereceipt));
                                }

                                slDoc.SetCellValue("D" + ((a * 111) + (b + 8)), data.currency);
                                if (!string.IsNullOrEmpty(data.incomecurrency))
                                {
                                    slDoc.SetCellValue("F" + ((a * 111) + (b + 8)), Convert.ToDouble(data.incomecurrency));
                                }
                                if (!string.IsNullOrEmpty(data.taxpaidcurrency))
                                {
                                    slDoc.SetCellValue("G" + ((a * 111) + (b + 8)), Convert.ToDouble(data.taxpaidcurrency));
                                }
                                if (!string.IsNullOrEmpty(data.exchrate))
                                {
                                    slDoc.SetCellValue("H" + ((a * 111) + (b + 8)), Convert.ToDouble(data.exchrate));
                                }

                                if (data.irregularincome == "yes" && ir <= 5)
                                {
                                    vm.Irregulardata dataexist = Irregulardatas.Find(x => x.country == data.country && x.indonesian == "Penghasilan dari Jepang");
                                    if (dataexist == null)
                                    {
                                        vm.Irregulardata irregulardata = new vm.Irregulardata();
                                        irregulardata.ir = ir;
                                        irregulardata.country = "Japan";
                                        irregulardata.english = "Japan Salary from Certificate of Income (CoI)";
                                        irregulardata.indonesian = "Penghasilan dari Jepang";
                                        irregulardata.currency = data.currency;
                                        if (data.incomecurrency != "")
                                        {
                                            irregulardata.incomecurrency = Convert.ToDouble(data.incomecurrency);
                                        }
                                        else
                                        {
                                            irregulardata.incomecurrency = 0;
                                        }
                                        if (data.incomerp != "")
                                        {
                                            irregulardata.bil1 = Convert.ToDouble(data.incomerp);
                                        }
                                        else
                                        {
                                            irregulardata.bil1 = 0;
                                        }
                                        if (data.taxpaidrp != "")
                                        {
                                            irregulardata.bil2 = Convert.ToDouble(data.taxpaidrp);
                                        }
                                        else
                                        {
                                            irregulardata.bil2 = 0;
                                        }

                                        Irregulardatas.Add(irregulardata);
                                        ir++;
                                    }
                                    else
                                    {
                                        vm.Irregulardata irregulardata = new vm.Irregulardata();
                                        irregulardata.ir = dataexist.ir;
                                        irregulardata.country = dataexist.country;
                                        irregulardata.english = dataexist.english;
                                        irregulardata.indonesian = dataexist.indonesian;
                                        irregulardata.currency = dataexist.currency;

                                        if (data.incomecurrency != "")
                                        {
                                            irregulardata.incomecurrency = dataexist.incomecurrency + Convert.ToDouble(data.incomecurrency);
                                        }
                                        else
                                        {
                                            irregulardata.incomecurrency = dataexist.incomecurrency + 0;
                                        }
                                        if (data.incomerp != "")
                                        {
                                            irregulardata.bil1 = dataexist.bil1 + Convert.ToDouble(data.incomerp);
                                        }
                                        else
                                        {
                                            irregulardata.bil1 = dataexist.bil1 + 0;
                                        }
                                        if (data.taxpaidrp != "")
                                        {
                                            irregulardata.bil2 = dataexist.bil2 + Convert.ToDouble(data.taxpaidrp);
                                        }
                                        else
                                        {
                                            irregulardata.bil2 = dataexist.bil2 + +0;
                                        }

                                        Irregulardatas[dataexist.ir] = irregulardata;
                                    }
                                }
                                b++;
                            }
                        }
                    }


                    debugtext = "DEBUG 7 ";
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
                                    slDoc.SetCellValue("B" + ((a * 111) + (b + 31)), thedate);
                                }
                                else if (data.interval == "3")
                                {
                                    slDoc.SetCellValue("B" + ((a * 111) + (b + 31)), "JanDec" + year);
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
                                    slDoc.SetCellValue("B" + ((a * 111) + (b + 31)), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("B" + ((a * 111) + (b + 31)), Convert.ToDateTime(datereceipt));
                                }
                                slDoc.SetCellValue("D" + ((a * 111) + (b + 31)), data.currency);
                                if (!string.IsNullOrEmpty(data.incomecurrency))
                                {
                                    slDoc.SetCellValue("F" + ((a * 111) + (b + 31)), Convert.ToDouble(data.incomecurrency));
                                }
                                if (!string.IsNullOrEmpty(data.taxpaidcurrency))
                                {
                                    slDoc.SetCellValue("G" + ((a * 111) + (b + 31)), Convert.ToDouble(data.taxpaidcurrency));
                                }
                                if (!string.IsNullOrEmpty(data.exchrate))
                                {
                                    slDoc.SetCellValue("H" + ((a * 111) + (b + 31)), Convert.ToDouble(data.exchrate));
                                }

                                if (data.irregularincome == "yes" && ir <= 5)
                                {
                                    vm.Irregulardata dataexist = Irregulardatas.Find(x => x.country == data.country && x.indonesian == "Penghasilan dari Jepang");
                                    if (dataexist == null)
                                    {
                                        vm.Irregulardata irregulardata = new vm.Irregulardata();
                                        irregulardata.ir = ir;
                                        irregulardata.country = "Japan";
                                        irregulardata.english = "Japan Salary from Certificate of Income (CoI)";
                                        irregulardata.indonesian = "Penghasilan dari Jepang";
                                        irregulardata.currency = data.currency;
                                        irregulardata.incomecurrency = Convert.ToDouble(data.incomecurrency);
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
                                        irregulardata.english = dataexist.english;
                                        irregulardata.indonesian = dataexist.indonesian;
                                        irregulardata.currency = dataexist.currency;
                                        irregulardata.incomecurrency = dataexist.incomecurrency + Convert.ToDouble(data.incomecurrency);
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
                                }

                                if (data.interval == "4")
                                {
                                    string thedate = data.dateofreceipt;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("B" + ((a * 111) + (b + 54)), thedate);
                                }
                                else if (data.interval == "3")
                                {
                                    slDoc.SetCellValue("B" + ((a * 111) + (b + 54)), "JanDec" + year);
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
                                    slDoc.SetCellValue("B" + ((a * 111) + (b + 54)), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("B" + ((a * 111) + (b + 54)), Convert.ToDateTime(datereceipt));
                                }
                                slDoc.SetCellValue("D" + ((a * 111) + (b + 54)), data.currency);
                                if (!string.IsNullOrEmpty(data.incomecurrency))
                                {
                                    slDoc.SetCellValue("F" + ((a * 111) + (b + 54)), Convert.ToDouble(data.incomecurrency));
                                }
                                if (!string.IsNullOrEmpty(data.taxpaidcurrency))
                                {
                                    slDoc.SetCellValue("G" + ((a * 111) + (b + 54)), Convert.ToDouble(data.taxpaidcurrency));
                                }
                                if (!string.IsNullOrEmpty(data.exchrate))
                                {
                                    slDoc.SetCellValue("H" + ((a * 111) + (b + 54)), Convert.ToDouble(data.exchrate));
                                }

                                if (data.irregularincome == "yes" && ir <= 5)
                                {
                                    vm.Irregulardata dataexist = Irregulardatas.Find(x => x.country == data.country && x.indonesian == "Penghasilan lainnya");
                                    if (dataexist == null)
                                    {
                                        vm.Irregulardata irregulardata = new vm.Irregulardata();
                                        irregulardata.ir = ir;
                                        irregulardata.country = "Japan";
                                        irregulardata.english = "Other payments/allowances from Certificate of Salary";
                                        irregulardata.indonesian = "Penghasilan lainnya";
                                        irregulardata.currency = data.currency;
                                        irregulardata.incomecurrency = Convert.ToDouble(data.incomecurrency);
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
                                        irregulardata.english = dataexist.english;
                                        irregulardata.indonesian = dataexist.indonesian;
                                        irregulardata.currency = dataexist.currency;
                                        irregulardata.incomecurrency = dataexist.incomecurrency + Convert.ToDouble(data.incomecurrency);
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
                        ovincome = _servicesOvIncome.GetAllBy3(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, country, 4, taxform.ammend);
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
                                    slDoc.SetCellValue("B" + ((a * 111) + (b + 77)), thedate);
                                }
                                else if (data.interval == "3")
                                {
                                    slDoc.SetCellValue("B" + ((a * 111) + (b + 77)), "JanDec" + year);
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
                                    slDoc.SetCellValue("B" + ((a * 111) + (b + 77)), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("B" + ((a * 111) + (b + 77)), Convert.ToDateTime(datereceipt));
                                }
                                slDoc.SetCellValue("D" + ((a * 111) + (b + 77)), data.currency);
                                if (!string.IsNullOrEmpty(data.incomecurrency))
                                {
                                    slDoc.SetCellValue("F" + ((a * 111) + (b + 77)), Convert.ToDouble(data.incomecurrency));
                                }
                                if (!string.IsNullOrEmpty(data.taxpaidcurrency))
                                {
                                    slDoc.SetCellValue("G" + ((a * 111) + (b + 77)), Convert.ToDouble(data.taxpaidcurrency));
                                }
                                if (!string.IsNullOrEmpty(data.exchrate))
                                {
                                    slDoc.SetCellValue("H" + ((a * 111) + (b + 77)), Convert.ToDouble(data.exchrate));
                                }

                                if (data.irregularincome == "yes" && ir <= 5)
                                {
                                    vm.Irregulardata dataexist = Irregulardatas.Find(x => x.country == data.country && x.indonesian == "Penghasilan lainnya");
                                    if (dataexist == null)
                                    {
                                        vm.Irregulardata irregulardata = new vm.Irregulardata();
                                        irregulardata.ir = ir;
                                        irregulardata.country = "Japan";
                                        irregulardata.english = "Other payments/allowances from Certificate of Salary";
                                        irregulardata.indonesian = "Penghasilan lainnya";
                                        irregulardata.currency = data.currency;
                                        irregulardata.incomecurrency = Convert.ToDouble(data.incomecurrency);
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
                                        irregulardata.english = dataexist.english;
                                        irregulardata.indonesian = dataexist.indonesian;
                                        irregulardata.currency = dataexist.currency;
                                        irregulardata.incomecurrency = dataexist.incomecurrency + Convert.ToDouble(data.incomecurrency);
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
                        ovincome = _servicesOvIncome.GetAllBy3(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, country, 5, taxform.ammend);
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
                                }

                                if (data.interval == "4")
                                {
                                    string thedate = data.dateofreceipt;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("B" + ((a * 111) + (b + 100)), thedate);
                                }
                                else if (data.interval == "3")
                                {
                                    slDoc.SetCellValue("B" + ((a * 111) + (b + 100)), "JanDec" + year);
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
                                    slDoc.SetCellValue("B" + ((a * 111) + (b + 100)), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("B" + ((a * 111) + (b + 100)), Convert.ToDateTime(datereceipt));
                                }
                                slDoc.SetCellValue("D" + ((a * 111) + (b + 100)), data.currency);
                                if (!string.IsNullOrEmpty(data.incomecurrency))
                                {
                                    slDoc.SetCellValue("F" + ((a * 111) + (b + 100)), Convert.ToDouble(data.incomecurrency));
                                }
                                if (!string.IsNullOrEmpty(data.taxpaidcurrency))
                                {
                                    slDoc.SetCellValue("G" + ((a * 111) + (b + 100)), Convert.ToDouble(data.taxpaidcurrency));
                                }
                                if (!string.IsNullOrEmpty(data.exchrate))
                                {
                                    slDoc.SetCellValue("H" + ((a * 111) + (b + 100)), Convert.ToDouble(data.exchrate));
                                }

                                if (data.irregularincome == "yes" && ir <= 5)
                                {
                                    vm.Irregulardata dataexist = Irregulardatas.Find(x => x.country == data.country && x.indonesian == "Bonus");
                                    if (dataexist == null)
                                    {
                                        vm.Irregulardata irregulardata = new vm.Irregulardata();
                                        irregulardata.ir = ir;
                                        irregulardata.country = "Japan";
                                        irregulardata.english = "Bonuses";
                                        irregulardata.indonesian = "Bonus";
                                        irregulardata.currency = data.currency;
                                        irregulardata.incomecurrency = Convert.ToDouble(data.incomecurrency);
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
                                        irregulardata.english = dataexist.english;
                                        irregulardata.indonesian = dataexist.indonesian;
                                        irregulardata.currency = dataexist.currency;
                                        irregulardata.incomecurrency = dataexist.incomecurrency + Convert.ToDouble(data.incomecurrency);
                                        irregulardata.bil1 = dataexist.bil1 + Convert.ToDouble(data.incomerp);
                                        irregulardata.bil2 = dataexist.bil2 + Convert.ToDouble(data.taxpaidrp);

                                        Irregulardatas[dataexist.ir] = irregulardata;
                                    }
                                }
                                b++;
                            }

                        }

                    }

                    /*foreach (vm.Irregulardata Irregulardata in Irregulardatas)
                    {
                        slDoc.SetCellValue("B" + ((Irregulardata.ir) + 156), Irregulardata.english);
                        slDoc.SetCellValue("D" + ((Irregulardata.ir) + 156), Irregulardata.indonesian);
                        slDoc.SetCellValue("F" + ((Irregulardata.ir) + 156), Irregulardata.currency);
                        slDoc.SetCellValue("G" + ((Irregulardata.ir) + 156), Irregulardata.incomecurrency);
                        slDoc.SetCellValue("H" + ((Irregulardata.ir) + 156), Irregulardata.bil1);
                        slDoc.SetCellValue("I" + ((Irregulardata.ir) + 156), Irregulardata.bil2);
                    }*/


                    debugtext = "DEBUG 8 ";
                    List<vm.Irregular> Irregulardatasnew = _servicesIrregular.GetAllBy(taxform.TaxPayerNumber, taxform.type, taxform.year, taxform.ammend);
                    int ino = 0;
                    foreach (vm.Irregulardata Irregulardata in Irregulardatas)
                    {
                        slDoc.SetCellValue("B" + ((ino) + 156), Irregulardata.english);
                        slDoc.SetCellValue("D" + ((ino) + 156), Irregulardata.indonesian);
                        slDoc.SetCellValue("F" + ((ino) + 156), Irregulardata.currency);
                        slDoc.SetCellValue("G" + ((ino) + 156), Convert.ToDouble(Irregulardata.incomecurrency));
                        slDoc.SetCellValue("H" + ((ino) + 156), Convert.ToDouble(Irregulardata.bil1));
                        slDoc.SetCellValue("I" + ((ino) + 156), Convert.ToDouble(Irregulardata.bil2));
                        ino++;
                    }

                    debugtext = "DEBUG 9 ";
                    //======================================
                    generatenext = false;
                    slDoc.SelectWorksheet("A & L INFO");
                    List<vm.Asset> dataassets = _servicesAsset.GetAllAssetBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, 1, taxform.ammend);
                    a = 0;
                    totalasset += dataassets.Count();
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
                            slDoc.SetCellValue("B" + ((a * 1) + 8), data.as_refnumber);
                            slDoc.SetCellValue("C" + ((a * 1) + 8), data.as_description);
                            slDoc.SetCellValue("D" + ((a * 1) + 8), data.as_owner);
                            if (as_balancedate != "")
                            {
                                if (data.as_interval == "4")
                                {
                                    string thedate = data.as_balancedate;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("E" + ((a * 1) + 8), thedate);
                                }
                                else if (data.as_interval == "3")
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 8), "JanDec" + year);
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
                                    slDoc.SetCellValue("E" + ((a * 1) + 8), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 8), Convert.ToDateTime(as_balancedate));
                                }
                            }
                            slDoc.SetCellValue("F" + ((a * 1) + 8), data.as_currency);
                            if (!string.IsNullOrEmpty(data.as_originalcurrency))
                            {
                                slDoc.SetCellValue("G" + ((a * 1) + 8), Convert.ToDouble(data.as_originalcurrency));
                            }
                            if (!string.IsNullOrEmpty(data.as_exchrate))
                            {
                                slDoc.SetCellValue("H" + ((a * 1) + 8), Convert.ToDouble(data.as_exchrate));
                            }
                        }
                        a++;
                    }

                    dataassets = _servicesAsset.GetAllAssetBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, 2, taxform.ammend);
                    a = 0;
                    totalasset += dataassets.Count();
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
                        if (a < 10)
                        {
                            slDoc.SetCellValue("B" + ((a * 1) + 29), data.as_refnumber);
                            slDoc.SetCellValue("C" + ((a * 1) + 29), data.as_description);
                            slDoc.SetCellValue("D" + ((a * 1) + 29), data.as_owner);
                            if (as_balancedate != "")
                            {
                                if (data.as_interval == "4")
                                {
                                    string thedate = data.as_balancedate;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("E" + ((a * 1) + 29), thedate);
                                }
                                else if (data.as_interval == "3")
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 29), data.as_balancedate.Split('/')[2]);
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
                                    slDoc.SetCellValue("E" + ((a * 1) + 29), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 29), Convert.ToDateTime(as_balancedate));
                                }
                            }
                            slDoc.SetCellValue("F" + ((a * 1) + 29), data.as_currency);
                            if (!string.IsNullOrEmpty(data.as_originalcurrency))
                            {
                                slDoc.SetCellValue("G" + ((a * 1) + 29), Convert.ToDouble(data.as_originalcurrency));
                            }
                            if (!string.IsNullOrEmpty(data.as_exchrate))
                            {
                                slDoc.SetCellValue("H" + ((a * 1) + 29), Convert.ToDouble(data.as_exchrate));
                            }
                        }
                        a++;
                    }

                    dataassets = _servicesAsset.GetAllAssetBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, 3, taxform.ammend);
                    a = 0;
                    totalasset += dataassets.Count();
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
                        if (a < 10)
                        {
                            slDoc.SetCellValue("B" + ((a * 1) + 45), data.as_refnumber);
                            slDoc.SetCellValue("C" + ((a * 1) + 45), data.as_description);
                            slDoc.SetCellValue("D" + ((a * 1) + 45), data.as_owner);
                            if (as_balancedate != "")
                            {
                                if (data.as_interval == "4")
                                {
                                    string thedate = data.as_balancedate;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("E" + ((a * 1) + 45), thedate);
                                }
                                else if (data.as_interval == "3")
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 45), data.as_balancedate.Split('/')[2]);
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
                                    slDoc.SetCellValue("E" + ((a * 1) + 45), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 45), Convert.ToDateTime(as_balancedate));
                                }
                            }
                            slDoc.SetCellValue("F" + ((a * 1) + 45), data.as_currency);
                            if (!string.IsNullOrEmpty(data.as_originalcurrency))
                            {
                                slDoc.SetCellValue("G" + ((a * 1) + 45), Convert.ToDouble(data.as_originalcurrency));
                            }
                            if (!string.IsNullOrEmpty(data.as_exchrate))
                            {
                                slDoc.SetCellValue("H" + ((a * 1) + 45), Convert.ToDouble(data.as_exchrate));
                            }
                        }
                        a++;
                    }

                    dataassets = _servicesAsset.GetAllAssetBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, 4, taxform.ammend);
                    a = 0;
                    totalasset += dataassets.Count();
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
                        if (a < 10)
                        {
                            slDoc.SetCellValue("B" + ((a * 1) + 61), data.as_refnumber);
                            slDoc.SetCellValue("C" + ((a * 1) + 61), data.as_description);
                            slDoc.SetCellValue("D" + ((a * 1) + 61), data.as_owner);
                            if (as_balancedate != "")
                            {
                                if (data.as_interval == "4")
                                {
                                    string thedate = data.as_balancedate;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("E" + ((a * 1) + 61), thedate);
                                }
                                else if (data.as_interval == "3")
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 61), data.as_balancedate.Split('/')[2]);
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
                                    slDoc.SetCellValue("E" + ((a * 1) + 61), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 61), Convert.ToDateTime(as_balancedate));
                                }
                            }
                            slDoc.SetCellValue("F" + ((a * 1) + 61), data.as_currency);
                            if (!string.IsNullOrEmpty(data.as_originalcurrency))
                            {
                                slDoc.SetCellValue("G" + ((a * 1) + 61), Convert.ToDouble(data.as_originalcurrency));
                            }
                            if (!string.IsNullOrEmpty(data.as_exchrate))
                            {
                                slDoc.SetCellValue("H" + ((a * 1) + 61), Convert.ToDouble(data.as_exchrate));
                            }
                        }
                        a++;
                    }

                    dataassets = _servicesAsset.GetAllAssetBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, 5, taxform.ammend);
                    a = 0;
                    totalasset += dataassets.Count();
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
                        if (a < 10)
                        {
                            slDoc.SetCellValue("B" + ((a * 1) + 77), data.as_refnumber);
                            slDoc.SetCellValue("C" + ((a * 1) + 77), data.as_description);
                            slDoc.SetCellValue("D" + ((a * 1) + 77), data.as_owner);
                            if (as_balancedate != "")
                            {
                                if (data.as_interval == "4")
                                {
                                    string thedate = data.as_balancedate;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("E" + ((a * 1) + 77), thedate);
                                }
                                else if (data.as_interval == "3")
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 77), data.as_balancedate.Split('/')[2]);
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
                                    slDoc.SetCellValue("E" + ((a * 1) + 77), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 77), Convert.ToDateTime(as_balancedate));
                                }
                            }
                            slDoc.SetCellValue("F" + ((a * 1) + 77), data.as_currency);
                            if (!string.IsNullOrEmpty(data.as_originalcurrency))
                            {
                                slDoc.SetCellValue("G" + ((a * 1) + 77), Convert.ToDouble(data.as_originalcurrency));
                            }
                            if (!string.IsNullOrEmpty(data.as_exchrate))
                            {
                                slDoc.SetCellValue("H" + ((a * 1) + 77), Convert.ToDouble(data.as_exchrate));
                            }
                        }
                        a++;
                    }

                    dataassets = _servicesAsset.GetAllAssetBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, 6, taxform.ammend);
                    a = 0;
                    totalasset += dataassets.Count();
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
                        if (a < 10)
                        {
                            slDoc.SetCellValue("B" + ((a * 1) + 93), data.as_refnumber);
                            slDoc.SetCellValue("C" + ((a * 1) + 93), data.as_description);
                            slDoc.SetCellValue("D" + ((a * 1) + 93), data.as_owner);
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
                            if (!string.IsNullOrEmpty(data.as_originalcurrency))
                            {
                                slDoc.SetCellValue("G" + ((a * 1) + 93), Convert.ToDouble(data.as_originalcurrency));
                            }
                            if (!string.IsNullOrEmpty(data.as_exchrate))
                            {
                                slDoc.SetCellValue("H" + ((a * 1) + 93), Convert.ToDouble(data.as_exchrate));
                            }
                        }
                        a++;
                    }

                    dataassets = _servicesAsset.GetAllAssetBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, 10, taxform.ammend);
                    a = 0;
                    totalasset += dataassets.Count();
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
                        if (a < 10)
                        {
                            slDoc.SetCellValue("B" + ((a * 1) + 113), data.as_refnumber);
                            slDoc.SetCellValue("C" + ((a * 1) + 113), data.as_description);
                            slDoc.SetCellValue("D" + ((a * 1) + 113), data.as_owner);
                            if (as_balancedate != "")
                            {
                                if (data.as_interval == "4")
                                {
                                    string thedate = data.as_balancedate;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("E" + ((a * 1) + 113), thedate);
                                }
                                else if (data.as_interval == "3")
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 113), data.as_balancedate.Split('/')[2]);
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
                                    slDoc.SetCellValue("E" + ((a * 1) + 113), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("E" + ((a * 1) + 113), Convert.ToDateTime(as_balancedate));
                                }
                            }
                            slDoc.SetCellValue("F" + ((a * 1) + 113), data.as_currency);
                            if (!string.IsNullOrEmpty(data.as_originalcurrency))
                            {
                                slDoc.SetCellValue("G" + ((a * 1) + 113), Convert.ToDouble(data.as_originalcurrency));
                            }
                            if (!string.IsNullOrEmpty(data.as_exchrate))
                            {
                                slDoc.SetCellValue("H" + ((a * 1) + 113), Convert.ToDouble(data.as_exchrate));
                            }
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
                if (totalasset > 5)
                {
                    generatenext = true;
                }

                debugtext = "DEBUG 10 ";
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
                        slDoc.SetCellValue("AF" + (145), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_b9)));

                        slDoc.SetCellValue("J" + (14 - 1), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_1)));
                        slDoc.SetCellValue("J" + (15 - 1), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_2)));
                        slDoc.SetCellValue("N" + (16 - 1), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_3)));
                        slDoc.SetCellValue("N" + (17 - 1), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_4)));
                        slDoc.SetCellValue("N" + (18 - 1), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_5)));
                        slDoc.SetCellValue("R" + (19 - 1), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_6)));
                        slDoc.SetCellValue("J" + (23 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_7)));
                        slDoc.SetCellValue("J" + (24 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_8)));
                        slDoc.SetCellValue("N" + (25 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_9)));
                        slDoc.SetCellValue("N" + (26 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_10)));

                        slDoc.SetCellValue("N" + (27 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_11)));
                        slDoc.SetCellValue("R" + (28 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_12)));
                        slDoc.SetCellValue("AF" + (23 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_13)));
                        slDoc.SetCellValue("AF" + (24 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_14)));
                        slDoc.SetCellValue("AF" + (25 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_15)));
                        slDoc.SetCellValue("R" + (30 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_16)));
                        slDoc.SetCellValue("R" + (32 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_17)));
                        slDoc.SetCellValue("AF" + (33 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_18)));
                        slDoc.SetCellValue("AF" + (34 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_19)));
                        slDoc.SetCellValue("AF" + (35 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_20)));

                        slDoc.SetCellValue("AF" + (36 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_21)));
                        slDoc.SetCellValue("AF" + (37 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_22)));
                        slDoc.SetCellValue("AF" + (38 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_23)));
                        slDoc.SetCellValue("AF" + (39 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_24)));
                        slDoc.SetCellValue("J" + (35 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_25)));
                        slDoc.SetCellValue("J" + (36 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_26)));
                        slDoc.SetCellValue("N" + (37 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_27)));
                        slDoc.SetCellValue("N" + (38 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_28)));
                        slDoc.SetCellValue("R" + (39 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_29)));
                        slDoc.SetCellValue("J" + (42 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_30)));

                        slDoc.SetCellValue("J" + (43 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_31)));
                        slDoc.SetCellValue("N" + (44 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_32)));
                        slDoc.SetCellValue("N" + (45 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_33)));
                        slDoc.SetCellValue("R" + (46 - 2), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_34)));
                        slDoc.SetCellValue("J" + (59 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_35)));
                        slDoc.SetCellValue("J" + (60 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_36)));
                        slDoc.SetCellValue("N" + (61 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_37)));
                        slDoc.SetCellValue("J" + (63 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_38)));
                        slDoc.SetCellValue("J" + (64 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_39)));
                        slDoc.SetCellValue("N" + (65 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_40)));

                        slDoc.SetCellValue("J" + (67 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_41)));
                        slDoc.SetCellValue("J" + (68 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_42)));
                        slDoc.SetCellValue("N" + (69 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_43)));
                        slDoc.SetCellValue("R" + (71 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_44)));
                        slDoc.SetCellValue("AF" + (66 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_45)));
                        slDoc.SetCellValue("AF" + (67 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_46)));
                        slDoc.SetCellValue("AF" + (68 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_47)));
                        slDoc.SetCellValue("R" + (73 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_48)));
                        slDoc.SetCellValue("R" + (75 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_49)));
                        slDoc.SetCellValue("AF" + (76 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_50)));

                        slDoc.SetCellValue("AF" + (77 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_51)));
                        slDoc.SetCellValue("AF" + (78 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_52)));
                        slDoc.SetCellValue("AF" + (79 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_53)));
                        slDoc.SetCellValue("AF" + (80 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_54)));
                        slDoc.SetCellValue("AF" + (81 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_55)));
                        slDoc.SetCellValue("AF" + (82 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_56)));
                        slDoc.SetCellValue("J" + (78 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_57)));
                        slDoc.SetCellValue("J" + (79 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_58)));
                        slDoc.SetCellValue("N" + (80 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_59)));
                        slDoc.SetCellValue("N" + (81 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_60)));

                        slDoc.SetCellValue("R" + (82 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_61)));
                        slDoc.SetCellValue("J" + (85 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_62)));
                        slDoc.SetCellValue("J" + (86 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_63)));
                        slDoc.SetCellValue("N" + (87 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_64)));
                        slDoc.SetCellValue("N" + (88 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_65)));
                        slDoc.SetCellValue("R" + (89 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_66)));
                        slDoc.SetCellValue("N" + (92 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_67)));
                        slDoc.SetCellValue("N" + (93 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_68)));
                        slDoc.SetCellValue("N" + (94 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_69)));
                        slDoc.SetCellValue("R" + (95 - 6), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_70)));

                        slDoc.SetCellValue("R" + (99 - 7), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_71)));
                        slDoc.SetCellValue("R" + (101 - 7), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_72)));
                        slDoc.SetCellValue("R" + (103 - 7), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_73)));

                        slDoc.SetCellValue("J" + (14 + 89), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_1)));
                        slDoc.SetCellValue("J" + (15 + 89), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_2)));
                        slDoc.SetCellValue("N" + (16 + 89), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_3)));
                        slDoc.SetCellValue("N" + (17 + 89), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_4)));
                        slDoc.SetCellValue("N" + (18 + 89), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_5)));
                        slDoc.SetCellValue("R" + (19 + 89), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_6)));
                        slDoc.SetCellValue("J" + (23 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_7)));
                        slDoc.SetCellValue("J" + (24 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_8)));
                        slDoc.SetCellValue("N" + (25 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_9)));
                        slDoc.SetCellValue("N" + (26 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_10)));

                        slDoc.SetCellValue("N" + (27 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_11)));
                        slDoc.SetCellValue("R" + (28 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_12)));
                        slDoc.SetCellValue("AF" + (23 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_13)));
                        slDoc.SetCellValue("AF" + (24 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_14)));
                        slDoc.SetCellValue("AF" + (25 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_15)));
                        slDoc.SetCellValue("R" + (30 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_16)));
                        slDoc.SetCellValue("R" + (32 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_17)));
                        slDoc.SetCellValue("AF" + (33 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_18)));
                        slDoc.SetCellValue("AF" + (34 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_19)));
                        slDoc.SetCellValue("AF" + (35 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_20)));

                        slDoc.SetCellValue("AF" + (36 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_21)));
                        slDoc.SetCellValue("AF" + (37 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_22)));
                        slDoc.SetCellValue("AF" + (38 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_23)));
                        slDoc.SetCellValue("AF" + (39 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_24)));
                        slDoc.SetCellValue("J" + (35 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_25)));
                        slDoc.SetCellValue("J" + (36 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_26)));
                        slDoc.SetCellValue("N" + (37 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_27)));
                        slDoc.SetCellValue("N" + (38 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_28)));
                        slDoc.SetCellValue("R" + (39 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_29)));
                        slDoc.SetCellValue("J" + (42 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_30)));

                        slDoc.SetCellValue("J" + (43 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_31)));
                        slDoc.SetCellValue("N" + (44 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_32)));
                        slDoc.SetCellValue("N" + (45 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_33)));
                        slDoc.SetCellValue("R" + (46 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_34)));
                        slDoc.SetCellValue("J" + (59 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_35)));
                        slDoc.SetCellValue("J" + (60 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_36)));
                        slDoc.SetCellValue("N" + (61 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_37)));
                        slDoc.SetCellValue("J" + (63 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_38)));
                        slDoc.SetCellValue("J" + (64 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_39)));
                        slDoc.SetCellValue("N" + (65 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_40)));

                        slDoc.SetCellValue("J" + (67 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_41)));
                        slDoc.SetCellValue("J" + (68 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_42)));
                        slDoc.SetCellValue("N" + (69 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_43)));
                        slDoc.SetCellValue("R" + (71 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_44)));
                        slDoc.SetCellValue("AF" + (66 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_45)));
                        slDoc.SetCellValue("AF" + (67 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_46)));
                        slDoc.SetCellValue("AF" + (68 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_47)));
                        slDoc.SetCellValue("R" + (73 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_48)));
                        slDoc.SetCellValue("R" + (75 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_49)));
                        slDoc.SetCellValue("AF" + (76 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_50)));

                        slDoc.SetCellValue("AF" + (77 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_51)));
                        slDoc.SetCellValue("AF" + (78 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_52)));
                        slDoc.SetCellValue("AF" + (79 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_53)));
                        slDoc.SetCellValue("AF" + (80 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_54)));
                        slDoc.SetCellValue("AF" + (81 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_55)));
                        slDoc.SetCellValue("AF" + (82 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_56)));
                        slDoc.SetCellValue("J" + (78 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_57)));
                        slDoc.SetCellValue("J" + (79 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_58)));
                        slDoc.SetCellValue("N" + (80 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_59)));
                        slDoc.SetCellValue("N" + (81 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_60)));

                        slDoc.SetCellValue("R" + (82 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_61)));
                        slDoc.SetCellValue("J" + (85 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_62)));
                        slDoc.SetCellValue("J" + (86 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_63)));
                        slDoc.SetCellValue("N" + (87 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_64)));
                        slDoc.SetCellValue("N" + (88 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_65)));
                        slDoc.SetCellValue("R" + (89 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_66)));
                        slDoc.SetCellValue("N" + (92 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_67)));
                        slDoc.SetCellValue("N" + (93 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_68)));
                        slDoc.SetCellValue("N" + (94 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_69)));
                        slDoc.SetCellValue("R" + (95 + 83), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_70)));

                        slDoc.SetCellValue("R" + (99 + 81), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_71)));
                        slDoc.SetCellValue("R" + (101 + 81), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_72)));
                        slDoc.SetCellValue("R" + (103 + 81), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_73)));
                    }
                }

                debugtext = "DEBUG 11 ";
                slDoc.SelectWorksheet("GENERAL INFO");
                string excelfile = HttpContext.Current.Server.MapPath(exportPath + sessionLog + "/" + hdid.Value + "-report/") + hdid.Value + "-" + templatename + ".xlsx";
                slDoc.SaveAs(excelfile);

                try
                {
                    ss.Workbook workbook = new ss.Workbook();
                    workbook.LoadFromFile(HttpContext.Current.Server.MapPath(exportPath + sessionLog + "/" + hdid.Value + "-report/") + hdid.Value + "-" + templatename + ".xlsx", ss.ExcelVersion.Version2013);


                    ss.Worksheet sheetselected = workbook.Worksheets[0];

                    for (int aa = 4; aa <= 15; aa++)
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
                    throw ex;
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
                    _services.Save(true, 0, datas[0].TaxPayerNumber, datas[0].type, datas[0].year, datas[0].ammend, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToDouble(var_calc_rounded_1.ToString()), Convert.ToDouble(var_calc_rounded_2), Convert.ToDouble(var_calc_rounded_3), Convert.ToDouble(var_calc_rounded_4), Convert.ToDouble(var_calc_rounded_5), Convert.ToDouble(var_calc_rounded_6), Convert.ToDouble(var_calc_rounded_7), Convert.ToDouble(var_calc_rounded_8), Convert.ToDouble(var_calc_rounded_9), Convert.ToDouble(var_calc_rounded_10), Convert.ToDouble(var_calc_rounded_11), Convert.ToDouble(var_calc_rounded_12), Convert.ToDouble(var_calc_rounded_13), Convert.ToDouble(var_calc_rounded_14), Convert.ToDouble(var_calc_rounded_15), Convert.ToDouble(var_calc_rounded_16), Convert.ToDouble(var_calc_rounded_17), Convert.ToDouble(var_calc_rounded_18), Convert.ToDouble(var_calc_rounded_19), Convert.ToDouble(var_calc_rounded_20), Convert.ToDouble(var_calc_rounded_21), Convert.ToDouble(var_calc_rounded_22), Convert.ToDouble(var_calc_rounded_23), Convert.ToDouble(var_calc_rounded_24), Convert.ToDouble(var_calc_rounded_25), Convert.ToDouble(var_calc_rounded_26), Convert.ToDouble(var_calc_rounded_27), Convert.ToDouble(var_calc_rounded_28), Convert.ToDouble(var_calc_rounded_29), Convert.ToDouble(var_calc_rounded_30), Convert.ToDouble(var_calc_rounded_31), Convert.ToDouble(var_calc_rounded_32), Convert.ToDouble(var_calc_rounded_33), Convert.ToDouble(var_calc_rounded_34), Convert.ToDouble(var_calc_rounded_35), Convert.ToDouble(var_calc_rounded_36), Convert.ToDouble(var_calc_rounded_37), Convert.ToDouble(var_calc_rounded_38), Convert.ToDouble(var_calc_rounded_39), Convert.ToDouble(var_calc_rounded_40), Convert.ToDouble(var_calc_rounded_41), Convert.ToDouble(var_calc_rounded_42), Convert.ToDouble(var_calc_rounded_43), Convert.ToDouble(var_calc_rounded_44), Convert.ToDouble(var_calc_rounded_45), Convert.ToDouble(var_calc_rounded_46), Convert.ToDouble(var_calc_rounded_47), Convert.ToDouble(var_calc_rounded_48), Convert.ToDouble(var_calc_rounded_49), Convert.ToDouble(var_calc_rounded_50), Convert.ToDouble(var_calc_rounded_51), Convert.ToDouble(var_calc_rounded_52), Convert.ToDouble(var_calc_rounded_53), Convert.ToDouble(var_calc_rounded_54), Convert.ToDouble(var_calc_rounded_55), Convert.ToDouble(var_calc_rounded_56), Convert.ToDouble(var_calc_rounded_57), Convert.ToDouble(var_calc_rounded_58), Convert.ToDouble(var_calc_rounded_59), Convert.ToDouble(var_calc_rounded_60), Convert.ToDouble(var_calc_rounded_61), Convert.ToDouble(var_calc_rounded_62), Convert.ToDouble(var_calc_rounded_63), Convert.ToDouble(var_calc_rounded_64), Convert.ToDouble(var_calc_rounded_65), Convert.ToDouble(var_calc_rounded_66), Convert.ToDouble(var_calc_rounded_67), Convert.ToDouble(var_calc_rounded_68), Convert.ToDouble(var_calc_rounded_69), Convert.ToDouble(var_calc_rounded_70), Convert.ToDouble(var_calc_rounded_71), Convert.ToDouble(var_calc_rounded_72), Convert.ToDouble(var_calc_rounded_73), Convert.ToDouble(var_calc_not_1), Convert.ToDouble(var_calc_not_2), Convert.ToDouble(var_calc_not_3), Convert.ToDouble(var_calc_not_4), Convert.ToDouble(var_calc_not_5), Convert.ToDouble(var_calc_not_6), Convert.ToDouble(var_calc_not_7), Convert.ToDouble(var_calc_not_8), Convert.ToDouble(var_calc_not_9), Convert.ToDouble(var_calc_not_10), Convert.ToDouble(var_calc_not_11), Convert.ToDouble(var_calc_not_12), Convert.ToDouble(var_calc_not_13), Convert.ToDouble(var_calc_not_14), Convert.ToDouble(var_calc_not_15), Convert.ToDouble(var_calc_not_16), Convert.ToDouble(var_calc_not_17), Convert.ToDouble(var_calc_not_18), Convert.ToDouble(var_calc_not_19), Convert.ToDouble(var_calc_not_20), Convert.ToDouble(var_calc_not_21), Convert.ToDouble(var_calc_not_22), Convert.ToDouble(var_calc_not_23), Convert.ToDouble(var_calc_not_24), Convert.ToDouble(var_calc_not_25), Convert.ToDouble(var_calc_not_26), Convert.ToDouble(var_calc_not_27), Convert.ToDouble(var_calc_not_28), Convert.ToDouble(var_calc_not_29), Convert.ToDouble(var_calc_not_30), Convert.ToDouble(var_calc_not_31), Convert.ToDouble(var_calc_not_32), Convert.ToDouble(var_calc_not_33), Convert.ToDouble(var_calc_not_34), Convert.ToDouble(var_calc_not_35), Convert.ToDouble(var_calc_not_36), Convert.ToDouble(var_calc_not_37), Convert.ToDouble(var_calc_not_38), Convert.ToDouble(var_calc_not_39), Convert.ToDouble(var_calc_not_40), Convert.ToDouble(var_calc_not_41), Convert.ToDouble(var_calc_not_42), Convert.ToDouble(var_calc_not_43), Convert.ToDouble(var_calc_not_44), Convert.ToDouble(var_calc_not_45), Convert.ToDouble(var_calc_not_46), Convert.ToDouble(var_calc_not_47), Convert.ToDouble(var_calc_not_48), Convert.ToDouble(var_calc_not_49), Convert.ToDouble(var_calc_not_50), Convert.ToDouble(var_calc_not_51), Convert.ToDouble(var_calc_not_52), Convert.ToDouble(var_calc_not_53), Convert.ToDouble(var_calc_not_54), Convert.ToDouble(var_calc_not_55), Convert.ToDouble(var_calc_not_56), Convert.ToDouble(var_calc_not_57), Convert.ToDouble(var_calc_not_58), Convert.ToDouble(var_calc_not_59), Convert.ToDouble(var_calc_not_60), Convert.ToDouble(var_calc_not_61), Convert.ToDouble(var_calc_not_62), Convert.ToDouble(var_calc_not_63), Convert.ToDouble(var_calc_not_64), Convert.ToDouble(var_calc_not_65), Convert.ToDouble(var_calc_not_66), Convert.ToDouble(var_calc_not_67), Convert.ToDouble(var_calc_not_68), Convert.ToDouble(var_calc_not_69), Convert.ToDouble(var_calc_not_70), Convert.ToDouble(var_calc_not_71), Convert.ToDouble(var_calc_not_72), Convert.ToDouble(var_calc_not_73), createdby, createddate, createdby, createddate);
                }
                else
                {
                    _services.Save(false, calculations[0].id, datas[0].TaxPayerNumber, datas[0].type, datas[0].year, datas[0].ammend, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToDouble(var_calc_rounded_1.ToString()), Convert.ToDouble(var_calc_rounded_2), Convert.ToDouble(var_calc_rounded_3), Convert.ToDouble(var_calc_rounded_4), Convert.ToDouble(var_calc_rounded_5), Convert.ToDouble(var_calc_rounded_6), Convert.ToDouble(var_calc_rounded_7), Convert.ToDouble(var_calc_rounded_8), Convert.ToDouble(var_calc_rounded_9), Convert.ToDouble(var_calc_rounded_10), Convert.ToDouble(var_calc_rounded_11), Convert.ToDouble(var_calc_rounded_12), Convert.ToDouble(var_calc_rounded_13), Convert.ToDouble(var_calc_rounded_14), Convert.ToDouble(var_calc_rounded_15), Convert.ToDouble(var_calc_rounded_16), Convert.ToDouble(var_calc_rounded_17), Convert.ToDouble(var_calc_rounded_18), Convert.ToDouble(var_calc_rounded_19), Convert.ToDouble(var_calc_rounded_20), Convert.ToDouble(var_calc_rounded_21), Convert.ToDouble(var_calc_rounded_22), Convert.ToDouble(var_calc_rounded_23), Convert.ToDouble(var_calc_rounded_24), Convert.ToDouble(var_calc_rounded_25), Convert.ToDouble(var_calc_rounded_26), Convert.ToDouble(var_calc_rounded_27), Convert.ToDouble(var_calc_rounded_28), Convert.ToDouble(var_calc_rounded_29), Convert.ToDouble(var_calc_rounded_30), Convert.ToDouble(var_calc_rounded_31), Convert.ToDouble(var_calc_rounded_32), Convert.ToDouble(var_calc_rounded_33), Convert.ToDouble(var_calc_rounded_34), Convert.ToDouble(var_calc_rounded_35), Convert.ToDouble(var_calc_rounded_36), Convert.ToDouble(var_calc_rounded_37), Convert.ToDouble(var_calc_rounded_38), Convert.ToDouble(var_calc_rounded_39), Convert.ToDouble(var_calc_rounded_40), Convert.ToDouble(var_calc_rounded_41), Convert.ToDouble(var_calc_rounded_42), Convert.ToDouble(var_calc_rounded_43), Convert.ToDouble(var_calc_rounded_44), Convert.ToDouble(var_calc_rounded_45), Convert.ToDouble(var_calc_rounded_46), Convert.ToDouble(var_calc_rounded_47), Convert.ToDouble(var_calc_rounded_48), Convert.ToDouble(var_calc_rounded_49), Convert.ToDouble(var_calc_rounded_50), Convert.ToDouble(var_calc_rounded_51), Convert.ToDouble(var_calc_rounded_52), Convert.ToDouble(var_calc_rounded_53), Convert.ToDouble(var_calc_rounded_54), Convert.ToDouble(var_calc_rounded_55), Convert.ToDouble(var_calc_rounded_56), Convert.ToDouble(var_calc_rounded_57), Convert.ToDouble(var_calc_rounded_58), Convert.ToDouble(var_calc_rounded_59), Convert.ToDouble(var_calc_rounded_60), Convert.ToDouble(var_calc_rounded_61), Convert.ToDouble(var_calc_rounded_62), Convert.ToDouble(var_calc_rounded_63), Convert.ToDouble(var_calc_rounded_64), Convert.ToDouble(var_calc_rounded_65), Convert.ToDouble(var_calc_rounded_66), Convert.ToDouble(var_calc_rounded_67), Convert.ToDouble(var_calc_rounded_68), Convert.ToDouble(var_calc_rounded_69), Convert.ToDouble(var_calc_rounded_70), Convert.ToDouble(var_calc_rounded_71), Convert.ToDouble(var_calc_rounded_72), Convert.ToDouble(var_calc_rounded_73), Convert.ToDouble(var_calc_not_1), Convert.ToDouble(var_calc_not_2), Convert.ToDouble(var_calc_not_3), Convert.ToDouble(var_calc_not_4), Convert.ToDouble(var_calc_not_5), Convert.ToDouble(var_calc_not_6), Convert.ToDouble(var_calc_not_7), Convert.ToDouble(var_calc_not_8), Convert.ToDouble(var_calc_not_9), Convert.ToDouble(var_calc_not_10), Convert.ToDouble(var_calc_not_11), Convert.ToDouble(var_calc_not_12), Convert.ToDouble(var_calc_not_13), Convert.ToDouble(var_calc_not_14), Convert.ToDouble(var_calc_not_15), Convert.ToDouble(var_calc_not_16), Convert.ToDouble(var_calc_not_17), Convert.ToDouble(var_calc_not_18), Convert.ToDouble(var_calc_not_19), Convert.ToDouble(var_calc_not_20), Convert.ToDouble(var_calc_not_21), Convert.ToDouble(var_calc_not_22), Convert.ToDouble(var_calc_not_23), Convert.ToDouble(var_calc_not_24), Convert.ToDouble(var_calc_not_25), Convert.ToDouble(var_calc_not_26), Convert.ToDouble(var_calc_not_27), Convert.ToDouble(var_calc_not_28), Convert.ToDouble(var_calc_not_29), Convert.ToDouble(var_calc_not_30), Convert.ToDouble(var_calc_not_31), Convert.ToDouble(var_calc_not_32), Convert.ToDouble(var_calc_not_33), Convert.ToDouble(var_calc_not_34), Convert.ToDouble(var_calc_not_35), Convert.ToDouble(var_calc_not_36), Convert.ToDouble(var_calc_not_37), Convert.ToDouble(var_calc_not_38), Convert.ToDouble(var_calc_not_39), Convert.ToDouble(var_calc_not_40), Convert.ToDouble(var_calc_not_41), Convert.ToDouble(var_calc_not_42), Convert.ToDouble(var_calc_not_43), Convert.ToDouble(var_calc_not_44), Convert.ToDouble(var_calc_not_45), Convert.ToDouble(var_calc_not_46), Convert.ToDouble(var_calc_not_47), Convert.ToDouble(var_calc_not_48), Convert.ToDouble(var_calc_not_49), Convert.ToDouble(var_calc_not_50), Convert.ToDouble(var_calc_not_51), Convert.ToDouble(var_calc_not_52), Convert.ToDouble(var_calc_not_53), Convert.ToDouble(var_calc_not_54), Convert.ToDouble(var_calc_not_55), Convert.ToDouble(var_calc_not_56), Convert.ToDouble(var_calc_not_57), Convert.ToDouble(var_calc_not_58), Convert.ToDouble(var_calc_not_59), Convert.ToDouble(var_calc_not_60), Convert.ToDouble(var_calc_not_61), Convert.ToDouble(var_calc_not_62), Convert.ToDouble(var_calc_not_63), Convert.ToDouble(var_calc_not_64), Convert.ToDouble(var_calc_not_65), Convert.ToDouble(var_calc_not_66), Convert.ToDouble(var_calc_not_67), Convert.ToDouble(var_calc_not_68), Convert.ToDouble(var_calc_not_69), Convert.ToDouble(var_calc_not_70), Convert.ToDouble(var_calc_not_71), Convert.ToDouble(var_calc_not_72), Convert.ToDouble(var_calc_not_73), createdby, createddate, createdby, createddate);
                }

            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }
    }
}