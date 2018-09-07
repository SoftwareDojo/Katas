namespace Katas.FizzBuzz
{
    public class FizzBuzz
    {
        public string ToFizzBuzz(uint number)
        {
            var result = string.Empty;
            var numberAsString = number.ToString();
            if (number == 0) return numberAsString;

            if (number % 3 == 0) result = "fizz";
            if (number % 5 == 0) result = result + "buzz";

            if (string.IsNullOrEmpty(result)) return numberAsString;

            return result;
        }

        public string ToFizzBuzzExtended(uint number)
        {
            var result = string.Empty;
            var numberAsString = number.ToString();
            if (number == 0) return numberAsString;
            

            if (number % 3 == 0 || numberAsString.Contains("3"))
            {
                result = "fizz";
            }
            if (number % 5 == 0 || numberAsString.Contains("5"))
            {
                result = result + "buzz";
            }

            if (string.IsNullOrEmpty(result)) return numberAsString;

            return result;
        }
    }
}
