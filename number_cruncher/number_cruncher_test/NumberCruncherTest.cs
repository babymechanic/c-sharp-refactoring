using number_cruncher;
using NUnit.Framework;

namespace number_cruncher_test
{
    [TestFixture]
    public class NumberCruncherTest
    {
        [Test]
        public void ShouldCountEvenNumbers()
        {
            var evens = new NumberCruncher(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11).CountEven();
            Assert.That(evens, Is.EqualTo(5));
        }

        [Test]
        public void ShouldCountOddNumbers()
        {
            var odds = new NumberCruncher(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11).CountOdd();
            Assert.That(odds, Is.EqualTo(6));
        }

        [Test]
        public void ShouldCountPositiveNumbers()
        {
            var positives = new NumberCruncher(-5, -4, -3, -2, -1, 0, 1, 2, 3, 4).CountPositive();
            Assert.That(positives, Is.EqualTo(5));
        }

        [Test]
        public void ShouldCountNegativeNumbers()
        {
            var negatives = new NumberCruncher(-5, -4, -3, -2, -1, 0, 1, 2, 3, 4).CountNegative();
            Assert.That(negatives, Is.EqualTo(5));
        }
    }
}