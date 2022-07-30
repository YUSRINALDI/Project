using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;
using DelloiteTRLib;
using DelloiteTRLib.Services;
using vm = DelloiteTRLib.Model;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Web.Script.Serialization;
using ss = Spire.Xls;
using sp = Spire.Pdf;

namespace DelloiteTR
{
    public partial class report_nonus : System.Web.UI.Page
    {

        private string templatePath = HttpContext.Current.Server.MapPath("~/templates/");
        private string exportPath = "~/App_Data/";
        private string formType = "formNonUs";
        private double period = 12;
        private int reportCount = 11;
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

        private CalculationServices _services;
        ServiceReference2.CalculationSoapClient client;
        ServiceReference2.TaxForm[] datas;

        private string thename = "";
        string[] files;
        string outputFile = "";
        string outputname = "";
        string outputFileexcel = "";
        string outputnameexcel = "";
        bool generatenext;
        List<vm.IEIncome> ieincome;

        string debugtext = "";

        string sessionLog = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //FileStream fs = File.Create("/templates-export/test.txt", 1024);
                _servicesTaxForm = ServicesFactory.CreateTaxFormServices(ConnectionString.Value);
                _servicesIncome = ServicesFactory.CreateIEIncomeServices(ConnectionString.Value);
                _servicesFamily = ServicesFactory.CreateFamilyServices(ConnectionString.Value);
                _servicesMarital = ServicesFactory.CreateMaritalServices(ConnectionString.Value);
                _servicesAsset = ServicesFactory.CreateAssetServices(ConnectionString.Value);
                _servicesOvIncome = ServicesFactory.CreateOvIncomeServices(ConnectionString.Value);
                _servicesOvRental = ServicesFactory.CreateOvRentalServices(ConnectionString.Value);
                _servicesOvCapital = ServicesFactory.CreateOvCapitalServices(ConnectionString.Value);
                _servicesCalculation = ServicesFactory.CreateCalculationServices(ConnectionString.Value);
                _services = ServicesFactory.CreateCalculationServices(ConnectionString.Value);
                _servicesIrregular = ServicesFactory.CreateIrregularServices(ConnectionString.Value);

                if (!this.IsPostBack)
                {
                    this.PageLoad();
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        private void PageLoad()
        {
            SetMessage("");
            hdid.Value = Request.QueryString["id"];
            sessionLog = Session["userLog"].ToString();

            if (Session["userRole"].ToString() == "2")
            {
                divinput.Visible = false;
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
                errorMsg.Text = debugtext + message;
            }
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

        private void SaveasPDF(List<string> filename, List<int> selectedsheet, bool selected)
        {
            string templatename = "Form1770S";
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


                    debugtext = "DEBUG 3 ";
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
                        string year = taxform.t1s2f1.Split('/')[2];
                        if (year.Length == 4)
                        {
                            year = year.Substring(2, 2);
                        }
                        t1s2f1 = taxform.t1s2f1.Split('/')[1] + "/" + taxform.t1s2f1.Split('/')[0] + "/" + year;
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
                        slDoc.SetCellValue("Q52", "X");
                    }

                    if (taxform.t1s2f10 == "True")
                    {
                        slDoc.SetCellValue("W55", "X");
                    }

                    slDoc.SetCellValue("H52", taxform.t1s2f18);
                    slDoc.SetCellValue("S52", taxform.t1s2f19);

                    

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
                    if(!string.IsNullOrEmpty(taxform.t1s3f2)){
                        slDoc.SetCellValue("F65", Convert.ToInt32(taxform.t1s3f2));
                    }

                    if (!string.IsNullOrEmpty(taxform.t1s3f3) && taxform.t1s3f3!="0")
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


                    debugtext = "DEBUG 4 ";
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

                    debugtext = "DEBUG 5 ";
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

                            if(dataf1!=""){
                                slDoc.SetCellValue(col + "108", Convert.ToDateTime(dataf1));
                            }
                            if (dataf2 != "")
                            {
                                slDoc.SetCellValue(col2 + "108", Convert.ToDateTime(dataf2));
                            }

                            string field5 = data.field5.Replace(".", "");
                            field5 = field5.Replace("-", "");
                            string field6 = data.field6.Replace(".", "");
                            field6 = field6.Replace("-", "");

                            slDoc.SetCellValue(col + "110", data.field4);
                            slDoc.SetCellValue(col + "111", field5.ToString());
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

                    debugtext = "DEBUG 6 ";
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

                    debugtext = "DEBUG 7 ";
                    List<vm.OverseasIncome> ovincome;
                    List<string> countries = new List<string>();
                    var ir = 0;
                    foreach (string country in countryList)
                    {
                        ovincome = _servicesOvIncome.GetAllBy3(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, country, 1, taxform.ammend);

                        debugtext = "DEBUG 7a ";
                        int b = 0;
                        if (ovincome.Count > 0)
                        {
                            if (!countries.Any(f => f == ovincome[0].country) && countries.Count < 4)
                            {
                                countries.Add(ovincome[0].country);
                            }
                        }

                        debugtext = "DEBUG 7b ";
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
                                    slDoc.SetCellValue("B" + ((a * 151) + (b + 15)), year);
                                }
                                else if (data.interval == "2")
                                {
                                    string mnt = "";
                                    if (month=="01")
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
                                }else{
                                    if (!string.IsNullOrEmpty(datereceipt))
                                    {
                                        slDoc.SetCellValue("B" + ((a * 151) + (b + 15)), Convert.ToDateTime(datereceipt));
                                    }
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
                                        Double dataincomerp = 0;
                                        if (!string.IsNullOrEmpty(data.incomerp))
                                        {
                                            dataincomerp = Convert.ToDouble(data.incomerp);
                                        }
                                        Double datataxpaidrp = 0;
                                        if (!string.IsNullOrEmpty(data.taxpaidrp))
                                        {
                                            datataxpaidrp = Convert.ToDouble(data.taxpaidrp);
                                        }
                                        irregulardata.bil1 = dataincomerp;
                                        irregulardata.bil2 = datataxpaidrp;

                                        Irregulardatas.Add(irregulardata);
                                        ir++;
                                    }
                                    else
                                    {
                                        vm.Irregulardata irregulardata = new vm.Irregulardata();
                                        irregulardata.ir = dataexist.ir;
                                        irregulardata.country = dataexist.country;
                                        irregulardata.typeincome = dataexist.typeincome;
                                        Double dataincomerp = 0;
                                        if (!string.IsNullOrEmpty(data.incomerp))
                                        {
                                            dataincomerp = Convert.ToDouble(data.incomerp);
                                        }
                                        Double datataxpaidrp = 0;
                                        if (!string.IsNullOrEmpty(data.taxpaidrp))
                                        {
                                            datataxpaidrp = Convert.ToDouble(data.taxpaidrp);
                                        }
                                        irregulardata.bil1 = dataexist.bil1 + dataincomerp;
                                        irregulardata.bil2 = dataexist.bil2 + datataxpaidrp;

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

                        debugtext = "DEBUG 7c ";
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
                                    slDoc.SetCellValue("B" + ((a * 151) + (b + 40)), year);
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

                        debugtext = "DEBUG 7d ";
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
                                    slDoc.SetCellValue("B" + ((a * 151) + (b + 65)), year);
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

                        debugtext = "DEBUG 7e ";

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
                                slDoc.SetCellValue("B" + ((a * 151) + (b + 90)), data.cap_description);
                                slDoc.SetCellValue("F" + ((a * 151) + (b + 90)), data.cap_currency);
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
                                if (data.cap_interval == "4")
                                {
                                    string thedate = data.cap_sellingdate;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("B" + ((a * 151) + (b + 90)), thedate);
                                }
                                else if (data.cap_interval == "3")
                                {
                                    slDoc.SetCellValue("H" + ((a * 151) + (b + 90)), year);
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

                        debugtext = "DEBUG 7f ";

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
                                
                                if (data.type == 1)
                                {
                                    slDoc.SetCellValue("C" + ((a * 151) + (b + 117)), data.ren_information);
                                    slDoc.SetCellValue("K" + ((a * 151) + (b + 117)), data.ren_currency);

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
                                    if (data.ren_interval == "4")
                                    {
                                        string thedate = data.ren_dateofreceipt;
                                        string aa = thedate.Split('-')[0].Substring(0, 3);
                                        string bb = thedate.Split('-')[1].Substring(1, 3);
                                        string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                        thedate = aa + "-" + bb + cc;
                                        slDoc.SetCellValue("B" + ((a * 151) + (b + 117)), thedate);
                                    }
                                    else if (data.ren_interval == "3")
                                    {
                                        slDoc.SetCellValue("M" + ((a * 151) + (b + 117)), year);
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
                                    if (data.ren_interval == "4")
                                    {
                                        string thedate = data.ren_dateofreceipt;
                                        string aa = thedate.Split('-')[0].Substring(0, 3);
                                        string bb = thedate.Split('-')[1].Substring(1, 3);
                                        string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                        thedate = aa + "-" + bb + cc;
                                        slDoc.SetCellValue("B" + ((a * 151) + (b + 133)), thedate);
                                    }
                                    else if (data.ren_interval == "3")
                                    {
                                        slDoc.SetCellValue("M" + ((a * 151) + (c + 133)), year);
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

                    /*foreach (vm.Irregulardata Irregulardata in Irregulardatas)
                    {
                        slDoc.SetCellValue("B" + ((Irregulardata.ir) + 620), Irregulardata.country);
                        slDoc.SetCellValue("K" + ((Irregulardata.ir) + 620), Irregulardata.typeincome);
                        slDoc.SetCellValue("T" + ((Irregulardata.ir) + 620), Irregulardata.bil1);
                        slDoc.SetCellValue("X" + ((Irregulardata.ir) + 620), Irregulardata.bil2);
                    }*/

                    debugtext = "DEBUG 8 ";
                    List<vm.Irregular> Irregulardatasnew = _servicesIrregular.GetAllBy(taxform.TaxPayerNumber, taxform.type, taxform.year, taxform.ammend);
                    int ino = 0;
                    foreach (vm.Irregulardata Irregulardata in Irregulardatas)
                    {
                        slDoc.SetCellValue("B" + ((ino) + 620), Irregulardata.country);
                        slDoc.SetCellValue("K" + ((ino) + 620), Irregulardata.typeincome);
                        slDoc.SetCellValue("T" + ((ino) + 620), Convert.ToDouble(Irregulardata.bil1));
                        slDoc.SetCellValue("X" + ((ino) + 620), Convert.ToDouble(Irregulardata.bil2));
                        ino++;
                    }

                    //======================================
                    int totalasset = 0;
                    generatenext = false;
                    slDoc.SelectWorksheet("A & L INFO");
                    List<vm.Asset> dataassets = _servicesAsset.GetAllAssetBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, 1, taxform.ammend);
                    debugtext = "DEBUG 9 ";
                    totalasset += dataassets.Count();
                    if (totalasset > 5)
                    {
                        generatenext = true;
                    }
                    a = 0;
                    foreach (vm.Asset data in dataassets)
                    {
                        if (a < 15)
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
                            string as_owner = "";
                            if (data.as_owner == "taxPayer")
                            {
                                as_owner = "Tax Payer";
                            }
                            else if (data.as_owner == "spouse")
                            {
                                as_owner = "Spouse";
                            }
                            else if (data.as_owner == "child")
                            {
                                as_owner = "Child";
                            }
                            else if (data.as_owner == "joint")
                            {
                                as_owner = "Joint";
                            }
                            slDoc.SetCellValue("B" + ((a * 1) + 8), data.as_refnumber);
                            slDoc.SetCellValue("C" + ((a * 1) + 8), data.as_description);
                            slDoc.SetCellValue("D" + ((a * 1) + 8), as_owner);
                            slDoc.SetCellValue("E" + ((a * 1) + 8), data.as_address);
                            slDoc.SetCellValue("F" + ((a * 1) + 8), data.as_country);
                            slDoc.SetCellValue("G" + ((a * 1) + 8), data.as_details);
                            slDoc.SetCellValue("H" + ((a * 1) + 8), data.as_account);
                            
                            if (as_balancedate!="")
                            {
                                if (data.as_interval == "4")
                                {
                                    string thedate = data.as_balancedate;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("I" + ((a * 1) + 8), thedate);
                                }
                                else if (data.as_interval == "3")
                                {
                                    slDoc.SetCellValue("I" + ((a * 1) + 8), data.as_balancedate.Split('/')[2]);
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
                                    slDoc.SetCellValue("I" + ((a * 1) + 8), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("I" + ((a * 1) + 8), Convert.ToDateTime(as_balancedate));
                                }
                                
                            }
                            
                            slDoc.SetCellValue("J" + ((a * 1) + 8), data.as_currency);
                            if (!string.IsNullOrEmpty(data.as_originalcurrency))
                            {
                                slDoc.SetCellValue("K" + ((a * 1) + 8), Convert.ToDouble(data.as_originalcurrency));
                            }
                            if (!string.IsNullOrEmpty(data.as_exchrate))
                            {
                                slDoc.SetCellValue("L" + ((a * 1) + 8), Convert.ToDouble(data.as_exchrate));
                            }
                        }
                        a++;
                    }

                    dataassets = _servicesAsset.GetAllAssetBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, 2, taxform.ammend);
                    totalasset += dataassets.Count();
                    if (totalasset > 5)
                    {
                        generatenext = true;
                    }
                    a = 0;
                    foreach (vm.Asset data in dataassets)
                    {
                        if (a < 15)
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
                            string as_owner = "";
                            if (data.as_owner == "taxPayer")
                            {
                                as_owner = "Tax Payer";
                            }
                            else if (data.as_owner == "spouse")
                            {
                                as_owner = "Spouse";
                            }
                            else if (data.as_owner == "child")
                            {
                                as_owner = "Child";
                            }
                            else if (data.as_owner == "joint")
                            {
                                as_owner = "Joint";
                            }
                            slDoc.SetCellValue("B" + ((a * 1) + 29), data.as_refnumber);
                            slDoc.SetCellValue("C" + ((a * 1) + 29), data.as_description);
                            slDoc.SetCellValue("D" + ((a * 1) + 29), as_owner);
                            slDoc.SetCellValue("E" + ((a * 1) + 29), data.as_address);
                            slDoc.SetCellValue("F" + ((a * 1) + 29), data.as_country);
                            slDoc.SetCellValue("G" + ((a * 1) + 29), data.as_details);
                            slDoc.SetCellValue("H" + ((a * 1) + 29), data.as_account);
                            if (as_balancedate != "")
                            {
                                if (data.as_interval == "4")
                                {
                                    string thedate = data.as_balancedate;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("I" + ((a * 1) + 29), thedate);
                                }
                                else if (data.as_interval == "3")
                                {
                                    slDoc.SetCellValue("I" + ((a * 1) + 29), data.as_balancedate.Split('/')[2]);
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
                                    slDoc.SetCellValue("I" + ((a * 1) + 29), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("I" + ((a * 1) + 29), Convert.ToDateTime(as_balancedate));
                                }
                            }
                            slDoc.SetCellValue("J" + ((a * 1) + 29), data.as_currency);
                            if (!string.IsNullOrEmpty(data.as_originalcurrency))
                            {
                                slDoc.SetCellValue("K" + ((a * 1) + 29), Convert.ToDouble(data.as_originalcurrency));
                            }
                            if (!string.IsNullOrEmpty(data.as_exchrate))
                            {
                                slDoc.SetCellValue("L" + ((a * 1) + 29), Convert.ToDouble(data.as_exchrate));
                            }
                        }
                        a++;
                    }

                    dataassets = _servicesAsset.GetAllAssetBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, 3, taxform.ammend);
                    totalasset += dataassets.Count();
                    if (totalasset > 5)
                    {
                        generatenext = true;
                    }
                    a = 0;
                    foreach (vm.Asset data in dataassets)
                    {
                        if (a < 34)
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
                            string as_owner = "";
                            if (data.as_owner == "taxPayer")
                            {
                                as_owner = "Tax Payer";
                            }
                            else if (data.as_owner == "spouse")
                            {
                                as_owner = "Spouse";
                            }
                            else if (data.as_owner == "child")
                            {
                                as_owner = "Child";
                            }
                            else if (data.as_owner == "joint")
                            {
                                as_owner = "Joint";
                            }
                            slDoc.SetCellValue("B" + ((a * 1) + 50), data.as_refnumber);
                            slDoc.SetCellValue("C" + ((a * 1) + 50), data.as_description);
                            slDoc.SetCellValue("D" + ((a * 1) + 50), as_owner);
                            slDoc.SetCellValue("E" + ((a * 1) + 50), data.as_address);
                            slDoc.SetCellValue("F" + ((a * 1) + 50), data.as_country);
                            slDoc.SetCellValue("G" + ((a * 1) + 50), data.as_details);
                            slDoc.SetCellValue("H" + ((a * 1) + 50), data.as_account);
                            if (as_balancedate != "")
                            {
                                if (data.as_interval == "4")
                                {
                                    string thedate = data.as_balancedate;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("I" + ((a * 1) + 50), thedate);
                                }
                                else if (data.as_interval == "3")
                                {
                                    slDoc.SetCellValue("I" + ((a * 1) + 50), data.as_balancedate.Split('/')[2]);
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
                                    slDoc.SetCellValue("I" + ((a * 1) + 50), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("I" + ((a * 1) + 50), Convert.ToDateTime(as_balancedate));
                                }
                            }
                            slDoc.SetCellValue("J" + ((a * 1) + 50), data.as_currency);
                            if (!string.IsNullOrEmpty(data.as_originalcurrency))
                            {
                                slDoc.SetCellValue("K" + ((a * 1) + 50), Convert.ToDouble(data.as_originalcurrency));
                            }
                            if (!string.IsNullOrEmpty(data.as_exchrate))
                            {
                                slDoc.SetCellValue("L" + ((a * 1) + 50), Convert.ToDouble(data.as_exchrate));
                            }
                        }
                        a++;
                    }

                    dataassets = _servicesAsset.GetAllAssetBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, 4, taxform.ammend);
                    totalasset += dataassets.Count();
                    if (totalasset > 5)
                    {
                        generatenext = true;
                    }
                    a = 0;
                    foreach (vm.Asset data in dataassets)
                    {
                        if (a < 15)
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
                            string as_owner = "";
                            if (data.as_owner == "taxPayer")
                            {
                                as_owner = "Tax Payer";
                            }
                            else if (data.as_owner == "spouse")
                            {
                                as_owner = "Spouse";
                            }
                            else if (data.as_owner == "child")
                            {
                                as_owner = "Child";
                            }
                            else if (data.as_owner == "joint")
                            {
                                as_owner = "Joint";
                            }
                            slDoc.SetCellValue("B" + ((a * 1) + 71), data.as_refnumber);
                            slDoc.SetCellValue("C" + ((a * 1) + 71), data.as_description);
                            slDoc.SetCellValue("D" + ((a * 1) + 71), as_owner);
                            slDoc.SetCellValue("E" + ((a * 1) + 71), data.as_address);
                            slDoc.SetCellValue("F" + ((a * 1) + 71), data.as_country);
                            slDoc.SetCellValue("G" + ((a * 1) + 71), data.as_details);
                            slDoc.SetCellValue("H" + ((a * 1) + 71), data.as_account);
                            if (as_balancedate != "")
                            {
                                if (data.as_interval == "4")
                                {
                                    string thedate = data.as_balancedate;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("I" + ((a * 1) + 90), thedate);
                                }
                                else if (data.as_interval == "3")
                                {
                                    slDoc.SetCellValue("I" + ((a * 1) + 90), data.as_balancedate.Split('/')[2]);
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
                                    slDoc.SetCellValue("I" + ((a * 1) + 71), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("I" + ((a * 1) + 71), Convert.ToDateTime(as_balancedate));
                                }
                            }
                            slDoc.SetCellValue("J" + ((a * 1) + 71), data.as_currency);
                            if (!string.IsNullOrEmpty(data.as_originalcurrency))
                            {
                                slDoc.SetCellValue("K" + ((a * 1) + 71), Convert.ToDouble(data.as_originalcurrency));
                            }
                            if (!string.IsNullOrEmpty(data.as_exchrate))
                            {
                                slDoc.SetCellValue("L" + ((a * 1) + 71), Convert.ToDouble(data.as_exchrate));
                            }
                        }
                        a++;
                    }

                    dataassets = _servicesAsset.GetAllAssetBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, 5, taxform.ammend);
                    totalasset += dataassets.Count();
                    if (totalasset > 5)
                    {
                        generatenext = true;
                    }
                    a = 0;
                    foreach (vm.Asset data in dataassets)
                    {
                        if (a < 15)
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
                            string as_owner = "";
                            if (data.as_owner == "taxPayer")
                            {
                                as_owner = "Tax Payer";
                            }
                            else if (data.as_owner == "spouse")
                            {
                                as_owner = "Spouse";
                            }
                            else if (data.as_owner == "child")
                            {
                                as_owner = "Child";
                            }
                            else if (data.as_owner == "joint")
                            {
                                as_owner = "Joint";
                            }
                            slDoc.SetCellValue("B" + ((a * 1) + 92), data.as_refnumber);
                            slDoc.SetCellValue("C" + ((a * 1) + 92), data.as_description);
                            slDoc.SetCellValue("D" + ((a * 1) + 92), as_owner);
                            slDoc.SetCellValue("E" + ((a * 1) + 92), data.as_address);
                            slDoc.SetCellValue("F" + ((a * 1) + 92), data.as_country);
                            slDoc.SetCellValue("G" + ((a * 1) + 92), data.as_details);
                            slDoc.SetCellValue("H" + ((a * 1) + 92), data.as_account);
                            if (as_balancedate != "")
                            {
                                if (data.as_interval == "4")
                                {
                                    string thedate = data.as_balancedate;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("I" + ((a * 1) + 92), thedate);
                                }
                                else if (data.as_interval == "3")
                                {
                                    slDoc.SetCellValue("I" + ((a * 1) + 92), data.as_balancedate.Split('/')[2]);
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
                                    slDoc.SetCellValue("I" + ((a * 1) + 92), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("I" + ((a * 1) + 92), Convert.ToDateTime(as_balancedate));
                                }
                            }
                            slDoc.SetCellValue("J" + ((a * 1) + 92), data.as_currency);
                            if (!string.IsNullOrEmpty(data.as_originalcurrency))
                            {
                                slDoc.SetCellValue("K" + ((a * 1) + 92), Convert.ToDouble(data.as_originalcurrency));
                            }
                            if (!string.IsNullOrEmpty(data.as_exchrate))
                            {
                                slDoc.SetCellValue("L" + ((a * 1) + 92), Convert.ToDouble(data.as_exchrate));
                            }
                        }
                        a++;
                    }

                    dataassets = _servicesAsset.GetAllAssetBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, 6, taxform.ammend);
                    totalasset += dataassets.Count();
                    if (totalasset > 5)
                    {
                        generatenext = true;
                    }
                    a = 0;
                    foreach (vm.Asset data in dataassets)
                    {
                        if (a < 15)
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
                            string as_owner = "";
                            if (data.as_owner == "taxPayer")
                            {
                                as_owner = "Tax Payer";
                            }
                            else if (data.as_owner == "spouse")
                            {
                                as_owner = "Spouse";
                            }
                            else if (data.as_owner == "child")
                            {
                                as_owner = "Child";
                            }
                            else if (data.as_owner == "joint")
                            {
                                as_owner = "Joint";
                            }
                            slDoc.SetCellValue("B" + ((a * 1) + 113), data.as_refnumber);
                            slDoc.SetCellValue("C" + ((a * 1) + 113), data.as_description);
                            slDoc.SetCellValue("D" + ((a * 1) + 113), as_owner);
                            slDoc.SetCellValue("E" + ((a * 1) + 113), data.as_address);
                            slDoc.SetCellValue("F" + ((a * 1) + 113), data.as_country);
                            slDoc.SetCellValue("G" + ((a * 1) + 113), data.as_details);
                            slDoc.SetCellValue("H" + ((a * 1) + 113), data.as_account);
                            if (as_balancedate != "")
                            {
                                if (data.as_interval == "4")
                                {
                                    string thedate = data.as_balancedate;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("I" + ((a * 1) + 113), thedate);
                                }
                                else if (data.as_interval == "3")
                                {
                                    slDoc.SetCellValue("I" + ((a * 1) + 113), data.as_balancedate.Split('/')[2]);
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
                                    slDoc.SetCellValue("I" + ((a * 1) + 113), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("I" + ((a * 1) + 113), Convert.ToDateTime(as_balancedate));
                                }
                            }
                            slDoc.SetCellValue("J" + ((a * 1) + 113), data.as_currency);
                            if (!string.IsNullOrEmpty(data.as_originalcurrency))
                            {
                                slDoc.SetCellValue("K" + ((a * 1) + 113), Convert.ToDouble(data.as_originalcurrency));
                            }
                            if (!string.IsNullOrEmpty(data.as_exchrate))
                            {
                                slDoc.SetCellValue("L" + ((a * 1) + 113), Convert.ToDouble(data.as_exchrate));
                            }
                        }
                        a++;
                    }

                    dataassets = _servicesAsset.GetAllAssetBy(Session["taxform-taxpaynumber"].ToString(), taxform.type, taxform.year, 10, taxform.ammend);
                    a = 0;
                    foreach (vm.Asset data in dataassets)
                    {
                        if (a < 20)
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
                            string as_owner = "";
                            if (data.as_owner == "taxPayer")
                            {
                                as_owner = "Tax Payer";
                            }
                            else if (data.as_owner == "spouse")
                            {
                                as_owner = "Spouse";
                            }
                            else if (data.as_owner == "child")
                            {
                                as_owner = "Child";
                            }
                            else if (data.as_owner == "joint")
                            {
                                as_owner = "Joint";
                            }
                            slDoc.SetCellValue("B" + ((a * 1) + 138), data.as_refnumber);
                            slDoc.SetCellValue("C" + ((a * 1) + 138), data.as_description);
                            slDoc.SetCellValue("D" + ((a * 1) + 138), as_owner);
                            slDoc.SetCellValue("E" + ((a * 1) + 138), data.as_address);
                            slDoc.SetCellValue("F" + ((a * 1) + 138), data.as_country);
                            slDoc.SetCellValue("G" + ((a * 1) + 138), data.as_details);
                            slDoc.SetCellValue("H" + ((a * 1) + 138), data.as_account);
                            if (as_balancedate != "")
                            {
                                if (data.as_interval == "4")
                                {
                                    string thedate = data.as_balancedate;
                                    string aa = thedate.Split('-')[0].Substring(0, 3);
                                    string bb = thedate.Split('-')[1].Substring(1, 3);
                                    string cc = thedate.Split('-')[1].Substring(thedate.Split('-')[1].Length - 2, 2);
                                    thedate = aa + "-" + bb + cc;
                                    slDoc.SetCellValue("I" + ((a * 1) + 138), thedate);
                                }
                                else if (data.as_interval == "3")
                                {
                                    slDoc.SetCellValue("I" + ((a * 1) + 138), data.as_balancedate.Split('/')[2]);
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
                                    slDoc.SetCellValue("I" + ((a * 1) + 138), "avg" + mnt + year);
                                }
                                else
                                {
                                    slDoc.SetCellValue("I" + ((a * 1) + 138), Convert.ToDateTime(as_balancedate));
                                }
                            }
                            slDoc.SetCellValue("J" + ((a * 1) + 138), data.as_currency);
                            if (!string.IsNullOrEmpty(data.as_originalcurrency))
                            {
                                slDoc.SetCellValue("K" + ((a * 1) + 138), Convert.ToDouble(data.as_originalcurrency));
                            }
                            if (!string.IsNullOrEmpty(data.as_exchrate))
                            {
                                slDoc.SetCellValue("L" + ((a * 1) + 138), Convert.ToDouble(data.as_exchrate));
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

                        slDoc.SetCellValue("AF" + (144), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_b9)));

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

                        slDoc.SetCellValue("R" + (99 - 8), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_71)));
                        slDoc.SetCellValue("R" + (101 - 8), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_72)));
                        slDoc.SetCellValue("R" + (103 - 8), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_rounded_73)));

                        slDoc.SetCellValue("J" + (14 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_1)));
                        slDoc.SetCellValue("J" + (15 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_2)));
                        slDoc.SetCellValue("N" + (16 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_3)));
                        slDoc.SetCellValue("N" + (17 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_4)));
                        slDoc.SetCellValue("N" + (18 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_5)));
                        slDoc.SetCellValue("R" + (19 + 88), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_6)));
                        slDoc.SetCellValue("J" + (23 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_7)));
                        slDoc.SetCellValue("J" + (24 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_8)));
                        slDoc.SetCellValue("N" + (25 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_9)));
                        slDoc.SetCellValue("N" + (26 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_10)));

                        slDoc.SetCellValue("N" + (27 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_11)));
                        slDoc.SetCellValue("R" + (28 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_12)));
                        slDoc.SetCellValue("AF" + (23 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_13)));
                        slDoc.SetCellValue("AF" + (24 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_14)));
                        slDoc.SetCellValue("AF" + (25 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_15)));
                        slDoc.SetCellValue("R" + (30 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_16)));
                        slDoc.SetCellValue("R" + (32 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_17)));
                        slDoc.SetCellValue("AF" + (33 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_18)));
                        slDoc.SetCellValue("AF" + (34 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_19)));
                        slDoc.SetCellValue("AF" + (35 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_20)));

                        slDoc.SetCellValue("AF" + (36 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_21)));
                        slDoc.SetCellValue("AF" + (37 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_22)));
                        slDoc.SetCellValue("AF" + (38 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_23)));
                        slDoc.SetCellValue("AF" + (39 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_24)));
                        slDoc.SetCellValue("J" + (35 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_25)));
                        slDoc.SetCellValue("J" + (36 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_26)));
                        slDoc.SetCellValue("N" + (37 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_27)));
                        slDoc.SetCellValue("N" + (38 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_28)));
                        slDoc.SetCellValue("R" + (39 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_29)));
                        slDoc.SetCellValue("J" + (42 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_30)));

                        slDoc.SetCellValue("J" + (43 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_31)));
                        slDoc.SetCellValue("N" + (44 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_32)));
                        slDoc.SetCellValue("N" + (45 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_33)));
                        slDoc.SetCellValue("R" + (46 + 87), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_34)));
                        slDoc.SetCellValue("J" + (59 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_35)));
                        slDoc.SetCellValue("J" + (60 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_36)));
                        slDoc.SetCellValue("N" + (61 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_37)));
                        slDoc.SetCellValue("J" + (63 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_38)));
                        slDoc.SetCellValue("J" + (64 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_39)));
                        slDoc.SetCellValue("N" + (65 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_40)));

                        slDoc.SetCellValue("J" + (67 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_41)));
                        slDoc.SetCellValue("J" + (68 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_42)));
                        slDoc.SetCellValue("N" + (69 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_43)));
                        slDoc.SetCellValue("R" + (71 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_44)));
                        slDoc.SetCellValue("AF" + (66 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_45)));
                        slDoc.SetCellValue("AF" + (67 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_46)));
                        slDoc.SetCellValue("AF" + (68 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_47)));
                        slDoc.SetCellValue("R" + (73 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_48)));
                        slDoc.SetCellValue("R" + (75 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_49)));
                        slDoc.SetCellValue("AF" + (76 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_50)));

                        slDoc.SetCellValue("AF" + (77 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_51)));
                        slDoc.SetCellValue("AF" + (78 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_52)));
                        slDoc.SetCellValue("AF" + (79 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_53)));
                        slDoc.SetCellValue("AF" + (80 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_54)));
                        slDoc.SetCellValue("AF" + (81 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_55)));
                        slDoc.SetCellValue("AF" + (82 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_56)));
                        slDoc.SetCellValue("J" + (78 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_57)));
                        slDoc.SetCellValue("J" + (79 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_58)));
                        slDoc.SetCellValue("N" + (80 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_59)));
                        slDoc.SetCellValue("N" + (81 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_60)));

                        slDoc.SetCellValue("R" + (82 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_61)));
                        slDoc.SetCellValue("J" + (85 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_62)));
                        slDoc.SetCellValue("J" + (86 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_63)));
                        slDoc.SetCellValue("N" + (87 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_64)));
                        slDoc.SetCellValue("N" + (88 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_65)));
                        slDoc.SetCellValue("R" + (89 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_66)));
                        slDoc.SetCellValue("N" + (92 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_67)));
                        slDoc.SetCellValue("N" + (93 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_68)));
                        slDoc.SetCellValue("N" + (94 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_69)));
                        slDoc.SetCellValue("R" + (95 + 82), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_70)));

                        slDoc.SetCellValue("R" + (99 + 80), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_71)));
                        slDoc.SetCellValue("R" + (101 + 80), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_72)));
                        slDoc.SetCellValue("R" + (103 + 80), Convert.ToDouble(String.Format("{0:#,##0}", calculation.calc_not_73)));
                    }
                }


                debugtext = "DEBUG 11 ";
                slDoc.SelectWorksheet("GENERAL INFO");
                string excelfile = HttpContext.Current.Server.MapPath(exportPath + sessionLog + "/" + hdid.Value + "-report/") + hdid.Value + "-" + templatename + ".xlsx";
                slDoc.SaveAs(excelfile);

                debugtext = "DEBUG 12 ";
                try
                {
                    ss.Workbook workbook = new ss.Workbook();
                    workbook.LoadFromFile(HttpContext.Current.Server.MapPath(exportPath + sessionLog + "/" + hdid.Value + "-report/") + hdid.Value + "-" + templatename + ".xlsx", ss.ExcelVersion.Version2013);

                    ss.Worksheet sheetselected = workbook.Worksheets[0];

                    for (int aa = 4; aa <= 20; aa++)
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

        protected void btnDownloadExcel_Click(object sender, EventArgs e)
        {
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
                selectedfilenamearr.Add("Form1770S");
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

        protected void LinkButton20_Click(object sender, EventArgs e)
        {
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
                    System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)this.Master.FindControl("MainContent").FindControl("CheckBox" + i);
                    if (cb.Checked)
                    {
                        if (i == 1)
                        {
                            selectedarr.Add(7);
                            selectedfilenamearr.Add("FE-1770S");
                        }
                        else if (i == 2)
                        {
                            selectedarr.Add(8);
                            selectedfilenamearr.Add("FE-1770S-I");
                        }
                        else if (i == 3)
                        {
                            selectedarr.Add(9);
                            selectedfilenamearr.Add("FE-1770S-II");
                            selectedarr.Add(10);
                            selectedfilenamearr.Add("FE-1770 S-II (2)");
                        }
                        else if (i == 4)
                        {
                            selectedarr.Add(11);
                            selectedfilenamearr.Add("Attachment");
                        }
                        else if (i == 5)
                        {
                            selectedarr.Add(15);
                            selectedfilenamearr.Add("1770S");
                        }
                        else if (i == 6)
                        {
                            selectedarr.Add(16);
                            selectedfilenamearr.Add("1770S-I");
                        }
                        else if (i == 7)
                        {
                            selectedarr.Add(17);
                            selectedfilenamearr.Add("1770S-II");
                            selectedarr.Add(18);
                            selectedfilenamearr.Add("1770 S-II (2)");
                        }
                        else if (i == 8)
                        {
                            selectedarr.Add(19);
                            selectedfilenamearr.Add("LAMPIRAN.");
                        }
                        else if (i == 9)
                        {
                            selectedarr.Add(12);
                            selectedfilenamearr.Add("1721A1 (1)");
                            selectedarr.Add(13);
                            selectedfilenamearr.Add("1721A1 (2)");
                            selectedarr.Add(14);
                            selectedfilenamearr.Add("1721A1 (3)");
                        }
                        else if (i == 10)
                        {
                            selectedarr.Add(6);
                            selectedfilenamearr.Add("ENVELOPEFORM");
                        }
                        else if (i == 11)
                        {
                            selectedarr.Add(0);
                            selectedfilenamearr.Add("Form1770S");
                        }
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

        protected void UnSelect(object sender, EventArgs e)
        {
            for (int i = 1; i <= reportCount; i++)
            {
                System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)this.Master.FindControl("MainContent").FindControl("CheckBox" + i);
                cb.Checked = false;
            }
        }

        protected void Select(object sender, EventArgs e)
        {
            for (int i = 1; i <= reportCount; i++)
            {
                System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)this.Master.FindControl("MainContent").FindControl("CheckBox" + i);
                cb.Checked = true;
            }
        }


        protected void btnBackTaxform_Click(object sender, EventArgs e)
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

        protected void btnBackForm_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/formnonus.aspx?id=" + hdid.Value);
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }
    }
}