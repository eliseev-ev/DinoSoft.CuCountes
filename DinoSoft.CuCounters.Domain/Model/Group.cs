using DinoSoft.CuCounters.Domain.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel = DinoSoft.CuCounters.Data.Contracts.Model;

namespace DinoSoft.CuCounters.Domain.Model
{
    internal class Group : IGroup
    {
        private readonly DataModel.Group group;
        private Lazy<IEnumerable<ICounter>> counters { get; }
        private Lazy<IEnumerable<IGroup>> groups { get; }


        public Group(DataModel.Group group)
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
