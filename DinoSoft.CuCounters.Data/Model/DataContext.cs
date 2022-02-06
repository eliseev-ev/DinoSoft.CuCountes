using DinoSoft.CuCounters.Common.Extensions;
using DinoSoft.CuCounters.Data.Infrastructure;
using DinoSoft.CuCounters.Data.Infrastructure.Model;

namespace DinoSoft.CuCounters.Data.Model
{
    public class DataContext : IdNameModel
    {
        public DataContext()
        {
            Populate();
        }

        public List<CounterGroup> CounterGroups { get; set; }


        private void Populate()
        {
            CounterGroups = new List<CounterGroup>();

            for (int i = 0; i < 10; i++)
            {
                CounterGroups.Add(
                    new CounterGroup
                    {
                        Name = $"Карма",
                        Id = Guid.NewGuid(),
                        IconName = "bi-diamond",
                        Counters = new List<Counter>()
                        {
                            GenCounter(),
                            GenCounter(),
                            GenCounter(),
                            GenCounter(),
                            GenCounter(),
                            GenCounter(),
                            GenCounter(),
                            GenCounter(),
                            GenCounter(),
                            GenCounter(),
                            GenCounter(),
                            GenCounter(),
                            GenCounter(),
                            GenCounter(),
                        }
                    });
                }

            Counter GenCounter() => new Counter()
            {
                Id = Guid.NewGuid(),
                Value = 1,
                Name = $"Карма",
                IconName = "bi-diamond",
                SortOrder = 0,
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
                }
            };
        }
    }
}