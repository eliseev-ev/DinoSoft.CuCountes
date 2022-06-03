using DinoSoft.CuCounters.Domain.Contracts.Model;

namespace DinoSoft.CuCounters.Domain.Contracts.Model
{
    /// <summary>
    /// Группа.
    /// </summary>
    public interface IGroup
    {
        Guid? CounterGroupId { get; }

        IEnumerable<ICounter> Counters { get; }

        IEnumerable<IGroup> Groups { get; }

        string IconName { get; }

        Guid Id { get; }

        string Name { get; }
    }
}