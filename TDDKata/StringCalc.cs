// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;

namespace TDDKata
{
    internal class StringCalc
    {
        internal int Sum(string v)
        {
            if (string.IsNullOrEmpty(v) || string.IsNullOrWhiteSpace(v))
            {
                return 0;
            }

            var nums = v.Split(',');

            if (nums.Length > 3)
            {
                return -1;
            }

            int result = 0;

            foreach (string numStr in nums)
            {
                try
                {
                    var numInt = Convert.ToInt32(numStr);

                    if (numInt < 0)
                    {
                        return -1;
                    }

                    result += numInt;

                }
                catch(Exception ex)
                {
                    return -1;
                }
            }

            return result;
        }
    }
}