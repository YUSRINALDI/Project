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
    public partial class Taxform : System.Web.UI.Page
    {
        private TaxPlayerServices _services;
        private TaxFormServices _servicesTaxForm;

        private FamilyServices _servicesFamily;
        private IEIncomeServices _servicesIEIncome;
        private OverseasCapitalServices _servicesCapital;
        private OverseaRentalServices _servicesRental;
        private OverseaIncomeServices _servicesIncome;
        private OverseasDetailedServices _servicesIncomeDetailed;
        private AssetServices _servicesAsset;
        private IrregularServices _servicesIrr;

        private string taxPlayerNumber;

        protected void Page_Load(object sender, EventArgs e)
        {
            _services = ServicesFactory.CreateTaxPlayerServices(ConnectionString.Value);
            _servicesTaxForm = ServicesFactory.CreateTaxFormServices(ConnectionString.Value);

            _servicesFamily = ServicesFactory.CreateFamilyServices(ConnectionString.Value);
            _servicesIEIncome = ServicesFactory.CreateIEIncomeServices(ConnectionString.Value);
            _servicesCapital = ServicesFactory.CreateOvCapitalServices(ConnectionString.Value);
            _servicesRental = ServicesFactory.CreateOvRentalServices(ConnectionString.Value);
            _servicesIncome = ServicesFactory.CreateOvIncomeServices(ConnectionString.Value);
            _servicesIncomeDetailed = ServicesFactory.CreateOvIncomeDetailedServices(ConnectionString.Value);
            _servicesAsset = ServicesFactory.CreateAssetServices(ConnectionString.Value);
            _servicesIrr = ServicesFactory.CreateIrregularServices(ConnectionString.Value);

            if (!this.IsPostBack)
            {
                this.loadData();
            }
        }

        private void loadData()
        {
            try
            {
                int fromyear = 2017;
                int currentYear = DateTime.Now.Year;
                int totalyear = currentYear - fromyear;
                int startyear = fromyear;
                for (int i = 0; i <= totalyear; i++)
                {
                    txtYear.Items.Add(new ListItem(startyear.ToString(), startyear.ToString()));
                    startyear += 1;
                }

                if (!string.IsNullOrEmpty(Request.QueryString["eid"]))
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["d"]))
                    {
                        int eid = Convert.ToInt32(Request.QueryString["eid"]);
                        vm.TaxForm vmTaxForm = _servicesTaxForm.GetAllByID(eid);

                        List<vm.Family> datas = _servicesFamily.GetAllBy(vmTaxForm.TaxPayerNumber, vmTaxForm.type, vmTaxForm.year, vmTaxForm.ammend);
                        foreach(vm.Family data in datas){
                            _servicesFamily.Delete(data.id);
                        }

                        List<vm.IEIncome> datas2 = _servicesIEIncome.GetAllBy(vmTaxForm.TaxPayerNumber, vmTaxForm.type, vmTaxForm.year, vmTaxForm.ammend);
                        foreach (vm.IEIncome data in datas2)
                        {
                            _servicesIEIncome.Delete(data.id);
                        }

                        List<vm.OverseasIncome> datas3 = _servicesIncome.GetAllBy2(vmTaxForm.TaxPayerNumber, vmTaxForm.type, vmTaxForm.year, vmTaxForm.ammend);
                        foreach (vm.OverseasIncome data in datas3)
                        {
                            _servicesIncome.Delete(data.id);
                        }

                        List<vm.OverseasDetailed> datas4 = _servicesIncomeDetailed.GetAllBy(vmTaxForm.TaxPayerNumber, vmTaxForm.type, vmTaxForm.year, vmTaxForm.ammend);
                        foreach (vm.OverseasDetailed data in datas4)
                        {
                            _servicesIncomeDetailed.Delete(data.id);
                        }

                        List<vm.OverseasCapital> datas5 = _servicesCapital.GetAllBy(vmTaxForm.TaxPayerNumber, vmTaxForm.type, vmTaxForm.year, vmTaxForm.ammend);
                        foreach (vm.OverseasCapital data in datas5)
                        {
                            _servicesCapital.Delete(data.id);
                        }

                        List<vm.OverseasRental> datas6 = _servicesRental.GetAllBy(vmTaxForm.TaxPayerNumber, vmTaxForm.type, vmTaxForm.year, vmTaxForm.ammend);
                        foreach (vm.OverseasRental data in datas6)
                        {
                            _servicesRental.Delete(data.id);
                        }

                        List<vm.Asset> datas7 = _servicesAsset.GetAssetBy(vmTaxForm.TaxPayerNumber, vmTaxForm.type, vmTaxForm.year, vmTaxForm.ammend);
                        foreach (vm.Asset data in datas7)
                        {
                            _servicesAsset.Delete(data.id);
                        }

                        List<vm.Irregular> datas8 = _servicesIrr.GetBy(vmTaxForm.TaxPayerNumber, vmTaxForm.type, vmTaxForm.year, vmTaxForm.ammend);
                        foreach (vm.Irregular data in datas8)
                        {
                            _servicesIrr.Delete(data.id);
                        }

                        _servicesTaxForm.Delete(vmTaxForm.id);
                        taxPlayerNumber = Request.QueryString["id"];
                        Response.Redirect("~/taxform.aspx?id=" + taxPlayerNumber);
                    }
                    else
                    {
                        taxPlayerNumber = Request.QueryString["id"];
                        vm.TaxPlayer vmTaxPlayer = _services.GetByTaxPayerNumber(taxPlayerNumber);

                        var taxidnumber = vmTaxPlayer.TaxRefNo;
                        var createdby = Session["userLog"].ToString();
                        var createddate = Hash.UnixTimeNow().ToString();
                        int eid = Convert.ToInt32(Request.QueryString["eid"]);
                        int theid = _servicesTaxForm.CreateNewCopy(eid, createdby, createddate);
                        Session["taxform-taxform"] = Request.QueryString["f"];
                        Session["taxform-taxidnumber"] = taxidnumber;
                        Session["taxform-taxyear"] = Request.QueryString["year"];
                        Response.Redirect("~/" + Request.QueryString["f"] + ".aspx?id=" + theid);
                    }
                }
                else
                {
                    taxPlayerNumber = Request.QueryString["id"];
                    Session["taxform-taxpaynumber"] = taxPlayerNumber;
                    vm.TaxPlayer vmTaxPlayer = _services.GetByTaxPayerNumber(taxPlayerNumber);
                    txtCompany.Value = vmTaxPlayer.COY_NAME_Key;
                    txtPlayerName.Value = vmTaxPlayer.TaxPayerName;


                    List<vm.TaxForm> taxForms = _servicesTaxForm.GetAllBy(vmTaxPlayer.TaxRefNo, "", "", 1);
                    string htmltext = "";
                    int i = 1;
                    foreach (vm.TaxForm taxForm in taxForms)
                    {
                        string formname = "";
                        if (taxForm.type == "form1770")
                        {
                            formname = "Form 1770";
                        }
                        else if (taxForm.type == "formNonUs")
                        {
                            formname = "Form Non US";
                        }
                        else if (taxForm.type == "formUs")
                        {
                            formname = "Form US";
                        }
                        else if (taxForm.type == "formJapan")
                        {
                            formname = "Form Japan";
                        }
                        htmltext += "<tr><td>" + i + "</td>";
                        htmltext += "<td>" + taxForm.year + "</td>";
                        htmltext += "<td>" + formname + "</td>";
                        htmltext += "<td>" + taxForm.ammend + "</td>";
                        htmltext += "<td><ul class=\"icons-list\"><li><a title=\"Edit\" href=\"" + taxForm.type + ".aspx?id=" + taxForm.id + "\"><i class=\"icon-pencil7\"></i> </a></li>";
                        htmltext += "<li><a title=\"Amendment\" href=\"taxform.aspx?id=" + taxPlayerNumber + "&eid=" + taxForm.id + "&year=" + taxForm.year + "&f=" + taxForm.type + "\"><i class=\"icon-add\"></i> </a></li>";
                        htmltext += "<li><a title=\"Delete\" onclick=\"confirm('Are you sure?')\" href=\"taxform.aspx?id=" + taxPlayerNumber + "&d=1&eid=" + taxForm.id + "&year=" + taxForm.year + "&f=" + taxForm.type + "\"><i class=\"icon-trash\"></i> </a></li>";
                        if (taxForm.type == "form1770")
                        {
                            htmltext += "<li><a title=\"View Calculation\" href=\"calculation.aspx?id=" + taxForm.id + "\"><i class=\"icon-file-pdf\"></i> </a></li></ul></td></tr>";
                        }
                        else if (taxForm.type == "formNonUs")
                        {
                            htmltext += "<li><a title=\"View Calculation\" href=\"calculation_nonus.aspx?id=" + taxForm.id + "\"><i class=\"icon-file-pdf\"></i> </a></li></ul></td></tr>";
                        }
                        else if (taxForm.type == "formUs")
                        {
                            htmltext += "<li><a title=\"View Calculation\" href=\"calculation_us.aspx?id=" + taxForm.id + "\"><i class=\"icon-file-pdf\"></i> </a></li></ul></td></tr>";
                        }
                        else if (taxForm.type == "formJapan")
                        {
                            htmltext += "<li><a title=\"View Calculation\" href=\"calculation_japan.aspx?id=" + taxForm.id + "\"><i class=\"icon-file-pdf\"></i> </a></li></ul></td></tr>";
                        }

                        dataTable.Text = htmltext;
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                taxPlayerNumber = Request.QueryString["id"];

                vm.TaxPlayer vmTaxPlayer = _services.GetByTaxPayerNumber(taxPlayerNumber);

                var taxidnumber = vmTaxPlayer.TaxRefNo;
                var type = cbForm.Value;
                var year = txtYear.Value;
                var t1s1f2 = vmTaxPlayer.TaxPayerName;
                var createdby = Session["userLog"].ToString();
                var createddate = Hash.UnixTimeNow().ToString();

                Session["taxform-taxidnumber"] = taxidnumber;
                Session["taxform-taxform"] = type;
                Session["taxform-taxyear"] = year;

                int theid = 0;
                List<vm.TaxForm> lastTaxForms = _servicesTaxForm.GetAllBy(taxidnumber, type, year, -1);
                if (lastTaxForms.Count() == 0)
                {
                    //insert new form
                    theid = _servicesTaxForm.Create(0, 0, taxidnumber, type, year, t1s1f2, createdby, createddate, createdby, createddate);
                }
                else
                {
                    foreach (vm.TaxForm taxForm in lastTaxForms)
                    {
                        if (taxForm.status == 1)
                        {
                            //copy last form with new ammend
                            theid = _servicesTaxForm.CreateNewCopy(taxForm.id, createdby, createddate);
                        }
                        else
                        {
                            theid = _servicesTaxForm.GetLastRecordID(taxidnumber, type, year);
                        }
                    }
                }

                Response.Redirect("~/" + cbForm.Value + ".aspx?id=" + theid);
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}