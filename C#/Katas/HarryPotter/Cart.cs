using System.Collections.Generic;
using System.Linq;

namespace Katas.HarryPotter
{
    public class Cart
    {
        private readonly IList<IOrder> m_Orders;
        private readonly IDiscount m_Discount;

        public Cart(IDiscount discount)
        {
            m_Orders = new List<IOrder>();
            m_Discount = discount;
        }

        public void AddOrder(IProduct product, uint quantity)
        {
            m_Orders.Add(new Order(product, quantity));
        }

        public double GetTotalPrice()
        {
            double price = 0;
            if (!m_Orders.Any()) return price;

            foreach (var set in GetSetOrders(m_Orders))
            {
                price += set.CalculatePrice(m_Discount);
            }

            return price;
        }

        private IEnumerable<ISetOrder> GetSetOrders(IEnumerable<IOrder> orders)
        {
            var sets = new List<ISetOrder>();
            var orderCopies = new List<IOrder>();
            orderCopies.AddRange(orders.Select(o => o.Clone()));

            while (orderCopies.Any())
            {
                IProduct product = null;
                uint count = 0;
                foreach (var order in orderCopies)
                {
                    if (order.Quantity == 0) continue;

                    count++;
                    order.Quantity--;
                    if (product == null) product = order.Product;
                }

                if (count == 0) break;
                sets.Add(new SetOrder(product, count));
            }

            return sets;
        }
    }
}
