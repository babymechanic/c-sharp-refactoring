using System;

namespace movie_rental
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;
        private int priceCode;
        private readonly string title;

        public Movie(String title, int priceCode)
        {
            this.title = title;
            this.priceCode = priceCode;
        }

        public int GetPriceCode()
        {
            return priceCode;
        }

        public void SetPriceCode(int arg)
        {
            priceCode = arg;
        }

        public String GetTitle()
        {
            return title;
        }
    }
}