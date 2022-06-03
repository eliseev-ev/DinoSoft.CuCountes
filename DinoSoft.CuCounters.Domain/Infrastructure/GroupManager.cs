using DinoSoft.CuCounters.Data.Contracts.Repository;
using DinoSoft.CuCounters.Domain.Contracts.Infrastructure;
using DinoSoft.CuCounters.Domain.Contracts.Model;
using DinoSoft.CuCounters.Domain.Model;

namespace DinoSoft.CuCounters.Domain.Infrastructure
{
    internal class GroupManager : IGroupManager
    {
        private readonly ICounterGroupRepository counterGroupRepository;

        public GroupManager(ICounterGroupRepository counterGroupRepository)
        {
            this.counterGroupRepository = counterGroupRepository;
        }

        public async Task<IGroup> GetRootCounterGroup()
        {
            var counterGroup = await counterGroupRepository.FirstOrDefault(x => !x.CounterGroupId.HasValue);
            return new Group(counterGroup);
        }

        public async Task<IGroup> GetCounterGroup(Guid id)
        {
            var counterGroup = await counterGroupRepository.Get(id);
            return new Group(counterGroup);
        }

        public async Task<IEnumerable<IGroup>> GetGroups()
        {
            var counterGroups = await counterGroupRepository.Get(x => true);

            return counterGroups.Select(x => new Group(x));
        }
    }
}
