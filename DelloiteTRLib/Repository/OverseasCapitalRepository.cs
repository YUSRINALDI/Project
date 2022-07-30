using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Database;
using System.Data.SqlClient;
using dc = DelloiteTRLib.DataContext;

namespace DelloiteTRLib.Repository
{
    public class OverseasCapitalRepository
    {
        private SqlServerDatabase _database;
        private dc.DelloiteDataContext _dataContext;

        public OverseasCapitalRepository()
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

        public IEnumerable<dc.Overseas_Capital> GetAllBy(string TaxPayerNumber, string form, string year)
        {
            IEnumerable<dc.Overseas_Capital> datas = new List<dc.Overseas_Capital>();

            try
            {
                datas = from data in _dataContext.Overseas_Capitals select data;
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
                datas = datas.OrderBy(x => x.cap_country);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datas;
        }

        public IEnumerable<dc.Overseas_Capital> GetAllBy(string TaxPayerNumber, string form, string year, int ammend)
        {
            IEnumerable<dc.Overseas_Capital> datas = new List<dc.Overseas_Capital>();

            try
            {
                datas = from data in _dataContext.Overseas_Capitals select data;
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
                if (ammend!= null)
                {
                    datas = datas.Where(x => x.ammend == ammend);
                }
                datas = datas.OrderBy(x => x.cap_country);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datas;
        }


        public IEnumerable<dc.Overseas_Capital> GetAllBy2(string TaxPayerNumber, string form, string year, string country, int ammend)
        {
            IEnumerable<dc.Overseas_Capital> datas = new List<dc.Overseas_Capital>();

            try
            {
                datas = from data in _dataContext.Overseas_Capitals select data;
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
                    datas = datas.Where(x => x.cap_country == country);
                }
                if (ammend != null)
                {
                    datas = datas.Where(x => x.ammend == ammend);
                }
                datas = datas.OrderBy(x => x.cap_country);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datas;
        }

        public bool Delete(int id)
        {
            dc.Overseas_Capital data = null;
            try
            {
                data = _dataContext.Overseas_Capitals.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.Overseas_Capital>();
                if (data != null)
                {
                    _dataContext.Overseas_Capitals.DeleteOnSubmit(data);
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
