namespace Katas.FizzBuzz
{
    public class FizzBuzz
    {
        public string DoFizzBuzz(uint value)
        {
            string result = string.Empty;
            if (value == 0) return result;

            if (value % 3 == 0) result = "fizz";
            if (value % 5 == 0) result = result + "buzz";

            if (string.IsNullOrEmpty(result)) result = value.ToString();

            return result;
        }

        public string DoFizzBuzzExtended(uint value)
        {
            string result = string.Empty;
            if (value == 0) return result;
            string text = value.ToString();

            if (value % 3 == 0 || text.Contains("3"))
            {
                result = "fizz";
            }
            if (value % 5 == 0 || text.Contains("5"))
            {
                result = result + "buzz";
            }

            if (string.IsNullOrEmpty(result)) return text;

            return result;
        }
    }
}
