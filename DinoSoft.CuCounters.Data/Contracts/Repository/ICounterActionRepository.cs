using DinoSoft.CuCounters.Data.Common.Model;
using DinoSoft.CuCounters.Data.Model;
using System.Linq.Expressions;

namespace DinoSoft.CuCounters.Data.Contracts.Repository
{
    public interface ICounterActionRepository : IRepository<Guid, CounterAction> 
    {
    }
}