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
                            GenCounter(counterGroupId, "#bd34b9", "bi-dice-3", "Карма"),
                            GenCounter(counterGroupId, "#d82b37", "bi-arrow-through-heart", "Любовь"),
                            GenCounter(counterGroupId, "#d2f589", "bi-bag", "Шопинг"),
                            GenCounter(counterGroupId, "#89d0f5", "bi-chat-left-dots", "Общение"),
                            GenCounter(counterGroupId, "#661919", "bi-cup-fill", "Чашек кофе"),
                            GenCounter(counterGroupId, "#9da312", "bi-lightning-charge", "Сила"),
                            GenCounter(counterGroupId, "#12F300", "bi-mortarboard", "Интелект"),
                            GenCounter(counterGroupId, "#107380", "bi-palette", "Вдохновение"),
                            GenCounter(counterGroupId, "#0f2780", "bi-journal-bookmark", "Занятий"),
                            GenCounter(counterGroupId, "#1200FF", "bi-piggy-bank", "Что-то"),
                            GenCounter(counterGroupId, "#00FFFF", "bi-person-video", "Бла бла"),
                            GenCounter(counterGroupId, "#0FFF00", "bi-map-fill", "asdfqwe dsa 123"),
                            GenCounter(counterGroupId, "#0000FF", "bi-key", "ыфв1"),
                            GenCounter(counterGroupId, "#00FF00", "bi-graph-down", "ASd"),
                        }
                    });
            }

            this.CounterGroups.AddRange(counterGroups);
            this.SaveChanges();

            Data.Model.Counter GenCounter(Guid counterGroupId, string color, string iconName, string name) => new Data.Model.Counter()
            {
                Id = Guid.NewGuid(),
                CounterGroupId = counterGroupId,
                Value = 1,
                Name = name,
                IconName = iconName,
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
