using DinoSoft.CuCounters.Data.Model;
using DinoSoft.CuCounters.Domain.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoSoft.CuCounters.Domain.Model
{
    internal class Group : IGroup
    {
        private readonly Data.Model.Group group;
        private Lazy<IEnumerable<ICounter>> counters { get; }
        private Lazy<IEnumerable<IGroup>> groups { get; }


        public Group(Data.Model.Group group)
        {
            this.group = group;

            counters = new Lazy<IEnumerable<ICounter>>(() => this.group.Counters.Select(x => new Counter(x)));
            groups = new Lazy<IEnumerable<IGroup>>(() => this.group.Groups.Select(x => new Group(x)));
        }

        public Guid Id => this.group.Id;

        public Guid? CounterGroupId => this.group.CounterGroupId;

        public String Name => this.group.Name;

        public String IconName => this.group.IconName;

        public IEnumerable<ICounter> Counters => counters.Value;

        public IEnumerable<IGroup> Groups => groups.Value;
    }
}
