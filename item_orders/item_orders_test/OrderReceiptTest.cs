using System.Collections.Generic;
using item_orders;
using NUnit.Framework;

namespace item_orders_test
{
    [TestFixture]
    public class OrderReceiptTest
    {
        [Test]
        public void ShouldPrintCustomerInformationOnOrder()
        {
            var order = new Order("Mr X", "Chicago, 60601", new List<LineItem>());
            var receipt = new OrderReceipt(order);

            var output = receipt.printReceipt();

            Assert.That(output, Contains.Substring("Mr X"));
            Assert.That(output, Contains.Substring("Chicago, 60601"));
        }

        [Test]
        public void ShouldPrintLineItemAndSalesTaxInformation()
        {
            var lineItems = new List<LineItem>
            {
                new LineItem("milk", 10.0d, 2),
                new LineItem("biscuits", 5.0d, 5),
                new LineItem("chocolate", 20.0d, 1)
            };
            var receipt = new OrderReceipt(new Order(null, null, lineItems));

            var output = receipt.printReceipt();

            Assert.That(output, Contains.Substring("milk\t10\t2\t20\n"));
            Assert.That(output, Contains.Substring("biscuits\t5\t5\t25\n"));
            Assert.That(output, Contains.Substring("chocolate\t20\t1\t20\n"));
            Assert.That(output, Contains.Substring("Sales Tax\t6.5"));
            Assert.That(output, Contains.Substring("Total Amount\t71.5"));
        }
    }
}