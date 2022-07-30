using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Database;
using System.Data.SqlClient;
using dc = DelloiteTRLib.DataContext;

namespace DelloiteTRLib.Repository
{
    public class TaxPlayerRepository
    {
        private SqlServerDatabase _database;
        private dc.DelloiteDataContext _dataContext;

        public TaxPlayerRepository()
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


        public IEnumerable<dc.TaxPlayerDetail> FindAll()
        {
            IEnumerable<dc.TaxPlayerDetail> taxPlayerDetails = new List<dc.TaxPlayerDetail>();
            try
            {
                taxPlayerDetails = _dataContext.TaxPlayerDetails.ToList<dc.TaxPlayerDetail>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return taxPlayerDetails;
        }

        public IEnumerable<dc.TaxForm> FindTaxFormBy(string taxidnumber)
        {
            IEnumerable<dc.TaxForm> taxForms = new List<dc.TaxForm>();

            try
            {
                taxForms = from taxForm in _dataContext.TaxForms select taxForm;
                if (!string.IsNullOrEmpty(taxidnumber))
                {
                    taxForms = taxForms.Where(x => x.taxidnumber == taxidnumber);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return taxForms;
        }

        public IEnumerable<dc.TaxPlayerDetail> FindAllBy(string userLogon)
        {
            IEnumerable<dc.TaxPlayerDetail> taxPlayerDetails = new List<dc.TaxPlayerDetail>();

            try
            {
                taxPlayerDetails = from taxPlayerDetail in _dataContext.TaxPlayerDetails select taxPlayerDetail;
                /*if (!string.IsNullOrEmpty(userLogon))
                {
                    
                } */
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return taxPlayerDetails;
        }

        public dc.TaxPlayerDetail FindByTaxPayerNumber(string TaxPayerNumber)
        {
            dc.TaxPlayerDetail taxPlayerDetail = null;

            try
            {
                taxPlayerDetail = _dataContext.TaxPlayerDetails.
                                Where(p => p.TaxPayerNumber == TaxPayerNumber).
                                SingleOrDefault<dc.TaxPlayerDetail>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return taxPlayerDetail;
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
