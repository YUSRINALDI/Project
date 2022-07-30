using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Database;
using System.Data.SqlClient;
using dc = DelloiteTRLib.DataContext;

namespace DelloiteTRLib.Repository
{
    public class OverseasDetailedRepository
    {
        private SqlServerDatabase _database;
        private dc.DelloiteDataContext _dataContext;

        public OverseasDetailedRepository()
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

        public IEnumerable<dc.Overseas_Detailed> GetAllBy(string TaxPayerNumber, string form, string year, int ammend)
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
            dc.Overseas_Detailed Overseas_Detailed = null;
            try
            {
                Overseas_Detailed = _dataContext.Overseas_Detaileds.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.Overseas_Detailed>();
                if (Overseas_Detailed != null)
                {
                    _dataContext.Overseas_Detaileds.DeleteOnSubmit(Overseas_Detailed);
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
