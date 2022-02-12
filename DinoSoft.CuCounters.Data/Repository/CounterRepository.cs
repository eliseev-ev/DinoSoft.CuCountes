using System.Text.Json;
using DinoSoft.CuCounters.Data.Common;
using DinoSoft.CuCounters.Data.Infrastructure;
using DinoSoft.CuCounters.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace DinoSoft.CuCounters.Data.Repository
{
    public class CounterRepository : AbstractRepository<Guid, Counter>
    {
        public CounterRepository(DataContext context)
            : base(context)
        {
        }
    }
}
