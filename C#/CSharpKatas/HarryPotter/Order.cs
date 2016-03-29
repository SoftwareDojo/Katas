namespace CSharpKatas.HarryPotter
{
    public class Order : SetOrder, IOrder
    {
        public Order(IProduct product, uint quantity) : base(product, quantity)
        {
        }

        public IOrder Clone()
        {
            return new Order(Product.Clone(), Quantity);
        }
    }

    public class SetOrder : ISetOrder
    {
        public IProduct Product { get; set; }
        public uint Quantity { get; set; }

        public SetOrder(IProduct product, uint quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public double CalculatePrice(IDiscount discount)
        {
            return Quantity * Product.Price * discount.GetSetDiscount(Quantity);
        }
    }
}