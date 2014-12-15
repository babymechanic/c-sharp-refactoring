using NUnit.Framework;
using System.IO;
using System.Reflection;


//import sun.security.util.Debug;
//
//import java.io.BufferedReader;
//import java.io.FileReader;
//import java.io.IOException;
//import java.io.StringReader;
//

namespace com.thoughtworks.refactoring{


[TestFixture]
public class CustomerTest {

    private Customer dinsdale = new Customer("Dinsdale Pirhana");

    private Movie python = new Movie("Monty Python and the Holy Grail", Movie.REGULAR);
	private Movie ran = new Movie("Ran", Movie.REGULAR);
	private Movie la = new Movie("LA Confidential", Movie.NEW_RELEASE);
	private Movie trek = new Movie("Star Trek 13.2", Movie.NEW_RELEASE);
	private Movie wallace = new Movie("Wallace and Gromit", Movie.CHILDRENS);

    [SetUp]
    public void setUpData(){
       dinsdale.AddRental(new Rental (python, 3));
       dinsdale.AddRental(new Rental (ran, 1));
       dinsdale.AddRental(new Rental (la, 2));
       dinsdale.AddRental(new Rental (trek, 1));
       dinsdale.AddRental(new Rental (wallace, 6));
   }

    [Test]
    public void shouldOutputEmptyStatement() {
        Customer customer = new Customer("Golden Shark");
        verifyOutput(customer.Statement(), "outputEmpty");
    }

    [Test]
    public void shouldOutputCustomerStatement(){
        verifyOutput(dinsdale.Statement(), "output1");
    }

    [Test]
    public void shouldOutputChangedStatement(){
        la.SetPriceCode(Movie.REGULAR);
        verifyOutput(dinsdale.Statement(), "outputChange");
    }

    /*
    public void testHtml() throws Exception {
        verifyOutput("1st Output", "outputHtml", dinsdale.htmlStatement());
    }
    */
    	
    protected void verifyOutput(string actualValue, string fileName) {
        StreamReader file = new StreamReader(fileName);
        StringReader actualStream = new StringReader(actualValue);
        string thisFileLine;
        while  ((thisFileLine = file.ReadLine()) != null) {
            Assert.That(actualStream.ReadLine(), Is.EqualTo(thisFileLine));
        }
    }

}
    }
