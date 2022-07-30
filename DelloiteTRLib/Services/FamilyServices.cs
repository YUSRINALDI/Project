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
    public class FamilyServices
    {
        private FamilyRepository _repository;

        public FamilyServices(FamilyRepository repository)
        {
            _repository = repository;
        }


        public List<vm.Family> GetAll()
        {

            List<vm.Family> vmFamilies = new List<vm.Family>();
            IEnumerable<dc.Family> families = null;
            try
            {
                families = _repository.FindAll();
                if (families != null)
                {

                    foreach (dc.Family family in families)
                    {
                        vm.Family vmFamily = new vm.Family();
                        vmFamily.id = family.id;
                        vmFamily.TaxPlayerNumber = family.TaxPayerNumber;
                        vmFamily.Name = family.Name;
                        vmFamily.Relationship = family.Relationship1.relationship1;
                        vmFamily.Birthdate = family.Birthdate;
                        vmFamily.Occupation = family.Occupation;
                        vmFamily.NIK = family.NIK;
                        vmFamily.createdby = family.createdby;
                        vmFamily.createddate = family.createddate;
                        vmFamily.updatedby = family.updatedby;
                        vmFamily.updateddate = family.updateddate;

                        vmFamilies.Add(vmFamily);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmFamilies;
        }

        public List<vm.Family> GetAllBy(string TaxPayerNumber, string form, string year, int ammend)
        {
            List<vm.Family> vmFamilies = new List<vm.Family>();
            IEnumerable<dc.Family> families = null;

            try
            {
                families = _repository.GetAllBy(TaxPayerNumber, form, year, ammend);

                if (families != null)
                {
                    foreach (dc.Family family in families)
                    {
                        vm.Family vmFamily = new vm.Family();
                        vmFamily.id = family.id;
                        vmFamily.TaxPlayerNumber = family.TaxPayerNumber;
                        vmFamily.Name = family.Name;
                        vmFamily.form = family.form;
                        vmFamily.year = family.year;
                        vmFamily.Relationship = family.Relationship1.relationship1;
                        vmFamily.Birthdate = family.Birthdate;
                        vmFamily.Occupation = family.Occupation;
                        vmFamily.NIK = family.NIK;
                        vmFamily.createdby = family.createdby;
                        vmFamily.createddate = family.createddate;
                        vmFamily.updatedby = family.updatedby;
                        vmFamily.updateddate = family.updateddate;

                        vmFamilies.Add(vmFamily);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmFamilies;
        }



        public List<vm.Family> GetAllBy(string TaxPayerNumber)
        {
            List<vm.Family> vmFamilies = new List<vm.Family>();
            IEnumerable<dc.Family> families = null;

            try
            {
                families = _repository.FindAllBy(TaxPayerNumber);

                if (families != null)
                {
                    foreach (dc.Family family in families)
                    {
                        vm.Family vmFamily = new vm.Family();
                        vmFamily.id = family.id;
                        vmFamily.TaxPlayerNumber = family.TaxPayerNumber;
                        vmFamily.Name = family.Name;
                        vmFamily.form = family.form;
                        vmFamily.year = family.year;
                        vmFamily.Relationship = family.Relationship1.relationship1;
                        vmFamily.Birthdate = family.Birthdate;
                        vmFamily.Occupation = family.Occupation;
                        vmFamily.NIK = family.NIK;
                        vmFamily.createdby = family.createdby;
                        vmFamily.createddate = family.createddate;
                        vmFamily.updatedby = family.updatedby;
                        vmFamily.updateddate = family.updateddate;

                        vmFamilies.Add(vmFamily);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmFamilies;
        }

        public vm.Family GetByID(int id)
        {
            vm.Family vmFamily = null;
            dc.Family family = null;

            try
            {
                family = _repository.FindByID(id);
                if (family != null)
                {
                    vmFamily = new vm.Family();
                    vmFamily.id = family.id;
                    vmFamily.TaxPlayerNumber = family.TaxPayerNumber;
                    vmFamily.Name = family.Name;
                    vmFamily.Relationship = family.Relationship1.relationship1;
                    vmFamily.Birthdate = family.Birthdate;
                    vmFamily.Occupation = family.Occupation;
                    vmFamily.NIK = family.NIK;
                    vmFamily.createdby = family.createdby;
                    vmFamily.createddate = family.createddate;
                    vmFamily.updatedby = family.updatedby;
                    vmFamily.updateddate = family.updateddate;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmFamily;
        }

        public bool Create(string TaxPayerNumber, string Name, int Relationship,
            string Birthdate, string Occupation, string NIK, 
            string createdby, string createddate, string updatedby, string updateddate)
        {
            bool boolInsert = false;
            try
            {
                boolInsert = _repository.Insert(TaxPayerNumber, Name, Relationship, Birthdate, 
                    Occupation, NIK, createdby, createddate, updatedby, updateddate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return boolInsert;
        }

        public bool Update(int id, string TaxPayerNumber, string Name, int Relationship,
            string Birthdate, string Occupation, string NIK, 
            string createdby, string createddate, string updatedby, string updateddate)
        {
            bool boolUpdate = false;
            try
            {
                boolUpdate = _repository.Update(id, TaxPayerNumber, Name, Relationship, Birthdate,
                    Occupation, NIK, updatedby, updateddate);
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

