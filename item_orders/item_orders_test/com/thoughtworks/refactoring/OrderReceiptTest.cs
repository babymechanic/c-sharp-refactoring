using System;
using NUnit.Framework;
using System.Collections.Generic;


namespace com.thoughtworks.refactoring
{

[TestFixture]
public class OrderReceiptTest {
    [Test]
    public void ShouldPrintCustomerInformationOnOrder() {
        Order order = new Order("Mr X", "Chicago, 60601", new List<LineItem>());
        OrderReceipt receipt = new OrderReceipt(order);

        String output = receipt.printReceipt();

        Assert.That(output, Contains.Substring("Mr X"));
        Assert.That(output, Contains.Substring("Chicago, 60601"));
    }

    [Test]
    public void ShouldPrintLineItemAndSalesTaxInformation() {
        List<LineItem> lineItems = new List<LineItem>() {
            new LineItem("milk", 10.0, 2),
            new LineItem("biscuits", 5.0, 5),
            new LineItem("chocolate", 20.0, 1)
        };
        OrderReceipt receipt = new OrderReceipt(new Order(null, null, lineItems));

        String output = receipt.printReceipt();

        Assert.That(output, Contains.Substring("milk\t10.0\t2\t20.0\n"));
        Assert.That(output, Contains.Substring("biscuits\t5.0\t5\t25.0\n"));
        Assert.That(output, Contains.Substring("chocolate\t20.0\t1\t20.0\n"));
        Assert.That(output, Contains.Substring("Sales Tax\t6.5"));
        Assert.That(output, Contains.Substring("Total Amount\t71.5"));
    }

}
}
