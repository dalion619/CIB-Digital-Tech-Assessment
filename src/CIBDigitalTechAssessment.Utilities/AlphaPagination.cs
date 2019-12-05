using System;

namespace CIBDigitalTechAssessment.Utilities
{
    public static partial class AlphaPagination
    {
        public static char[] AlphaArray => "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public static string PageNumberToLetters(int pageNumber)
        {
            var numberPattern = pageNumber.ToString("D4");
            var primary = numberPattern.Substring(0, 2);
            var secondary = numberPattern.Substring(2, 2);

            var primaryNumber = -1;
            var secondaryNumber = -1;
            if (Int32.TryParse(primary, out primaryNumber) && Int32.TryParse(secondary, out secondaryNumber))
            {
                if (primaryNumber == 0)
                {
                    return $"{AlphaArray[secondaryNumber - 1]}";
                }

                if (secondaryNumber == 0)
                {
                    return $"{AlphaArray[primaryNumber - 1]}";
                }

                return $"{AlphaArray[primaryNumber - 1]}{AlphaArray[secondaryNumber - 1]}";
            }

            return string.Empty;
        }

        public static int LettersToPageNumber(string letters)
        {
            var letterArray = letters.ToUpper().ToCharArray();
            if (letterArray.Length ==2)
            {
                var primary = Array.IndexOf(AlphaArray, letterArray[0]);
                var secondary = Array.IndexOf(AlphaArray, letterArray[1]);
                
                return ((primary+1) * 100) + secondary+1;
            }
            else
            {
                var secondary = Array.IndexOf(AlphaArray,  letterArray[0]);
                return secondary+1;
            } 
        }

       
    }
}