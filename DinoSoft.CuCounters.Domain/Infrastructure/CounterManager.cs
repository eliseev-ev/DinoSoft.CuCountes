using DinoSoft.CuCounters.Data.Repository;
using DinoSoft.CuCounters.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoSoft.CuCounters.Domain.Infrastructure
{
    public class MainDataManager
    {
        private readonly MainRepository mainRepository;

        public MainDataManager()
        {
            this.mainRepository = new MainRepository();
        }

        public MainData Get()
        {
            var data = mainRepository.GetMainData();
            return new MainData(data);
        }
    }
}
