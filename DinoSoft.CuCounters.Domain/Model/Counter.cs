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

        public int SortOrder
        {
            get => counter.SortOrder;
            set => counter.SortOrder = value;
        }

        public string Name
        {
            get => counter.Name;
            set => counter.Name = value;
        }

        public int Value
        {
            get => counter.Value;
        }

        public DateTime? LastUpdated => counter.LastUpdated;

        public List<CounterAction> CounterAction => counter.CounterActions;

        public void Act(Guid actionId)
        {
            // Нужно сделать домменую модель counterAction
            var action = counter.CounterActions.First(x => x.Id == actionId);
            if (action.ActionType == Data.Model.CounterActionType.Add)
            {
                this.counter.Value += action.Value;
            }
            else
            {
                this.counter.Value -= action.Value;
            }
            counter.LastUpdated = DateTime.Now;
        }

    }
}
