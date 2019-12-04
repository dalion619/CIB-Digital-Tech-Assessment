using CIBDigitalTechAssessment.Abstractions.Bases;
using CIBDigitalTechAssessment.Entities;
using Microsoft.EntityFrameworkCore;

namespace CIBDigitalTechAssessment.EntityFramework
{
    public class PhoneBookDbContext: DbContext
    {
        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options)
            : base(options)
        {
        }
        
        // public PhoneBookDbContext()
        // {
        //     
        // }
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer(
        //         connectionString:
        //         "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=local-phonebook-db;Integrated Security=true;MultipleActiveResultSets=True;Connect Timeout=60;");
        // }
        
        public DbSet<Person> People { get; set; }
        public DbSet<PhoneBookEntry> PhoneBookEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<EntityBase>();
            base.OnModelCreating(modelBuilder: modelBuilder);
            // To support system-versioning temporal table support, DeleteBehavior.Restrict
            modelBuilder.Entity<PhoneBookEntry>()
                        .HasOne(navigationExpression: i => i.Person)
                        .WithMany(navigationExpression: c => c.PhoneBookEntries)
                        .IsRequired()
                        .OnDelete(deleteBehavior: DeleteBehavior.Restrict);
        }
    }
}