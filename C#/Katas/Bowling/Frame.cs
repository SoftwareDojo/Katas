using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas.Bowling
{
    public class Frame
    {
        private const string s_Strike = "X";
        private const string s_Spare = "/";
        private const string s_WhiteSpace = " ";
        private readonly IList<int> m_Throws;

        public Frame NextFrame { private get; set; }

        public Frame()
        {
            m_Throws = new List<int>();
        }

        public int GetThrowCount => m_Throws.Count;

        public void Throw(int pins)
        {
            if (pins < 0 || pins > Game.MaxPins) throw new ArgumentException("Invalid number of pins");
            m_Throws.Add(pins);
        }

        public int Score()
        {
            int result = m_Throws.Sum();
            // no spare/strike or next frame isn't available
            if (result < Game.MaxPins || !AreThrowsAavailable(NextFrame)) return result;

            // spare
            result += NextFrame.m_Throws[0];
            if (m_Throws.Count > 1) return result;

            // strike
            if (NextFrame.m_Throws.Count == 1 && AreThrowsAavailable(NextFrame.NextFrame)) result += NextFrame.NextFrame.m_Throws[0];
            else if (NextFrame.m_Throws.Count > 1) result += NextFrame.m_Throws[1];

            return result;
        }

        public string GetThrows()
        {
            string rolls = string.Empty;
            int sum = 0;

            foreach (var roll in m_Throws)
            {
                if (roll == Game.MaxPins)
                {
                    rolls += s_WhiteSpace + s_Strike;
                    continue;
                }

                sum += roll;

                if (sum == Game.MaxPins)
                {
                    sum -= Game.MaxPins;
                    rolls += s_WhiteSpace + s_Spare;
                }
                else
                {
                    rolls += s_WhiteSpace + roll;
                }
            }

            return rolls.Trim();
        }

        public bool AreThrowsAavailable(Frame frame)
        {
            return frame != null && frame.m_Throws.Count > 0;
        }
    }
}
