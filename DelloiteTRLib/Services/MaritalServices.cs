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
    public class MaritalServices
    {
        private MaritalRepository _maritalRepository;

        public MaritalServices(MaritalRepository repository)
        {
            _maritalRepository = repository;
        }


        public List<vm.Marital> GetAll()
        {

            List<vm.Marital> vmMaritals = new List<vm.Marital>();
            IEnumerable<dc.Marital> maritals = null;
            try
            {
                maritals = _maritalRepository.FindAll();
                if (maritals != null)
                {

                    foreach (dc.Marital marital in maritals)
                    {
                        vm.Marital vmMarital = new vm.Marital();
                        vmMarital.id = marital.id;
                        vmMarital.year = marital.year;
                        vmMarital.status = marital.status;
                        vmMarital.amount = marital.amount;
                        vmMarital.dependant = marital.dependant;
                        vmMarital.createdby = marital.createdby;
                        vmMarital.createddate = marital.createddate;
                        vmMarital.updatedby = marital.updatedby;
                        vmMarital.updateddate = marital.updateddate;

                        vmMaritals.Add(vmMarital);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmMaritals;
        }

        public List<vm.Marital> GetAllBy(string year, string status, int amount)
        {
            List<vm.Marital> vmMaritals = new List<vm.Marital>();
            IEnumerable<dc.Marital> maritals = null;

            try
            {
                maritals = _maritalRepository.FindAllBy(year, status, amount);

                if (maritals != null)
                {
                    foreach (dc.Marital marital in maritals)
                    {
                        vm.Marital vmMarital = new vm.Marital();
                        vmMarital.id = marital.id;
                        vmMarital.year = marital.year;
                        vmMarital.status = marital.status;
                        vmMarital.amount = marital.amount;
                        vmMarital.dependant = marital.dependant;
                        vmMarital.createdby = marital.createdby;
                        vmMarital.createddate = marital.createddate;
                        vmMarital.updatedby = marital.updatedby;
                        vmMarital.updateddate = marital.updateddate;

                        vmMaritals.Add(vmMarital);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmMaritals;
        }



        public vm.Marital GetByYearAndStatus(string year, string status)
        {
            vm.Marital vmMarital = null;
            dc.Marital marital = null;

            try
            {
                marital = _maritalRepository.FindByYearAndStatus(year, status);
                if (marital != null)
                {
                    vmMarital = new vm.Marital();
                    vmMarital.id = marital.id;
                    vmMarital.year = marital.year;
                    vmMarital.status = marital.status;
                    vmMarital.amount = marital.amount;
                    vmMarital.dependant = marital.dependant;
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

        public vm.Marital GetByID(int id)
        {
            vm.Marital vmMarital = null;
            dc.Marital marital = null;

            try
            {
                marital = _maritalRepository.FindByID(id);
                if (marital != null)
                {
                    vmMarital = new vm.Marital();
                    vmMarital.id = marital.id;
                    vmMarital.year = marital.year;
                    vmMarital.status = marital.status;
                    vmMarital.amount = marital.amount;
                    vmMarital.dependant = marital.dependant;
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

        public bool Create(string year, string status, int amount
            , string createdby, string createddate, string updatedby, string updateddate, int dependant)
        {
            bool boolInsert = false;
            try
            {
                boolInsert = _maritalRepository.Insert(year, status, amount
            , createdby, createddate, updatedby, updateddate, dependant);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return boolInsert;
        }

        public bool Update(int id, string year, string status, int amount
            , string createdby, string createddate, string updatedby, string updateddate, int dependant)
        {
            bool boolUpdate = false;
            try
            {
                boolUpdate = _maritalRepository.Update(id, year, status, amount
            , updatedby, updateddate, dependant);
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
                boolDelete = _maritalRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return boolDelete;
        }

        public void Dispose()
        {
            if (_maritalRepository != null)
            {
                _maritalRepository.Dispose();
                _maritalRepository = null;
            }
        }

    }
}

