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
            // todo: DataContext init
            //dataContext = InitAndSaveTestDataContext();

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

        private Data.Model.DataContext InitAndSaveTestDataContext()
        {
            dataContext = new Data.Model.DataContext()
            {
                CounterGroups = new List<Data.Model.CounterGroup>()
            };

            for (int i = 0; i < 10; i++)
            {
                var counterGroupId = Guid.NewGuid();
                dataContext.CounterGroups.Add(
                    new Data.Model.CounterGroup
                    {
                        Name = $"Карма",
                        Id = counterGroupId,
                        IconName = "bi-diamond",
                        Counters = new List<Data.Model.Counter>()
                        {
                            GenCounter(counterGroupId),
                            GenCounter(counterGroupId),
                            GenCounter(counterGroupId),
                            GenCounter(counterGroupId),
                            GenCounter(counterGroupId),
                            GenCounter(counterGroupId),
                            GenCounter(counterGroupId),
                            GenCounter(counterGroupId),
                            GenCounter(counterGroupId),
                            GenCounter(counterGroupId),
                            GenCounter(counterGroupId),
                            GenCounter(counterGroupId),
                            GenCounter(counterGroupId),
                            GenCounter(counterGroupId),
                        }
                    });
            }

            Data.Model.Counter GenCounter(Guid counterGroupId) => new Data.Model.Counter()
            {
                Id = Guid.NewGuid(),
                CounterGroupId = counterGroupId,
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
            SaveCurrent();
            return dataContext;
        }
    }
}
