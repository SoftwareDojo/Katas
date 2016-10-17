
namespace Katas.HarryPotter
{
    public class Book : IProduct
    {
        public string Name { get; private set; }
        public double Price { get; private set; }

        public Book(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public IProduct Clone()
        {
            return MemberwiseClone() as IProduct;
        }
    }
}
