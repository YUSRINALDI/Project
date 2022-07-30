using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Database;
using System.Data.SqlClient;
using dc = DelloiteTRLib.DataContext;

namespace DelloiteTRLib.Repository
{
    public class AssetRepository
    {
        private SqlServerDatabase _database;
        private dc.DelloiteDataContext _dataContext;

        public AssetRepository()
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

        public IEnumerable<dc.Overseas_Asset> GetAllAssetBy(string TaxPayerNumber, string form, string year, int type, int ammend)
        {
            IEnumerable<dc.Overseas_Asset> datas = new List<dc.Overseas_Asset>();

            try
            {
                datas = from data in _dataContext.Overseas_Assets select data;
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
                if (type!=-1)
                {
                    datas = datas.Where(x => x.type == type);
                }
                
                datas = datas.Where(x => x.ammend == ammend);
                datas = datas.OrderBy(x => x.as_refnumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datas;
        }

        public IEnumerable<dc.Overseas_Asset> GetAssetBy(string TaxPayerNumber, string form, string year)
        {
            IEnumerable<dc.Overseas_Asset> datas = new List<dc.Overseas_Asset>();

            try
            {
                datas = from data in _dataContext.Overseas_Assets select data;
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
                datas = datas.Where(x => x.type <= 6);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datas;
        }

        public IEnumerable<dc.Overseas_Asset> GetAssetBy(string TaxPayerNumber, string form, string year, int ammend)
        {
            IEnumerable<dc.Overseas_Asset> datas = new List<dc.Overseas_Asset>();

            try
            {
                datas = from data in _dataContext.Overseas_Assets select data;
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
                    datas = datas.Where(x => x.ammend ==ammend);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datas;
        }

        public IEnumerable<dc.Overseas_Asset> GetLiabilitiesBy(string TaxPayerNumber, string form, string year)
        {
            IEnumerable<dc.Overseas_Asset> datas = new List<dc.Overseas_Asset>();

            try
            {
                datas = from data in _dataContext.Overseas_Assets select data;
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
                datas = datas.Where(x => x.type==10);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datas;
        }

        public bool Delete(int id)
        {
            dc.Overseas_Asset data = null;
            try
            {
                data = _dataContext.Overseas_Assets.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.Overseas_Asset>();
                if (data != null)
                {
                    _dataContext.Overseas_Assets.DeleteOnSubmit(data);
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
