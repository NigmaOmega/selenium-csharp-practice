using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SeleniumPractice
{
    public static class StringExtension
    {
        public static List<int> ExtractNumbers(this string input)
        {
            var result = Regex.Matches(input, @"\d+").OfType<Match>().Select(m => int.Parse(m.Value)).ToList();

            return result;
        }

        public static int ToInt(this string input)
        {
            return Int32.Parse(input);
        }
    }
}
