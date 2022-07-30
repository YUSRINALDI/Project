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
    /// Summary description for Calculation
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Calculation : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<vm.TaxForm> GetTaxFormByID(int id)
        {
            List<vm.TaxForm> models = new List<vm.TaxForm>();
            vm.TaxForm model = new vm.TaxForm();
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetTaxFormByID", sqlConnection);
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
                    model = new vm.TaxForm();
                    model.id = Convert.ToInt32(sqlDataReader["id"]);

                    model.TaxPayerNumber = sqlDataReader["TaxPayerNumber"].ToString();

                    model.ammend = int.Parse(sqlDataReader["ammend"].ToString());
                    model.status = int.Parse(sqlDataReader["status"].ToString());
                    model.taxidnumber = sqlDataReader["taxidnumber"].ToString();
                    model.type = sqlDataReader["type"].ToString();
                    model.year = sqlDataReader["year"].ToString();
                    model.t1s1f2 = sqlDataReader["t1s1f2"].ToString();
                    model.t1s1f4 = sqlDataReader["t1s1f4"].ToString();
                    model.t1s1f5 = sqlDataReader["t1s1f5"].ToString();
                    model.t1s1f6 = sqlDataReader["t1s1f6"].ToString();
                    model.t1s1f7 = sqlDataReader["t1s1f7"].ToString();
                    model.t1s1f8 = sqlDataReader["t1s1f8"].ToString();
                    model.t1s2f1 = sqlDataReader["t1s2f1"].ToString();
                    model.t1s2f2 = sqlDataReader["t1s2f2"].ToString();
                    model.t1s2f3 = sqlDataReader["t1s2f3"].ToString();
                    model.t1s2f4 = sqlDataReader["t1s2f4"].ToString();
                    model.t1s2f5 = sqlDataReader["t1s2f5"].ToString();
                    model.t1s2f6 = sqlDataReader["t1s2f6"].ToString();
                    model.t1s2f7 = sqlDataReader["t1s2f7"].ToString();
                    model.t1s2f8 = sqlDataReader["t1s2f8"].ToString();
                    model.t1s2f9 = sqlDataReader["t1s2f9"].ToString();
                    model.t1s2f10 = sqlDataReader["t1s2f10"].ToString();
                    model.t1s2f11 = sqlDataReader["t1s2f11"].ToString();
                    model.t1s2f12 = sqlDataReader["t1s2f12"].ToString();
                    model.t1s2f13 = sqlDataReader["t1s2f13"].ToString();
                    model.t1s2f14 = sqlDataReader["t1s2f14"].ToString();
                    model.t1s2f15 = sqlDataReader["t1s2f15"].ToString();
                    model.t1s2f16 = sqlDataReader["t1s2f16"].ToString();
                    model.t1s2f17 = sqlDataReader["t1s2f17"].ToString();
                    model.t1s2f18 = sqlDataReader["t1s2f18"].ToString();
                    model.t1s2f19 = sqlDataReader["t1s2f19"].ToString();
                    model.t1s2f20 = sqlDataReader["t1s2f20"].ToString();
                    model.t1s2f21 = sqlDataReader["t1s2f21"].ToString();
                    model.t1s2f22 = sqlDataReader["t1s2f22"].ToString();
                    model.t1s2f23 = sqlDataReader["t1s2f23"].ToString();
                    model.t1s2f24 = sqlDataReader["t1s2f24"].ToString();
                    model.t1s3f1 = sqlDataReader["t1s3f1"].ToString();
                    model.t1s3f2 = sqlDataReader["t1s3f2"].ToString();
                    model.t1s3f3 = sqlDataReader["t1s3f3"].ToString();
                    model.t1s4f1 = sqlDataReader["t1s4f1"].ToString();
                    model.t1s4f2 = sqlDataReader["t1s4f2"].ToString();
                    model.t1s4f3 = sqlDataReader["t1s4f3"].ToString();
                    model.t1s4f4 = sqlDataReader["t1s4f4"].ToString();
                    model.t1s4f5 = sqlDataReader["t1s4f5"].ToString();
                    model.t1s4f6 = sqlDataReader["t1s4f6"].ToString();
                    model.t1s4f7 = sqlDataReader["t1s4f7"].ToString();
                    model.t1s4f8 = sqlDataReader["t1s4f8"].ToString();
                    model.t1s4f9 = sqlDataReader["t1s4f9"].ToString();
                    model.t1s4f10 = sqlDataReader["t1s4f10"].ToString();
                    model.t1s4f11 = sqlDataReader["t1s4f11"].ToString();
                    model.t1s4f12 = sqlDataReader["t1s4f12"].ToString();
                    model.t1s4f13 = sqlDataReader["t1s4f13"].ToString();
                    model.t1s4f14 = sqlDataReader["t1s4f14"].ToString();
                    model.t1s4f15 = sqlDataReader["t1s4f15"].ToString();
                    model.t1s4f16 = sqlDataReader["t1s4f16"].ToString();
                    model.t1s4f17 = sqlDataReader["t1s4f17"].ToString();
                    model.t1s4f18 = sqlDataReader["t1s4f18"].ToString();
                    model.t1s4f19 = sqlDataReader["t1s4f19"].ToString();
                    model.t1s4f20 = sqlDataReader["t1s4f20"].ToString();
                    model.t1s4f21 = sqlDataReader["t1s4f21"].ToString();
                    model.t1s4f22 = sqlDataReader["t1s4f22"].ToString();
                    model.t1s4f23 = sqlDataReader["t1s4f23"].ToString();
                    model.t1s4f24 = sqlDataReader["t1s4f24"].ToString();
                    model.t1s4f25 = sqlDataReader["t1s4f25"].ToString();
                    model.t1s4f26 = sqlDataReader["t1s4f26"].ToString();
                    model.t1s4f27 = sqlDataReader["t1s4f27"].ToString();
                    model.t1s4f28 = sqlDataReader["t1s4f28"].ToString();
                    model.t1s4f29 = sqlDataReader["t1s4f29"].ToString();
                    model.t1s4f30 = sqlDataReader["t1s4f30"].ToString();
                    model.t1s4f31 = sqlDataReader["t1s4f31"].ToString();
                    model.t1s4f32 = sqlDataReader["t1s4f32"].ToString();
                    model.t1s4f33 = sqlDataReader["t1s4f33"].ToString();
                    model.t1s4f34 = sqlDataReader["t1s4f34"].ToString();
                    model.t1s4f35 = sqlDataReader["t1s4f35"].ToString();
                    model.t1s4f36 = sqlDataReader["t1s4f36"].ToString();
                    model.t1s4f37 = sqlDataReader["t1s4f37"].ToString();
                    model.t1s4f38 = sqlDataReader["t1s4f38"].ToString();
                    model.t1s4f39 = sqlDataReader["t1s4f39"].ToString();
                    model.t1s4f40 = sqlDataReader["t1s4f40"].ToString();
                    model.t1s4f41 = sqlDataReader["t1s4f41"].ToString();
                    model.t1s4f42 = sqlDataReader["t1s4f42"].ToString();
                    model.t1s4f43 = sqlDataReader["t1s4f43"].ToString();
                    model.t1s4f44 = sqlDataReader["t1s4f44"].ToString();
                    model.t1s4f45 = sqlDataReader["t1s4f45"].ToString();
                    model.t1s4f46 = sqlDataReader["t1s4f46"].ToString();
                    model.t1s4f47 = sqlDataReader["t1s4f47"].ToString();
                    model.t1s4f48 = sqlDataReader["t1s4f48"].ToString();
                    model.t1s4f49 = sqlDataReader["t1s4f49"].ToString();
                    model.t1s4f50 = sqlDataReader["t1s4f50"].ToString();
                    model.t1s4f51 = sqlDataReader["t1s4f51"].ToString();
                    model.t1s4f52 = sqlDataReader["t1s4f52"].ToString();
                    model.t1s4f53 = sqlDataReader["t1s4f53"].ToString();
                    model.t1s4f54 = sqlDataReader["t1s4f54"].ToString();
                    model.totalemployee = sqlDataReader["totalemployee"].ToString();
                    model.totalperiod = sqlDataReader["totalperiod"].ToString();
                    model.totalsalaries = sqlDataReader["totalsalaries"].ToString();
                    model.totalincome = sqlDataReader["totalincome"].ToString();
                    model.totalother = sqlDataReader["totalother"].ToString();
                    model.totalhonorarium = sqlDataReader["totalhonorarium"].ToString();
                    model.totalinsurance = sqlDataReader["totalinsurance"].ToString();
                    model.totalbenefit = sqlDataReader["totalbenefit"].ToString();
                    model.totalbonus = sqlDataReader["totalbonus"].ToString();
                    model.totalgross = sqlDataReader["totalgross"].ToString();
                    model.totalcost = sqlDataReader["totalcost"].ToString();
                    model.totalpension = sqlDataReader["totalpension"].ToString();
                    model.totaldeductions = sqlDataReader["totaldeductions"].ToString();
                    model.totalnetincome = sqlDataReader["totalnetincome"].ToString();
                    model.totalincometax = sqlDataReader["totalincometax"].ToString();
                    model.totalprevnetincome = sqlDataReader["totalprevnetincome"].ToString();
                    model.totalprevincometax = sqlDataReader["totalprevincometax"].ToString();
                    model.t1s6f1 = sqlDataReader["t1s6f1"].ToString();
                    model.t1s6f2 = sqlDataReader["t1s6f2"].ToString();
                    model.t1s6f3 = sqlDataReader["t1s6f3"].ToString();
                    model.t1s6f4 = sqlDataReader["t1s6f4"].ToString();
                    model.t1s6f5 = sqlDataReader["t1s6f5"].ToString();
                    model.t1s6f6 = sqlDataReader["t1s6f6"].ToString();
                    model.t1s6f7 = sqlDataReader["t1s6f7"].ToString();
                    model.t1s6f8 = sqlDataReader["t1s6f8"].ToString();
                    model.t1s6f9 = sqlDataReader["t1s6f9"].ToString();
                    model.t1s6f10 = sqlDataReader["t1s6f10"].ToString();
                    model.t1s6f11 = sqlDataReader["t1s6f11"].ToString();
                    model.t1s6f12 = sqlDataReader["t1s6f12"].ToString();
                    model.t1s6f13 = sqlDataReader["t1s6f13"].ToString();
                    model.t1s6f14 = sqlDataReader["t1s6f14"].ToString();
                    model.t1s6f15 = sqlDataReader["t1s6f15"].ToString();
                    model.t1s6f16 = sqlDataReader["t1s6f16"].ToString();
                    model.t1s6f17 = sqlDataReader["t1s6f17"].ToString();
                    model.t1s6f18 = sqlDataReader["t1s6f18"].ToString();
                    model.t1s6f19 = sqlDataReader["t1s6f19"].ToString();
                    model.t1s6f20 = sqlDataReader["t1s6f20"].ToString();
                    model.t1s6f21 = sqlDataReader["t1s6f21"].ToString();
                    model.t1s6f22 = sqlDataReader["t1s6f22"].ToString();
                    model.t1s6f23 = sqlDataReader["t1s6f23"].ToString();
                    model.t1s6f24 = sqlDataReader["t1s6f24"].ToString();
                    model.t1s6f25 = sqlDataReader["t1s6f25"].ToString();
                    model.t1s7f1 = sqlDataReader["t1s7f1"].ToString();
                    model.t1s7f2 = sqlDataReader["t1s7f2"].ToString();
                    model.t1s7f3 = sqlDataReader["t1s7f3"].ToString();
                    model.t1s7f4 = sqlDataReader["t1s7f4"].ToString();
                    model.t1s7f5 = sqlDataReader["t1s7f5"].ToString();
                    model.t1s7f6 = sqlDataReader["t1s7f6"].ToString();
                    model.t1s7f7 = sqlDataReader["t1s7f7"].ToString();
                    model.t1s7f8 = sqlDataReader["t1s7f8"].ToString();
                    model.t1s7f9 = sqlDataReader["t1s7f9"].ToString();
                    model.t1s7f10 = sqlDataReader["t1s7f10"].ToString();
                    model.t1s7f11 = sqlDataReader["t1s7f11"].ToString();
                    model.t1s7f12 = sqlDataReader["t1s7f12"].ToString();
                    model.t1s7f13 = sqlDataReader["t1s7f13"].ToString();
                    model.t1s7f14 = sqlDataReader["t1s7f14"].ToString();
                    model.t1s7f15 = sqlDataReader["t1s7f15"].ToString();
                    model.t1s7f16 = sqlDataReader["t1s7f16"].ToString();
                    model.t1s7f17 = sqlDataReader["t1s7f17"].ToString();
                    model.t1s7f18 = sqlDataReader["t1s7f18"].ToString();
                    model.t1s7f19 = sqlDataReader["t1s7f19"].ToString();
                    model.t1s7f20 = sqlDataReader["t1s7f20"].ToString();
                    model.t1s7f21 = sqlDataReader["t1s7f21"].ToString();
                    model.t1s7f22 = sqlDataReader["t1s7f22"].ToString();
                    model.t1s7f23 = sqlDataReader["t1s7f23"].ToString();
                    model.t1s7f24 = sqlDataReader["t1s7f24"].ToString();
                    model.t1s7f25 = sqlDataReader["t1s7f25"].ToString();
                    model.t1s7f26 = sqlDataReader["t1s7f26"].ToString();
                    model.t1s7f27 = sqlDataReader["t1s7f27"].ToString();
                    model.t1s7f28 = sqlDataReader["t1s7f28"].ToString();
                    model.t1s7f29 = sqlDataReader["t1s7f29"].ToString();
                    model.t1s7f30 = sqlDataReader["t1s7f30"].ToString();
                    model.t1s7f31 = sqlDataReader["t1s7f31"].ToString();
                    model.t1s7f32 = sqlDataReader["t1s7f32"].ToString();
                    model.t1s7f33 = sqlDataReader["t1s7f33"].ToString();
                    model.t1s7f34 = sqlDataReader["t1s7f34"].ToString();
                    model.t1s7f35 = sqlDataReader["t1s7f35"].ToString();
                    model.t1s7f36 = sqlDataReader["t1s7f36"].ToString();
                    model.t1s7f37 = sqlDataReader["t1s7f37"].ToString();
                    model.t1s7f38 = sqlDataReader["t1s7f38"].ToString();
                    model.t1s7f39 = sqlDataReader["t1s7f39"].ToString();
                    model.t1s8f1 = sqlDataReader["t1s8f1"].ToString();
                    model.t1s8f2 = sqlDataReader["t1s8f2"].ToString();
                    model.t1s8f3 = sqlDataReader["t1s8f3"].ToString();
                    model.t1s8f4 = sqlDataReader["t1s8f4"].ToString();
                    model.t1s8f5 = sqlDataReader["t1s8f5"].ToString();
                    model.t1s8f6 = sqlDataReader["t1s8f6"].ToString();
                    model.t1s8f7 = sqlDataReader["t1s8f7"].ToString();
                    model.t1s8f8 = sqlDataReader["t1s8f8"].ToString();
                    model.t1s8f9 = sqlDataReader["t1s8f9"].ToString();
                    model.t1s8f10 = sqlDataReader["t1s8f10"].ToString();
                    model.t1s8f11 = sqlDataReader["t1s8f11"].ToString();
                    model.t1s8f12 = sqlDataReader["t1s8f12"].ToString();
                    model.t1s8f13 = sqlDataReader["t1s8f13"].ToString();
                    model.t1s8f14 = sqlDataReader["t1s8f14"].ToString();
                    model.t1s8f15 = sqlDataReader["t1s8f15"].ToString();
                    model.t1s8f16 = sqlDataReader["t1s8f16"].ToString();
                    model.t1s8f17 = sqlDataReader["t1s8f17"].ToString();
                    model.t1s8f18 = sqlDataReader["t1s8f18"].ToString();
                    model.t1s8f19 = sqlDataReader["t1s8f19"].ToString();
                    model.t1s8f20 = sqlDataReader["t1s8f20"].ToString();
                    model.t1s8f21 = sqlDataReader["t1s8f21"].ToString();
                    model.t1s8f22 = sqlDataReader["t1s8f22"].ToString();
                    model.t1s8f23 = sqlDataReader["t1s8f23"].ToString();
                    model.t1s8f24 = sqlDataReader["t1s8f24"].ToString();
                    model.t1s8f25 = sqlDataReader["t1s8f25"].ToString();
                    model.t1s8f26 = sqlDataReader["t1s8f26"].ToString();
                    model.t1s8f27 = sqlDataReader["t1s8f27"].ToString();
                    model.t1s8f28 = sqlDataReader["t1s8f28"].ToString();
                    model.t1s8f29 = sqlDataReader["t1s8f29"].ToString();
                    model.t1s8f30 = sqlDataReader["t1s8f30"].ToString();
                    model.t1s8f31 = sqlDataReader["t1s8f31"].ToString();
                    model.t1s8f32 = sqlDataReader["t1s8f32"].ToString();
                    model.t1s8f33 = sqlDataReader["t1s8f33"].ToString();
                    model.t1s8f34 = sqlDataReader["t1s8f34"].ToString();
                    model.t1s8f35 = sqlDataReader["t1s8f35"].ToString();
                    model.t1s8f36 = sqlDataReader["t1s8f36"].ToString();
                    model.t1s8f37 = sqlDataReader["t1s8f37"].ToString();
                    model.t1s8f38 = sqlDataReader["t1s8f38"].ToString();
                    model.t1s8f39 = sqlDataReader["t1s8f39"].ToString();
                    model.t1s8f40 = sqlDataReader["t1s8f40"].ToString();
                    model.t1s8f41 = sqlDataReader["t1s8f41"].ToString();
                    model.t1s8f42 = sqlDataReader["t1s8f42"].ToString();
                    model.t1s8f43 = sqlDataReader["t1s8f43"].ToString();
                    model.total1 = sqlDataReader["total1"].ToString();
                    model.total2 = sqlDataReader["total2"].ToString();
                    model.total3 = sqlDataReader["total3"].ToString();
                    model.total4 = sqlDataReader["total4"].ToString();
                    model.total5 = sqlDataReader["total5"].ToString();
                    model.total6 = sqlDataReader["total6"].ToString();
                    model.total7 = sqlDataReader["total7"].ToString();
                    model.total8 = sqlDataReader["total8"].ToString();
                    model.total9 = sqlDataReader["total9"].ToString();
                    model.total10 = sqlDataReader["total10"].ToString();
                    model.total11 = sqlDataReader["total11"].ToString();
                    model.total12 = sqlDataReader["total12"].ToString();
                    model.total13 = sqlDataReader["total13"].ToString();
                    model.total14 = sqlDataReader["total14"].ToString();
                    model.total15 = sqlDataReader["total15"].ToString();
                    model.total16 = sqlDataReader["total16"].ToString();
                    model.total17 = sqlDataReader["total17"].ToString();
                    model.total18 = sqlDataReader["total18"].ToString();
                    model.total19 = sqlDataReader["total19"].ToString();
                    model.total20 = sqlDataReader["total20"].ToString();
                    model.total21 = sqlDataReader["total21"].ToString();
                    model.total22 = sqlDataReader["total22"].ToString();
                    model.total23 = sqlDataReader["total23"].ToString();
                    model.total24 = sqlDataReader["total24"].ToString();
                    model.total25 = sqlDataReader["total25"].ToString();
                    model.total26 = sqlDataReader["total26"].ToString();
                    model.ren_netamountcurrency = sqlDataReader["ren_netamountcurrency"].ToString();
                    model.ren_netamountrp = sqlDataReader["ren_netamountrp"].ToString();
                    model.ren_nettaxpaidcurrency = sqlDataReader["ren_nettaxpaidcurrency"].ToString();
                    model.ren_nettaxpaidexchrate = sqlDataReader["ren_nettaxpaidexchrate"].ToString();
                    model.ren_nettaxpaidamountrp = sqlDataReader["ren_nettaxpaidamountrp"].ToString();
                    model.tabirregulartotal1 = sqlDataReader["tabirregulartotal1"].ToString();
                    model.tabirregulartotal2 = sqlDataReader["tabirregulartotal2"].ToString();
                    model.irregulartaxcredit = sqlDataReader["irregulartaxcredit"].ToString();
                    model.lbltotalsummary1 = sqlDataReader["lbltotalsummary1"].ToString();
                    model.lbltotalsummary2 = sqlDataReader["lbltotalsummary2"].ToString();
                    model.tabasset1 = sqlDataReader["tabasset1"].ToString();
                    model.tabasset2 = sqlDataReader["tabasset2"].ToString();
                    model.tabasset3 = sqlDataReader["tabasset3"].ToString();
                    model.tabasset4 = sqlDataReader["tabasset4"].ToString();
                    model.tabasset5 = sqlDataReader["tabasset5"].ToString();
                    model.tabasset6 = sqlDataReader["tabasset6"].ToString();
                    model.tabasset10 = sqlDataReader["tabasset10"].ToString();
                    model.tab3nettotalasset = sqlDataReader["tab3nettotalasset"].ToString();
                    model.tab3nettotalliabilities = sqlDataReader["tab3nettotalliabilities"].ToString();
                    model.tab3netasset = sqlDataReader["tab3netasset"].ToString();
                    model.createdby = sqlDataReader["createdby"].ToString();
                    model.createddate = sqlDataReader["createddate"].ToString();
                    model.updatedby = sqlDataReader["updatedby"].ToString();
                    model.updateddate = sqlDataReader["updateddate"].ToString();


                    model.netincomeroundedyes = sqlDataReader["netincomeroundedyes"].ToString();
                    model.bonusroundedyes = sqlDataReader["bonusroundedyes"].ToString();
                    model.totalperiodroundedyes = sqlDataReader["totalperiodroundedyes"].ToString();

                    model.netincomeroundednot = sqlDataReader["netincomeroundednot"].ToString();
                    model.bonusroundednot = sqlDataReader["bonusroundednot"].ToString();
                    model.totalperiodroundednot = sqlDataReader["totalperiodroundednot"].ToString();

                    models.Add(model);
                }
            }
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //Context.Response.Write(js.Serialize(models));

            return models;
        }

        [WebMethod]
        public void GetTaxFormByIDJSON(int id)
        {
            List<vm.TaxForm> models = new List<vm.TaxForm>();
            vm.TaxForm model = new vm.TaxForm();
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetTaxFormByID", sqlConnection);
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
                    model = new vm.TaxForm();
                    model.id = Convert.ToInt32(sqlDataReader["id"]);

                    model.TaxPayerNumber = sqlDataReader["TaxPayerNumber"].ToString();

                    model.ammend = int.Parse(sqlDataReader["ammend"].ToString());
                    model.status = int.Parse(sqlDataReader["status"].ToString());
                    model.taxidnumber = sqlDataReader["taxidnumber"].ToString();
                    model.type = sqlDataReader["type"].ToString();
                    model.year = sqlDataReader["year"].ToString();
                    model.t1s1f2 = sqlDataReader["t1s1f2"].ToString();
                    model.t1s1f4 = sqlDataReader["t1s1f4"].ToString();
                    model.t1s1f5 = sqlDataReader["t1s1f5"].ToString();
                    model.t1s1f6 = sqlDataReader["t1s1f6"].ToString();
                    model.t1s1f7 = sqlDataReader["t1s1f7"].ToString();
                    model.t1s1f8 = sqlDataReader["t1s1f8"].ToString();
                    model.t1s2f1 = sqlDataReader["t1s2f1"].ToString();
                    model.t1s2f2 = sqlDataReader["t1s2f2"].ToString();
                    model.t1s2f3 = sqlDataReader["t1s2f3"].ToString();
                    model.t1s2f4 = sqlDataReader["t1s2f4"].ToString();
                    model.t1s2f5 = sqlDataReader["t1s2f5"].ToString();
                    model.t1s2f6 = sqlDataReader["t1s2f6"].ToString();
                    model.t1s2f7 = sqlDataReader["t1s2f7"].ToString();
                    model.t1s2f8 = sqlDataReader["t1s2f8"].ToString();
                    model.t1s2f9 = sqlDataReader["t1s2f9"].ToString();
                    model.t1s2f10 = sqlDataReader["t1s2f10"].ToString();
                    model.t1s2f11 = sqlDataReader["t1s2f11"].ToString();
                    model.t1s2f12 = sqlDataReader["t1s2f12"].ToString();
                    model.t1s2f13 = sqlDataReader["t1s2f13"].ToString();
                    model.t1s2f14 = sqlDataReader["t1s2f14"].ToString();
                    model.t1s2f15 = sqlDataReader["t1s2f15"].ToString();
                    model.t1s2f16 = sqlDataReader["t1s2f16"].ToString();
                    model.t1s2f17 = sqlDataReader["t1s2f17"].ToString();
                    model.t1s2f18 = sqlDataReader["t1s2f18"].ToString();
                    model.t1s2f19 = sqlDataReader["t1s2f19"].ToString();
                    model.t1s2f20 = sqlDataReader["t1s2f20"].ToString();
                    model.t1s2f21 = sqlDataReader["t1s2f21"].ToString();
                    model.t1s2f22 = sqlDataReader["t1s2f22"].ToString();
                    model.t1s2f23 = sqlDataReader["t1s2f23"].ToString();
                    model.t1s2f24 = sqlDataReader["t1s2f24"].ToString();
                    model.t1s3f1 = sqlDataReader["t1s3f1"].ToString();
                    model.t1s3f2 = sqlDataReader["t1s3f2"].ToString();
                    model.t1s3f3 = sqlDataReader["t1s3f3"].ToString();
                    model.t1s4f1 = sqlDataReader["t1s4f1"].ToString();
                    model.t1s4f2 = sqlDataReader["t1s4f2"].ToString();
                    model.t1s4f3 = sqlDataReader["t1s4f3"].ToString();
                    model.t1s4f4 = sqlDataReader["t1s4f4"].ToString();
                    model.t1s4f5 = sqlDataReader["t1s4f5"].ToString();
                    model.t1s4f6 = sqlDataReader["t1s4f6"].ToString();
                    model.t1s4f7 = sqlDataReader["t1s4f7"].ToString();
                    model.t1s4f8 = sqlDataReader["t1s4f8"].ToString();
                    model.t1s4f9 = sqlDataReader["t1s4f9"].ToString();
                    model.t1s4f10 = sqlDataReader["t1s4f10"].ToString();
                    model.t1s4f11 = sqlDataReader["t1s4f11"].ToString();
                    model.t1s4f12 = sqlDataReader["t1s4f12"].ToString();
                    model.t1s4f13 = sqlDataReader["t1s4f13"].ToString();
                    model.t1s4f14 = sqlDataReader["t1s4f14"].ToString();
                    model.t1s4f15 = sqlDataReader["t1s4f15"].ToString();
                    model.t1s4f16 = sqlDataReader["t1s4f16"].ToString();
                    model.t1s4f17 = sqlDataReader["t1s4f17"].ToString();
                    model.t1s4f18 = sqlDataReader["t1s4f18"].ToString();
                    model.t1s4f19 = sqlDataReader["t1s4f19"].ToString();
                    model.t1s4f20 = sqlDataReader["t1s4f20"].ToString();
                    model.t1s4f21 = sqlDataReader["t1s4f21"].ToString();
                    model.t1s4f22 = sqlDataReader["t1s4f22"].ToString();
                    model.t1s4f23 = sqlDataReader["t1s4f23"].ToString();
                    model.t1s4f24 = sqlDataReader["t1s4f24"].ToString();
                    model.t1s4f25 = sqlDataReader["t1s4f25"].ToString();
                    model.t1s4f26 = sqlDataReader["t1s4f26"].ToString();
                    model.t1s4f27 = sqlDataReader["t1s4f27"].ToString();
                    model.t1s4f28 = sqlDataReader["t1s4f28"].ToString();
                    model.t1s4f29 = sqlDataReader["t1s4f29"].ToString();
                    model.t1s4f30 = sqlDataReader["t1s4f30"].ToString();
                    model.t1s4f31 = sqlDataReader["t1s4f31"].ToString();
                    model.t1s4f32 = sqlDataReader["t1s4f32"].ToString();
                    model.t1s4f33 = sqlDataReader["t1s4f33"].ToString();
                    model.t1s4f34 = sqlDataReader["t1s4f34"].ToString();
                    model.t1s4f35 = sqlDataReader["t1s4f35"].ToString();
                    model.t1s4f36 = sqlDataReader["t1s4f36"].ToString();
                    model.t1s4f37 = sqlDataReader["t1s4f37"].ToString();
                    model.t1s4f38 = sqlDataReader["t1s4f38"].ToString();
                    model.t1s4f39 = sqlDataReader["t1s4f39"].ToString();
                    model.t1s4f40 = sqlDataReader["t1s4f40"].ToString();
                    model.t1s4f41 = sqlDataReader["t1s4f41"].ToString();
                    model.t1s4f42 = sqlDataReader["t1s4f42"].ToString();
                    model.t1s4f43 = sqlDataReader["t1s4f43"].ToString();
                    model.t1s4f44 = sqlDataReader["t1s4f44"].ToString();
                    model.t1s4f45 = sqlDataReader["t1s4f45"].ToString();
                    model.t1s4f46 = sqlDataReader["t1s4f46"].ToString();
                    model.t1s4f47 = sqlDataReader["t1s4f47"].ToString();
                    model.t1s4f48 = sqlDataReader["t1s4f48"].ToString();
                    model.t1s4f49 = sqlDataReader["t1s4f49"].ToString();
                    model.t1s4f50 = sqlDataReader["t1s4f50"].ToString();
                    model.t1s4f51 = sqlDataReader["t1s4f51"].ToString();
                    model.t1s4f52 = sqlDataReader["t1s4f52"].ToString();
                    model.t1s4f53 = sqlDataReader["t1s4f53"].ToString();
                    model.t1s4f54 = sqlDataReader["t1s4f54"].ToString();
                    model.totalemployee = sqlDataReader["totalemployee"].ToString();
                    model.totalperiod = sqlDataReader["totalperiod"].ToString();
                    model.totalsalaries = sqlDataReader["totalsalaries"].ToString();
                    model.totalincome = sqlDataReader["totalincome"].ToString();
                    model.totalother = sqlDataReader["totalother"].ToString();
                    model.totalhonorarium = sqlDataReader["totalhonorarium"].ToString();
                    model.totalinsurance = sqlDataReader["totalinsurance"].ToString();
                    model.totalbenefit = sqlDataReader["totalbenefit"].ToString();
                    model.totalbonus = sqlDataReader["totalbonus"].ToString();
                    model.totalgross = sqlDataReader["totalgross"].ToString();
                    model.totalcost = sqlDataReader["totalcost"].ToString();
                    model.totalpension = sqlDataReader["totalpension"].ToString();
                    model.totaldeductions = sqlDataReader["totaldeductions"].ToString();
                    model.totalnetincome = sqlDataReader["totalnetincome"].ToString();
                    model.totalincometax = sqlDataReader["totalincometax"].ToString();
                    model.totalprevnetincome = sqlDataReader["totalprevnetincome"].ToString();
                    model.totalprevincometax = sqlDataReader["totalprevincometax"].ToString();
                    model.t1s6f1 = sqlDataReader["t1s6f1"].ToString();
                    model.t1s6f2 = sqlDataReader["t1s6f2"].ToString();
                    model.t1s6f3 = sqlDataReader["t1s6f3"].ToString();
                    model.t1s6f4 = sqlDataReader["t1s6f4"].ToString();
                    model.t1s6f5 = sqlDataReader["t1s6f5"].ToString();
                    model.t1s6f6 = sqlDataReader["t1s6f6"].ToString();
                    model.t1s6f7 = sqlDataReader["t1s6f7"].ToString();
                    model.t1s6f8 = sqlDataReader["t1s6f8"].ToString();
                    model.t1s6f9 = sqlDataReader["t1s6f9"].ToString();
                    model.t1s6f10 = sqlDataReader["t1s6f10"].ToString();
                    model.t1s6f11 = sqlDataReader["t1s6f11"].ToString();
                    model.t1s6f12 = sqlDataReader["t1s6f12"].ToString();
                    model.t1s6f13 = sqlDataReader["t1s6f13"].ToString();
                    model.t1s6f14 = sqlDataReader["t1s6f14"].ToString();
                    model.t1s6f15 = sqlDataReader["t1s6f15"].ToString();
                    model.t1s6f16 = sqlDataReader["t1s6f16"].ToString();
                    model.t1s6f17 = sqlDataReader["t1s6f17"].ToString();
                    model.t1s6f18 = sqlDataReader["t1s6f18"].ToString();
                    model.t1s6f19 = sqlDataReader["t1s6f19"].ToString();
                    model.t1s6f20 = sqlDataReader["t1s6f20"].ToString();
                    model.t1s6f21 = sqlDataReader["t1s6f21"].ToString();
                    model.t1s6f22 = sqlDataReader["t1s6f22"].ToString();
                    model.t1s6f23 = sqlDataReader["t1s6f23"].ToString();
                    model.t1s6f24 = sqlDataReader["t1s6f24"].ToString();
                    model.t1s6f25 = sqlDataReader["t1s6f25"].ToString();
                    model.t1s7f1 = sqlDataReader["t1s7f1"].ToString();
                    model.t1s7f2 = sqlDataReader["t1s7f2"].ToString();
                    model.t1s7f3 = sqlDataReader["t1s7f3"].ToString();
                    model.t1s7f4 = sqlDataReader["t1s7f4"].ToString();
                    model.t1s7f5 = sqlDataReader["t1s7f5"].ToString();
                    model.t1s7f6 = sqlDataReader["t1s7f6"].ToString();
                    model.t1s7f7 = sqlDataReader["t1s7f7"].ToString();
                    model.t1s7f8 = sqlDataReader["t1s7f8"].ToString();
                    model.t1s7f9 = sqlDataReader["t1s7f9"].ToString();
                    model.t1s7f10 = sqlDataReader["t1s7f10"].ToString();
                    model.t1s7f11 = sqlDataReader["t1s7f11"].ToString();
                    model.t1s7f12 = sqlDataReader["t1s7f12"].ToString();
                    model.t1s7f13 = sqlDataReader["t1s7f13"].ToString();
                    model.t1s7f14 = sqlDataReader["t1s7f14"].ToString();
                    model.t1s7f15 = sqlDataReader["t1s7f15"].ToString();
                    model.t1s7f16 = sqlDataReader["t1s7f16"].ToString();
                    model.t1s7f17 = sqlDataReader["t1s7f17"].ToString();
                    model.t1s7f18 = sqlDataReader["t1s7f18"].ToString();
                    model.t1s7f19 = sqlDataReader["t1s7f19"].ToString();
                    model.t1s7f20 = sqlDataReader["t1s7f20"].ToString();
                    model.t1s7f21 = sqlDataReader["t1s7f21"].ToString();
                    model.t1s7f22 = sqlDataReader["t1s7f22"].ToString();
                    model.t1s7f23 = sqlDataReader["t1s7f23"].ToString();
                    model.t1s7f24 = sqlDataReader["t1s7f24"].ToString();
                    model.t1s7f25 = sqlDataReader["t1s7f25"].ToString();
                    model.t1s7f26 = sqlDataReader["t1s7f26"].ToString();
                    model.t1s7f27 = sqlDataReader["t1s7f27"].ToString();
                    model.t1s7f28 = sqlDataReader["t1s7f28"].ToString();
                    model.t1s7f29 = sqlDataReader["t1s7f29"].ToString();
                    model.t1s7f30 = sqlDataReader["t1s7f30"].ToString();
                    model.t1s7f31 = sqlDataReader["t1s7f31"].ToString();
                    model.t1s7f32 = sqlDataReader["t1s7f32"].ToString();
                    model.t1s7f33 = sqlDataReader["t1s7f33"].ToString();
                    model.t1s7f34 = sqlDataReader["t1s7f34"].ToString();
                    model.t1s7f35 = sqlDataReader["t1s7f35"].ToString();
                    model.t1s7f36 = sqlDataReader["t1s7f36"].ToString();
                    model.t1s7f37 = sqlDataReader["t1s7f37"].ToString();
                    model.t1s7f38 = sqlDataReader["t1s7f38"].ToString();
                    model.t1s7f39 = sqlDataReader["t1s7f39"].ToString();
                    model.t1s8f1 = sqlDataReader["t1s8f1"].ToString();
                    model.t1s8f2 = sqlDataReader["t1s8f2"].ToString();
                    model.t1s8f3 = sqlDataReader["t1s8f3"].ToString();
                    model.t1s8f4 = sqlDataReader["t1s8f4"].ToString();
                    model.t1s8f5 = sqlDataReader["t1s8f5"].ToString();
                    model.t1s8f6 = sqlDataReader["t1s8f6"].ToString();
                    model.t1s8f7 = sqlDataReader["t1s8f7"].ToString();
                    model.t1s8f8 = sqlDataReader["t1s8f8"].ToString();
                    model.t1s8f9 = sqlDataReader["t1s8f9"].ToString();
                    model.t1s8f10 = sqlDataReader["t1s8f10"].ToString();
                    model.t1s8f11 = sqlDataReader["t1s8f11"].ToString();
                    model.t1s8f12 = sqlDataReader["t1s8f12"].ToString();
                    model.t1s8f13 = sqlDataReader["t1s8f13"].ToString();
                    model.t1s8f14 = sqlDataReader["t1s8f14"].ToString();
                    model.t1s8f15 = sqlDataReader["t1s8f15"].ToString();
                    model.t1s8f16 = sqlDataReader["t1s8f16"].ToString();
                    model.t1s8f17 = sqlDataReader["t1s8f17"].ToString();
                    model.t1s8f18 = sqlDataReader["t1s8f18"].ToString();
                    model.t1s8f19 = sqlDataReader["t1s8f19"].ToString();
                    model.t1s8f20 = sqlDataReader["t1s8f20"].ToString();
                    model.t1s8f21 = sqlDataReader["t1s8f21"].ToString();
                    model.t1s8f22 = sqlDataReader["t1s8f22"].ToString();
                    model.t1s8f23 = sqlDataReader["t1s8f23"].ToString();
                    model.t1s8f24 = sqlDataReader["t1s8f24"].ToString();
                    model.t1s8f25 = sqlDataReader["t1s8f25"].ToString();
                    model.t1s8f26 = sqlDataReader["t1s8f26"].ToString();
                    model.t1s8f27 = sqlDataReader["t1s8f27"].ToString();
                    model.t1s8f28 = sqlDataReader["t1s8f28"].ToString();
                    model.t1s8f29 = sqlDataReader["t1s8f29"].ToString();
                    model.t1s8f30 = sqlDataReader["t1s8f30"].ToString();
                    model.t1s8f31 = sqlDataReader["t1s8f31"].ToString();
                    model.t1s8f32 = sqlDataReader["t1s8f32"].ToString();
                    model.t1s8f33 = sqlDataReader["t1s8f33"].ToString();
                    model.t1s8f34 = sqlDataReader["t1s8f34"].ToString();
                    model.t1s8f35 = sqlDataReader["t1s8f35"].ToString();
                    model.t1s8f36 = sqlDataReader["t1s8f36"].ToString();
                    model.t1s8f37 = sqlDataReader["t1s8f37"].ToString();
                    model.t1s8f38 = sqlDataReader["t1s8f38"].ToString();
                    model.t1s8f39 = sqlDataReader["t1s8f39"].ToString();
                    model.t1s8f40 = sqlDataReader["t1s8f40"].ToString();
                    model.t1s8f41 = sqlDataReader["t1s8f41"].ToString();
                    model.t1s8f42 = sqlDataReader["t1s8f42"].ToString();
                    model.t1s8f43 = sqlDataReader["t1s8f43"].ToString();
                    model.total1 = sqlDataReader["total1"].ToString();
                    model.total2 = sqlDataReader["total2"].ToString();
                    model.total3 = sqlDataReader["total3"].ToString();
                    model.total4 = sqlDataReader["total4"].ToString();
                    model.total5 = sqlDataReader["total5"].ToString();
                    model.total6 = sqlDataReader["total6"].ToString();
                    model.total7 = sqlDataReader["total7"].ToString();
                    model.total8 = sqlDataReader["total8"].ToString();
                    model.total9 = sqlDataReader["total9"].ToString();
                    model.total10 = sqlDataReader["total10"].ToString();
                    model.total11 = sqlDataReader["total11"].ToString();
                    model.total12 = sqlDataReader["total12"].ToString();
                    model.total13 = sqlDataReader["total13"].ToString();
                    model.total14 = sqlDataReader["total14"].ToString();
                    model.total15 = sqlDataReader["total15"].ToString();
                    model.total16 = sqlDataReader["total16"].ToString();
                    model.total17 = sqlDataReader["total17"].ToString();
                    model.total18 = sqlDataReader["total18"].ToString();
                    model.total19 = sqlDataReader["total19"].ToString();
                    model.total20 = sqlDataReader["total20"].ToString();
                    model.total21 = sqlDataReader["total21"].ToString();
                    model.total22 = sqlDataReader["total22"].ToString();
                    model.total23 = sqlDataReader["total23"].ToString();
                    model.total24 = sqlDataReader["total24"].ToString();
                    model.total25 = sqlDataReader["total25"].ToString();
                    model.total26 = sqlDataReader["total26"].ToString();
                    model.ren_netamountcurrency = sqlDataReader["ren_netamountcurrency"].ToString();
                    model.ren_netamountrp = sqlDataReader["ren_netamountrp"].ToString();
                    model.ren_nettaxpaidcurrency = sqlDataReader["ren_nettaxpaidcurrency"].ToString();
                    model.ren_nettaxpaidexchrate = sqlDataReader["ren_nettaxpaidexchrate"].ToString();
                    model.ren_nettaxpaidamountrp = sqlDataReader["ren_nettaxpaidamountrp"].ToString();
                    model.tabirregulartotal1 = sqlDataReader["tabirregulartotal1"].ToString();
                    model.tabirregulartotal2 = sqlDataReader["tabirregulartotal2"].ToString();
                    model.irregulartaxcredit = sqlDataReader["irregulartaxcredit"].ToString();
                    model.lbltotalsummary1 = sqlDataReader["lbltotalsummary1"].ToString();
                    model.lbltotalsummary2 = sqlDataReader["lbltotalsummary2"].ToString();
                    model.tabasset1 = sqlDataReader["tabasset1"].ToString();
                    model.tabasset2 = sqlDataReader["tabasset2"].ToString();
                    model.tabasset3 = sqlDataReader["tabasset3"].ToString();
                    model.tabasset4 = sqlDataReader["tabasset4"].ToString();
                    model.tabasset5 = sqlDataReader["tabasset5"].ToString();
                    model.tabasset6 = sqlDataReader["tabasset6"].ToString();
                    model.tabasset10 = sqlDataReader["tabasset10"].ToString();
                    model.tab3nettotalasset = sqlDataReader["tab3nettotalasset"].ToString();
                    model.tab3nettotalliabilities = sqlDataReader["tab3nettotalliabilities"].ToString();
                    model.tab3netasset = sqlDataReader["tab3netasset"].ToString();
                    model.createdby = sqlDataReader["createdby"].ToString();
                    model.createddate = sqlDataReader["createddate"].ToString();
                    model.updatedby = sqlDataReader["updatedby"].ToString();
                    model.updateddate = sqlDataReader["updateddate"].ToString();


                    model.netincomeroundedyes = sqlDataReader["netincomeroundedyes"].ToString();
                    model.bonusroundedyes = sqlDataReader["bonusroundedyes"].ToString();
                    model.totalperiodroundedyes = sqlDataReader["totalperiodroundedyes"].ToString();

                    model.netincomeroundednot = sqlDataReader["netincomeroundednot"].ToString();
                    model.bonusroundednot = sqlDataReader["bonusroundednot"].ToString();
                    model.totalperiodroundednot = sqlDataReader["totalperiodroundednot"].ToString();

                    models.Add(model);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(models));
        }


        [WebMethod]
        public void GetIEIncomeByRounded(string form, string year, string field8)
        {
            List<vm.IEIncome> models = new List<vm.IEIncome>();
            string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(congigManager))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetIEIncomeByRounded", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
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
                    ParameterName = "@field8",
                    Value = field8
                });
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    vm.IEIncome model = new vm.IEIncome();
                    model.field20 = sqlDataReader["field20"].ToString();

                    models.Add(model);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(models));
        }
    }
}
