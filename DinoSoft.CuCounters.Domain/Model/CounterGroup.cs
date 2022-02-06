using DinoSoft.CuCounters.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoSoft.CuCounters.Domain.Model
{
    public class CounterGroup
    {
        private readonly Data.Model.CounterGroup counterGroup;
        
        private Lazy<IEnumerable<Counter>> counters { get; }

        
        public CounterGroup(Data.Model.CounterGroup counterGroup)
        {
            this.counterGroup = counterGroup;

            counters = new Lazy<IEnumerable<Counter>>(() => this.counterGroup.Counters.Select(x => new Counter(x)));
        }

        public Guid Id  => this.counterGroup.Id;
        public String Name => this.counterGroup.Name;
        public String IconName => this.counterGroup.IconName;

        public IEnumerable<Counter> Counters => counters.Value;
    }
}
