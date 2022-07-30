using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Repository;
using vm = DelloiteTRLib.Model;
using dc = DelloiteTRLib.DataContext;

namespace DelloiteTRLib.Services
{
    public class etServices
    {
        private etRepository _repository;

        public etServices(etRepository repository)
        {
            _repository = repository;
        }

        public List<vm.et> CheckAdminCalculation(string userlogon)
        {
            List<vm.et> vmdatas = new List<vm.et>();
            IEnumerable<dc.EngagementTeam> datas = null;

            try
            {
                datas = _repository.CheckAdminCalculation(userlogon);

                if (datas != null)
                {
                    foreach (dc.EngagementTeam data in datas)
                    {
                        vm.et vmdata = new vm.et();
                        vmdata.EngagementId = data.EngagementId;
                        vmdata.Company_Key = data.Company_Key;
                        vmdata.PIC = data.PIC;
                        vmdata.MIC = data.MIC;
                        vmdata.AMIC = data.AMIC;
                        vmdata.AMIC2 = data.AMIC2;
                        vmdata.SIC2 = data.SIC2;
                        vmdata.SIC = data.SIC;
                        vmdata.AIC1 = data.AIC1;
                        vmdata.AIC2 = data.AIC2;
                        vmdata.AIC3 = data.AIC3;

                        vmdatas.Add(vmdata);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmdatas;
        }

        public List<vm.et> GetAllBy(string company_key, string userlogon)
        {
            List<vm.et> vmdatas = new List<vm.et>();
            IEnumerable<dc.EngagementTeam> datas = null;

            try
            {
                datas = _repository.gets(company_key, userlogon);

                if (datas != null)
                {
                    foreach (dc.EngagementTeam data in datas)
                    {
                        vm.et vmdata = new vm.et();
                        vmdata.EngagementId = data.EngagementId;
                        vmdata.Company_Key = data.Company_Key;
                        vmdata.PIC = data.PIC;
                        vmdata.MIC = data.MIC;
                        vmdata.AMIC = data.AMIC;
                        vmdata.AMIC2 = data.AMIC2;
                        vmdata.SIC2 = data.SIC2;
                        vmdata.SIC = data.SIC;
                        vmdata.AIC1 = data.AIC1;
                        vmdata.AIC2 = data.AIC2;
                        vmdata.AIC3 = data.AIC3;

                        vmdatas.Add(vmdata);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmdatas;
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
