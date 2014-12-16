using System.Collections.Generic;

namespace movie_rental
{
    public class Customer
    {
        private readonly string name;
        private readonly List<Rental> rentalList = new List<Rental>();

        public Customer(string name)
        {
            this.name = name;
        }

        public void AddRental(Rental arg)
        {
            rentalList.Add(arg);
        }

        public string GetName()
        {
            return name;
        }

        public string Statement()
        {
            double totalAmount = 0;
            var frequentRenterPoints = 0;
            IEnumerator<Rental> rentals = rentalList.GetEnumerator();
            var result = "Rental Record for " + GetName() + "\n";
            while (rentals.MoveNext())
            {
                double thisAmount = 0;
                var each = rentals.Current;

                // determine amounts for each line
                switch (each.GetMovie().GetPriceCode())
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (each.GetDaysRented() > 2)
                            thisAmount += (each.GetDaysRented() - 2)*1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += each.GetDaysRented()*3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (each.GetDaysRented() > 3)
                            thisAmount += (each.GetDaysRented() - 3)*1.5;
                        break;
                }

                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if ((each.GetMovie().GetPriceCode() == Movie.NEW_RELEASE)
                    && each.GetDaysRented() > 1)
                    frequentRenterPoints++;

                // show figures for this rental
                result += "\t" + each.GetMovie().GetTitle() + "\t"
                          + thisAmount + "\n";
                totalAmount += thisAmount;
            }
            // add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints
                      + " frequent renter points";
            return result;
        }
    }
}