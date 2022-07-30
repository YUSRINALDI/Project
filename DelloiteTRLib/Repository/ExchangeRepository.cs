using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Database;
using System.Data.SqlClient;
using dc = DelloiteTRLib.DataContext;

namespace DelloiteTRLib.Repository
{
    public class ExchangeRepository
    {
        private SqlServerDatabase _database;
        private dc.DelloiteDataContext _dataContext;

        public ExchangeRepository()
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


        public IEnumerable<dc.Exchange> FindAll()
        {
            IEnumerable<dc.Exchange> exchanges = new List<dc.Exchange>();
            try
            {
                exchanges = _dataContext.Exchanges.ToList<dc.Exchange>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exchanges;
        }

        public IEnumerable<dc.Exchange> FindAllBy(string country, string currency, string year, string interval, int amount, int type)
        {
            IEnumerable<dc.Exchange> exchanges = new List<dc.Exchange>();

            try
            {
                exchanges = from exchange in _dataContext.Exchanges select exchange;
                if (!string.IsNullOrEmpty(country))
                {
                    exchanges = exchanges.Where(x => x.country.ToLower().Contains(country));
                }

                if (!string.IsNullOrEmpty(currency))
                {
                    exchanges = exchanges.Where(x => x.currency.ToLower().Contains(currency.ToLower()));
                }

                if (!string.IsNullOrEmpty(year))
                {
                    exchanges = exchanges.Where(x => x.year.ToLower().Contains(year));
                }

                if (!string.IsNullOrEmpty(interval))
                {
                    exchanges = exchanges.Where(x => x.interval.ToLower().Contains(interval.ToLower()));
                }
                if (amount != 0)
                {
                    exchanges = exchanges.Where(x => x.amount == amount);
                }
                if (type != 0)
                {
                    exchanges = exchanges.Where(x => x.type == type);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exchanges;
        }

        public dc.Exchange FindByID(int id)
        {
            dc.Exchange exchange = null;

            try
            {
                exchange = _dataContext.Exchanges.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.Exchange>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exchange;
        }

        public bool Insert(string country, string currency, string year, string interval, double amount, int type, string createdby, string createddate, string updatedby, string updateddate)
        {
            dc.Exchange exchange = null;
            try
            {
                exchange = new dc.Exchange();
                exchange.country = country;
                exchange.currency = currency;
                exchange.year = year;
                exchange.interval = interval;
                exchange.amount = amount;
                exchange.type = type;
                exchange.createdby = createdby;
                exchange.createddate = createddate;
                exchange.updatedby = updatedby;
                exchange.updateddate = updateddate;

                _dataContext.Exchanges.InsertOnSubmit(exchange);
                _dataContext.SubmitChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool Update(int id, string country, string currency, string year, string interval, double amount, int type, string updatedby, string updateddate)       
        {
            dc.Exchange exchange = null;
            try
            {
                exchange = _dataContext.Exchanges.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.Exchange>();
                if (exchange != null)
                {
                    exchange.country = country;
                    exchange.currency = currency;
                    exchange.year = year;
                    exchange.interval = interval;
                    exchange.amount = amount;
                    exchange.type = type;
                    exchange.updatedby = updatedby;
                    exchange.updateddate = updateddate;

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
            dc.Exchange exchange = null;
            try
            {
                exchange = _dataContext.Exchanges.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.Exchange>();
                if (exchange != null)
                {
                    _dataContext.Exchanges.DeleteOnSubmit(exchange);
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
