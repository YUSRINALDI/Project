using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Repository;
using vm = DelloiteTRLib.Model;
using dc = DelloiteTRLib.DataContext;
using System.Security.Cryptography;

namespace DelloiteTRLib.Services
{
    public class TaxFormServices
    {
        private TaxFormRepository _repository;

        public TaxFormServices(TaxFormRepository repository)
        {
            _repository = repository;
        }


        public List<vm.TaxForm> GetAll()
        {

            List<vm.TaxForm> vmTaxForms = new List<vm.TaxForm>();
            IEnumerable<dc.TaxForm> taxForms = null;
            try
            {
                taxForms = _repository.FindAll();
                if (taxForms != null)
                {

                    foreach (dc.TaxForm taxForm in taxForms)
                    {
                        vm.TaxForm vmTaxForm = new vm.TaxForm();
                        vmTaxForm.id = taxForm.id;
                        vmTaxForm.TaxPayerNumber = taxForm.TaxPlayerDetail.TaxPayerNumber;
                        vmTaxForm.ammend = taxForm.ammend;
                        vmTaxForm.status = taxForm.status;
                        vmTaxForm.taxidnumber = taxForm.taxidnumber;
                        vmTaxForm.type = taxForm.type;
                        vmTaxForm.year = taxForm.year;

                        vmTaxForm.t1s1f2 = taxForm.t1s1f2;
                        vmTaxForm.t1s1f4 = taxForm.t1s1f4;
                        vmTaxForm.t1s1f5 = taxForm.t1s1f5;
                        vmTaxForm.t1s1f6 = taxForm.t1s1f6;
                        vmTaxForm.t1s1f7 = taxForm.t1s1f7;
                        vmTaxForm.t1s1f8 = taxForm.t1s1f8;
                        vmTaxForm.t1s2f1 = taxForm.t1s2f1;
                        vmTaxForm.t1s2f2 = taxForm.t1s2f2;
                        vmTaxForm.t1s2f3 = taxForm.t1s2f3;
                        vmTaxForm.t1s2f4 = taxForm.t1s2f4;
                        vmTaxForm.t1s2f5 = taxForm.t1s2f5;
                        vmTaxForm.t1s2f6 = taxForm.t1s2f6;
                        vmTaxForm.t1s2f7 = taxForm.t1s2f7;
                        vmTaxForm.t1s2f8 = taxForm.t1s2f8;
                        vmTaxForm.t1s2f9 = taxForm.t1s2f9;
                        vmTaxForm.t1s2f10 = taxForm.t1s2f10;
                        vmTaxForm.t1s2f11 = taxForm.t1s2f11;
                        vmTaxForm.t1s2f12 = taxForm.t1s2f12;
                        vmTaxForm.t1s2f13 = taxForm.t1s2f13;
                        vmTaxForm.t1s2f14 = taxForm.t1s2f14;
                        vmTaxForm.t1s2f15 = taxForm.t1s2f15;
                        vmTaxForm.t1s2f16 = taxForm.t1s2f16;
                        vmTaxForm.t1s2f17 = taxForm.t1s2f17;
                        vmTaxForm.t1s2f18 = taxForm.t1s2f18;
                        vmTaxForm.t1s2f19 = taxForm.t1s2f19;
                        vmTaxForm.t1s2f20 = taxForm.t1s2f20;
                        vmTaxForm.t1s2f21 = taxForm.t1s2f21;
                        vmTaxForm.t1s2f22 = taxForm.t1s2f22;
                        vmTaxForm.t1s2f23 = taxForm.t1s2f23;
                        vmTaxForm.t1s2f24 = taxForm.t1s2f24;
                        vmTaxForm.t1s3f1 = taxForm.t1s3f1;
                        vmTaxForm.t1s3f2 = taxForm.t1s3f2;
                        vmTaxForm.t1s3f3 = taxForm.t1s3f3;
                        vmTaxForm.t1s4f1 = taxForm.t1s4f1;
                        vmTaxForm.t1s4f2 = taxForm.t1s4f2;
                        vmTaxForm.t1s4f3 = taxForm.t1s4f3;
                        vmTaxForm.t1s4f4 = taxForm.t1s4f4;
                        vmTaxForm.t1s4f5 = taxForm.t1s4f5;
                        vmTaxForm.t1s4f6 = taxForm.t1s4f6;
                        vmTaxForm.t1s4f7 = taxForm.t1s4f7;
                        vmTaxForm.t1s4f8 = taxForm.t1s4f8;
                        vmTaxForm.t1s4f9 = taxForm.t1s4f9;
                        vmTaxForm.t1s4f10 = taxForm.t1s4f10;
                        vmTaxForm.t1s4f11 = taxForm.t1s4f11;
                        vmTaxForm.t1s4f12 = taxForm.t1s4f12;
                        vmTaxForm.t1s4f13 = taxForm.t1s4f13;
                        vmTaxForm.t1s4f14 = taxForm.t1s4f14;
                        vmTaxForm.t1s4f15 = taxForm.t1s4f15;
                        vmTaxForm.t1s4f16 = taxForm.t1s4f16;
                        vmTaxForm.t1s4f17 = taxForm.t1s4f17;
                        vmTaxForm.t1s4f18 = taxForm.t1s4f18;
                        vmTaxForm.t1s4f19 = taxForm.t1s4f19;
                        vmTaxForm.t1s4f20 = taxForm.t1s4f20;
                        vmTaxForm.t1s4f21 = taxForm.t1s4f21;
                        vmTaxForm.t1s4f22 = taxForm.t1s4f22;
                        vmTaxForm.t1s4f23 = taxForm.t1s4f23;
                        vmTaxForm.t1s4f24 = taxForm.t1s4f24;
                        vmTaxForm.t1s4f25 = taxForm.t1s4f25;
                        vmTaxForm.t1s4f26 = taxForm.t1s4f26;
                        vmTaxForm.t1s4f27 = taxForm.t1s4f27;
                        vmTaxForm.t1s4f28 = taxForm.t1s4f28;
                        vmTaxForm.t1s4f29 = taxForm.t1s4f29;
                        vmTaxForm.t1s4f30 = taxForm.t1s4f30;
                        vmTaxForm.t1s4f31 = taxForm.t1s4f31;
                        vmTaxForm.t1s4f32 = taxForm.t1s4f32;
                        vmTaxForm.t1s4f33 = taxForm.t1s4f33;
                        vmTaxForm.t1s4f34 = taxForm.t1s4f34;
                        vmTaxForm.t1s4f35 = taxForm.t1s4f35;
                        vmTaxForm.t1s4f36 = taxForm.t1s4f36;
                        vmTaxForm.t1s4f37 = taxForm.t1s4f37;
                        vmTaxForm.t1s4f38 = taxForm.t1s4f38;
                        vmTaxForm.t1s4f39 = taxForm.t1s4f39;
                        vmTaxForm.t1s4f40 = taxForm.t1s4f40;
                        vmTaxForm.t1s4f41 = taxForm.t1s4f41;
                        vmTaxForm.t1s4f42 = taxForm.t1s4f42;
                        vmTaxForm.t1s4f43 = taxForm.t1s4f43;
                        vmTaxForm.t1s4f44 = taxForm.t1s4f44;
                        vmTaxForm.t1s4f45 = taxForm.t1s4f45;
                        vmTaxForm.t1s4f46 = taxForm.t1s4f46;
                        vmTaxForm.t1s4f47 = taxForm.t1s4f47;
                        vmTaxForm.t1s4f48 = taxForm.t1s4f48;
                        vmTaxForm.t1s4f49 = taxForm.t1s4f49;
                        vmTaxForm.t1s4f50 = taxForm.t1s4f50;
                        vmTaxForm.t1s4f51 = taxForm.t1s4f51;
                        vmTaxForm.t1s4f52 = taxForm.t1s4f52;
                        vmTaxForm.t1s4f53 = taxForm.t1s4f53;
                        vmTaxForm.t1s4f54 = taxForm.t1s4f54;
                        vmTaxForm.t1s4f55 = taxForm.t1s4f55;
                        vmTaxForm.t1s6f1 = taxForm.t1s6f1;
                        vmTaxForm.t1s6f2 = taxForm.t1s6f2;
                        vmTaxForm.t1s6f3 = taxForm.t1s6f3;
                        vmTaxForm.t1s6f4 = taxForm.t1s6f4;
                        vmTaxForm.t1s6f5 = taxForm.t1s6f5;
                        vmTaxForm.t1s6f6 = taxForm.t1s6f6;
                        vmTaxForm.t1s6f7 = taxForm.t1s6f7;
                        vmTaxForm.t1s6f8 = taxForm.t1s6f8;
                        vmTaxForm.t1s6f9 = taxForm.t1s6f9;
                        vmTaxForm.t1s6f10 = taxForm.t1s6f10;
                        vmTaxForm.t1s6f11 = taxForm.t1s6f11;
                        vmTaxForm.t1s6f12 = taxForm.t1s6f12;
                        vmTaxForm.t1s6f13 = taxForm.t1s6f13;
                        vmTaxForm.t1s6f14 = taxForm.t1s6f14;
                        vmTaxForm.t1s6f15 = taxForm.t1s6f15;
                        vmTaxForm.t1s6f16 = taxForm.t1s6f16;
                        vmTaxForm.t1s6f17 = taxForm.t1s6f17;
                        vmTaxForm.t1s6f18 = taxForm.t1s6f18;
                        vmTaxForm.t1s6f19 = taxForm.t1s6f19;
                        vmTaxForm.t1s6f20 = taxForm.t1s6f20;
                        vmTaxForm.t1s6f21 = taxForm.t1s6f21;
                        vmTaxForm.t1s6f22 = taxForm.t1s6f22;
                        vmTaxForm.t1s6f23 = taxForm.t1s6f23;
                        vmTaxForm.t1s6f24 = taxForm.t1s6f24;
                        vmTaxForm.t1s6f25 = taxForm.t1s6f25;
                        vmTaxForm.t1s7f1 = taxForm.t1s7f1;
                        vmTaxForm.t1s7f2 = taxForm.t1s7f2;
                        vmTaxForm.t1s7f3 = taxForm.t1s7f3;
                        vmTaxForm.t1s7f4 = taxForm.t1s7f4;
                        vmTaxForm.t1s7f5 = taxForm.t1s7f5;
                        vmTaxForm.t1s7f6 = taxForm.t1s7f6;
                        vmTaxForm.t1s7f7 = taxForm.t1s7f7;
                        vmTaxForm.t1s7f8 = taxForm.t1s7f8;
                        vmTaxForm.t1s7f9 = taxForm.t1s7f9;
                        vmTaxForm.t1s7f10 = taxForm.t1s7f10;
                        vmTaxForm.t1s7f11 = taxForm.t1s7f11;
                        vmTaxForm.t1s7f12 = taxForm.t1s7f12;
                        vmTaxForm.t1s7f13 = taxForm.t1s7f13;
                        vmTaxForm.t1s7f14 = taxForm.t1s7f14;
                        vmTaxForm.t1s7f15 = taxForm.t1s7f15;
                        vmTaxForm.t1s7f16 = taxForm.t1s7f16;
                        vmTaxForm.t1s7f17 = taxForm.t1s7f17;
                        vmTaxForm.t1s7f18 = taxForm.t1s7f18;
                        vmTaxForm.t1s7f19 = taxForm.t1s7f19;
                        vmTaxForm.t1s7f20 = taxForm.t1s7f20;
                        vmTaxForm.t1s7f21 = taxForm.t1s7f21;
                        vmTaxForm.t1s7f22 = taxForm.t1s7f22;
                        vmTaxForm.t1s7f23 = taxForm.t1s7f23;
                        vmTaxForm.t1s7f24 = taxForm.t1s7f24;
                        vmTaxForm.t1s7f25 = taxForm.t1s7f25;
                        vmTaxForm.t1s7f26 = taxForm.t1s7f26;
                        vmTaxForm.t1s7f27 = taxForm.t1s7f27;
                        vmTaxForm.t1s7f28 = taxForm.t1s7f28;
                        vmTaxForm.t1s7f29 = taxForm.t1s7f29;
                        vmTaxForm.t1s7f30 = taxForm.t1s7f30;
                        vmTaxForm.t1s7f31 = taxForm.t1s7f31;
                        vmTaxForm.t1s7f32 = taxForm.t1s7f32;
                        vmTaxForm.t1s7f33 = taxForm.t1s7f33;
                        vmTaxForm.t1s7f34 = taxForm.t1s7f34;
                        vmTaxForm.t1s7f35 = taxForm.t1s7f35;
                        vmTaxForm.t1s7f36 = taxForm.t1s7f36;
                        vmTaxForm.t1s7f37 = taxForm.t1s7f37;
                        vmTaxForm.t1s7f38 = taxForm.t1s7f38;
                        vmTaxForm.t1s7f39 = taxForm.t1s7f39;
                        vmTaxForm.t1s8f1 = taxForm.t1s8f1;
                        vmTaxForm.t1s8f2 = taxForm.t1s8f2;
                        vmTaxForm.t1s8f3 = taxForm.t1s8f3;
                        vmTaxForm.t1s8f4 = taxForm.t1s8f4;
                        vmTaxForm.t1s8f5 = taxForm.t1s8f5;
                        vmTaxForm.t1s8f6 = taxForm.t1s8f6;
                        vmTaxForm.t1s8f7 = taxForm.t1s8f7;
                        vmTaxForm.t1s8f8 = taxForm.t1s8f8;
                        vmTaxForm.t1s8f9 = taxForm.t1s8f9;
                        vmTaxForm.t1s8f10 = taxForm.t1s8f10;
                        vmTaxForm.t1s8f11 = taxForm.t1s8f11;
                        vmTaxForm.t1s8f12 = taxForm.t1s8f12;
                        vmTaxForm.t1s8f13 = taxForm.t1s8f13;
                        vmTaxForm.t1s8f14 = taxForm.t1s8f14;
                        vmTaxForm.t1s8f15 = taxForm.t1s8f15;
                        vmTaxForm.t1s8f16 = taxForm.t1s8f16;
                        vmTaxForm.t1s8f17 = taxForm.t1s8f17;
                        vmTaxForm.t1s8f18 = taxForm.t1s8f18;
                        vmTaxForm.t1s8f19 = taxForm.t1s8f19;
                        vmTaxForm.t1s8f20 = taxForm.t1s8f20;
                        vmTaxForm.t1s8f21 = taxForm.t1s8f21;
                        vmTaxForm.t1s8f22 = taxForm.t1s8f22;
                        vmTaxForm.t1s8f23 = taxForm.t1s8f23;
                        vmTaxForm.t1s8f24 = taxForm.t1s8f24;
                        vmTaxForm.t1s8f25 = taxForm.t1s8f25;
                        vmTaxForm.t1s8f26 = taxForm.t1s8f26;
                        vmTaxForm.t1s8f27 = taxForm.t1s8f27;
                        vmTaxForm.t1s8f28 = taxForm.t1s8f28;
                        vmTaxForm.t1s8f29 = taxForm.t1s8f29;
                        vmTaxForm.t1s8f30 = taxForm.t1s8f30;
                        vmTaxForm.t1s8f31 = taxForm.t1s8f31;
                        vmTaxForm.t1s8f32 = taxForm.t1s8f32;
                        vmTaxForm.t1s8f33 = taxForm.t1s8f33;
                        vmTaxForm.t1s8f34 = taxForm.t1s8f34;
                        vmTaxForm.t1s8f35 = taxForm.t1s8f35;
                        vmTaxForm.t1s8f36 = taxForm.t1s8f36;
                        vmTaxForm.t1s8f37 = taxForm.t1s8f37;
                        vmTaxForm.t1s8f38 = taxForm.t1s8f38;
                        vmTaxForm.t1s8f39 = taxForm.t1s8f39;
                        vmTaxForm.t1s8f40 = taxForm.t1s8f40;
                        vmTaxForm.t1s8f41 = taxForm.t1s8f41;
                        vmTaxForm.t1s8f42 = taxForm.t1s8f42;
                        vmTaxForm.t1s8f43 = taxForm.t1s8f43;

                        vmTaxForm.totalemployee = taxForm.totalemployee;
                        vmTaxForm.totalperiod = taxForm.totalperiod;
                        vmTaxForm.totalsalaries = taxForm.totalsalaries;
                        vmTaxForm.totalincome = taxForm.totalincome;
                        vmTaxForm.totalother = taxForm.totalother;
                        vmTaxForm.totalhonorarium = taxForm.totalhonorarium;
                        vmTaxForm.totalinsurance = taxForm.totalinsurance;
                        vmTaxForm.totalbenefit = taxForm.totalbenefit;
                        vmTaxForm.totalbonus = taxForm.totalbonus;
                        vmTaxForm.totalgross = taxForm.totalgross;
                        vmTaxForm.totalcost = taxForm.totalcost;
                        vmTaxForm.totalpension = taxForm.totalpension;
                        vmTaxForm.totaldeductions = taxForm.totaldeductions;
                        vmTaxForm.totalnetincome = taxForm.totalnetincome;
                        vmTaxForm.totalincometax = taxForm.totalincometax;
                        vmTaxForm.totalprevnetincome = taxForm.totalprevnetincome;
                        vmTaxForm.totalprevincometax = taxForm.totalprevincometax;
                        vmTaxForm.total1 = taxForm.total1;
                        vmTaxForm.total2 = taxForm.total2;
                        vmTaxForm.total3 = taxForm.total3;
                        vmTaxForm.total4 = taxForm.total4;
                        vmTaxForm.total5 = taxForm.total5;
                        vmTaxForm.total6 = taxForm.total6;
                        vmTaxForm.total7 = taxForm.total7;
                        vmTaxForm.total8 = taxForm.total8;
                        vmTaxForm.total9 = taxForm.total9;
                        vmTaxForm.total10 = taxForm.total10;
                        vmTaxForm.total11 = taxForm.total11;
                        vmTaxForm.total12 = taxForm.total12;
                        vmTaxForm.total13 = taxForm.total13;
                        vmTaxForm.total14 = taxForm.total14;
                        vmTaxForm.total15 = taxForm.total15;
                        vmTaxForm.total16 = taxForm.total16;
                        vmTaxForm.total17 = taxForm.total17;
                        vmTaxForm.total18 = taxForm.total18;
                        vmTaxForm.total19 = taxForm.total19;
                        vmTaxForm.total20 = taxForm.total20;
                        vmTaxForm.total21 = taxForm.total21;
                        vmTaxForm.total22 = taxForm.total22;
                        vmTaxForm.total23 = taxForm.total23;
                        vmTaxForm.total24 = taxForm.total24;
                        vmTaxForm.total25 = taxForm.total25;
                        vmTaxForm.total26 = taxForm.total26;
                        vmTaxForm.ren_netamountcurrency = taxForm.ren_netamountcurrency;
                        vmTaxForm.ren_netamountrp = taxForm.ren_netamountrp;
                        vmTaxForm.ren_nettaxpaidcurrency = taxForm.ren_nettaxpaidcurrency;
                        vmTaxForm.ren_nettaxpaidexchrate = taxForm.ren_nettaxpaidexchrate;
                        vmTaxForm.ren_nettaxpaidamountrp = taxForm.ren_nettaxpaidamountrp;
                        vmTaxForm.tabirregulartotal1 = taxForm.tabirregulartotal1;
                        vmTaxForm.tabirregulartotal2 = taxForm.tabirregulartotal2;
                        vmTaxForm.irregulartaxcredit = taxForm.irregulartaxcredit;
                        vmTaxForm.lbltotalsummary1 = taxForm.lbltotalsummary1;
                        vmTaxForm.lbltotalsummary2 = taxForm.lbltotalsummary2;
                        vmTaxForm.tabasset1 = taxForm.tabasset1;
                        vmTaxForm.tabasset2 = taxForm.tabasset2;
                        vmTaxForm.tabasset3 = taxForm.tabasset3;
                        vmTaxForm.tabasset4 = taxForm.tabasset4;
                        vmTaxForm.tabasset5 = taxForm.tabasset5;
                        vmTaxForm.tabasset6 = taxForm.tabasset6;
                        vmTaxForm.tabasset10 = taxForm.tabasset10;
                        vmTaxForm.tab3nettotalasset = taxForm.tab3nettotalasset;
                        vmTaxForm.tab3nettotalliabilities = taxForm.tab3nettotalliabilities;
                        vmTaxForm.tab3netasset = taxForm.tab3netasset;

                        vmTaxForm.createdby = taxForm.createdby;
                        vmTaxForm.createddate = taxForm.createddate;
                        vmTaxForm.updatedby = taxForm.updatedby;
                        vmTaxForm.updateddate = taxForm.updateddate;

                        vmTaxForms.Add(vmTaxForm);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmTaxForms;
        }

        public List<vm.TaxForm> GetAllBy(string taxidnumber, string type, string year, int status)
        {
            List<vm.TaxForm> vmTaxForms = new List<vm.TaxForm>();
            IEnumerable<dc.TaxForm> taxForms = null;

            try
            {
                taxForms = _repository.FindAllBy(taxidnumber, type, year, status);

                if (taxForms != null)
                {
                    foreach (dc.TaxForm taxForm in taxForms)
                    {
                        vm.TaxForm vmTaxForm = new vm.TaxForm();
                        vmTaxForm.id = taxForm.id;
                        vmTaxForm.TaxPayerNumber = taxForm.TaxPlayerDetail.TaxPayerNumber;
                        vmTaxForm.ammend = taxForm.ammend;
                        vmTaxForm.status = taxForm.status;
                        vmTaxForm.taxidnumber = taxForm.taxidnumber;
                        vmTaxForm.type = taxForm.type;
                        vmTaxForm.year = taxForm.year;

                        vmTaxForm.t1s1f2 = taxForm.t1s1f2;
                        vmTaxForm.t1s1f4 = taxForm.t1s1f4;
                        vmTaxForm.t1s1f5 = taxForm.t1s1f5;
                        vmTaxForm.t1s1f6 = taxForm.t1s1f6;
                        vmTaxForm.t1s1f7 = taxForm.t1s1f7;
                        vmTaxForm.t1s1f8 = taxForm.t1s1f8;
                        vmTaxForm.t1s2f1 = taxForm.t1s2f1;
                        vmTaxForm.t1s2f2 = taxForm.t1s2f2;
                        vmTaxForm.t1s2f3 = taxForm.t1s2f3;
                        vmTaxForm.t1s2f4 = taxForm.t1s2f4;
                        vmTaxForm.t1s2f5 = taxForm.t1s2f5;
                        vmTaxForm.t1s2f6 = taxForm.t1s2f6;
                        vmTaxForm.t1s2f7 = taxForm.t1s2f7;
                        vmTaxForm.t1s2f8 = taxForm.t1s2f8;
                        vmTaxForm.t1s2f9 = taxForm.t1s2f9;
                        vmTaxForm.t1s2f10 = taxForm.t1s2f10;
                        vmTaxForm.t1s2f11 = taxForm.t1s2f11;
                        vmTaxForm.t1s2f12 = taxForm.t1s2f12;
                        vmTaxForm.t1s2f13 = taxForm.t1s2f13;
                        vmTaxForm.t1s2f14 = taxForm.t1s2f14;
                        vmTaxForm.t1s2f15 = taxForm.t1s2f15;
                        vmTaxForm.t1s2f16 = taxForm.t1s2f16;
                        vmTaxForm.t1s2f17 = taxForm.t1s2f17;
                        vmTaxForm.t1s2f18 = taxForm.t1s2f18;
                        vmTaxForm.t1s2f19 = taxForm.t1s2f19;
                        vmTaxForm.t1s2f20 = taxForm.t1s2f20;
                        vmTaxForm.t1s2f21 = taxForm.t1s2f21;
                        vmTaxForm.t1s2f22 = taxForm.t1s2f22;
                        vmTaxForm.t1s2f23 = taxForm.t1s2f23;
                        vmTaxForm.t1s2f24 = taxForm.t1s2f24;
                        vmTaxForm.t1s3f1 = taxForm.t1s3f1;
                        vmTaxForm.t1s3f2 = taxForm.t1s3f2;
                        vmTaxForm.t1s3f3 = taxForm.t1s3f3;
                        vmTaxForm.t1s4f1 = taxForm.t1s4f1;
                        vmTaxForm.t1s4f2 = taxForm.t1s4f2;
                        vmTaxForm.t1s4f3 = taxForm.t1s4f3;
                        vmTaxForm.t1s4f4 = taxForm.t1s4f4;
                        vmTaxForm.t1s4f5 = taxForm.t1s4f5;
                        vmTaxForm.t1s4f6 = taxForm.t1s4f6;
                        vmTaxForm.t1s4f7 = taxForm.t1s4f7;
                        vmTaxForm.t1s4f8 = taxForm.t1s4f8;
                        vmTaxForm.t1s4f9 = taxForm.t1s4f9;
                        vmTaxForm.t1s4f10 = taxForm.t1s4f10;
                        vmTaxForm.t1s4f11 = taxForm.t1s4f11;
                        vmTaxForm.t1s4f12 = taxForm.t1s4f12;
                        vmTaxForm.t1s4f13 = taxForm.t1s4f13;
                        vmTaxForm.t1s4f14 = taxForm.t1s4f14;
                        vmTaxForm.t1s4f15 = taxForm.t1s4f15;
                        vmTaxForm.t1s4f16 = taxForm.t1s4f16;
                        vmTaxForm.t1s4f17 = taxForm.t1s4f17;
                        vmTaxForm.t1s4f18 = taxForm.t1s4f18;
                        vmTaxForm.t1s4f19 = taxForm.t1s4f19;
                        vmTaxForm.t1s4f20 = taxForm.t1s4f20;
                        vmTaxForm.t1s4f21 = taxForm.t1s4f21;
                        vmTaxForm.t1s4f22 = taxForm.t1s4f22;
                        vmTaxForm.t1s4f23 = taxForm.t1s4f23;
                        vmTaxForm.t1s4f24 = taxForm.t1s4f24;
                        vmTaxForm.t1s4f25 = taxForm.t1s4f25;
                        vmTaxForm.t1s4f26 = taxForm.t1s4f26;
                        vmTaxForm.t1s4f27 = taxForm.t1s4f27;
                        vmTaxForm.t1s4f28 = taxForm.t1s4f28;
                        vmTaxForm.t1s4f29 = taxForm.t1s4f29;
                        vmTaxForm.t1s4f30 = taxForm.t1s4f30;
                        vmTaxForm.t1s4f31 = taxForm.t1s4f31;
                        vmTaxForm.t1s4f32 = taxForm.t1s4f32;
                        vmTaxForm.t1s4f33 = taxForm.t1s4f33;
                        vmTaxForm.t1s4f34 = taxForm.t1s4f34;
                        vmTaxForm.t1s4f35 = taxForm.t1s4f35;
                        vmTaxForm.t1s4f36 = taxForm.t1s4f36;
                        vmTaxForm.t1s4f37 = taxForm.t1s4f37;
                        vmTaxForm.t1s4f38 = taxForm.t1s4f38;
                        vmTaxForm.t1s4f39 = taxForm.t1s4f39;
                        vmTaxForm.t1s4f40 = taxForm.t1s4f40;
                        vmTaxForm.t1s4f41 = taxForm.t1s4f41;
                        vmTaxForm.t1s4f42 = taxForm.t1s4f42;
                        vmTaxForm.t1s4f43 = taxForm.t1s4f43;
                        vmTaxForm.t1s4f44 = taxForm.t1s4f44;
                        vmTaxForm.t1s4f45 = taxForm.t1s4f45;
                        vmTaxForm.t1s4f46 = taxForm.t1s4f46;
                        vmTaxForm.t1s4f47 = taxForm.t1s4f47;
                        vmTaxForm.t1s4f48 = taxForm.t1s4f48;
                        vmTaxForm.t1s4f49 = taxForm.t1s4f49;
                        vmTaxForm.t1s4f50 = taxForm.t1s4f50;
                        vmTaxForm.t1s4f51 = taxForm.t1s4f51;
                        vmTaxForm.t1s4f52 = taxForm.t1s4f52;
                        vmTaxForm.t1s4f53 = taxForm.t1s4f53;
                        vmTaxForm.t1s4f54 = taxForm.t1s4f54;
                        vmTaxForm.t1s4f55 = taxForm.t1s4f55;
                        vmTaxForm.t1s6f1 = taxForm.t1s6f1;
                        vmTaxForm.t1s6f2 = taxForm.t1s6f2;
                        vmTaxForm.t1s6f3 = taxForm.t1s6f3;
                        vmTaxForm.t1s6f4 = taxForm.t1s6f4;
                        vmTaxForm.t1s6f5 = taxForm.t1s6f5;
                        vmTaxForm.t1s6f6 = taxForm.t1s6f6;
                        vmTaxForm.t1s6f7 = taxForm.t1s6f7;
                        vmTaxForm.t1s6f8 = taxForm.t1s6f8;
                        vmTaxForm.t1s6f9 = taxForm.t1s6f9;
                        vmTaxForm.t1s6f10 = taxForm.t1s6f10;
                        vmTaxForm.t1s6f11 = taxForm.t1s6f11;
                        vmTaxForm.t1s6f12 = taxForm.t1s6f12;
                        vmTaxForm.t1s6f13 = taxForm.t1s6f13;
                        vmTaxForm.t1s6f14 = taxForm.t1s6f14;
                        vmTaxForm.t1s6f15 = taxForm.t1s6f15;
                        vmTaxForm.t1s6f16 = taxForm.t1s6f16;
                        vmTaxForm.t1s6f17 = taxForm.t1s6f17;
                        vmTaxForm.t1s6f18 = taxForm.t1s6f18;
                        vmTaxForm.t1s6f19 = taxForm.t1s6f19;
                        vmTaxForm.t1s6f20 = taxForm.t1s6f20;
                        vmTaxForm.t1s6f21 = taxForm.t1s6f21;
                        vmTaxForm.t1s6f22 = taxForm.t1s6f22;
                        vmTaxForm.t1s6f23 = taxForm.t1s6f23;
                        vmTaxForm.t1s6f24 = taxForm.t1s6f24;
                        vmTaxForm.t1s6f25 = taxForm.t1s6f25;
                        vmTaxForm.t1s7f1 = taxForm.t1s7f1;
                        vmTaxForm.t1s7f2 = taxForm.t1s7f2;
                        vmTaxForm.t1s7f3 = taxForm.t1s7f3;
                        vmTaxForm.t1s7f4 = taxForm.t1s7f4;
                        vmTaxForm.t1s7f5 = taxForm.t1s7f5;
                        vmTaxForm.t1s7f6 = taxForm.t1s7f6;
                        vmTaxForm.t1s7f7 = taxForm.t1s7f7;
                        vmTaxForm.t1s7f8 = taxForm.t1s7f8;
                        vmTaxForm.t1s7f9 = taxForm.t1s7f9;
                        vmTaxForm.t1s7f10 = taxForm.t1s7f10;
                        vmTaxForm.t1s7f11 = taxForm.t1s7f11;
                        vmTaxForm.t1s7f12 = taxForm.t1s7f12;
                        vmTaxForm.t1s7f13 = taxForm.t1s7f13;
                        vmTaxForm.t1s7f14 = taxForm.t1s7f14;
                        vmTaxForm.t1s7f15 = taxForm.t1s7f15;
                        vmTaxForm.t1s7f16 = taxForm.t1s7f16;
                        vmTaxForm.t1s7f17 = taxForm.t1s7f17;
                        vmTaxForm.t1s7f18 = taxForm.t1s7f18;
                        vmTaxForm.t1s7f19 = taxForm.t1s7f19;
                        vmTaxForm.t1s7f20 = taxForm.t1s7f20;
                        vmTaxForm.t1s7f21 = taxForm.t1s7f21;
                        vmTaxForm.t1s7f22 = taxForm.t1s7f22;
                        vmTaxForm.t1s7f23 = taxForm.t1s7f23;
                        vmTaxForm.t1s7f24 = taxForm.t1s7f24;
                        vmTaxForm.t1s7f25 = taxForm.t1s7f25;
                        vmTaxForm.t1s7f26 = taxForm.t1s7f26;
                        vmTaxForm.t1s7f27 = taxForm.t1s7f27;
                        vmTaxForm.t1s7f28 = taxForm.t1s7f28;
                        vmTaxForm.t1s7f29 = taxForm.t1s7f29;
                        vmTaxForm.t1s7f30 = taxForm.t1s7f30;
                        vmTaxForm.t1s7f31 = taxForm.t1s7f31;
                        vmTaxForm.t1s7f32 = taxForm.t1s7f32;
                        vmTaxForm.t1s7f33 = taxForm.t1s7f33;
                        vmTaxForm.t1s7f34 = taxForm.t1s7f34;
                        vmTaxForm.t1s7f35 = taxForm.t1s7f35;
                        vmTaxForm.t1s7f36 = taxForm.t1s7f36;
                        vmTaxForm.t1s7f37 = taxForm.t1s7f37;
                        vmTaxForm.t1s7f38 = taxForm.t1s7f38;
                        vmTaxForm.t1s7f39 = taxForm.t1s7f39;
                        vmTaxForm.t1s8f1 = taxForm.t1s8f1;
                        vmTaxForm.t1s8f2 = taxForm.t1s8f2;
                        vmTaxForm.t1s8f3 = taxForm.t1s8f3;
                        vmTaxForm.t1s8f4 = taxForm.t1s8f4;
                        vmTaxForm.t1s8f5 = taxForm.t1s8f5;
                        vmTaxForm.t1s8f6 = taxForm.t1s8f6;
                        vmTaxForm.t1s8f7 = taxForm.t1s8f7;
                        vmTaxForm.t1s8f8 = taxForm.t1s8f8;
                        vmTaxForm.t1s8f9 = taxForm.t1s8f9;
                        vmTaxForm.t1s8f10 = taxForm.t1s8f10;
                        vmTaxForm.t1s8f11 = taxForm.t1s8f11;
                        vmTaxForm.t1s8f12 = taxForm.t1s8f12;
                        vmTaxForm.t1s8f13 = taxForm.t1s8f13;
                        vmTaxForm.t1s8f14 = taxForm.t1s8f14;
                        vmTaxForm.t1s8f15 = taxForm.t1s8f15;
                        vmTaxForm.t1s8f16 = taxForm.t1s8f16;
                        vmTaxForm.t1s8f17 = taxForm.t1s8f17;
                        vmTaxForm.t1s8f18 = taxForm.t1s8f18;
                        vmTaxForm.t1s8f19 = taxForm.t1s8f19;
                        vmTaxForm.t1s8f20 = taxForm.t1s8f20;
                        vmTaxForm.t1s8f21 = taxForm.t1s8f21;
                        vmTaxForm.t1s8f22 = taxForm.t1s8f22;
                        vmTaxForm.t1s8f23 = taxForm.t1s8f23;
                        vmTaxForm.t1s8f24 = taxForm.t1s8f24;
                        vmTaxForm.t1s8f25 = taxForm.t1s8f25;
                        vmTaxForm.t1s8f26 = taxForm.t1s8f26;
                        vmTaxForm.t1s8f27 = taxForm.t1s8f27;
                        vmTaxForm.t1s8f28 = taxForm.t1s8f28;
                        vmTaxForm.t1s8f29 = taxForm.t1s8f29;
                        vmTaxForm.t1s8f30 = taxForm.t1s8f30;
                        vmTaxForm.t1s8f31 = taxForm.t1s8f31;
                        vmTaxForm.t1s8f32 = taxForm.t1s8f32;
                        vmTaxForm.t1s8f33 = taxForm.t1s8f33;
                        vmTaxForm.t1s8f34 = taxForm.t1s8f34;
                        vmTaxForm.t1s8f35 = taxForm.t1s8f35;
                        vmTaxForm.t1s8f36 = taxForm.t1s8f36;
                        vmTaxForm.t1s8f37 = taxForm.t1s8f37;
                        vmTaxForm.t1s8f38 = taxForm.t1s8f38;
                        vmTaxForm.t1s8f39 = taxForm.t1s8f39;
                        vmTaxForm.t1s8f40 = taxForm.t1s8f40;
                        vmTaxForm.t1s8f41 = taxForm.t1s8f41;
                        vmTaxForm.t1s8f42 = taxForm.t1s8f42;
                        vmTaxForm.t1s8f43 = taxForm.t1s8f43;

                        vmTaxForm.totalemployee = taxForm.totalemployee;
                        vmTaxForm.totalperiod = taxForm.totalperiod;
                        vmTaxForm.totalsalaries = taxForm.totalsalaries;
                        vmTaxForm.totalincome = taxForm.totalincome;
                        vmTaxForm.totalother = taxForm.totalother;
                        vmTaxForm.totalhonorarium = taxForm.totalhonorarium;
                        vmTaxForm.totalinsurance = taxForm.totalinsurance;
                        vmTaxForm.totalbenefit = taxForm.totalbenefit;
                        vmTaxForm.totalbonus = taxForm.totalbonus;
                        vmTaxForm.totalgross = taxForm.totalgross;
                        vmTaxForm.totalcost = taxForm.totalcost;
                        vmTaxForm.totalpension = taxForm.totalpension;
                        vmTaxForm.totaldeductions = taxForm.totaldeductions;
                        vmTaxForm.totalnetincome = taxForm.totalnetincome;
                        vmTaxForm.totalincometax = taxForm.totalincometax;
                        vmTaxForm.totalprevnetincome = taxForm.totalprevnetincome;
                        vmTaxForm.totalprevincometax = taxForm.totalprevincometax;
                        vmTaxForm.total1 = taxForm.total1;
                        vmTaxForm.total2 = taxForm.total2;
                        vmTaxForm.total3 = taxForm.total3;
                        vmTaxForm.total4 = taxForm.total4;
                        vmTaxForm.total5 = taxForm.total5;
                        vmTaxForm.total6 = taxForm.total6;
                        vmTaxForm.total7 = taxForm.total7;
                        vmTaxForm.total8 = taxForm.total8;
                        vmTaxForm.total9 = taxForm.total9;
                        vmTaxForm.total10 = taxForm.total10;
                        vmTaxForm.total11 = taxForm.total11;
                        vmTaxForm.total12 = taxForm.total12;
                        vmTaxForm.total13 = taxForm.total13;
                        vmTaxForm.total14 = taxForm.total14;
                        vmTaxForm.total15 = taxForm.total15;
                        vmTaxForm.total16 = taxForm.total16;
                        vmTaxForm.total17 = taxForm.total17;
                        vmTaxForm.total18 = taxForm.total18;
                        vmTaxForm.total19 = taxForm.total19;
                        vmTaxForm.total20 = taxForm.total20;
                        vmTaxForm.total21 = taxForm.total21;
                        vmTaxForm.total22 = taxForm.total22;
                        vmTaxForm.total23 = taxForm.total23;
                        vmTaxForm.total24 = taxForm.total24;
                        vmTaxForm.total25 = taxForm.total25;
                        vmTaxForm.total26 = taxForm.total26;
                        vmTaxForm.ren_netamountcurrency = taxForm.ren_netamountcurrency;
                        vmTaxForm.ren_netamountrp = taxForm.ren_netamountrp;
                        vmTaxForm.ren_nettaxpaidcurrency = taxForm.ren_nettaxpaidcurrency;
                        vmTaxForm.ren_nettaxpaidexchrate = taxForm.ren_nettaxpaidexchrate;
                        vmTaxForm.ren_nettaxpaidamountrp = taxForm.ren_nettaxpaidamountrp;
                        vmTaxForm.tabirregulartotal1 = taxForm.tabirregulartotal1;
                        vmTaxForm.tabirregulartotal2 = taxForm.tabirregulartotal2;
                        vmTaxForm.irregulartaxcredit = taxForm.irregulartaxcredit;
                        vmTaxForm.lbltotalsummary1 = taxForm.lbltotalsummary1;
                        vmTaxForm.lbltotalsummary2 = taxForm.lbltotalsummary2;
                        vmTaxForm.tabasset1 = taxForm.tabasset1;
                        vmTaxForm.tabasset2 = taxForm.tabasset2;
                        vmTaxForm.tabasset3 = taxForm.tabasset3;
                        vmTaxForm.tabasset4 = taxForm.tabasset4;
                        vmTaxForm.tabasset5 = taxForm.tabasset5;
                        vmTaxForm.tabasset6 = taxForm.tabasset6;
                        vmTaxForm.tabasset10 = taxForm.tabasset10;
                        vmTaxForm.tab3nettotalasset = taxForm.tab3nettotalasset;
                        vmTaxForm.tab3nettotalliabilities = taxForm.tab3nettotalliabilities;
                        vmTaxForm.tab3netasset = taxForm.tab3netasset;

                        vmTaxForm.createdby = taxForm.createdby;
                        vmTaxForm.createddate = taxForm.createddate;
                        vmTaxForm.updatedby = taxForm.updatedby;
                        vmTaxForm.updateddate = taxForm.updateddate;

                        vmTaxForms.Add(vmTaxForm);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmTaxForms;
        }

        public List<vm.TaxForm> GetAllBy(string taxidnumber, string type, string year, int status, int id)
        {
            List<vm.TaxForm> vmTaxForms = new List<vm.TaxForm>();
            IEnumerable<dc.TaxForm> taxForms = null;

            try
            {
                taxForms = _repository.FindAllBy(taxidnumber, type, year, status, id);

                if (taxForms != null)
                {
                    foreach (dc.TaxForm taxForm in taxForms)
                    {
                        vm.TaxForm vmTaxForm = new vm.TaxForm();
                        vmTaxForm.id = taxForm.id;
                        vmTaxForm.TaxPayerNumber = taxForm.TaxPlayerDetail.TaxPayerNumber;
                        vmTaxForm.ammend = taxForm.ammend;
                        vmTaxForm.status = taxForm.status;
                        vmTaxForm.taxidnumber = taxForm.taxidnumber;
                        vmTaxForm.type = taxForm.type;
                        vmTaxForm.year = taxForm.year;

                        vmTaxForm.t1s1f2 = taxForm.t1s1f2;
                        vmTaxForm.t1s1f4 = taxForm.t1s1f4;
                        vmTaxForm.t1s1f5 = taxForm.t1s1f5;
                        vmTaxForm.t1s1f6 = taxForm.t1s1f6;
                        vmTaxForm.t1s1f7 = taxForm.t1s1f7;
                        vmTaxForm.t1s1f8 = taxForm.t1s1f8;
                        vmTaxForm.t1s2f1 = taxForm.t1s2f1;
                        vmTaxForm.t1s2f2 = taxForm.t1s2f2;
                        vmTaxForm.t1s2f3 = taxForm.t1s2f3;
                        vmTaxForm.t1s2f4 = taxForm.t1s2f4;
                        vmTaxForm.t1s2f5 = taxForm.t1s2f5;
                        vmTaxForm.t1s2f6 = taxForm.t1s2f6;
                        vmTaxForm.t1s2f7 = taxForm.t1s2f7;
                        vmTaxForm.t1s2f8 = taxForm.t1s2f8;
                        vmTaxForm.t1s2f9 = taxForm.t1s2f9;
                        vmTaxForm.t1s2f10 = taxForm.t1s2f10;
                        vmTaxForm.t1s2f11 = taxForm.t1s2f11;
                        vmTaxForm.t1s2f12 = taxForm.t1s2f12;
                        vmTaxForm.t1s2f13 = taxForm.t1s2f13;
                        vmTaxForm.t1s2f14 = taxForm.t1s2f14;
                        vmTaxForm.t1s2f15 = taxForm.t1s2f15;
                        vmTaxForm.t1s2f16 = taxForm.t1s2f16;
                        vmTaxForm.t1s2f17 = taxForm.t1s2f17;
                        vmTaxForm.t1s2f18 = taxForm.t1s2f18;
                        vmTaxForm.t1s2f19 = taxForm.t1s2f19;
                        vmTaxForm.t1s2f20 = taxForm.t1s2f20;
                        vmTaxForm.t1s2f21 = taxForm.t1s2f21;
                        vmTaxForm.t1s2f22 = taxForm.t1s2f22;
                        vmTaxForm.t1s2f23 = taxForm.t1s2f23;
                        vmTaxForm.t1s2f24 = taxForm.t1s2f24;
                        vmTaxForm.t1s3f1 = taxForm.t1s3f1;
                        vmTaxForm.t1s3f2 = taxForm.t1s3f2;
                        vmTaxForm.t1s3f3 = taxForm.t1s3f3;
                        vmTaxForm.t1s4f1 = taxForm.t1s4f1;
                        vmTaxForm.t1s4f2 = taxForm.t1s4f2;
                        vmTaxForm.t1s4f3 = taxForm.t1s4f3;
                        vmTaxForm.t1s4f4 = taxForm.t1s4f4;
                        vmTaxForm.t1s4f5 = taxForm.t1s4f5;
                        vmTaxForm.t1s4f6 = taxForm.t1s4f6;
                        vmTaxForm.t1s4f7 = taxForm.t1s4f7;
                        vmTaxForm.t1s4f8 = taxForm.t1s4f8;
                        vmTaxForm.t1s4f9 = taxForm.t1s4f9;
                        vmTaxForm.t1s4f10 = taxForm.t1s4f10;
                        vmTaxForm.t1s4f11 = taxForm.t1s4f11;
                        vmTaxForm.t1s4f12 = taxForm.t1s4f12;
                        vmTaxForm.t1s4f13 = taxForm.t1s4f13;
                        vmTaxForm.t1s4f14 = taxForm.t1s4f14;
                        vmTaxForm.t1s4f15 = taxForm.t1s4f15;
                        vmTaxForm.t1s4f16 = taxForm.t1s4f16;
                        vmTaxForm.t1s4f17 = taxForm.t1s4f17;
                        vmTaxForm.t1s4f18 = taxForm.t1s4f18;
                        vmTaxForm.t1s4f19 = taxForm.t1s4f19;
                        vmTaxForm.t1s4f20 = taxForm.t1s4f20;
                        vmTaxForm.t1s4f21 = taxForm.t1s4f21;
                        vmTaxForm.t1s4f22 = taxForm.t1s4f22;
                        vmTaxForm.t1s4f23 = taxForm.t1s4f23;
                        vmTaxForm.t1s4f24 = taxForm.t1s4f24;
                        vmTaxForm.t1s4f25 = taxForm.t1s4f25;
                        vmTaxForm.t1s4f26 = taxForm.t1s4f26;
                        vmTaxForm.t1s4f27 = taxForm.t1s4f27;
                        vmTaxForm.t1s4f28 = taxForm.t1s4f28;
                        vmTaxForm.t1s4f29 = taxForm.t1s4f29;
                        vmTaxForm.t1s4f30 = taxForm.t1s4f30;
                        vmTaxForm.t1s4f31 = taxForm.t1s4f31;
                        vmTaxForm.t1s4f32 = taxForm.t1s4f32;
                        vmTaxForm.t1s4f33 = taxForm.t1s4f33;
                        vmTaxForm.t1s4f34 = taxForm.t1s4f34;
                        vmTaxForm.t1s4f35 = taxForm.t1s4f35;
                        vmTaxForm.t1s4f36 = taxForm.t1s4f36;
                        vmTaxForm.t1s4f37 = taxForm.t1s4f37;
                        vmTaxForm.t1s4f38 = taxForm.t1s4f38;
                        vmTaxForm.t1s4f39 = taxForm.t1s4f39;
                        vmTaxForm.t1s4f40 = taxForm.t1s4f40;
                        vmTaxForm.t1s4f41 = taxForm.t1s4f41;
                        vmTaxForm.t1s4f42 = taxForm.t1s4f42;
                        vmTaxForm.t1s4f43 = taxForm.t1s4f43;
                        vmTaxForm.t1s4f44 = taxForm.t1s4f44;
                        vmTaxForm.t1s4f45 = taxForm.t1s4f45;
                        vmTaxForm.t1s4f46 = taxForm.t1s4f46;
                        vmTaxForm.t1s4f47 = taxForm.t1s4f47;
                        vmTaxForm.t1s4f48 = taxForm.t1s4f48;
                        vmTaxForm.t1s4f49 = taxForm.t1s4f49;
                        vmTaxForm.t1s4f50 = taxForm.t1s4f50;
                        vmTaxForm.t1s4f51 = taxForm.t1s4f51;
                        vmTaxForm.t1s4f52 = taxForm.t1s4f52;
                        vmTaxForm.t1s4f53 = taxForm.t1s4f53;
                        vmTaxForm.t1s4f54 = taxForm.t1s4f54;
                        vmTaxForm.t1s4f55 = taxForm.t1s4f55;
                        vmTaxForm.t1s6f1 = taxForm.t1s6f1;
                        vmTaxForm.t1s6f2 = taxForm.t1s6f2;
                        vmTaxForm.t1s6f3 = taxForm.t1s6f3;
                        vmTaxForm.t1s6f4 = taxForm.t1s6f4;
                        vmTaxForm.t1s6f5 = taxForm.t1s6f5;
                        vmTaxForm.t1s6f6 = taxForm.t1s6f6;
                        vmTaxForm.t1s6f7 = taxForm.t1s6f7;
                        vmTaxForm.t1s6f8 = taxForm.t1s6f8;
                        vmTaxForm.t1s6f9 = taxForm.t1s6f9;
                        vmTaxForm.t1s6f10 = taxForm.t1s6f10;
                        vmTaxForm.t1s6f11 = taxForm.t1s6f11;
                        vmTaxForm.t1s6f12 = taxForm.t1s6f12;
                        vmTaxForm.t1s6f13 = taxForm.t1s6f13;
                        vmTaxForm.t1s6f14 = taxForm.t1s6f14;
                        vmTaxForm.t1s6f15 = taxForm.t1s6f15;
                        vmTaxForm.t1s6f16 = taxForm.t1s6f16;
                        vmTaxForm.t1s6f17 = taxForm.t1s6f17;
                        vmTaxForm.t1s6f18 = taxForm.t1s6f18;
                        vmTaxForm.t1s6f19 = taxForm.t1s6f19;
                        vmTaxForm.t1s6f20 = taxForm.t1s6f20;
                        vmTaxForm.t1s6f21 = taxForm.t1s6f21;
                        vmTaxForm.t1s6f22 = taxForm.t1s6f22;
                        vmTaxForm.t1s6f23 = taxForm.t1s6f23;
                        vmTaxForm.t1s6f24 = taxForm.t1s6f24;
                        vmTaxForm.t1s6f25 = taxForm.t1s6f25;
                        vmTaxForm.t1s7f1 = taxForm.t1s7f1;
                        vmTaxForm.t1s7f2 = taxForm.t1s7f2;
                        vmTaxForm.t1s7f3 = taxForm.t1s7f3;
                        vmTaxForm.t1s7f4 = taxForm.t1s7f4;
                        vmTaxForm.t1s7f5 = taxForm.t1s7f5;
                        vmTaxForm.t1s7f6 = taxForm.t1s7f6;
                        vmTaxForm.t1s7f7 = taxForm.t1s7f7;
                        vmTaxForm.t1s7f8 = taxForm.t1s7f8;
                        vmTaxForm.t1s7f9 = taxForm.t1s7f9;
                        vmTaxForm.t1s7f10 = taxForm.t1s7f10;
                        vmTaxForm.t1s7f11 = taxForm.t1s7f11;
                        vmTaxForm.t1s7f12 = taxForm.t1s7f12;
                        vmTaxForm.t1s7f13 = taxForm.t1s7f13;
                        vmTaxForm.t1s7f14 = taxForm.t1s7f14;
                        vmTaxForm.t1s7f15 = taxForm.t1s7f15;
                        vmTaxForm.t1s7f16 = taxForm.t1s7f16;
                        vmTaxForm.t1s7f17 = taxForm.t1s7f17;
                        vmTaxForm.t1s7f18 = taxForm.t1s7f18;
                        vmTaxForm.t1s7f19 = taxForm.t1s7f19;
                        vmTaxForm.t1s7f20 = taxForm.t1s7f20;
                        vmTaxForm.t1s7f21 = taxForm.t1s7f21;
                        vmTaxForm.t1s7f22 = taxForm.t1s7f22;
                        vmTaxForm.t1s7f23 = taxForm.t1s7f23;
                        vmTaxForm.t1s7f24 = taxForm.t1s7f24;
                        vmTaxForm.t1s7f25 = taxForm.t1s7f25;
                        vmTaxForm.t1s7f26 = taxForm.t1s7f26;
                        vmTaxForm.t1s7f27 = taxForm.t1s7f27;
                        vmTaxForm.t1s7f28 = taxForm.t1s7f28;
                        vmTaxForm.t1s7f29 = taxForm.t1s7f29;
                        vmTaxForm.t1s7f30 = taxForm.t1s7f30;
                        vmTaxForm.t1s7f31 = taxForm.t1s7f31;
                        vmTaxForm.t1s7f32 = taxForm.t1s7f32;
                        vmTaxForm.t1s7f33 = taxForm.t1s7f33;
                        vmTaxForm.t1s7f34 = taxForm.t1s7f34;
                        vmTaxForm.t1s7f35 = taxForm.t1s7f35;
                        vmTaxForm.t1s7f36 = taxForm.t1s7f36;
                        vmTaxForm.t1s7f37 = taxForm.t1s7f37;
                        vmTaxForm.t1s7f38 = taxForm.t1s7f38;
                        vmTaxForm.t1s7f39 = taxForm.t1s7f39;
                        vmTaxForm.t1s8f1 = taxForm.t1s8f1;
                        vmTaxForm.t1s8f2 = taxForm.t1s8f2;
                        vmTaxForm.t1s8f3 = taxForm.t1s8f3;
                        vmTaxForm.t1s8f4 = taxForm.t1s8f4;
                        vmTaxForm.t1s8f5 = taxForm.t1s8f5;
                        vmTaxForm.t1s8f6 = taxForm.t1s8f6;
                        vmTaxForm.t1s8f7 = taxForm.t1s8f7;
                        vmTaxForm.t1s8f8 = taxForm.t1s8f8;
                        vmTaxForm.t1s8f9 = taxForm.t1s8f9;
                        vmTaxForm.t1s8f10 = taxForm.t1s8f10;
                        vmTaxForm.t1s8f11 = taxForm.t1s8f11;
                        vmTaxForm.t1s8f12 = taxForm.t1s8f12;
                        vmTaxForm.t1s8f13 = taxForm.t1s8f13;
                        vmTaxForm.t1s8f14 = taxForm.t1s8f14;
                        vmTaxForm.t1s8f15 = taxForm.t1s8f15;
                        vmTaxForm.t1s8f16 = taxForm.t1s8f16;
                        vmTaxForm.t1s8f17 = taxForm.t1s8f17;
                        vmTaxForm.t1s8f18 = taxForm.t1s8f18;
                        vmTaxForm.t1s8f19 = taxForm.t1s8f19;
                        vmTaxForm.t1s8f20 = taxForm.t1s8f20;
                        vmTaxForm.t1s8f21 = taxForm.t1s8f21;
                        vmTaxForm.t1s8f22 = taxForm.t1s8f22;
                        vmTaxForm.t1s8f23 = taxForm.t1s8f23;
                        vmTaxForm.t1s8f24 = taxForm.t1s8f24;
                        vmTaxForm.t1s8f25 = taxForm.t1s8f25;
                        vmTaxForm.t1s8f26 = taxForm.t1s8f26;
                        vmTaxForm.t1s8f27 = taxForm.t1s8f27;
                        vmTaxForm.t1s8f28 = taxForm.t1s8f28;
                        vmTaxForm.t1s8f29 = taxForm.t1s8f29;
                        vmTaxForm.t1s8f30 = taxForm.t1s8f30;
                        vmTaxForm.t1s8f31 = taxForm.t1s8f31;
                        vmTaxForm.t1s8f32 = taxForm.t1s8f32;
                        vmTaxForm.t1s8f33 = taxForm.t1s8f33;
                        vmTaxForm.t1s8f34 = taxForm.t1s8f34;
                        vmTaxForm.t1s8f35 = taxForm.t1s8f35;
                        vmTaxForm.t1s8f36 = taxForm.t1s8f36;
                        vmTaxForm.t1s8f37 = taxForm.t1s8f37;
                        vmTaxForm.t1s8f38 = taxForm.t1s8f38;
                        vmTaxForm.t1s8f39 = taxForm.t1s8f39;
                        vmTaxForm.t1s8f40 = taxForm.t1s8f40;
                        vmTaxForm.t1s8f41 = taxForm.t1s8f41;
                        vmTaxForm.t1s8f42 = taxForm.t1s8f42;
                        vmTaxForm.t1s8f43 = taxForm.t1s8f43;

                        vmTaxForm.totalemployee = taxForm.totalemployee;
                        vmTaxForm.totalperiod = taxForm.totalperiod;
                        vmTaxForm.totalsalaries = taxForm.totalsalaries;
                        vmTaxForm.totalincome = taxForm.totalincome;
                        vmTaxForm.totalother = taxForm.totalother;
                        vmTaxForm.totalhonorarium = taxForm.totalhonorarium;
                        vmTaxForm.totalinsurance = taxForm.totalinsurance;
                        vmTaxForm.totalbenefit = taxForm.totalbenefit;
                        vmTaxForm.totalbonus = taxForm.totalbonus;
                        vmTaxForm.totalgross = taxForm.totalgross;
                        vmTaxForm.totalcost = taxForm.totalcost;
                        vmTaxForm.totalpension = taxForm.totalpension;
                        vmTaxForm.totaldeductions = taxForm.totaldeductions;
                        vmTaxForm.totalnetincome = taxForm.totalnetincome;
                        vmTaxForm.totalincometax = taxForm.totalincometax;
                        vmTaxForm.totalprevnetincome = taxForm.totalprevnetincome;
                        vmTaxForm.totalprevincometax = taxForm.totalprevincometax;
                        vmTaxForm.total1 = taxForm.total1;
                        vmTaxForm.total2 = taxForm.total2;
                        vmTaxForm.total3 = taxForm.total3;
                        vmTaxForm.total4 = taxForm.total4;
                        vmTaxForm.total5 = taxForm.total5;
                        vmTaxForm.total6 = taxForm.total6;
                        vmTaxForm.total7 = taxForm.total7;
                        vmTaxForm.total8 = taxForm.total8;
                        vmTaxForm.total9 = taxForm.total9;
                        vmTaxForm.total10 = taxForm.total10;
                        vmTaxForm.total11 = taxForm.total11;
                        vmTaxForm.total12 = taxForm.total12;
                        vmTaxForm.total13 = taxForm.total13;
                        vmTaxForm.total14 = taxForm.total14;
                        vmTaxForm.total15 = taxForm.total15;
                        vmTaxForm.total16 = taxForm.total16;
                        vmTaxForm.total17 = taxForm.total17;
                        vmTaxForm.total18 = taxForm.total18;
                        vmTaxForm.total19 = taxForm.total19;
                        vmTaxForm.total20 = taxForm.total20;
                        vmTaxForm.total21 = taxForm.total21;
                        vmTaxForm.total22 = taxForm.total22;
                        vmTaxForm.total23 = taxForm.total23;
                        vmTaxForm.total24 = taxForm.total24;
                        vmTaxForm.total25 = taxForm.total25;
                        vmTaxForm.total26 = taxForm.total26;
                        vmTaxForm.ren_netamountcurrency = taxForm.ren_netamountcurrency;
                        vmTaxForm.ren_netamountrp = taxForm.ren_netamountrp;
                        vmTaxForm.ren_nettaxpaidcurrency = taxForm.ren_nettaxpaidcurrency;
                        vmTaxForm.ren_nettaxpaidexchrate = taxForm.ren_nettaxpaidexchrate;
                        vmTaxForm.ren_nettaxpaidamountrp = taxForm.ren_nettaxpaidamountrp;
                        vmTaxForm.tabirregulartotal1 = taxForm.tabirregulartotal1;
                        vmTaxForm.tabirregulartotal2 = taxForm.tabirregulartotal2;
                        vmTaxForm.irregulartaxcredit = taxForm.irregulartaxcredit;
                        vmTaxForm.lbltotalsummary1 = taxForm.lbltotalsummary1;
                        vmTaxForm.lbltotalsummary2 = taxForm.lbltotalsummary2;
                        vmTaxForm.tabasset1 = taxForm.tabasset1;
                        vmTaxForm.tabasset2 = taxForm.tabasset2;
                        vmTaxForm.tabasset3 = taxForm.tabasset3;
                        vmTaxForm.tabasset4 = taxForm.tabasset4;
                        vmTaxForm.tabasset5 = taxForm.tabasset5;
                        vmTaxForm.tabasset6 = taxForm.tabasset6;
                        vmTaxForm.tabasset10 = taxForm.tabasset10;
                        vmTaxForm.tab3nettotalasset = taxForm.tab3nettotalasset;
                        vmTaxForm.tab3nettotalliabilities = taxForm.tab3nettotalliabilities;
                        vmTaxForm.tab3netasset = taxForm.tab3netasset;

                        vmTaxForm.createdby = taxForm.createdby;
                        vmTaxForm.createddate = taxForm.createddate;
                        vmTaxForm.updatedby = taxForm.updatedby;
                        vmTaxForm.updateddate = taxForm.updateddate;

                        vmTaxForms.Add(vmTaxForm);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmTaxForms;
        }

        public vm.TaxForm GetAllByID(int id)
        {
            vm.TaxForm vmTaxForm = null;
            dc.TaxForm taxForm = null;

            try
            {
                taxForm = _repository.FindByID(id);

                if (taxForm != null)
                {
                    vmTaxForm = new vm.TaxForm();
                    vmTaxForm.id = taxForm.id;
                    vmTaxForm.TaxPayerNumber = taxForm.TaxPlayerDetail.TaxPayerNumber;
                    vmTaxForm.ammend = taxForm.ammend;
                    vmTaxForm.status = taxForm.status;
                    vmTaxForm.taxidnumber = taxForm.taxidnumber;
                    vmTaxForm.type = taxForm.type;
                    vmTaxForm.year = taxForm.year;

                    vmTaxForm.t1s1f2 = taxForm.t1s1f2;
                    vmTaxForm.t1s1f4 = taxForm.t1s1f4;
                    vmTaxForm.t1s1f5 = taxForm.t1s1f5;
                    vmTaxForm.t1s1f6 = taxForm.t1s1f6;
                    vmTaxForm.t1s1f7 = taxForm.t1s1f7;
                    vmTaxForm.t1s1f8 = taxForm.t1s1f8;
                    vmTaxForm.t1s2f1 = taxForm.t1s2f1;
                    vmTaxForm.t1s2f2 = taxForm.t1s2f2;
                    vmTaxForm.t1s2f3 = taxForm.t1s2f3;
                    vmTaxForm.t1s2f4 = taxForm.t1s2f4;
                    vmTaxForm.t1s2f5 = taxForm.t1s2f5;
                    vmTaxForm.t1s2f6 = taxForm.t1s2f6;
                    vmTaxForm.t1s2f7 = taxForm.t1s2f7;
                    vmTaxForm.t1s2f8 = taxForm.t1s2f8;
                    vmTaxForm.t1s2f9 = taxForm.t1s2f9;
                    vmTaxForm.t1s2f10 = taxForm.t1s2f10;
                    vmTaxForm.t1s2f11 = taxForm.t1s2f11;
                    vmTaxForm.t1s2f12 = taxForm.t1s2f12;
                    vmTaxForm.t1s2f13 = taxForm.t1s2f13;
                    vmTaxForm.t1s2f14 = taxForm.t1s2f14;
                    vmTaxForm.t1s2f15 = taxForm.t1s2f15;
                    vmTaxForm.t1s2f16 = taxForm.t1s2f16;
                    vmTaxForm.t1s2f17 = taxForm.t1s2f17;
                    vmTaxForm.t1s2f18 = taxForm.t1s2f18;
                    vmTaxForm.t1s2f19 = taxForm.t1s2f19;
                    vmTaxForm.t1s2f20 = taxForm.t1s2f20;
                    vmTaxForm.t1s2f21 = taxForm.t1s2f21;
                    vmTaxForm.t1s2f22 = taxForm.t1s2f22;
                    vmTaxForm.t1s2f23 = taxForm.t1s2f23;
                    vmTaxForm.t1s2f24 = taxForm.t1s2f24;
                    vmTaxForm.t1s3f1 = taxForm.t1s3f1;
                    vmTaxForm.t1s3f2 = taxForm.t1s3f2;
                    vmTaxForm.t1s3f3 = taxForm.t1s3f3;
                    vmTaxForm.t1s4f1 = taxForm.t1s4f1;
                    vmTaxForm.t1s4f2 = taxForm.t1s4f2;
                    vmTaxForm.t1s4f3 = taxForm.t1s4f3;
                    vmTaxForm.t1s4f4 = taxForm.t1s4f4;
                    vmTaxForm.t1s4f5 = taxForm.t1s4f5;
                    vmTaxForm.t1s4f6 = taxForm.t1s4f6;
                    vmTaxForm.t1s4f7 = taxForm.t1s4f7;
                    vmTaxForm.t1s4f8 = taxForm.t1s4f8;
                    vmTaxForm.t1s4f9 = taxForm.t1s4f9;
                    vmTaxForm.t1s4f10 = taxForm.t1s4f10;
                    vmTaxForm.t1s4f11 = taxForm.t1s4f11;
                    vmTaxForm.t1s4f12 = taxForm.t1s4f12;
                    vmTaxForm.t1s4f13 = taxForm.t1s4f13;
                    vmTaxForm.t1s4f14 = taxForm.t1s4f14;
                    vmTaxForm.t1s4f15 = taxForm.t1s4f15;
                    vmTaxForm.t1s4f16 = taxForm.t1s4f16;
                    vmTaxForm.t1s4f17 = taxForm.t1s4f17;
                    vmTaxForm.t1s4f18 = taxForm.t1s4f18;
                    vmTaxForm.t1s4f19 = taxForm.t1s4f19;
                    vmTaxForm.t1s4f20 = taxForm.t1s4f20;
                    vmTaxForm.t1s4f21 = taxForm.t1s4f21;
                    vmTaxForm.t1s4f22 = taxForm.t1s4f22;
                    vmTaxForm.t1s4f23 = taxForm.t1s4f23;
                    vmTaxForm.t1s4f24 = taxForm.t1s4f24;
                    vmTaxForm.t1s4f25 = taxForm.t1s4f25;
                    vmTaxForm.t1s4f26 = taxForm.t1s4f26;
                    vmTaxForm.t1s4f27 = taxForm.t1s4f27;
                    vmTaxForm.t1s4f28 = taxForm.t1s4f28;
                    vmTaxForm.t1s4f29 = taxForm.t1s4f29;
                    vmTaxForm.t1s4f30 = taxForm.t1s4f30;
                    vmTaxForm.t1s4f31 = taxForm.t1s4f31;
                    vmTaxForm.t1s4f32 = taxForm.t1s4f32;
                    vmTaxForm.t1s4f33 = taxForm.t1s4f33;
                    vmTaxForm.t1s4f34 = taxForm.t1s4f34;
                    vmTaxForm.t1s4f35 = taxForm.t1s4f35;
                    vmTaxForm.t1s4f36 = taxForm.t1s4f36;
                    vmTaxForm.t1s4f37 = taxForm.t1s4f37;
                    vmTaxForm.t1s4f38 = taxForm.t1s4f38;
                    vmTaxForm.t1s4f39 = taxForm.t1s4f39;
                    vmTaxForm.t1s4f40 = taxForm.t1s4f40;
                    vmTaxForm.t1s4f41 = taxForm.t1s4f41;
                    vmTaxForm.t1s4f42 = taxForm.t1s4f42;
                    vmTaxForm.t1s4f43 = taxForm.t1s4f43;
                    vmTaxForm.t1s4f44 = taxForm.t1s4f44;
                    vmTaxForm.t1s4f45 = taxForm.t1s4f45;
                    vmTaxForm.t1s4f46 = taxForm.t1s4f46;
                    vmTaxForm.t1s4f47 = taxForm.t1s4f47;
                    vmTaxForm.t1s4f48 = taxForm.t1s4f48;
                    vmTaxForm.t1s4f49 = taxForm.t1s4f49;
                    vmTaxForm.t1s4f50 = taxForm.t1s4f50;
                    vmTaxForm.t1s4f51 = taxForm.t1s4f51;
                    vmTaxForm.t1s4f52 = taxForm.t1s4f52;
                    vmTaxForm.t1s4f53 = taxForm.t1s4f53;
                    vmTaxForm.t1s4f54 = taxForm.t1s4f54;
                    vmTaxForm.t1s4f55 = taxForm.t1s4f55;
                    vmTaxForm.t1s6f1 = taxForm.t1s6f1;
                    vmTaxForm.t1s6f2 = taxForm.t1s6f2;
                    vmTaxForm.t1s6f3 = taxForm.t1s6f3;
                    vmTaxForm.t1s6f4 = taxForm.t1s6f4;
                    vmTaxForm.t1s6f5 = taxForm.t1s6f5;
                    vmTaxForm.t1s6f6 = taxForm.t1s6f6;
                    vmTaxForm.t1s6f7 = taxForm.t1s6f7;
                    vmTaxForm.t1s6f8 = taxForm.t1s6f8;
                    vmTaxForm.t1s6f9 = taxForm.t1s6f9;
                    vmTaxForm.t1s6f10 = taxForm.t1s6f10;
                    vmTaxForm.t1s6f11 = taxForm.t1s6f11;
                    vmTaxForm.t1s6f12 = taxForm.t1s6f12;
                    vmTaxForm.t1s6f13 = taxForm.t1s6f13;
                    vmTaxForm.t1s6f14 = taxForm.t1s6f14;
                    vmTaxForm.t1s6f15 = taxForm.t1s6f15;
                    vmTaxForm.t1s6f16 = taxForm.t1s6f16;
                    vmTaxForm.t1s6f17 = taxForm.t1s6f17;
                    vmTaxForm.t1s6f18 = taxForm.t1s6f18;
                    vmTaxForm.t1s6f19 = taxForm.t1s6f19;
                    vmTaxForm.t1s6f20 = taxForm.t1s6f20;
                    vmTaxForm.t1s6f21 = taxForm.t1s6f21;
                    vmTaxForm.t1s6f22 = taxForm.t1s6f22;
                    vmTaxForm.t1s6f23 = taxForm.t1s6f23;
                    vmTaxForm.t1s6f24 = taxForm.t1s6f24;
                    vmTaxForm.t1s6f25 = taxForm.t1s6f25;
                    vmTaxForm.t1s7f1 = taxForm.t1s7f1;
                    vmTaxForm.t1s7f2 = taxForm.t1s7f2;
                    vmTaxForm.t1s7f3 = taxForm.t1s7f3;
                    vmTaxForm.t1s7f4 = taxForm.t1s7f4;
                    vmTaxForm.t1s7f5 = taxForm.t1s7f5;
                    vmTaxForm.t1s7f6 = taxForm.t1s7f6;
                    vmTaxForm.t1s7f7 = taxForm.t1s7f7;
                    vmTaxForm.t1s7f8 = taxForm.t1s7f8;
                    vmTaxForm.t1s7f9 = taxForm.t1s7f9;
                    vmTaxForm.t1s7f10 = taxForm.t1s7f10;
                    vmTaxForm.t1s7f11 = taxForm.t1s7f11;
                    vmTaxForm.t1s7f12 = taxForm.t1s7f12;
                    vmTaxForm.t1s7f13 = taxForm.t1s7f13;
                    vmTaxForm.t1s7f14 = taxForm.t1s7f14;
                    vmTaxForm.t1s7f15 = taxForm.t1s7f15;
                    vmTaxForm.t1s7f16 = taxForm.t1s7f16;
                    vmTaxForm.t1s7f17 = taxForm.t1s7f17;
                    vmTaxForm.t1s7f18 = taxForm.t1s7f18;
                    vmTaxForm.t1s7f19 = taxForm.t1s7f19;
                    vmTaxForm.t1s7f20 = taxForm.t1s7f20;
                    vmTaxForm.t1s7f21 = taxForm.t1s7f21;
                    vmTaxForm.t1s7f22 = taxForm.t1s7f22;
                    vmTaxForm.t1s7f23 = taxForm.t1s7f23;
                    vmTaxForm.t1s7f24 = taxForm.t1s7f24;
                    vmTaxForm.t1s7f25 = taxForm.t1s7f25;
                    vmTaxForm.t1s7f26 = taxForm.t1s7f26;
                    vmTaxForm.t1s7f27 = taxForm.t1s7f27;
                    vmTaxForm.t1s7f28 = taxForm.t1s7f28;
                    vmTaxForm.t1s7f29 = taxForm.t1s7f29;
                    vmTaxForm.t1s7f30 = taxForm.t1s7f30;
                    vmTaxForm.t1s7f31 = taxForm.t1s7f31;
                    vmTaxForm.t1s7f32 = taxForm.t1s7f32;
                    vmTaxForm.t1s7f33 = taxForm.t1s7f33;
                    vmTaxForm.t1s7f34 = taxForm.t1s7f34;
                    vmTaxForm.t1s7f35 = taxForm.t1s7f35;
                    vmTaxForm.t1s7f36 = taxForm.t1s7f36;
                    vmTaxForm.t1s7f37 = taxForm.t1s7f37;
                    vmTaxForm.t1s7f38 = taxForm.t1s7f38;
                    vmTaxForm.t1s7f39 = taxForm.t1s7f39;
                    vmTaxForm.t1s8f1 = taxForm.t1s8f1;
                    vmTaxForm.t1s8f2 = taxForm.t1s8f2;
                    vmTaxForm.t1s8f3 = taxForm.t1s8f3;
                    vmTaxForm.t1s8f4 = taxForm.t1s8f4;
                    vmTaxForm.t1s8f5 = taxForm.t1s8f5;
                    vmTaxForm.t1s8f6 = taxForm.t1s8f6;
                    vmTaxForm.t1s8f7 = taxForm.t1s8f7;
                    vmTaxForm.t1s8f8 = taxForm.t1s8f8;
                    vmTaxForm.t1s8f9 = taxForm.t1s8f9;
                    vmTaxForm.t1s8f10 = taxForm.t1s8f10;
                    vmTaxForm.t1s8f11 = taxForm.t1s8f11;
                    vmTaxForm.t1s8f12 = taxForm.t1s8f12;
                    vmTaxForm.t1s8f13 = taxForm.t1s8f13;
                    vmTaxForm.t1s8f14 = taxForm.t1s8f14;
                    vmTaxForm.t1s8f15 = taxForm.t1s8f15;
                    vmTaxForm.t1s8f16 = taxForm.t1s8f16;
                    vmTaxForm.t1s8f17 = taxForm.t1s8f17;
                    vmTaxForm.t1s8f18 = taxForm.t1s8f18;
                    vmTaxForm.t1s8f19 = taxForm.t1s8f19;
                    vmTaxForm.t1s8f20 = taxForm.t1s8f20;
                    vmTaxForm.t1s8f21 = taxForm.t1s8f21;
                    vmTaxForm.t1s8f22 = taxForm.t1s8f22;
                    vmTaxForm.t1s8f23 = taxForm.t1s8f23;
                    vmTaxForm.t1s8f24 = taxForm.t1s8f24;
                    vmTaxForm.t1s8f25 = taxForm.t1s8f25;
                    vmTaxForm.t1s8f26 = taxForm.t1s8f26;
                    vmTaxForm.t1s8f27 = taxForm.t1s8f27;
                    vmTaxForm.t1s8f28 = taxForm.t1s8f28;
                    vmTaxForm.t1s8f29 = taxForm.t1s8f29;
                    vmTaxForm.t1s8f30 = taxForm.t1s8f30;
                    vmTaxForm.t1s8f31 = taxForm.t1s8f31;
                    vmTaxForm.t1s8f32 = taxForm.t1s8f32;
                    vmTaxForm.t1s8f33 = taxForm.t1s8f33;
                    vmTaxForm.t1s8f34 = taxForm.t1s8f34;
                    vmTaxForm.t1s8f35 = taxForm.t1s8f35;
                    vmTaxForm.t1s8f36 = taxForm.t1s8f36;
                    vmTaxForm.t1s8f37 = taxForm.t1s8f37;
                    vmTaxForm.t1s8f38 = taxForm.t1s8f38;
                    vmTaxForm.t1s8f39 = taxForm.t1s8f39;
                    vmTaxForm.t1s8f40 = taxForm.t1s8f40;
                    vmTaxForm.t1s8f41 = taxForm.t1s8f41;
                    vmTaxForm.t1s8f42 = taxForm.t1s8f42;
                    vmTaxForm.t1s8f43 = taxForm.t1s8f43;

                    vmTaxForm.totalemployee = taxForm.totalemployee;
                    vmTaxForm.totalperiod = taxForm.totalperiod;
                    vmTaxForm.totalsalaries = taxForm.totalsalaries;
                    vmTaxForm.totalincome = taxForm.totalincome;
                    vmTaxForm.totalother = taxForm.totalother;
                    vmTaxForm.totalhonorarium = taxForm.totalhonorarium;
                    vmTaxForm.totalinsurance = taxForm.totalinsurance;
                    vmTaxForm.totalbenefit = taxForm.totalbenefit;
                    vmTaxForm.totalbonus = taxForm.totalbonus;
                    vmTaxForm.totalgross = taxForm.totalgross;
                    vmTaxForm.totalcost = taxForm.totalcost;
                    vmTaxForm.totalpension = taxForm.totalpension;
                    vmTaxForm.totalpensioncost = taxForm.totalpensioncost;
                    vmTaxForm.totalincome25 = taxForm.totalincome25;
                    vmTaxForm.totalincome26 = taxForm.totalincome26;
                    vmTaxForm.totalincome27 = taxForm.totalincome27;
                    vmTaxForm.totalincome28 = taxForm.totalincome28;
                    vmTaxForm.totalincome29 = taxForm.totalincome29;
                    vmTaxForm.totaldeductions = taxForm.totaldeductions;
                    vmTaxForm.totalnetincome = taxForm.totalnetincome;
                    vmTaxForm.totalincometax = taxForm.totalincometax;
                    vmTaxForm.totalprevnetincome = taxForm.totalprevnetincome;
                    vmTaxForm.totalprevincometax = taxForm.totalprevincometax;
                    vmTaxForm.total1 = taxForm.total1;
                    vmTaxForm.total2 = taxForm.total2;
                    vmTaxForm.total3 = taxForm.total3;
                    vmTaxForm.total4 = taxForm.total4;
                    vmTaxForm.total5 = taxForm.total5;
                    vmTaxForm.total6 = taxForm.total6;
                    vmTaxForm.total7 = taxForm.total7;
                    vmTaxForm.total8 = taxForm.total8;
                    vmTaxForm.total9 = taxForm.total9;
                    vmTaxForm.total10 = taxForm.total10;
                    vmTaxForm.total11 = taxForm.total11;
                    vmTaxForm.total12 = taxForm.total12;
                    vmTaxForm.total13 = taxForm.total13;
                    vmTaxForm.total14 = taxForm.total14;
                    vmTaxForm.total15 = taxForm.total15;
                    vmTaxForm.total16 = taxForm.total16;
                    vmTaxForm.total17 = taxForm.total17;
                    vmTaxForm.total18 = taxForm.total18;
                    vmTaxForm.total19 = taxForm.total19;
                    vmTaxForm.total20 = taxForm.total20;
                    vmTaxForm.total21 = taxForm.total21;
                    vmTaxForm.total22 = taxForm.total22;
                    vmTaxForm.total23 = taxForm.total23;
                    vmTaxForm.total24 = taxForm.total24;
                    vmTaxForm.total25 = taxForm.total25;
                    vmTaxForm.total26 = taxForm.total26;
                    vmTaxForm.ren_netamountcurrency = taxForm.ren_netamountcurrency;
                    vmTaxForm.ren_netamountrp = taxForm.ren_netamountrp;
                    vmTaxForm.ren_nettaxpaidcurrency = taxForm.ren_nettaxpaidcurrency;
                    vmTaxForm.ren_nettaxpaidexchrate = taxForm.ren_nettaxpaidexchrate;
                    vmTaxForm.ren_nettaxpaidamountrp = taxForm.ren_nettaxpaidamountrp;
                    vmTaxForm.tabirregulartotal1 = taxForm.tabirregulartotal1;
                    vmTaxForm.tabirregulartotal2 = taxForm.tabirregulartotal2;
                    vmTaxForm.irregulartaxcredit = taxForm.irregulartaxcredit;
                    vmTaxForm.lbltotalsummary1 = taxForm.lbltotalsummary1;
                    vmTaxForm.lbltotalsummary2 = taxForm.lbltotalsummary2;
                    vmTaxForm.tabasset1 = taxForm.tabasset1;
                    vmTaxForm.tabasset2 = taxForm.tabasset2;
                    vmTaxForm.tabasset3 = taxForm.tabasset3;
                    vmTaxForm.tabasset4 = taxForm.tabasset4;
                    vmTaxForm.tabasset5 = taxForm.tabasset5;
                    vmTaxForm.tabasset6 = taxForm.tabasset6;
                    vmTaxForm.tabasset10 = taxForm.tabasset10;
                    vmTaxForm.tab3nettotalasset = taxForm.tab3nettotalasset;
                    vmTaxForm.tab3nettotalliabilities = taxForm.tab3nettotalliabilities;
                    vmTaxForm.tab3netasset = taxForm.tab3netasset;

                    vmTaxForm.createdby = taxForm.createdby;
                    vmTaxForm.createddate = taxForm.createddate;
                    vmTaxForm.updatedby = taxForm.updatedby;
                    vmTaxForm.updateddate = taxForm.updateddate;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmTaxForm;
        }

        public vm.TaxForm GetByID(int id)
        {
            vm.TaxForm vmTaxForm = null;
            dc.TaxForm taxForm = null;

            try
            {
                taxForm = _repository.FindByID(id);
                if (taxForm != null)
                {
                    vmTaxForm = new vm.TaxForm();
                    vmTaxForm.id = taxForm.id;
                    vmTaxForm.TaxPayerNumber = taxForm.TaxPlayerDetail.TaxPayerNumber;
                    vmTaxForm.ammend = taxForm.ammend;
                    vmTaxForm.status = taxForm.status;
                    vmTaxForm.taxidnumber = taxForm.taxidnumber;
                    vmTaxForm.type = taxForm.type;
                    vmTaxForm.year = taxForm.year;

                    vmTaxForm.t1s1f2 = taxForm.t1s1f2;
                    vmTaxForm.t1s1f4 = taxForm.t1s1f4;
                    vmTaxForm.t1s1f5 = taxForm.t1s1f5;
                    vmTaxForm.t1s1f6 = taxForm.t1s1f6;
                    vmTaxForm.t1s1f7 = taxForm.t1s1f7;
                    vmTaxForm.t1s1f8 = taxForm.t1s1f8;
                    vmTaxForm.t1s2f1 = taxForm.t1s2f1;
                    vmTaxForm.t1s2f2 = taxForm.t1s2f2;
                    vmTaxForm.t1s2f3 = taxForm.t1s2f3;
                    vmTaxForm.t1s2f4 = taxForm.t1s2f4;
                    vmTaxForm.t1s2f5 = taxForm.t1s2f5;
                    vmTaxForm.t1s2f6 = taxForm.t1s2f6;
                    vmTaxForm.t1s2f7 = taxForm.t1s2f7;
                    vmTaxForm.t1s2f8 = taxForm.t1s2f8;
                    vmTaxForm.t1s2f9 = taxForm.t1s2f9;
                    vmTaxForm.t1s2f10 = taxForm.t1s2f10;
                    vmTaxForm.t1s2f11 = taxForm.t1s2f11;
                    vmTaxForm.t1s2f12 = taxForm.t1s2f12;
                    vmTaxForm.t1s2f13 = taxForm.t1s2f13;
                    vmTaxForm.t1s2f14 = taxForm.t1s2f14;
                    vmTaxForm.t1s2f15 = taxForm.t1s2f15;
                    vmTaxForm.t1s2f16 = taxForm.t1s2f16;
                    vmTaxForm.t1s2f17 = taxForm.t1s2f17;
                    vmTaxForm.t1s2f18 = taxForm.t1s2f18;
                    vmTaxForm.t1s2f19 = taxForm.t1s2f19;
                    vmTaxForm.t1s2f20 = taxForm.t1s2f20;
                    vmTaxForm.t1s2f21 = taxForm.t1s2f21;
                    vmTaxForm.t1s2f22 = taxForm.t1s2f22;
                    vmTaxForm.t1s2f23 = taxForm.t1s2f23;
                    vmTaxForm.t1s2f24 = taxForm.t1s2f24;
                    vmTaxForm.t1s3f1 = taxForm.t1s3f1;
                    vmTaxForm.t1s3f2 = taxForm.t1s3f2;
                    vmTaxForm.t1s3f3 = taxForm.t1s3f3;
                    vmTaxForm.t1s4f1 = taxForm.t1s4f1;
                    vmTaxForm.t1s4f2 = taxForm.t1s4f2;
                    vmTaxForm.t1s4f3 = taxForm.t1s4f3;
                    vmTaxForm.t1s4f4 = taxForm.t1s4f4;
                    vmTaxForm.t1s4f5 = taxForm.t1s4f5;
                    vmTaxForm.t1s4f6 = taxForm.t1s4f6;
                    vmTaxForm.t1s4f7 = taxForm.t1s4f7;
                    vmTaxForm.t1s4f8 = taxForm.t1s4f8;
                    vmTaxForm.t1s4f9 = taxForm.t1s4f9;
                    vmTaxForm.t1s4f10 = taxForm.t1s4f10;
                    vmTaxForm.t1s4f11 = taxForm.t1s4f11;
                    vmTaxForm.t1s4f12 = taxForm.t1s4f12;
                    vmTaxForm.t1s4f13 = taxForm.t1s4f13;
                    vmTaxForm.t1s4f14 = taxForm.t1s4f14;
                    vmTaxForm.t1s4f15 = taxForm.t1s4f15;
                    vmTaxForm.t1s4f16 = taxForm.t1s4f16;
                    vmTaxForm.t1s4f17 = taxForm.t1s4f17;
                    vmTaxForm.t1s4f18 = taxForm.t1s4f18;
                    vmTaxForm.t1s4f19 = taxForm.t1s4f19;
                    vmTaxForm.t1s4f20 = taxForm.t1s4f20;
                    vmTaxForm.t1s4f21 = taxForm.t1s4f21;
                    vmTaxForm.t1s4f22 = taxForm.t1s4f22;
                    vmTaxForm.t1s4f23 = taxForm.t1s4f23;
                    vmTaxForm.t1s4f24 = taxForm.t1s4f24;
                    vmTaxForm.t1s4f25 = taxForm.t1s4f25;
                    vmTaxForm.t1s4f26 = taxForm.t1s4f26;
                    vmTaxForm.t1s4f27 = taxForm.t1s4f27;
                    vmTaxForm.t1s4f28 = taxForm.t1s4f28;
                    vmTaxForm.t1s4f29 = taxForm.t1s4f29;
                    vmTaxForm.t1s4f30 = taxForm.t1s4f30;
                    vmTaxForm.t1s4f31 = taxForm.t1s4f31;
                    vmTaxForm.t1s4f32 = taxForm.t1s4f32;
                    vmTaxForm.t1s4f33 = taxForm.t1s4f33;
                    vmTaxForm.t1s4f34 = taxForm.t1s4f34;
                    vmTaxForm.t1s4f35 = taxForm.t1s4f35;
                    vmTaxForm.t1s4f36 = taxForm.t1s4f36;
                    vmTaxForm.t1s4f37 = taxForm.t1s4f37;
                    vmTaxForm.t1s4f38 = taxForm.t1s4f38;
                    vmTaxForm.t1s4f39 = taxForm.t1s4f39;
                    vmTaxForm.t1s4f40 = taxForm.t1s4f40;
                    vmTaxForm.t1s4f41 = taxForm.t1s4f41;
                    vmTaxForm.t1s4f42 = taxForm.t1s4f42;
                    vmTaxForm.t1s4f43 = taxForm.t1s4f43;
                    vmTaxForm.t1s4f44 = taxForm.t1s4f44;
                    vmTaxForm.t1s4f45 = taxForm.t1s4f45;
                    vmTaxForm.t1s4f46 = taxForm.t1s4f46;
                    vmTaxForm.t1s4f47 = taxForm.t1s4f47;
                    vmTaxForm.t1s4f48 = taxForm.t1s4f48;
                    vmTaxForm.t1s4f49 = taxForm.t1s4f49;
                    vmTaxForm.t1s4f50 = taxForm.t1s4f50;
                    vmTaxForm.t1s4f51 = taxForm.t1s4f51;
                    vmTaxForm.t1s4f52 = taxForm.t1s4f52;
                    vmTaxForm.t1s4f53 = taxForm.t1s4f53;
                    vmTaxForm.t1s4f54 = taxForm.t1s4f54;
                    vmTaxForm.t1s4f55 = taxForm.t1s4f55;
                    vmTaxForm.t1s6f1 = taxForm.t1s6f1;
                    vmTaxForm.t1s6f2 = taxForm.t1s6f2;
                    vmTaxForm.t1s6f3 = taxForm.t1s6f3;
                    vmTaxForm.t1s6f4 = taxForm.t1s6f4;
                    vmTaxForm.t1s6f5 = taxForm.t1s6f5;
                    vmTaxForm.t1s6f6 = taxForm.t1s6f6;
                    vmTaxForm.t1s6f7 = taxForm.t1s6f7;
                    vmTaxForm.t1s6f8 = taxForm.t1s6f8;
                    vmTaxForm.t1s6f9 = taxForm.t1s6f9;
                    vmTaxForm.t1s6f10 = taxForm.t1s6f10;
                    vmTaxForm.t1s6f11 = taxForm.t1s6f11;
                    vmTaxForm.t1s6f12 = taxForm.t1s6f12;
                    vmTaxForm.t1s6f13 = taxForm.t1s6f13;
                    vmTaxForm.t1s6f14 = taxForm.t1s6f14;
                    vmTaxForm.t1s6f15 = taxForm.t1s6f15;
                    vmTaxForm.t1s6f16 = taxForm.t1s6f16;
                    vmTaxForm.t1s6f17 = taxForm.t1s6f17;
                    vmTaxForm.t1s6f18 = taxForm.t1s6f18;
                    vmTaxForm.t1s6f19 = taxForm.t1s6f19;
                    vmTaxForm.t1s6f20 = taxForm.t1s6f20;
                    vmTaxForm.t1s6f21 = taxForm.t1s6f21;
                    vmTaxForm.t1s6f22 = taxForm.t1s6f22;
                    vmTaxForm.t1s6f23 = taxForm.t1s6f23;
                    vmTaxForm.t1s6f24 = taxForm.t1s6f24;
                    vmTaxForm.t1s6f25 = taxForm.t1s6f25;
                    vmTaxForm.t1s7f1 = taxForm.t1s7f1;
                    vmTaxForm.t1s7f2 = taxForm.t1s7f2;
                    vmTaxForm.t1s7f3 = taxForm.t1s7f3;
                    vmTaxForm.t1s7f4 = taxForm.t1s7f4;
                    vmTaxForm.t1s7f5 = taxForm.t1s7f5;
                    vmTaxForm.t1s7f6 = taxForm.t1s7f6;
                    vmTaxForm.t1s7f7 = taxForm.t1s7f7;
                    vmTaxForm.t1s7f8 = taxForm.t1s7f8;
                    vmTaxForm.t1s7f9 = taxForm.t1s7f9;
                    vmTaxForm.t1s7f10 = taxForm.t1s7f10;
                    vmTaxForm.t1s7f11 = taxForm.t1s7f11;
                    vmTaxForm.t1s7f12 = taxForm.t1s7f12;
                    vmTaxForm.t1s7f13 = taxForm.t1s7f13;
                    vmTaxForm.t1s7f14 = taxForm.t1s7f14;
                    vmTaxForm.t1s7f15 = taxForm.t1s7f15;
                    vmTaxForm.t1s7f16 = taxForm.t1s7f16;
                    vmTaxForm.t1s7f17 = taxForm.t1s7f17;
                    vmTaxForm.t1s7f18 = taxForm.t1s7f18;
                    vmTaxForm.t1s7f19 = taxForm.t1s7f19;
                    vmTaxForm.t1s7f20 = taxForm.t1s7f20;
                    vmTaxForm.t1s7f21 = taxForm.t1s7f21;
                    vmTaxForm.t1s7f22 = taxForm.t1s7f22;
                    vmTaxForm.t1s7f23 = taxForm.t1s7f23;
                    vmTaxForm.t1s7f24 = taxForm.t1s7f24;
                    vmTaxForm.t1s7f25 = taxForm.t1s7f25;
                    vmTaxForm.t1s7f26 = taxForm.t1s7f26;
                    vmTaxForm.t1s7f27 = taxForm.t1s7f27;
                    vmTaxForm.t1s7f28 = taxForm.t1s7f28;
                    vmTaxForm.t1s7f29 = taxForm.t1s7f29;
                    vmTaxForm.t1s7f30 = taxForm.t1s7f30;
                    vmTaxForm.t1s7f31 = taxForm.t1s7f31;
                    vmTaxForm.t1s7f32 = taxForm.t1s7f32;
                    vmTaxForm.t1s7f33 = taxForm.t1s7f33;
                    vmTaxForm.t1s7f34 = taxForm.t1s7f34;
                    vmTaxForm.t1s7f35 = taxForm.t1s7f35;
                    vmTaxForm.t1s7f36 = taxForm.t1s7f36;
                    vmTaxForm.t1s7f37 = taxForm.t1s7f37;
                    vmTaxForm.t1s7f38 = taxForm.t1s7f38;
                    vmTaxForm.t1s7f39 = taxForm.t1s7f39;
                    vmTaxForm.t1s8f1 = taxForm.t1s8f1;
                    vmTaxForm.t1s8f2 = taxForm.t1s8f2;
                    vmTaxForm.t1s8f3 = taxForm.t1s8f3;
                    vmTaxForm.t1s8f4 = taxForm.t1s8f4;
                    vmTaxForm.t1s8f5 = taxForm.t1s8f5;
                    vmTaxForm.t1s8f6 = taxForm.t1s8f6;
                    vmTaxForm.t1s8f7 = taxForm.t1s8f7;
                    vmTaxForm.t1s8f8 = taxForm.t1s8f8;
                    vmTaxForm.t1s8f9 = taxForm.t1s8f9;
                    vmTaxForm.t1s8f10 = taxForm.t1s8f10;
                    vmTaxForm.t1s8f11 = taxForm.t1s8f11;
                    vmTaxForm.t1s8f12 = taxForm.t1s8f12;
                    vmTaxForm.t1s8f13 = taxForm.t1s8f13;
                    vmTaxForm.t1s8f14 = taxForm.t1s8f14;
                    vmTaxForm.t1s8f15 = taxForm.t1s8f15;
                    vmTaxForm.t1s8f16 = taxForm.t1s8f16;
                    vmTaxForm.t1s8f17 = taxForm.t1s8f17;
                    vmTaxForm.t1s8f18 = taxForm.t1s8f18;
                    vmTaxForm.t1s8f19 = taxForm.t1s8f19;
                    vmTaxForm.t1s8f20 = taxForm.t1s8f20;
                    vmTaxForm.t1s8f21 = taxForm.t1s8f21;
                    vmTaxForm.t1s8f22 = taxForm.t1s8f22;
                    vmTaxForm.t1s8f23 = taxForm.t1s8f23;
                    vmTaxForm.t1s8f24 = taxForm.t1s8f24;
                    vmTaxForm.t1s8f25 = taxForm.t1s8f25;
                    vmTaxForm.t1s8f26 = taxForm.t1s8f26;
                    vmTaxForm.t1s8f27 = taxForm.t1s8f27;
                    vmTaxForm.t1s8f28 = taxForm.t1s8f28;
                    vmTaxForm.t1s8f29 = taxForm.t1s8f29;
                    vmTaxForm.t1s8f30 = taxForm.t1s8f30;
                    vmTaxForm.t1s8f31 = taxForm.t1s8f31;
                    vmTaxForm.t1s8f32 = taxForm.t1s8f32;
                    vmTaxForm.t1s8f33 = taxForm.t1s8f33;
                    vmTaxForm.t1s8f34 = taxForm.t1s8f34;
                    vmTaxForm.t1s8f35 = taxForm.t1s8f35;
                    vmTaxForm.t1s8f36 = taxForm.t1s8f36;
                    vmTaxForm.t1s8f37 = taxForm.t1s8f37;
                    vmTaxForm.t1s8f38 = taxForm.t1s8f38;
                    vmTaxForm.t1s8f39 = taxForm.t1s8f39;
                    vmTaxForm.t1s8f40 = taxForm.t1s8f40;
                    vmTaxForm.t1s8f41 = taxForm.t1s8f41;
                    vmTaxForm.t1s8f42 = taxForm.t1s8f42;
                    vmTaxForm.t1s8f43 = taxForm.t1s8f43;

                    vmTaxForm.totalemployee = taxForm.totalemployee;
                    vmTaxForm.totalperiod = taxForm.totalperiod;
                    vmTaxForm.totalsalaries = taxForm.totalsalaries;
                    vmTaxForm.totalincome = taxForm.totalincome;
                    vmTaxForm.totalother = taxForm.totalother;
                    vmTaxForm.totalhonorarium = taxForm.totalhonorarium;
                    vmTaxForm.totalinsurance = taxForm.totalinsurance;
                    vmTaxForm.totalbenefit = taxForm.totalbenefit;
                    vmTaxForm.totalbonus = taxForm.totalbonus;
                    vmTaxForm.totalgross = taxForm.totalgross;
                    vmTaxForm.totalcost = taxForm.totalcost;
                    vmTaxForm.totalpension = taxForm.totalpension;
                    vmTaxForm.totaldeductions = taxForm.totaldeductions;
                    vmTaxForm.totalnetincome = taxForm.totalnetincome;
                    vmTaxForm.totalincometax = taxForm.totalincometax;
                    vmTaxForm.totalprevnetincome = taxForm.totalprevnetincome;
                    vmTaxForm.totalprevincometax = taxForm.totalprevincometax;
                    vmTaxForm.total1 = taxForm.total1;
                    vmTaxForm.total2 = taxForm.total2;
                    vmTaxForm.total3 = taxForm.total3;
                    vmTaxForm.total4 = taxForm.total4;
                    vmTaxForm.total5 = taxForm.total5;
                    vmTaxForm.total6 = taxForm.total6;
                    vmTaxForm.total7 = taxForm.total7;
                    vmTaxForm.total8 = taxForm.total8;
                    vmTaxForm.total9 = taxForm.total9;
                    vmTaxForm.total10 = taxForm.total10;
                    vmTaxForm.total11 = taxForm.total11;
                    vmTaxForm.total12 = taxForm.total12;
                    vmTaxForm.total13 = taxForm.total13;
                    vmTaxForm.total14 = taxForm.total14;
                    vmTaxForm.total15 = taxForm.total15;
                    vmTaxForm.total16 = taxForm.total16;
                    vmTaxForm.total17 = taxForm.total17;
                    vmTaxForm.total18 = taxForm.total18;
                    vmTaxForm.total19 = taxForm.total19;
                    vmTaxForm.total20 = taxForm.total20;
                    vmTaxForm.total21 = taxForm.total21;
                    vmTaxForm.total22 = taxForm.total22;
                    vmTaxForm.total23 = taxForm.total23;
                    vmTaxForm.total24 = taxForm.total24;
                    vmTaxForm.total25 = taxForm.total25;
                    vmTaxForm.total26 = taxForm.total26;
                    vmTaxForm.ren_netamountcurrency = taxForm.ren_netamountcurrency;
                    vmTaxForm.ren_netamountrp = taxForm.ren_netamountrp;
                    vmTaxForm.ren_nettaxpaidcurrency = taxForm.ren_nettaxpaidcurrency;
                    vmTaxForm.ren_nettaxpaidexchrate = taxForm.ren_nettaxpaidexchrate;
                    vmTaxForm.ren_nettaxpaidamountrp = taxForm.ren_nettaxpaidamountrp;
                    vmTaxForm.tabirregulartotal1 = taxForm.tabirregulartotal1;
                    vmTaxForm.tabirregulartotal2 = taxForm.tabirregulartotal2;
                    vmTaxForm.irregulartaxcredit = taxForm.irregulartaxcredit;
                    vmTaxForm.lbltotalsummary1 = taxForm.lbltotalsummary1;
                    vmTaxForm.lbltotalsummary2 = taxForm.lbltotalsummary2;
                    vmTaxForm.tabasset1 = taxForm.tabasset1;
                    vmTaxForm.tabasset2 = taxForm.tabasset2;
                    vmTaxForm.tabasset3 = taxForm.tabasset3;
                    vmTaxForm.tabasset4 = taxForm.tabasset4;
                    vmTaxForm.tabasset5 = taxForm.tabasset5;
                    vmTaxForm.tabasset6 = taxForm.tabasset6;
                    vmTaxForm.tabasset10 = taxForm.tabasset10;
                    vmTaxForm.tab3nettotalasset = taxForm.tab3nettotalasset;
                    vmTaxForm.tab3nettotalliabilities = taxForm.tab3nettotalliabilities;
                    vmTaxForm.tab3netasset = taxForm.tab3netasset;

                    vmTaxForm.createdby = taxForm.createdby;
                    vmTaxForm.createddate = taxForm.createddate;
                    vmTaxForm.updatedby = taxForm.updatedby;
                    vmTaxForm.updateddate = taxForm.updateddate;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmTaxForm;
        }

        public int GetLastRecordID(string taxidnumber, string type,
            string year)
        {
            int taxFormID = 0;

            try
            {
                taxFormID = _repository.GetLastRecordID(taxidnumber, type, year);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return taxFormID;
        }

        public int Create(int ammend, int status, string taxidnumber, string type,
            string year, string t1s1f2, string createdby, string createddate, string updatedby, string updateddate)
        {
            int insertID = 0;
            try
            {
                insertID = _repository.Insert(ammend, status, taxidnumber, type, year, t1s1f2, 
                    createdby, createddate, updatedby, updateddate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return insertID;
        }

        public int CreateNewCopy(int id, string createdby, string createddate)
        {
            int insertID = 0;
            try
            {
                insertID = _repository.InsertNewCopy(id, createdby, createddate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return insertID;
        }

        public bool Update(int id, int ammend, string taxidnumber, string type,
            string year, string createdby, string createddate, string updatedby, string updateddate)
        {
            bool boolUpdate = false;
            try
            {
                boolUpdate = _repository.Update(id, ammend, taxidnumber, type, year, updatedby, updateddate);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return boolUpdate;
        }

        public bool Delete(int id)
        {
            bool boolDelete = false;
            try
            {
                boolDelete = _repository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return boolDelete;
        }

        public void Dispose()
        {
            if (_repository != null)
            {
                _repository.Dispose();
                _repository = null;
            }
        }

    }
}

