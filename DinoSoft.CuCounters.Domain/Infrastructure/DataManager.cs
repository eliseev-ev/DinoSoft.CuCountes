using DinoSoft.CuCounters.Data.Infrastructure;
using DinoSoft.CuCounters.Domain.Model;

namespace DinoSoft.CuCounters.Domain.Infrastructure
{
    public class DataManager
    {
        private readonly DataContextRepository dataContextRepository;
        private Data.Model.DataContext dataContext;

        public DataManager(DataContextRepository dataContextRepository)
        {
            this.dataContextRepository = dataContextRepository;
        }

        public IEnumerable<CounterGroup> GetCounterGroups()
        {
            //dataContext = GenerateTestDataContext();
            dataContext = dataContextRepository.DataContext;
            return dataContext.CounterGroups.Select(x => new CounterGroup(x));
        }

        public void SaveCurrent()
        {
            if (dataContext != null)
            {
                dataContextRepository.Save(dataContext);
            }
        }

        private Data.Model.DataContext GenerateTestDataContext()
        {
            var dataContext = new Data.Model.DataContext()
            {
                CounterGroups = new List<Data.Model.CounterGroup>()
            };

            for (int i = 0; i < 10; i++)
            {
                dataContext.CounterGroups.Add(
                    new Data.Model.CounterGroup
                    {
                        Name = $"Карма",
                        Id = Guid.NewGuid(),
                        IconName = "bi-diamond",
                        Counters = new List<Data.Model.Counter>()
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

            Data.Model.Counter GenCounter() => new Data.Model.Counter()
            {
                Id = Guid.NewGuid(),
                Value = 1,
                Name = $"Карма",
                IconName = "bi-diamond",
                SortOrder = 0,
                CounterActions = new List<Data.Model.CounterAction>
                {
                    new Data.Model.CounterAction()
                    {
                        Id = Guid.NewGuid(),
                        Value = 1,
                        ActionType = Data.Model.CounterActionType.Add
                    },
                    new Data.Model.CounterAction()
                    {
                        Id = Guid.NewGuid(),
                        Value = 5,
                        ActionType = Data.Model.CounterActionType.Add
                    },
                    new Data.Model.CounterAction()
                    {
                        Id = Guid.NewGuid(),
                        Value = 1,
                        ActionType = Data.Model.CounterActionType.Sub
                    }
                }
            };

            return dataContext;
        }
    }
}
