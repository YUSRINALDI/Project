using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Database;
using System.Data.SqlClient;
using dc = DelloiteTRLib.DataContext;

namespace DelloiteTRLib.Repository
{
    public class FamilyRepository
    {
        private SqlServerDatabase _database;
        private dc.DelloiteDataContext _dataContext;

        public FamilyRepository()
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


        public IEnumerable<dc.Family> FindAll()
        {
            IEnumerable<dc.Family> families = new List<dc.Family>();
            try
            {
                families = _dataContext.Families.ToList<dc.Family>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return families;
        }

        public IEnumerable<dc.Family> FindAllBy(string TaxPayerNumber)
        {
            IEnumerable<dc.Family> families = new List<dc.Family>();

            try
            {
                families = from family in _dataContext.Families select family;
                if (!string.IsNullOrEmpty(TaxPayerNumber))
                {
                    families = families.Where(x => x.TaxPayerNumber.Contains(TaxPayerNumber));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return families;
        }

        public IEnumerable<dc.Family> GetAllBy(string TaxPayerNumber, string form, string year, int ammend)
        {
            IEnumerable<dc.Family> families = new List<dc.Family>();

            try
            {
                families = from family in _dataContext.Families select family;
                if (!string.IsNullOrEmpty(TaxPayerNumber))
                {
                    families = families.Where(x => x.TaxPayerNumber.Contains(TaxPayerNumber));
                }
                if (!string.IsNullOrEmpty(form))
                {
                    families = families.Where(x => x.form.Contains(form));
                }
                if (!string.IsNullOrEmpty(year))
                {
                    families = families.Where(x => x.year.Contains(year));
                }
                if (ammend!=null)
                {
                    families = families.Where(x => x.ammend == ammend);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return families;
        }

        public dc.Family FindByID(int id)
        {
            dc.Family family = null;

            try
            {
                family = _dataContext.Families.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.Family>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return family;
        }

        public bool Insert(string TaxPayerNumber, string Name, int Relationship, 
            string Birthdate, string Occupation, string NIK, 
            string createdby, string createddate, string updatedby, string updateddate)
        {
            dc.Family family = null;
            try
            {
                family = new dc.Family();
                family.TaxPayerNumber = TaxPayerNumber;
                family.Name = Name;
                family.Relationship = Relationship;
                family.Birthdate = Birthdate;
                family.Occupation = Occupation;
                family.NIK = NIK;
                family.createdby = createdby;
                family.createddate = createddate;
                family.updatedby = updatedby;
                family.updateddate = updateddate;


                _dataContext.Families.InsertOnSubmit(family);
                _dataContext.SubmitChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool Update(int id, string TaxPayerNumber, string Name, int Relationship,
            string Birthdate, string Occupation, string NIK, string updatedby, string updateddate)       
        {
            dc.Family family = null;
            try
            {
                family = _dataContext.Families.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.Family>();
                if (family != null)
                {
                    family.TaxPayerNumber = TaxPayerNumber;
                    family.Name = Name;
                    family.Relationship = Relationship;
                    family.Birthdate = Birthdate;
                    family.Occupation = Occupation;
                    family.NIK = NIK;
                    family.updatedby = updatedby;
                    family.updateddate = updateddate;


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
            dc.Family family = null;
            try
            {
                family = _dataContext.Families.
                                Where(p => p.id == id).
                                SingleOrDefault<dc.Family>();
                if (family != null)
                {
                    _dataContext.Families.DeleteOnSubmit(family);
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
