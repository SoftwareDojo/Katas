using System;

namespace CSharpKatas.Bowling
{
    public class Roll
    {
        public int Pins { get; }

        public Roll(int pins)
        {
            if (pins < 0 || pins > 10) throw new ArgumentException("Invalide Pins");
            Pins = pins;
        }

        public override string ToString()
        {
            return Pins.ToString();
        }
    }
}
