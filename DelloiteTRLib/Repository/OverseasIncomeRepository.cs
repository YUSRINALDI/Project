using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Database;
using System.Data.SqlClient;
using dc = DelloiteTRLib.DataContext;

namespace DelloiteTRLib.Repository
{
    public class OverseasIncomeRepository
    {
        private SqlServerDatabase _database;
        private dc.DelloiteDataContext _dataContext;

        public OverseasIncomeRepository()
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

        public IEnumerable<dc.Overseas_Income> GetAllBy(string TaxPayerNumber, string form, string year)
        {
            IEnumerable<dc.Overseas_Income> datas = new List<dc.Overseas_Income>();

            try
            {
                datas = from data in _dataContext.Overseas_Incomes select data;
                if (!string.IsNullOrEmpty(TaxPayerNumber))
                {
                    datas = datas.Where(x => x.TaxPlayerNumber.Contains(TaxPayerNumber));
                }
                if (!string.IsNullOrEmpty(form))
                {
                    datas = datas.Where(x => x.form.Contains(form));
                }
                if (!string.IsNullOrEmpty(year))
                {
                    datas = datas.Where(x => x.year.Contains(year));
                }
                datas = datas.Where(x => x.irregularincome == "yes");
                datas = datas.OrderBy(x => x.country);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datas;
        }

        public IEnumerable<dc.Overseas_Income> GetAllBy2(string TaxPayerNumber, string form, string year, int type)
        {
            IEnumerable<dc.Overseas_Income> datas = new List<dc.Overseas_Income>();

            try
            {
                datas = from data in _dataContext.Overseas_Incomes select data;
                if (!string.IsNullOrEmpty(TaxPayerNumber))
                {
                    datas = datas.Where(x => x.TaxPlayerNumber.Contains(TaxPayerNumber));
                }
                if (!string.IsNullOrEmpty(form))
                {
                    datas = datas.Where(x => x.form.Contains(form));
                }
                if (!string.IsNullOrEmpty(year))
                {
                    datas = datas.Where(x => x.year.Contains(year));
                }
                if (type!=0)
                {
                    datas = datas.Where(x => x.type==type);
                }
                datas = datas.OrderBy(x=>x.country);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datas;
        }

        public IEnumerable<dc.Overseas_Income> GetAllBy3(string TaxPayerNumber, string form, string year, string country, int type, int ammend)
        {
            IEnumerable<dc.Overseas_Income> datas = new List<dc.Overseas_Income>();

            try
            {
                datas = from data in _dataContext.Overseas_Incomes select data;
                if (!string.IsNullOrEmpty(TaxPayerNumber))
                {
                    datas = datas.Where(x => x.TaxPlayerNumber.Contains(TaxPayerNumber));
                }
                if (!string.IsNullOrEmpty(form))
                {
                    datas = datas.Where(x => x.form.Contains(form));
                }
                if (!string.IsNullOrEmpty(year))
                {
                    datas = datas.Where(x => x.year.Contains(year));
                }
                if (!string.IsNullOrEmpty(country))
                {
                    datas = datas.Where(x => x.country == country);
                }
                if (type != 0)
                {
                    datas = datas.Where(x => x.type == type);
                }
                if (ammend != null)
                {
                    datas = datas.Where(x => x.ammend == ammend);
                }
                datas = datas.OrderBy(x => x.country);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datas;
        }

        public IEnumerable<dc.Overseas_Detailed> GetAllDetailedBy2(string TaxPayerNumber, string form, string year, int type, int ammend)
        {
            IEnumerable<dc.Overseas_Detailed> datas = new List<dc.Overseas_Detailed>();

            try
            {
                datas = from data in _dataContext.Overseas_Detaileds select data;
                if (!string.IsNullOrEmpty(TaxPayerNumber))
                {
                    datas = datas.Where(x => x.TaxPlayerNumber.Contains(TaxPayerNumber));
                }
                if (!string.IsNullOrEmpty(form))
                {
                    datas = datas.Where(x => x.form.Contains(form));
                }
                if (!string.IsNullOrEmpty(year))
                {
                    datas = datas.Where(x => x.year.Contains(year));
                }
                if (type != 0)
                {
                    datas = datas.Where(x => x.type == type);
                }
                if (ammend != null)
                {
                    datas = datas.Where(x => x.ammend == ammend);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datas;
        }

        public bool Delete(int id)
        {
            dc.Overseas_Income data = null;
            try
            {
                data = _dataContext.Overseas_Incomes.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.Overseas_Income>();
                if (data != null)
                {
                    _dataContext.Overseas_Incomes.DeleteOnSubmit(data);
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
