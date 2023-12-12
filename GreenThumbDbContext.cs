using GreenThumb.models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;
namespace GreenThumb.Data
{
    public class GreenThumbDbContext : DbContext
    {
        public GreenThumbDbContext()
        {
        }

        public DbSet<Plantmodel> Plants { get; set; }
        public DbSet<InstructionModel> Instructions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenThumbDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Plantmodel>().HasData(
                new Plantmodel
                {
                    Id = 1,
                    Name = "Rose"
                },
                new Plantmodel
                {
                    Id = 2,
                    Name = "Mary"
                },
                new Plantmodel
                {
                    Id = 3,
                    Name = "Sofie"
                },
                new Plantmodel
                {
                    Id = 4,
                    Name = "Coli"
                },
                new Plantmodel
                {
                    Id = 5,
                    Name = "Sigo"
                },
                new Plantmodel
                {
                    Id = 6,
                    Name = "Mowi"
                },
                new Plantmodel
                {
                    Id = 7,
                    Name = "Loke"
                },
                new Plantmodel
                {
                    Id = 8,
                    Name = "Sunny"
                },
                new Plantmodel
                {
                    Id = 9,
                    Name = "Alice"
                },
                new Plantmodel
                {
                    Id = 10,
                    Name = "Sensei"
                },
                new Plantmodel
                {
                    Id = 11,
                    Name = "Mason"
                },
                new Plantmodel
                {
                    Id = 12,
                    Name = "Oxie"
                },
                new Plantmodel
                {
                    Id = 13,
                    Name = "shaie"
                });

            modelBuilder.Entity<InstructionModel>().HasData(
                new InstructionModel
                {
                    Id = 1,
                    Name = "Give water to plant",
                    PlantId = 1,
                },
                new InstructionModel
                {
                    Id = 2,
                    Name = "Give water to plant",
                    PlantId = 2,
                },
                new InstructionModel
                {
                    Id = 3,
                    Name = "Give water to plant",
                    PlantId = 3,
                },
                new InstructionModel()
                {
                    Id = 4,
                    Name = "Give water to plant",
                    PlantId = 4,
                },
                 new InstructionModel()
                 {
                     Id = 5,
                     Name = "Give water to plant",
                     PlantId = 5,
                 },
                 new InstructionModel()
                 {
                     Id = 6,
                     Name = "Give water to plant",
                     PlantId = 6,
                 },
                 new InstructionModel()
                 {
                     Id = 7,
                     Name = "Give water to plant",
                     PlantId = 7,
                 },
                 new InstructionModel()
                 {
                     Id = 8,
                     Name = "Place in direct sunlight",
                     PlantId = 8,

                 },
                 new InstructionModel()
                 {
                     Id = 9,
                     Name = "Place in direct sunlight",
                     PlantId = 9,
                 },
                 new InstructionModel()
                 {
                     Id = 10,
                     Name = "Place in direct sunlight",
                     PlantId = 10,
                 },
                 new InstructionModel()
                 {
                     Id = 11,
                     Name = "Place in direct sunlight",
                     PlantId = 11,
                 },
                 new InstructionModel()
                 {
                     Id = 12,
                     Name = "Place in direct sunlight",
                     PlantId = 12,
                 },
                 new InstructionModel()
                 {
                     Id = 13,
                     Name = "Place in direct sunlight",
                     PlantId = 1,
                
                 });







        }
    }

    

}
