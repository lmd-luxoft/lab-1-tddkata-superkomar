// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace TDDKata
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void SumZeroNums()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum("");
            Assert.That(value, Is.EqualTo(0), "Wrong actual value");
        }

        [Test]
        public void SumOneNums()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum("1");
            Assert.That(value, Is.EqualTo(1), "Wrong actual value");
        }

        [Test]
        public void SumTwoNums()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum("1,2");
            Assert.That(value, Is.EqualTo(3), "Wrong actual value");
        }

        [Test]
        public void SumThreeNums()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum("1,2,3");
            Assert.That(value, Is.EqualTo(6), "Wrong actual value");
        }

        [Test]
        public void SumFourNums()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum("1,2,3,4");
            Assert.That(value, Is.EqualTo(-1), "Wrong actual value");
        }

        [Test]
        public void SumNegativeNums()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum("1,2,-3");
            Assert.That(value, Is.EqualTo(-1), "Wrong actual value");
        }

        [Test]
        public void LettersArguments()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum("art");
            Assert.That(value, Is.EqualTo(-1), "Wrong actual value");
        }

        [Test]
        public void SpecSymbolsArguments()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum("&,:#$");
            Assert.That(value, Is.EqualTo(-1), "Wrong actual value");
        }

        [Test]
        public void SpaceAsArguments()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum("   ,   ");
            Assert.That(value, Is.EqualTo(-1), "Wrong actual value");
        }
    }
}
