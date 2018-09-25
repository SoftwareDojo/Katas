using Xunit;
using Katas.HarryPotter;

namespace KatasFacts.HarryPotter
{
    public class CartFacts
    {
        [Fact]
        public void FactCart_1x1_2x1_3x1_4x1_5x0()
        {
            var cart = new Cart(new Books5Discount());
            cart.AddOrder(new Book("Harry1", 8), 1);
            cart.AddOrder(new Book("Harry2", 8), 1);
            cart.AddOrder(new Book("Harry3", 8), 1);
            cart.AddOrder(new Book("Harry4", 8), 1);
            cart.AddOrder(new Book("Harry5", 8), 0);

            Assert.Equal(25.6, cart.GetTotalPrice(), 1);
        }

        [Fact]
        public void FactCart_1x1_2x1_3x1_4x1_5x1()
        {
            var cart = new Cart(new Books5Discount());
            cart.AddOrder(new Book("Harry1", 8), 1);
            cart.AddOrder(new Book("Harry2", 8), 1);
            cart.AddOrder(new Book("Harry3", 8), 1);
            cart.AddOrder(new Book("Harry4", 8), 1);
            cart.AddOrder(new Book("Harry5", 8), 1);

            Assert.Equal(30, cart.GetTotalPrice(), 0);
        }

        [Fact]
        public void FactCart_1x3_2x2_3x4_4x2_5x1()
        {
            var cart = new Cart(new Books5Discount());
            cart.AddOrder(new Book("Harry1", 8), 3);
            cart.AddOrder(new Book("Harry2", 8), 2);
            cart.AddOrder(new Book("Harry3", 8), 4);
            cart.AddOrder(new Book("Harry4", 8), 2);
            cart.AddOrder(new Book("Harry5", 8), 1);

            Assert.Equal(78.8, cart.GetTotalPrice(), 1);
        }

        [Fact]
        public void FactCart_1x2_2x2_3x2_4x1_5x1()
        {
            var cart = new Cart(new Books5Discount());
            cart.AddOrder(new Book("Harry1", 8), 2);
            cart.AddOrder(new Book("Harry2", 8), 2);
            cart.AddOrder(new Book("Harry3", 8), 2);
            cart.AddOrder(new Book("Harry4", 8), 1);
            cart.AddOrder(new Book("Harry5", 8), 1);

            var price = cart.GetTotalPrice();
            Assert.Equal(51.2, price, 1);
        }

        [Fact]
        public void FactCart_0x0()
        {
            var cart = new Cart(new Books5Discount());

            Assert.Equal(0, cart.GetTotalPrice());
        }

        [Fact]
        public void FactCartNew_1x1_2x1_3x1_4x1_5x1_6x1_7x1()
        {
            var cart = new Cart(new Books7Discount());
            cart.AddOrder(new Book("Harry1", 8), 1);
            cart.AddOrder(new Book("Harry2", 8), 1);
            cart.AddOrder(new Book("Harry3", 8), 1);
            cart.AddOrder(new Book("Harry4", 8), 1);
            cart.AddOrder(new Book("Harry5", 8), 1);
            cart.AddOrder(new Book("Harry6", 8), 1);
            cart.AddOrder(new Book("Harry7", 8), 1);

            Assert.Equal(39.2, cart.GetTotalPrice(), 1);
        }
    }
}
