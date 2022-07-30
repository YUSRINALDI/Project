using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Database;
using System.Data.SqlClient;
using dc = DelloiteTRLib.DataContext;

namespace DelloiteTRLib.Repository
{
    public class MaritalRepository
    {
        private SqlServerDatabase _database;
        private dc.DelloiteDataContext _dataContext;

        public MaritalRepository()
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


        public IEnumerable<dc.Marital> FindAll()
        {
            IEnumerable<dc.Marital> maritals = new List<dc.Marital>();
            try
            {
                maritals = _dataContext.Maritals.ToList<dc.Marital>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return maritals;
        }

        public IEnumerable<dc.Marital> FindAllBy(string year, string status, int amount)
        {
            IEnumerable<dc.Marital> maritals = new List<dc.Marital>();

            try
            {
                maritals = from marital in _dataContext.Maritals select marital;
                if (!string.IsNullOrEmpty(year))
                {
                    maritals = maritals.Where(x => x.year.ToLower().Contains(year));
                }

                if (!string.IsNullOrEmpty(status))
                {
                    maritals = maritals.Where(x => x.status.ToLower().Contains(status.ToLower()));
                }
                if (amount != 0)
                {
                    maritals = maritals.Where(x => x.amount == amount);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return maritals;
        }

        public dc.Marital FindByYearAndStatus(string year, string status)
        {
            dc.Marital marital = null;

            try
            {
                marital = _dataContext.Maritals.
                                Where(p => p.year == year).
                                Where(p => p.status.Contains(status)).
                                SingleOrDefault<dc.Marital>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return marital;
        }

        public dc.Marital FindByID(int id)
        {
            dc.Marital marital = null;

            try
            {
                marital = _dataContext.Maritals.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.Marital>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return marital;
        }

        public bool Insert(string year, string status, int amount
            , string createdby, string createddate, string updatedby, string updateddate, int dependant)
        {
            dc.Marital marital = null;
            try
            {
                marital = new dc.Marital();
                marital.year = year;
                marital.status = status;
                marital.amount = amount;
                marital.dependant = dependant;
                marital.createdby = createdby;
                marital.createddate = createddate;
                marital.updatedby = updatedby;
                marital.updateddate = updateddate;


                _dataContext.Maritals.InsertOnSubmit(marital);
                _dataContext.SubmitChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool Update(int id, string year, string status, int amount
            , string updatedby, string updateddate, int dependant)       
        {
            dc.Marital marital = null;
            try
            {
                marital = _dataContext.Maritals.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.Marital>();
                if (marital != null)
                {
                    marital.year = year;
                    marital.status = status;
                    marital.amount = amount;
                    marital.dependant = dependant;
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
            dc.Marital marital = null;
            try
            {
                marital = _dataContext.Maritals.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.Marital>();
                if (marital != null)
                {
                    _dataContext.Maritals.DeleteOnSubmit(marital);
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
