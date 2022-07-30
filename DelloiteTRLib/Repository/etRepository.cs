using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Database;
using System.Data.SqlClient;
using dc = DelloiteTRLib.DataContext;

namespace DelloiteTRLib.Repository
{
    public class etRepository
    {
        private SqlServerDatabase _database;
        private dc.DelloiteDataContext _dataContext;

        public etRepository()
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

        public IEnumerable<dc.EngagementTeam> CheckAdminCalculation(string userlogon)
        {
            IEnumerable<dc.EngagementTeam> datas = new List<dc.EngagementTeam>();

            try
            {
                //datas = from data in _dataContext.EngagementTeams select data;
                datas = _dataContext.EngagementTeams.ToList<dc.EngagementTeam>();
                if (!string.IsNullOrEmpty(userlogon))
                {
                    datas = datas.Where(x => 
                        x.AIC1 == userlogon ||
                        x.AIC2 == userlogon ||
                        x.AIC3 == userlogon
                        );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datas;
        }

        public IEnumerable<dc.EngagementTeam> gets(string Company_Key, string userlogon)
        {
            IEnumerable<dc.EngagementTeam> datas = new List<dc.EngagementTeam>();

            try
            {
                //datas = from data in _dataContext.EngagementTeams select data;
                datas = _dataContext.EngagementTeams.ToList<dc.EngagementTeam>();

                if (!string.IsNullOrEmpty(Company_Key))
                {
                    datas = datas.Where(x => x.Company_Key == Company_Key);
                }
                if (!string.IsNullOrEmpty(userlogon))
                {
                    datas = datas.Where(x => x.PIC == userlogon||
                        x.MIC == userlogon ||
                        x.AMIC == userlogon ||
                        x.AMIC2 == userlogon ||
                        x.SIC == userlogon ||
                        x.SIC2 == userlogon ||
                        x.AIC1 == userlogon ||
                        x.AIC2 == userlogon ||
                        x.AIC3 == userlogon
                        );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datas;
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
