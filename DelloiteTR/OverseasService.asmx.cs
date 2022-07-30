using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;
using vm = DelloiteTRLib.Model;
using System.Web.Script.Services;

namespace DelloiteTR
{
    /// <summary>
    /// Summary description for OverseasService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class OverseasService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddOverseasIncome(vm.OverseasIncome jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddOverseasIncome", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@Type",
                        Value = jsonData.type
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = jsonData.TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@form",
                        Value = jsonData.form
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = jsonData.year
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = jsonData.ammend
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@country",
                        Value = jsonData.country
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@currency",
                        Value = jsonData.currency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@dateofreceipt",
                        Value = jsonData.dateofreceipt
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@interval",
                        Value = jsonData.interval
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@exchrate",
                        Value = jsonData.exchrate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@incomecurrency",
                        Value = jsonData.incomecurrency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@taxpaidcurrency",
                        Value = jsonData.taxpaidcurrency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@incomerp",
                        Value = jsonData.incomerp
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@taxpaidrp",
                        Value = jsonData.taxpaidrp
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@treatyrate",
                        Value = jsonData.treatyrate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ftc",
                        Value = jsonData.ftc
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@allowedftc",
                        Value = jsonData.allowedftc
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@irregularincome",
                        Value = jsonData.irregularincome
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@createdby",
                        Value = jsonData.createdby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@createddate",
                        Value = jsonData.createddate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updatedby",
                        Value = jsonData.updatedby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updateddate",
                        Value = jsonData.updateddate
                    });
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddOverseasDetailed(vm.OverseasIncome jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddOverseasDetailed", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@Type",
                        Value = jsonData.type
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = jsonData.TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@form",
                        Value = jsonData.form
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = jsonData.year
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = jsonData.ammend
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@line",
                        Value = jsonData.line
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@description",
                        Value = jsonData.description
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@currency",
                        Value = jsonData.currency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@dateofreceipt",
                        Value = jsonData.dateofreceipt
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@interval",
                        Value = jsonData.interval
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@exchrate",
                        Value = jsonData.exchrate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@fullyearincome",
                        Value = jsonData.fullyearincome
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@incomecurrency",
                        Value = jsonData.incomecurrency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@taxpaidcurrency",
                        Value = jsonData.taxpaidcurrency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@incomerp",
                        Value = jsonData.incomerp
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@taxpaidrp",
                        Value = jsonData.taxpaidrp
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@treatyrate",
                        Value = jsonData.treatyrate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ftc",
                        Value = jsonData.ftc
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@allowedftc",
                        Value = jsonData.allowedftc
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@irregularincome",
                        Value = jsonData.irregularincome
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@createdby",
                        Value = jsonData.createdby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@createddate",
                        Value = jsonData.createddate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updatedby",
                        Value = jsonData.updatedby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updateddate",
                        Value = jsonData.updateddate
                    });
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddAsset(vm.OverseasAsset jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddAsset", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@Type",
                        Value = jsonData.type
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = jsonData.TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@form",
                        Value = jsonData.form
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = jsonData.year
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = jsonData.ammend
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_id",
                        Value = jsonData.as_id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_refnumber",
                        Value = jsonData.as_refnumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_details",
                        Value = jsonData.as_details
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_currency",
                        Value = jsonData.as_currency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_balancedate",
                        Value = jsonData.as_balancedate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_interval",
                        Value = jsonData.as_interval
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_originalcurrency",
                        Value = jsonData.as_originalcurrency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_exchrate",
                        Value = jsonData.as_exchrate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_inrupiah",
                        Value = jsonData.as_inrupiah
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_owner",
                        Value = jsonData.as_owner
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_address",
                        Value = jsonData.as_address
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_account",
                        Value = jsonData.as_account
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_country",
                        Value = jsonData.as_country
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@createdby",
                        Value = jsonData.createdby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@createddate",
                        Value = jsonData.createddate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updatedby",
                        Value = jsonData.updatedby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updateddate",
                        Value = jsonData.updateddate
                    });
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddRental(vm.OverseasRental jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddRental", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@Type",
                        Value = jsonData.type
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = jsonData.TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@form",
                        Value = jsonData.form
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = jsonData.year
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = jsonData.ammend
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_information",
                        Value = jsonData.ren_information
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_country",
                        Value = jsonData.ren_country
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_currency",
                        Value = jsonData.ren_currency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_dateofreceipt",
                        Value = jsonData.ren_dateofreceipt
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_interval",
                        Value = jsonData.ren_interval
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_exchrate",
                        Value = jsonData.ren_exchrate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_amountcurrency",
                        Value = jsonData.ren_amountcurrency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_amountrp",
                        Value = jsonData.ren_amountrp
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_irregularincome",
                        Value = jsonData.ren_irregularincome
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@createdby",
                        Value = jsonData.createdby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@createddate",
                        Value = jsonData.createddate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updatedby",
                        Value = jsonData.updatedby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updateddate",
                        Value = jsonData.updateddate
                    });
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddCapital(vm.OverseasCapital jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddCapital", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = jsonData.TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@form",
                        Value = jsonData.form
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = jsonData.year
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = jsonData.ammend
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_description",
                        Value = jsonData.cap_description
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_country",
                        Value = jsonData.cap_country
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_currency",
                        Value = jsonData.cap_currency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_sellingdate",
                        Value = jsonData.cap_sellingdate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_interval",
                        Value = jsonData.cap_interval
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_exchrate",
                        Value = jsonData.cap_exchrate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_proceeds",
                        Value = jsonData.cap_proceeds
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_cost",
                        Value = jsonData.cap_cost
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_gainloss",
                        Value = jsonData.cap_gainloss
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_taxpaid",
                        Value = jsonData.cap_taxpaid
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_gainlossrp",
                        Value = jsonData.cap_gainlossrp
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_taxpaidrp",
                        Value = jsonData.cap_taxpaidrp
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_irregularincome",
                        Value = jsonData.cap_irregularincome
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@createdby",
                        Value = jsonData.createdby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@createddate",
                        Value = jsonData.createddate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updatedby",
                        Value = jsonData.updatedby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updateddate",
                        Value = jsonData.updateddate
                    });
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddIrregular(vm.Irregular jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddIrregular", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = jsonData.TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@form",
                        Value = jsonData.form
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = jsonData.year
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = jsonData.ammend
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@country",
                        Value = jsonData.country
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data1",
                        Value = jsonData.data1
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data2",
                        Value = jsonData.data2
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data3",
                        Value = jsonData.data3
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data4",
                        Value = jsonData.data4
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data5",
                        Value = jsonData.data5
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data6",
                        Value = jsonData.data6
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data7",
                        Value = jsonData.data7
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data8",
                        Value = jsonData.data8
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data9",
                        Value = jsonData.data9
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data10",
                        Value = jsonData.data10
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@createdby",
                        Value = jsonData.createdby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@createddate",
                        Value = jsonData.createddate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updatedby",
                        Value = jsonData.updatedby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updateddate",
                        Value = jsonData.updateddate
                    });
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void UpdateIrregular(vm.Irregular jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateIrregular", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = jsonData.TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@form",
                        Value = jsonData.form
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = jsonData.year
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = jsonData.ammend
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@country",
                        Value = jsonData.country
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data1",
                        Value = jsonData.data1
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data2",
                        Value = jsonData.data2
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data3",
                        Value = jsonData.data3
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data4",
                        Value = jsonData.data4
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data5",
                        Value = jsonData.data5
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data6",
                        Value = jsonData.data6
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data7",
                        Value = jsonData.data7
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data8",
                        Value = jsonData.data8
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data9",
                        Value = jsonData.data9
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data10",
                        Value = jsonData.data10
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@createdby",
                        Value = jsonData.createdby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@createddate",
                        Value = jsonData.createddate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updatedby",
                        Value = jsonData.updatedby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updateddate",
                        Value = jsonData.updateddate
                    });
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void EditOverseasIncome(vm.OverseasIncome jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spEditOverseasIncome", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@Type",
                        Value = jsonData.type
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = jsonData.TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@country",
                        Value = jsonData.country
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@currency",
                        Value = jsonData.currency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@dateofreceipt",
                        Value = jsonData.dateofreceipt
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@interval",
                        Value = jsonData.interval
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@exchrate",
                        Value = jsonData.exchrate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@incomecurrency",
                        Value = jsonData.incomecurrency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@taxpaidcurrency",
                        Value = jsonData.taxpaidcurrency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@incomerp",
                        Value = jsonData.incomerp
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@taxpaidrp",
                        Value = jsonData.taxpaidrp
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@treatyrate",
                        Value = jsonData.treatyrate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ftc",
                        Value = jsonData.ftc
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@allowedftc",
                        Value = jsonData.allowedftc
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@irregularincome",
                        Value = jsonData.irregularincome
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@createdby",
                        Value = jsonData.createdby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@createddate",
                        Value = jsonData.createddate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updatedby",
                        Value = jsonData.updatedby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updateddate",
                        Value = jsonData.updateddate
                    });
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void EditOverseasDetailed(vm.OverseasIncome jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spEditOverseasDetailed", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@Type",
                        Value = jsonData.type
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = jsonData.TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@description",
                        Value = jsonData.description
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@line",
                        Value = jsonData.line
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@currency",
                        Value = jsonData.currency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@dateofreceipt",
                        Value = jsonData.dateofreceipt
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@interval",
                        Value = jsonData.interval
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@exchrate",
                        Value = jsonData.exchrate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@fullyearincome",
                        Value = jsonData.fullyearincome
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@incomecurrency",
                        Value = jsonData.incomecurrency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@taxpaidcurrency",
                        Value = jsonData.taxpaidcurrency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@incomerp",
                        Value = jsonData.incomerp
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@taxpaidrp",
                        Value = jsonData.taxpaidrp
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@treatyrate",
                        Value = jsonData.treatyrate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ftc",
                        Value = jsonData.ftc
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@allowedftc",
                        Value = jsonData.allowedftc
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@irregularincome",
                        Value = jsonData.irregularincome
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@createdby",
                        Value = jsonData.createdby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@createddate",
                        Value = jsonData.createddate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updatedby",
                        Value = jsonData.updatedby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updateddate",
                        Value = jsonData.updateddate
                    });
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void EditAsset(vm.OverseasAsset jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spEditAsset", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@Type",
                        Value = jsonData.type
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = jsonData.TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_id",
                        Value = jsonData.as_id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_refnumber",
                        Value = jsonData.as_refnumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_details",
                        Value = jsonData.as_details
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_currency",
                        Value = jsonData.as_currency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_balancedate",
                        Value = jsonData.as_balancedate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_interval",
                        Value = jsonData.as_interval
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_originalcurrency",
                        Value = jsonData.as_originalcurrency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_exchrate",
                        Value = jsonData.as_exchrate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_inrupiah",
                        Value = jsonData.as_inrupiah
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_owner",
                        Value = jsonData.as_owner
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_address",
                        Value = jsonData.as_address
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_account",
                        Value = jsonData.as_account
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@as_country",
                        Value = jsonData.as_country
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@createdby",
                        Value = jsonData.createdby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@createddate",
                        Value = jsonData.createddate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updatedby",
                        Value = jsonData.updatedby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updateddate",
                        Value = jsonData.updateddate
                    });
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void EditRental(vm.OverseasRental jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spEditRental", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@Type",
                        Value = jsonData.type
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = jsonData.TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_information",
                        Value = jsonData.ren_information
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_country",
                        Value = jsonData.ren_country
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_currency",
                        Value = jsonData.ren_currency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_dateofreceipt",
                        Value = jsonData.ren_dateofreceipt
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_interval",
                        Value = jsonData.ren_interval
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_exchrate",
                        Value = jsonData.ren_exchrate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_amountcurrency",
                        Value = jsonData.ren_amountcurrency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_amountrp",
                        Value = jsonData.ren_amountrp
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_irregularincome",
                        Value = jsonData.ren_irregularincome
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updatedby",
                        Value = jsonData.updatedby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updateddate",
                        Value = jsonData.updateddate
                    });
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void EditCapital(vm.OverseasCapital jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spEditCapital", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = jsonData.TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_description",
                        Value = jsonData.cap_description
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_country",
                        Value = jsonData.cap_country
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_currency",
                        Value = jsonData.cap_currency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_sellingdate",
                        Value = jsonData.cap_sellingdate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_interval",
                        Value = jsonData.cap_interval
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_exchrate",
                        Value = jsonData.cap_exchrate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_proceeds",
                        Value = jsonData.cap_proceeds
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_cost",
                        Value = jsonData.cap_cost
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_gainloss",
                        Value = jsonData.cap_gainloss
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_taxpaid",
                        Value = jsonData.cap_taxpaid
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_gainlossrp",
                        Value = jsonData.cap_gainlossrp
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_taxpaidrp",
                        Value = jsonData.cap_taxpaidrp
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@cap_irregularincome",
                        Value = jsonData.cap_irregularincome
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@createdby",
                        Value = jsonData.createdby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@createddate",
                        Value = jsonData.createddate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updatedby",
                        Value = jsonData.updatedby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updateddate",
                        Value = jsonData.updateddate
                    });
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void EditIrregular(vm.Irregular jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spEditIrregular", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = jsonData.TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@country",
                        Value = jsonData.country
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data1",
                        Value = jsonData.data1
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data2",
                        Value = jsonData.data2
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data3",
                        Value = jsonData.data3
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data4",
                        Value = jsonData.data4
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data5",
                        Value = jsonData.data5
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data6",
                        Value = jsonData.data6
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data7",
                        Value = jsonData.data7
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data8",
                        Value = jsonData.data8
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data9",
                        Value = jsonData.data9
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data10",
                        Value = jsonData.data10
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updatedby",
                        Value = jsonData.updatedby
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@updateddate",
                        Value = jsonData.updateddate
                    });
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }

        [WebMethod]
        public void GetCurrency()
        {
            List<vm.Exchange> models = new List<vm.Exchange>();
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetCurrency", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    vm.Exchange model = new vm.Exchange();
                    model.currency = sqlDataReader["currency"].ToString();

                    models.Add(model);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(models));
        }

        [WebMethod]
        public void GetWeeklyRate()
        {
            List<vm.Exchange> models = new List<vm.Exchange>();
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetWeeklyRate", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    vm.Exchange model = new vm.Exchange();
                    model.interval = sqlDataReader["interval"].ToString();
                    model.year = sqlDataReader["year"].ToString();

                    models.Add(model);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(models));
        }

        [WebMethod]
        public void GetExchange(string currency, string type, string interval, string year)
        {
            try
            {
                List<vm.Exchange> datas = new List<vm.Exchange>();
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetExchRate", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@currency",
                        Value = currency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@interval",
                        Value = interval
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@type",
                        Value = type
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = year
                    });
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        vm.Exchange data = new vm.Exchange();
                        data.amount = double.Parse(sqlDataReader["amount"].ToString());

                        datas.Add(data);
                    }
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(datas));
            }
            catch (Exception ex)
            {
                
            }
        }

        [WebMethod]
        public void GetIncomeBy(int type, string TaxPlayerNumber, string form, string year, int ammend)
        {
            try
            {
                List<vm.OverseasIncome> models = new List<vm.OverseasIncome>();
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetIncomeBy", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@type",
                        Value = type
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@form",
                        Value = form
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = year
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = ammend
                    });
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        vm.OverseasIncome model = new vm.OverseasIncome();
                        model.id = Convert.ToInt32(sqlDataReader["id"]);
                        model.TaxPlayerNumber = sqlDataReader["TaxPlayerNumber"].ToString();
                        model.form = sqlDataReader["form"].ToString();
                        model.year = sqlDataReader["year"].ToString();
                        model.type = int.Parse(sqlDataReader["type"].ToString());
                        model.country = sqlDataReader["country"].ToString();
                        model.currency = sqlDataReader["currency"].ToString();
                        model.dateofreceipt = sqlDataReader["dateofreceipt"].ToString();
                        model.interval = sqlDataReader["interval"].ToString();
                        model.exchrate = sqlDataReader["exchrate"].ToString();
                        model.incomecurrency = sqlDataReader["incomecurrency"].ToString();
                        model.taxpaidcurrency = sqlDataReader["taxpaidcurrency"].ToString();
                        model.incomerp = sqlDataReader["incomerp"].ToString();
                        model.taxpaidrp = sqlDataReader["taxpaidrp"].ToString();
                        model.treatyrate = sqlDataReader["treatyrate"].ToString();
                        model.ftc = sqlDataReader["ftc"].ToString();
                        model.allowedftc = sqlDataReader["allowedftc"].ToString();
                        model.irregularincome = sqlDataReader["irregularincome"].ToString();
                        model.createdby = sqlDataReader["createdby"].ToString();
                        model.createddate = sqlDataReader["createddate"].ToString();
                        model.updatedby = sqlDataReader["updatedby"].ToString();
                        model.updateddate = sqlDataReader["updateddate"].ToString();

                        models.Add(model);
                    }
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(models));
            }
            catch (Exception ex)
            {
                
                
            }
        }

        [WebMethod]
        public void GetIncomeDetailedBy(int type, string TaxPlayerNumber, string form, string year, int ammend)
        {
            try
            {
                List<vm.OverseasIncome> models = new List<vm.OverseasIncome>();
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetIncomeDetailedBy", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@type",
                        Value = type
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@form",
                        Value = form
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = year
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = ammend
                    });
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        vm.OverseasIncome model = new vm.OverseasIncome();
                        model.id = Convert.ToInt32(sqlDataReader["id"]);
                        model.TaxPlayerNumber = sqlDataReader["TaxPlayerNumber"].ToString();
                        model.form = sqlDataReader["form"].ToString();
                        model.year = sqlDataReader["year"].ToString();
                        model.type = int.Parse(sqlDataReader["type"].ToString());
                        model.description = sqlDataReader["description"].ToString();
                        model.line = sqlDataReader["line"].ToString();
                        model.currency = sqlDataReader["currency"].ToString();
                        model.dateofreceipt = sqlDataReader["dateofreceipt"].ToString();
                        model.interval = sqlDataReader["interval"].ToString();
                        model.exchrate = sqlDataReader["exchrate"].ToString();
                        model.fullyearincome = sqlDataReader["fullyearincome"].ToString();
                        model.incomecurrency = sqlDataReader["incomecurrency"].ToString();
                        model.taxpaidcurrency = sqlDataReader["taxpaidcurrency"].ToString();
                        model.incomerp = sqlDataReader["incomerp"].ToString();
                        model.taxpaidrp = sqlDataReader["taxpaidrp"].ToString();
                        model.treatyrate = sqlDataReader["treatyrate"].ToString();
                        model.ftc = sqlDataReader["ftc"].ToString();
                        model.allowedftc = sqlDataReader["allowedftc"].ToString();
                        model.irregularincome = sqlDataReader["irregularincome"].ToString();
                        model.createdby = sqlDataReader["createdby"].ToString();
                        model.createddate = sqlDataReader["createddate"].ToString();
                        model.updatedby = sqlDataReader["updatedby"].ToString();
                        model.updateddate = sqlDataReader["updateddate"].ToString();

                        models.Add(model);
                    }
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(models));
            }
            catch (Exception ex)
            {
                
                
            }
        }

        [WebMethod]
        public void GetSummary(string TaxPlayerNumber, string country, string form, string year, int ammend)
        {
            try
            {
                List<vm.Summary> models = new List<vm.Summary>();
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetSummary", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@country",
                        Value = country
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@form",
                        Value = form
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = year
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = ammend
                    });
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        vm.Summary model = new vm.Summary();

                        model.country = sqlDataReader["country"].ToString();
                        model.incomerp1 = sqlDataReader["incomerp1"].ToString();
                        model.taxpaidrp1 = sqlDataReader["taxpaidrp1"].ToString();
                        model.allowedftc1 = sqlDataReader["allowedftc1"].ToString();

                        model.incomerp2 = sqlDataReader["incomerp2"].ToString();
                        model.taxpaidrp2 = sqlDataReader["taxpaidrp2"].ToString();
                        model.allowedftc2 = sqlDataReader["allowedftc2"].ToString();

                        model.incomerp3 = sqlDataReader["incomerp3"].ToString();
                        model.taxpaidrp3 = sqlDataReader["taxpaidrp3"].ToString();
                        model.allowedftc3 = sqlDataReader["allowedftc3"].ToString();

                        model.cap_gainlossrp = sqlDataReader["cap_gainlossrp"].ToString();
                        model.cap_taxpaidrp = sqlDataReader["cap_taxpaidrp"].ToString();

                        models.Add(model);
                    }
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(models));
            }
            catch (Exception ex)
            {
                
                
            }
        }

        [WebMethod]
        public List<vm.Summary> GetSummary2(string TaxPlayerNumber, string country)
        {
            List<vm.Summary> models = new List<vm.Summary>();
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetSummaryAttachment", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@country",
                        Value = country
                    });
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        vm.Summary model = new vm.Summary();

                        model.country = sqlDataReader["country"].ToString();
                        model.incomerp1 = sqlDataReader["incomerp1"].ToString();
                        model.taxpaidrp1 = sqlDataReader["taxpaidrp1"].ToString();
                        model.incomecurrency1 = sqlDataReader["incomecurrency1"].ToString();
                        model.taxpaidcurrency1 = sqlDataReader["taxpaidcurrency1"].ToString();
                        model.allowedftc1 = sqlDataReader["allowedftc1"].ToString();

                        model.incomerp2 = sqlDataReader["incomerp2"].ToString();
                        model.taxpaidrp2 = sqlDataReader["taxpaidrp2"].ToString();
                        model.incomecurrency2 = sqlDataReader["incomecurrency2"].ToString();
                        model.taxpaidcurrency2 = sqlDataReader["taxpaidcurrency2"].ToString();
                        model.allowedftc2 = sqlDataReader["allowedftc2"].ToString();

                        model.incomerp3 = sqlDataReader["incomerp3"].ToString();
                        model.taxpaidrp3 = sqlDataReader["taxpaidrp3"].ToString();
                        model.incomecurrency3 = sqlDataReader["incomecurrency3"].ToString();
                        model.taxpaidcurrency3 = sqlDataReader["taxpaidcurrency3"].ToString();
                        model.allowedftc3 = sqlDataReader["allowedftc3"].ToString();

                        model.cap_gainlossrp = sqlDataReader["cap_gainlossrp"].ToString();
                        model.cap_taxpaidrp = sqlDataReader["cap_taxpaidrp"].ToString();
                        model.cap_gainloss = sqlDataReader["cap_gainloss"].ToString();
                        model.cap_taxpaid = sqlDataReader["cap_taxpaid"].ToString();

                        models.Add(model);
                    }
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                
            }
            catch (Exception ex)
            {
                
            }
            return models;
        }

        [WebMethod]
        public void GetIncomeByCountry(int type, string TaxPlayerNumber, string form, string year, int ammend)
        {
            try
            {
                List<vm.OverseasIncome> models = new List<vm.OverseasIncome>();
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetIncomeByCountry", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@type",
                        Value = type
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@form",
                        Value = form
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = year
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = ammend
                    });
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        vm.OverseasIncome model = new vm.OverseasIncome();
                        model.country = sqlDataReader["country"].ToString();
                        model.incomecurrency = sqlDataReader["incomecurrency"].ToString();
                        model.taxpaidcurrency = sqlDataReader["taxpaidcurrency"].ToString();
                        model.incomerp = sqlDataReader["incomerp"].ToString();
                        model.taxpaidrp = sqlDataReader["taxpaidrp"].ToString();
                        model.ftc = sqlDataReader["ftc"].ToString();
                        model.allowedftc = sqlDataReader["allowedftc"].ToString();

                        models.Add(model);
                    }
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(models));
            }
            catch (Exception ex)
            {


            }
        }

        [WebMethod]
        public void GetIrregularIncomeNew(string TaxPlayerNumber, string form, string year, int ammend)
        {
            try
            {
                List<vm.Irregular> models = new List<vm.Irregular>();
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetIrregularIncomeNew", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@form",
                        Value = form
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = year
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = ammend
                    });
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        vm.Irregular model = new vm.Irregular();
                        model.id = Convert.ToInt32(sqlDataReader["id"]);
                        model.TaxPlayerNumber = sqlDataReader["TaxPlayerNumber"].ToString();
                        model.form = sqlDataReader["form"].ToString();
                        model.year = sqlDataReader["year"].ToString();
                        model.country = sqlDataReader["country"].ToString();
                        model.data1 = sqlDataReader["data1"].ToString();
                        model.data2 = sqlDataReader["data2"].ToString();
                        model.data3 = sqlDataReader["data3"].ToString();
                        model.data4 = sqlDataReader["data4"].ToString();
                        model.data5 = sqlDataReader["data5"].ToString();
                        model.data6 = sqlDataReader["data6"].ToString();
                        model.data7 = sqlDataReader["data7"].ToString();
                        model.data8 = sqlDataReader["data8"].ToString();
                        model.data9 = sqlDataReader["data9"].ToString();
                        model.data10 = sqlDataReader["data10"].ToString();
                        model.createdby = sqlDataReader["createdby"].ToString();
                        model.createddate = sqlDataReader["createddate"].ToString();
                        model.updatedby = sqlDataReader["updatedby"].ToString();
                        model.updateddate = sqlDataReader["updateddate"].ToString();

                        models.Add(model);
                    }
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(models));
            }
            catch (Exception ex)
            {
                
                
            }
        }

        [WebMethod]
        public void GetIrregularIncomeNewBy(string TaxPlayerNumber, string form, string year, int ammend, string country, string data1)
        {
            try
            {
                List<vm.Irregular> models = new List<vm.Irregular>();
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetIrregularIncomeNewBy", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@form",
                        Value = form
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = year
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = ammend
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@country",
                        Value = country
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@data1",
                        Value = data1
                    });
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        vm.Irregular model = new vm.Irregular();
                        model.id = Convert.ToInt32(sqlDataReader["id"]);
                        model.TaxPlayerNumber = sqlDataReader["TaxPlayerNumber"].ToString();
                        model.form = sqlDataReader["form"].ToString();
                        model.year = sqlDataReader["year"].ToString();
                        model.country = sqlDataReader["country"].ToString();
                        model.data1 = sqlDataReader["data1"].ToString();
                        model.data2 = sqlDataReader["data2"].ToString();
                        model.data3 = sqlDataReader["data3"].ToString();
                        model.data4 = sqlDataReader["data4"].ToString();
                        model.data5 = sqlDataReader["data5"].ToString();
                        model.data6 = sqlDataReader["data6"].ToString();
                        model.data7 = sqlDataReader["data7"].ToString();
                        model.data8 = sqlDataReader["data8"].ToString();
                        model.data9 = sqlDataReader["data9"].ToString();
                        model.data10 = sqlDataReader["data10"].ToString();
                        model.createdby = sqlDataReader["createdby"].ToString();
                        model.createddate = sqlDataReader["createddate"].ToString();
                        model.updatedby = sqlDataReader["updatedby"].ToString();
                        model.updateddate = sqlDataReader["updateddate"].ToString();

                        models.Add(model);
                    }
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(models));
            }
            catch (Exception ex)
            {


            }
        }

        [WebMethod]
        public void GetIrregularIncome1(string TaxPlayerNumber, string form, string year, int ammend)
        {
            try
            {
                List<vm.OverseasIncome> models = new List<vm.OverseasIncome>();
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetIrregularIncome1", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@form",
                        Value = form
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = year
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = ammend
                    });
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        vm.OverseasIncome model = new vm.OverseasIncome();
                        model.id = Convert.ToInt32(sqlDataReader["id"]);
                        model.TaxPlayerNumber = sqlDataReader["TaxPlayerNumber"].ToString();
                        model.form = sqlDataReader["form"].ToString();
                        model.year = sqlDataReader["year"].ToString();
                        model.type = int.Parse(sqlDataReader["type"].ToString());
                        model.country = sqlDataReader["country"].ToString();
                        model.currency = sqlDataReader["currency"].ToString();
                        model.dateofreceipt = sqlDataReader["dateofreceipt"].ToString();
                        model.interval = sqlDataReader["interval"].ToString();
                        model.exchrate = sqlDataReader["exchrate"].ToString();
                        model.incomecurrency = sqlDataReader["incomecurrency"].ToString();
                        model.taxpaidcurrency = sqlDataReader["taxpaidcurrency"].ToString();
                        model.incomerp = sqlDataReader["incomerp"].ToString();
                        model.taxpaidrp = sqlDataReader["taxpaidrp"].ToString();
                        model.treatyrate = sqlDataReader["treatyrate"].ToString();
                        model.ftc = sqlDataReader["ftc"].ToString();
                        model.allowedftc = sqlDataReader["allowedftc"].ToString();
                        model.irregularincome = sqlDataReader["irregularincome"].ToString();
                        model.createdby = sqlDataReader["createdby"].ToString();
                        model.createddate = sqlDataReader["createddate"].ToString();
                        model.updatedby = sqlDataReader["updatedby"].ToString();
                        model.updateddate = sqlDataReader["updateddate"].ToString();

                        models.Add(model);
                    }
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(models));
            }
            catch (Exception ex)
            {
                
                
            }
        }

        [WebMethod]
        public void GetIrregularIncomeDetailed1(string TaxPlayerNumber, string form, string year, int ammend)
        {
            try
            {
                List<vm.OverseasIncome> models = new List<vm.OverseasIncome>();
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetIrregularIncomeDetailed1", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@form",
                        Value = form
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = year
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = ammend
                    });
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        vm.OverseasIncome model = new vm.OverseasIncome();
                        model.id = Convert.ToInt32(sqlDataReader["id"]);
                        model.TaxPlayerNumber = sqlDataReader["TaxPlayerNumber"].ToString();
                        model.form = sqlDataReader["form"].ToString();
                        model.year = sqlDataReader["year"].ToString();
                        model.type = int.Parse(sqlDataReader["type"].ToString());
                        model.description = sqlDataReader["description"].ToString();
                        model.line = sqlDataReader["line"].ToString();
                        model.currency = sqlDataReader["currency"].ToString();
                        model.dateofreceipt = sqlDataReader["dateofreceipt"].ToString();
                        model.interval = sqlDataReader["interval"].ToString();
                        model.exchrate = sqlDataReader["exchrate"].ToString();
                        model.fullyearincome = sqlDataReader["fullyearincome"].ToString();
                        model.incomecurrency = sqlDataReader["incomecurrency"].ToString();
                        model.taxpaidcurrency = sqlDataReader["taxpaidcurrency"].ToString();
                        model.incomerp = sqlDataReader["incomerp"].ToString();
                        model.taxpaidrp = sqlDataReader["taxpaidrp"].ToString();
                        model.treatyrate = sqlDataReader["treatyrate"].ToString();
                        model.ftc = sqlDataReader["ftc"].ToString();
                        model.allowedftc = sqlDataReader["allowedftc"].ToString();
                        model.irregularincome = sqlDataReader["irregularincome"].ToString();
                        model.createdby = sqlDataReader["createdby"].ToString();
                        model.createddate = sqlDataReader["createddate"].ToString();
                        model.updatedby = sqlDataReader["updatedby"].ToString();
                        model.updateddate = sqlDataReader["updateddate"].ToString();

                        models.Add(model);
                    }
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(models));
            }
            catch (Exception ex)
            {
                
                
            }
        }

        [WebMethod]
        public void GetIrregularIncome2(string TaxPlayerNumber, string form, string year, int ammend)
        {
            try
            {
                List<vm.OverseasCapital> models = new List<vm.OverseasCapital>();
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetIrregularIncome2", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@form",
                        Value = form
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = year
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = ammend
                    });
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        vm.OverseasCapital model = new vm.OverseasCapital();
                        model.id = Convert.ToInt32(sqlDataReader["id"]);
                        model.TaxPlayerNumber = sqlDataReader["TaxPlayerNumber"].ToString();
                        model.form = sqlDataReader["form"].ToString();
                        model.year = sqlDataReader["year"].ToString();
                        model.cap_description = sqlDataReader["cap_description"].ToString();
                        model.cap_country = sqlDataReader["cap_country"].ToString();
                        model.cap_currency = sqlDataReader["cap_currency"].ToString();
                        model.cap_sellingdate = sqlDataReader["cap_sellingdate"].ToString();
                        model.cap_interval = sqlDataReader["cap_interval"].ToString();
                        model.cap_exchrate = sqlDataReader["cap_exchrate"].ToString();
                        model.cap_proceeds = sqlDataReader["cap_proceeds"].ToString();
                        model.cap_cost = sqlDataReader["cap_cost"].ToString();
                        model.cap_gainloss = sqlDataReader["cap_gainloss"].ToString();
                        model.cap_taxpaid = sqlDataReader["cap_taxpaid"].ToString();
                        model.cap_gainlossrp = sqlDataReader["cap_gainlossrp"].ToString();
                        model.cap_taxpaidrp = sqlDataReader["cap_taxpaidrp"].ToString();
                        model.cap_irregularincome = sqlDataReader["cap_irregularincome"].ToString();
                        model.createdby = sqlDataReader["createdby"].ToString();
                        model.createddate = sqlDataReader["createddate"].ToString();
                        model.updatedby = sqlDataReader["updatedby"].ToString();
                        model.updateddate = sqlDataReader["updateddate"].ToString();

                        models.Add(model);
                    }
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(models));
            }
            catch (Exception ex)
            {

            }
        }

        [WebMethod]
        public void GetIrregularIncome3(string TaxPlayerNumber, string form, string year, int ammend)
        {
            try
            {
                List<vm.OverseasRental> models = new List<vm.OverseasRental>();
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetIrregularIncome3", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@form",
                        Value = form
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = year
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = ammend
                    });
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        vm.OverseasRental model = new vm.OverseasRental();
                        model.id = Convert.ToInt32(sqlDataReader["id"]);
                        model.type = Convert.ToInt32(sqlDataReader["type"]);
                        model.TaxPlayerNumber = sqlDataReader["TaxPlayerNumber"].ToString();
                        model.form = sqlDataReader["form"].ToString();
                        model.year = sqlDataReader["year"].ToString();
                        model.ren_information = sqlDataReader["ren_information"].ToString();
                        model.ren_country = sqlDataReader["ren_country"].ToString();
                        model.ren_currency = sqlDataReader["ren_currency"].ToString();
                        model.ren_dateofreceipt = sqlDataReader["ren_dateofreceipt"].ToString();
                        model.ren_interval = sqlDataReader["ren_interval"].ToString();
                        model.ren_exchrate = sqlDataReader["ren_exchrate"].ToString();
                        model.ren_amountcurrency = sqlDataReader["ren_amountcurrency"].ToString();
                        model.ren_amountrp = sqlDataReader["ren_amountrp"].ToString();
                        model.ren_irregularincome = sqlDataReader["ren_irregularincome"].ToString();
                        model.createdby = sqlDataReader["createdby"].ToString();
                        model.createddate = sqlDataReader["createddate"].ToString();
                        model.updatedby = sqlDataReader["updatedby"].ToString();
                        model.updateddate = sqlDataReader["updateddate"].ToString();

                        models.Add(model);
                    }
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(models));
            }
            catch (Exception ex)
            {

            }
        }

        [WebMethod]
        public void GetAssetBy(int type, string TaxPlayerNumber, string form, string year, int ammend)
        {
            try
            {
                List<vm.OverseasAsset> models = new List<vm.OverseasAsset>();
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetAssetBy", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@type",
                        Value = type
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@form",
                        Value = form
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = year
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = ammend
                    });
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        vm.OverseasAsset model = new vm.OverseasAsset();
                        model.id = Convert.ToInt32(sqlDataReader["id"]);
                        model.TaxPlayerNumber = sqlDataReader["TaxPlayerNumber"].ToString();
                        model.type = int.Parse(sqlDataReader["type"].ToString());
                        model.form = sqlDataReader["form"].ToString();
                        model.year = sqlDataReader["year"].ToString();
                        model.as_description = sqlDataReader["descriptiontext"].ToString();
                        model.as_refnumber = sqlDataReader["as_refnumber"].ToString();
                        model.as_details = sqlDataReader["as_details"].ToString();
                        model.as_currency = sqlDataReader["as_currency"].ToString();
                        model.as_balancedate = sqlDataReader["as_balancedate"].ToString();
                        model.as_interval = sqlDataReader["as_interval"].ToString();
                        model.as_originalcurrency = sqlDataReader["as_originalcurrency"].ToString();
                        model.as_exchrate = sqlDataReader["as_exchrate"].ToString();
                        model.as_inrupiah = sqlDataReader["as_inrupiah"].ToString();
                        model.as_owner = sqlDataReader["as_owner"].ToString();
                        model.as_address = sqlDataReader["as_address"].ToString();
                        model.as_account = sqlDataReader["as_account"].ToString();
                        model.as_country = sqlDataReader["as_country"].ToString();
                        model.createdby = sqlDataReader["createdby"].ToString();
                        model.createddate = sqlDataReader["createddate"].ToString();
                        model.updatedby = sqlDataReader["updatedby"].ToString();
                        model.updateddate = sqlDataReader["updateddate"].ToString();

                        models.Add(model);
                    }
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(models));
            }
            catch (Exception ex)
            {
                
                
            }
        }

        [WebMethod]
        public void GetRentalBy(int type, string TaxPlayerNumber, string form, string year, int ammend)
        {
            try
            {
                List<vm.OverseasRental> models = new List<vm.OverseasRental>();
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetRentalBy", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@type",
                        Value = type
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@form",
                        Value = form
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = year
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = ammend
                    });
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        vm.OverseasRental model = new vm.OverseasRental();
                        model.id = Convert.ToInt32(sqlDataReader["id"]);
                        model.TaxPlayerNumber = sqlDataReader["TaxPlayerNumber"].ToString();
                        model.type = int.Parse(sqlDataReader["type"].ToString());
                        model.form = sqlDataReader["form"].ToString();
                        model.year = sqlDataReader["year"].ToString();
                        model.ren_information = sqlDataReader["ren_information"].ToString();
                        model.ren_country = sqlDataReader["ren_country"].ToString();
                        model.ren_currency = sqlDataReader["ren_currency"].ToString();
                        model.ren_dateofreceipt = sqlDataReader["ren_dateofreceipt"].ToString();
                        model.ren_interval = sqlDataReader["ren_interval"].ToString();
                        model.ren_exchrate = sqlDataReader["ren_exchrate"].ToString();
                        model.ren_amountcurrency = sqlDataReader["ren_amountcurrency"].ToString();
                        model.ren_amountrp = sqlDataReader["ren_amountrp"].ToString();
                        model.ren_irregularincome = sqlDataReader["ren_irregularincome"].ToString();
                        model.createdby = sqlDataReader["createdby"].ToString();
                        model.createddate = sqlDataReader["createddate"].ToString();
                        model.updatedby = sqlDataReader["updatedby"].ToString();
                        model.updateddate = sqlDataReader["updateddate"].ToString();

                        models.Add(model);
                    }
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(models));
            }
            catch (Exception ex)
            {


            }
        }

        [WebMethod]
        public void GetRentalByCountry(int type, string TaxPlayerNumber, string form, string year, int ammend)
        {
            try
            {
                List<vm.OverseasRental> models = new List<vm.OverseasRental>();
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetRentalByCountry", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@type",
                        Value = type
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@form",
                        Value = form
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = year
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = ammend
                    });
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        vm.OverseasRental model = new vm.OverseasRental();
                        model.ren_country = sqlDataReader["ren_country"].ToString();
                        model.ren_amountcurrency = sqlDataReader["ren_amountcurrency"].ToString();
                        model.ren_amountrp = sqlDataReader["ren_amountrp"].ToString();

                        models.Add(model);
                    }
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(models));
            }
            catch (Exception ex)
            {
                
            }
        }

        [WebMethod]
        public void GetCapitalBy(string TaxPlayerNumber, string form, string year, int ammend)
        {
            try
            {
                List<vm.OverseasCapital> models = new List<vm.OverseasCapital>();
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetCapitalBy", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@form",
                        Value = form
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = year
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = ammend
                    });
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        vm.OverseasCapital model = new vm.OverseasCapital();
                        model.id = Convert.ToInt32(sqlDataReader["id"]);
                        model.TaxPlayerNumber = sqlDataReader["TaxPlayerNumber"].ToString();
                        model.form = sqlDataReader["form"].ToString();
                        model.year = sqlDataReader["year"].ToString();
                        model.cap_description = sqlDataReader["cap_description"].ToString();
                        model.cap_country = sqlDataReader["cap_country"].ToString();
                        model.cap_currency = sqlDataReader["cap_currency"].ToString();
                        model.cap_sellingdate = sqlDataReader["cap_sellingdate"].ToString();
                        model.cap_interval = sqlDataReader["cap_interval"].ToString();
                        model.cap_exchrate = sqlDataReader["cap_exchrate"].ToString();
                        model.cap_proceeds = sqlDataReader["cap_proceeds"].ToString();
                        model.cap_cost = sqlDataReader["cap_cost"].ToString();
                        model.cap_gainloss = sqlDataReader["cap_gainloss"].ToString();
                        model.cap_taxpaid = sqlDataReader["cap_taxpaid"].ToString();
                        model.cap_gainlossrp = sqlDataReader["cap_gainlossrp"].ToString();
                        model.cap_taxpaidrp = sqlDataReader["cap_taxpaidrp"].ToString();
                        model.cap_irregularincome = sqlDataReader["cap_irregularincome"].ToString();
                        model.createdby = sqlDataReader["createdby"].ToString();
                        model.createddate = sqlDataReader["createddate"].ToString();
                        model.updatedby = sqlDataReader["updatedby"].ToString();
                        model.updateddate = sqlDataReader["updateddate"].ToString();

                        models.Add(model);
                    }
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(models));
            }
            catch (Exception ex)
            {
                
                
            }
        }

        [WebMethod]
        public void GetCapitalByCountry(string TaxPlayerNumber, string form, string year, int ammend)
        {
            try
            {
                List<vm.OverseasCapital> models = new List<vm.OverseasCapital>();
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetCapitalByCountry", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TaxPlayerNumber",
                        Value = TaxPlayerNumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@form",
                        Value = form
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = year
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = ammend
                    });
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        vm.OverseasCapital model = new vm.OverseasCapital();
                        model.cap_country = sqlDataReader["cap_country"].ToString();
                        model.cap_gainloss = sqlDataReader["cap_gainloss"].ToString();
                        model.cap_taxpaid = sqlDataReader["cap_taxpaid"].ToString();
                        model.cap_gainlossrp = sqlDataReader["cap_gainlossrp"].ToString();
                        model.cap_taxpaidrp = sqlDataReader["cap_taxpaidrp"].ToString();

                        models.Add(model);
                    }
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(models));
            }
            catch (Exception ex)
            {
                
                
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteIncome(vm.OverseasIncome jsonData)
        {
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spDeleteIncome", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = jsonData.id
                });
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteIncomeDetailed(vm.OverseasIncome jsonData)
        {
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spDeleteDetailed", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = jsonData.id
                });
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteAsset(vm.OverseasAsset jsonData)
        {
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spDeleteAsset", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = jsonData.id
                });
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteRental(vm.OverseasRental jsonData)
        {
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spDeleteRental", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = jsonData.id
                });
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteCapital(vm.OverseasAsset jsonData)
        {
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spDeleteCapital", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = jsonData.id
                });
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteIrregular(vm.OverseasAsset jsonData)
        {
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spDeleteIrregular", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = jsonData.id
                });
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        [WebMethod]
        public void GetIncomeByID(int id)
        {
            List<vm.OverseasIncome> models = new List<vm.OverseasIncome>();
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetIncomeByID", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = id
                });
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    vm.OverseasIncome model = new vm.OverseasIncome();
                    model.id = Convert.ToInt32(sqlDataReader["id"]);
                    model.TaxPlayerNumber = sqlDataReader["TaxPlayerNumber"].ToString();
                    model.form = sqlDataReader["form"].ToString();
                    model.year = sqlDataReader["year"].ToString();
                    model.type = int.Parse(sqlDataReader["type"].ToString());
                    model.country = sqlDataReader["country"].ToString();
                    model.currency = sqlDataReader["currency"].ToString();
                    model.dateofreceipt = sqlDataReader["dateofreceipt"].ToString();
                    model.interval = sqlDataReader["interval"].ToString();
                    model.exchrate = sqlDataReader["exchrate"].ToString();
                    model.incomecurrency = sqlDataReader["incomecurrency"].ToString();
                    model.taxpaidcurrency = sqlDataReader["taxpaidcurrency"].ToString();
                    model.incomerp = sqlDataReader["incomerp"].ToString();
                    model.taxpaidrp = sqlDataReader["taxpaidrp"].ToString();
                    model.treatyrate = sqlDataReader["treatyrate"].ToString();
                    model.ftc = sqlDataReader["ftc"].ToString();
                    model.allowedftc = sqlDataReader["allowedftc"].ToString();
                    model.irregularincome = sqlDataReader["irregularincome"].ToString();
                    model.createdby = sqlDataReader["createdby"].ToString();
                    model.createddate = sqlDataReader["createddate"].ToString();
                    model.updatedby = sqlDataReader["updatedby"].ToString();
                    model.updateddate = sqlDataReader["updateddate"].ToString();

                    models.Add(model);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(models));
        }

        [WebMethod]
        public void GetIrregularByID(int id)
        {
            List<vm.Irregular> models = new List<vm.Irregular>();
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetIrregularByID", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = id
                });
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    vm.Irregular model = new vm.Irregular();
                    model.id = Convert.ToInt32(sqlDataReader["id"]);
                    model.TaxPlayerNumber = sqlDataReader["TaxPlayerNumber"].ToString();
                    model.form = sqlDataReader["form"].ToString();
                    model.year = sqlDataReader["year"].ToString();
                    model.country = sqlDataReader["country"].ToString();
                    model.data1 = sqlDataReader["data1"].ToString();
                    model.data2 = sqlDataReader["data2"].ToString();
                    model.data3 = sqlDataReader["data3"].ToString();
                    model.data4 = sqlDataReader["data4"].ToString();
                    model.data5 = sqlDataReader["data5"].ToString();
                    model.data6 = sqlDataReader["data6"].ToString();
                    model.data7 = sqlDataReader["data7"].ToString();
                    model.data8 = sqlDataReader["data8"].ToString();
                    model.data9 = sqlDataReader["data9"].ToString();
                    model.data10 = sqlDataReader["data10"].ToString();
                    model.createdby = sqlDataReader["createdby"].ToString();
                    model.createddate = sqlDataReader["createddate"].ToString();
                    model.updatedby = sqlDataReader["updatedby"].ToString();
                    model.updateddate = sqlDataReader["updateddate"].ToString();

                    models.Add(model);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(models));
        }

        [WebMethod]
        public void GetIncomeDetailedByID(int id)
        {
            List<vm.OverseasIncome> models = new List<vm.OverseasIncome>();
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetIncomeDetailedByID", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = id
                });
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    vm.OverseasIncome model = new vm.OverseasIncome();
                    model.id = Convert.ToInt32(sqlDataReader["id"]);
                    model.TaxPlayerNumber = sqlDataReader["TaxPlayerNumber"].ToString();
                    model.form = sqlDataReader["form"].ToString();
                    model.year = sqlDataReader["year"].ToString();
                    model.type = int.Parse(sqlDataReader["type"].ToString());
                    model.description = sqlDataReader["description"].ToString();
                    model.line = sqlDataReader["line"].ToString();
                    model.currency = sqlDataReader["currency"].ToString();
                    model.dateofreceipt = sqlDataReader["dateofreceipt"].ToString();
                    model.interval = sqlDataReader["interval"].ToString();
                    model.exchrate = sqlDataReader["exchrate"].ToString();
                    model.fullyearincome = sqlDataReader["fullyearincome"].ToString();
                    model.incomecurrency = sqlDataReader["incomecurrency"].ToString();
                    model.taxpaidcurrency = sqlDataReader["taxpaidcurrency"].ToString();
                    model.incomerp = sqlDataReader["incomerp"].ToString();
                    model.taxpaidrp = sqlDataReader["taxpaidrp"].ToString();
                    model.treatyrate = sqlDataReader["treatyrate"].ToString();
                    model.ftc = sqlDataReader["ftc"].ToString();
                    model.allowedftc = sqlDataReader["allowedftc"].ToString();
                    model.irregularincome = sqlDataReader["irregularincome"].ToString();
                    model.createdby = sqlDataReader["createdby"].ToString();
                    model.createddate = sqlDataReader["createddate"].ToString();
                    model.updatedby = sqlDataReader["updatedby"].ToString();
                    model.updateddate = sqlDataReader["updateddate"].ToString();

                    models.Add(model);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(models));
        }

        [WebMethod]
        public void GetAssetByID(int id)
        {
            List<vm.OverseasAsset> models = new List<vm.OverseasAsset>();
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetAssetByID", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = id
                });
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    vm.OverseasAsset model = new vm.OverseasAsset();
                    model.id = Convert.ToInt32(sqlDataReader["id"]);
                    model.TaxPlayerNumber = sqlDataReader["TaxPlayerNumber"].ToString();
                    model.type = int.Parse(sqlDataReader["type"].ToString());
                    model.form = sqlDataReader["form"].ToString();
                    model.year = sqlDataReader["year"].ToString();
                    model.as_id = sqlDataReader["as_id"].ToString();
                    model.as_refnumber = sqlDataReader["as_refnumber"].ToString();
                    model.as_details = sqlDataReader["as_details"].ToString();
                    model.as_currency = sqlDataReader["as_currency"].ToString();
                    model.as_balancedate = sqlDataReader["as_balancedate"].ToString();
                    model.as_interval = sqlDataReader["as_interval"].ToString();
                    model.as_originalcurrency = sqlDataReader["as_originalcurrency"].ToString();
                    model.as_exchrate = sqlDataReader["as_exchrate"].ToString();
                    model.as_inrupiah = sqlDataReader["as_inrupiah"].ToString();
                    model.as_owner = sqlDataReader["as_owner"].ToString();
                    model.as_address = sqlDataReader["as_address"].ToString();
                    model.as_account = sqlDataReader["as_account"].ToString();
                    model.as_country = sqlDataReader["as_country"].ToString();
                    model.createdby = sqlDataReader["createdby"].ToString();
                    model.createddate = sqlDataReader["createddate"].ToString();
                    model.updatedby = sqlDataReader["updatedby"].ToString();
                    model.updateddate = sqlDataReader["updateddate"].ToString();

                    models.Add(model);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(models));
        }

        [WebMethod]
        public void GetRentalByID(int id)
        {
            List<vm.OverseasRental> models = new List<vm.OverseasRental>();
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetRentalByID", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = id
                });
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    vm.OverseasRental model = new vm.OverseasRental();
                    model.id = Convert.ToInt32(sqlDataReader["id"]);
                    model.TaxPlayerNumber = sqlDataReader["TaxPlayerNumber"].ToString();
                    model.type = int.Parse(sqlDataReader["type"].ToString());
                    model.form = sqlDataReader["form"].ToString();
                    model.year = sqlDataReader["year"].ToString();
                    model.ren_information = sqlDataReader["ren_information"].ToString();
                    model.ren_country = sqlDataReader["ren_country"].ToString();
                    model.ren_currency = sqlDataReader["ren_currency"].ToString();
                    model.ren_dateofreceipt = sqlDataReader["ren_dateofreceipt"].ToString();
                    model.ren_interval = sqlDataReader["ren_interval"].ToString();
                    model.ren_exchrate = sqlDataReader["ren_exchrate"].ToString();
                    model.ren_amountcurrency = sqlDataReader["ren_amountcurrency"].ToString();
                    model.ren_amountrp = sqlDataReader["ren_amountrp"].ToString();
                    model.ren_irregularincome = sqlDataReader["ren_irregularincome"].ToString();
                    model.createdby = sqlDataReader["createdby"].ToString();
                    model.createddate = sqlDataReader["createddate"].ToString();
                    model.updatedby = sqlDataReader["updatedby"].ToString();
                    model.updateddate = sqlDataReader["updateddate"].ToString();

                    models.Add(model);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(models));
        }

        [WebMethod]
        public void GetCapitalByID(int id)
        {
            List<vm.OverseasCapital> models = new List<vm.OverseasCapital>();
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetCapitalByID", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = id
                });
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    vm.OverseasCapital model = new vm.OverseasCapital();
                    model.id = Convert.ToInt32(sqlDataReader["id"]);
                    model.TaxPlayerNumber = sqlDataReader["TaxPlayerNumber"].ToString();
                    model.form = sqlDataReader["form"].ToString();
                    model.year = sqlDataReader["year"].ToString();
                    model.cap_description = sqlDataReader["cap_description"].ToString();
                    model.cap_country = sqlDataReader["cap_country"].ToString();
                    model.cap_currency = sqlDataReader["cap_currency"].ToString();
                    model.cap_sellingdate = sqlDataReader["cap_sellingdate"].ToString();
                    model.cap_interval = sqlDataReader["cap_interval"].ToString();
                    model.cap_exchrate = sqlDataReader["cap_exchrate"].ToString();
                    model.cap_proceeds = sqlDataReader["cap_proceeds"].ToString();
                    model.cap_cost = sqlDataReader["cap_cost"].ToString();
                    model.cap_gainloss = sqlDataReader["cap_gainloss"].ToString();
                    model.cap_taxpaid = sqlDataReader["cap_taxpaid"].ToString();
                    model.cap_gainlossrp = sqlDataReader["cap_gainlossrp"].ToString();
                    model.cap_taxpaidrp = sqlDataReader["cap_taxpaidrp"].ToString();
                    model.cap_irregularincome = sqlDataReader["cap_irregularincome"].ToString();
                    model.createdby = sqlDataReader["createdby"].ToString();
                    model.createddate = sqlDataReader["createddate"].ToString();
                    model.updatedby = sqlDataReader["updatedby"].ToString();
                    model.updateddate = sqlDataReader["updateddate"].ToString();

                    models.Add(model);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(models));
        }

        [WebMethod]
        public void GetDescription(string code, string form)
        {
            if (int.Parse(code) < 10)
            {
                code = "0" + code;
            }
            List<vm.Assetsliabilities> models = new List<vm.Assetsliabilities>();
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetDescription", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@code",
                    Value = code
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@form",
                    Value = form
                });
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    vm.Assetsliabilities model = new vm.Assetsliabilities();
                    model.id = int.Parse(sqlDataReader["id"].ToString());
                    model.account = sqlDataReader["account"].ToString();
                    model.code = sqlDataReader["code"].ToString();

                    models.Add(model);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(models));
        }

    }
}
