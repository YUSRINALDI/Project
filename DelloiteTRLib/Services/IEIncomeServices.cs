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
    public class IEIncomeServices
    {
        private IEIncomeRepository _repository;

        public IEIncomeServices(IEIncomeRepository repository)
        {
            _repository = repository;
        }


        public List<vm.IEIncome> GetAll()
        {

            List<vm.IEIncome> vmIEIncomes = new List<vm.IEIncome>();
            IEnumerable<dc.IEIncome> iEIncomes = null;
            try
            {
                iEIncomes = _repository.FindAll();
                if (iEIncomes != null)
                {

                    foreach (dc.IEIncome iEIncome in iEIncomes)
                    {
                        vm.IEIncome vmIEIncome = new vm.IEIncome();
                        vmIEIncome.id = iEIncome.id;
                        vmIEIncome.TaxPlayerNumber = iEIncome.TaxPlayerNumber;
                        vmIEIncome.field1 = iEIncome.field1;
                        vmIEIncome.field2 = iEIncome.field2;
                        vmIEIncome.field3 = iEIncome.field3;
                        vmIEIncome.field4 = iEIncome.field4;
                        vmIEIncome.field5 = iEIncome.field5;
                        vmIEIncome.field6 = iEIncome.field6;
                        vmIEIncome.field7 = iEIncome.field7;
                        vmIEIncome.field8 = iEIncome.field8;
                        vmIEIncome.field9 = iEIncome.field9;
                        vmIEIncome.field10 = iEIncome.field10;
                        vmIEIncome.field11 = iEIncome.field11;
                        vmIEIncome.field12 = iEIncome.field12;
                        vmIEIncome.field13 = iEIncome.field13;
                        vmIEIncome.field14 = iEIncome.field14;
                        vmIEIncome.field15 = iEIncome.field15;
                        vmIEIncome.field16 = iEIncome.field16;
                        vmIEIncome.field17 = iEIncome.field17;
                        vmIEIncome.field18 = iEIncome.field18;
                        vmIEIncome.field19 = iEIncome.field19;
                        vmIEIncome.field20 = iEIncome.field20;
                        vmIEIncome.field21 = iEIncome.field21;
                        vmIEIncome.field22 = iEIncome.field22;
                        vmIEIncome.field23 = iEIncome.field23;
                        vmIEIncome.createdby = iEIncome.createdby;
                        vmIEIncome.createddate = iEIncome.createddate;
                        vmIEIncome.updatedby = iEIncome.updatedby;
                        vmIEIncome.updateddate = iEIncome.updateddate;

                        vmIEIncomes.Add(vmIEIncome);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmIEIncomes;
        }

        public List<vm.IEIncome> GetAllBy(string TaxPayerNumber)
        {
            List<vm.IEIncome> vmIEIncomes = new List<vm.IEIncome>();
            IEnumerable<dc.IEIncome> iEIncomes = null;

            try
            {
                iEIncomes = _repository.FindAllBy(TaxPayerNumber);

                if (iEIncomes != null)
                {
                    foreach (dc.IEIncome iEIncome in iEIncomes)
                    {
                        vm.IEIncome vmIEIncome = new vm.IEIncome();
                        vmIEIncome.id = iEIncome.id;
                        vmIEIncome.TaxPlayerNumber = iEIncome.TaxPlayerNumber;
                        vmIEIncome.field1 = iEIncome.field1;
                        vmIEIncome.field2 = iEIncome.field2;
                        vmIEIncome.field3 = iEIncome.field3;
                        vmIEIncome.field4 = iEIncome.field4;
                        vmIEIncome.field5 = iEIncome.field5;
                        vmIEIncome.field6 = iEIncome.field6;
                        vmIEIncome.field7 = iEIncome.field7;
                        vmIEIncome.field8 = iEIncome.field8;
                        vmIEIncome.field9 = iEIncome.field9;
                        vmIEIncome.field10 = iEIncome.field10;
                        vmIEIncome.field11 = iEIncome.field11;
                        vmIEIncome.field12 = iEIncome.field12;
                        vmIEIncome.field13 = iEIncome.field13;
                        vmIEIncome.field14 = iEIncome.field14;
                        vmIEIncome.field15 = iEIncome.field15;
                        vmIEIncome.field16 = iEIncome.field16;
                        vmIEIncome.field17 = iEIncome.field17;
                        vmIEIncome.field18 = iEIncome.field18;
                        vmIEIncome.field19 = iEIncome.field19;
                        vmIEIncome.field20 = iEIncome.field20;
                        vmIEIncome.field21 = iEIncome.field21;
                        vmIEIncome.field22 = iEIncome.field22;
                        vmIEIncome.field23 = iEIncome.field23;
                        vmIEIncome.createdby = iEIncome.createdby;
                        vmIEIncome.createddate = iEIncome.createddate;
                        vmIEIncome.updatedby = iEIncome.updatedby;
                        vmIEIncome.updateddate = iEIncome.updateddate;

                        vmIEIncomes.Add(vmIEIncome);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmIEIncomes;
        }

        public List<vm.IEIncome> GetAllBy(string TaxPayerNumber, string form, string year)
        {
            List<vm.IEIncome> vmIEIncomes = new List<vm.IEIncome>();
            IEnumerable<dc.IEIncome> iEIncomes = null;

            try
            {
                iEIncomes = _repository.GetAllBy(TaxPayerNumber, form, year);

                if (iEIncomes != null)
                {
                    foreach (dc.IEIncome iEIncome in iEIncomes)
                    {
                        vm.IEIncome vmIEIncome = new vm.IEIncome();
                        vmIEIncome.id = iEIncome.id;
                        vmIEIncome.TaxPlayerNumber = iEIncome.TaxPlayerNumber;
                        vmIEIncome.form = iEIncome.form;
                        vmIEIncome.year = iEIncome.year;
                        vmIEIncome.field1 = iEIncome.field1;
                        vmIEIncome.field2 = iEIncome.field2;
                        vmIEIncome.field3 = iEIncome.field3;
                        vmIEIncome.field4 = iEIncome.field4;
                        vmIEIncome.field5 = iEIncome.field5;
                        vmIEIncome.field6 = iEIncome.field6;
                        vmIEIncome.field7 = iEIncome.field7;
                        vmIEIncome.field8 = iEIncome.field8;
                        vmIEIncome.field9 = iEIncome.field9;
                        vmIEIncome.field10 = iEIncome.field10;
                        vmIEIncome.field11 = iEIncome.field11;
                        vmIEIncome.field12 = iEIncome.field12;
                        vmIEIncome.field13 = iEIncome.field13;
                        vmIEIncome.field14 = iEIncome.field14;
                        vmIEIncome.field15 = iEIncome.field15;
                        vmIEIncome.field16 = iEIncome.field16;
                        vmIEIncome.field17 = iEIncome.field17;
                        vmIEIncome.field18 = iEIncome.field18;
                        vmIEIncome.field19 = iEIncome.field19;
                        vmIEIncome.field20 = iEIncome.field20;
                        vmIEIncome.field21 = iEIncome.field21;
                        vmIEIncome.field22 = iEIncome.field22;
                        vmIEIncome.field23 = iEIncome.field23;
                        vmIEIncome.field24 = iEIncome.field24;
                        vmIEIncome.field25 = iEIncome.field25;
                        vmIEIncome.field26 = iEIncome.field26;
                        vmIEIncome.field27 = iEIncome.field27;
                        vmIEIncome.field28 = iEIncome.field28;
                        vmIEIncome.field29 = iEIncome.field29;
                        vmIEIncome.createdby = iEIncome.createdby;
                        vmIEIncome.createddate = iEIncome.createddate;
                        vmIEIncome.updatedby = iEIncome.updatedby;
                        vmIEIncome.updateddate = iEIncome.updateddate;

                        vmIEIncomes.Add(vmIEIncome);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmIEIncomes;
        }

        public List<vm.IEIncome> GetAllBy(string TaxPayerNumber, string form, string year, int ammend)
        {
            List<vm.IEIncome> vmIEIncomes = new List<vm.IEIncome>();
            IEnumerable<dc.IEIncome> iEIncomes = null;

            try
            {
                iEIncomes = _repository.GetAllBy(TaxPayerNumber, form, year, ammend);

                if (iEIncomes != null)
                {
                    foreach (dc.IEIncome iEIncome in iEIncomes)
                    {
                        vm.IEIncome vmIEIncome = new vm.IEIncome();
                        vmIEIncome.id = iEIncome.id;
                        vmIEIncome.TaxPlayerNumber = iEIncome.TaxPlayerNumber;
                        vmIEIncome.form = iEIncome.form;
                        vmIEIncome.year = iEIncome.year;
                        vmIEIncome.field1 = iEIncome.field1;
                        vmIEIncome.field2 = iEIncome.field2;
                        vmIEIncome.field3 = iEIncome.field3;
                        vmIEIncome.field4 = iEIncome.field4;
                        vmIEIncome.field5 = iEIncome.field5;
                        vmIEIncome.field6 = iEIncome.field6;
                        vmIEIncome.field7 = iEIncome.field7;
                        vmIEIncome.field8 = iEIncome.field8;
                        vmIEIncome.field9 = iEIncome.field9;
                        vmIEIncome.field10 = iEIncome.field10;
                        vmIEIncome.field11 = iEIncome.field11;
                        vmIEIncome.field12 = iEIncome.field12;
                        vmIEIncome.field13 = iEIncome.field13;
                        vmIEIncome.field14 = iEIncome.field14;
                        vmIEIncome.field15 = iEIncome.field15;
                        vmIEIncome.field16 = iEIncome.field16;
                        vmIEIncome.field17 = iEIncome.field17;
                        vmIEIncome.field18 = iEIncome.field18;
                        vmIEIncome.field19 = iEIncome.field19;
                        vmIEIncome.field20 = iEIncome.field20;
                        vmIEIncome.field21 = iEIncome.field21;
                        vmIEIncome.field22 = iEIncome.field22;
                        vmIEIncome.field23 = iEIncome.field23;
                        vmIEIncome.field24 = iEIncome.field24;
                        vmIEIncome.field25 = iEIncome.field25;
                        vmIEIncome.field26 = iEIncome.field26;
                        vmIEIncome.field27 = iEIncome.field27;
                        vmIEIncome.field28 = iEIncome.field28;
                        vmIEIncome.field29 = iEIncome.field29;
                        vmIEIncome.createdby = iEIncome.createdby;
                        vmIEIncome.createddate = iEIncome.createddate;
                        vmIEIncome.updatedby = iEIncome.updatedby;
                        vmIEIncome.updateddate = iEIncome.updateddate;

                        vmIEIncomes.Add(vmIEIncome);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmIEIncomes;
        }

        public vm.IEIncome GetByID(int id)
        {
            vm.IEIncome vmIEIncome = null;
            dc.IEIncome iEIncome = null;

            try
            {
                iEIncome = _repository.FindByID(id);
                if (iEIncome != null)
                {
                    vmIEIncome = new vm.IEIncome();
                    vmIEIncome.id = iEIncome.id;
                    vmIEIncome.TaxPlayerNumber = iEIncome.TaxPlayerNumber;
                    vmIEIncome.field1 = iEIncome.field1;
                    vmIEIncome.field2 = iEIncome.field2;
                    vmIEIncome.field3 = iEIncome.field3;
                    vmIEIncome.field4 = iEIncome.field4;
                    vmIEIncome.field5 = iEIncome.field5;
                    vmIEIncome.field6 = iEIncome.field6;
                    vmIEIncome.field7 = iEIncome.field7;
                    vmIEIncome.field8 = iEIncome.field8;
                    vmIEIncome.field9 = iEIncome.field9;
                    vmIEIncome.field10 = iEIncome.field10;
                    vmIEIncome.field11 = iEIncome.field11;
                    vmIEIncome.field12 = iEIncome.field12;
                    vmIEIncome.field13 = iEIncome.field13;
                    vmIEIncome.field14 = iEIncome.field14;
                    vmIEIncome.field15 = iEIncome.field15;
                    vmIEIncome.field16 = iEIncome.field16;
                    vmIEIncome.field17 = iEIncome.field17;
                    vmIEIncome.field18 = iEIncome.field18;
                    vmIEIncome.field19 = iEIncome.field19;
                    vmIEIncome.field20 = iEIncome.field20;
                    vmIEIncome.field21 = iEIncome.field21;
                    vmIEIncome.field22 = iEIncome.field22;
                    vmIEIncome.field23 = iEIncome.field23;
                    vmIEIncome.createdby = iEIncome.createdby;
                    vmIEIncome.createddate = iEIncome.createddate;
                    vmIEIncome.updatedby = iEIncome.updatedby;
                    vmIEIncome.updateddate = iEIncome.updateddate;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmIEIncome;
        }

        public string GetEmployName(string taxpayernumber)
        {
            vm.IEIncome vmIEIncome = null;
            dc.IEIncome iEIncome = null;

            try
            {
                iEIncome = _repository.GetEmployName(taxpayernumber);
                if (iEIncome != null)
                {
                    vmIEIncome = new vm.IEIncome();
                    vmIEIncome.id = iEIncome.id;
                    vmIEIncome.TaxPlayerNumber = iEIncome.TaxPlayerNumber;
                    vmIEIncome.field1 = iEIncome.field1;
                    vmIEIncome.field2 = iEIncome.field2;
                    vmIEIncome.field3 = iEIncome.field3;
                    vmIEIncome.field4 = iEIncome.field4;
                    vmIEIncome.field5 = iEIncome.field5;
                    vmIEIncome.field6 = iEIncome.field6;
                    vmIEIncome.field7 = iEIncome.field7;
                    vmIEIncome.field8 = iEIncome.field8;
                    vmIEIncome.field9 = iEIncome.field9;
                    vmIEIncome.field10 = iEIncome.field10;
                    vmIEIncome.field11 = iEIncome.field11;
                    vmIEIncome.field12 = iEIncome.field12;
                    vmIEIncome.field13 = iEIncome.field13;
                    vmIEIncome.field14 = iEIncome.field14;
                    vmIEIncome.field15 = iEIncome.field15;
                    vmIEIncome.field16 = iEIncome.field16;
                    vmIEIncome.field17 = iEIncome.field17;
                    vmIEIncome.field18 = iEIncome.field18;
                    vmIEIncome.field19 = iEIncome.field19;
                    vmIEIncome.field20 = iEIncome.field20;
                    vmIEIncome.field21 = iEIncome.field21;
                    vmIEIncome.field22 = iEIncome.field22;
                    vmIEIncome.field23 = iEIncome.field23;
                    vmIEIncome.createdby = iEIncome.createdby;
                    vmIEIncome.createddate = iEIncome.createddate;
                    vmIEIncome.updatedby = iEIncome.updatedby;
                    vmIEIncome.updateddate = iEIncome.updateddate;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmIEIncome.field4;
        }

        public bool Create(string TaxPlayerNumber, string field1, string field2, string field3
            , string field4, string field5, string field6, string field7, string field8, string field9
            , string field10, string field11, string field12, string field13, string field14,
            string field15, string field16, string field17, string field18, string field19,
            string field20, string field21, string field22, string field23, 
            string createdby, string createddate, string updatedby, string updateddate)
        {
            bool boolInsert = false;
            try
            {
                boolInsert = _repository.Insert(TaxPlayerNumber, field1, field2, field3
            , field4, field5, field6, field7, field8, field9
            , field10, field11, field12, field13, field14, 
            field15, field16, field17, field18, field19, 
            field20, field21, field22, field23, createdby, createddate, updatedby, updateddate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return boolInsert;
        }

        public bool Update(int id, string TaxPlayerNumber, string field1, string field2, string field3
            , string field4, string field5, string field6, string field7, string field8, string field9
            , string field10, string field11, string field12, string field13, string field14,
            string field15, string field16, string field17, string field18, string field19,
            string field20, string field21, string field22, string field23, 
            string createdby, string createddate, string updatedby, string updateddate)
        {
            bool boolUpdate = false;
            try
            {
                boolUpdate = _repository.Update(id, TaxPlayerNumber, field1, field2, field3
            , field4, field5, field6, field7, field8, field9
            , field10, field11, field12, field13, field14,
            field15, field16, field17, field18, field19,
            field20, field21, field22, field23, updatedby, updateddate);
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

