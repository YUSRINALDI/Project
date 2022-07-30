using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Repository;
using vm = DelloiteTRLib.Model;
using dc = DelloiteTRLib.DataContext;

namespace DelloiteTRLib.Services
{
    public class comServices
    {
        private comRepository _repository;

        public comServices(comRepository repository)
        {
            _repository = repository;
        }

        public vm.com getData(string COY_RCB_Key)
        {
            vm.com vmdata = null;
            dc.Company data = null;

            try
            {
                data = _repository.get(COY_RCB_Key);
                if (data != null)
                {
                    vmdata = new vm.com();
                    vmdata.COY_RCB_Key = data.COY_RCB_Key;
                    vmdata.COY_NAME_Key = data.COY_NAME_Key;
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
