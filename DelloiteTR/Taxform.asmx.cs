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
    /// Summary description for Taxform1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Taxform1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void SaveForm(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spSaveForm", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ammend",
                        Value = jsonData.ammend
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@taxidnumber",
                        Value = jsonData.taxidnumber
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@type",
                        Value = jsonData.type
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@year",
                        Value = jsonData.year
                    });


                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s1f2",
                        Value = jsonData.t1s1f2
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s1f4",
                        Value = jsonData.t1s1f4
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s1f5",
                        Value = jsonData.t1s1f5
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s1f6",
                        Value = jsonData.t1s1f6
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s1f7",
                        Value = jsonData.t1s1f7
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s1f8",
                        Value = jsonData.t1s1f8
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f1",
                        Value = jsonData.t1s2f1
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f2",
                        Value = jsonData.t1s2f2
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f3",
                        Value = jsonData.t1s2f3
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f4",
                        Value = jsonData.t1s2f4
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f5",
                        Value = jsonData.t1s2f5
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f6",
                        Value = jsonData.t1s2f6
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f7",
                        Value = jsonData.t1s2f7
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f8",
                        Value = jsonData.t1s2f8
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f9",
                        Value = jsonData.t1s2f9
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f10",
                        Value = jsonData.t1s2f10
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f11",
                        Value = jsonData.t1s2f11
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f12",
                        Value = jsonData.t1s2f12
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f13",
                        Value = jsonData.t1s2f13
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f14",
                        Value = jsonData.t1s2f14
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f15",
                        Value = jsonData.t1s2f15
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f16",
                        Value = jsonData.t1s2f16
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f17",
                        Value = jsonData.t1s2f17
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f18",
                        Value = jsonData.t1s2f18
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f19",
                        Value = jsonData.t1s2f19
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f20",
                        Value = jsonData.t1s2f20
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f21",
                        Value = jsonData.t1s2f21
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f22",
                        Value = jsonData.t1s2f22
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f23",
                        Value = jsonData.t1s2f23
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f24",
                        Value = jsonData.t1s2f24
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s3f1",
                        Value = jsonData.t1s3f1
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s3f2",
                        Value = jsonData.t1s3f2
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s3f3",
                        Value = jsonData.t1s3f3
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f1",
                        Value = jsonData.t1s4f1
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f2",
                        Value = jsonData.t1s4f2
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f3",
                        Value = jsonData.t1s4f3
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f4",
                        Value = jsonData.t1s4f4
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f5",
                        Value = jsonData.t1s4f5
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f6",
                        Value = jsonData.t1s4f6
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f7",
                        Value = jsonData.t1s4f7
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f8",
                        Value = jsonData.t1s4f8
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f9",
                        Value = jsonData.t1s4f9
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f10",
                        Value = jsonData.t1s4f10
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f11",
                        Value = jsonData.t1s4f11
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f12",
                        Value = jsonData.t1s4f12
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f13",
                        Value = jsonData.t1s4f13
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f14",
                        Value = jsonData.t1s4f14
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f15",
                        Value = jsonData.t1s4f15
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f16",
                        Value = jsonData.t1s4f16
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f17",
                        Value = jsonData.t1s4f17
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f18",
                        Value = jsonData.t1s4f18
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f19",
                        Value = jsonData.t1s4f19
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f20",
                        Value = jsonData.t1s4f20
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f21",
                        Value = jsonData.t1s4f21
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f22",
                        Value = jsonData.t1s4f22
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f23",
                        Value = jsonData.t1s4f23
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f24",
                        Value = jsonData.t1s4f24
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f25",
                        Value = jsonData.t1s4f25
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f26",
                        Value = jsonData.t1s4f26
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f27",
                        Value = jsonData.t1s4f27
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f28",
                        Value = jsonData.t1s4f28
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f29",
                        Value = jsonData.t1s4f29
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f30",
                        Value = jsonData.t1s4f30
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f31",
                        Value = jsonData.t1s4f31
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f32",
                        Value = jsonData.t1s4f32
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f33",
                        Value = jsonData.t1s4f33
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f34",
                        Value = jsonData.t1s4f34
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f35",
                        Value = jsonData.t1s4f35
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f36",
                        Value = jsonData.t1s4f36
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f37",
                        Value = jsonData.t1s4f37
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f38",
                        Value = jsonData.t1s4f38
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f39",
                        Value = jsonData.t1s4f39
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f40",
                        Value = jsonData.t1s4f40
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f41",
                        Value = jsonData.t1s4f41
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f42",
                        Value = jsonData.t1s4f42
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f43",
                        Value = jsonData.t1s4f43
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f44",
                        Value = jsonData.t1s4f44
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f45",
                        Value = jsonData.t1s4f45
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f46",
                        Value = jsonData.t1s4f46
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f47",
                        Value = jsonData.t1s4f47
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f48",
                        Value = jsonData.t1s4f48
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f49",
                        Value = jsonData.t1s4f49
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f50",
                        Value = jsonData.t1s4f50
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f51",
                        Value = jsonData.t1s4f51
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f52",
                        Value = jsonData.t1s4f52
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f53",
                        Value = jsonData.t1s4f53
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f54",
                        Value = jsonData.t1s4f54
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f1",
                        Value = jsonData.t1s6f1
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f2",
                        Value = jsonData.t1s6f2
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f3",
                        Value = jsonData.t1s6f3
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f4",
                        Value = jsonData.t1s6f4
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f5",
                        Value = jsonData.t1s6f5
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f6",
                        Value = jsonData.t1s6f6
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f7",
                        Value = jsonData.t1s6f7
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f8",
                        Value = jsonData.t1s6f8
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f9",
                        Value = jsonData.t1s6f9
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f10",
                        Value = jsonData.t1s6f10
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f11",
                        Value = jsonData.t1s6f11
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f12",
                        Value = jsonData.t1s6f12
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f13",
                        Value = jsonData.t1s6f13
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f14",
                        Value = jsonData.t1s6f14
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f15",
                        Value = jsonData.t1s6f15
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f16",
                        Value = jsonData.t1s6f16
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f17",
                        Value = jsonData.t1s6f17
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f18",
                        Value = jsonData.t1s6f18
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f19",
                        Value = jsonData.t1s6f19
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f20",
                        Value = jsonData.t1s6f20
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f21",
                        Value = jsonData.t1s6f21
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f22",
                        Value = jsonData.t1s6f22
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f23",
                        Value = jsonData.t1s6f23
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f24",
                        Value = jsonData.t1s6f24
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f25",
                        Value = jsonData.t1s6f25
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f1",
                        Value = jsonData.t1s7f1
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f2",
                        Value = jsonData.t1s7f2
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f3",
                        Value = jsonData.t1s7f3
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f4",
                        Value = jsonData.t1s7f4
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f5",
                        Value = jsonData.t1s7f5
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f6",
                        Value = jsonData.t1s7f6
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f7",
                        Value = jsonData.t1s7f7
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f8",
                        Value = jsonData.t1s7f8
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f9",
                        Value = jsonData.t1s7f9
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f10",
                        Value = jsonData.t1s7f10
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f11",
                        Value = jsonData.t1s7f11
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f12",
                        Value = jsonData.t1s7f12
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f13",
                        Value = jsonData.t1s7f13
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f14",
                        Value = jsonData.t1s7f14
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f15",
                        Value = jsonData.t1s7f15
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f16",
                        Value = jsonData.t1s7f16
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f17",
                        Value = jsonData.t1s7f17
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f18",
                        Value = jsonData.t1s7f18
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f19",
                        Value = jsonData.t1s7f19
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f20",
                        Value = jsonData.t1s7f20
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f21",
                        Value = jsonData.t1s7f21
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f22",
                        Value = jsonData.t1s7f22
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f23",
                        Value = jsonData.t1s7f23
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f24",
                        Value = jsonData.t1s7f24
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f25",
                        Value = jsonData.t1s7f25
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f26",
                        Value = jsonData.t1s7f26
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f27",
                        Value = jsonData.t1s7f27
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f28",
                        Value = jsonData.t1s7f28
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f29",
                        Value = jsonData.t1s7f29
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f30",
                        Value = jsonData.t1s7f30
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f31",
                        Value = jsonData.t1s7f31
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f32",
                        Value = jsonData.t1s7f32
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f33",
                        Value = jsonData.t1s7f33
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f34",
                        Value = jsonData.t1s7f34
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f35",
                        Value = jsonData.t1s7f35
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f36",
                        Value = jsonData.t1s7f36
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f37",
                        Value = jsonData.t1s7f37
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f38",
                        Value = jsonData.t1s7f38
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f39",
                        Value = jsonData.t1s7f39
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f1",
                        Value = jsonData.t1s8f1
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f2",
                        Value = jsonData.t1s8f2
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f3",
                        Value = jsonData.t1s8f3
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f4",
                        Value = jsonData.t1s8f4
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f5",
                        Value = jsonData.t1s8f5
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f6",
                        Value = jsonData.t1s8f6
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f7",
                        Value = jsonData.t1s8f7
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f8",
                        Value = jsonData.t1s8f8
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f9",
                        Value = jsonData.t1s8f9
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f10",
                        Value = jsonData.t1s8f10
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f11",
                        Value = jsonData.t1s8f11
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f12",
                        Value = jsonData.t1s8f12
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f13",
                        Value = jsonData.t1s8f13
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f14",
                        Value = jsonData.t1s8f14
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f15",
                        Value = jsonData.t1s8f15
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f16",
                        Value = jsonData.t1s8f16
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f17",
                        Value = jsonData.t1s8f17
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f18",
                        Value = jsonData.t1s8f18
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f19",
                        Value = jsonData.t1s8f19
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f20",
                        Value = jsonData.t1s8f20
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f21",
                        Value = jsonData.t1s8f21
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f22",
                        Value = jsonData.t1s8f22
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f23",
                        Value = jsonData.t1s8f23
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f24",
                        Value = jsonData.t1s8f24
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f25",
                        Value = jsonData.t1s8f25
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f26",
                        Value = jsonData.t1s8f26
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f27",
                        Value = jsonData.t1s8f27
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f28",
                        Value = jsonData.t1s8f28
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f29",
                        Value = jsonData.t1s8f29
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f30",
                        Value = jsonData.t1s8f30
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f31",
                        Value = jsonData.t1s8f31
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f32",
                        Value = jsonData.t1s8f32
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f33",
                        Value = jsonData.t1s8f33
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f34",
                        Value = jsonData.t1s8f34
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f35",
                        Value = jsonData.t1s8f35
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f36",
                        Value = jsonData.t1s8f36
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f37",
                        Value = jsonData.t1s8f37
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f38",
                        Value = jsonData.t1s8f38
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f39",
                        Value = jsonData.t1s8f39
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f40",
                        Value = jsonData.t1s8f40
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f41",
                        Value = jsonData.t1s8f41
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f42",
                        Value = jsonData.t1s8f42
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f43",
                        Value = jsonData.t1s8f43
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@lbltotalsummary1",
                        Value = jsonData.lbltotalsummary1
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_netamountcurrency",
                        Value = jsonData.ren_netamountcurrency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_netamountrp",
                        Value = jsonData.ren_netamountrp
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_nettaxpaidcurrency",
                        Value = jsonData.ren_nettaxpaidcurrency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_nettaxpaidexchrate",
                        Value = jsonData.ren_nettaxpaidexchrate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_nettaxpaidamountrp",
                        Value = jsonData.ren_nettaxpaidamountrp
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@irregulartaxcredit",
                        Value = jsonData.irregulartaxcredit
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@tab3nettotalasset",
                        Value = jsonData.tab3nettotalasset
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@tab3nettotalliabilities",
                        Value = jsonData.tab3nettotalliabilities
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@tab3netasset",
                        Value = jsonData.tab3netasset
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
        public void spUpdateFormStep11(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep1-1", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s1f4",
                        Value = jsonData.t1s1f4
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s1f5",
                        Value = jsonData.t1s1f5
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s1f6",
                        Value = jsonData.t1s1f6
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s1f7",
                        Value = jsonData.t1s1f7
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s1f8",
                        Value = jsonData.t1s1f8
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
        public void spUpdateFormStep12(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep1-2", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f1",
                        Value = jsonData.t1s2f1
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f2",
                        Value = jsonData.t1s2f2
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f3",
                        Value = jsonData.t1s2f3
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f4",
                        Value = jsonData.t1s2f4
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f5",
                        Value = jsonData.t1s2f5
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f6",
                        Value = jsonData.t1s2f6
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f7",
                        Value = jsonData.t1s2f7
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f8",
                        Value = jsonData.t1s2f8
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f9",
                        Value = jsonData.t1s2f9
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f10",
                        Value = jsonData.t1s2f10
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f11",
                        Value = jsonData.t1s2f11
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f12",
                        Value = jsonData.t1s2f12
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f13",
                        Value = jsonData.t1s2f13
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f14",
                        Value = jsonData.t1s2f14
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f15",
                        Value = jsonData.t1s2f15
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f16",
                        Value = jsonData.t1s2f16
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f17",
                        Value = jsonData.t1s2f17
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f18",
                        Value = jsonData.t1s2f18
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f19",
                        Value = jsonData.t1s2f19
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f20",
                        Value = jsonData.t1s2f20
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f21",
                        Value = jsonData.t1s2f21
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f22",
                        Value = jsonData.t1s2f22
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f23",
                        Value = jsonData.t1s2f23
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s2f24",
                        Value = jsonData.t1s2f24
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
        public void spUpdateFormStep13(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep1-3", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s3f1",
                        Value = jsonData.t1s3f1
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s3f2",
                        Value = jsonData.t1s3f2
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s3f3",
                        Value = jsonData.t1s3f3
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
        public void spUpdateFormStep14(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep1-4", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f1",
                        Value = jsonData.t1s4f1
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f2",
                        Value = jsonData.t1s4f2
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f3",
                        Value = jsonData.t1s4f3
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f4",
                        Value = jsonData.t1s4f4
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f5",
                        Value = jsonData.t1s4f5
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f6",
                        Value = jsonData.t1s4f6
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f7",
                        Value = jsonData.t1s4f7
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f8",
                        Value = jsonData.t1s4f8
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f9",
                        Value = jsonData.t1s4f9
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f10",
                        Value = jsonData.t1s4f10
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f11",
                        Value = jsonData.t1s4f11
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f12",
                        Value = jsonData.t1s4f12
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f13",
                        Value = jsonData.t1s4f13
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f14",
                        Value = jsonData.t1s4f14
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f15",
                        Value = jsonData.t1s4f15
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f16",
                        Value = jsonData.t1s4f16
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f17",
                        Value = jsonData.t1s4f17
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f18",
                        Value = jsonData.t1s4f18
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f19",
                        Value = jsonData.t1s4f19
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f20",
                        Value = jsonData.t1s4f20
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f21",
                        Value = jsonData.t1s4f21
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f22",
                        Value = jsonData.t1s4f22
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f23",
                        Value = jsonData.t1s4f23
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f24",
                        Value = jsonData.t1s4f24
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f25",
                        Value = jsonData.t1s4f25
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f26",
                        Value = jsonData.t1s4f26
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f27",
                        Value = jsonData.t1s4f27
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f28",
                        Value = jsonData.t1s4f28
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f29",
                        Value = jsonData.t1s4f29
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f30",
                        Value = jsonData.t1s4f30
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f31",
                        Value = jsonData.t1s4f31
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f32",
                        Value = jsonData.t1s4f32
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f33",
                        Value = jsonData.t1s4f33
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f34",
                        Value = jsonData.t1s4f34
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f35",
                        Value = jsonData.t1s4f35
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f36",
                        Value = jsonData.t1s4f36
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f37",
                        Value = jsonData.t1s4f37
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f38",
                        Value = jsonData.t1s4f38
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f39",
                        Value = jsonData.t1s4f39
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f40",
                        Value = jsonData.t1s4f40
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f41",
                        Value = jsonData.t1s4f41
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f42",
                        Value = jsonData.t1s4f42
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f43",
                        Value = jsonData.t1s4f43
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f44",
                        Value = jsonData.t1s4f44
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f45",
                        Value = jsonData.t1s4f45
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f46",
                        Value = jsonData.t1s4f46
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f47",
                        Value = jsonData.t1s4f47
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f48",
                        Value = jsonData.t1s4f48
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f49",
                        Value = jsonData.t1s4f49
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f50",
                        Value = jsonData.t1s4f50
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f51",
                        Value = jsonData.t1s4f51
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f52",
                        Value = jsonData.t1s4f52
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f53",
                        Value = jsonData.t1s4f53
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f54",
                        Value = jsonData.t1s4f54
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s4f55",
                        Value = jsonData.t1s4f55
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
        public void spUpdateFormStep15(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep1-5", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totalemployee",
                        Value = jsonData.totalemployee
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totalperiod",
                        Value = jsonData.totalperiod
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totalsalaries",
                        Value = jsonData.totalsalaries
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totalincome",
                        Value = jsonData.totalincome
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totalother",
                        Value = jsonData.totalother
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totalhonorarium",
                        Value = jsonData.totalhonorarium
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totalinsurance",
                        Value = jsonData.totalinsurance
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totalbenefit",
                        Value = jsonData.totalbenefit
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totalbonus",
                        Value = jsonData.totalbonus
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totalgross",
                        Value = jsonData.totalgross
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totalcost",
                        Value = jsonData.totalcost
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totalpension",
                        Value = jsonData.totalpension
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totalpensioncost",
                        Value = jsonData.totalpensioncost
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totalincome25",
                        Value = jsonData.totalincome25
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totalincome26",
                        Value = jsonData.totalincome26
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totalincome27",
                        Value = jsonData.totalincome27
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totalincome28",
                        Value = jsonData.totalincome28
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totalincome29",
                        Value = jsonData.totalincome29
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totaldeductions",
                        Value = jsonData.totaldeductions
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totalnetincome",
                        Value = jsonData.totalnetincome
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totalincometax",
                        Value = jsonData.totalincometax
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totalprevnetincome",
                        Value = jsonData.totalprevnetincome
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@totalprevincometax",
                        Value = jsonData.totalprevincometax
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
        public void spUpdateFormStep16(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep1-6", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f1",
                        Value = jsonData.t1s6f1
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f2",
                        Value = jsonData.t1s6f2
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f3",
                        Value = jsonData.t1s6f3
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f4",
                        Value = jsonData.t1s6f4
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f5",
                        Value = jsonData.t1s6f5
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f6",
                        Value = jsonData.t1s6f6
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f7",
                        Value = jsonData.t1s6f7
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f8",
                        Value = jsonData.t1s6f8
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f9",
                        Value = jsonData.t1s6f9
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f10",
                        Value = jsonData.t1s6f10
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f11",
                        Value = jsonData.t1s6f11
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f12",
                        Value = jsonData.t1s6f12
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f13",
                        Value = jsonData.t1s6f13
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f14",
                        Value = jsonData.t1s6f14
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f15",
                        Value = jsonData.t1s6f15
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f16",
                        Value = jsonData.t1s6f16
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f17",
                        Value = jsonData.t1s6f17
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f18",
                        Value = jsonData.t1s6f18
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f19",
                        Value = jsonData.t1s6f19
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f20",
                        Value = jsonData.t1s6f20
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f21",
                        Value = jsonData.t1s6f21
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f22",
                        Value = jsonData.t1s6f22
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f23",
                        Value = jsonData.t1s6f23
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f24",
                        Value = jsonData.t1s6f24
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s6f25",
                        Value = jsonData.t1s6f25
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
        public void spUpdateFormStep17(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep1-7", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f1",
                        Value = jsonData.t1s7f1
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f2",
                        Value = jsonData.t1s7f2
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f3",
                        Value = jsonData.t1s7f3
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f4",
                        Value = jsonData.t1s7f4
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f5",
                        Value = jsonData.t1s7f5
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f6",
                        Value = jsonData.t1s7f6
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f7",
                        Value = jsonData.t1s7f7
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f8",
                        Value = jsonData.t1s7f8
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f9",
                        Value = jsonData.t1s7f9
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f10",
                        Value = jsonData.t1s7f10
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f11",
                        Value = jsonData.t1s7f11
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f12",
                        Value = jsonData.t1s7f12
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f13",
                        Value = jsonData.t1s7f13
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f14",
                        Value = jsonData.t1s7f14
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f15",
                        Value = jsonData.t1s7f15
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f16",
                        Value = jsonData.t1s7f16
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f17",
                        Value = jsonData.t1s7f17
                    });

                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f18",
                        Value = jsonData.t1s7f18
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f19",
                        Value = jsonData.t1s7f19
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f20",
                        Value = jsonData.t1s7f20
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f21",
                        Value = jsonData.t1s7f21
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f22",
                        Value = jsonData.t1s7f22
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f23",
                        Value = jsonData.t1s7f23
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f24",
                        Value = jsonData.t1s7f24
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f25",
                        Value = jsonData.t1s7f25
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f26",
                        Value = jsonData.t1s7f26
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f27",
                        Value = jsonData.t1s7f27
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f28",
                        Value = jsonData.t1s7f28
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f29",
                        Value = jsonData.t1s7f29
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f30",
                        Value = jsonData.t1s7f30
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f31",
                        Value = jsonData.t1s7f31
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f32",
                        Value = jsonData.t1s7f32
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f33",
                        Value = jsonData.t1s7f33
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f34",
                        Value = jsonData.t1s7f34
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f35",
                        Value = jsonData.t1s7f35
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f36",
                        Value = jsonData.t1s7f36
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f37",
                        Value = jsonData.t1s7f37
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f38",
                        Value = jsonData.t1s7f38
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s7f39",
                        Value = jsonData.t1s7f39
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
        public void spUpdateFormStep18(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep1-8", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f1",
                        Value = jsonData.t1s8f1
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f2",
                        Value = jsonData.t1s8f2
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f3",
                        Value = jsonData.t1s8f3
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f4",
                        Value = jsonData.t1s8f4
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f5",
                        Value = jsonData.t1s8f5
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f6",
                        Value = jsonData.t1s8f6
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f7",
                        Value = jsonData.t1s8f7
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f8",
                        Value = jsonData.t1s8f8
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f9",
                        Value = jsonData.t1s8f9
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f10",
                        Value = jsonData.t1s8f10
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f11",
                        Value = jsonData.t1s8f11
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f12",
                        Value = jsonData.t1s8f12
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f13",
                        Value = jsonData.t1s8f13
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f14",
                        Value = jsonData.t1s8f14
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f15",
                        Value = jsonData.t1s8f15
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f16",
                        Value = jsonData.t1s8f16
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f17",
                        Value = jsonData.t1s8f17
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f18",
                        Value = jsonData.t1s8f18
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f19",
                        Value = jsonData.t1s8f19
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f20",
                        Value = jsonData.t1s8f20
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f21",
                        Value = jsonData.t1s8f21
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f22",
                        Value = jsonData.t1s8f22
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f23",
                        Value = jsonData.t1s8f23
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f24",
                        Value = jsonData.t1s8f24
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f25",
                        Value = jsonData.t1s8f25
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f26",
                        Value = jsonData.t1s8f26
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f27",
                        Value = jsonData.t1s8f27
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f28",
                        Value = jsonData.t1s8f28
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f29",
                        Value = jsonData.t1s8f29
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f30",
                        Value = jsonData.t1s8f30
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f31",
                        Value = jsonData.t1s8f31
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f32",
                        Value = jsonData.t1s8f32
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f33",
                        Value = jsonData.t1s8f33
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f34",
                        Value = jsonData.t1s8f34
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f35",
                        Value = jsonData.t1s8f35
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f36",
                        Value = jsonData.t1s8f36
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f37",
                        Value = jsonData.t1s8f37
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f38",
                        Value = jsonData.t1s8f38
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f39",
                        Value = jsonData.t1s8f39
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f40",
                        Value = jsonData.t1s8f40
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f41",
                        Value = jsonData.t1s8f41
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f42",
                        Value = jsonData.t1s8f42
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@t1s8f43",
                        Value = jsonData.t1s8f43
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
        public void spUpdateFormStep21(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep2-1", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total1",
                        Value = jsonData.total1
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total2",
                        Value = jsonData.total2
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total3",
                        Value = jsonData.total3
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total4",
                        Value = jsonData.total4
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total5",
                        Value = jsonData.total5
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total6",
                        Value = jsonData.total6
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
        public void spUpdateFormStep22(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep2-2", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total7",
                        Value = jsonData.total7
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total8",
                        Value = jsonData.total8
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total9",
                        Value = jsonData.total9
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total10",
                        Value = jsonData.total10
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total11",
                        Value = jsonData.total11
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total12",
                        Value = jsonData.total12
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
        public void spUpdateFormStep23(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep2-3", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total13",
                        Value = jsonData.total13
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total14",
                        Value = jsonData.total14
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total15",
                        Value = jsonData.total15
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total16",
                        Value = jsonData.total16
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total17",
                        Value = jsonData.total17
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total18",
                        Value = jsonData.total18
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
        public void spUpdateFormStep24(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep2-4", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total19",
                        Value = jsonData.total19
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total20",
                        Value = jsonData.total20
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total21",
                        Value = jsonData.total21
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total22",
                        Value = jsonData.total22
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
        public void spUpdateFormStep25(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep2-5", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total23",
                        Value = jsonData.total23
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total24",
                        Value = jsonData.total24
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total25",
                        Value = jsonData.total25
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@total26",
                        Value = jsonData.total26
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_netamountcurrency",
                        Value = jsonData.ren_netamountcurrency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_netamountrp",
                        Value = jsonData.ren_netamountrp
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_nettaxpaidcurrency",
                        Value = jsonData.ren_nettaxpaidcurrency
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_nettaxpaidexchrate",
                        Value = jsonData.ren_nettaxpaidexchrate
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@ren_nettaxpaidamountrp",
                        Value = jsonData.ren_nettaxpaidamountrp
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
        public void spUpdateFormStep26(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep2-6", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@tabirregulartotal1",
                        Value = jsonData.tabirregulartotal1
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@tabirregulartotal2",
                        Value = jsonData.tabirregulartotal2
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@irregulartaxcredit",
                        Value = jsonData.irregulartaxcredit
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
        public void spUpdateFormStep27(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep2-7", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@lbltotalsummary1",
                        Value = jsonData.lbltotalsummary1
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@lbltotalsummary2",
                        Value = jsonData.lbltotalsummary2
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
        public void spUpdateFormStep31(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep3-1", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@tabasset1",
                        Value = jsonData.tabasset1
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
        public void spUpdateFormStep32(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep3-2", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@tabasset2",
                        Value = jsonData.tabasset2
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
        public void spUpdateFormStep33(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep3-3", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@tabasset3",
                        Value = jsonData.tabasset3
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
        public void spUpdateFormStep34(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep3-4", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@tabasset4",
                        Value = jsonData.tabasset4
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
        public void spUpdateFormStep35(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep3-5", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@tabasset5",
                        Value = jsonData.tabasset5
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
        public void spUpdateFormStep36(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep3-6", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@tabasset6",
                        Value = jsonData.tabasset6
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
        public void spUpdateFormStep37(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep3-7", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@tabasset10",
                        Value = jsonData.tabasset10
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
        public void spUpdateFormStep38(vm.TaxForm jsonData)
        {
            try
            {
                string congigManager = ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(congigManager))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateFormStep3-8", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@id",
                        Value = jsonData.id
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@tab3nettotalasset",
                        Value = jsonData.tab3nettotalasset
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@tab3nettotalliabilities",
                        Value = jsonData.tab3nettotalliabilities
                    });
                    sqlCommand.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@tab3netasset",
                        Value = jsonData.tab3netasset
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
    }
}
