using System.Collections.Generic;
using Bogus;
using CIBDigitalTechAssessment.ViewModels.BogusData;

namespace TestData
{
    public static partial class BogusPeopleGenerator
    {
        public static List<BogusPersonViewModel> GenerateBogusPeople(int count = 100)
        {
            var peopleFaker = new Faker<BogusPersonViewModel>()
                              .RuleFor(property: u => u.FirstName, setter: (f, u) => f.Person.FirstName)
                              .RuleFor(property: u => u.LastName, setter: (f, u) => f.Person.LastName)
                              .RuleFor(property: u => u.PhoneNumber, setter: (f, u) =>
                              {
                                  f.Phone.Locale = "en_ZA";
                                  return f.Phone.PhoneNumberFormat();
                              });
            peopleFaker.Locale = "en_ZA";
            return peopleFaker.Generate(count); 
        }
    }
}