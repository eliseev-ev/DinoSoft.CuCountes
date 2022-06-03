using DinoSoft.CuCounters.Data.Contracts.Repository;
using DinoSoft.CuCounters.Data.Infrastructure;
using DinoSoft.CuCounters.Data.Repository;
using DinoSoft.CuCounters.Domain.Model;

namespace DinoSoft.CuCounters.Domain.Infrastructure
{
    public class CounterManager
    {
        private readonly ICounterRepository counterRepository;

        public CounterManager(ICounterRepository counterRepository)
        {
            this.counterRepository = counterRepository;
        }

        public async Task<Counter> GetCounter(Guid id)
        {
            var counter = await counterRepository.Get(id);
            return new Counter(counter);
        }
    }
}
