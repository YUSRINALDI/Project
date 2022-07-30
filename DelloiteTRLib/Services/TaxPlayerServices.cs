using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Repository;
using vm = DelloiteTRLib.Model;
using dc = DelloiteTRLib.DataContext;

namespace DelloiteTRLib.Services
{
    public class TaxPlayerServices
    {
        private TaxPlayerRepository _repository;

        public TaxPlayerServices(TaxPlayerRepository repository)
        {
            _repository = repository;
        }


        public List<vm.TaxPlayer> GetAll()
        {

            List<vm.TaxPlayer> vmTaxPlayers = new List<vm.TaxPlayer>();
            IEnumerable<dc.TaxPlayerDetail> taxPlayerDetails = null;
            try
            {
                taxPlayerDetails = _repository.FindAll();
                if (taxPlayerDetails != null)
                {

                    foreach (dc.TaxPlayerDetail taxPlayerDetail in taxPlayerDetails)
                    {
                        vm.TaxPlayer vmTaxPlayer = new vm.TaxPlayer();
                        vmTaxPlayer.ParticularId = taxPlayerDetail.ParticularId;
                        vmTaxPlayer.TaxPayerNumber = taxPlayerDetail.TaxPayerNumber;
                        vmTaxPlayer.TaxRefNo = taxPlayerDetail.TaxRefNo;
                        vmTaxPlayer.TaxPayerName = taxPlayerDetail.TaxPayerName;

                        /*vmTaxPlayer.ID = taxPlayerDetail.Emp_CompanyDet.ID;
                        vmTaxPlayer.MasterId = taxPlayerDetail.Emp_CompanyDet.MasterId;
                        vmTaxPlayer.Company_Key = taxPlayerDetail.Emp_CompanyDet.Company_Key;
                        vmTaxPlayer.LocalCompany_Key = taxPlayerDetail.Emp_CompanyDet.LocalCompany_Key;
                        vmTaxPlayer.COY_NAME_Key = taxPlayerDetail.Emp_CompanyDet.Company.COY_NAME_Key;*/

                        vmTaxPlayers.Add(vmTaxPlayer);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmTaxPlayers;
        }

        public List<vm.TaxPlayer> GetAllBy(string userLogon)
        {
            List<vm.TaxPlayer> vmTaxPlayers = new List<vm.TaxPlayer>();
            IEnumerable<dc.TaxPlayerDetail> TaxPlayerDetails = null;

            try
            {
                TaxPlayerDetails = _repository.FindAllBy(userLogon);

                if (TaxPlayerDetails != null)
                {
                    foreach (dc.TaxPlayerDetail taxPlayerDetail in TaxPlayerDetails)
                    {
                        vm.TaxPlayer vmTaxPlayer = new vm.TaxPlayer();
                        vmTaxPlayer.ParticularId = taxPlayerDetail.ParticularId;
                        vmTaxPlayer.TaxPayerNumber = taxPlayerDetail.TaxPayerNumber;
                        vmTaxPlayer.TaxRefNo = taxPlayerDetail.TaxRefNo;
                        vmTaxPlayer.TaxPayerName = taxPlayerDetail.TaxPayerName;

                        /*vmTaxPlayer.ID = taxPlayerDetail.Emp_CompanyDet.ID;
                        vmTaxPlayer.MasterId = taxPlayerDetail.Emp_CompanyDet.MasterId;
                        vmTaxPlayer.Company_Key = taxPlayerDetail.Emp_CompanyDet.Company_Key;
                        vmTaxPlayer.LocalCompany_Key = taxPlayerDetail.Emp_CompanyDet.LocalCompany_Key;
                        vmTaxPlayer.COY_NAME_Key = taxPlayerDetail.Emp_CompanyDet.Company.COY_NAME_Key;
                        vmTaxPlayer.PIC = "";*/

                        vmTaxPlayers.Add(vmTaxPlayer);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmTaxPlayers;
        }

        public vm.TaxPlayer GetByTaxPayerNumber(string TaxPayerNumber)
        {
            vm.TaxPlayer vmTaxPlayer = null;
            dc.TaxPlayerDetail taxPlayerDetail = null;

            try
            {
                taxPlayerDetail = _repository.FindByTaxPayerNumber(TaxPayerNumber);
                if (taxPlayerDetail != null)
                {
                    vmTaxPlayer = new vm.TaxPlayer();
                    vmTaxPlayer.ParticularId = taxPlayerDetail.ParticularId;
                    vmTaxPlayer.TaxPayerNumber = taxPlayerDetail.TaxPayerNumber;
                    vmTaxPlayer.TaxRefNo = taxPlayerDetail.TaxRefNo;
                    vmTaxPlayer.TaxPayerName = taxPlayerDetail.TaxPayerName;

                    vmTaxPlayer.ID = taxPlayerDetail.Emp_CompanyDet.ID;
                    vmTaxPlayer.MasterId = taxPlayerDetail.Emp_CompanyDet.MasterId;
                    vmTaxPlayer.Company_Key = taxPlayerDetail.Emp_CompanyDet.Company_Key;
                    vmTaxPlayer.LocalCompany_Key = taxPlayerDetail.Emp_CompanyDet.LocalCompany_Key;
                    vmTaxPlayer.COY_NAME_Key = taxPlayerDetail.Emp_CompanyDet.Company.COY_NAME_Key;
                    vmTaxPlayer.PIC = "";

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmTaxPlayer;
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
