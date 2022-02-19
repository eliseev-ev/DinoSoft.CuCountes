using DinoSoft.CuCounters.Data.Infrastructure;
using DinoSoft.CuCounters.Data.Repository;
using DinoSoft.CuCounters.Domain.Model;

namespace DinoSoft.CuCounters.Domain.Infrastructure
{
    /// <summary>
    /// Менеджер для работы со счетчиками.
    /// </summary>
    public class CounterManager
    {
        private readonly CounterRepository counterRepository;

        /// <summary>
        /// Контркутор менеджера.
        /// </summary>
        /// <param name="counterRepository">Счетчик.</param>
        public CounterManager(CounterRepository counterRepository)
        {
            this.counterRepository = counterRepository;
        }

        /// <summary>
        /// получить счетчик по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Счетчик.</returns>
        public async Task<Counter> GetCounter(Guid id)
        {
            var counter = await counterRepository.Get(id);
            return new Counter(counter);
        }
    }
}
