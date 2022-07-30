using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Database;
using System.Data.SqlClient;
using dc = DelloiteTRLib.DataContext;

namespace DelloiteTRLib.Repository
{
    public class ecRepository
    {
        private SqlServerDatabase _database;
        private dc.DelloiteDataContext _dataContext;

        public ecRepository()
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

        public dc.Emp_CompanyDet get(int ParticularId)
        {
            dc.Emp_CompanyDet data = null;

            try
            {
                data = _dataContext.Emp_CompanyDets.
                                Where(p => p.ParticularId == ParticularId).
                                SingleOrDefault<dc.Emp_CompanyDet>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
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
