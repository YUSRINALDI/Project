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
    public class IrregularServices
    {
        private IrregularRepository _repository;

        public IrregularServices(IrregularRepository repository)
        {
            _repository = repository;
        }

        public List<vm.Irregular> GetBy(string TaxPayerNumber, string form, string year)
        {
            List<vm.Irregular> models = new List<vm.Irregular>();
            IEnumerable<dc.Irregular> assets = null;

            try
            {
                assets = _repository.GetBy(TaxPayerNumber, form, year);

                if (assets != null)
                {
                    foreach (dc.Irregular asset in assets)
                    {
                        vm.Irregular model = new vm.Irregular();
                        model.id = asset.id;
                        model.TaxPlayerNumber = asset.TaxPlayerNumber;
                        model.form = asset.form;
                        model.year = asset.year;
                        model.data1 = asset.data1;
                        model.data2 = asset.data2;
                        model.data3 = asset.data3;
                        model.data4 = asset.data4;
                        model.data5 = asset.data5;
                        model.data6 = asset.data6;
                        model.data7 = asset.data7;
                        model.data8 = asset.data8;
                        model.data9 = asset.data9;
                        model.data10 = asset.data10;
                        model.createdby = asset.createdby;
                        model.createddate = asset.createddate;
                        model.updatedby = asset.updatedby;
                        model.updateddate = asset.updateddate;

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

        public List<vm.Irregular> GetBy(string TaxPayerNumber, string form, string year, int ammend)
        {
            List<vm.Irregular> models = new List<vm.Irregular>();
            IEnumerable<dc.Irregular> assets = null;

            try
            {
                assets = _repository.GetBy(TaxPayerNumber, form, year, ammend);

                if (assets != null)
                {
                    foreach (dc.Irregular asset in assets)
                    {
                        vm.Irregular model = new vm.Irregular();
                        model.id = asset.id;
                        model.TaxPlayerNumber = asset.TaxPlayerNumber;
                        model.form = asset.form;
                        model.year = asset.year;
                        model.form = asset.form;
                        model.year = asset.year;
                        model.data1 = asset.data1;
                        model.data2 = asset.data2;
                        model.data3 = asset.data3;
                        model.data4 = asset.data4;
                        model.data5 = asset.data5;
                        model.data6 = asset.data6;
                        model.data7 = asset.data7;
                        model.data8 = asset.data8;
                        model.data9 = asset.data9;
                        model.data10 = asset.data10;
                        model.createdby = asset.createdby;
                        model.createddate = asset.createddate;
                        model.updatedby = asset.updatedby;
                        model.updateddate = asset.updateddate;

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

        public List<vm.Irregular> GetAllBy(string TaxPayerNumber, string form, string year, int ammend)
        {
            List<vm.Irregular> models = new List<vm.Irregular>();
            IEnumerable<dc.Irregular> assets = null;

            try
            {
                assets = _repository.GetAllBy(TaxPayerNumber, form, year, ammend);

                if (assets != null)
                {
                    foreach (dc.Irregular asset in assets)
                    {
                        vm.Irregular model = new vm.Irregular();
                        model.id = asset.id;
                        model.TaxPlayerNumber = asset.TaxPlayerNumber;
                        model.form = asset.form;
                        model.year = asset.year;
                        model.country = asset.country;
                        model.data1 = asset.data1;
                        model.data2 = asset.data2;
                        model.data3 = asset.data3;
                        model.data4 = asset.data4;
                        model.data5 = asset.data5;
                        model.data6 = asset.data6;
                        model.data7 = asset.data7;
                        model.data8 = asset.data8;
                        model.data9 = asset.data9;
                        model.data10 = asset.data10;
                        model.createdby = asset.createdby;
                        model.createddate = asset.createddate;
                        model.updatedby = asset.updatedby;
                        model.updateddate = asset.updateddate;

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

