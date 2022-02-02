using DinoSoft.CuCounters.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoSoft.CuCounters.Domain.Model
{
    public class MainData
    {
        public List<Counter> Counters { get; }
        
        public MainData(Data.Model.MainData mainData)
        {
            this.Counters = mainData.Counters.Select(x => new Counter(x)).ToList();
        }
    }
}
