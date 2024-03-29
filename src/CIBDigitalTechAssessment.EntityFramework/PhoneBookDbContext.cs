using CIBDigitalTechAssessment.Abstractions.Bases;
using CIBDigitalTechAssessment.Entities;
using CIBDigitalTechAssessment.EntityFramework.Views;
using CIBDigitalTechAssessment.Views;
using Microsoft.EntityFrameworkCore;

namespace CIBDigitalTechAssessment.EntityFramework
{
    public class PhoneBookDbContext: DbContext
    {
        // Required for DBContext pooling.
        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options)
            : base(options)
        {
        }
        
        // Required when using ef through the command-line.
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
        
        public DbSet<ViewPhoneBookEntries> ViewPhoneBookEntries { get; set; }
        
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
            
            // Keyless entities aka database views
            modelBuilder
                .Entity<ViewPhoneBookEntries>(eb =>
                {
                    eb.HasNoKey();
                    eb.ToView($"{nameof(view_PhoneBookEntries)}");
                });
            
            
        }
    }
}