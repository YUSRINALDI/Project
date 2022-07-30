using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Database;
using System.Data.SqlClient;
using dc = DelloiteTRLib.DataContext;

namespace DelloiteTRLib.Repository
{
    public class RelationshipRepository
    {
        private SqlServerDatabase _database;
        private dc.DelloiteDataContext _dataContext;

        public RelationshipRepository()
        {
        }

        public void SetDatabase(SqlServerDatabase database)
        {
            _database = database;
        }

        public void SetDataContext(dc.DelloiteDataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public IEnumerable<dc.Relationship> FindAll()
        {
            IEnumerable<dc.Relationship> relationships = new List<dc.Relationship>();
            try
            {
                relationships = _dataContext.Relationships.ToList<dc.Relationship>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return relationships;
        }

        public IEnumerable<dc.Relationship> FindAllBy(string relationship)
        {
            IEnumerable<dc.Relationship> relationships = new List<dc.Relationship>();

            try
            {
                relationships = from relation in _dataContext.Relationships select relation;
                if (!string.IsNullOrEmpty(relationship))
                {
                    relationships = relationships.Where(x => x.relationship1.ToLower().Contains(relationship));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return relationships;
        }

        public dc.Relationship FindByID(int id)
        {
            dc.Relationship relationship = null;

            try
            {
                relationship = _dataContext.Relationships.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.Relationship>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return relationship;
        }

        public bool Insert(string relationship
            , string createdby, string createddate, string updatedby, string updateddate)
        {
            dc.Relationship relation = null;
            try
            {
                relation = new dc.Relationship();
                relation.relationship1 = relationship;
                relation.createdby = createdby;
                relation.createddate = createddate;
                relation.updatedby = updatedby;
                relation.updateddate = updateddate;


                _dataContext.Relationships.InsertOnSubmit(relation);
                _dataContext.SubmitChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool Update(int id, string relationship
            , string updatedby, string updateddate)       
        {
            dc.Relationship relation = null;
            try
            {
                relation = _dataContext.Relationships.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.Relationship>();
                if (relation != null)
                {
                    relation.relationship1 = relationship;
                    relation.updatedby = updatedby;
                    relation.updateddate = updateddate;


                    _dataContext.SubmitChanges();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
            
        }
        
        public bool Delete(int id)
        {
            dc.Relationship relation = null;
            try
            {
                relation = _dataContext.Relationships.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.Relationship>();
                if (relation != null)
                {
                    _dataContext.Relationships.DeleteOnSubmit(relation);
                    _dataContext.SubmitChanges();
                }
              
            }
            catch (Exception ex)
            {
                throw ex;
            }        

            return true;
        }
        

        public void Dispose()
        {
            if (_database != null)
            {
                _database.Dispose();
                _database = null;
            }

            if (_dataContext != null)
            {
                _dataContext.Dispose();
                _dataContext = null;
            }
        }
    }
}
