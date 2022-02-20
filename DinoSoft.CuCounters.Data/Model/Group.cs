﻿using DinoSoft.CuCounters.Data.Common.Model;

namespace DinoSoft.CuCounters.Data.Model
{
    public class Group : IdNameModel
    {
        public int SortOrder { get; set; }

        /// <summary> Имя иконки. </summary>
        public string IconName { get; set; }

        /// <summary> Имя Цвет. </summary>
        public string IconColor { get; set; } = "#112233";

        public Guid? CounterGroupId { get; set; }

        public List<Group> Groups { get; set; }

        public List<Counter> Counters { get; set; }
        
    }
}