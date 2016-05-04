using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpKatas.Bowling
{
    public class Game
    {
        public const int MaxPins = 10;
        public const int MaxBalls = 2;
        private const int s_FrameCount = 10;
        private int m_CurrentFrameIndex;
        internal IList<Frame> Frames { get; }

        public Game()
        {
            Frames = new List<Frame>();

            for (int i = 0; i < s_FrameCount; i++) Frames.Add(new Frame());
            for (int i = 0; i < s_FrameCount-1; i++) Frames[i].NextFrame = Frames[i + 1];

            m_CurrentFrameIndex = 0;
        }

        public void Throw(int pins)
        {
            var frame = Frames[m_CurrentFrameIndex];
            frame.Throw(pins);

            if (m_CurrentFrameIndex < s_FrameCount - 1 && (frame.GetThrowCount == MaxBalls || frame.Score() >= MaxPins))
                m_CurrentFrameIndex++;
        }

        public string ScoreBoard()
        {
            var scoreboard = new StringBuilder();
            var score = 0;

            for (int i = 0; i < s_FrameCount; i++)
            {
                score += Frames[i].Score();
                string frame = $"Frame {i + 1}:";

                var throws = Frames[i].GetThrows();
                if (string.IsNullOrEmpty(throws)) scoreboard.AppendLine(frame);
                else scoreboard.AppendLine(frame + $" {score} = {throws}");             
            }

            return scoreboard.ToString();
        }

        public int TotalScore()
        {
            return Frames.Sum(f => f.Score());
        }
    }
}
