using DinoSoft.CuCounters.Domain.Contracts.Infrastructure;
using DinoSoft.CuCounters.Domain.Infrastructure;
using DinoSoft.CuCounters.Modularity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoSoft.CuCounters.Domain
{
    public class DomainModule : IModule
    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IGroupManager, GroupManager>();
            serviceCollection.AddScoped<ICounterManager, CounterManager>();
        }
    }
}
