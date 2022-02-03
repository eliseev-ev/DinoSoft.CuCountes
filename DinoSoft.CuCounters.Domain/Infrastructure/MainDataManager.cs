using DinoSoft.CuCounters.Data.Repository;
using DinoSoft.CuCounters.Domain.Model;

namespace DinoSoft.CuCounters.Domain.Infrastructure
{
    public class MainDataManager
    {
        private readonly DataRepository mainRepository;

        private Data.Model.MainData currentMainData;

        public MainDataManager()
        {
            this.mainRepository = new DataRepository();
        }

        public MainData Get()
        {
            currentMainData = mainRepository.GetMainData();
            return new MainData(currentMainData);
        }

        public void SaveCurrent()
        {
            if (currentMainData != null)
            {
                mainRepository.SaveMainData(currentMainData);
            }
        }
    }
}
