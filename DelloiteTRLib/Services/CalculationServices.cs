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
    public class CalculationServices
    {
        private CalculationRepository _repository;

        public CalculationServices(CalculationRepository repository)
        {
            _repository = repository;
        }


        public List<vm.Calculation> GetAll()
        {

            List<vm.Calculation> dataModels = new List<vm.Calculation>();
            IEnumerable<dc.Calculation> datas = null;
            try
            {
                datas = _repository.FindAll();
                if (datas != null)
                {

                    foreach (dc.Calculation data in datas)
                    {
                        vm.Calculation dataModel = new vm.Calculation();
                        dataModel.id = data.id;
                        dataModel.TaxPlayerNumber = data.TaxPayerNumber;
                        dataModel.form = data.form;
                        dataModel.year = data.year;

                        dataModel.calc_rounded_b1 = data.calc_rounded_b1;
                        dataModel.calc_rounded_b2 = data.calc_rounded_b2;
                        dataModel.calc_rounded_b3 = data.calc_rounded_b3;
                        dataModel.calc_rounded_b4 = data.calc_rounded_b4;
                        dataModel.calc_rounded_b5 = data.calc_rounded_b5;
                        dataModel.calc_rounded_b6 = data.calc_rounded_b6;
                        dataModel.calc_rounded_b7 = data.calc_rounded_b7;
                        dataModel.calc_rounded_b8 = data.calc_rounded_b8;
                        dataModel.calc_not_b1 = data.calc_not_b1;
                        dataModel.calc_not_b2 = data.calc_not_b2;
                        dataModel.calc_not_b3 = data.calc_not_b3;
                        dataModel.calc_not_b4 = data.calc_not_b4;
                        dataModel.calc_not_b5 = data.calc_not_b5;
                        dataModel.calc_not_b6 = data.calc_not_b6;
                        dataModel.calc_not_b7 = data.calc_not_b7;
                        dataModel.calc_not_b8 = data.calc_not_b8;
                        dataModel.calc_not_b9 = data.calc_not_b9;
                        dataModel.calc_rounded_0 = data.calc_rounded_0;
                        dataModel.calc_rounded_01 = data.calc_rounded_01;
                        dataModel.calc_not_0 = data.calc_not_0;
                        dataModel.calc_not_01 = data.calc_not_01;

                        dataModel.calc_rounded_1 = data.calc_rounded_1;
                        dataModel.calc_rounded_2 = data.calc_rounded_2;
                        dataModel.calc_rounded_3 = data.calc_rounded_3;
                        dataModel.calc_rounded_4 = data.calc_rounded_4;
                        dataModel.calc_rounded_5 = data.calc_rounded_5;
                        dataModel.calc_rounded_6 = data.calc_rounded_6;
                        dataModel.calc_rounded_7 = data.calc_rounded_7;
                        dataModel.calc_rounded_8 = data.calc_rounded_8;
                        dataModel.calc_rounded_9 = data.calc_rounded_9;
                        dataModel.calc_rounded_10 = data.calc_rounded_10;
                        dataModel.calc_rounded_11 = data.calc_rounded_11;
                        dataModel.calc_rounded_12 = data.calc_rounded_12;
                        dataModel.calc_rounded_13 = data.calc_rounded_13;
                        dataModel.calc_rounded_14 = data.calc_rounded_14;
                        dataModel.calc_rounded_15 = data.calc_rounded_15;
                        dataModel.calc_rounded_16 = data.calc_rounded_16;
                        dataModel.calc_rounded_17 = data.calc_rounded_17;
                        dataModel.calc_rounded_18 = data.calc_rounded_18;
                        dataModel.calc_rounded_19 = data.calc_rounded_19;
                        dataModel.calc_rounded_20 = data.calc_rounded_20;
                        dataModel.calc_rounded_21 = data.calc_rounded_21;
                        dataModel.calc_rounded_22 = data.calc_rounded_22;
                        dataModel.calc_rounded_23 = data.calc_rounded_23;
                        dataModel.calc_rounded_24 = data.calc_rounded_24;
                        dataModel.calc_rounded_25 = data.calc_rounded_25;
                        dataModel.calc_rounded_26 = data.calc_rounded_26;
                        dataModel.calc_rounded_27 = data.calc_rounded_27;
                        dataModel.calc_rounded_28 = data.calc_rounded_28;
                        dataModel.calc_rounded_29 = data.calc_rounded_29;
                        dataModel.calc_rounded_30 = data.calc_rounded_30;
                        dataModel.calc_rounded_31 = data.calc_rounded_31;
                        dataModel.calc_rounded_32 = data.calc_rounded_32;
                        dataModel.calc_rounded_33 = data.calc_rounded_33;
                        dataModel.calc_rounded_34 = data.calc_rounded_34;
                        dataModel.calc_rounded_35 = data.calc_rounded_35;
                        dataModel.calc_rounded_36 = data.calc_rounded_36;
                        dataModel.calc_rounded_37 = data.calc_rounded_37;
                        dataModel.calc_rounded_38 = data.calc_rounded_38;
                        dataModel.calc_rounded_39 = data.calc_rounded_39;
                        dataModel.calc_rounded_40 = data.calc_rounded_40;
                        dataModel.calc_rounded_41 = data.calc_rounded_41;
                        dataModel.calc_rounded_42 = data.calc_rounded_42;
                        dataModel.calc_rounded_43 = data.calc_rounded_43;
                        dataModel.calc_rounded_44 = data.calc_rounded_44;
                        dataModel.calc_rounded_45 = data.calc_rounded_45;
                        dataModel.calc_rounded_46 = data.calc_rounded_46;
                        dataModel.calc_rounded_47 = data.calc_rounded_47;
                        dataModel.calc_rounded_48 = data.calc_rounded_48;
                        dataModel.calc_rounded_49 = data.calc_rounded_49;
                        dataModel.calc_rounded_50 = data.calc_rounded_50;
                        dataModel.calc_rounded_51 = data.calc_rounded_51;
                        dataModel.calc_rounded_52 = data.calc_rounded_52;
                        dataModel.calc_rounded_53 = data.calc_rounded_53;
                        dataModel.calc_rounded_54 = data.calc_rounded_54;
                        dataModel.calc_rounded_55 = data.calc_rounded_55;
                        dataModel.calc_rounded_56 = data.calc_rounded_56;
                        dataModel.calc_rounded_57 = data.calc_rounded_57;
                        dataModel.calc_rounded_58 = data.calc_rounded_58;
                        dataModel.calc_rounded_59 = data.calc_rounded_59;
                        dataModel.calc_rounded_60 = data.calc_rounded_60;
                        dataModel.calc_rounded_61 = data.calc_rounded_61;
                        dataModel.calc_rounded_62 = data.calc_rounded_62;
                        dataModel.calc_rounded_63 = data.calc_rounded_63;
                        dataModel.calc_rounded_64 = data.calc_rounded_64;
                        dataModel.calc_rounded_65 = data.calc_rounded_65;
                        dataModel.calc_rounded_66 = data.calc_rounded_66;
                        dataModel.calc_rounded_67 = data.calc_rounded_67;
                        dataModel.calc_rounded_68 = data.calc_rounded_68;
                        dataModel.calc_rounded_69 = data.calc_rounded_69;
                        dataModel.calc_rounded_70 = data.calc_rounded_70;
                        dataModel.calc_rounded_71 = data.calc_rounded_71;
                        dataModel.calc_rounded_72 = data.calc_rounded_72;
                        dataModel.calc_rounded_73 = data.calc_rounded_73;
                        dataModel.calc_not_1 = data.calc_not_1;
                        dataModel.calc_not_2 = data.calc_not_2;
                        dataModel.calc_not_3 = data.calc_not_3;
                        dataModel.calc_not_4 = data.calc_not_4;
                        dataModel.calc_not_5 = data.calc_not_5;
                        dataModel.calc_not_6 = data.calc_not_6;
                        dataModel.calc_not_7 = data.calc_not_7;
                        dataModel.calc_not_8 = data.calc_not_8;
                        dataModel.calc_not_9 = data.calc_not_9;
                        dataModel.calc_not_10 = data.calc_not_10;
                        dataModel.calc_not_11 = data.calc_not_11;
                        dataModel.calc_not_12 = data.calc_not_12;
                        dataModel.calc_not_13 = data.calc_not_13;
                        dataModel.calc_not_14 = data.calc_not_14;
                        dataModel.calc_not_15 = data.calc_not_15;
                        dataModel.calc_not_16 = data.calc_not_16;
                        dataModel.calc_not_17 = data.calc_not_17;
                        dataModel.calc_not_18 = data.calc_not_18;
                        dataModel.calc_not_19 = data.calc_not_19;
                        dataModel.calc_not_20 = data.calc_not_20;
                        dataModel.calc_not_21 = data.calc_not_21;
                        dataModel.calc_not_22 = data.calc_not_22;
                        dataModel.calc_not_23 = data.calc_not_23;
                        dataModel.calc_not_24 = data.calc_not_24;
                        dataModel.calc_not_25 = data.calc_not_25;
                        dataModel.calc_not_26 = data.calc_not_26;
                        dataModel.calc_not_27 = data.calc_not_27;
                        dataModel.calc_not_28 = data.calc_not_28;
                        dataModel.calc_not_29 = data.calc_not_29;
                        dataModel.calc_not_30 = data.calc_not_30;
                        dataModel.calc_not_31 = data.calc_not_31;
                        dataModel.calc_not_32 = data.calc_not_32;
                        dataModel.calc_not_33 = data.calc_not_33;
                        dataModel.calc_not_34 = data.calc_not_34;
                        dataModel.calc_not_35 = data.calc_not_35;
                        dataModel.calc_not_36 = data.calc_not_36;
                        dataModel.calc_not_37 = data.calc_not_37;
                        dataModel.calc_not_38 = data.calc_not_38;
                        dataModel.calc_not_39 = data.calc_not_39;
                        dataModel.calc_not_40 = data.calc_not_40;
                        dataModel.calc_not_41 = data.calc_not_41;
                        dataModel.calc_not_42 = data.calc_not_42;
                        dataModel.calc_not_43 = data.calc_not_43;
                        dataModel.calc_not_44 = data.calc_not_44;
                        dataModel.calc_not_45 = data.calc_not_45;
                        dataModel.calc_not_46 = data.calc_not_46;
                        dataModel.calc_not_47 = data.calc_not_47;
                        dataModel.calc_not_48 = data.calc_not_48;
                        dataModel.calc_not_49 = data.calc_not_49;
                        dataModel.calc_not_50 = data.calc_not_50;
                        dataModel.calc_not_51 = data.calc_not_51;
                        dataModel.calc_not_52 = data.calc_not_52;
                        dataModel.calc_not_53 = data.calc_not_53;
                        dataModel.calc_not_54 = data.calc_not_54;
                        dataModel.calc_not_55 = data.calc_not_55;
                        dataModel.calc_not_56 = data.calc_not_56;
                        dataModel.calc_not_57 = data.calc_not_57;
                        dataModel.calc_not_58 = data.calc_not_58;
                        dataModel.calc_not_59 = data.calc_not_59;
                        dataModel.calc_not_60 = data.calc_not_60;
                        dataModel.calc_not_61 = data.calc_not_61;
                        dataModel.calc_not_62 = data.calc_not_62;
                        dataModel.calc_not_63 = data.calc_not_63;
                        dataModel.calc_not_64 = data.calc_not_64;
                        dataModel.calc_not_65 = data.calc_not_65;
                        dataModel.calc_not_66 = data.calc_not_66;
                        dataModel.calc_not_67 = data.calc_not_67;
                        dataModel.calc_not_68 = data.calc_not_68;
                        dataModel.calc_not_69 = data.calc_not_69;
                        dataModel.calc_not_70 = data.calc_not_70;
                        dataModel.calc_not_71 = data.calc_not_71;
                        dataModel.calc_not_72 = data.calc_not_72;
                        dataModel.calc_not_73 = data.calc_not_73;
                        dataModel.createdby = data.createdby;
                        dataModel.createddate = data.createddate;
                        dataModel.updatedby = data.updatedby;
                        dataModel.updateddate = data.updateddate;

                        dataModels.Add(dataModel);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dataModels;
        }

        public List<vm.Calculation> GetAllBy(string TaxPayerNumber, string form, string year, int ammend)
        {
            List<vm.Calculation> dataModels = new List<vm.Calculation>();
            IEnumerable<dc.Calculation> datas = null;

            try
            {
                datas = _repository.GetAllBy(TaxPayerNumber, form, year, ammend);

                if (datas != null)
                {
                    foreach (dc.Calculation data in datas)
                    {
                        vm.Calculation dataModel = new vm.Calculation();
                        dataModel.id = data.id;
                        dataModel.TaxPlayerNumber = data.TaxPayerNumber;
                        dataModel.form = data.form;
                        dataModel.year = data.year;

                        dataModel.calc_rounded_b1 = data.calc_rounded_b1;
                        dataModel.calc_rounded_b2 = data.calc_rounded_b2;
                        dataModel.calc_rounded_b3 = data.calc_rounded_b3;
                        dataModel.calc_rounded_b4 = data.calc_rounded_b4;
                        dataModel.calc_rounded_b5 = data.calc_rounded_b5;
                        dataModel.calc_rounded_b6 = data.calc_rounded_b6;
                        dataModel.calc_rounded_b7 = data.calc_rounded_b7;
                        dataModel.calc_rounded_b8 = data.calc_rounded_b8;
                        dataModel.calc_not_b1 = data.calc_not_b1;
                        dataModel.calc_not_b2 = data.calc_not_b2;
                        dataModel.calc_not_b3 = data.calc_not_b3;
                        dataModel.calc_not_b4 = data.calc_not_b4;
                        dataModel.calc_not_b5 = data.calc_not_b5;
                        dataModel.calc_not_b6 = data.calc_not_b6;
                        dataModel.calc_not_b7 = data.calc_not_b7;
                        dataModel.calc_not_b8 = data.calc_not_b8;
                        dataModel.calc_not_b9 = data.calc_not_b9;
                        dataModel.calc_rounded_0 = data.calc_rounded_0;
                        dataModel.calc_rounded_01 = data.calc_rounded_01;
                        dataModel.calc_not_0 = data.calc_not_0;
                        dataModel.calc_not_01 = data.calc_not_01;

                        dataModel.calc_rounded_1 = data.calc_rounded_1;
                        dataModel.calc_rounded_2 = data.calc_rounded_2;
                        dataModel.calc_rounded_3 = data.calc_rounded_3;
                        dataModel.calc_rounded_4 = data.calc_rounded_4;
                        dataModel.calc_rounded_5 = data.calc_rounded_5;
                        dataModel.calc_rounded_6 = data.calc_rounded_6;
                        dataModel.calc_rounded_7 = data.calc_rounded_7;
                        dataModel.calc_rounded_8 = data.calc_rounded_8;
                        dataModel.calc_rounded_9 = data.calc_rounded_9;
                        dataModel.calc_rounded_10 = data.calc_rounded_10;
                        dataModel.calc_rounded_11 = data.calc_rounded_11;
                        dataModel.calc_rounded_12 = data.calc_rounded_12;
                        dataModel.calc_rounded_13 = data.calc_rounded_13;
                        dataModel.calc_rounded_14 = data.calc_rounded_14;
                        dataModel.calc_rounded_15 = data.calc_rounded_15;
                        dataModel.calc_rounded_16 = data.calc_rounded_16;
                        dataModel.calc_rounded_17 = data.calc_rounded_17;
                        dataModel.calc_rounded_18 = data.calc_rounded_18;
                        dataModel.calc_rounded_19 = data.calc_rounded_19;
                        dataModel.calc_rounded_20 = data.calc_rounded_20;
                        dataModel.calc_rounded_21 = data.calc_rounded_21;
                        dataModel.calc_rounded_22 = data.calc_rounded_22;
                        dataModel.calc_rounded_23 = data.calc_rounded_23;
                        dataModel.calc_rounded_24 = data.calc_rounded_24;
                        dataModel.calc_rounded_25 = data.calc_rounded_25;
                        dataModel.calc_rounded_26 = data.calc_rounded_26;
                        dataModel.calc_rounded_27 = data.calc_rounded_27;
                        dataModel.calc_rounded_28 = data.calc_rounded_28;
                        dataModel.calc_rounded_29 = data.calc_rounded_29;
                        dataModel.calc_rounded_30 = data.calc_rounded_30;
                        dataModel.calc_rounded_31 = data.calc_rounded_31;
                        dataModel.calc_rounded_32 = data.calc_rounded_32;
                        dataModel.calc_rounded_33 = data.calc_rounded_33;
                        dataModel.calc_rounded_34 = data.calc_rounded_34;
                        dataModel.calc_rounded_35 = data.calc_rounded_35;
                        dataModel.calc_rounded_36 = data.calc_rounded_36;
                        dataModel.calc_rounded_37 = data.calc_rounded_37;
                        dataModel.calc_rounded_38 = data.calc_rounded_38;
                        dataModel.calc_rounded_39 = data.calc_rounded_39;
                        dataModel.calc_rounded_40 = data.calc_rounded_40;
                        dataModel.calc_rounded_41 = data.calc_rounded_41;
                        dataModel.calc_rounded_42 = data.calc_rounded_42;
                        dataModel.calc_rounded_43 = data.calc_rounded_43;
                        dataModel.calc_rounded_44 = data.calc_rounded_44;
                        dataModel.calc_rounded_45 = data.calc_rounded_45;
                        dataModel.calc_rounded_46 = data.calc_rounded_46;
                        dataModel.calc_rounded_47 = data.calc_rounded_47;
                        dataModel.calc_rounded_48 = data.calc_rounded_48;
                        dataModel.calc_rounded_49 = data.calc_rounded_49;
                        dataModel.calc_rounded_50 = data.calc_rounded_50;
                        dataModel.calc_rounded_51 = data.calc_rounded_51;
                        dataModel.calc_rounded_52 = data.calc_rounded_52;
                        dataModel.calc_rounded_53 = data.calc_rounded_53;
                        dataModel.calc_rounded_54 = data.calc_rounded_54;
                        dataModel.calc_rounded_55 = data.calc_rounded_55;
                        dataModel.calc_rounded_56 = data.calc_rounded_56;
                        dataModel.calc_rounded_57 = data.calc_rounded_57;
                        dataModel.calc_rounded_58 = data.calc_rounded_58;
                        dataModel.calc_rounded_59 = data.calc_rounded_59;
                        dataModel.calc_rounded_60 = data.calc_rounded_60;
                        dataModel.calc_rounded_61 = data.calc_rounded_61;
                        dataModel.calc_rounded_62 = data.calc_rounded_62;
                        dataModel.calc_rounded_63 = data.calc_rounded_63;
                        dataModel.calc_rounded_64 = data.calc_rounded_64;
                        dataModel.calc_rounded_65 = data.calc_rounded_65;
                        dataModel.calc_rounded_66 = data.calc_rounded_66;
                        dataModel.calc_rounded_67 = data.calc_rounded_67;
                        dataModel.calc_rounded_68 = data.calc_rounded_68;
                        dataModel.calc_rounded_69 = data.calc_rounded_69;
                        dataModel.calc_rounded_70 = data.calc_rounded_70;
                        dataModel.calc_rounded_71 = data.calc_rounded_71;
                        dataModel.calc_rounded_72 = data.calc_rounded_72;
                        dataModel.calc_rounded_73 = data.calc_rounded_73;
                        dataModel.calc_not_1 = data.calc_not_1;
                        dataModel.calc_not_2 = data.calc_not_2;
                        dataModel.calc_not_3 = data.calc_not_3;
                        dataModel.calc_not_4 = data.calc_not_4;
                        dataModel.calc_not_5 = data.calc_not_5;
                        dataModel.calc_not_6 = data.calc_not_6;
                        dataModel.calc_not_7 = data.calc_not_7;
                        dataModel.calc_not_8 = data.calc_not_8;
                        dataModel.calc_not_9 = data.calc_not_9;
                        dataModel.calc_not_10 = data.calc_not_10;
                        dataModel.calc_not_11 = data.calc_not_11;
                        dataModel.calc_not_12 = data.calc_not_12;
                        dataModel.calc_not_13 = data.calc_not_13;
                        dataModel.calc_not_14 = data.calc_not_14;
                        dataModel.calc_not_15 = data.calc_not_15;
                        dataModel.calc_not_16 = data.calc_not_16;
                        dataModel.calc_not_17 = data.calc_not_17;
                        dataModel.calc_not_18 = data.calc_not_18;
                        dataModel.calc_not_19 = data.calc_not_19;
                        dataModel.calc_not_20 = data.calc_not_20;
                        dataModel.calc_not_21 = data.calc_not_21;
                        dataModel.calc_not_22 = data.calc_not_22;
                        dataModel.calc_not_23 = data.calc_not_23;
                        dataModel.calc_not_24 = data.calc_not_24;
                        dataModel.calc_not_25 = data.calc_not_25;
                        dataModel.calc_not_26 = data.calc_not_26;
                        dataModel.calc_not_27 = data.calc_not_27;
                        dataModel.calc_not_28 = data.calc_not_28;
                        dataModel.calc_not_29 = data.calc_not_29;
                        dataModel.calc_not_30 = data.calc_not_30;
                        dataModel.calc_not_31 = data.calc_not_31;
                        dataModel.calc_not_32 = data.calc_not_32;
                        dataModel.calc_not_33 = data.calc_not_33;
                        dataModel.calc_not_34 = data.calc_not_34;
                        dataModel.calc_not_35 = data.calc_not_35;
                        dataModel.calc_not_36 = data.calc_not_36;
                        dataModel.calc_not_37 = data.calc_not_37;
                        dataModel.calc_not_38 = data.calc_not_38;
                        dataModel.calc_not_39 = data.calc_not_39;
                        dataModel.calc_not_40 = data.calc_not_40;
                        dataModel.calc_not_41 = data.calc_not_41;
                        dataModel.calc_not_42 = data.calc_not_42;
                        dataModel.calc_not_43 = data.calc_not_43;
                        dataModel.calc_not_44 = data.calc_not_44;
                        dataModel.calc_not_45 = data.calc_not_45;
                        dataModel.calc_not_46 = data.calc_not_46;
                        dataModel.calc_not_47 = data.calc_not_47;
                        dataModel.calc_not_48 = data.calc_not_48;
                        dataModel.calc_not_49 = data.calc_not_49;
                        dataModel.calc_not_50 = data.calc_not_50;
                        dataModel.calc_not_51 = data.calc_not_51;
                        dataModel.calc_not_52 = data.calc_not_52;
                        dataModel.calc_not_53 = data.calc_not_53;
                        dataModel.calc_not_54 = data.calc_not_54;
                        dataModel.calc_not_55 = data.calc_not_55;
                        dataModel.calc_not_56 = data.calc_not_56;
                        dataModel.calc_not_57 = data.calc_not_57;
                        dataModel.calc_not_58 = data.calc_not_58;
                        dataModel.calc_not_59 = data.calc_not_59;
                        dataModel.calc_not_60 = data.calc_not_60;
                        dataModel.calc_not_61 = data.calc_not_61;
                        dataModel.calc_not_62 = data.calc_not_62;
                        dataModel.calc_not_63 = data.calc_not_63;
                        dataModel.calc_not_64 = data.calc_not_64;
                        dataModel.calc_not_65 = data.calc_not_65;
                        dataModel.calc_not_66 = data.calc_not_66;
                        dataModel.calc_not_67 = data.calc_not_67;
                        dataModel.calc_not_68 = data.calc_not_68;
                        dataModel.calc_not_69 = data.calc_not_69;
                        dataModel.calc_not_70 = data.calc_not_70;
                        dataModel.calc_not_71 = data.calc_not_71;
                        dataModel.calc_not_72 = data.calc_not_72;
                        dataModel.calc_not_73 = data.calc_not_73;
                        dataModel.createdby = data.createdby;
                        dataModel.createddate = data.createddate;
                        dataModel.updatedby = data.updatedby;
                        dataModel.updateddate = data.updateddate;

                        dataModels.Add(dataModel);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dataModels;
        }


        public bool Save(bool isnew, int id, string TaxPayerNumber, string form, string year, int ammend, double calc_rounded_b1, double calc_rounded_b2, double calc_rounded_b3, double calc_rounded_b4, double calc_rounded_b5, double calc_rounded_b6, double calc_rounded_b7, double calc_rounded_b8, double calc_not_b1, double calc_not_b2, double calc_not_b3, double calc_not_b4, double calc_not_b5, double calc_not_b6, double calc_not_b7, double calc_not_b8, double calc_not_b9, double calc_rounded_0, double calc_rounded_01, double calc_not_0, double calc_not_01, double calc_rounded_1, double calc_rounded_2, double calc_rounded_3, double calc_rounded_4, double calc_rounded_5, double calc_rounded_6, double calc_rounded_7, double calc_rounded_8, double calc_rounded_9, double calc_rounded_10, double calc_rounded_11, double calc_rounded_12, double calc_rounded_13, double calc_rounded_14, double calc_rounded_15, double calc_rounded_16, double calc_rounded_17, double calc_rounded_18, double calc_rounded_19, double calc_rounded_20, double calc_rounded_21, double calc_rounded_22, double calc_rounded_23, double calc_rounded_24, double calc_rounded_25, double calc_rounded_26, double calc_rounded_27, double calc_rounded_28, double calc_rounded_29, double calc_rounded_30, double calc_rounded_31, double calc_rounded_32, double calc_rounded_33, double calc_rounded_34, double calc_rounded_35, double calc_rounded_36, double calc_rounded_37, double calc_rounded_38, double calc_rounded_39, double calc_rounded_40, double calc_rounded_41, double calc_rounded_42, double calc_rounded_43, double calc_rounded_44, double calc_rounded_45, double calc_rounded_46, double calc_rounded_47, double calc_rounded_48, double calc_rounded_49, double calc_rounded_50, double calc_rounded_51, double calc_rounded_52, double calc_rounded_53, double calc_rounded_54, double calc_rounded_55, double calc_rounded_56, double calc_rounded_57, double calc_rounded_58, double calc_rounded_59, double calc_rounded_60, double calc_rounded_61, double calc_rounded_62, double calc_rounded_63, double calc_rounded_64, double calc_rounded_65, double calc_rounded_66, double calc_rounded_67, double calc_rounded_68, double calc_rounded_69, double calc_rounded_70, double calc_rounded_71, double calc_rounded_72, double calc_rounded_73, double calc_not_1, double calc_not_2, double calc_not_3, double calc_not_4, double calc_not_5, double calc_not_6, double calc_not_7, double calc_not_8, double calc_not_9, double calc_not_10, double calc_not_11, double calc_not_12, double calc_not_13, double calc_not_14, double calc_not_15, double calc_not_16, double calc_not_17, double calc_not_18, double calc_not_19, double calc_not_20, double calc_not_21, double calc_not_22, double calc_not_23, double calc_not_24, double calc_not_25, double calc_not_26, double calc_not_27, double calc_not_28, double calc_not_29, double calc_not_30, double calc_not_31, double calc_not_32, double calc_not_33, double calc_not_34, double calc_not_35, double calc_not_36, double calc_not_37, double calc_not_38, double calc_not_39, double calc_not_40, double calc_not_41, double calc_not_42, double calc_not_43, double calc_not_44, double calc_not_45, double calc_not_46, double calc_not_47, double calc_not_48, double calc_not_49, double calc_not_50, double calc_not_51, double calc_not_52, double calc_not_53, double calc_not_54, double calc_not_55, double calc_not_56, double calc_not_57, double calc_not_58, double calc_not_59, double calc_not_60, double calc_not_61, double calc_not_62, double calc_not_63, double calc_not_64, double calc_not_65, double calc_not_66, double calc_not_67, double calc_not_68, double calc_not_69, double calc_not_70, double calc_not_71, double calc_not_72, double calc_not_73, string createdby, string createddate, string updatedby, string updateddate)
        {
            bool boolInsert = false;
            try
            {
                boolInsert = _repository.Save(isnew, id, TaxPayerNumber, form, year, ammend, calc_rounded_b1, calc_rounded_b2, calc_rounded_b3, calc_rounded_b4, calc_rounded_b5, calc_rounded_b6, calc_rounded_b7, calc_rounded_b8, calc_not_b1, calc_not_b2, calc_not_b3, calc_not_b4, calc_not_b5, calc_not_b6, calc_not_b7, calc_not_b8, calc_not_b9, calc_rounded_0, calc_rounded_01, calc_not_0, calc_not_01, calc_rounded_1, calc_rounded_2, calc_rounded_3, calc_rounded_4, calc_rounded_5, calc_rounded_6, calc_rounded_7, calc_rounded_8, calc_rounded_9, calc_rounded_10, calc_rounded_11, calc_rounded_12, calc_rounded_13, calc_rounded_14, calc_rounded_15, calc_rounded_16, calc_rounded_17, calc_rounded_18, calc_rounded_19, calc_rounded_20, calc_rounded_21, calc_rounded_22, calc_rounded_23, calc_rounded_24, calc_rounded_25, calc_rounded_26, calc_rounded_27, calc_rounded_28, calc_rounded_29, calc_rounded_30, calc_rounded_31, calc_rounded_32, calc_rounded_33, calc_rounded_34, calc_rounded_35, calc_rounded_36, calc_rounded_37, calc_rounded_38, calc_rounded_39, calc_rounded_40, calc_rounded_41, calc_rounded_42, calc_rounded_43, calc_rounded_44, calc_rounded_45, calc_rounded_46, calc_rounded_47, calc_rounded_48, calc_rounded_49, calc_rounded_50, calc_rounded_51, calc_rounded_52, calc_rounded_53, calc_rounded_54, calc_rounded_55, calc_rounded_56, calc_rounded_57, calc_rounded_58, calc_rounded_59, calc_rounded_60, calc_rounded_61, calc_rounded_62, calc_rounded_63, calc_rounded_64, calc_rounded_65, calc_rounded_66, calc_rounded_67, calc_rounded_68, calc_rounded_69, calc_rounded_70, calc_rounded_71, calc_rounded_72, calc_rounded_73, calc_not_1, calc_not_2, calc_not_3, calc_not_4, calc_not_5, calc_not_6, calc_not_7, calc_not_8, calc_not_9, calc_not_10, calc_not_11, calc_not_12, calc_not_13, calc_not_14, calc_not_15, calc_not_16, calc_not_17, calc_not_18, calc_not_19, calc_not_20, calc_not_21, calc_not_22, calc_not_23, calc_not_24, calc_not_25, calc_not_26, calc_not_27, calc_not_28, calc_not_29, calc_not_30, calc_not_31, calc_not_32, calc_not_33, calc_not_34, calc_not_35, calc_not_36, calc_not_37, calc_not_38, calc_not_39, calc_not_40, calc_not_41, calc_not_42, calc_not_43, calc_not_44, calc_not_45, calc_not_46, calc_not_47, calc_not_48, calc_not_49, calc_not_50, calc_not_51, calc_not_52, calc_not_53, calc_not_54, calc_not_55, calc_not_56, calc_not_57, calc_not_58, calc_not_59, calc_not_60, calc_not_61, calc_not_62, calc_not_63, calc_not_64, calc_not_65, calc_not_66, calc_not_67, calc_not_68, calc_not_69, calc_not_70, calc_not_71, calc_not_72, calc_not_73, createdby, createddate, updatedby, updateddate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return boolInsert;
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

