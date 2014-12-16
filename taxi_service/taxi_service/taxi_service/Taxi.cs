namespace taxi_service
{
    public class Taxi
    {
        private readonly bool airConditioned;
        private readonly bool peakTime;
        private readonly int totalKms;

        public Taxi(bool airConditioned, int totalKms, bool peakTime)
        {
            this.airConditioned = airConditioned;
            this.totalKms = totalKms;
            this.peakTime = peakTime;
        }

        public bool IsAirConditioned()
        {
            return airConditioned;
        }

        public int GetTotalKms()
        {
            return totalKms;
        }

        public bool IsPeakTime()
        {
            return peakTime;
        }
    }
}