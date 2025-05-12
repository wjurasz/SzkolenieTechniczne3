using SzkolenieTechinczne.Company.Resolvers;
using SzkolenieTechniczne.Company.Services;
using SzkolenieTechniczne.Geo.Storage;

namespace SzkolenieTechinczne.Company.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCompanyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<JobPositionService>();
            serviceCollection.AddTransient<CompanyService>();
            serviceCollection.AddDbContext<CompanyDbContext, CompanyDbContext>();
            serviceCollection.AddTransient<CountryIntegrationDataResolver>();
            return serviceCollection;   
        }
    }
}
