
namespace Katas.StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers, char seperator)
        {
            int result = 0;
            if (string.IsNullOrEmpty(numbers)) return result;

            foreach (string part in numbers.Split(seperator))
            {
                if (string.IsNullOrEmpty(part) || string.IsNullOrWhiteSpace(part)) continue;

                int number;
                if (!int.TryParse(part, out number)) continue;
                result = result + number;
            }

            return result;
        }
    }
}
