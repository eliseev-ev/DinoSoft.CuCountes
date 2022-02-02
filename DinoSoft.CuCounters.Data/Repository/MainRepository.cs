using DinoSoft.CuCounters.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoSoft.CuCounters.Data.Repository
{
    public class MainRepository
    {
        public MainData GetMainData()
        {
            return new MainData();
        }
    }
}
