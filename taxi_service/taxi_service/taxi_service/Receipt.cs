using System;

namespace taxi_service
{
    public class Receipt
    {
        private readonly Taxi taxi;

        public Receipt(Taxi taxi)
        {
            this.taxi = taxi;
        }

        public double TotalCost()
        {
            double totalCost = 0;

            // fixed charges
            totalCost += 50;

            // taxi charges
            var totalKms = taxi.GetTotalKms();
            var peakTimeMultiple = taxi.IsPeakTime() ? 1.2 : 1.0;
            if (taxi.IsAirConditioned())
            {
                totalCost += Math.Min(10, totalKms)*20*peakTimeMultiple;
                totalCost += Math.Max(0, totalKms - 10)*17*peakTimeMultiple;
            }
            else
            {
                totalCost += Math.Min(10, totalKms)*15*peakTimeMultiple;
                totalCost += Math.Max(0, totalKms - 10)*12*peakTimeMultiple;
            }

            return totalCost*(1 + 0.1);
        }
    }
}