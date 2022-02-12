using DinoSoft.CuCounters.Data.Infrastructure;
using DinoSoft.CuCounters.Domain.Model;

namespace DinoSoft.CuCounters.Domain.Infrastructure
{
    public class DataManager
    {
        private readonly DataContextProvider dataContextRepository;
        private Data.Model.DataContext dataContext;

        public DataManager(DataContextProvider dataContextRepository)
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
                        IconColor = "#0000FF",
                        Counters = new List<Data.Model.Counter>()
                        {
                            GenCounter(counterGroupId, "#00FF00"),
                            GenCounter(counterGroupId, "#0000FF"),
                            GenCounter(counterGroupId, "#00FFFF"),
                            GenCounter(counterGroupId, "#FFFF00"),
                            GenCounter(counterGroupId, "#FFF000"),
                            GenCounter(counterGroupId, "#F00F00"),
                            GenCounter(counterGroupId, "#12F300"),
                            GenCounter(counterGroupId, "#1200FF"),
                            GenCounter(counterGroupId, "#00FFFF"),
                            GenCounter(counterGroupId, "#F0F0F0"),
                            GenCounter(counterGroupId, "#0FFF00"),
                            GenCounter(counterGroupId, "#0000FF"),
                            GenCounter(counterGroupId, "#00FF00"),
                            GenCounter(counterGroupId, "#00FF00"),
                        }
                    });
            }

            Data.Model.Counter GenCounter(Guid counterGroupId, string color) => new Data.Model.Counter()
            {
                Id = Guid.NewGuid(),
                CounterGroupId = counterGroupId,
                Value = 1,
                Name = $"Карма",
                IconName = "bi-diamond",
                IconColor = color,
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
