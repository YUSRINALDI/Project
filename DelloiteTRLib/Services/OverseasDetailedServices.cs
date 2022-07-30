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
    public class OverseasDetailedServices
    {
        private OverseasDetailedRepository _repository;

        public OverseasDetailedServices(OverseasDetailedRepository repository)
        {
            _repository = repository;
        }

        public List<vm.OverseasDetailed> GetAllBy(string TaxPayerNumber, string form, string year, int ammend)
        {
            List<vm.OverseasDetailed> models = new List<vm.OverseasDetailed>();
            IEnumerable<dc.Overseas_Detailed> datas = null;

            try
            {
                datas = _repository.GetAllBy(TaxPayerNumber, form, year, ammend);

                if (datas != null)
                {
                    foreach (dc.Overseas_Detailed data in datas)
                    {
                        vm.OverseasDetailed model = new vm.OverseasDetailed();
                        model.id = data.id;
                        model.TaxPlayerNumber = data.TaxPlayerNumber;
                        model.form = data.form;
                        model.year = data.year;
                        model.type = data.type;
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

