using DinoSoft.CuCounters.Data.Contracts.Repository;
using DinoSoft.CuCounters.Data.Infrastructure;
using DinoSoft.CuCounters.Data.Repository;
using DinoSoft.CuCounters.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace DinoSoft.CuCounters.Data
{
    public class DataModule : IModule
    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICounterGroupRepository, CounterGroupRepository>();
            serviceCollection.AddScoped<ICounterRepository, CounterRepository>();
            serviceCollection.AddScoped<ICounterActionRepository, CounterActionRepository>();
            serviceCollection.AddDbContext<DataContext>();
        }
    }
}
