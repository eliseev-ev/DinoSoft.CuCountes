using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinoSoft.CuCounters.Data.Model;

namespace DinoSoft.CuCounters.Domain.Model
{
    /// <summary>
    /// Группа.
    /// </summary>
    public class Group
    {
        private readonly Data.Model.CounterGroup counterGroup;

        private Lazy<IEnumerable<Counter>> counters;

        private Lazy<IEnumerable<Group>> groups;

        /// <summary>
        /// Конструктор группы.
        /// </summary>
        /// <param name="counterGroup"></param>
        public Group(Data.Model.CounterGroup counterGroup)
        {
            this.counterGroup = counterGroup;

            counters = new Lazy<IEnumerable<Counter>>(() => this.counterGroup.Counters.Select(x => new Counter(x)));
            groups = new Lazy<IEnumerable<Group>>(() => this.counterGroup.CounterGroups.Select(x => new Group(x)));
        }

        /// <summary>
        /// Идентифкатор.
        /// </summary>
        public Guid Id => this.counterGroup.Id;

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name => this.counterGroup.Name;

        /// <summary>
        /// Имя иконтки.
        /// </summary>
        public string IconName => this.counterGroup.IconName;

        /// <summary>
        /// Счетчики.
        /// </summary>
        public IEnumerable<Counter> Counters => counters.Value;

        /// <summary>
        /// Грууппы.
        /// </summary>
        public IEnumerable<Group> Groups => groups.Value;
    }
}
