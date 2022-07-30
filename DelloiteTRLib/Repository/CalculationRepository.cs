using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Database;
using System.Data.SqlClient;
using dc = DelloiteTRLib.DataContext;

namespace DelloiteTRLib.Repository
{
    public class CalculationRepository
    {
        private SqlServerDatabase _database;
        private dc.DelloiteDataContext _dataContext;

        public CalculationRepository()
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


        public IEnumerable<dc.Calculation> FindAll()
        {
            IEnumerable<dc.Calculation> datas = new List<dc.Calculation>();
            try
            {
                datas = _dataContext.Calculations.ToList<dc.Calculation>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datas;
        }

        public IEnumerable<dc.Calculation> GetAllBy(string TaxPayerNumber, string form, string year, int ammend)
        {
            IEnumerable<dc.Calculation> datas = new List<dc.Calculation>();

            try
            {
                datas = from data in _dataContext.Calculations select data;
                if (!string.IsNullOrEmpty(TaxPayerNumber))
                {
                    datas = datas.Where(x => x.TaxPayerNumber.Contains(TaxPayerNumber));
                }
                if (!string.IsNullOrEmpty(form))
                {
                    datas = datas.Where(x => x.form.Contains(form));
                }
                if (!string.IsNullOrEmpty(year))
                {
                    datas = datas.Where(x => x.year.Contains(year));
                }
                if (ammend!= null)
                {
                    datas = datas.Where(x => x.ammend == ammend);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datas;
        }

        public bool Save(bool isnew, int id, string TaxPayerNumber, string form, string year, int ammend, double calc_rounded_b1, double calc_rounded_b2, double calc_rounded_b3, double calc_rounded_b4, double calc_rounded_b5, double calc_rounded_b6, double calc_rounded_b7, double calc_rounded_b8, double calc_not_b1, double calc_not_b2, double calc_not_b3, double calc_not_b4, double calc_not_b5, double calc_not_b6, double calc_not_b7, double calc_not_b8, double calc_not_b9, double calc_rounded_0, double calc_rounded_01, double calc_not_0, double calc_not_01, double calc_rounded_1, double calc_rounded_2, double calc_rounded_3, double calc_rounded_4, double calc_rounded_5, double calc_rounded_6, double calc_rounded_7, double calc_rounded_8, double calc_rounded_9, double calc_rounded_10, double calc_rounded_11, double calc_rounded_12, double calc_rounded_13, double calc_rounded_14, double calc_rounded_15, double calc_rounded_16, double calc_rounded_17, double calc_rounded_18, double calc_rounded_19, double calc_rounded_20, double calc_rounded_21, double calc_rounded_22, double calc_rounded_23, double calc_rounded_24, double calc_rounded_25, double calc_rounded_26, double calc_rounded_27, double calc_rounded_28, double calc_rounded_29, double calc_rounded_30, double calc_rounded_31, double calc_rounded_32, double calc_rounded_33, double calc_rounded_34, double calc_rounded_35, double calc_rounded_36, double calc_rounded_37, double calc_rounded_38, double calc_rounded_39, double calc_rounded_40, double calc_rounded_41, double calc_rounded_42, double calc_rounded_43, double calc_rounded_44, double calc_rounded_45, double calc_rounded_46, double calc_rounded_47, double calc_rounded_48, double calc_rounded_49, double calc_rounded_50, double calc_rounded_51, double calc_rounded_52, double calc_rounded_53, double calc_rounded_54, double calc_rounded_55, double calc_rounded_56, double calc_rounded_57, double calc_rounded_58, double calc_rounded_59, double calc_rounded_60, double calc_rounded_61, double calc_rounded_62, double calc_rounded_63, double calc_rounded_64, double calc_rounded_65, double calc_rounded_66, double calc_rounded_67, double calc_rounded_68, double calc_rounded_69, double calc_rounded_70, double calc_rounded_71, double calc_rounded_72, double calc_rounded_73, double calc_not_1, double calc_not_2, double calc_not_3, double calc_not_4, double calc_not_5, double calc_not_6, double calc_not_7, double calc_not_8, double calc_not_9, double calc_not_10, double calc_not_11, double calc_not_12, double calc_not_13, double calc_not_14, double calc_not_15, double calc_not_16, double calc_not_17, double calc_not_18, double calc_not_19, double calc_not_20, double calc_not_21, double calc_not_22, double calc_not_23, double calc_not_24, double calc_not_25, double calc_not_26, double calc_not_27, double calc_not_28, double calc_not_29, double calc_not_30, double calc_not_31, double calc_not_32, double calc_not_33, double calc_not_34, double calc_not_35, double calc_not_36, double calc_not_37, double calc_not_38, double calc_not_39, double calc_not_40, double calc_not_41, double calc_not_42, double calc_not_43, double calc_not_44, double calc_not_45, double calc_not_46, double calc_not_47, double calc_not_48, double calc_not_49, double calc_not_50, double calc_not_51, double calc_not_52, double calc_not_53, double calc_not_54, double calc_not_55, double calc_not_56, double calc_not_57, double calc_not_58, double calc_not_59, double calc_not_60, double calc_not_61, double calc_not_62, double calc_not_63, double calc_not_64, double calc_not_65, double calc_not_66, double calc_not_67, double calc_not_68, double calc_not_69, double calc_not_70, double calc_not_71, double calc_not_72, double calc_not_73, string createdby, string createddate, string updatedby, string updateddate)
        {
            dc.Calculation calculation = null;
            try
            {
                if (isnew == false)
                {
                    calculation = _dataContext.Calculations.
                                    Where(p => p.id == id).
                                    SingleOrDefault<dc.Calculation>();
                }
                else
                {
                    calculation = new dc.Calculation();
                }

                calculation.TaxPayerNumber = TaxPayerNumber;
                calculation.form = form;
                calculation.year = year;
                calculation.ammend = ammend;

                calculation.calc_rounded_b1 = calc_rounded_b1;
                calculation.calc_rounded_b2 = calc_rounded_b2;
                calculation.calc_rounded_b3 = calc_rounded_b3;
                calculation.calc_rounded_b4 = calc_rounded_b4;
                calculation.calc_rounded_b5 = calc_rounded_b5;
                calculation.calc_rounded_b6 = calc_rounded_b6;
                calculation.calc_rounded_b7 = calc_rounded_b7;
                calculation.calc_rounded_b8 = calc_rounded_b8;
                calculation.calc_not_b1 = calc_not_b1;
                calculation.calc_not_b2 = calc_not_b2;
                calculation.calc_not_b3 = calc_not_b3;
                calculation.calc_not_b4 = calc_not_b4;
                calculation.calc_not_b5 = calc_not_b5;
                calculation.calc_not_b6 = calc_not_b6;
                calculation.calc_not_b7 = calc_not_b7;
                calculation.calc_not_b8 = calc_not_b8;
                calculation.calc_not_b9 = calc_not_b9;
                calculation.calc_rounded_0 = calc_rounded_0;
                calculation.calc_rounded_01 = calc_rounded_01;
                calculation.calc_not_0 = calc_not_0;
                calculation.calc_not_01 = calc_not_01;

                calculation.calc_rounded_1 = calc_rounded_1;
                calculation.calc_rounded_2 = calc_rounded_2;
                calculation.calc_rounded_3 = calc_rounded_3;
                calculation.calc_rounded_4 = calc_rounded_4;
                calculation.calc_rounded_5 = calc_rounded_5;
                calculation.calc_rounded_6 = calc_rounded_6;
                calculation.calc_rounded_7 = calc_rounded_7;
                calculation.calc_rounded_8 = calc_rounded_8;
                calculation.calc_rounded_9 = calc_rounded_9;
                calculation.calc_rounded_10 = calc_rounded_10;
                calculation.calc_rounded_11 = calc_rounded_11;
                calculation.calc_rounded_12 = calc_rounded_12;
                calculation.calc_rounded_13 = calc_rounded_13;
                calculation.calc_rounded_14 = calc_rounded_14;
                calculation.calc_rounded_15 = calc_rounded_15;
                calculation.calc_rounded_16 = calc_rounded_16;
                calculation.calc_rounded_17 = calc_rounded_17;
                calculation.calc_rounded_18 = calc_rounded_18;
                calculation.calc_rounded_19 = calc_rounded_19;
                calculation.calc_rounded_20 = calc_rounded_20;
                calculation.calc_rounded_21 = calc_rounded_21;
                calculation.calc_rounded_22 = calc_rounded_22;
                calculation.calc_rounded_23 = calc_rounded_23;
                calculation.calc_rounded_24 = calc_rounded_24;
                calculation.calc_rounded_25 = calc_rounded_25;
                calculation.calc_rounded_26 = calc_rounded_26;
                calculation.calc_rounded_27 = calc_rounded_27;
                calculation.calc_rounded_28 = calc_rounded_28;
                calculation.calc_rounded_29 = calc_rounded_29;
                calculation.calc_rounded_30 = calc_rounded_30;
                calculation.calc_rounded_31 = calc_rounded_31;
                calculation.calc_rounded_32 = calc_rounded_32;
                calculation.calc_rounded_33 = calc_rounded_33;
                calculation.calc_rounded_34 = calc_rounded_34;
                calculation.calc_rounded_35 = calc_rounded_35;
                calculation.calc_rounded_36 = calc_rounded_36;
                calculation.calc_rounded_37 = calc_rounded_37;
                calculation.calc_rounded_38 = calc_rounded_38;
                calculation.calc_rounded_39 = calc_rounded_39;
                calculation.calc_rounded_40 = calc_rounded_40;
                calculation.calc_rounded_41 = calc_rounded_41;
                calculation.calc_rounded_42 = calc_rounded_42;
                calculation.calc_rounded_43 = calc_rounded_43;
                calculation.calc_rounded_44 = calc_rounded_44;
                calculation.calc_rounded_45 = calc_rounded_45;
                calculation.calc_rounded_46 = calc_rounded_46;
                calculation.calc_rounded_47 = calc_rounded_47;
                calculation.calc_rounded_48 = calc_rounded_48;
                calculation.calc_rounded_49 = calc_rounded_49;
                calculation.calc_rounded_50 = calc_rounded_50;
                calculation.calc_rounded_51 = calc_rounded_51;
                calculation.calc_rounded_52 = calc_rounded_52;
                calculation.calc_rounded_53 = calc_rounded_53;
                calculation.calc_rounded_54 = calc_rounded_54;
                calculation.calc_rounded_55 = calc_rounded_55;
                calculation.calc_rounded_56 = calc_rounded_56;
                calculation.calc_rounded_57 = calc_rounded_57;
                calculation.calc_rounded_58 = calc_rounded_58;
                calculation.calc_rounded_59 = calc_rounded_59;
                calculation.calc_rounded_60 = calc_rounded_60;
                calculation.calc_rounded_61 = calc_rounded_61;
                calculation.calc_rounded_62 = calc_rounded_62;
                calculation.calc_rounded_63 = calc_rounded_63;
                calculation.calc_rounded_64 = calc_rounded_64;
                calculation.calc_rounded_65 = calc_rounded_65;
                calculation.calc_rounded_66 = calc_rounded_66;
                calculation.calc_rounded_67 = calc_rounded_67;
                calculation.calc_rounded_68 = calc_rounded_68;
                calculation.calc_rounded_69 = calc_rounded_69;
                calculation.calc_rounded_70 = calc_rounded_70;
                calculation.calc_rounded_71 = calc_rounded_71;
                calculation.calc_rounded_72 = calc_rounded_72;
                calculation.calc_rounded_73 = calc_rounded_73;
                calculation.calc_not_1 = calc_not_1;
                calculation.calc_not_2 = calc_not_2;
                calculation.calc_not_3 = calc_not_3;
                calculation.calc_not_4 = calc_not_4;
                calculation.calc_not_5 = calc_not_5;
                calculation.calc_not_6 = calc_not_6;
                calculation.calc_not_7 = calc_not_7;
                calculation.calc_not_8 = calc_not_8;
                calculation.calc_not_9 = calc_not_9;
                calculation.calc_not_10 = calc_not_10;
                calculation.calc_not_11 = calc_not_11;
                calculation.calc_not_12 = calc_not_12;
                calculation.calc_not_13 = calc_not_13;
                calculation.calc_not_14 = calc_not_14;
                calculation.calc_not_15 = calc_not_15;
                calculation.calc_not_16 = calc_not_16;
                calculation.calc_not_17 = calc_not_17;
                calculation.calc_not_18 = calc_not_18;
                calculation.calc_not_19 = calc_not_19;
                calculation.calc_not_20 = calc_not_20;
                calculation.calc_not_21 = calc_not_21;
                calculation.calc_not_22 = calc_not_22;
                calculation.calc_not_23 = calc_not_23;
                calculation.calc_not_24 = calc_not_24;
                calculation.calc_not_25 = calc_not_25;
                calculation.calc_not_26 = calc_not_26;
                calculation.calc_not_27 = calc_not_27;
                calculation.calc_not_28 = calc_not_28;
                calculation.calc_not_29 = calc_not_29;
                calculation.calc_not_30 = calc_not_30;
                calculation.calc_not_31 = calc_not_31;
                calculation.calc_not_32 = calc_not_32;
                calculation.calc_not_33 = calc_not_33;
                calculation.calc_not_34 = calc_not_34;
                calculation.calc_not_35 = calc_not_35;
                calculation.calc_not_36 = calc_not_36;
                calculation.calc_not_37 = calc_not_37;
                calculation.calc_not_38 = calc_not_38;
                calculation.calc_not_39 = calc_not_39;
                calculation.calc_not_40 = calc_not_40;
                calculation.calc_not_41 = calc_not_41;
                calculation.calc_not_42 = calc_not_42;
                calculation.calc_not_43 = calc_not_43;
                calculation.calc_not_44 = calc_not_44;
                calculation.calc_not_45 = calc_not_45;
                calculation.calc_not_46 = calc_not_46;
                calculation.calc_not_47 = calc_not_47;
                calculation.calc_not_48 = calc_not_48;
                calculation.calc_not_49 = calc_not_49;
                calculation.calc_not_50 = calc_not_50;
                calculation.calc_not_51 = calc_not_51;
                calculation.calc_not_52 = calc_not_52;
                calculation.calc_not_53 = calc_not_53;
                calculation.calc_not_54 = calc_not_54;
                calculation.calc_not_55 = calc_not_55;
                calculation.calc_not_56 = calc_not_56;
                calculation.calc_not_57 = calc_not_57;
                calculation.calc_not_58 = calc_not_58;
                calculation.calc_not_59 = calc_not_59;
                calculation.calc_not_60 = calc_not_60;
                calculation.calc_not_61 = calc_not_61;
                calculation.calc_not_62 = calc_not_62;
                calculation.calc_not_63 = calc_not_63;
                calculation.calc_not_64 = calc_not_64;
                calculation.calc_not_65 = calc_not_65;
                calculation.calc_not_66 = calc_not_66;
                calculation.calc_not_67 = calc_not_67;
                calculation.calc_not_68 = calc_not_68;
                calculation.calc_not_69 = calc_not_69;
                calculation.calc_not_70 = calc_not_70;
                calculation.calc_not_71 = calc_not_71;
                calculation.calc_not_72 = calc_not_72;
                calculation.calc_not_73 = calc_not_73;
                calculation.updatedby = updatedby;
                calculation.updateddate = updateddate;

                if (isnew == false)
                {
                    _dataContext.SubmitChanges();
                }
                else
                {
                    calculation.createdby = createdby;
                    calculation.createddate = createddate;
                    _dataContext.Calculations.InsertOnSubmit(calculation);
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
