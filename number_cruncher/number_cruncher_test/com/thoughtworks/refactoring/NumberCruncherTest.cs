using System;
using NUnit.Framework;

namespace com.thoughtworks.refactoring
{

[TestFixture]
public class NumberCruncherTest {
    [Test]
    public void shouldCountEvenNumbers() {
        int evens = new NumberCruncher(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11).CountEven();
        Assert.That(evens, Is.EqualTo(5));
    
    }

    [Test]
    public void shouldCountOddNumbers() {
        int odds = new NumberCruncher(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11).CountOdd();
        Assert.That(odds, Is.EqualTo(6));
    }

    [Test]
    public void shouldCountPositiveNumbers() {
        int positives = new NumberCruncher(-5, -4, -3, -2, -1, 0, 1, 2, 3, 4).CountPositive();
        Assert.That(positives, Is.EqualTo(5));
    }

    [Test]
    public void shouldCountNegativeNumbers() {
        int negatives = new NumberCruncher(-5, -4, -3, -2, -1, 0, 1, 2, 3, 4).CountNegative();
        Assert.That(negatives, Is.EqualTo(5));
    }

    }
}
