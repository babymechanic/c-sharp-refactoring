using System;
using date_parser;
using NUnit.Framework;

namespace date_parser_test
{
    [TestFixture]
    public class DateParserTest
    {
        [Test, ExpectedException(typeof (ArgumentException))]
        public void ShouldThrowExceptionIfYearStringCannotBeParsed()
        {
            new DateParser("111").parse();
        }

        [Test]
        public void ShouldThrowExceptionIfYearIsNotInteger()
        {
            try
            {
                new DateParser("abcd").parse();
                Assert.Fail("Should have failed since the year string is not an integer");
            }
            catch (ArgumentException e)
            {
                Assert.That(e.Message, Is.EqualTo("Year is not an integer"));
            }
        }

        [Test]
        public void ShouldThrowExceptionIfYearIsLessThan2000()
        {
            try
            {
                new DateParser("1999").parse();
                Assert.Fail("Should have failed since the year is less than 2000");
            }
            catch (ArgumentException e)
            {
                Assert.That(e.Message, Is.EqualTo("Year cannot be less than 2000 or more than 2012"));
            }
        }

        [Test]
        public void ShouldThrowExceptionIfMonthStringCannotBeParsed()
        {
            try
            {
                new DateParser("2012-1").parse();
                Assert.Fail("Should have failed since the month string is less than 2 characters");
            }
            catch (ArgumentException e)
            {
                Assert.That(e.Message, Is.EqualTo("Month string is less than 2 characters"));
            }
        }

        [Test]
        public void ShouldThrowExceptionIfMonthIsNotInteger()
        {
            try
            {
                new DateParser("2012-ab").parse();
                Assert.Fail("Should have failed since the month string is not an integer");
            }
            catch (ArgumentException e)
            {
                Assert.That(e.Message, Is.EqualTo("Month is not an integer"));
            }
        }

        [Test]
        public void ShouldThrowExceptionIfMonthIsMoreThan12()
        {
            try
            {
                new DateParser("2012-13").parse();
                Assert.Fail("Should have failed since the month is more than 12");
            }
            catch (ArgumentException e)
            {
                Assert.That(e.Message, Is.EqualTo("Month cannot be less than 1 or more than 12"));
            }
        }

        [Test]
        public void ShouldThrowExceptionIfDateStringCannotBeParsed()
        {
            try
            {
                new DateParser("2012-12-1").parse();
                Assert.Fail("Should have failed since the date string is less than 2 characters");
            }
            catch (ArgumentException e)
            {
                Assert.That(e.Message, Is.EqualTo("Date string is less than 2 characters"));
            }
        }

        [Test]
        public void ShouldThrowExceptionIfDateIsNotInteger()
        {
            try
            {
                new DateParser("2012-12-ab").parse();
                Assert.Fail("Should have failed since the date string is not an integer");
            }
            catch (ArgumentException e)
            {
                Assert.That(e.Message, Is.EqualTo("Date is not an integer"));
            }
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void ShouldThrowExceptionIfDateIsMoreThan31()
        {
            new DateParser("2012-12-32").parse();
        }

        [Test]
        public void ShouldThrowExceptionIfHourStringCannotBeParsed()
        {
            try
            {
                new DateParser("2012-12-11T0").parse();
                Assert.Fail("Should have failed since the hour string is less than 2 characters");
            }
            catch (ArgumentException e)
            {
                Assert.That(e.Message, Is.EqualTo("Hour string is less than 2 characters"));
            }
        }

        [Test]
        public void ShouldThrowExceptionIfHourIsNotInteger()
        {
            try
            {
                new DateParser("2012-12-30Tab").parse();
                Assert.Fail("Should have failed since the hour string is not an integer");
            }
            catch (ArgumentException e)
            {
                Assert.That(e.Message, Is.EqualTo("Hour is not an integer"));
            }
        }

        [Test]
        public void ShouldThrowExceptionIfHourIsMoreThan23()
        {
            try
            {
                new DateParser("2012-12-31T24").parse();
                Assert.Fail("Should have failed since the hour is more than 23");
            }
            catch (ArgumentException e)
            {
                Assert.That(e.Message, Is.EqualTo("Hour cannot be less than 0 or more than 23"));
            }
        }

        [Test]
        public void ShouldThrowExceptionIfMinuteStringCannotBeParsed()
        {
            try
            {
                new DateParser("2012-12-11T01:1").parse();
                Assert.Fail("Should have failed since the minute string is less than 2 characters");
            }
            catch (ArgumentException e)
            {
                Assert.That(e.Message, Is.EqualTo("Minute string is less than 2 characters"));
            }
        }

        [Test]
        public void ShouldThrowExceptionIfMinuteIsNotInteger()
        {
            try
            {
                new DateParser("2012-12-30T01:ab").parse();
                Assert.Fail("Should have failed since the minute string is not an integer");
            }
            catch (ArgumentException e)
            {
                Assert.That(e.Message, Is.EqualTo("Minute is not an integer"));
            }
        }

        [Test]
        public void ShouldThrowExceptionIfMinuteIsMoreThan59()
        {
            try
            {
                new DateParser("2012-12-31T23:60").parse();
                Assert.Fail("Should have failed since the minute is more than 59");
            }
            catch (ArgumentException e)
            {
                Assert.That(e.Message, Is.EqualTo("Minute cannot be less than 0 or more than 59"));
            }
        }

        [Test]
        public void ShouldParseDateForValidInput()
        {
            var dateTimeExpected = new DateTime(2012, 12, 31, 23, 59, 0, 0, DateTimeKind.Utc);
            var result = new DateParser("2012-12-31T23:59Z").parse();

            Assert.That(result, Is.EqualTo(dateTimeExpected));
        }
    }
}