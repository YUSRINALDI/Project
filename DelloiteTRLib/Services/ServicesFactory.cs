using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.DataContext;
using DelloiteTRLib.Repository;


namespace DelloiteTRLib.Services
{
    public class ServicesFactory
    {
        public static UserServices CreateUserServices(string connectionString)
        {
            DelloiteDataContext dataContext = new DelloiteDataContext(connectionString);
            UserRepository repository = new UserRepository();
            repository.SetDataContext(dataContext);
            UserServices service = new UserServices(repository);

            return service;
        }

        public static MaritalServices CreateMaritalServices(string connectionString)
        {
            DelloiteDataContext dataContext = new DelloiteDataContext(connectionString);
            MaritalRepository repository = new MaritalRepository();
            repository.SetDataContext(dataContext);
            MaritalServices service = new MaritalServices(repository);

            return service;
        }

        public static ecServices CreateECServices(string connectionString)
        {
            DelloiteDataContext dataContext = new DelloiteDataContext(connectionString);
            ecRepository repository = new ecRepository();
            repository.SetDataContext(dataContext);
            ecServices service = new ecServices(repository);

            return service;
        }

        public static comServices CreateCOMServices(string connectionString)
        {
            DelloiteDataContext dataContext = new DelloiteDataContext(connectionString);
            comRepository repository = new comRepository();
            repository.SetDataContext(dataContext);
            comServices service = new comServices(repository);

            return service;
        }

        public static etServices CreateETServices(string connectionString)
        {
            DelloiteDataContext dataContext = new DelloiteDataContext(connectionString);
            etRepository repository = new etRepository();
            repository.SetDataContext(dataContext);
            etServices service = new etServices(repository);

            return service;
        }

        public static IrregularServices CreateIrregularServices(string connectionString)
        {
            DelloiteDataContext dataContext = new DelloiteDataContext(connectionString);
            IrregularRepository repository = new IrregularRepository();
            repository.SetDataContext(dataContext);
            IrregularServices service = new IrregularServices(repository);

            return service;
        }

        public static AssetsliabilitiesServices CreateAssetsliabilitiesServices(string connectionString)
        {
            DelloiteDataContext dataContext = new DelloiteDataContext(connectionString);
            AssetsliabilitiesRepository repository = new AssetsliabilitiesRepository();
            repository.SetDataContext(dataContext);
            AssetsliabilitiesServices service = new AssetsliabilitiesServices(repository);

            return service;
        }

        public static RelationshipServices CreateRelationshipServices(string connectionString)
        {
            DelloiteDataContext dataContext = new DelloiteDataContext(connectionString);
            RelationshipRepository repository = new RelationshipRepository();
            repository.SetDataContext(dataContext);
            RelationshipServices service = new RelationshipServices(repository);

            return service;
        }

        public static ExchangeServices CreateExchangeServices(string connectionString)
        {
            DelloiteDataContext dataContext = new DelloiteDataContext(connectionString);
            ExchangeRepository repository = new ExchangeRepository();
            repository.SetDataContext(dataContext);
            ExchangeServices service = new ExchangeServices(repository);

            return service;
        }

        public static TaxPlayerServices CreateTaxPlayerServices(string connectionString)
        {
            DelloiteDataContext dataContext = new DelloiteDataContext(connectionString);
            TaxPlayerRepository repository = new TaxPlayerRepository();
            repository.SetDataContext(dataContext);
            TaxPlayerServices service = new TaxPlayerServices(repository);

            return service;
        }

        public static FamilyServices CreateFamilyServices(string connectionString)
        {
            DelloiteDataContext dataContext = new DelloiteDataContext(connectionString);
            FamilyRepository repository = new FamilyRepository();
            repository.SetDataContext(dataContext);
            FamilyServices service = new FamilyServices(repository);

            return service;
        }

        public static IEIncomeServices CreateIEIncomeServices(string connectionString)
        {
            DelloiteDataContext dataContext = new DelloiteDataContext(connectionString);
            IEIncomeRepository repository = new IEIncomeRepository();
            repository.SetDataContext(dataContext);
            IEIncomeServices service = new IEIncomeServices(repository);

            return service;
        }

        public static TaxFormServices CreateTaxFormServices(string connectionString)
        {
            DelloiteDataContext dataContext = new DelloiteDataContext(connectionString);
            TaxFormRepository repository = new TaxFormRepository();
            repository.SetDataContext(dataContext);
            TaxFormServices service = new TaxFormServices(repository);

            return service;
        }

        public static AssetServices CreateAssetServices(string connectionString)
        {
            DelloiteDataContext dataContext = new DelloiteDataContext(connectionString);
            AssetRepository repository = new AssetRepository();
            repository.SetDataContext(dataContext);
            AssetServices service = new AssetServices(repository);

            return service;
        }

        public static OverseaIncomeServices CreateOvIncomeServices(string connectionString)
        {
            DelloiteDataContext dataContext = new DelloiteDataContext(connectionString);
            OverseasIncomeRepository repository = new OverseasIncomeRepository();
            repository.SetDataContext(dataContext);
            OverseaIncomeServices service = new OverseaIncomeServices(repository);

            return service;
        }

        public static OverseasDetailedServices CreateOvIncomeDetailedServices(string connectionString)
        {
            DelloiteDataContext dataContext = new DelloiteDataContext(connectionString);
            OverseasDetailedRepository repository = new OverseasDetailedRepository();
            repository.SetDataContext(dataContext);
            OverseasDetailedServices service = new OverseasDetailedServices(repository);

            return service;
        }

        public static OverseaRentalServices CreateOvRentalServices(string connectionString)
        {
            DelloiteDataContext dataContext = new DelloiteDataContext(connectionString);
            OverseasRentalRepository repository = new OverseasRentalRepository();
            repository.SetDataContext(dataContext);
            OverseaRentalServices service = new OverseaRentalServices(repository);

            return service;
        }

        public static OverseasCapitalServices CreateOvCapitalServices(string connectionString)
        {
            DelloiteDataContext dataContext = new DelloiteDataContext(connectionString);
            OverseasCapitalRepository repository = new OverseasCapitalRepository();
            repository.SetDataContext(dataContext);
            OverseasCapitalServices service = new OverseasCapitalServices(repository);

            return service;
        }

        public static CalculationServices CreateCalculationServices(string connectionString)
        {
            DelloiteDataContext dataContext = new DelloiteDataContext(connectionString);
            CalculationRepository repository = new CalculationRepository();
            repository.SetDataContext(dataContext);
            CalculationServices service = new CalculationServices(repository);

            return service;
        }
    }
}
