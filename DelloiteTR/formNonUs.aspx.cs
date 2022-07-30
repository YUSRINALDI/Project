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
    public partial class formNonUs : System.Web.UI.Page
    {
        private TaxPlayerServices _services;
        private FamilyServices _servicesFamily;
        private RelationshipServices _servicesRelationship;
        private IEIncomeServices _servicesIEIncome;
        private TaxFormServices _servicesTaxForm;
        private MaritalServices _servicesMarital;

        private int taxFormID;

        protected void Page_Load(object sender, EventArgs e)
        {
            SetMessage("");
            _services = ServicesFactory.CreateTaxPlayerServices(ConnectionString.Value);
            _servicesFamily = ServicesFactory.CreateFamilyServices(ConnectionString.Value);
            _servicesRelationship = ServicesFactory.CreateRelationshipServices(ConnectionString.Value);
            _servicesIEIncome = ServicesFactory.CreateIEIncomeServices(ConnectionString.Value);
            _servicesTaxForm = ServicesFactory.CreateTaxFormServices(ConnectionString.Value);
            _servicesMarital = ServicesFactory.CreateMaritalServices(ConnectionString.Value);

            if (!this.IsPostBack)
            {
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
                int fromyear = 2017;
                int currentYear = DateTime.Now.Year;
                int totalyear = currentYear - fromyear;
                int startyear = fromyear;
                for (int i = 0; i <= totalyear; i++)
                {
                    oi_dateofreceipt2_2_1.Items.Add(new ListItem(startyear.ToString(), startyear.ToString()));
                    as_dateofreceipt2_2_1.Items.Add(new ListItem(startyear.ToString(), startyear.ToString()));
                    cap_dateofreceipt2_2_1.Items.Add(new ListItem(startyear.ToString(), startyear.ToString()));
                    ren_dateofreceipt2_2_1.Items.Add(new ListItem(startyear.ToString(), startyear.ToString()));
                    startyear += 1;
                }

                IEnumerable<vm.Marital> maritals = _servicesMarital.GetAll();
                List<string> maritalGroups = new List<string>();
                foreach (vm.Marital marital in maritals)
                {
                    string status = marital.status.Split(';')[0].ToString();
                    if (!maritalGroups.Contains(status))
                    {
                        maritalGroups.Add(status);
                    }
                }
                t1s3f1.Items.Add(new ListItem("", ""));
                foreach (string marital in maritalGroups)
                {
                    string status = "";
                    if (marital == "Married1")
                    {
                        status = "Married";
                    }
                    else if (marital == "Married2")
                    {
                        status = "Married+";
                    }
                    else
                    {
                        status = marital;
                    }
                    t1s3f1.Items.Add(new ListItem(status, marital));
                }

                taxFormID = int.Parse(Request.QueryString["id"]);
                vm.TaxForm vmTaxForm = _servicesTaxForm.GetAllByID(taxFormID);
                selectedform.Value = vmTaxForm.type;
                lblBreadcrumb.Text = vmTaxForm.t1s1f2 + " | " + vmTaxForm.year + " | " +
                    vmTaxForm.type;

                String timeStamp = Hash.UnixTimeNow().ToString();
                hdTaxPlayerNumber.Value = vmTaxForm.TaxPayerNumber;
                hdcreatedby.Value = Session["userLog"].ToString();
                hdcreateddate.Value = timeStamp;
                hdtaxformid.Value = taxFormID.ToString();

                //start-form1-1=====================
                t1s1f1.Value = vmTaxForm.taxidnumber;
                t1s1f2.Value = vmTaxForm.t1s1f2;
                t1s1f3.Value = vmTaxForm.year;
                t1s1f4.Text = vmTaxForm.t1s1f4;
                t1s1f5.Text = vmTaxForm.t1s1f5;
                t1s1f6.Text = vmTaxForm.t1s1f6;
                if(!string.IsNullOrEmpty(vmTaxForm.t1s1f7)){
                    t1s1f7.SelectedValue = vmTaxForm.t1s1f7;
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s1f8))
                {
                    t1s1f8.Text = vmTaxForm.t1s1f8;
                }
                //finish-form1-1====================

                //start-form1-2=====================
                t1s2f1.Value = vmTaxForm.t1s2f1;
                t1s2f2.Text = vmTaxForm.ammend.ToString();
                t1s2f3.Value = vmTaxForm.t1s2f3;
                if (string.IsNullOrEmpty(vmTaxForm.t1s2f4))
                {
                    t1s2f4.Text = "0";
                }
                else
                {
                    t1s2f4.Text = vmTaxForm.t1s2f4;
                }
                
                t1s2f5.Value = vmTaxForm.t1s2f5;
                t1s2f6.Value = vmTaxForm.t1s2f6;
                t1s2f7.Value = vmTaxForm.t1s2f7;
                t1s2f8.Value = vmTaxForm.t1s2f8;
                t1s2f9.Value = vmTaxForm.t1s2f9;
                t1s2f10.Checked = Convert.ToBoolean(vmTaxForm.t1s2f10);
                t1s2f11.Checked = Convert.ToBoolean(vmTaxForm.t1s2f11);
                t1s2f12.Checked = Convert.ToBoolean(vmTaxForm.t1s2f12);
                t1s2f13.Checked = Convert.ToBoolean(vmTaxForm.t1s2f13);
                t1s2f14.Checked = Convert.ToBoolean(vmTaxForm.t1s2f14);
                t1s2f15.Checked = Convert.ToBoolean(vmTaxForm.t1s2f15);
                t1s2f16.Checked = Convert.ToBoolean(vmTaxForm.t1s2f16);
                t1s2f17.Checked = Convert.ToBoolean(vmTaxForm.t1s2f17);
                t1s2f18.Value = vmTaxForm.t1s2f18;
                t1s2f19.Value = vmTaxForm.t1s2f19;
                t1s2f20.Checked = Convert.ToBoolean(vmTaxForm.t1s2f20);
                t1s2f21.Checked = Convert.ToBoolean(vmTaxForm.t1s2f21);
                t1s2f22.Checked = Convert.ToBoolean(vmTaxForm.t1s2f22);
                t1s2f23.Value = vmTaxForm.t1s2f23;
                t1s2f24.Value = vmTaxForm.t1s2f24;
                //finish-form1-2====================

                //start-form1-3=====================
                t1s3f1.SelectedValue = vmTaxForm.t1s3f1;
                t1s3f2.Text = vmTaxForm.t1s3f2;
                t1s3f3.Text = vmTaxForm.t1s3f3;
                //finish-form1-3====================

                //start-form1-4=====================
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f1))
                {
                    t1s4f1.Value = vmTaxForm.t1s4f1.ToString().Split('.')[0];
                }
                t1s4f2.Value = vmTaxForm.t1s4f2;
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f3))
                {
                    t1s4f3.Value = vmTaxForm.t1s4f3.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f4))
                {
                    t1s4f4.Value = vmTaxForm.t1s4f4.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f5))
                {
                    t1s4f5.Value = vmTaxForm.t1s4f5.ToString().Split('.')[0];
                }
                t1s4f6.Value = vmTaxForm.t1s4f6;
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f7))
                {
                    t1s4f7.Value = vmTaxForm.t1s4f7.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f8))
                {
                    t1s4f8.Value = vmTaxForm.t1s4f8.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f9))
                {
                    t1s4f9.Value = vmTaxForm.t1s4f9.ToString().Split('.')[0];
                }
                t1s4f10.Value = vmTaxForm.t1s4f10;
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f11))
                {
                    t1s4f11.Value = vmTaxForm.t1s4f11.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f12))
                {
                    t1s4f12.Value = vmTaxForm.t1s4f12.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f13))
                {
                    t1s4f13.Value = vmTaxForm.t1s4f13.ToString().Split('.')[0];
                }
                t1s4f14.Value = vmTaxForm.t1s4f14;
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f15))
                {
                    t1s4f15.Value = vmTaxForm.t1s4f15.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f16))
                {
                    t1s4f16.Value = vmTaxForm.t1s4f16.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f17))
                {
                    t1s4f17.Value = vmTaxForm.t1s4f17.ToString().Split('.')[0];
                }
                t1s4f18.Value = vmTaxForm.t1s4f18;
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f19))
                {
                    t1s4f19.Value = vmTaxForm.t1s4f19.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f20))
                {
                    t1s4f20.Value = vmTaxForm.t1s4f20.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f21))
                {
                    t1s4f21.Value = vmTaxForm.t1s4f21.ToString().Split('.')[0];
                }
                t1s4f22.Value = vmTaxForm.t1s4f22;
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f23))
                {
                    t1s4f23.Value = vmTaxForm.t1s4f23.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f24))
                {
                    t1s4f24.Value = vmTaxForm.t1s4f24.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f25))
                {
                    t1s4f25.Value = vmTaxForm.t1s4f25.ToString().Split('.')[0];
                }
                t1s4f26.Value = vmTaxForm.t1s4f26;
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f27))
                {
                    t1s4f27.Value = vmTaxForm.t1s4f27.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f28))
                {
                    t1s4f28.Value = vmTaxForm.t1s4f28.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f29))
                {
                    t1s4f29.Value = vmTaxForm.t1s4f29.ToString().Split('.')[0];
                }
                t1s4f30.Value = vmTaxForm.t1s4f30;
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f31))
                {
                    t1s4f31.Value = vmTaxForm.t1s4f31.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f32))
                {
                    t1s4f32.Value = vmTaxForm.t1s4f32.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f33))
                {
                    t1s4f33.Value = vmTaxForm.t1s4f33.ToString().Split('.')[0];
                }
                t1s4f34.Value = vmTaxForm.t1s4f34;
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f35))
                {
                    t1s4f35.Value = vmTaxForm.t1s4f35.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f36))
                {
                    t1s4f36.Value = vmTaxForm.t1s4f36.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f37))
                {
                    t1s4f37.Value = vmTaxForm.t1s4f37.ToString().Split('.')[0];
                }
                t1s4f38.Value = vmTaxForm.t1s4f38;
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f39))
                {
                    t1s4f39.Value = vmTaxForm.t1s4f39.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f40))
                {
                    t1s4f40.Value = vmTaxForm.t1s4f40.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f41))
                {
                    t1s4f41.Value = vmTaxForm.t1s4f41.ToString().Split('.')[0];
                }
                t1s4f42.Value = vmTaxForm.t1s4f42;
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f43))
                {
                    t1s4f43.Value = vmTaxForm.t1s4f43.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f44))
                {
                    t1s4f44.Value = vmTaxForm.t1s4f44.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f45))
                {
                    t1s4f45.Value = vmTaxForm.t1s4f45.ToString().Split('.')[0];
                }
                t1s4f46.Value = vmTaxForm.t1s4f46;
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f47))
                {
                    t1s4f47.Value = vmTaxForm.t1s4f47.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f48))
                {
                    t1s4f48.Value = vmTaxForm.t1s4f48.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f49))
                {
                    t1s4f49.Value = vmTaxForm.t1s4f49.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f50))
                {
                    t1s4f50.Value = vmTaxForm.t1s4f50.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f51))
                {
                    t1s4f51.Value = vmTaxForm.t1s4f51.ToString().Split('.')[0];
                }
                t1s4f52.Value = vmTaxForm.t1s4f52;
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f53))
                {
                    t1s4f53.Value = vmTaxForm.t1s4f53.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f54))
                {
                    t1s4f54.Value = vmTaxForm.t1s4f54.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s4f55))
                {
                    t1s4f55.Value = vmTaxForm.t1s4f55.ToString().Split('.')[0];
                }
                //finish-form1-4====================

                //start-form1-5=====================
                totalemployee.Value = vmTaxForm.totalemployee;
                totalperiod.Value = vmTaxForm.totalperiod;
                totalsalaries.Value = vmTaxForm.totalsalaries;
                totalincome.Value = vmTaxForm.totalincome;
                totalother.Value = vmTaxForm.totalother;
                totalhonorarium.Value = vmTaxForm.totalhonorarium;
                totalinsurance.Value = vmTaxForm.totalinsurance;
                totalbenefit.Value = vmTaxForm.totalbenefit;
                totalbonus.Value = vmTaxForm.totalbonus;
                totalgross.Value = vmTaxForm.totalgross;
                totalcost.Value = vmTaxForm.totalcost;
                totalpension.Value = vmTaxForm.totalpension;
                totalpensioncost.Value = vmTaxForm.totalpensioncost;
                totalincome25.Value = vmTaxForm.totalincome25;
                totalincome26.Value = vmTaxForm.totalincome26;
                totalincome27.Value = vmTaxForm.totalincome27;
                totalincome28.Value = vmTaxForm.totalincome28;
                totalincome29.Value = vmTaxForm.totalincome29;
                totaldeductions.Value = vmTaxForm.totaldeductions;
                totalnetincome.Value = vmTaxForm.totalnetincome;
                totalincometax.Value = vmTaxForm.totalincometax;
                totalprevnetincome.Value = vmTaxForm.totalprevnetincome;
                totalprevincometax.Value = vmTaxForm.totalprevincometax;
                //finish-form1-5====================

                //start-form1-6=====================
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f1))
                {
                    t1s6f1.Value = vmTaxForm.t1s6f1.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f2))
                {
                    t1s6f2.Value = vmTaxForm.t1s6f2.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f3))
                {
                    t1s6f3.Value = vmTaxForm.t1s6f3.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f4))
                {
                    t1s6f4.Value = vmTaxForm.t1s6f4.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f5))
                {
                    t1s6f5.Value = vmTaxForm.t1s6f5.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f6))
                {
                    t1s6f6.Value = vmTaxForm.t1s6f6.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f7))
                {
                    t1s6f7.Value = vmTaxForm.t1s6f7.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f8))
                {
                    t1s6f8.Value = vmTaxForm.t1s6f8.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f9))
                {
                    t1s6f9.Value = vmTaxForm.t1s6f9.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f10))
                {
                    t1s6f10.Value = vmTaxForm.t1s6f10.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f11))
                {
                    t1s6f11.Value = vmTaxForm.t1s6f11.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f12))
                {
                    t1s6f12.Value = vmTaxForm.t1s6f12.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f13))
                {
                    t1s6f13.Value = vmTaxForm.t1s6f13.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f14))
                {
                    t1s6f14.Value = vmTaxForm.t1s6f14.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f15))
                {
                    t1s6f15.Value = vmTaxForm.t1s6f15.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f16))
                {
                    t1s6f16.Value = vmTaxForm.t1s6f16.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f17))
                {
                    t1s6f17.Value = vmTaxForm.t1s6f17.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f18))
                {
                    t1s6f18.Value = vmTaxForm.t1s6f18.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f19))
                {
                    t1s6f19.Value = vmTaxForm.t1s6f19.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f20))
                {
                    t1s6f20.Value = vmTaxForm.t1s6f20.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f21))
                {
                    t1s6f21.Value = vmTaxForm.t1s6f21.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f22))
                {
                    t1s6f22.Value = vmTaxForm.t1s6f22.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f23))
                {
                    t1s6f23.Value = vmTaxForm.t1s6f23.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f24))
                {
                    t1s6f24.Value = vmTaxForm.t1s6f24.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s6f25))
                {
                    t1s6f25.Value = vmTaxForm.t1s6f25.ToString().Split('.')[0];
                }
                //finish-form1-6====================

                //start-form1-7=====================
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f1))
                {
                    t1s7f1.Value = vmTaxForm.t1s7f1.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f2))
                {
                    t1s7f2.Value = vmTaxForm.t1s7f2.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f3))
                {
                    t1s7f3.Value = vmTaxForm.t1s7f3.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f4))
                {
                    t1s7f4.Value = vmTaxForm.t1s7f4.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f5))
                {
                    t1s7f5.Value = vmTaxForm.t1s7f5.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f6))
                {
                    t1s7f6.Value = vmTaxForm.t1s7f6.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f7))
                {
                    t1s7f7.Value = vmTaxForm.t1s7f7.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f8))
                {
                    t1s7f8.Value = vmTaxForm.t1s7f8.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f9))
                {
                    t1s7f9.Value = vmTaxForm.t1s7f9.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f10))
                {
                    t1s7f10.Value = vmTaxForm.t1s7f10.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f11))
                {
                    t1s7f11.Value = vmTaxForm.t1s7f11.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f12))
                {
                    t1s7f12.Value = vmTaxForm.t1s7f12.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f13))
                {
                    t1s7f13.Value = vmTaxForm.t1s7f13.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f14))
                {
                    t1s7f14.Value = vmTaxForm.t1s7f14.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f15))
                {
                    t1s7f15.Value = vmTaxForm.t1s7f15.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f16))
                {
                    t1s7f16.Value = vmTaxForm.t1s7f16.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f17))
                {
                    t1s7f17.Value = vmTaxForm.t1s7f17.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f18))
                {
                    t1s7f18.Value = vmTaxForm.t1s7f18.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f19))
                {
                    t1s7f19.Value = vmTaxForm.t1s7f19.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f20))
                {
                    t1s7f20.Value = vmTaxForm.t1s7f20.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f21))
                {
                    t1s7f21.Value = vmTaxForm.t1s7f21.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f22))
                {
                    t1s7f22.Value = vmTaxForm.t1s7f22.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f23))
                {
                    t1s7f23.Value = vmTaxForm.t1s7f23.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f24))
                {
                    t1s7f24.Value = vmTaxForm.t1s7f24.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f25))
                {
                    t1s7f25.Value = vmTaxForm.t1s7f25.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f26))
                {
                    t1s7f26.Value = vmTaxForm.t1s7f26.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f27))
                {
                    t1s7f27.Value = vmTaxForm.t1s7f27.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f28))
                {
                    t1s7f28.Value = vmTaxForm.t1s7f28.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f29))
                {
                    t1s7f29.Value = vmTaxForm.t1s7f29.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f30))
                {
                    t1s7f30.Value = vmTaxForm.t1s7f30.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f31))
                {
                    t1s7f31.Value = vmTaxForm.t1s7f31.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f32))
                {
                    t1s7f32.Value = vmTaxForm.t1s7f32.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f33))
                {
                    t1s7f33.Value = vmTaxForm.t1s7f33.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f34))
                {
                    t1s7f34.Value = vmTaxForm.t1s7f34.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f35))
                {
                    t1s7f35.Value = vmTaxForm.t1s7f35.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f36))
                {
                    t1s7f36.Value = vmTaxForm.t1s7f36.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f37))
                {
                    t1s7f37.Value = vmTaxForm.t1s7f37.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f38))
                {
                    t1s7f38.Value = vmTaxForm.t1s7f38.ToString().Split('.')[0];
                }
                if (!string.IsNullOrEmpty(vmTaxForm.t1s7f39))
                {
                    t1s7f39.Value = vmTaxForm.t1s7f39.ToString().Split('.')[0];
                }
                //finish-form1-7====================

                //start-form1-8=====================
                t1s8f1.Checked = Convert.ToBoolean(vmTaxForm.t1s8f1);
                t1s8f2.Checked = Convert.ToBoolean(vmTaxForm.t1s8f2);
                t1s8f3.Checked = Convert.ToBoolean(vmTaxForm.t1s8f3);
                t1s8f4.Checked = Convert.ToBoolean(vmTaxForm.t1s8f4);
                t1s8f5.Checked = Convert.ToBoolean(vmTaxForm.t1s8f5);
                t1s8f6.Value = vmTaxForm.t1s8f6;
                t1s8f7.Value = vmTaxForm.t1s8f7;
                t1s8f8.Value = vmTaxForm.t1s8f8;
                t1s8f9.Value = vmTaxForm.t1s8f9;
                t1s8f10.Value = vmTaxForm.t1s8f10;
                t1s8f11.Value = vmTaxForm.t1s8f11;
                t1s8f12.Value = vmTaxForm.t1s8f12;
                t1s8f13.Value = vmTaxForm.t1s8f13;
                t1s8f14.Value = vmTaxForm.t1s8f14;
                t1s8f15.Value = vmTaxForm.t1s8f15;
                t1s8f16.Value = vmTaxForm.t1s8f16;
                t1s8f17.Value = vmTaxForm.t1s8f17;
                t1s8f18.Value = vmTaxForm.t1s8f18;
                t1s8f19.Value = vmTaxForm.t1s8f19;
                t1s8f20.Value = vmTaxForm.t1s8f20;
                t1s8f21.Value = vmTaxForm.t1s8f21;
                t1s8f22.Value = vmTaxForm.t1s8f22;
                t1s8f23.Value = vmTaxForm.t1s8f23;
                t1s8f24.Value = vmTaxForm.t1s8f24;
                t1s8f25.Value = vmTaxForm.t1s8f25;
                t1s8f26.Value = vmTaxForm.t1s8f26;
                t1s8f27.Value = vmTaxForm.t1s8f27;
                t1s8f28.Value = vmTaxForm.t1s8f28;
                t1s8f29.Value = vmTaxForm.t1s8f29;
                t1s8f30.Value = vmTaxForm.t1s8f30;
                t1s8f31.Value = vmTaxForm.t1s8f31;
                t1s8f32.Checked = Convert.ToBoolean(vmTaxForm.t1s8f32);
                t1s8f33.Value = vmTaxForm.t1s8f33;
                t1s8f34.Text = vmTaxForm.t1s8f34;
                t1s8f35.Value = vmTaxForm.t1s8f35;
                t1s8f36.Text = vmTaxForm.t1s8f36;
                t1s8f37.Value = vmTaxForm.t1s8f37;
                t1s8f38.Text = vmTaxForm.t1s8f38;
                t1s8f39.Value = vmTaxForm.t1s8f39;
                t1s8f40.Text = vmTaxForm.t1s8f40;
                t1s8f41.Value = vmTaxForm.t1s8f41;
                t1s8f42.Text = vmTaxForm.t1s8f42;
                t1s8f43.Text = vmTaxForm.t1s8f43;
                //finish-form1-8====================

                

                //start-form2-5=====================
                ren_netamountcurrency.Value = vmTaxForm.ren_netamountcurrency;
                ren_netamountrp.Value = vmTaxForm.ren_netamountrp;
                ren_nettaxpaidcurrency.Value = vmTaxForm.ren_nettaxpaidcurrency;
                ren_nettaxpaidexchrate.Value = vmTaxForm.ren_nettaxpaidexchrate;
                ren_nettaxpaidamountrp.Value = vmTaxForm.ren_nettaxpaidamountrp;
                //finish-form2-5====================

                //start-form2-6=====================
                if (!string.IsNullOrEmpty(vmTaxForm.irregulartaxcredit))
                {
                    irregulartaxcredit.Text = vmTaxForm.irregulartaxcredit.ToString().Split('.')[0];
                }
                //finish-form2-6====================

                //start-form3-8=====================
                tab3nettotalasset.Value = vmTaxForm.tab3nettotalasset;
                tab3nettotalliabilities.Value = vmTaxForm.tab3nettotalliabilities;
                tab3netasset.Value = vmTaxForm.tab3netasset;
                //finish-form3-8====================

            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        protected void LBBreadcrumb_Click(object sender, EventArgs e)
        {
            try
            {
                taxFormID = int.Parse(Request.QueryString["id"]);
                Response.Redirect("~/" + Session["taxform-taxform"].ToString() + ".aspx?id=" + taxFormID);
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        protected void lbForm_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/taxform.aspx?id=" + hdTaxPlayerNumber.Value);
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

    }
}