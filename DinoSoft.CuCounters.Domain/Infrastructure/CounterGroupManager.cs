using DinoSoft.CuCounters.Data.Infrastructure;
using DinoSoft.CuCounters.Data.Repository;
using DinoSoft.CuCounters.Domain.Model;

namespace DinoSoft.CuCounters.Domain.Infrastructure
{
    public class CounterGroupManager
    {
        private readonly CounterGroupRepository counterGroupRepository;

        public CounterGroupManager(CounterGroupRepository counterGroupRepository)
        {
            this.counterGroupRepository = counterGroupRepository;
        }

        public async Task<CounterGroup> GetRootCounterGroup()
        {
            var counterGroup = await counterGroupRepository.FirstOrDefault(x => !x.CounterGroupId.HasValue);
            return new CounterGroup(counterGroup);
        }

        public async Task<CounterGroup> GetCounterGroup(Guid id)
        {
            var counterGroup = await counterGroupRepository.Get(id);
            return new CounterGroup(counterGroup);
        }

        public async Task<IEnumerable<CounterGroup>> GetCounterGroups()
        {
            // todo: DataContext init
            //dataContext = InitAndSaveTestDataContext();
            var counterGroups = await counterGroupRepository.Get(x => true);

            return counterGroups.Select(x => new CounterGroup(x));
        }
    }
}
