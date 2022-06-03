using DinoSoft.CuCounters.Data.Contracts.Repository;
using DinoSoft.CuCounters.Domain.Contracts.Infrastructure;
using DinoSoft.CuCounters.Domain.Contracts.Model;
using DinoSoft.CuCounters.Domain.Model;

namespace DinoSoft.CuCounters.Domain.Infrastructure
{
    internal class CounterManager : ICounterManager
    {
        private readonly ICounterRepository counterRepository;

        public CounterManager(ICounterRepository counterRepository)
        {
            this.counterRepository = counterRepository;
        }

        public async Task<ICounter> GetCounter(Guid id)
        {
            var counter = await counterRepository.Get(id);
            return new Counter(counter);
        }
    }
}
