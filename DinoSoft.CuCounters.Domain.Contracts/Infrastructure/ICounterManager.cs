using DinoSoft.CuCounters.Domain.Contracts.Model;

namespace DinoSoft.CuCounters.Domain.Contracts.Infrastructure
{
    /// <summary>
    /// Менеджер счетчиков.
    /// </summary>
    public interface ICounterManager
    {
        Task<ICounter> GetCounter(Guid id);
    }
}