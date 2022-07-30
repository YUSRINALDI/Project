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
    public class OverseasCapitalServices
    {
        private OverseasCapitalRepository _repository;

        public OverseasCapitalServices(OverseasCapitalRepository repository)
        {
            _repository = repository;
        }

        public List<vm.OverseasCapital> GetAllBy(string TaxPayerNumber, string form, string year)
        {
            List<vm.OverseasCapital> models = new List<vm.OverseasCapital>();
            IEnumerable<dc.Overseas_Capital> datas = null;

            try
            {
                datas = _repository.GetAllBy(TaxPayerNumber, form, year);

                if (datas != null)
                {
                    foreach (dc.Overseas_Capital data in datas)
                    {
                        vm.OverseasCapital model = new vm.OverseasCapital();
                        model.id = data.id;
                        model.TaxPlayerNumber = data.TaxPlayerNumber;
                        model.form = data.form;
                        model.year = data.year;
                        model.cap_description = data.cap_description;
                        model.cap_country = data.cap_country;
                        model.cap_currency = data.cap_currency;
                        model.cap_sellingdate = data.cap_sellingdate;
                        model.cap_interval = data.cap_interval;
                        model.cap_exchrate = data.cap_exchrate;
                        model.cap_proceeds = data.cap_proceeds;
                        model.cap_cost = data.cap_cost;
                        model.cap_gainloss = data.cap_gainloss;
                        model.cap_taxpaid = data.cap_taxpaid;
                        model.cap_gainlossrp = data.cap_gainlossrp;
                        model.cap_taxpaidrp = data.cap_taxpaidrp;
                        model.cap_irregularincome = data.cap_irregularincome;
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

        public List<vm.OverseasCapital> GetAllBy(string TaxPayerNumber, string form, string year, int ammend)
        {
            List<vm.OverseasCapital> models = new List<vm.OverseasCapital>();
            IEnumerable<dc.Overseas_Capital> datas = null;

            try
            {
                datas = _repository.GetAllBy(TaxPayerNumber, form, year, ammend);

                if (datas != null)
                {
                    foreach (dc.Overseas_Capital data in datas)
                    {
                        vm.OverseasCapital model = new vm.OverseasCapital();
                        model.id = data.id;
                        model.TaxPlayerNumber = data.TaxPlayerNumber;
                        model.form = data.form;
                        model.year = data.year;
                        model.cap_description = data.cap_description;
                        model.cap_country = data.cap_country;
                        model.cap_currency = data.cap_currency;
                        model.cap_sellingdate = data.cap_sellingdate;
                        model.cap_interval = data.cap_interval;
                        model.cap_exchrate = data.cap_exchrate;
                        model.cap_proceeds = data.cap_proceeds;
                        model.cap_cost = data.cap_cost;
                        model.cap_gainloss = data.cap_gainloss;
                        model.cap_taxpaid = data.cap_taxpaid;
                        model.cap_gainlossrp = data.cap_gainlossrp;
                        model.cap_taxpaidrp = data.cap_taxpaidrp;
                        model.cap_irregularincome = data.cap_irregularincome;
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

        public List<vm.OverseasCapital> GetAllBy2(string TaxPayerNumber, string form, string year, string country, int ammend)
        {
            List<vm.OverseasCapital> models = new List<vm.OverseasCapital>();
            IEnumerable<dc.Overseas_Capital> datas = null;

            try
            {
                datas = _repository.GetAllBy2(TaxPayerNumber, form, year, country, ammend);

                if (datas != null)
                {
                    foreach (dc.Overseas_Capital data in datas)
                    {
                        vm.OverseasCapital model = new vm.OverseasCapital();
                        model.id = data.id;
                        model.TaxPlayerNumber = data.TaxPlayerNumber;
                        model.form = data.form;
                        model.year = data.year;
                        model.cap_description = data.cap_description;
                        model.cap_country = data.cap_country;
                        model.cap_currency = data.cap_currency;
                        model.cap_sellingdate = data.cap_sellingdate;
                        model.cap_interval = data.cap_interval;
                        model.cap_exchrate = data.cap_exchrate;
                        model.cap_proceeds = data.cap_proceeds;
                        model.cap_cost = data.cap_cost;
                        model.cap_gainloss = data.cap_gainloss;
                        model.cap_taxpaid = data.cap_taxpaid;
                        model.cap_gainlossrp = data.cap_gainlossrp;
                        model.cap_taxpaidrp = data.cap_taxpaidrp;
                        model.cap_irregularincome = data.cap_irregularincome;
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

