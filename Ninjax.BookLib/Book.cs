using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Ninjax.BookLib
{
    public class Book
    {
        private List<Order> _orders;

        public Order PlaceOrder(OrderRequest request)
        {
            var order = new Order();
            _orders.Add(order);
            return order;
        }
    }

    public class Order
    {
    }
    
    public class OrderRequest
    {
    }

}