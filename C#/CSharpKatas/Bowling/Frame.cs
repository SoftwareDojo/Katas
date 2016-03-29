using System.Collections.Generic;
using System.Linq;

namespace CSharpKatas.Bowling
{
    public class Frame
    {
        public Frame NextFrame { get; set; }
        public IList<Roll> Rolls { get; }
        public int Number { get; }

        public Frame(int number)
        {
            Rolls = new List<Roll>();
            Number = number;
        }

        public void Roll(int pins)
        {
            Rolls.Add(new Roll(pins));
        }

        public int Score()
        {
            int result = Rolls.Sum(r => r.Pins);
            if (result < 10 || NextFrame == null) return result;

            result += NextFrame.Rolls[0].Pins;
            if (Rolls.Count > 1) return result;

            if (NextFrame.Rolls.Count == 1 && NextFrame.NextFrame != null)
                result += NextFrame.NextFrame.Rolls[0].Pins;
            else if (NextFrame.Rolls.Count > 1)
                result += NextFrame.Rolls[1].Pins;

            return result;
        }

        public override string ToString()
        {
            string  txt = "Frame "+Number+": " + Score() + " = ";
            foreach (var roll in Rolls)
            {
                txt += roll + "+";
            }

            return txt.Substring(0, txt.Length - 1);
        }
    }
}
