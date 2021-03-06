using DinoSoft.CuCounters.Domain.Contracts.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel = DinoSoft.CuCounters.Data.Contracts.Model;

namespace DinoSoft.CuCounters.Domain.Model
{
    internal class Counter : ICounter
    {
        private readonly DataModel.Counter counter;

        public Counter(DataModel.Counter counter)
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

        [Required]
        [StringLength(30, ErrorMessage = "Name is too long.")]
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

        [Required]
        [Range(-999999, 999999, ErrorMessage = "Accommodation invalid (-999999-999999).")]
        public int Value
        {
            get => this.counter.Value;
            set => this.counter.Value = value;
        }

        public DateTime? LastUpdated => counter.LastUpdated;

        public List<DataModel.CounterAction> CounterAction => counter.CounterActions;

        public void Act(Guid actionId)
        {
            // Нужно сделать домменую модель counterAction
            var action = counter.CounterActions.First(x => x.Id == actionId);
            if (action.ActionType == DataModel.CounterActionType.Add)
            {
                AddValue(action.Value);
            }
            else
            {
                AddValue(-action.Value);
            }
            this.counter.LastUpdated = DateTime.Now;
        }

        [Obsolete("Сделать приватным, дырка - для теста")]
        public void AddValue(int value)
        {
            this.counter.Value += value;
            this.counter.LastUpdated = DateTime.Now;
        }
    }
}
