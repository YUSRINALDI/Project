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
    public class AssetsliabilitiesServices
    {
        private AssetsliabilitiesRepository _assetsliabilitiesRepository;

        public AssetsliabilitiesServices(AssetsliabilitiesRepository repository)
        {
            _assetsliabilitiesRepository = repository;
        }


        public List<vm.Assetsliabilities> GetAll()
        {

            List<vm.Assetsliabilities> vmAssetsliabilitiess = new List<vm.Assetsliabilities>();
            IEnumerable<dc.Assetsliability> assetsliabilitiess = null;
            try
            {
                assetsliabilitiess = _assetsliabilitiesRepository.FindAll();
                if (assetsliabilitiess != null)
                {

                    foreach (dc.Assetsliability assetsliabilities in assetsliabilitiess)
                    {
                        vm.Assetsliabilities vmAssetsliabilities = new vm.Assetsliabilities();
                        vmAssetsliabilities.id = assetsliabilities.id;
                        vmAssetsliabilities.form = assetsliabilities.form;
                        vmAssetsliabilities.code = assetsliabilities.code;
                        vmAssetsliabilities.account = assetsliabilities.account;
                        vmAssetsliabilities.createdby = assetsliabilities.createdby;
                        vmAssetsliabilities.createddate = assetsliabilities.createddate;
                        vmAssetsliabilities.updatedby = assetsliabilities.updatedby;
                        vmAssetsliabilities.updateddate = assetsliabilities.updateddate;

                        vmAssetsliabilitiess.Add(vmAssetsliabilities);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmAssetsliabilitiess;
        }

        public List<vm.Assetsliabilities> GetAllBy(string code, string account)
        {
            List<vm.Assetsliabilities> vmAssetsliabilitiess = new List<vm.Assetsliabilities>();
            IEnumerable<dc.Assetsliability> assetsliabilitiess = null;

            try
            {
                assetsliabilitiess = _assetsliabilitiesRepository.FindAllBy(code, account);

                if (assetsliabilitiess != null)
                {
                    foreach (dc.Assetsliability assetsliabilities in assetsliabilitiess)
                    {
                        vm.Assetsliabilities vmAssetsliabilities = new vm.Assetsliabilities();
                        vmAssetsliabilities.id = assetsliabilities.id;
                        vmAssetsliabilities.form = assetsliabilities.form;
                        vmAssetsliabilities.code = assetsliabilities.code;
                        vmAssetsliabilities.account = assetsliabilities.account;
                        vmAssetsliabilities.createdby = assetsliabilities.createdby;
                        vmAssetsliabilities.createddate = assetsliabilities.createddate;
                        vmAssetsliabilities.updatedby = assetsliabilities.updatedby;
                        vmAssetsliabilities.updateddate = assetsliabilities.updateddate;

                        vmAssetsliabilitiess.Add(vmAssetsliabilities);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmAssetsliabilitiess;
        }

        public vm.Assetsliabilities GetByID(int id)
        {
            vm.Assetsliabilities vmAssetsliabilities = null;
            dc.Assetsliability assetsliabilities = null;

            try
            {
                assetsliabilities = _assetsliabilitiesRepository.FindByID(id);
                if (assetsliabilities != null)
                {
                    vmAssetsliabilities = new vm.Assetsliabilities();
                    vmAssetsliabilities.id = assetsliabilities.id;
                    vmAssetsliabilities.form = assetsliabilities.form;
                    vmAssetsliabilities.code = assetsliabilities.code;
                    vmAssetsliabilities.account = assetsliabilities.account;
                    vmAssetsliabilities.createdby = assetsliabilities.createdby;
                    vmAssetsliabilities.createddate = assetsliabilities.createddate;
                    vmAssetsliabilities.updatedby = assetsliabilities.updatedby;
                    vmAssetsliabilities.updateddate = assetsliabilities.updateddate;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmAssetsliabilities;
        }

        public bool Create(string form, string code, string account
            , string createdby, string createddate, string updatedby, string updateddate)
        {
            bool boolInsert = false;
            try
            {
                boolInsert = _assetsliabilitiesRepository.Insert(form, code, account
            , createdby, createddate, updatedby, updateddate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return boolInsert;
        }

        public bool Update(int id, string form, string code, string account
            , string createdby, string createddate, string updatedby, string updateddate)
        {
            bool boolUpdate = false;
            try
            {
                boolUpdate = _assetsliabilitiesRepository.Update(id, form, code, account
            , updatedby, updateddate);
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
                boolDelete = _assetsliabilitiesRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return boolDelete;
        }

        public void Dispose()
        {
            if (_assetsliabilitiesRepository != null)
            {
                _assetsliabilitiesRepository.Dispose();
                _assetsliabilitiesRepository = null;
            }
        }

    }
}

