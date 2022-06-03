using System.Text.Json;
using DinoSoft.CuCounters.Data.Common;
using DinoSoft.CuCounters.Data.Contracts.Repository;
using DinoSoft.CuCounters.Data.Infrastructure;
using DinoSoft.CuCounters.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace DinoSoft.CuCounters.Data.Repository
{
    internal class CounterActionRepository :  AbstractRepository<Guid, CounterAction>, ICounterActionRepository
    {
        public CounterActionRepository(DataContext context)
            : base(context)
        {
        }
    }
}
