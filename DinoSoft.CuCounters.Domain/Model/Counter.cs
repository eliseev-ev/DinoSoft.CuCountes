using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinoSoft.CuCounters.Data.Model;

namespace DinoSoft.CuCounters.Domain.Model
{
    /// <summary>
    /// Счетчик.
    /// </summary>
    public class Counter
    {
        private readonly Data.Model.Counter counter;

        /// <summary>
        /// Конструктор счетчика.
        /// </summary>
        /// <param name="counter"></param>
        public Counter(Data.Model.Counter counter)
        {
            this.counter = counter;
        }

        /// <summary>Идентификатор.</summary>
        public Guid Id => counter.Id;

        /// <summary>Идентификатор группы.</summary>
        public Guid CounterGroupId => counter.CounterGroupId;

        /// <summary>Порядок сортировки. </summary>
        public int SortOrder
        {
            get => this.counter.SortOrder;
            set => this.counter.SortOrder = value;
        }

        /// <summary>Имя.</summary>
        [Required]
        [StringLength(30, ErrorMessage = "Name is too long.")]
        public string Name
        {
            get => this.counter.Name;
            set => this.counter.Name = value;
        }

        /// <summary>Имя иконки.</summary>
        public string IconName
        {
            get => this.counter.IconName;
            set => this.counter.IconName = value;
        }

        /// <summary>Цвет иконки.</summary>
        public string IconColor
        {
            get => this.counter.IconColor;
            set => this.counter.IconColor = value;
        }

        /// <summary>Значение.</summary>
        [Required]
        [Range(-999999, 999999, ErrorMessage = "Accommodation invalid (-999999-999999).")]
        public int Value
        {
            get => this.counter.Value;
            set => this.counter.Value = value;
        }

        /// <summary>Последнее обновление. </summary>
        public DateTime? LastUpdated => counter.LastUpdated;

        /// <summary>Экшены счетчика.</summary>
        public List<CounterAction> CounterAction => counter.CounterActions;

        /// <summary>
        /// Применить действие.
        /// </summary>
        /// <param name="actionId"Идентификатор действия.></param>
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

        /// <summary>
        /// Добавить значение.
        /// </summary>
        /// <param name="value">Значение.</param>
        [Obsolete("Сделать приватным, дырка, для теста")]
        public void AddValue(int value)
        {
            this.counter.Value += value;
            this.counter.LastUpdated = DateTime.Now;
        }
    }
}
