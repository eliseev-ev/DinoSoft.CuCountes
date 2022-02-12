using System.Text.Json;
using DinoSoft.CuCounters.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace DinoSoft.CuCounters.Data.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            //SQLitePCL.Batteries_V2.Init();
            //this.Database.EnsureCreated();

            if (this.Database.EnsureCreated())
            {
                Populate();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "entities.db3");
            //optionsBuilder
            //    .UseSqlite($"Filename={dbPath}");
            optionsBuilder.UseInMemoryDatabase("db");
        }

        public DbSet<CounterGroup> CounterGroups { get; set; }

        public DbSet<Counter> Counters { get; set; }

        public DbSet<CounterAction> CounterActions { get; set; }



        private void Populate()
        {
            var counterGroups = new List<Data.Model.CounterGroup>();

            for (int i = 0; i < 10; i++)
            {
                var counterGroupId = Guid.NewGuid();
                counterGroups.Add(
                    new Data.Model.CounterGroup
                    {
                        Name = $"Карма",
                        Id = counterGroupId,
                        IconName = "bi-diamond",
                        IconColor = "#0000FF",
                        Counters = new List<Data.Model.Counter>()
                        {
                            GenCounter(counterGroupId, "#00FF00"),
                            GenCounter(counterGroupId, "#0000FF"),
                            GenCounter(counterGroupId, "#00FFFF"),
                            GenCounter(counterGroupId, "#FFFF00"),
                            GenCounter(counterGroupId, "#FFF000"),
                            GenCounter(counterGroupId, "#F00F00"),
                            GenCounter(counterGroupId, "#12F300"),
                            GenCounter(counterGroupId, "#1200FF"),
                            GenCounter(counterGroupId, "#00FFFF"),
                            GenCounter(counterGroupId, "#F0F0F0"),
                            GenCounter(counterGroupId, "#0FFF00"),
                            GenCounter(counterGroupId, "#0000FF"),
                            GenCounter(counterGroupId, "#00FF00"),
                            GenCounter(counterGroupId, "#00FF00"),
                        }
                    });
            }

            this.CounterGroups.AddRange(counterGroups);
            this.SaveChanges();

            Data.Model.Counter GenCounter(Guid counterGroupId, string color) => new Data.Model.Counter()
            {
                Id = Guid.NewGuid(),
                CounterGroupId = counterGroupId,
                Value = 1,
                Name = $"Карма",
                IconName = "bi-diamond",
                IconColor = color,
                SortOrder = 0,
                CounterActions = new List<Data.Model.CounterAction>
                {
                    new Data.Model.CounterAction()
                    {
                        Id = Guid.NewGuid(),
                        Value = 1,
                        ActionType = Data.Model.CounterActionType.Add
                    },
                    new Data.Model.CounterAction()
                    {
                        Id = Guid.NewGuid(),
                        Value = 5,
                        ActionType = Data.Model.CounterActionType.Add
                    },
                    new Data.Model.CounterAction()
                    {
                        Id = Guid.NewGuid(),
                        Value = 1,
                        ActionType = Data.Model.CounterActionType.Sub
                    }
                }
            };
        }
    }
}
