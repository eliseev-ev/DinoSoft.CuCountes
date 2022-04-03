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
            // Ждем когда заработает sqlite на maui
            //string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "entities.db3");
            //optionsBuilder
            //    .UseSqlite($"Filename={dbPath}");
            optionsBuilder.UseInMemoryDatabase("db");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .HasMany(x => x.Groups)
                .WithOne()
                .HasForeignKey(x => x.CounterGroupId);

            modelBuilder.Entity<Group>()
                .HasMany(x => x.Counters)
                .WithOne()
                .HasForeignKey(x => x.CounterGroupId);
        }

        public DbSet<Group> CounterGroups { get; set; }

        public DbSet<Counter> Counters { get; set; }

        public DbSet<CounterAction> CounterActions { get; set; }



        private void Populate()
        {
            var counterGroups = new List<Data.Model.Group>();

            counterGroups.Add(
                new Data.Model.Group
                {
                    Name = $"Папка 1",
                    Id = Guid.NewGuid(),
                    IconName = "bi-diamond",
                    IconColor = "#0000FF",
                    Counters = new List<Data.Model.Counter>()
                    {
                        GenCounter("#bd34b9", "bi-dice-3", "Карма"),
                        GenCounter("#d82b37", "bi-arrow-through-heart", "Любовь"),
                        GenCounter("#d2f589", "bi-bag", "Шопинг"),
                        GenCounter("#89d0f5", "bi-chat-left-dots", "Общение"),
                        GenCounter("#661919", "bi-cup-fill", "Чашек кофе"),                  
                    },
                    Groups = new List<Group>
                    {
                        new Data.Model.Group
                        {
                            Name = $"Подпапка",
                            Id = Guid.NewGuid(),
                            IconName = "bi-diamond",
                            IconColor = "#0000FF",
                            Counters = new List<Data.Model.Counter>()
                            {
                                GenCounter("#9da312", "bi-lightning-charge", "Сила"),
                                GenCounter("#12F300", "bi-mortarboard", "Интелект"),
                                GenCounter("#107380", "bi-palette", "Вдохновение"),
                                GenCounter("#0f2780", "bi-journal-bookmark", "Занятий"),
                            },
                            Groups = new List<Group>()
                        }
                    }
                });
            

            this.CounterGroups.AddRange(counterGroups);
            this.SaveChanges();

            Data.Model.Counter GenCounter(string color, string iconName, string name) => new Data.Model.Counter()
            {
                Id = Guid.NewGuid(),
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
