
namespace Katas.BankOCR
{
    public class Character
    {
        public string[] Lines { get; }
        public string Value { get; }

        public Character(string[] lines, string value)
        {
            Lines = lines;
            Value = value;
        }
    }
}
