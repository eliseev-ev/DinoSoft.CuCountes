namespace DinoSoft.CuCounters.Data.Model
{
    public class MainData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        private int sortOrder = 0;

        public IList<Counter> Counters { get; set; } = new List<Counter>()
        {
            new Counter()
            {
                Name = $"Карма",
                Value = 1,
                Id = Guid.NewGuid(),
                SortOrder = 0
            },
            new Counter()
            {
                Name = $"Сила",
                Value = 1,
                Id = Guid.NewGuid(),
                SortOrder = 0,
            },
            new Counter()
            {
                Name = $"Здоровье",
                Value = 1,
                Id = Guid.NewGuid(),
                SortOrder = 0,
            },
            new Counter()
            {
                Name = $"Харизма",
                Value = 1,
                Id = Guid.NewGuid(),
                SortOrder = 0,
            },
            new Counter()
            {
                Name = $"Ум",
                Value = 1,
                Id = Guid.NewGuid(),
                SortOrder = 0,
            },
            new Counter()
            {
                Name = $"Мозг",
                Value = 1,
                Id = Guid.NewGuid(),
                SortOrder = 0,
            },
            new Counter()
            {
                Name = $"counter ",
                Value = 1,
                Id = Guid.NewGuid(),
                SortOrder = 0,
            },
            new Counter()
            {
                Name = $"counter",
                Value = 1,
                Id = Guid.NewGuid(),
                SortOrder = 0,
            },
            new Counter()
            {
                Name = $"counter",
                Value = 1,
                Id = Guid.NewGuid(),
                SortOrder = 1,
            },
            new Counter()
            {
                Name = $"counter",
                Value = 1,
                Id = Guid.NewGuid(),
                SortOrder = 2,
            },
        };
    }
}