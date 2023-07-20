using System.Collections.Generic;
using System.Linq;

namespace Katas
{
    public class ABCProblem
    {
        private readonly IEnumerable<string> blocks;

        public ABCProblem()
        {
            blocks = new List<string>
            {
                "bo", "xk", "dq",
                "cp", "na", "gt",
                "re", "tg", "qd",
                "fs", "jw", "hu",
                "vi", "an", "ob",
                "er", "fs", "ly",
                "pc", "zm",
            };
        }

        public ABCProblem(IEnumerable<string> blocks)
        {
            this.blocks = blocks;
        }

        public bool IsPossible(string word)
        {
            var copyBlocks = new List<string>(blocks);

            foreach (var letter in word)
            {
                if (!IsLetterAvailable(copyBlocks, letter, out string block)) return false;

                copyBlocks.Remove(block);
            }

            return true;
        }

        private bool IsLetterAvailable(List<string> blocks, char letter, out string block)
        {
            var lowerLetter = char.ToLower(letter);

            block = blocks.FirstOrDefault(b => b.Contains(lowerLetter));

            return !string.IsNullOrEmpty(block);
        }
    }
}
