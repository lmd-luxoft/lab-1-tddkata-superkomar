// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Text.RegularExpressions;

namespace TDDKata
{
    internal class StringCalc
    {
        private static readonly Regex DelimeterRegex = new Regex(@"\/\/(.*)\n(.*)", RegexOptions.Compiled);

        internal int Sum(string inputStr)
        {
            try
            {
                int result = 0;

                var spaceFreeStr = inputStr.TrimStart(' ').TrimEnd(' ');

                if (string.IsNullOrEmpty(spaceFreeStr))
                {
                    return result;
                }

                ParseStringToDelimeters(spaceFreeStr, out string strToParse, out string[] delimeters);


                foreach (string numStr in strToParse.Split(delimeters, StringSplitOptions.None))
                {
                    var numInt = Convert.ToInt32(numStr);

                    if (numInt < 0)
                    {
                        throw new ArgumentException();
                    }

                    result += numInt;
                }

                return result;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private void ParseStringToDelimeters(string inputStr, out string strToParse, out string[] delimeters)
        {
            var match = DelimeterRegex.Match(inputStr);

            if (match.Success && !string.IsNullOrEmpty(match.Groups[2].Value))
            {
                strToParse = match.Groups[2].Value;
                delimeters = new[] { match.Groups[1].Value };
            }
            else
            {
                strToParse = inputStr;
                delimeters = new[] { ",", "\n" };
            }
        }
    }
}