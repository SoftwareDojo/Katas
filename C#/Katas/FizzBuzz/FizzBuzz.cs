namespace Katas.FizzBuzz
{
    public class FizzBuzz
    {
        private const string Buzz = "buzz";
        private const string Fizz = "fizz";

        public string ToFizzBuzz(uint number)
        {
            var result = number.ToString();
            if (number == 0) return result;

            if (IsDivisibleBy3(number)) result = Fizz;
            if (IsDivisibleBy5(number)) result = Buzz;
            if (IsDivisibleBy3(number) && IsDivisibleBy5(number)) result = Fizz + Buzz;

            return result;
        }

        public string ToFizzBuzzExtended(uint number)
        {
            var result = string.Empty;
            var numberAsString = number.ToString();
            if (number == 0) return numberAsString;

            if (IsDivisibleBy3(number) || numberAsString.Contains("3")) result = Fizz;
            if (IsDivisibleBy5(number) || numberAsString.Contains("5")) result += Buzz;

            if (string.IsNullOrEmpty(result)) return numberAsString;

            return result;
        }

        private bool IsDivisibleBy3(uint number)
        {
            return number % 3 == 0;
        }

        private bool IsDivisibleBy5(uint number)
        {
            return number % 5 == 0;
        }
    }
}
