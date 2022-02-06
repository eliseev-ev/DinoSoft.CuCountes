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
            dataContext = dataContextRepository.DataContext ;
            return dataContext.CounterGroups.Select(x => new CounterGroup(x));
        }

        public void SaveCurrent()
        {
            if (dataContext != null)
            {
                dataContextRepository.Save(dataContext);
            }
        }
    }
}
