using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Database;
using System.Data.SqlClient;
using dc = DelloiteTRLib.DataContext;
using vm = DelloiteTRLib.Model;

namespace DelloiteTRLib.Repository
{
    public class TaxFormRepository
    {
        private SqlServerDatabase _database;
        private dc.DelloiteDataContext _dataContext;

        public TaxFormRepository()
        {
        }

        public void SetDatabase(SqlServerDatabase database)
        {
            _database = database;
        }

        public void SetDataContext(dc.DelloiteDataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public IEnumerable<dc.TaxForm> FindAll()
        {
            IEnumerable<dc.TaxForm> taxForms = new List<dc.TaxForm>();
            try
            {
                taxForms = _dataContext.TaxForms.ToList<dc.TaxForm>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return taxForms;
        }

        public IEnumerable<dc.TaxForm> FindAllBy(string taxidnumber, string type, string year, int status)
        {
            IEnumerable<dc.TaxForm> taxForms = new List<dc.TaxForm>();

            try
            {
                taxForms = from taxForm in _dataContext.TaxForms select taxForm;
                if (!string.IsNullOrEmpty(taxidnumber))
                {
                    taxForms = taxForms.Where(x => x.taxidnumber== taxidnumber);
                }
                if (!string.IsNullOrEmpty(type))
                {
                    taxForms = taxForms.Where(x => x.type == type);
                }
                if (!string.IsNullOrEmpty(year))
                {
                    taxForms = taxForms.Where(x => x.year == year);
                }
                if (status!=-1)
                {
                    taxForms = taxForms.Where(x => x.status == status);
                }
                else
                {
                    taxForms = taxForms.OrderByDescending(x => x.ammend).Take(1).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return taxForms;
        }

        public IEnumerable<dc.TaxForm> FindAllBy(string taxidnumber, string type, string year, int status, int id)
        {
            IEnumerable<dc.TaxForm> taxForms = new List<dc.TaxForm>();

            try
            {
                taxForms = from taxForm in _dataContext.TaxForms select taxForm;
                if (!string.IsNullOrEmpty(taxidnumber))
                {
                    taxForms = taxForms.Where(x => x.taxidnumber == taxidnumber);
                }
                if (!string.IsNullOrEmpty(type))
                {
                    taxForms = taxForms.Where(x => x.type == type);
                }
                if (!string.IsNullOrEmpty(year))
                {
                    taxForms = taxForms.Where(x => x.year == year);
                }
                if (status != -1)
                {
                    taxForms = taxForms.Where(x => x.status == status);
                }
                else
                {
                    taxForms = taxForms.OrderByDescending(x => x.ammend).Take(1).ToList();
                }
                taxForms = taxForms.Where(x => x.id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return taxForms;
        }

        public dc.TaxForm FindByID(int id)
        {
            dc.TaxForm taxForm = null;

            try
            {
                taxForm = _dataContext.TaxForms.
                    Where(p => p.id == id).
                    SingleOrDefault<dc.TaxForm>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return taxForm;
        }

        public int GetLastRecordID(string taxidnumber, string type,
            string year)
        {
            dc.TaxForm taxForm = null;

            try
            {
                taxForm = _dataContext.TaxForms.
                    Where(p => p.taxidnumber == taxidnumber).
                    Where(p => p.type == type).
                    Where(p => p.year == year).
                    OrderByDescending(p=>p.id)
                    .First<dc.TaxForm>();
                          
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return taxForm.id;
        }

        public int Insert(int ammend, int status, string taxidnumber, string type,
            string year, string t1s1f2, string createdby, string createddate, string updatedby, string updateddate)
        {
            dc.TaxForm taxForm = null;
            try
            {
                taxForm = new dc.TaxForm();
                taxForm.ammend = ammend;
                taxForm.status = status;
                taxForm.taxidnumber = taxidnumber;
                taxForm.type = type;
                taxForm.year = year;
                taxForm.t1s1f2 = t1s1f2;
                taxForm.createdby = createdby;
                taxForm.createddate = createddate;
                taxForm.updatedby = updatedby;
                taxForm.updateddate = updateddate;

                _dataContext.TaxForms.InsertOnSubmit(taxForm);
                _dataContext.SubmitChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return taxForm.id;
        }

        public int InsertNewCopy(int id, string createdby, string createddate)
        {
            dc.TaxForm taxForm = null;
            try
            {
                dc.TaxForm lasttaxForm = _dataContext.TaxForms.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.TaxForm>();
                taxForm = new dc.TaxForm();

                taxForm.taxidnumber = lasttaxForm.taxidnumber;
                taxForm.type = lasttaxForm.type;
                taxForm.year = lasttaxForm.year;
                taxForm.t1s1f2 = lasttaxForm.t1s1f2;
                taxForm.t1s1f4 = lasttaxForm.t1s1f4;
                taxForm.t1s1f5 = lasttaxForm.t1s1f5;
                taxForm.t1s1f6 = lasttaxForm.t1s1f6;
                taxForm.t1s1f7 = lasttaxForm.t1s1f7;
                taxForm.t1s1f8 = lasttaxForm.t1s1f8;
                taxForm.t1s2f1 = lasttaxForm.t1s2f1;
                taxForm.t1s2f2 = lasttaxForm.t1s2f2;
                taxForm.t1s2f3 = lasttaxForm.t1s2f3;
                taxForm.t1s2f4 = lasttaxForm.t1s2f4;
                taxForm.t1s2f5 = lasttaxForm.t1s2f5;
                taxForm.t1s2f6 = lasttaxForm.t1s2f6;
                taxForm.t1s2f7 = lasttaxForm.t1s2f7;
                taxForm.t1s2f8 = lasttaxForm.t1s2f8;
                taxForm.t1s2f9 = lasttaxForm.t1s2f9;
                taxForm.t1s2f10 = lasttaxForm.t1s2f10;
                taxForm.t1s2f11 = lasttaxForm.t1s2f11;
                taxForm.t1s2f12 = lasttaxForm.t1s2f12;
                taxForm.t1s2f13 = lasttaxForm.t1s2f13;
                taxForm.t1s2f14 = lasttaxForm.t1s2f14;
                taxForm.t1s2f15 = lasttaxForm.t1s2f15;
                taxForm.t1s2f16 = lasttaxForm.t1s2f16;
                taxForm.t1s2f17 = lasttaxForm.t1s2f17;
                taxForm.t1s2f18 = lasttaxForm.t1s2f18;
                taxForm.t1s2f19 = lasttaxForm.t1s2f19;
                taxForm.t1s2f20 = lasttaxForm.t1s2f20;
                taxForm.t1s2f21 = lasttaxForm.t1s2f21;
                taxForm.t1s2f22 = lasttaxForm.t1s2f22;
                taxForm.t1s2f23 = lasttaxForm.t1s2f23;
                taxForm.t1s2f24 = lasttaxForm.t1s2f24;
                taxForm.t1s3f1 = lasttaxForm.t1s3f1;
                taxForm.t1s3f2 = lasttaxForm.t1s3f2;
                taxForm.t1s3f3 = lasttaxForm.t1s3f3;
                taxForm.t1s4f1 = lasttaxForm.t1s4f1;
                taxForm.t1s4f2 = lasttaxForm.t1s4f2;
                taxForm.t1s4f3 = lasttaxForm.t1s4f3;
                taxForm.t1s4f4 = lasttaxForm.t1s4f4;
                taxForm.t1s4f5 = lasttaxForm.t1s4f5;
                taxForm.t1s4f6 = lasttaxForm.t1s4f6;
                taxForm.t1s4f7 = lasttaxForm.t1s4f7;
                taxForm.t1s4f8 = lasttaxForm.t1s4f8;
                taxForm.t1s4f9 = lasttaxForm.t1s4f9;
                taxForm.t1s4f10 = lasttaxForm.t1s4f10;
                taxForm.t1s4f11 = lasttaxForm.t1s4f11;
                taxForm.t1s4f12 = lasttaxForm.t1s4f12;
                taxForm.t1s4f13 = lasttaxForm.t1s4f13;
                taxForm.t1s4f14 = lasttaxForm.t1s4f14;
                taxForm.t1s4f15 = lasttaxForm.t1s4f15;
                taxForm.t1s4f16 = lasttaxForm.t1s4f16;
                taxForm.t1s4f17 = lasttaxForm.t1s4f17;
                taxForm.t1s4f18 = lasttaxForm.t1s4f18;
                taxForm.t1s4f19 = lasttaxForm.t1s4f19;
                taxForm.t1s4f20 = lasttaxForm.t1s4f20;
                taxForm.t1s4f21 = lasttaxForm.t1s4f21;
                taxForm.t1s4f22 = lasttaxForm.t1s4f22;
                taxForm.t1s4f23 = lasttaxForm.t1s4f23;
                taxForm.t1s4f24 = lasttaxForm.t1s4f24;
                taxForm.t1s4f25 = lasttaxForm.t1s4f25;
                taxForm.t1s4f26 = lasttaxForm.t1s4f26;
                taxForm.t1s4f27 = lasttaxForm.t1s4f27;
                taxForm.t1s4f28 = lasttaxForm.t1s4f28;
                taxForm.t1s4f29 = lasttaxForm.t1s4f29;
                taxForm.t1s4f30 = lasttaxForm.t1s4f30;
                taxForm.t1s4f31 = lasttaxForm.t1s4f31;
                taxForm.t1s4f32 = lasttaxForm.t1s4f32;
                taxForm.t1s4f33 = lasttaxForm.t1s4f33;
                taxForm.t1s4f34 = lasttaxForm.t1s4f34;
                taxForm.t1s4f35 = lasttaxForm.t1s4f35;
                taxForm.t1s4f36 = lasttaxForm.t1s4f36;
                taxForm.t1s4f37 = lasttaxForm.t1s4f37;
                taxForm.t1s4f38 = lasttaxForm.t1s4f38;
                taxForm.t1s4f39 = lasttaxForm.t1s4f39;
                taxForm.t1s4f40 = lasttaxForm.t1s4f40;
                taxForm.t1s4f41 = lasttaxForm.t1s4f41;
                taxForm.t1s4f42 = lasttaxForm.t1s4f42;
                taxForm.t1s4f43 = lasttaxForm.t1s4f43;
                taxForm.t1s4f44 = lasttaxForm.t1s4f44;
                taxForm.t1s4f45 = lasttaxForm.t1s4f45;
                taxForm.t1s4f46 = lasttaxForm.t1s4f46;
                taxForm.t1s4f47 = lasttaxForm.t1s4f47;
                taxForm.t1s4f48 = lasttaxForm.t1s4f48;
                taxForm.t1s4f49 = lasttaxForm.t1s4f49;
                taxForm.t1s4f50 = lasttaxForm.t1s4f50;
                taxForm.t1s4f51 = lasttaxForm.t1s4f51;
                taxForm.t1s4f52 = lasttaxForm.t1s4f52;
                taxForm.t1s4f53 = lasttaxForm.t1s4f53;
                taxForm.t1s4f54 = lasttaxForm.t1s4f54;
                taxForm.t1s6f1 = lasttaxForm.t1s6f1;
                taxForm.t1s6f2 = lasttaxForm.t1s6f2;
                taxForm.t1s6f3 = lasttaxForm.t1s6f3;
                taxForm.t1s6f4 = lasttaxForm.t1s6f4;
                taxForm.t1s6f5 = lasttaxForm.t1s6f5;
                taxForm.t1s6f6 = lasttaxForm.t1s6f6;
                taxForm.t1s6f7 = lasttaxForm.t1s6f7;
                taxForm.t1s6f8 = lasttaxForm.t1s6f8;
                taxForm.t1s6f9 = lasttaxForm.t1s6f9;
                taxForm.t1s6f10 = lasttaxForm.t1s6f10;
                taxForm.t1s6f11 = lasttaxForm.t1s6f11;
                taxForm.t1s6f12 = lasttaxForm.t1s6f12;
                taxForm.t1s6f13 = lasttaxForm.t1s6f13;
                taxForm.t1s6f14 = lasttaxForm.t1s6f14;
                taxForm.t1s6f15 = lasttaxForm.t1s6f15;
                taxForm.t1s6f16 = lasttaxForm.t1s6f16;
                taxForm.t1s6f17 = lasttaxForm.t1s6f17;
                taxForm.t1s6f18 = lasttaxForm.t1s6f18;
                taxForm.t1s6f19 = lasttaxForm.t1s6f19;
                taxForm.t1s6f20 = lasttaxForm.t1s6f20;
                taxForm.t1s6f21 = lasttaxForm.t1s6f21;
                taxForm.t1s6f22 = lasttaxForm.t1s6f22;
                taxForm.t1s6f23 = lasttaxForm.t1s6f23;
                taxForm.t1s6f24 = lasttaxForm.t1s6f24;
                taxForm.t1s6f25 = lasttaxForm.t1s6f25;
                taxForm.t1s7f1 = lasttaxForm.t1s7f1;
                taxForm.t1s7f2 = lasttaxForm.t1s7f2;
                taxForm.t1s7f3 = lasttaxForm.t1s7f3;
                taxForm.t1s7f4 = lasttaxForm.t1s7f4;
                taxForm.t1s7f5 = lasttaxForm.t1s7f5;
                taxForm.t1s7f6 = lasttaxForm.t1s7f6;
                taxForm.t1s7f7 = lasttaxForm.t1s7f7;
                taxForm.t1s7f8 = lasttaxForm.t1s7f8;
                taxForm.t1s7f9 = lasttaxForm.t1s7f9;
                taxForm.t1s7f10 = lasttaxForm.t1s7f10;
                taxForm.t1s7f11 = lasttaxForm.t1s7f11;
                taxForm.t1s7f12 = lasttaxForm.t1s7f12;
                taxForm.t1s7f13 = lasttaxForm.t1s7f13;
                taxForm.t1s7f14 = lasttaxForm.t1s7f14;
                taxForm.t1s7f15 = lasttaxForm.t1s7f15;
                taxForm.t1s7f16 = lasttaxForm.t1s7f16;
                taxForm.t1s7f17 = lasttaxForm.t1s7f17;
                taxForm.t1s7f18 = lasttaxForm.t1s7f18;
                taxForm.t1s7f19 = lasttaxForm.t1s7f19;
                taxForm.t1s7f20 = lasttaxForm.t1s7f20;
                taxForm.t1s7f21 = lasttaxForm.t1s7f21;
                taxForm.t1s7f22 = lasttaxForm.t1s7f22;
                taxForm.t1s7f23 = lasttaxForm.t1s7f23;
                taxForm.t1s7f24 = lasttaxForm.t1s7f24;
                taxForm.t1s7f25 = lasttaxForm.t1s7f25;
                taxForm.t1s7f26 = lasttaxForm.t1s7f26;
                taxForm.t1s7f27 = lasttaxForm.t1s7f27;
                taxForm.t1s7f28 = lasttaxForm.t1s7f28;
                taxForm.t1s7f29 = lasttaxForm.t1s7f29;
                taxForm.t1s7f30 = lasttaxForm.t1s7f30;
                taxForm.t1s7f31 = lasttaxForm.t1s7f31;
                taxForm.t1s7f32 = lasttaxForm.t1s7f32;
                taxForm.t1s7f33 = lasttaxForm.t1s7f33;
                taxForm.t1s7f34 = lasttaxForm.t1s7f34;
                taxForm.t1s7f35 = lasttaxForm.t1s7f35;
                taxForm.t1s7f36 = lasttaxForm.t1s7f36;
                taxForm.t1s7f37 = lasttaxForm.t1s7f37;
                taxForm.t1s7f38 = lasttaxForm.t1s7f38;
                taxForm.t1s7f39 = lasttaxForm.t1s7f39;
                taxForm.t1s8f1 = lasttaxForm.t1s8f1;
                taxForm.t1s8f2 = lasttaxForm.t1s8f2;
                taxForm.t1s8f3 = lasttaxForm.t1s8f3;
                taxForm.t1s8f4 = lasttaxForm.t1s8f4;
                taxForm.t1s8f5 = lasttaxForm.t1s8f5;
                taxForm.t1s8f6 = lasttaxForm.t1s8f6;
                taxForm.t1s8f7 = lasttaxForm.t1s8f7;
                taxForm.t1s8f8 = lasttaxForm.t1s8f8;
                taxForm.t1s8f9 = lasttaxForm.t1s8f9;
                taxForm.t1s8f10 = lasttaxForm.t1s8f10;
                taxForm.t1s8f11 = lasttaxForm.t1s8f11;
                taxForm.t1s8f12 = lasttaxForm.t1s8f12;
                taxForm.t1s8f13 = lasttaxForm.t1s8f13;
                taxForm.t1s8f14 = lasttaxForm.t1s8f14;
                taxForm.t1s8f15 = lasttaxForm.t1s8f15;
                taxForm.t1s8f16 = lasttaxForm.t1s8f16;
                taxForm.t1s8f17 = lasttaxForm.t1s8f17;
                taxForm.t1s8f18 = lasttaxForm.t1s8f18;
                taxForm.t1s8f19 = lasttaxForm.t1s8f19;
                taxForm.t1s8f20 = lasttaxForm.t1s8f20;
                taxForm.t1s8f21 = lasttaxForm.t1s8f21;
                taxForm.t1s8f22 = lasttaxForm.t1s8f22;
                taxForm.t1s8f23 = lasttaxForm.t1s8f23;
                taxForm.t1s8f24 = lasttaxForm.t1s8f24;
                taxForm.t1s8f25 = lasttaxForm.t1s8f25;
                taxForm.t1s8f26 = lasttaxForm.t1s8f26;
                taxForm.t1s8f27 = lasttaxForm.t1s8f27;
                taxForm.t1s8f28 = lasttaxForm.t1s8f28;
                taxForm.t1s8f29 = lasttaxForm.t1s8f29;
                taxForm.t1s8f30 = lasttaxForm.t1s8f30;
                taxForm.t1s8f31 = lasttaxForm.t1s8f31;
                taxForm.t1s8f32 = lasttaxForm.t1s8f32;
                taxForm.t1s8f33 = lasttaxForm.t1s8f33;
                taxForm.t1s8f34 = lasttaxForm.t1s8f34;
                taxForm.t1s8f35 = lasttaxForm.t1s8f35;
                taxForm.t1s8f36 = lasttaxForm.t1s8f36;
                taxForm.t1s8f37 = lasttaxForm.t1s8f37;
                taxForm.t1s8f38 = lasttaxForm.t1s8f38;
                taxForm.t1s8f39 = lasttaxForm.t1s8f39;
                taxForm.t1s8f40 = lasttaxForm.t1s8f40;
                taxForm.t1s8f41 = lasttaxForm.t1s8f41;
                taxForm.t1s8f42 = lasttaxForm.t1s8f42;
                taxForm.t1s8f43 = lasttaxForm.t1s8f43;
                taxForm.totalemployee = lasttaxForm.totalemployee;
                taxForm.totalperiod = lasttaxForm.totalperiod;
                taxForm.totalsalaries = lasttaxForm.totalsalaries;
                taxForm.totalincome = lasttaxForm.totalincome;
                taxForm.totalother = lasttaxForm.totalother;
                taxForm.totalhonorarium = lasttaxForm.totalhonorarium;
                taxForm.totalinsurance = lasttaxForm.totalinsurance;
                taxForm.totalbenefit = lasttaxForm.totalbenefit;
                taxForm.totalbonus = lasttaxForm.totalbonus;
                taxForm.totalgross = lasttaxForm.totalgross;
                taxForm.totalcost = lasttaxForm.totalcost;
                taxForm.totalpension = lasttaxForm.totalpension;
                taxForm.totaldeductions = lasttaxForm.totaldeductions;
                taxForm.totalnetincome = lasttaxForm.totalnetincome;
                taxForm.totalincometax = lasttaxForm.totalincometax;
                taxForm.totalprevnetincome = lasttaxForm.totalprevnetincome;
                taxForm.totalprevincometax = lasttaxForm.totalprevincometax;
                taxForm.total1 = lasttaxForm.total1;
                taxForm.total2 = lasttaxForm.total2;
                taxForm.total3 = lasttaxForm.total3;
                taxForm.total4 = lasttaxForm.total4;
                taxForm.total5 = lasttaxForm.total5;
                taxForm.total6 = lasttaxForm.total6;
                taxForm.total7 = lasttaxForm.total7;
                taxForm.total8 = lasttaxForm.total8;
                taxForm.total9 = lasttaxForm.total9;
                taxForm.total10 = lasttaxForm.total10;
                taxForm.total11 = lasttaxForm.total11;
                taxForm.total12 = lasttaxForm.total12;
                taxForm.total13 = lasttaxForm.total13;
                taxForm.total14 = lasttaxForm.total14;
                taxForm.total15 = lasttaxForm.total15;
                taxForm.total16 = lasttaxForm.total16;
                taxForm.total17 = lasttaxForm.total17;
                taxForm.total18 = lasttaxForm.total18;
                taxForm.total19 = lasttaxForm.total19;
                taxForm.total20 = lasttaxForm.total20;
                taxForm.total21 = lasttaxForm.total21;
                taxForm.total22 = lasttaxForm.total22;
                taxForm.total23 = lasttaxForm.total23;
                taxForm.total24 = lasttaxForm.total24;
                taxForm.total25 = lasttaxForm.total25;
                taxForm.total26 = lasttaxForm.total26;
                taxForm.ren_netamountcurrency = lasttaxForm.ren_netamountcurrency;
                taxForm.ren_netamountrp = lasttaxForm.ren_netamountrp;
                taxForm.ren_nettaxpaidcurrency = lasttaxForm.ren_nettaxpaidcurrency;
                taxForm.ren_nettaxpaidexchrate = lasttaxForm.ren_nettaxpaidexchrate;
                taxForm.ren_nettaxpaidamountrp = lasttaxForm.ren_nettaxpaidamountrp;
                taxForm.tabirregulartotal1 = lasttaxForm.tabirregulartotal1;
                taxForm.tabirregulartotal2 = lasttaxForm.tabirregulartotal2;
                taxForm.irregulartaxcredit = lasttaxForm.irregulartaxcredit;
                taxForm.lbltotalsummary1 = lasttaxForm.lbltotalsummary1;
                taxForm.lbltotalsummary2 = lasttaxForm.lbltotalsummary2;
                taxForm.tabasset1 = lasttaxForm.tabasset1;
                taxForm.tabasset2 = lasttaxForm.tabasset2;
                taxForm.tabasset3 = lasttaxForm.tabasset3;
                taxForm.tabasset4 = lasttaxForm.tabasset4;
                taxForm.tabasset5 = lasttaxForm.tabasset5;
                taxForm.tabasset6 = lasttaxForm.tabasset6;
                taxForm.tabasset10 = lasttaxForm.tabasset10;
                taxForm.tab3nettotalasset = lasttaxForm.tab3nettotalasset;
                taxForm.tab3nettotalliabilities = lasttaxForm.tab3nettotalliabilities;
                taxForm.tab3netasset = lasttaxForm.tab3netasset;

                taxForm.ammend = lasttaxForm.ammend + 1;
                taxForm.status = 0;
                taxForm.createdby = createdby;
                taxForm.createddate = createddate;
                taxForm.updatedby = createdby;
                taxForm.updateddate = createddate;

                _dataContext.TaxForms.InsertOnSubmit(taxForm);
                _dataContext.SubmitChanges();

                //copy family
                List<dc.Family> _fams = _dataContext.Families.
                                Where(p => p.year == taxForm.year).
                                Where(p => p.form == taxForm.type).
                                Where(p => p.ammend == lasttaxForm.ammend).
                                Where(p => p.TaxPayerNumber == taxForm.TaxPlayerDetail.TaxPayerNumber).
                                ToList<dc.Family>();

                foreach(dc.Family _fam in _fams){
                    dc.Family _family = new dc.Family();
                    _family.ammend = _fam.ammend + 1;
                    _family.Birthdate = _fam.Birthdate;
                    _family.createdby = createdby;
                    _family.createddate = createddate;
                    _family.updatedby = createdby;
                    _family.updateddate = createddate;
                    _family.year = _fam.year;
                    _family.TaxPayerNumber = _fam.TaxPayerNumber;
                    _family.Relationship = _fam.Relationship;
                    _family.form = _fam.form;
                    _family.Name = _fam.Name;
                    _family.NIK = _fam.NIK;
                    _family.Occupation = _fam.Occupation;

                    dc.Family _isexist = _dataContext.Families.
                                Where(p => p.year == _family.year).
                                Where(p => p.form == _family.form).
                                Where(p => p.ammend == _family.ammend).
                                Where(p => p.TaxPayerNumber == _family.TaxPayerNumber).
                                Where(p => p.Name == _family.Name).
                                SingleOrDefault<dc.Family>();

                    if (_isexist == null)
                    {
                        _dataContext.Families.InsertOnSubmit(_family);
                        _dataContext.SubmitChanges();
                    }
                }

                //copy ieincome
                List<dc.IEIncome> _ieincomes = _dataContext.IEIncomes.
                                Where(p => p.year == taxForm.year).
                                Where(p => p.form == taxForm.type).
                                Where(p => p.ammend == lasttaxForm.ammend).
                                Where(p => p.TaxPlayerNumber == taxForm.TaxPlayerDetail.TaxPayerNumber).
                                ToList<dc.IEIncome>();

                foreach (dc.IEIncome _ieincome in _ieincomes)
                {
                    dc.IEIncome _ie_income = new dc.IEIncome();
                    _ie_income.ammend = _ieincome.ammend + 1;
                    _ie_income.createdby = createdby;
                    _ie_income.createddate = createddate;
                    _ie_income.updatedby = createdby;
                    _ie_income.updateddate = createddate;
                    _ie_income.year = _ieincome.year;
                    _ie_income.TaxPlayerNumber = _ieincome.TaxPlayerNumber;
                    _ie_income.form = _ieincome.form;

                    _ie_income.field1 = _ieincome.field1;
                    _ie_income.field2 = _ieincome.field2;
                    _ie_income.field3 = _ieincome.field3;
                    _ie_income.field4 = _ieincome.field4;
                    _ie_income.field5 = _ieincome.field5;
                    _ie_income.field6 = _ieincome.field6;
                    _ie_income.field7 = _ieincome.field7;
                    _ie_income.field8 = _ieincome.field8;
                    _ie_income.field9 = _ieincome.field9;
                    _ie_income.field10 = _ieincome.field10;

                    _ie_income.field11 = _ieincome.field11;
                    _ie_income.field12 = _ieincome.field12;
                    _ie_income.field13 = _ieincome.field13;
                    _ie_income.field14 = _ieincome.field14;
                    _ie_income.field15 = _ieincome.field15;
                    _ie_income.field16 = _ieincome.field16;
                    _ie_income.field17 = _ieincome.field17;
                    _ie_income.field18 = _ieincome.field18;
                    _ie_income.field19 = _ieincome.field19;
                    _ie_income.field20 = _ieincome.field20;

                    _ie_income.field21 = _ieincome.field21;
                    _ie_income.field22 = _ieincome.field22;
                    _ie_income.field23 = _ieincome.field23;
                    _ie_income.field24 = _ieincome.field24;
                    _ie_income.field25 = _ieincome.field25;
                    _ie_income.field26 = _ieincome.field26;
                    _ie_income.field27 = _ieincome.field27;
                    _ie_income.field28 = _ieincome.field28;
                    _ie_income.field29 = _ieincome.field29;

                    dc.IEIncome _isexist = _dataContext.IEIncomes.
                                Where(p => p.year == _ie_income.year).
                                Where(p => p.form == _ie_income.form).
                                Where(p => p.ammend == _ie_income.ammend).
                                Where(p => p.TaxPlayerNumber == _ie_income.TaxPlayerNumber).
                                Where(p => p.field4 == _ie_income.field4).
                                SingleOrDefault<dc.IEIncome>();

                    if (_isexist == null)
                    {
                        _dataContext.IEIncomes.InsertOnSubmit(_ie_income);
                        _dataContext.SubmitChanges();
                    }
                }

                //copy overseas capital
                List<dc.Overseas_Capital> _capincomes = _dataContext.Overseas_Capitals.
                                Where(p => p.year == taxForm.year).
                                Where(p => p.form == taxForm.type).
                                Where(p => p.ammend == lasttaxForm.ammend).
                                Where(p => p.TaxPlayerNumber == taxForm.TaxPlayerDetail.TaxPayerNumber).
                                ToList<dc.Overseas_Capital>();

                foreach (dc.Overseas_Capital _capincome in _capincomes)
                {
                    dc.Overseas_Capital _cap_income = new dc.Overseas_Capital();
                    _cap_income.ammend = _capincome.ammend + 1;
                    _cap_income.createdby = createdby;
                    _cap_income.createddate = createddate;
                    _cap_income.updatedby = createdby;
                    _cap_income.updateddate = createddate;
                    _cap_income.year = _capincome.year;
                    _cap_income.TaxPlayerNumber = _capincome.TaxPlayerNumber;
                    _cap_income.form = _capincome.form;

                    _cap_income.cap_description = _capincome.cap_description;
                    _cap_income.cap_country = _capincome.cap_country;
                    _cap_income.cap_currency = _capincome.cap_currency;
                    _cap_income.cap_sellingdate = _capincome.cap_sellingdate;
                    _cap_income.cap_interval = _capincome.cap_interval;
                    _cap_income.cap_exchrate = _capincome.cap_exchrate;
                    _cap_income.cap_proceeds = _capincome.cap_proceeds;
                    _cap_income.cap_cost = _capincome.cap_cost;
                    _cap_income.cap_gainloss = _capincome.cap_gainloss;
                    _cap_income.cap_taxpaid = _capincome.cap_taxpaid;
                    _cap_income.cap_gainlossrp = _capincome.cap_gainlossrp;
                    _cap_income.cap_taxpaidrp = _capincome.cap_taxpaidrp;
                    _cap_income.cap_irregularincome = _capincome.cap_irregularincome;

                    dc.Overseas_Capital _isexist = _dataContext.Overseas_Capitals.
                                Where(p => p.year == _cap_income.year).
                                Where(p => p.form == _cap_income.form).
                                Where(p => p.ammend == _cap_income.ammend).
                                Where(p => p.TaxPlayerNumber == _cap_income.TaxPlayerNumber).
                                Where(p => p.cap_description == _cap_income.cap_description).
                                Where(p => p.cap_gainloss == _cap_income.cap_gainloss).
                                Where(p => p.cap_taxpaid == _cap_income.cap_taxpaid).
                                Where(p => p.cap_exchrate == _cap_income.cap_exchrate).
                                SingleOrDefault<dc.Overseas_Capital>();

                    if (_isexist == null)
                    {
                        _dataContext.Overseas_Capitals.InsertOnSubmit(_cap_income);
                        _dataContext.SubmitChanges();
                    }
                }



                //copy overseas asset
                List<dc.Overseas_Asset> _asincomes = _dataContext.Overseas_Assets.
                                Where(p => p.year == taxForm.year).
                                Where(p => p.form == taxForm.type).
                                Where(p => p.ammend == lasttaxForm.ammend).
                                Where(p => p.TaxPlayerNumber == taxForm.TaxPlayerDetail.TaxPayerNumber).
                                ToList<dc.Overseas_Asset>();

                foreach (dc.Overseas_Asset _asincome in _asincomes)
                {
                    dc.Overseas_Asset _as_income = new dc.Overseas_Asset();
                    _as_income.ammend = _asincome.ammend + 1;
                    _as_income.createdby = createdby;
                    _as_income.createddate = createddate;
                    _as_income.updatedby = createdby;
                    _as_income.updateddate = createddate;
                    _as_income.year = _asincome.year;
                    _as_income.TaxPlayerNumber = _asincome.TaxPlayerNumber;
                    _as_income.form = _asincome.form;

                    _as_income.type = _asincome.type;
                    _as_income.as_id = _asincome.as_id;
                    _as_income.as_refnumber = _asincome.as_refnumber;
                    _as_income.as_details = _asincome.as_details;
                    _as_income.as_currency = _asincome.as_currency;
                    _as_income.as_balancedate = _asincome.as_balancedate;
                    _as_income.as_interval = _asincome.as_interval;
                    _as_income.as_originalcurrency = _asincome.as_originalcurrency;
                    _as_income.as_exchrate = _asincome.as_exchrate;
                    _as_income.as_inrupiah = _asincome.as_inrupiah;
                    _as_income.as_owner = _asincome.as_owner;
                    _as_income.as_address = _asincome.as_address;
                    _as_income.as_account = _asincome.as_account;
                    _as_income.as_country = _asincome.as_country;

                    dc.Overseas_Asset _isexist = _dataContext.Overseas_Assets.
                                Where(p => p.year == _as_income.year).
                                Where(p => p.form == _as_income.form).
                                Where(p => p.ammend == _as_income.ammend).
                                Where(p => p.TaxPlayerNumber == _as_income.TaxPlayerNumber).
                                Where(p => p.as_id == _as_income.as_id).
                                Where(p => p.as_originalcurrency == _as_income.as_originalcurrency).
                                Where(p => p.as_details == _as_income.as_details).
                                Where(p => p.as_exchrate == _as_income.as_exchrate).
                                SingleOrDefault<dc.Overseas_Asset>();

                    if (_isexist == null)
                    {
                        _dataContext.Overseas_Assets.InsertOnSubmit(_as_income);
                        _dataContext.SubmitChanges();
                    }
                }

                if (taxForm.type != "formus")
                {
                    //copy overseas income
                    List<dc.Overseas_Income> _ovincomes = _dataContext.Overseas_Incomes.
                                    Where(p => p.year == taxForm.year).
                                    Where(p => p.form == taxForm.type).
                                    Where(p => p.ammend == lasttaxForm.ammend).
                                    Where(p => p.TaxPlayerNumber == taxForm.TaxPlayerDetail.TaxPayerNumber).
                                    ToList<dc.Overseas_Income>();

                    foreach (dc.Overseas_Income _ovincome in _ovincomes)
                    {
                        dc.Overseas_Income _ov_income = new dc.Overseas_Income();
                        _ov_income.ammend = _ovincome.ammend + 1;
                        _ov_income.createdby = createdby;
                        _ov_income.createddate = createddate;
                        _ov_income.updatedby = createdby;
                        _ov_income.updateddate = createddate;
                        _ov_income.year = _ovincome.year;
                        _ov_income.TaxPlayerNumber = _ovincome.TaxPlayerNumber;
                        _ov_income.form = _ovincome.form;

                        _ov_income.type = _ovincome.type;
                        _ov_income.country = _ovincome.country;
                        _ov_income.currency = _ovincome.currency;
                        _ov_income.dateofreceipt = _ovincome.dateofreceipt;
                        _ov_income.interval = _ovincome.interval;
                        _ov_income.exchrate = _ovincome.exchrate;
                        _ov_income.incomecurrency = _ovincome.incomecurrency;
                        _ov_income.taxpaidcurrency = _ovincome.taxpaidcurrency;
                        _ov_income.incomerp = _ovincome.incomerp;
                        _ov_income.taxpaidrp = _ovincome.taxpaidrp;
                        _ov_income.treatyrate = _ovincome.treatyrate;
                        _ov_income.ftc = _ovincome.ftc;
                        _ov_income.allowedftc = _ovincome.allowedftc;
                        _ov_income.irregularincome = _ovincome.irregularincome;

                        dc.Overseas_Income _isexist = _dataContext.Overseas_Incomes.
                                    Where(p => p.year == _ov_income.year).
                                    Where(p => p.form == _ov_income.form).
                                    Where(p => p.ammend == _ov_income.ammend).
                                    Where(p => p.TaxPlayerNumber == _ov_income.TaxPlayerNumber).
                                    Where(p => p.incomecurrency == _ov_income.incomecurrency).
                                    Where(p => p.taxpaidrp == _ov_income.taxpaidrp).
                                    Where(p => p.exchrate == _ov_income.exchrate).
                                    SingleOrDefault<dc.Overseas_Income>();

                        if (_isexist == null)
                        {
                            _dataContext.Overseas_Incomes.InsertOnSubmit(_ov_income);
                            _dataContext.SubmitChanges();
                        }
                    }

                    //copy overseas rental
                    List<dc.Overseas_Rental> _renincomes = _dataContext.Overseas_Rentals.
                                    Where(p => p.year == taxForm.year).
                                    Where(p => p.form == taxForm.type).
                                    Where(p => p.ammend == lasttaxForm.ammend).
                                    Where(p => p.TaxPlayerNumber == taxForm.TaxPlayerDetail.TaxPayerNumber).
                                    ToList<dc.Overseas_Rental>();

                    foreach (dc.Overseas_Rental _renincome in _renincomes)
                    {
                        dc.Overseas_Rental _ren_income = new dc.Overseas_Rental();
                        _ren_income.ammend = _renincome.ammend + 1;
                        _ren_income.createdby = createdby;
                        _ren_income.createddate = createddate;
                        _ren_income.updatedby = createdby;
                        _ren_income.updateddate = createddate;
                        _ren_income.year = _renincome.year;
                        _ren_income.TaxPlayerNumber = _renincome.TaxPlayerNumber;
                        _ren_income.form = _renincome.form;

                        _ren_income.type = _renincome.type;
                        _ren_income.ren_information = _renincome.ren_information;
                        _ren_income.ren_country = _renincome.ren_country;
                        _ren_income.ren_currency = _renincome.ren_currency;
                        _ren_income.ren_dateofreceipt = _renincome.ren_dateofreceipt;
                        _ren_income.ren_interval = _renincome.ren_interval;
                        _ren_income.ren_exchrate = _renincome.ren_exchrate;
                        _ren_income.ren_amountcurrency = _renincome.ren_amountcurrency;
                        _ren_income.ren_amountrp = _renincome.ren_amountrp;
                        _ren_income.ren_irregularincome = _renincome.ren_irregularincome;

                        dc.Overseas_Rental _isexist = _dataContext.Overseas_Rentals.
                                    Where(p => p.year == _ren_income.year).
                                    Where(p => p.form == _ren_income.form).
                                    Where(p => p.ammend == _ren_income.ammend).
                                    Where(p => p.TaxPlayerNumber == _ren_income.TaxPlayerNumber).
                                    Where(p => p.ren_information == _ren_income.ren_information).
                                    Where(p => p.ren_exchrate == _ren_income.ren_exchrate).
                                    Where(p => p.ren_amountcurrency == _ren_income.ren_amountcurrency).
                                    SingleOrDefault<dc.Overseas_Rental>();

                        if (_isexist == null)
                        {
                            _dataContext.Overseas_Rentals.InsertOnSubmit(_ren_income);
                            _dataContext.SubmitChanges();
                        }
                    }

                    //copy irregular
                    List<dc.Irregular> _renincomesirr = _dataContext.Irregulars.
                        Where(p => p.year == taxForm.year).
                        Where(p => p.form == taxForm.type).
                        Where(p => p.ammend == lasttaxForm.ammend).
                        Where(p => p.TaxPlayerNumber == taxForm.TaxPlayerDetail.TaxPayerNumber).
                        ToList<dc.Irregular>();

                    foreach (dc.Irregular _renincomeirr in _renincomesirr)
                    {
                        dc.Irregular _ren_incomeirr = new dc.Irregular();
                        _ren_incomeirr.ammend = _renincomeirr.ammend + 1;
                        _ren_incomeirr.createdby = createdby;
                        _ren_incomeirr.createddate = createddate;
                        _ren_incomeirr.updatedby = createdby;
                        _ren_incomeirr.updateddate = createddate;
                        _ren_incomeirr.year = _renincomeirr.year;
                        _ren_incomeirr.TaxPlayerNumber = _renincomeirr.TaxPlayerNumber;
                        _ren_incomeirr.form = _renincomeirr.form;

                        _ren_incomeirr.country = _renincomeirr.country;
                        _ren_incomeirr.data1 = _renincomeirr.data1;
                        _ren_incomeirr.data2 = _renincomeirr.data2;
                        _ren_incomeirr.data3 = _renincomeirr.data3;
                        _ren_incomeirr.data4 = _renincomeirr.data4;
                        _ren_incomeirr.data5 = _renincomeirr.data5;
                        _ren_incomeirr.data6 = _renincomeirr.data6;
                        _ren_incomeirr.data7 = _renincomeirr.data7;
                        _ren_incomeirr.data8 = _renincomeirr.data8;
                        _ren_incomeirr.data9 = _renincomeirr.data9;
                        _ren_incomeirr.data10 = _renincomeirr.data10;

                        dc.Irregular _isexist = _dataContext.Irregulars.
                                    Where(p => p.year == _ren_incomeirr.year).
                                    Where(p => p.form == _ren_incomeirr.form).
                                    Where(p => p.ammend == _ren_incomeirr.ammend).
                                    Where(p => p.TaxPlayerNumber == _ren_incomeirr.TaxPlayerNumber).
                                    Where(p => p.country == _ren_incomeirr.country).
                                    Where(p => p.data1 == _ren_incomeirr.data1).
                                    Where(p => p.data2 == _ren_incomeirr.data2).
                                    Where(p => p.data3 == _ren_incomeirr.data3).
                                    Where(p => p.data4 == _ren_incomeirr.data4).
                                    Where(p => p.data5 == _ren_incomeirr.data5).
                                    Where(p => p.data6 == _ren_incomeirr.data6).
                                    Where(p => p.data7 == _ren_incomeirr.data7).
                                    Where(p => p.data8 == _ren_incomeirr.data8).
                                    Where(p => p.data9 == _ren_incomeirr.data9).
                                    Where(p => p.data10 == _ren_incomeirr.data10).
                                    SingleOrDefault<dc.Irregular>();

                        if (_isexist == null)
                        {
                            _dataContext.Irregulars.InsertOnSubmit(_ren_incomeirr);
                            _dataContext.SubmitChanges();
                        }
                    }
                }
                else
                {
                    //copy overseas detailed
                    List<dc.Overseas_Detailed> _detincomes = _dataContext.Overseas_Detaileds.
                                    Where(p => p.year == taxForm.year).
                                    Where(p => p.form == taxForm.type).
                                    Where(p => p.ammend == lasttaxForm.ammend).
                                    Where(p => p.TaxPlayerNumber == taxForm.TaxPlayerDetail.TaxPayerNumber).
                                    ToList<dc.Overseas_Detailed>();

                    foreach (dc.Overseas_Detailed _detincome in _detincomes)
                    {
                        dc.Overseas_Detailed _det_income = new dc.Overseas_Detailed();
                        _det_income.ammend = _detincome.ammend + 1;
                        _det_income.createdby = createdby;
                        _det_income.createddate = createddate;
                        _det_income.updatedby = createdby;
                        _det_income.updateddate = createddate;
                        _det_income.year = _detincome.year;
                        _det_income.TaxPlayerNumber = _detincome.TaxPlayerNumber;
                        _det_income.form = _detincome.form;

                        _det_income.type = _detincome.type;
                        _det_income.description = _detincome.description;
                        _det_income.line = _detincome.line;
                        _det_income.currency = _detincome.currency;
                        _det_income.dateofreceipt = _detincome.dateofreceipt;
                        _det_income.interval = _detincome.interval;
                        _det_income.exchrate = _detincome.exchrate;
                        _det_income.fullyearincome = _detincome.fullyearincome;
                        _det_income.incomecurrency = _detincome.incomecurrency;
                        _det_income.taxpaidcurrency = _detincome.taxpaidcurrency;
                        _det_income.incomerp = _detincome.incomerp;
                        _det_income.taxpaidrp = _detincome.taxpaidrp;
                        _det_income.treatyrate = _detincome.treatyrate;
                        _det_income.ftc = _detincome.ftc;
                        _det_income.allowedftc = _detincome.allowedftc;
                        _det_income.irregularincome = _detincome.irregularincome;

                        dc.Overseas_Detailed _isexist = _dataContext.Overseas_Detaileds.
                                    Where(p => p.year == _det_income.year).
                                    Where(p => p.form == _det_income.form).
                                    Where(p => p.ammend == _det_income.ammend).
                                    Where(p => p.TaxPlayerNumber == _det_income.TaxPlayerNumber).
                                    Where(p => p.description == _det_income.description).
                                    Where(p => p.exchrate == _det_income.exchrate).
                                    Where(p => p.incomecurrency == _det_income.incomecurrency).
                                    Where(p => p.taxpaidcurrency == _det_income.taxpaidcurrency).
                                    SingleOrDefault<dc.Overseas_Detailed>();

                        if (_isexist == null)
                        {
                            _dataContext.Overseas_Detaileds.InsertOnSubmit(_det_income);
                            _dataContext.SubmitChanges();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return taxForm.id;
        }

        public bool Update(int id, int ammend, string taxidnumber, string type, string year, string updatedby, string updateddate)       
        {
            dc.TaxForm taxForm = null;
            try
            {
                taxForm = _dataContext.TaxForms.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.TaxForm>();
                if (taxForm != null)
                {
                    taxForm.ammend = ammend;
                    taxForm.taxidnumber = taxidnumber;
                    taxForm.type = type;
                    taxForm.year = year;
                    taxForm.updatedby = updatedby;
                    taxForm.updateddate = updateddate;


                    _dataContext.SubmitChanges();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
            
        }
        
        public bool Delete(int id)
        {
            dc.TaxForm taxForm = null;
            try
            {
                taxForm = _dataContext.TaxForms.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.TaxForm>();
                if (taxForm != null)
                {
                    _dataContext.TaxForms.DeleteOnSubmit(taxForm);
                    _dataContext.SubmitChanges();
                }
              
            }
            catch (Exception ex)
            {
                throw ex;
            }        

            return true;
        }
        

        public void Dispose()
        {
            if (_database != null)
            {
                _database.Dispose();
                _database = null;
            }

            if (_dataContext != null)
            {
                _dataContext.Dispose();
                _dataContext = null;
            }
        }
    }
}
