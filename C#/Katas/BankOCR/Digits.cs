using System.Collections.Generic;

namespace Katas.BankOCR
{
    public class Digits : List<Character>
    {
        public const int Height = 3;
        public const int Width = 3;

        public Digits()
        {
            Add(new Character(new[] {" _ ", "| |", "|_|"}, "0"));
            Add(new Character(new[] {"   ", "  |", "  |"}, "1"));
            Add(new Character(new[] {" _ ", " _|", "|_ "}, "2"));
            Add(new Character(new[] {" _ ", " _|", " _|"}, "3"));
            Add(new Character(new[] {"   ", "|_|", "  |"}, "4"));
            Add(new Character(new[] {" _ ", "|_ ", " _|"}, "5"));
            Add(new Character(new[] {" _ ", "|_ ", "|_|"}, "6"));
            Add(new Character(new[] {" _ ", "  |", "  |"}, "7"));
            Add(new Character(new[] {" _ ", "|_|", "|_|"}, "8"));
            Add(new Character(new[] {" _ ", "|_|", " _|"}, "9"));
        }
    }
}
