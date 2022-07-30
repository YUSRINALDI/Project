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
    public class OverseaRentalServices
    {
        private OverseasRentalRepository _repository;

        public OverseaRentalServices(OverseasRentalRepository repository)
        {
            _repository = repository;
        }

        public List<vm.OverseasRental> GetAllBy(string TaxPayerNumber, string form, string year)
        {
            List<vm.OverseasRental> models = new List<vm.OverseasRental>();
            IEnumerable<dc.Overseas_Rental> datas = null;

            try
            {
                datas = _repository.GetAllBy(TaxPayerNumber, form, year);

                if (datas != null)
                {
                    foreach (dc.Overseas_Rental data in datas)
                    {
                        vm.OverseasRental model = new vm.OverseasRental();
                        model.id = data.id;
                        model.TaxPlayerNumber = data.TaxPlayerNumber;
                        model.form = data.form;
                        model.year = data.year;
                        model.type = data.type;
                        model.ren_information = data.ren_information;
                        model.ren_country = data.ren_country;
                        model.ren_currency = data.ren_currency;
                        model.ren_dateofreceipt = data.ren_dateofreceipt;
                        model.ren_interval = data.ren_interval;
                        model.ren_exchrate = data.ren_exchrate;
                        model.ren_amountcurrency = data.ren_amountcurrency;
                        model.ren_amountrp = data.ren_amountrp;
                        model.ren_irregularincome = data.ren_irregularincome;
                        model.createdby = data.createdby;
                        model.createddate = data.createddate;
                        model.updatedby = data.updatedby;
                        model.updateddate = data.updateddate;

                        models.Add(model);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return models;
        }

        public List<vm.OverseasRental> GetAllBy(string TaxPayerNumber, string form, string year, int ammend)
        {
            List<vm.OverseasRental> models = new List<vm.OverseasRental>();
            IEnumerable<dc.Overseas_Rental> datas = null;

            try
            {
                datas = _repository.GetAllBy(TaxPayerNumber, form, year, ammend);

                if (datas != null)
                {
                    foreach (dc.Overseas_Rental data in datas)
                    {
                        vm.OverseasRental model = new vm.OverseasRental();
                        model.id = data.id;
                        model.TaxPlayerNumber = data.TaxPlayerNumber;
                        model.form = data.form;
                        model.year = data.year;
                        model.type = data.type;
                        model.ren_information = data.ren_information;
                        model.ren_country = data.ren_country;
                        model.ren_currency = data.ren_currency;
                        model.ren_dateofreceipt = data.ren_dateofreceipt;
                        model.ren_interval = data.ren_interval;
                        model.ren_exchrate = data.ren_exchrate;
                        model.ren_amountcurrency = data.ren_amountcurrency;
                        model.ren_amountrp = data.ren_amountrp;
                        model.ren_irregularincome = data.ren_irregularincome;
                        model.createdby = data.createdby;
                        model.createddate = data.createddate;
                        model.updatedby = data.updatedby;
                        model.updateddate = data.updateddate;

                        models.Add(model);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return models;
        }
        
        public List<vm.OverseasRental> GetAllBy2(string TaxPayerNumber, string form, string year, string country, int ammend)
        {
            List<vm.OverseasRental> models = new List<vm.OverseasRental>();
            IEnumerable<dc.Overseas_Rental> datas = null;

            try
            {
                datas = _repository.GetAllBy2(TaxPayerNumber, form, year, country, ammend);

                if (datas != null)
                {
                    foreach (dc.Overseas_Rental data in datas)
                    {
                        vm.OverseasRental model = new vm.OverseasRental();
                        model.id = data.id;
                        model.TaxPlayerNumber = data.TaxPlayerNumber;
                        model.form = data.form;
                        model.year = data.year;
                        model.type = data.type;
                        model.ren_information = data.ren_information;
                        model.ren_country = data.ren_country;
                        model.ren_currency = data.ren_currency;
                        model.ren_dateofreceipt = data.ren_dateofreceipt;
                        model.ren_interval = data.ren_interval;
                        model.ren_exchrate = data.ren_exchrate;
                        model.ren_amountcurrency = data.ren_amountcurrency;
                        model.ren_amountrp = data.ren_amountrp;
                        model.ren_irregularincome = data.ren_irregularincome;
                        model.createdby = data.createdby;
                        model.createddate = data.createddate;
                        model.updatedby = data.updatedby;
                        model.updateddate = data.updateddate;

                        models.Add(model);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return models;
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

