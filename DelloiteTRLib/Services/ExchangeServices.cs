using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Repository;
using vm = DelloiteTRLib.Model;
using dc = DelloiteTRLib.DataContext;
using System.Security.Cryptography;

namespace DelloiteTRLib.Services
{
    public class ExchangeServices
    {
        private ExchangeRepository _repository;

        public ExchangeServices(ExchangeRepository repository)
        {
            _repository = repository;
        }


        public List<vm.Exchange> GetAll()
        {

            List<vm.Exchange> vmExchanges = new List<vm.Exchange>();
            IEnumerable<dc.Exchange> exchanges = null;
            try
            {
                exchanges = _repository.FindAll();
                if (exchanges != null)
                {

                    foreach (dc.Exchange marital in exchanges)
                    {
                        vm.Exchange vmMarital = new vm.Exchange();
                        vmMarital.id = marital.id;
                        vmMarital.country = marital.country;
                        vmMarital.currency = marital.currency;
                        vmMarital.year = marital.year;
                        vmMarital.interval = marital.interval;
                        vmMarital.amount = marital.amount;
                        vmMarital.type = marital.type;
                        vmMarital.createdby = marital.createdby;
                        vmMarital.createddate = marital.createddate;
                        vmMarital.updatedby = marital.updatedby;
                        vmMarital.updateddate = marital.updateddate;

                        vmExchanges.Add(vmMarital);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmExchanges;
        }

        public List<vm.Exchange> GetAllBy(string country, string currency, string year, string interval, int amount, int type)
        {
            List<vm.Exchange> vmExchanges = new List<vm.Exchange>();
            IEnumerable<dc.Exchange> exchanges = null;

            try
            {
                exchanges = _repository.FindAllBy(country, currency, year, interval, amount, type);

                if (exchanges != null)
                {
                    foreach (dc.Exchange marital in exchanges)
                    {
                        vm.Exchange vmMarital = new vm.Exchange();
                        vmMarital.id = marital.id;
                        vmMarital.country = marital.country;
                        vmMarital.currency = marital.currency;
                        vmMarital.year = marital.year;
                        vmMarital.interval = marital.interval;
                        vmMarital.amount = marital.amount;
                        vmMarital.type = marital.type;
                        vmMarital.createdby = marital.createdby;
                        vmMarital.createddate = marital.createddate;
                        vmMarital.updatedby = marital.updatedby;
                        vmMarital.updateddate = marital.updateddate;

                        vmExchanges.Add(vmMarital);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmExchanges;
        }

        public vm.Exchange GetByID(int id)
        {
            vm.Exchange vmMarital = null;
            dc.Exchange marital = null;

            try
            {
                marital = _repository.FindByID(id);
                if (marital != null)
                {
                    vmMarital = new vm.Exchange();
                    vmMarital.id = marital.id;
                    vmMarital.country = marital.country;
                    vmMarital.currency = marital.currency;
                    vmMarital.year = marital.year;
                    vmMarital.interval = marital.interval;
                    vmMarital.amount = marital.amount;
                    vmMarital.type = marital.type;
                    vmMarital.createdby = marital.createdby;
                    vmMarital.createddate = marital.createddate;
                    vmMarital.updatedby = marital.updatedby;
                    vmMarital.updateddate = marital.updateddate;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmMarital;
        }

        public bool Create(string country, string currency, string year, string interval, double amount, int type, string createdby, string createddate, string updatedby, string updateddate)
        {
            bool boolInsert = false;
            try
            {
                boolInsert = _repository.Insert(country, currency, year, interval, amount, type, createdby, createddate, updatedby, updateddate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return boolInsert;
        }

        public bool Update(int id, string country, string currency, string year, string interval, double amount, int type, string createdby, string createddate, string updatedby, string updateddate)
        {
            bool boolUpdate = false;
            try
            {
                boolUpdate = _repository.Update(id, country, currency, year, interval, amount, type, updatedby, updateddate);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return boolUpdate;
        }

        public bool Delete(int id)
        {
            bool boolDelete = false;
            try
            {
                boolDelete = _repository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return boolDelete;
        }

        public void Dispose()
        {
            if (_repository != null)
            {
                _repository.Dispose();
                _repository = null;
            }
        }

    }
}

