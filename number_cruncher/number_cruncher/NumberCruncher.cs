namespace number_cruncher
{
    public class NumberCruncher
    {
        private readonly int[] numbers;

        public NumberCruncher(params int[] numbers)
        {
            this.numbers = numbers;
        }

        public int CountEven()
        {
            var count = 0;
            foreach (var number in numbers)
            {
                if (number%2 == 0) count++;
            }
            return count;
        }

        public int CountOdd()
        {
            var count = 0;
            foreach (var number in numbers)
            {
                if (number%2 == 1) count++;
            }
            return count;
        }

        public int CountPositive()
        {
            var count = 0;
            foreach (var number in numbers)
            {
                if (number >= 0) count++;
            }
            return count;
        }

        public int CountNegative()
        {
            var count = 0;
            foreach (var number in numbers)
            {
                if (number < 0) count++;
            }
            return count;
        }
    }
}