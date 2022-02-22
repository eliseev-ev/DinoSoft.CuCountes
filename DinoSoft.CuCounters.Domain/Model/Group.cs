using DinoSoft.CuCounters.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoSoft.CuCounters.Domain.Model
{
    public class Group
    {
        private readonly Data.Model.Group group;
        
        private Lazy<IEnumerable<Counter>> counters { get; }

        private Lazy<IEnumerable<Group>> groups { get; }

        
        public Group(Data.Model.Group group)
        {
            this.group = group;

            counters = new Lazy<IEnumerable<Counter>>(() => this.group.Counters.Select(x => new Counter(x)));
            groups = new Lazy<IEnumerable<Group>>(() => this.group.Groups.Select(x => new Group(x)));
        }

        public Guid Id  => this.group.Id;

        public Guid? CounterGroupId => this.group.CounterGroupId;

        public String Name => this.group.Name;

        public String IconName => this.group.IconName;

        public IEnumerable<Counter> Counters => counters.Value;

        public IEnumerable<Group> Groups => groups.Value;
    }
}
