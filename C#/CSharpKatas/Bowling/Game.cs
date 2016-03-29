using System.Collections.Generic;
using System.Linq;

namespace CSharpKatas.Bowling
{
    public class Game
    {
        public IList<Frame> Frames { get; }

        public Game()
        {
            Frames = new List<Frame>();
        }

        public void Roll(int pins)
        {
            var frame = GetCurrentFrame();

            if (Frames.Count != 10 &&
                (frame == null || frame.Rolls.Count() == 2 || frame.Score() >= 10))
            {
                var newframe = CreateFrame();
                if (frame != null) frame.NextFrame = newframe;
                frame = newframe;
            }

            frame.Roll(pins);
        }

        public string ScoreBoard()
        {
            return string.Empty;
        }

        public int TotalScore()
        {
            return Frames.Sum(f => f.Score());
        }

        private Frame GetCurrentFrame()
        {
            int frameCount = Frames.Count;
            return frameCount == 0 ? null : Frames[frameCount - 1];
        }

        private Frame CreateFrame()
        {
            var frame = new Frame(Frames.Count);
            Frames.Add(frame);
            return frame;
        }
    }
}
