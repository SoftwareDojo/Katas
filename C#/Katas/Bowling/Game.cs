using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katas.Bowling
{
    public class Game
    {
        public const int MaxPins = 10;
        public const int MaxBalls = 2;
        public IList<Frame> Frames { get; }

        private const int FrameCount = 10;
        private int currentFrameIndex;

        public Game()
        {
            Frames = new List<Frame>();

            for (int i = 0; i < FrameCount; i++) Frames.Add(new Frame());
            for (int i = 0; i < FrameCount - 1; i++) Frames[i].NextFrame = Frames[i + 1];

            currentFrameIndex = 0;
        }

        public void Throw(int pins)
        {
            var frame = Frames[currentFrameIndex];
            frame.Throw(pins);

            if (currentFrameIndex < FrameCount - 1 && (frame.GetThrowCount == MaxBalls || frame.Score() >= MaxPins))
                currentFrameIndex++;
        }

        public string ScoreBoard()
        {
            var scoreboard = new StringBuilder();
            var score = 0;

            for (int i = 0; i < FrameCount; i++)
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
