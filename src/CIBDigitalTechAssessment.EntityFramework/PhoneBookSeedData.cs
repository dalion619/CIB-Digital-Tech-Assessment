using System.Linq;
using System.Threading.Tasks;
using CIBDigitalTechAssessment.Entities;
using Microsoft.EntityFrameworkCore;
using TestData;

namespace CIBDigitalTechAssessment.EntityFramework
{
    public static partial class PhoneBookSeedData
    {
        public static async Task Seed(PhoneBookDbContext db)
        {
            var people = BogusPeopleGenerator.GenerateBogusPeople(100);
            var newRecords = people.Select(s => new PhoneBookEntry()
                                                {
                                                    PhoneNumber = s.PhoneNumber,
                                                    Description = "Office",
                                                    Person = new Person()
                                                             {
                                                                 FirstName = s.FirstName,
                                                                 LastName = s.LastName
                                                             }
                                                }).ToList();
            await db.PhoneBookEntries.AddRangeAsync(newRecords); 
            var successCount = await db.SaveChangesAsync();
        }
    }
}