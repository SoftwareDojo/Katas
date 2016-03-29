using CSharpKatas.HarryPotter;
using NUnit.Framework;

namespace CSharpKataTests.HarryPotter
{
    [TestFixture]
    public class CartTests
    {
        [Test]
        public void TestCart_1x1_2x1_3x1_4x1_5x0()
        {
            var cart = new Cart(new Books5Discount());
            cart.AddOrder(new Book("Harry1", 8), 1);
            cart.AddOrder(new Book("Harry2", 8), 1);
            cart.AddOrder(new Book("Harry3", 8), 1);
            cart.AddOrder(new Book("Harry4", 8), 1);
            cart.AddOrder(new Book("Harry5", 8), 0);

            Assert.AreEqual(25,6, cart.GetTotalPrice());
        }

        [Test]
        public void TestCart_1x1_2x1_3x1_4x1_5x1()
        {
            var cart = new Cart(new Books5Discount());
            cart.AddOrder(new Book("Harry1", 8), 1);
            cart.AddOrder(new Book("Harry2", 8), 1);
            cart.AddOrder(new Book("Harry3", 8), 1);
            cart.AddOrder(new Book("Harry4", 8), 1);
            cart.AddOrder(new Book("Harry5", 8), 1);

            Assert.AreEqual(30, cart.GetTotalPrice());
        }

        [Test]
        public void TestCart_1x3_2x2_3x4_4x2_5x1()
        {
            var cart = new Cart(new Books5Discount());
            cart.AddOrder(new Book("Harry1", 8), 3);
            cart.AddOrder(new Book("Harry2", 8), 2);
            cart.AddOrder(new Book("Harry3", 8), 4);
            cart.AddOrder(new Book("Harry4", 8), 2);
            cart.AddOrder(new Book("Harry5", 8), 1);

            Assert.AreEqual(78,8, cart.GetTotalPrice());
        }

        [Test]
        public void TestCart_1x2_2x2_3x2_4x1_5x1()
        {
            var cart = new Cart(new Books5Discount());
            cart.AddOrder(new Book("Harry1", 8), 2);
            cart.AddOrder(new Book("Harry2", 8), 2);
            cart.AddOrder(new Book("Harry3", 8), 2);
            cart.AddOrder(new Book("Harry4", 8), 1);
            cart.AddOrder(new Book("Harry5", 8), 1);

            Assert.AreEqual(51,2, cart.GetTotalPrice());
        }

        [Test]
        public void TestCart_0x0()
        {
            var cart = new Cart(new Books5Discount());

            Assert.AreEqual(0, cart.GetTotalPrice());
        }

        [Test]
        public void TestCartNew_1x1_2x1_3x1_4x1_5x1_6x1_7x1()
        {
            var cart = new Cart(new Books7Discount());
            cart.AddOrder(new Book("Harry1", 8), 1);
            cart.AddOrder(new Book("Harry2", 8), 1);
            cart.AddOrder(new Book("Harry3", 8), 1);
            cart.AddOrder(new Book("Harry4", 8), 1);
            cart.AddOrder(new Book("Harry5", 8), 1);
            cart.AddOrder(new Book("Harry6", 8), 1);
            cart.AddOrder(new Book("Harry7", 8), 1);

            Assert.AreEqual(39,2, cart.GetTotalPrice());
        }
    }
}
