using System;
using System.Collections.Generic;

namespace item_orders
{
    public class Order
    {
        private readonly String addr;
        private readonly List<LineItem> li;
        private readonly String nm;

        public Order(String nm, String addr, List<LineItem> li)
        {
            this.nm = nm;
            this.addr = addr;
            this.li = li;
        }

        public String GetCustomerName()
        {
            return nm;
        }

        public String GetCustomerAddress()
        {
            return addr;
        }

        public List<LineItem> GetLineItems()
        {
            return li;
        }
    }
}