
namespace Katas.HarryPotter
{
    public class Books5Discount : IDiscount
    {
        public double GetSetDiscount(uint quantity)
        {
            switch (quantity)
            {
                case 5: return 0.75;
                case 4: return 0.80;
                case 3: return 0.90;
                case 2: return 0.95;
                default:
                    return 1;
            }
        }
    }

    public class Books7Discount : IDiscount
    {
        public double GetSetDiscount(uint quantity)
        {
            switch (quantity)
            {
                case 7: return 0.70;
                case 6: return 0.75;
                case 5: return 0.80;
                case 4: return 0.85;
                case 3: return 0.90;
                case 2: return 0.95;
                default:
                    return 1;
            }
        }
    }
}
