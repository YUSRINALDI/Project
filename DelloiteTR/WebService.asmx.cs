using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;
using vm=DelloiteTRLib.Model;
using System.Web.Script.Services;

namespace DelloiteTR
{
    /// <summary>
    /// Summary description for FamilyService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddNewFamily(vm.Family family)
        {
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spAddNewFamily", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@TaxPlayerNumber",
                    Value = family.TaxPlayerNumber
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@form",
                    Value = family.form
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@year",
                    Value = family.year
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@ammend",
                    Value = family.ammend
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Name",
                    Value = family.Name
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Relationship",
                    Value = family.Relationship
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Birthdate",
                    Value = family.Birthdate
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Occupation",
                    Value = family.Occupation
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@NIK",
                    Value = family.NIK
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@createdby",
                    Value = family.createdby
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@createddate",
                    Value = family.createddate
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@updatedby",
                    Value = family.updatedby
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@updateddate",
                    Value = family.updateddate
                });
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void EditFamily(vm.Family family)
        {
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spEditFamily", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = family.id
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@TaxPlayerNumber",
                    Value = family.TaxPlayerNumber
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Name",
                    Value = family.Name
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Relationship",
                    Value = family.Relationship
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Birthdate",
                    Value = family.Birthdate
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Occupation",
                    Value = family.Occupation
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@NIK",
                    Value = family.NIK
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@updatedby",
                    Value = family.updatedby
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@updateddate",
                    Value = family.updateddate
                });
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteFamily(vm.Family family)
        {
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spDeleteFamily", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = family.id
                });
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        [WebMethod]
        public void GetFamiliesBy(string TaxPayerNumber, string form, string year, int ammend)
        {
            List<vm.Family> families = new List<vm.Family>();
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetFamilies", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@TaxPayerNumber",
                    Value = TaxPayerNumber
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
                    vm.Family family = new vm.Family();
                    family.id = Convert.ToInt32(sqlDataReader["id"]);
                    family.TaxPlayerNumber = sqlDataReader["TaxPayerNumber"].ToString();
                    family.form = sqlDataReader["form"].ToString();
                    family.year = sqlDataReader["year"].ToString();
                    family.Name = sqlDataReader["Name"].ToString();
                    family.Relationship = sqlDataReader["Relationship"].ToString();
                    family.Birthdate = sqlDataReader["Birthdate"].ToString();
                    family.Occupation = sqlDataReader["Occupation"].ToString();
                    family.NIK = sqlDataReader["NIK"].ToString();
                    family.createdby = sqlDataReader["createdby"].ToString();
                    family.createddate = sqlDataReader["createddate"].ToString();
                    family.updatedby = sqlDataReader["updatedby"].ToString();
                    family.updateddate = sqlDataReader["updateddate"].ToString();

                    families.Add(family);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(families));
        }

        [WebMethod]
        public void GetFamiliesByID(int id)
        {
            List<vm.Family> families = new List<vm.Family>();
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetFamily", sqlConnection);
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
                    vm.Family family = new vm.Family();
                    family.id = Convert.ToInt32(sqlDataReader["id"]);
                    family.TaxPlayerNumber = sqlDataReader["TaxPayerNumber"].ToString();
                    family.form = sqlDataReader["form"].ToString();
                    family.year = sqlDataReader["year"].ToString();
                    family.Name = sqlDataReader["Name"].ToString();
                    family.RelationshipID = Convert.ToInt32(sqlDataReader["RelationshipID"]);
                    family.Relationship = sqlDataReader["Relationship"].ToString();
                    family.Birthdate = sqlDataReader["Birthdate"].ToString();
                    family.Occupation = sqlDataReader["Occupation"].ToString();
                    family.NIK = sqlDataReader["NIK"].ToString();
                    family.createdby = sqlDataReader["createdby"].ToString();
                    family.createddate = sqlDataReader["createddate"].ToString();
                    family.updatedby = sqlDataReader["updatedby"].ToString();
                    family.updateddate = sqlDataReader["updateddate"].ToString();

                    families.Add(family);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(families));
        }

        [WebMethod]
        public void GetRelationship()
        {
            List<vm.Relationship> relationships = new List<vm.Relationship>();
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetRelationships", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    vm.Relationship relationship = new vm.Relationship();
                    relationship.id = Convert.ToInt32(sqlDataReader["id"]);
                    relationship.relationship = sqlDataReader["relationship"].ToString();
                    relationship.createdby = sqlDataReader["createdby"].ToString();
                    relationship.createddate = sqlDataReader["createddate"].ToString();
                    relationship.updatedby = sqlDataReader["updatedby"].ToString();
                    relationship.updateddate = sqlDataReader["updateddate"].ToString();

                    relationships.Add(relationship);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(relationships));
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddNewIEIncome(vm.IEIncome jsonData)
        {
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spAddNewIEIncome", sqlConnection);
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
                    ParameterName = "@field1",
                    Value = jsonData.field1
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field2",
                    Value = jsonData.field2
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field3",
                    Value = jsonData.field3
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field4",
                    Value = jsonData.field4
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field5",
                    Value = jsonData.field5
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field6",
                    Value = jsonData.field6
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field7",
                    Value = jsonData.field7
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field8",
                    Value = jsonData.field8
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field9",
                    Value = jsonData.field9
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field10",
                    Value = jsonData.field10
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field11",
                    Value = jsonData.field11
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field12",
                    Value = jsonData.field12
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field13",
                    Value = jsonData.field13
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field14",
                    Value = jsonData.field14
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field15",
                    Value = jsonData.field15
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field16",
                    Value = jsonData.field16
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field17",
                    Value = jsonData.field17
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field18",
                    Value = jsonData.field18
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field19",
                    Value = jsonData.field19
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field20",
                    Value = jsonData.field20
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field21",
                    Value = jsonData.field21
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field22",
                    Value = jsonData.field22
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field23",
                    Value = jsonData.field23
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field24",
                    Value = jsonData.field24
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field25",
                    Value = jsonData.field25
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field26",
                    Value = jsonData.field26
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field27",
                    Value = jsonData.field27
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field28",
                    Value = jsonData.field28
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field29",
                    Value = jsonData.field29
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void SaveEditIEIncome(vm.IEIncome jsonData)
        {
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spSaveEditIEIncome", sqlConnection);
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
                    ParameterName = "@field1",
                    Value = jsonData.field1
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field2",
                    Value = jsonData.field2
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field3",
                    Value = jsonData.field3
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field4",
                    Value = jsonData.field4
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field5",
                    Value = jsonData.field5
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field6",
                    Value = jsonData.field6
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field7",
                    Value = jsonData.field7
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field8",
                    Value = jsonData.field8
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field9",
                    Value = jsonData.field9
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field10",
                    Value = jsonData.field10
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field11",
                    Value = jsonData.field11
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field12",
                    Value = jsonData.field12
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field13",
                    Value = jsonData.field13
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field14",
                    Value = jsonData.field14
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field15",
                    Value = jsonData.field15
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field16",
                    Value = jsonData.field16
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field17",
                    Value = jsonData.field17
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field18",
                    Value = jsonData.field18
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field19",
                    Value = jsonData.field19
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field20",
                    Value = jsonData.field20
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field21",
                    Value = jsonData.field21
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field22",
                    Value = jsonData.field22
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field23",
                    Value = jsonData.field23
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field24",
                    Value = jsonData.field24
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field25",
                    Value = jsonData.field25
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field26",
                    Value = jsonData.field26
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field27",
                    Value = jsonData.field27
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field28",
                    Value = jsonData.field28
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@field29",
                    Value = jsonData.field29
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

        [WebMethod]
        public void GetIEIncomeBy(string TaxPlayerNumber, string form, string year, int ammend)
        {
            List<vm.IEIncome> datas = new List<vm.IEIncome>();
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetIEIncomeBy", sqlConnection);
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
                    vm.IEIncome data = new vm.IEIncome();
                    data.id = Convert.ToInt32(sqlDataReader["id"]);
                    data.TaxPlayerNumber = sqlDataReader["TaxPlayerNumber"].ToString();

                    data.form = sqlDataReader["form"].ToString();
                    data.year = sqlDataReader["year"].ToString();

                    data.field1 = sqlDataReader["field1"].ToString();
                    data.field2 = sqlDataReader["field2"].ToString();
                    data.field3 = sqlDataReader["field3"].ToString();
                    data.field4 = sqlDataReader["field4"].ToString();
                    data.field5 = sqlDataReader["field5"].ToString();
                    data.field6 = sqlDataReader["field6"].ToString();
                    data.field7 = sqlDataReader["field7"].ToString();
                    data.field8 = sqlDataReader["field8"].ToString();
                    data.field9 = sqlDataReader["field9"].ToString();
                    data.field10 = sqlDataReader["field10"].ToString();
                    data.field11 = sqlDataReader["field11"].ToString();
                    data.field12 = sqlDataReader["field12"].ToString();
                    data.field13 = sqlDataReader["field13"].ToString();
                    data.field14 = sqlDataReader["field14"].ToString();
                    data.field15 = sqlDataReader["field15"].ToString();
                    data.field16 = sqlDataReader["field16"].ToString();
                    data.field17 = sqlDataReader["field17"].ToString();
                    data.field18 = sqlDataReader["field18"].ToString();
                    data.field19 = sqlDataReader["field19"].ToString();
                    data.field20 = sqlDataReader["field20"].ToString();
                    data.field21 = sqlDataReader["field21"].ToString();
                    data.field22 = sqlDataReader["field22"].ToString();
                    data.field23 = sqlDataReader["field23"].ToString();
                    data.field24 = sqlDataReader["field24"].ToString();
                    data.field25 = sqlDataReader["field25"].ToString();
                    data.field26 = sqlDataReader["field26"].ToString();
                    data.field27 = sqlDataReader["field27"].ToString();
                    data.field28 = sqlDataReader["field28"].ToString();
                    data.field29 = sqlDataReader["field29"].ToString();

                    data.createdby = sqlDataReader["createdby"].ToString();
                    data.createddate = sqlDataReader["createddate"].ToString();
                    data.updatedby = sqlDataReader["updatedby"].ToString();
                    data.updateddate = sqlDataReader["updateddate"].ToString();

                    datas.Add(data);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(datas));
        }
        
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteIEIncome(vm.IEIncome jsonData)
        {
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spDeleteIEIncome", sqlConnection);
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
        public void GetIEIncomeByID(int id)
        {
            List<vm.IEIncome> datas = new List<vm.IEIncome>();
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetIEIncomeByID", sqlConnection);
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
                    vm.IEIncome data = new vm.IEIncome();
                    data.id = Convert.ToInt32(sqlDataReader["id"]);
                    data.TaxPlayerNumber = sqlDataReader["TaxPlayerNumber"].ToString();

                    data.form = sqlDataReader["form"].ToString();
                    data.year = sqlDataReader["year"].ToString();

                    data.field1 = sqlDataReader["field1"].ToString();
                    data.field2 = sqlDataReader["field2"].ToString();
                    data.field3 = sqlDataReader["field3"].ToString();
                    data.field4 = sqlDataReader["field4"].ToString();
                    data.field5 = sqlDataReader["field5"].ToString();
                    data.field6 = sqlDataReader["field6"].ToString();
                    data.field7 = sqlDataReader["field7"].ToString();
                    data.field8 = sqlDataReader["field8"].ToString();
                    data.field9 = sqlDataReader["field9"].ToString();
                    data.field10 = sqlDataReader["field10"].ToString();
                    data.field11 = sqlDataReader["field11"].ToString();
                    data.field12 = sqlDataReader["field12"].ToString();
                    data.field13 = sqlDataReader["field13"].ToString();
                    data.field14 = sqlDataReader["field14"].ToString();
                    data.field15 = sqlDataReader["field15"].ToString();
                    data.field16 = sqlDataReader["field16"].ToString();
                    data.field17 = sqlDataReader["field17"].ToString();
                    data.field18 = sqlDataReader["field18"].ToString();
                    data.field19 = sqlDataReader["field19"].ToString();
                    data.field20 = sqlDataReader["field20"].ToString();
                    data.field21 = sqlDataReader["field21"].ToString();
                    data.field22 = sqlDataReader["field22"].ToString();
                    data.field23 = sqlDataReader["field23"].ToString();
                    data.field24 = sqlDataReader["field24"].ToString();
                    data.field25 = sqlDataReader["field25"].ToString();
                    data.field26 = sqlDataReader["field26"].ToString();
                    data.field27 = sqlDataReader["field27"].ToString();
                    data.field28 = sqlDataReader["field28"].ToString();
                    data.field29 = sqlDataReader["field29"].ToString();

                    data.createdby = sqlDataReader["createdby"].ToString();
                    data.createddate = sqlDataReader["createddate"].ToString();
                    data.updatedby = sqlDataReader["updatedby"].ToString();
                    data.updateddate = sqlDataReader["updateddate"].ToString();

                    datas.Add(data);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(datas));
        }

        [WebMethod]
        public void GetReliefs(string year, string status)
        {
            List<vm.Marital> datas = new List<vm.Marital>();
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetReliefs", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@year",
                    Value = year
                });
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@status",
                    Value = status
                });
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    vm.Marital data = new vm.Marital();
                    data.id = Convert.ToInt32(sqlDataReader["id"]);
                    data.amount = int.Parse(sqlDataReader["amount"].ToString());
                    data.dependant = int.Parse(sqlDataReader["dependant"].ToString());
                    data.status = sqlDataReader["status"].ToString();

                    datas.Add(data);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(datas));
        }
    }
}
