using DinoSoft.CuCounters.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoSoft.CuCounters.BlazorApp.Infrastructure
{
    public class BlazorModule : IModule
    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<INavigationService, NavigationService>();
        }
    }
}
