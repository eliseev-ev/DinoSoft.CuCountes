using Microsoft.EntityFrameworkCore;
using DinoSoft.CuCounters.Data.Contracts.Model;

namespace DinoSoft.CuCounters.Data.Infrastructure
{
    internal class DataContext : DbContext
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
            var counterGroups = new List<Group>();

            counterGroups.Add(
                new Group
                {
                    Name = $"Папка 1",
                    Id = Guid.NewGuid(),
                    IconName = "bi-diamond",
                    IconColor = "#0000FF",
                    Counters = new List<Counter>()
                    {
                        CreateCounter("#bd34b9", "bi-dice-3", "Карма"),
                        CreateCounter("#d82b37", "bi-arrow-through-heart", "Любовь"),
                        CreateCounter("#d2f589", "bi-bag", "Шопинг"),
                        CreateCounter("#89d0f5", "bi-chat-left-dots", "Общение"),
                        CreateCounter("#661919", "bi-cup-fill", "Чашек кофе"),                  
                    },
                    Groups = new List<Group>
                    {
                        new Group
                        {
                            Name = $"Подпапка",
                            Id = Guid.NewGuid(),
                            IconName = "bi-diamond",
                            IconColor = "#0000FF",
                            Counters = new List<Counter>()
                            {
                                CreateCounter("#9da312", "bi-lightning-charge", "Сила"),
                                CreateCounter("#12F300", "bi-mortarboard", "Интелект"),
                                CreateCounter("#107380", "bi-palette", "Вдохновение"),
                                CreateCounter("#0f2780", "bi-journal-bookmark", "Занятий"),
                            },
                            Groups = new List<Group>()
                        }
                    }
                });
            

            this.CounterGroups.AddRange(counterGroups);
            this.SaveChanges();

            Counter CreateCounter(string color, string iconName, string name) => new Counter()
            {
                Id = Guid.NewGuid(),
                Value = 1,
                Name = name,
                IconName = iconName,
                IconColor = color,
                SortOrder = 0,
                CounterActions = new List<CounterAction>
                {
                    new CounterAction()
                    {
                        Id = Guid.NewGuid(),
                        Value = 1,
                        ActionType = CounterActionType.Add
                    },
                    new CounterAction()
                    {
                        Id = Guid.NewGuid(),
                        Value = 5,
                        ActionType = CounterActionType.Add
                    },
                    new CounterAction()
                    {
                        Id = Guid.NewGuid(),
                        Value = 1,
                        ActionType = CounterActionType.Sub
                    }
                }
            };
        }
    }
}
