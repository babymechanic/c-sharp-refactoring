using System.IO;
using movie_rental;
using NUnit.Framework;

namespace movie_rental_test
{
    [TestFixture]
    public class CustomerTest
    {
        private readonly Customer dinsdale = new Customer("Dinsdale Pirhana");
        private readonly Movie la = new Movie("LA Confidential", Movie.NEW_RELEASE);
        private readonly Movie python = new Movie("Monty Python and the Holy Grail", Movie.REGULAR);
        private readonly Movie ran = new Movie("Ran", Movie.REGULAR);
        private readonly Movie trek = new Movie("Star Trek 13.2", Movie.NEW_RELEASE);
        private readonly Movie wallace = new Movie("Wallace and Gromit", Movie.CHILDRENS);

        [SetUp]
        public void SetUpData()
        {
            dinsdale.AddRental(new Rental(python, 3));
            dinsdale.AddRental(new Rental(ran, 1));
            dinsdale.AddRental(new Rental(la, 2));
            dinsdale.AddRental(new Rental(trek, 1));
            dinsdale.AddRental(new Rental(wallace, 6));
        }

        [Test]
        public void ShouldOutputEmptyStatement()
        {
            var customer = new Customer("Golden Shark");
            VerifyOutput(customer.Statement(), "outputEmpty");
        }

        [Test]
        public void ShouldOutputCustomerStatement()
        {
            VerifyOutput(dinsdale.Statement(), "output1");
        }

        [Test]
        public void ShouldOutputChangedStatement()
        {
            la.SetPriceCode(Movie.REGULAR);
            VerifyOutput(dinsdale.Statement(), "outputChange");
        }

        /*
    public void testHtml() throws Exception {
        verifyOutput("1st Output", "outputHtml", dinsdale.htmlStatement());
    }
    */

        protected void VerifyOutput(string actualValue, string fileName)
        {
            var file = new StreamReader(fileName);
            var actualStream = new StringReader(actualValue);
            string thisFileLine;
            while ((thisFileLine = file.ReadLine()) != null)
            {
                Assert.That(actualStream.ReadLine(), Is.EqualTo(thisFileLine));
            }
        }
    }
}