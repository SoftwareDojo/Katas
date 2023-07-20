namespace Katas
{
    public static class StringCalculator
    {
        public static int Add(string numbers, char seperator)
        {
            var result = 0;
            if (string.IsNullOrEmpty(numbers)) return result;

            foreach (var part in numbers.Split(seperator))
            {
                if (string.IsNullOrWhiteSpace(part)) continue;

                if (!int.TryParse(part, out var number)) continue;
                result += number;
            }

            return result;
        }
    }
}
