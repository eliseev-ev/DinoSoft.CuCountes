using DinoSoft.CuCounters.Data.Infrastructure.Model;

namespace DinoSoft.CuCounters.Data.Model
{
    public class CounterGroup : IdNameModel
    {
        public int SortOrder { get; set; }

        /// <summary> Имя иконки. </summary>
        public string IconName { get; set; }

        public new List<Counter> Counters { get; set; }
        
    }
}