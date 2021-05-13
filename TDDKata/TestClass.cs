// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
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
        [TestCase("1,2")]
        [TestCase("1\n2")]
        public void SumTwoNums(string argument)
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum(argument);
            Assert.That(value, Is.EqualTo(3), "Wrong actual value");
        }

        [Test]
        [TestCase("1,2,3")]
        [TestCase("1\n2\n3")]
        [TestCase("1,2\n3")]
        [TestCase("1\n2,3")]
        public void SumThreeNums(string argument)
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum(argument);
            Assert.That(value, Is.EqualTo(6), "Wrong actual value");
        }

        [Test]
        [TestCase("1,2,3,4")]
        [TestCase("1\n2\n3\n4")]
        [TestCase("1,2\n3\n4")]
        [TestCase("1\n2,3\n4")]
        [TestCase("1\n2\n3,4")]
        public void SumFourNums(string argument)
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum(argument);
            Assert.That(value, Is.EqualTo(10), "Wrong actual value");
        }

        [Test]
        [TestCase("1,2,3,-4")]
        [TestCase("1\n2\n3\n-4")]
        [TestCase("1,2\n3\n-4")]
        [TestCase("1\n2,3\n-4")]
        [TestCase("1\n2\n3,-4")]
        public void SumNegativeNums(string argument)
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum(argument);
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
        [TestCase("   ,   ")]
        [TestCase("   \n   ")]
        public void SpaceAsManyArguments(string argument)
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum(argument);
            Assert.That(value, Is.EqualTo(-1), "Wrong actual value");
        }

        [Test]
        public void NullArgument()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum(null);
            Assert.That(value, Is.EqualTo(-1), "Wrong actual value");
        }

        [Test]
        public void SpaceAsOneArgument()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum("     ");
            Assert.That(value, Is.EqualTo(0), "Wrong actual value");
        }

        [Test]
        [TestCase("//;\n1;2;3")]
        [TestCase("// \n1 2 3")]
        [TestCase("//&\n1&2&3")]
        [TestCase("//%$\n1%$2%$3")]
        public void CustomNumSeparator_CorrectString(string argument)
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum(argument);
            Assert.That(value, Is.EqualTo(6), "Wrong actual value");
        }

        [Test]
        [TestCase("//;\n1.2.3")]
        [TestCase("// \n1 2;3")]
        [TestCase("//\n1,2\n3")]
        [TestCase("//%$\n1$%2%&3")]
        public void CustomNumSeparator_IncorrectString(string argument)
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum(argument);
            Assert.That(value, Is.EqualTo(-1), "Wrong actual value");
        }
    }
}
