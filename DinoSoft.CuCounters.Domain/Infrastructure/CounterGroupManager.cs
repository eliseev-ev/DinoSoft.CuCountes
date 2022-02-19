using DinoSoft.CuCounters.Data.Infrastructure;
using DinoSoft.CuCounters.Data.Repository;
using DinoSoft.CuCounters.Domain.Model;

namespace DinoSoft.CuCounters.Domain.Infrastructure
{
    /// <summary>
    /// Менеджер групп.
    /// </summary>
    public class CounterGroupManager
    {
        private readonly CounterGroupRepository counterGroupRepository;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="counterGroupRepository">Репозиторий групп.</param>
        public CounterGroupManager(CounterGroupRepository counterGroupRepository)
        {
            this.counterGroupRepository = counterGroupRepository;
        }

        /// <summary>
        /// Получить родительскую группу.
        /// </summary>
        /// <returns>Группа.</returns>
        public async Task<Group> GetRootCounterGroup()
        {
            var counterGroup = await counterGroupRepository.FirstOrDefault(x => !x.CounterGroupId.HasValue);
            return new Group(counterGroup);
        }

        /// <summary>
        /// Получить группу по идентификатору.
        /// </summary>
        /// <param name="id">Иденитфикатор.</param>
        /// <returns>Группа.</returns>
        public async Task<Group> GetCounterGroup(Guid id)
        {
            var counterGroup = await counterGroupRepository.Get(id);
            return new Group(counterGroup);
        }

        /// <summary>
        /// Получить группы.
        /// </summary>
        /// <returns>Группы.</returns>
        public async Task<IEnumerable<Group>> GetCounterGroups()
        {
            var counterGroups = await counterGroupRepository.Get(x => true);

            return counterGroups.Select(x => new Group(x));
        }
    }
}
