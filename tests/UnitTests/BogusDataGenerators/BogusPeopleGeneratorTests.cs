 
using TestData;
using Xunit;

namespace UnitTests.BogusDataGenerators
{
    public class BogusPeopleGeneratorTests
    {
        [Fact]
        public void Has100ValidItems()
        {
            var people = BogusPeopleGenerator.GenerateBogusPeople(100);
            Assert.Equal(expected: 100, actual: people.Count);
 
        }
    }
}