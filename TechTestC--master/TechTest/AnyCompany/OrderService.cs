using System;
using System.Collections.Generic;

namespace AnyCompany
{
    public class OrderService
    {
        private readonly OrderRepository orderRepository = new OrderRepository();

        public bool PlaceOrder(Order order, int customerId)
        {

            Customer customer = CustomerRepository.Load(customerId);

            if (order.Amount == 0.0d)
            {
                return false;
            }

            if (order.VAT == 0.0d)
            {
                return false;
            }

            if (customer.Country.Equals("UK", System.StringComparison.OrdinalIgnoreCase))
            {
                order.VAT = 0.2d;
            }

            orderRepository.SaveOrder(order);

            return true;


        }


        public List<Order> LoadAllOrders(int customerId)
        {
            if (customerId > 0)
            {
                return OrderRepository.LoadOrders(customerId);
            }
            return null;

        }
    }
}
