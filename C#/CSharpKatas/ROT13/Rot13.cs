using System.Collections.Generic;

namespace CSharpKatas.ROT13
{
    public class Rot13
    {
        private readonly Dictionary<int, int> m_EncodeTable; 

        public Rot13()
        {
            m_EncodeTable = new Dictionary<int, int>();

            // numbers 
            //for (int i = 48; i < 58; i++)
            //{
            //    m_EncodeTable.Add(i, i+13);
            //}

            // abc
            for (int i = 97; i < 123; i++)
            {
                int index = i + 13;
                if (i > 108) index = i - 13;

                m_EncodeTable.Add(i, index);
            }
        }

        public string Encode(string text)
        {
            text = TextNormalize(text.ToLower());
            var chars = text.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (m_EncodeTable.ContainsKey(chars[i]))
                {
                    chars[i] = (char)m_EncodeTable[chars[i]];
                }
            }

            return new string(chars);
        }

        public string Decode(string text)
        {
            var chars = text.ToLower().ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (m_EncodeTable.ContainsKey(chars[i]))
                {
                    chars[i] = (char)m_EncodeTable[chars[i]];
                }
            }

            return new string(chars);
        }

        private string TextNormalize(string text)
        {
            text = text.Replace("ä", "ae");
            text = text.Replace("ö", "oe");
            text = text.Replace("ü", "ue");
            text = text.Replace("ß", "ss");

            return text;
        }
    }
}
