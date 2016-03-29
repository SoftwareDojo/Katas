using System.Collections.Generic;
using System.Linq;

namespace CSharpKatas.ABC
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

        public bool CheckWord(string word)
        {
            var myBlocks = new List<string>(m_Blocks);

            foreach (char letter in word)
            {
                char lowerLetter = char.ToLower(letter);

                string block = myBlocks.FirstOrDefault(b => b.Contains(lowerLetter));
                if (!string.IsNullOrEmpty(block))
                {
                    myBlocks.Remove(block);
                }
                else return false;
            }

            return true;
        }
    }
}
