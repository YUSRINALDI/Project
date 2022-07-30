using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Database;
using System.Data.SqlClient;
using dc = DelloiteTRLib.DataContext;

namespace DelloiteTRLib.Repository
{
    public class IEIncomeRepository
    {
        private SqlServerDatabase _database;
        private dc.DelloiteDataContext _dataContext;

        public IEIncomeRepository()
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


        public IEnumerable<dc.IEIncome> FindAll()
        {
            IEnumerable<dc.IEIncome> iEIncomes = new List<dc.IEIncome>();
            try
            {
                iEIncomes = _dataContext.IEIncomes.ToList<dc.IEIncome>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return iEIncomes;
        }

        public IEnumerable<dc.IEIncome> FindAllBy(string TaxPayerNumber)
        {
            IEnumerable<dc.IEIncome> iEIncomes = new List<dc.IEIncome>();

            try
            {
                iEIncomes = from iEIncome in _dataContext.IEIncomes select iEIncome;
                if (!string.IsNullOrEmpty(TaxPayerNumber))
                {
                    iEIncomes = iEIncomes.Where(x => x.TaxPlayerNumber.Contains(TaxPayerNumber));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return iEIncomes;
        }

        public IEnumerable<dc.IEIncome> GetAllBy(string TaxPayerNumber, string form, string year)
        {
            IEnumerable<dc.IEIncome> iEIncomes = new List<dc.IEIncome>();

            try
            {
                iEIncomes = from iEIncome in _dataContext.IEIncomes select iEIncome;
                if (!string.IsNullOrEmpty(TaxPayerNumber))
                {
                    iEIncomes = iEIncomes.Where(x => x.TaxPlayerNumber.Contains(TaxPayerNumber));
                }
                if (!string.IsNullOrEmpty(form))
                {
                    iEIncomes = iEIncomes.Where(x => x.form.Contains(form));
                }
                if (!string.IsNullOrEmpty(year))
                {
                    iEIncomes = iEIncomes.Where(x => x.year.Contains(year));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return iEIncomes;
        }

        public IEnumerable<dc.IEIncome> GetAllBy(string TaxPayerNumber, string form, string year, int ammend)
        {
            IEnumerable<dc.IEIncome> iEIncomes = new List<dc.IEIncome>();

            try
            {
                iEIncomes = from iEIncome in _dataContext.IEIncomes select iEIncome;
                if (!string.IsNullOrEmpty(TaxPayerNumber))
                {
                    iEIncomes = iEIncomes.Where(x => x.TaxPlayerNumber.Contains(TaxPayerNumber));
                }
                if (!string.IsNullOrEmpty(form))
                {
                    iEIncomes = iEIncomes.Where(x => x.form.Contains(form));
                }
                if (!string.IsNullOrEmpty(year))
                {
                    iEIncomes = iEIncomes.Where(x => x.year.Contains(year));
                }
                if (ammend != null)
                {
                    iEIncomes = iEIncomes.Where(x => x.ammend == ammend);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return iEIncomes;
        }

        public dc.IEIncome FindByID(int id)
        {
            dc.IEIncome iEIncome = null;

            try
            {
                iEIncome = _dataContext.IEIncomes.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.IEIncome>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return iEIncome;
        }

        public dc.IEIncome GetEmployName(string taxpayernumber)
        {
            dc.IEIncome iEIncome = null;

            try
            {
                iEIncome = _dataContext.IEIncomes.
                                Where(p => p.TaxPlayerNumber == taxpayernumber).
                                First<dc.IEIncome>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return iEIncome;
        }

        public bool Insert(string TaxPayerNumber, string field1, string field2, string field3
            , string field4, string field5, string field6, string field7, string field8, string field9
            , string field10, string field11, string field12, string field13, string field14, 
            string field15, string field16, string field17, string field18, string field19, 
            string field20, string field21, string field22, string field23, string createdby, 
            string createddate, string updatedby, string updateddate)
        {
            dc.IEIncome iEIncome = null;
            try
            {
                iEIncome = new dc.IEIncome();
                iEIncome.TaxPlayerNumber = TaxPayerNumber;
                iEIncome.field1 = field1;
                iEIncome.field2 = field2;
                iEIncome.field3 = field3;
                iEIncome.field4 = field4;
                iEIncome.field5 = field5;
                iEIncome.field6 = field6;
                iEIncome.field7 = field7;
                iEIncome.field8 = field8;
                iEIncome.field9 = field9;
                iEIncome.field10 = field10;
                iEIncome.field11 = field11;
                iEIncome.field12 = field12;
                iEIncome.field13 = field13;
                iEIncome.field14 = field14;
                iEIncome.field15 = field15;
                iEIncome.field16 = field16;
                iEIncome.field17 = field17;
                iEIncome.field18 = field18;
                iEIncome.field19 = field19;
                iEIncome.field20 = field20;
                iEIncome.field21 = field21;
                iEIncome.field22 = field22;
                iEIncome.field23 = field23;
                iEIncome.createdby = createdby;
                iEIncome.createddate = createddate;
                iEIncome.updatedby = updatedby;
                iEIncome.updateddate = updateddate;


                _dataContext.IEIncomes.InsertOnSubmit(iEIncome);
                _dataContext.SubmitChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool Update(int id, string TaxPayerNumber, string field1, string field2, string field3
            , string field4, string field5, string field6, string field7, string field8, string field9
            , string field10, string field11, string field12, string field13, string field14,
            string field15, string field16, string field17, string field18, string field19,
            string field20, string field21, string field22, string field23, string updatedby, 
            string updateddate)       
        {
            dc.IEIncome iEIncome = null;
            try
            {
                iEIncome = _dataContext.IEIncomes.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.IEIncome>();
                if (iEIncome != null)
                {
                    iEIncome.TaxPlayerNumber = TaxPayerNumber;
                    iEIncome.field1 = field1;
                    iEIncome.field2 = field2;
                    iEIncome.field3 = field3;
                    iEIncome.field4 = field4;
                    iEIncome.field5 = field5;
                    iEIncome.field6 = field6;
                    iEIncome.field7 = field7;
                    iEIncome.field8 = field8;
                    iEIncome.field9 = field9;
                    iEIncome.field10 = field10;
                    iEIncome.field11 = field11;
                    iEIncome.field12 = field12;
                    iEIncome.field13 = field13;
                    iEIncome.field14 = field14;
                    iEIncome.field15 = field15;
                    iEIncome.field16 = field16;
                    iEIncome.field17 = field17;
                    iEIncome.field18 = field18;
                    iEIncome.field19 = field19;
                    iEIncome.field20 = field20;
                    iEIncome.field21 = field21;
                    iEIncome.field22 = field22;
                    iEIncome.field23 = field23;
                    iEIncome.updatedby = updatedby;
                    iEIncome.updateddate = updateddate;


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
            dc.IEIncome iEIncome = null;
            try
            {
                iEIncome = _dataContext.IEIncomes.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.IEIncome>();
                if (iEIncome != null)
                {
                    _dataContext.IEIncomes.DeleteOnSubmit(iEIncome);
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
