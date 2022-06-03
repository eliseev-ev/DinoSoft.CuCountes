using DinoSoft.CuCounters.Domain.Contracts.Model;

namespace DinoSoft.CuCounters.Domain.Contracts.Infrastructure
{
    /// <summary>
    /// Менеджер групп.
    /// </summary>
    public interface IGroupManager
    {
        Task<IGroup> GetCounterGroup(Guid id);

        Task<IEnumerable<IGroup>> GetGroups();

        Task<IGroup> GetRootCounterGroup();
    }
}