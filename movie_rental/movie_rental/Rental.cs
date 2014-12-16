namespace movie_rental
{
    public class Rental
    {
        private readonly int daysRented;
        private readonly Movie movie;

        public Rental(Movie movie, int daysRented)
        {
            this.movie = movie;
            this.daysRented = daysRented;
        }

        public int GetDaysRented()
        {
            return daysRented;
        }

        public Movie GetMovie()
        {
            return movie;
        }
    }
}