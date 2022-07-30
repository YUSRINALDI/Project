using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Database;
using System.Data.SqlClient;
using dc = DelloiteTRLib.DataContext;

namespace DelloiteTRLib.Repository
{
    public class OverseasRentalRepository
    {
        private SqlServerDatabase _database;
        private dc.DelloiteDataContext _dataContext;

        public OverseasRentalRepository()
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

        public IEnumerable<dc.Overseas_Rental> GetAllBy(string TaxPayerNumber, string form, string year)
        {
            IEnumerable<dc.Overseas_Rental> datas = new List<dc.Overseas_Rental>();

            try
            {
                datas = from data in _dataContext.Overseas_Rentals select data;
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
                datas = datas.OrderBy(x => x.ren_country);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datas;
        }

        public IEnumerable<dc.Overseas_Rental> GetAllBy(string TaxPayerNumber, string form, string year, int ammend)
        {
            IEnumerable<dc.Overseas_Rental> datas = new List<dc.Overseas_Rental>();

            try
            {
                datas = from data in _dataContext.Overseas_Rentals select data;
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
                if (ammend != null)
                {
                    datas = datas.Where(x => x.ammend == ammend);
                }
                datas = datas.OrderBy(x => x.ren_country);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datas;
        }

        public IEnumerable<dc.Overseas_Rental> GetAllBy2(string TaxPayerNumber, string form, string year, string country, int ammend)
        {
            IEnumerable<dc.Overseas_Rental> datas = new List<dc.Overseas_Rental>();

            try
            {
                datas = from data in _dataContext.Overseas_Rentals select data;
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
                    datas = datas.Where(x => x.ren_country==country);
                }
                if (ammend != null)
                {
                    datas = datas.Where(x => x.ammend==ammend);
                }
                datas = datas.OrderBy(x => x.ren_country);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datas;
        }

        public bool Delete(int id)
        {
            dc.Overseas_Rental data = null;
            try
            {
                data = _dataContext.Overseas_Rentals.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.Overseas_Rental>();
                if (data != null)
                {
                    _dataContext.Overseas_Rentals.DeleteOnSubmit(data);
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
