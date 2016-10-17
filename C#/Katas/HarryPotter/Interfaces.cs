
namespace Katas.HarryPotter
{
    public interface IOrder
    {
        IProduct Product { get; }
        uint Quantity { get; set; }
        IOrder Clone();
    }

    public interface ISetOrder
    {
        IProduct Product { get; }
        uint Quantity { get; }
        double CalculatePrice(IDiscount discount);
    }

    public interface IProduct
    {
        string Name { get; }
        double Price { get; }
        IProduct Clone();
    }

    public interface IDiscount
    {
        double GetSetDiscount(uint quantity);
    }
}
