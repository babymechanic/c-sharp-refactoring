using System;
using System.Collections.Generic;

namespace com.thoughtworks.refactoring
{

public class Order {
    String nm;
    String addr;
    List<LineItem> li;

    public Order(String nm, String addr, List<LineItem> li) {
        this.nm = nm;
        this.addr = addr;
        this.li = li;
    }

		public String GetCustomerName() {
        return nm;
    }

		public String GetCustomerAddress() {
        return addr;
    }

		public List<LineItem> GetLineItems() {
        return li;
    }
}
}
