using Microsoft.Extensions.DependencyInjection;

namespace DinoSoft.CuCounters.Modularity
{
    /// <summary>
    /// Модуль регистраций зависимостей.
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Регистриация зависимостей.
        /// </summary>
        /// <param name="serviceCollection"><see cref="IServiceCollection"/>.</param>
        public void RegisterServices(IServiceCollection serviceCollection);
    }
}
