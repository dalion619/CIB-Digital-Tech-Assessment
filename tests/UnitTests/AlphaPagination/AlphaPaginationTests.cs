using Xunit;

namespace UnitTests.AlphaPagination
{
    public class AlphaPaginationTests
    {
        [Fact]
        public void ValidPageNumberForA()
        {
            
            var number = CIBDigitalTechAssessment.Utilities.AlphaPagination.LettersToPageNumber("A");
            Assert.Equal(expected: 1, actual: number);
 
        }
        
        [Fact]
        public void ValidPageNumberForAA()
        {
            
            var number = CIBDigitalTechAssessment.Utilities.AlphaPagination.LettersToPageNumber("AA");
            Assert.Equal(expected: 101, actual: number);
 
        }
    }
}