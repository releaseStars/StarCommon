using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Extensions
{
    public static class RegexExtensions
    {
        public static bool TryMatch(this string input, string pattern, out Match result)
        {
            // eg:拆分0,1
            // input.TryMatch("(?<begin>\d+),(?<end>\d+)",out var result)
            // result.Groups["begin"].Value;
            try
            {
                result = Regex.Match(input, pattern);
                return result.Success;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            result = null;
            return false;
        }
    }
}
