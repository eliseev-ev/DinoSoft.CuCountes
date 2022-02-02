namespace DinoSoft.CuCounters.Data.Model
{
    public class Counter
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
                    Value = 5,
                    ActionType = CounterActionType.Add
                },
                new CounterAction()
                {
                    Id = Guid.NewGuid(),
                    Value = 1,
                    ActionType = CounterActionType.Sub
                }
            };
        }

        public Guid Id { get; set; }
        public int SortOrder { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public DateTime? LastUpdated { get; set; }
        public List<CounterAction> CounterActions { get; set; }
    }
}