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

        public async Task<IEnumerable<CounterGroup>> GetCounterGroups()
        {
            // todo: DataContext init
            //dataContext = InitAndSaveTestDataContext();
            var counterGroups = await counterGroupRepository.Get(x => true);

            return counterGroups.Select(x => new CounterGroup(x));
        }
    }
}
