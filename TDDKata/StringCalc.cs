// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;

namespace TDDKata
{
    internal class StringCalc
    {
        private readonly char[] delimiterChars = { ',', '\n' };

        internal int Sum(string str)
        {
            try
            {
                int result = 0;

                var stringSpaceFree = str.Replace(" ", "");

                if (string.IsNullOrEmpty(stringSpaceFree))
                {
                    return result;
                }

                foreach (string numStr in stringSpaceFree.Split(delimiterChars))
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
    }
}