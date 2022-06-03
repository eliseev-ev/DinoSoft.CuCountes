using Microsoft.Extensions.DependencyInjection;

namespace DinoSoft.CuCounters.Modularity.Extension
{
    /// <summary>
    /// Расширения для <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Зарегистрировать модуль в коллекции сервисов.
        /// </summary>
        /// <param name="serviceCollection"><see cref="IServiceCollection"/>.</param>
        /// <param name="module"><see cref="IModule"/>.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection RegisterModule(this IServiceCollection serviceCollection, IModule module)
        {
            module.RegisterServices(serviceCollection);
            return serviceCollection;
        }
    }
}