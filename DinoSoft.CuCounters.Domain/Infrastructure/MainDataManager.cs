using DinoSoft.CuCounters.Data.Infrastructure;
using DinoSoft.CuCounters.Domain.Model;

namespace DinoSoft.CuCounters.Domain.Infrastructure
{
    public class MainDataManager
    {
        private readonly DataService dataService;
        private Data.Model.MainData currentMainData;

        public MainDataManager(DataService dataService)
        {
            this.dataService = dataService;
        }

        public MainData Get()
        {
            currentMainData = dataService.GetMainData();
            return new MainData(currentMainData);
        }

        public void SaveCurrent()
        {
            if (currentMainData != null)
            {
                dataService.SaveMainData(currentMainData);
            }
        }
    }
}
