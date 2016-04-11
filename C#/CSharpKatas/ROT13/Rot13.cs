using System.Collections.Generic;

namespace CSharpKatas.ROT13
{
    public class Rot13
    {
        private const int s_DefaultOffset = 13;
        private readonly IDictionary<int, int> m_EncodeTable;
        private readonly IDictionary<int, int> m_DecodeTable; 

        public Rot13() : this(s_DefaultOffset) { }

        public Rot13(int offset)
        {
            m_EncodeTable = new Dictionary<int, int>();
            m_DecodeTable = new Dictionary<int, int>();

            AddToTable('a', 'z', offset);
            AddToTable('A', 'Z', offset);    
        }

        private void AddToTable(int start, int end, int offset)
        {
            for (int i = start; i <= end; i++)
            {
                int index = i + offset;
                if (i > end - offset)
                {
                    index = i - (end - start) + offset -1;
                }

                m_EncodeTable.Add(i, index);
                m_DecodeTable.Add(index, i);
            }
        }

        public string Encode(string text)
        {
            return Translate(NormalizeText(text), m_EncodeTable);
        }

        public string Decode(string text)
        {
            return Translate(text, m_DecodeTable);
        }

        private string Translate(string text, IDictionary<int, int> table)
        {
            var chars = text.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (table.ContainsKey(chars[i]))
                {
                    chars[i] = (char)table[chars[i]];
                }
            }

            return new string(chars);
        }

        private string NormalizeText(string text)
        {
            text = text.Replace("ä", "ae");
            text = text.Replace("Ä", "Ae");
            text = text.Replace("ö", "oe");
            text = text.Replace("Ö", "Oe");
            text = text.Replace("ü", "ue");
            text = text.Replace("Ü", "Ue");
            text = text.Replace("ß", "ss");

            return text;
        }
    }
}
