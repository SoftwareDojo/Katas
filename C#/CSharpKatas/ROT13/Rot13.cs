using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpKatas.ROT13
{
    public class Rot13
    {
        private readonly char[] m_CharTable;

        public Rot13()
        {
            m_CharTable = new char[char.MaxValue];

            for (int i = 48; i < 58; i++)
            {
                m_CharTable[i-48] = (char)i;
            }

            // 48 - 57 (numbers) / 65 - 90 (letters)

            for (int i = 65; i < 91; i++)
            {
                m_CharTable[i] = (char)i;
            }
        }

    }


}
