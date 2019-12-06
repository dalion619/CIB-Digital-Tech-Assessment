using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CIBDigitalTechAssessment.Utilities.Extensions
{
    public static partial class StringExtension
    {
        /// <summary>
        /// Removes extra white space.
        /// </summary>
        /// <param name="str">String to sanitize.</param>
        public static string RemoveExtraWhiteSpace(this string str)
        {
            return Regex.Replace(str,  @"\s+", " ", RegexOptions.Compiled);
        }
        
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
        
        /// <summary>
        /// Removes special characters.
        /// </summary>
        /// <param name="str">String to sanitize.</param>
        public static string Normalise(this string phrase)
        {
            string str = phrase.RemoveDiacritics().ToLower();
            // invalid chars
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "", RegexOptions.Compiled);
            // convert multiple spaces into one space
            str = Regex.Replace(str, @"\s+", " ", RegexOptions.Compiled).Trim();
            return str;
        }
        
        public static string RemoveDiacritics(this string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "":   throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default:   return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }
}