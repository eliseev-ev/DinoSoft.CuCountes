using DinoSoft.CuCounters.Data.Model;

namespace DinoSoft.CuCounters.Domain.Contracts.Model
{
    /// <summary>
    /// Счетчик.
    /// </summary>
    public interface ICounter
    {
        Guid Id { get; }

        string Name { get; set; }

        int SortOrder { get; set; }

        int Value { get; set; }

        List<CounterAction> CounterAction { get; }

        Guid CounterGroupId { get; }

        string IconColor { get; set; }

        string IconName { get; set; }

        DateTime? LastUpdated { get; }

        void Act(Guid actionId);

        void AddValue(int value);
    }
}