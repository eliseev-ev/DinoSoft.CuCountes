using DinoSoft.CuCounters.Data.Infrastructure.Model;

namespace DinoSoft.CuCounters.Data.Model
{
    public class Counter : IdNameModel
    {
        public Counter()
        {
            CounterActions = new List<CounterAction>
            {
                new CounterAction()
                {
                    Id = Guid.NewGuid(),
                    Value = 1,
                    ActionType = CounterActionType.Add
                },
                new CounterAction()
                {
                    Id = Guid.NewGuid(),
                    Value = 1,
                    ActionType = CounterActionType.Sub
                },
                new CounterAction()
                {
                    Id = Guid.NewGuid(),
                    Value = 10,
                    ActionType = CounterActionType.Add
                },
                new CounterAction()
                {
                    Id = Guid.NewGuid(),
                    Value = 10,
                    ActionType = CounterActionType.Sub
                }
            };
        }

        public int SortOrder { get; set; }

        public int Value { get; set; }
        
        /// <summary> Имя иконки. </summary>
        public string IconName { get; set; }

        /// <summary> Имя Цвет. </summary>
        public string IconColor { get; set; } = "#112233";

        public DateTime? LastUpdated { get; set; }

        public List<CounterAction> CounterActions { get; set; }
        
        public Guid CounterGroupId { get; set; }
    }
}