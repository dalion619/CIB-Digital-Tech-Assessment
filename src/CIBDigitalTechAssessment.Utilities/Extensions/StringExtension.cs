using System;
using System.Linq;

namespace CIBDigitalTechAssessment.Utilities.Extensions
{
    public static partial class StringExtension
    {
        /// <summary>
        /// Removes non digits.
        /// </summary>
        /// <param name="str">String to sanitize.</param>
        public static string RemoveNonDigits(this string str) =>
            $"{new string(Array.FindAll(str.ToArray(), c => (char.IsDigit(c))))}";

        /// <summary>
        /// Removes non letters or digits.
        /// </summary>
        /// <param name="str">String to sanitize.</param>
        public static string RemoveNonLettersOrDigits(this string str) =>
            $"{new string(Array.FindAll(str.ToArray(), c => (char.IsLetterOrDigit(c))))}";
    }
}