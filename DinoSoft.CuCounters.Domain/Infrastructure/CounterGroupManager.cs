using DinoSoft.CuCounters.Data.Infrastructure;
using DinoSoft.CuCounters.Data.Repository;
using DinoSoft.CuCounters.Domain.Model;

namespace DinoSoft.CuCounters.Domain.Infrastructure
{
    public class GroupManager
    {
        private readonly CounterGroupRepository counterGroupRepository;

        public GroupManager(CounterGroupRepository counterGroupRepository)
        {
            this.counterGroupRepository = counterGroupRepository;
        }

        public async Task<Group> GetRootCounterGroup()
        {
            var counterGroup = await counterGroupRepository.FirstOrDefault(x => !x.CounterGroupId.HasValue);
            return new Group(counterGroup);
        }

        public async Task<Group> GetCounterGroup(Guid id)
        {
            var counterGroup = await counterGroupRepository.Get(id);
            return new Group(counterGroup);
        }

        public async Task<IEnumerable<Group>> GetGroups()
        {
            var counterGroups = await counterGroupRepository.Get(x => true);

            return counterGroups.Select(x => new Group(x));
        }
    }
}
