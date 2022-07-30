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
    public class OverseaIncomeServices
    {
        private OverseasIncomeRepository _repository;

        public OverseaIncomeServices(OverseasIncomeRepository repository)
        {
            _repository = repository;
        }

        public List<vm.OverseasIncome> GetAllBy(string TaxPayerNumber, string form, string year)
        {
            List<vm.OverseasIncome> models = new List<vm.OverseasIncome>();
            IEnumerable<dc.Overseas_Income> datas = null;

            try
            {
                datas = _repository.GetAllBy(TaxPayerNumber, form, year);

                if (datas != null)
                {
                    foreach (dc.Overseas_Income data in datas)
                    {
                        vm.OverseasIncome model = new vm.OverseasIncome();
                        model.id = data.id;
                        model.TaxPlayerNumber = data.TaxPlayerNumber;
                        model.form = data.form;
                        model.year = data.year;
                        model.type = data.type;
                        model.country = data.country;
                        model.currency = data.currency;
                        model.dateofreceipt = data.dateofreceipt;
                        model.interval = data.interval;
                        model.exchrate = data.exchrate;
                        model.incomecurrency = data.incomecurrency;
                        model.taxpaidcurrency = data.taxpaidcurrency;
                        model.incomerp = data.incomerp;
                        model.taxpaidrp = data.taxpaidrp;
                        model.treatyrate = data.treatyrate;
                        model.ftc = data.ftc;
                        model.allowedftc = data.allowedftc;
                        model.irregularincome = data.irregularincome;
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

        public List<vm.OverseasIncome> GetAllBy2(string TaxPayerNumber, string form, string year, int type)
        {
            List<vm.OverseasIncome> models = new List<vm.OverseasIncome>();
            IEnumerable<dc.Overseas_Income> datas = null;

            try
            {
                datas = _repository.GetAllBy2(TaxPayerNumber, form, year, type);

                if (datas != null)
                {
                    foreach (dc.Overseas_Income data in datas)
                    {
                        vm.OverseasIncome model = new vm.OverseasIncome();
                        model.id = data.id;
                        model.TaxPlayerNumber = data.TaxPlayerNumber;
                        model.form = data.form;
                        model.year = data.year;
                        model.type = data.type;
                        model.country = data.country;
                        model.currency = data.currency;
                        model.dateofreceipt = data.dateofreceipt;
                        model.interval = data.interval;
                        model.exchrate = data.exchrate;
                        model.incomecurrency = data.incomecurrency;
                        model.taxpaidcurrency = data.taxpaidcurrency;
                        model.incomerp = data.incomerp;
                        model.taxpaidrp = data.taxpaidrp;
                        model.treatyrate = data.treatyrate;
                        model.ftc = data.ftc;
                        model.allowedftc = data.allowedftc;
                        model.irregularincome = data.irregularincome;
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



        public List<vm.OverseasIncome> GetAllBy3(string TaxPayerNumber, string form, string year, string country, int type, int ammend)
        {
            List<vm.OverseasIncome> models = new List<vm.OverseasIncome>();
            IEnumerable<dc.Overseas_Income> datas = null;

            try
            {
                datas = _repository.GetAllBy3(TaxPayerNumber, form, year, country, type, ammend);

                if (datas != null)
                {
                    foreach (dc.Overseas_Income data in datas)
                    {
                        vm.OverseasIncome model = new vm.OverseasIncome();
                        model.id = data.id;
                        model.TaxPlayerNumber = data.TaxPlayerNumber;
                        model.form = data.form;
                        model.year = data.year;
                        model.type = data.type;
                        model.country = data.country;
                        model.currency = data.currency;
                        model.dateofreceipt = data.dateofreceipt;
                        model.interval = data.interval;
                        model.exchrate = data.exchrate;
                        model.incomecurrency = data.incomecurrency;
                        model.taxpaidcurrency = data.taxpaidcurrency;
                        model.incomerp = data.incomerp;
                        model.taxpaidrp = data.taxpaidrp;
                        model.treatyrate = data.treatyrate;
                        model.ftc = data.ftc;
                        model.allowedftc = data.allowedftc;
                        model.irregularincome = data.irregularincome;
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

        public List<vm.OverseasIncome> GetAllDetailedBy2(string TaxPayerNumber, string form, string year, int type, int ammend)
        {
            List<vm.OverseasIncome> models = new List<vm.OverseasIncome>();
            IEnumerable<dc.Overseas_Detailed> datas = null;

            try
            {
                datas = _repository.GetAllDetailedBy2(TaxPayerNumber, form, year, type, ammend);

                if (datas != null)
                {
                    foreach (dc.Overseas_Detailed data in datas)
                    {
                        vm.OverseasIncome model = new vm.OverseasIncome();
                        model.id = data.id;
                        model.TaxPlayerNumber = data.TaxPlayerNumber;
                        model.form = data.form;
                        model.year = data.year;
                        model.type = data.type;
                        model.description = data.description;
                        model.line = data.line;
                        model.fullyearincome = data.fullyearincome;
                        model.currency = data.currency;
                        model.dateofreceipt = data.dateofreceipt;
                        model.interval = data.interval;
                        model.exchrate = data.exchrate;
                        model.incomecurrency = data.incomecurrency;
                        model.taxpaidcurrency = data.taxpaidcurrency;
                        model.incomerp = data.incomerp;
                        model.taxpaidrp = data.taxpaidrp;
                        model.treatyrate = data.treatyrate;
                        model.ftc = data.ftc;
                        model.allowedftc = data.allowedftc;
                        model.irregularincome = data.irregularincome;
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

