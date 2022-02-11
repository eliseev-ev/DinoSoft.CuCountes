using DinoSoft.CuCounters.Common.Extensions;
using DinoSoft.CuCounters.Data.Infrastructure;
using DinoSoft.CuCounters.Data.Infrastructure.Model;

namespace DinoSoft.CuCounters.Data.Model
{
    public class DataContext
    {
        public List<CounterGroup> CounterGroups { get; set; }
    }
}