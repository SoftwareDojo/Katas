using System.Collections.Generic;
using System.Linq;

namespace Katas.ABC
{
    public class ABCProblem
    {
        private readonly IEnumerable<string> m_Blocks;

        public ABCProblem()
        {
            m_Blocks = new List<string>
            {
                "bo", "xk", "dq",
                "cp", "na", "gt",
                "re", "tg", "qd",
                "fs", "jw", "hu",
                "vi", "an", "ob",
                "er", "fs", "ly",
                "pc", "zm"
            };
        }

        public ABCProblem(IEnumerable<string> blocks)
        {
            m_Blocks = blocks;
        }

        public bool IsPossible(string word)
        {
            var blocks = new List<string>(m_Blocks);

            foreach (var letter in word)
            {
                var lowerLetter = char.ToLower(letter);

                var block = blocks.FirstOrDefault(b => b.Contains(lowerLetter));
                if (!string.IsNullOrEmpty(block))
                {
                    blocks.Remove(block);
                }
                else return false;
            }

            return true;
        }
    }
}
