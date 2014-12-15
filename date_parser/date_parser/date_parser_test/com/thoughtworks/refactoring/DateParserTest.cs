using NUnit.Framework;
using System;

namespace com.thoughtworks.refactoring
{

[TestFixture]
public class DateParserTest {
    [Test]
    public void shouldThrowExceptionIfYearStringCannotBeParsed() {
        try {
            new DateParser("111").parse();
            Assert.Fail("Should have failed since the year string is less than 4 characters");
        } catch (ArgumentException e) {
            Assert.That(e.Message, Is.EqualTo("Year string is less than 4 characters"));
        }
    }

    [Test]
    public void shouldThrowExceptionIfYearIsNotInteger() {
        try {
            new DateParser("abcd").parse();
            Assert.Fail("Should have failed since the year string is not an integer");
        }
        catch (ArgumentException e)
        {
            Assert.That(e.Message, Is.EqualTo("Year is not an integer"));
        }
    }

    [Test]
    public void shouldThrowExceptionIfYearIsLessThan2000() {
        try {
            new DateParser("1999").parse();
            Assert.Fail("Should have failed since the year is less than 2000");
        }
        catch (ArgumentException e)
        {
            Assert.That(e.Message, Is.EqualTo("Year cannot be less than 2000 or more than 2012"));
        }
    }

    [Test]
    public void shouldThrowExceptionIfMonthStringCannotBeParsed() {
        try {
            new DateParser("2012-1").parse();
            Assert.Fail("Should have failed since the month string is less than 2 characters");
        }
        catch (ArgumentException e)
        {
            Assert.That(e.Message, Is.EqualTo("Month string is less than 2 characters"));
        }
    }

    [Test]
    public void shouldThrowExceptionIfMonthIsNotInteger() {
        try {
            new DateParser("2012-ab").parse();
            Assert.Fail("Should have failed since the month string is not an integer");
        }
        catch (ArgumentException e)
        {
            Assert.That(e.Message, Is.EqualTo("Month is not an integer"));
        }
    }

    [Test]
    public void shouldThrowExceptionIfMonthIsMoreThan12() {
        try {
            new DateParser("2012-13").parse();
            Assert.Fail("Should have failed since the month is more than 12");
        }
        catch (ArgumentException e)
        {
            Assert.That(e.Message, Is.EqualTo("Month cannot be less than 1 or more than 12"));
        }
    }

    [Test]
    public void shouldThrowExceptionIfDateStringCannotBeParsed() {
        try {
            new DateParser("2012-12-1").parse();
            Assert.Fail("Should have failed since the date string is less than 2 characters");
        }
        catch (ArgumentException e)
        {
            Assert.That(e.Message, Is.EqualTo("Date string is less than 2 characters"));
        }
    }

    [Test]
    public void shouldThrowExceptionIfDateIsNotInteger() {
        try {
            new DateParser("2012-12-ab").parse();
            Assert.Fail("Should have failed since the date string is not an integer");
        }
        catch (ArgumentException e)
        {
            Assert.That(e.Message, Is.EqualTo("Date is not an integer"));
        }
    }

    [Test]
    public void shouldThrowExceptionIfDateIsMoreThan31() {
        try {
            new DateParser("2012-12-32").parse();
            Assert.Fail("Should have failed since the date is more than 31");
        }
        catch (ArgumentException e)
        {
            Assert.That(e.Message, Is.EqualTo("Date cannot be less than 1 or more than 31"));
        }
    }

    [Test]
    public void shouldThrowExceptionIfHourStringCannotBeParsed() {
        try {
            new DateParser("2012-12-11T0").parse();
            Assert.Fail("Should have failed since the hour string is less than 2 characters");
        }
        catch (ArgumentException e)
        {
            Assert.That(e.Message, Is.EqualTo("Hour string is less than 2 characters"));
        }
    }

    [Test]
    public void shouldThrowExceptionIfHourIsNotInteger() {
        try {
            new DateParser("2012-12-30Tab").parse();
            Assert.Fail("Should have failed since the hour string is not an integer");
        }
        catch (ArgumentException e)
        {
            Assert.That(e.Message, Is.EqualTo("Hour is not an integer"));
        }
    }

    [Test]
    public void shouldThrowExceptionIfHourIsMoreThan23() {
        try {
            new DateParser("2012-12-31T24").parse();
            Assert.Fail("Should have failed since the hour is more than 23");
        }
        catch (ArgumentException e)
        {
            Assert.That(e.Message, Is.EqualTo("Hour cannot be less than 0 or more than 23"));
        }
    }

    [Test]
    public void shouldThrowExceptionIfMinuteStringCannotBeParsed() {
        try {
            new DateParser("2012-12-11T01:1").parse();
            Assert.Fail("Should have failed since the minute string is less than 2 characters");
        }
        catch (ArgumentException e)
        {
            Assert.That(e.Message, Is.EqualTo("Minute string is less than 2 characters"));
        }
    }

    [Test]
    public void shouldThrowExceptionIfMinuteIsNotInteger() {
        try {
            new DateParser("2012-12-30T01:ab").parse();
            Assert.Fail("Should have failed since the minute string is not an integer");
        }
        catch (ArgumentException e)
        {
            Assert.That(e.Message, Is.EqualTo("Minute is not an integer"));
        }
    }

    [Test]
    public void shouldThrowExceptionIfMinuteIsMoreThan59() {
        try {
            new DateParser("2012-12-31T23:60").parse();
            Assert.Fail("Should have failed since the minute is more than 59");
        }
        catch (ArgumentException e)
        {
            Assert.That(e.Message, Is.EqualTo("Minute cannot be less than 0 or more than 59"));
        }
    }

    [Test]
    public void shouldParseDateForValidInput() {
    	var dateTimeExpected = new DateTime(2012,12,31,23,59,0,0,DateTimeKind.Utc);
        var result = new DateParser("2012-12-31T23:59Z").parse();

        Assert.That(result, Is.EqualTo(dateTimeExpected));
    }
}
    }