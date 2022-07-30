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
    public class RelationshipServices
    {
        private RelationshipRepository _repository;

        public RelationshipServices(RelationshipRepository repository)
        {
            _repository = repository;
        }


        public List<vm.Relationship> GetAll()
        {

            List<vm.Relationship> vmRelationships = new List<vm.Relationship>();
            IEnumerable<dc.Relationship> relationships = null;
            try
            {
                relationships = _repository.FindAll();
                if (relationships != null)
                {

                    foreach (dc.Relationship relation in relationships)
                    {
                        vm.Relationship vmMarital = new vm.Relationship();
                        vmMarital.id = relation.id;
                        vmMarital.relationship = relation.relationship1;
                        vmMarital.createdby = relation.createdby;
                        vmMarital.createddate = relation.createddate;
                        vmMarital.updatedby = relation.updatedby;
                        vmMarital.updateddate = relation.updateddate;

                        vmRelationships.Add(vmMarital);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmRelationships;
        }

        public List<vm.Relationship> GetAllBy(string relationship)
        {
            List<vm.Relationship> vmRelationships = new List<vm.Relationship>();
            IEnumerable<dc.Relationship> relationships = null;

            try
            {
                relationships = _repository.FindAllBy(relationship);

                if (relationships != null)
                {
                    foreach (dc.Relationship relation in relationships)
                    {
                        vm.Relationship vmRelationship = new vm.Relationship();
                        vmRelationship.id = relation.id;
                        vmRelationship.relationship = relation.relationship1;
                        vmRelationship.createdby = relation.createdby;
                        vmRelationship.createddate = relation.createddate;
                        vmRelationship.updatedby = relation.updatedby;
                        vmRelationship.updateddate = relation.updateddate;

                        vmRelationships.Add(vmRelationship);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmRelationships;
        }

        public vm.Relationship GetByID(int id)
        {
            vm.Relationship vmMarital = null;
            dc.Relationship relation = null;

            try
            {
                relation = _repository.FindByID(id);
                if (relation != null)
                {
                    vmMarital = new vm.Relationship();
                    vmMarital.id = relation.id;
                    vmMarital.relationship = relation.relationship1;
                    vmMarital.createdby = relation.createdby;
                    vmMarital.createddate = relation.createddate;
                    vmMarital.updatedby = relation.updatedby;
                    vmMarital.updateddate = relation.updateddate;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmMarital;
        }

        public bool Create(string relationship
            , string createdby, string createddate, string updatedby, string updateddate)
        {
            bool boolInsert = false;
            try
            {
                boolInsert = _repository.Insert(relationship
            , createdby, createddate, updatedby, updateddate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return boolInsert;
        }

        public bool Update(int id, string relationship
            , string createdby, string createddate, string updatedby, string updateddate)
        {
            bool boolUpdate = false;
            try
            {
                boolUpdate = _repository.Update(id, relationship
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

