namespace DinoSoft.CuCounters.Data.Model
{
    public class MainData
    {
        int sortOrder = 0;
        public IList<Counter> Counters => new List<Counter>()
        {
            new Counter()
            {
                Name = $"Карма",
                Value = 1,
                Id = Guid.NewGuid(),
                SortOrder = sortOrder++,
            },
            new Counter()
            {
                Name = $"Сила",
                Value = 1,
                Id = Guid.NewGuid(),
                SortOrder = sortOrder++,
            },
            new Counter()
            {
                Name = $"Здоровье",
                Value = 1,
                Id = Guid.NewGuid(),
                SortOrder = sortOrder++,
            },
            new Counter()
            {
                Name = $"Харизма",
                Value = 1,
                Id = Guid.NewGuid(),
                SortOrder = sortOrder++,
            },
            new Counter()
            {
                Name = $"Ум",
                Value = 1,
                Id = Guid.NewGuid(),
                SortOrder = sortOrder++,
            },
            new Counter()
            {
                Name = $"Мозг",
                Value = 1,
                Id = Guid.NewGuid(),
                SortOrder = sortOrder++,
            },
            new Counter()
            {
                Name = $"counter {sortOrder}",
                Value = 1,
                Id = Guid.NewGuid(),
                SortOrder = sortOrder++,
            },
            new Counter()
            {
                Name = $"counter {sortOrder}",
                Value = 1,
                Id = Guid.NewGuid(),
                SortOrder = sortOrder++,
            },
            new Counter()
            {
                Name = $"counter {sortOrder}",
                Value = 1,
                Id = Guid.NewGuid(),
                SortOrder = sortOrder++,
            },
            new Counter()
            {
                Name = $"counter {sortOrder}",
                Value = 1,
                Id = Guid.NewGuid(),
                SortOrder = sortOrder++,
            },
        };
    }
}