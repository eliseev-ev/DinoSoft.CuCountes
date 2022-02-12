using DinoSoft.CuCounters.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoSoft.CuCounters.Domain.Model
{
    public class Counter
    {
        private readonly Data.Model.Counter counter;

        public Counter(Data.Model.Counter counter)
        {
            this.counter = counter;
        }

        public Guid Id => counter.Id;
        public Guid CounterGroupId => counter.CounterGroupId;

        public int SortOrder
        {
            get => this.counter.SortOrder;
            set => this.counter.SortOrder = value;
        }

        public string Name
        {
            get => this.counter.Name;
            set => this.counter.Name = value;
        }

        public string IconName
        {
            get => this.counter.IconName;
            set => this.counter.IconName = value;
        }

        public string IconColor
        {
            get => this.counter.IconColor;
            set => this.counter.IconColor = value;
        }

        public int Value
        {
            get => this.counter.Value;
            set => this.counter.Value = value;
        }

        public DateTime? LastUpdated => counter.LastUpdated;

        public List<CounterAction> CounterAction => counter.CounterActions;

        public void Act(Guid actionId)
        {
            // Нужно сделать домменую модель counterAction
            var action = counter.CounterActions.First(x => x.Id == actionId);
            if (action.ActionType == Data.Model.CounterActionType.Add)
            {
                AddValue(action.Value);
            }
            else
            {
                AddValue(-action.Value);
            }
            this.counter.LastUpdated = DateTime.Now;
        }

        [Obsolete("Сделать приватным, дырка, для теста")]
        public void AddValue(int value)
        {
            this.counter.Value += value;
            this.counter.LastUpdated = DateTime.Now;
        }
    }
}
