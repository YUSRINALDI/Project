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
    public class AssetServices
    {
        private AssetRepository _repository;

        public AssetServices(AssetRepository repository)
        {
            _repository = repository;
        }

        public List<vm.Asset> GetAssetBy(string TaxPayerNumber, string form, string year)
        {
            List<vm.Asset> models = new List<vm.Asset>();
            IEnumerable<dc.Overseas_Asset> assets = null;

            try
            {
                assets = _repository.GetAssetBy(TaxPayerNumber, form, year);

                if (assets != null)
                {
                    foreach (dc.Overseas_Asset asset in assets)
                    {
                        vm.Asset model = new vm.Asset();
                        model.id = asset.id;
                        model.type = asset.type;
                        model.TaxPlayerNumber = asset.TaxPlayerNumber;
                        model.form = asset.form;
                        model.year = asset.year;
                        model.as_description = asset.Assetsliability.account;
                        model.as_refnumber = asset.as_refnumber;
                        model.as_details = asset.as_details;
                        model.as_currency = asset.as_currency;
                        model.as_balancedate = asset.as_balancedate;
                        model.as_interval = asset.as_interval;
                        model.as_originalcurrency = asset.as_originalcurrency;
                        model.as_exchrate = asset.as_exchrate;
                        model.as_inrupiah = asset.as_inrupiah;
                        model.as_owner = asset.as_owner;
                        model.as_address = asset.as_address;
                        model.as_account = asset.as_account;
                        model.as_country = asset.as_country;
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

        public List<vm.Asset> GetAssetBy(string TaxPayerNumber, string form, string year, int ammend)
        {
            List<vm.Asset> models = new List<vm.Asset>();
            IEnumerable<dc.Overseas_Asset> assets = null;

            try
            {
                assets = _repository.GetAssetBy(TaxPayerNumber, form, year, ammend);

                if (assets != null)
                {
                    foreach (dc.Overseas_Asset asset in assets)
                    {
                        vm.Asset model = new vm.Asset();
                        model.id = asset.id;
                        model.type = asset.type;
                        model.TaxPlayerNumber = asset.TaxPlayerNumber;
                        model.form = asset.form;
                        model.year = asset.year;
                        model.as_description = asset.Assetsliability.account;
                        model.as_refnumber = asset.as_refnumber;
                        model.as_details = asset.as_details;
                        model.as_currency = asset.as_currency;
                        model.as_balancedate = asset.as_balancedate;
                        model.as_interval = asset.as_interval;
                        model.as_originalcurrency = asset.as_originalcurrency;
                        model.as_exchrate = asset.as_exchrate;
                        model.as_inrupiah = asset.as_inrupiah;
                        model.as_owner = asset.as_owner;
                        model.as_address = asset.as_address;
                        model.as_account = asset.as_account;
                        model.as_country = asset.as_country;
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

        public List<vm.Asset> GetAllAssetBy(string TaxPayerNumber, string form, string year, int type, int ammend)
        {
            List<vm.Asset> models = new List<vm.Asset>();
            IEnumerable<dc.Overseas_Asset> assets = null;

            try
            {
                assets = _repository.GetAllAssetBy(TaxPayerNumber, form, year, type, ammend);

                if (assets != null)
                {
                    foreach (dc.Overseas_Asset asset in assets)
                    {
                        vm.Asset model = new vm.Asset();
                        model.id = asset.id;
                        model.type = asset.type;
                        model.TaxPlayerNumber = asset.TaxPlayerNumber;
                        model.form = asset.form;
                        model.year = asset.year;
                        model.ammend = asset.ammend;
                        model.as_description = asset.Assetsliability.account;
                        model.as_refnumber = asset.as_refnumber;
                        model.as_details = asset.as_details;
                        model.as_currency = asset.as_currency;
                        model.as_balancedate = asset.as_balancedate;
                        model.as_interval = asset.as_interval;
                        model.as_originalcurrency = asset.as_originalcurrency;
                        model.as_exchrate = asset.as_exchrate;
                        model.as_inrupiah = asset.as_inrupiah;
                        model.as_owner = asset.as_owner;
                        model.as_address = asset.as_address;
                        model.as_account = asset.as_account;
                        model.as_country = asset.as_country;
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



        public List<vm.Asset> GetLiabilitiesBy(string TaxPayerNumber, string form, string year)
        {
            List<vm.Asset> models = new List<vm.Asset>();
            IEnumerable<dc.Overseas_Asset> assets = null;

            try
            {
                assets = _repository.GetLiabilitiesBy(TaxPayerNumber, form, year);

                if (assets != null)
                {
                    foreach (dc.Overseas_Asset asset in assets)
                    {
                        vm.Asset model = new vm.Asset();
                        model.id = asset.id;
                        model.type = asset.type;
                        model.TaxPlayerNumber = asset.TaxPlayerNumber;
                        model.form = asset.form;
                        model.year = asset.year;
                        model.as_description = asset.Assetsliability.account;
                        model.as_refnumber = asset.as_refnumber;
                        model.as_details = asset.as_details;
                        model.as_currency = asset.as_currency;
                        model.as_balancedate = asset.as_balancedate;
                        model.as_interval = asset.as_interval;
                        model.as_originalcurrency = asset.as_originalcurrency;
                        model.as_exchrate = asset.as_exchrate;
                        model.as_inrupiah = asset.as_inrupiah;
                        model.as_owner = asset.as_owner;
                        model.as_address = asset.as_address;
                        model.as_account = asset.as_account;
                        model.as_country = asset.as_country;
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

