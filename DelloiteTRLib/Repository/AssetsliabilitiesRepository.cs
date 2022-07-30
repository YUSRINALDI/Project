using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Database;
using System.Data.SqlClient;
using dc = DelloiteTRLib.DataContext;

namespace DelloiteTRLib.Repository
{
    public class AssetsliabilitiesRepository
    {
        private SqlServerDatabase _database;
        private dc.DelloiteDataContext _dataContext;

        public AssetsliabilitiesRepository()
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


        public IEnumerable<dc.Assetsliability> FindAll()
        {
            IEnumerable<dc.Assetsliability> assetsliabilitys = new List<dc.Assetsliability>();
            try
            {
                assetsliabilitys = _dataContext.Assetsliabilities.ToList<dc.Assetsliability>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return assetsliabilitys;
        }

        public IEnumerable<dc.Assetsliability> FindAllBy(string code, string account)
        {
            IEnumerable<dc.Assetsliability> assetsliabilitys = new List<dc.Assetsliability>();

            try
            {
                assetsliabilitys = from marital in _dataContext.Assetsliabilities select marital;
                if (!string.IsNullOrEmpty(code))
                {
                    assetsliabilitys = assetsliabilitys.Where(x => x.code.ToLower().Contains(code));
                }

                if (!string.IsNullOrEmpty(account))
                {
                    assetsliabilitys = assetsliabilitys.Where(x => x.account.ToLower().Contains(account.ToLower()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return assetsliabilitys;
        }

        public dc.Assetsliability FindByID(int id)
        {
            dc.Assetsliability marital = null;

            try
            {
                marital = _dataContext.Assetsliabilities.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.Assetsliability>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return marital;
        }

        public bool Insert(string form, string code, string account
            , string createdby, string createddate, string updatedby, string updateddate)
        {
            dc.Assetsliability marital = null;
            try
            {
                marital = new dc.Assetsliability();
                marital.form = form;
                marital.code = code;
                marital.account = account;
                marital.createdby = createdby;
                marital.createddate = createddate;
                marital.updatedby = updatedby;
                marital.updateddate = updateddate;


                _dataContext.Assetsliabilities.InsertOnSubmit(marital);
                _dataContext.SubmitChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool Update(int id, string form, string code, string account
            , string updatedby, string updateddate)       
        {
            dc.Assetsliability marital = null;
            try
            {
                marital = _dataContext.Assetsliabilities.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.Assetsliability>();
                if (marital != null)
                {
                    marital.form = form;
                    marital.code = code;
                    marital.account = account;
                    marital.updatedby = updatedby;
                    marital.updateddate = updateddate;


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
            dc.Assetsliability marital = null;
            try
            {
                marital = _dataContext.Assetsliabilities.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.Assetsliability>();
                if (marital != null)
                {
                    _dataContext.Assetsliabilities.DeleteOnSubmit(marital);
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
