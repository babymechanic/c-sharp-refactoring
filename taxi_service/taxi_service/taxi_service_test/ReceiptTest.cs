using NUnit.Framework;
using taxi_service;

namespace taxi_service_test
{
    [TestFixture]
    public class ReceiptTest
    {
        /**
     * Fixed Charges - 50 Rs.
     * Minimum Total Charges - 150 Rs.
     * <p/>
     * Non AC - 15 Rs/Km. for first 10 Km., 12 Rs/Km. from there on.
     * AC - 20 Rs/Km. for first 10 Km., 17 Rs/Km. from there on.
     * 20 % extra for peak time
     * <p/>
     * Sales Tax - 10 % on total bill amount
     */

        [Test]
        public void ShouldCalculateChargesForACTaxiFor20Kms()
        {
            // ((20 * 10 + 17 * 20) + 50 ) * 1.1 = 649.0
            var cost = new Receipt(new Taxi(true, 30, false)).TotalCost();
            Assert.That(cost, Is.EqualTo(649D).Within(0.01D));
        }

        [Test]
        public void ShouldCalculateChargesForNonACTaxiFor20Kms()
        {
            // ((15 * 10 + 12 * 20) + 50 ) * 1.1 = 374.0
            var cost = new Receipt(new Taxi(false, 30, false)).TotalCost();
            Assert.That(cost, Is.EqualTo(484D).Within(0.01D));
        }

        [Test]
        public void ShouldCalculateForACChargesFor20KmsPeakTime()
        {
            // ((20 * 10 + 17 * 20) * 1.2 + 50 ) * 1.1 = 767.8
            var cost = new Receipt(new Taxi(true, 30, true)).TotalCost();
            Assert.That(cost, Is.EqualTo(767.8D).Within(0.01D));
        }

        [Test]
        public void ShouldCalculateChargesForNonACTaxiFor20KmsPeakTime()
        {
            // ((15 * 10 + 12 * 20) * 1.2 + 50 ) * 1.1 = 569.8
            var cost = new Receipt(new Taxi(false, 30, true)).TotalCost();
            Assert.That(cost, Is.EqualTo(569.8D).Within(0.01D));
        }
    }
}