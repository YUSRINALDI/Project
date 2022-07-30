using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Repository;
using vm = DelloiteTRLib.Model;
using dc = DelloiteTRLib.DataContext;

namespace DelloiteTRLib.Services
{
    public class ecServices
    {
        private ecRepository _repository;

        public ecServices(ecRepository repository)
        {
            _repository = repository;
        }

        public vm.ec getData(int ParticularId)
        {
            vm.ec vmdata = null;
            dc.Emp_CompanyDet data = null;

            try
            {
                data = _repository.get(ParticularId);
                if (data != null)
                {
                    vmdata = new vm.ec();
                    vmdata.MasterId = data.MasterId;
                    vmdata.Company_Key = data.Company_Key;
                    vmdata.Local_Company_Key = data.LocalCompany_Key;
                    vmdata.ParticularId = data.ParticularId;
                    vmdata.id = data.ID;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmdata;
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
