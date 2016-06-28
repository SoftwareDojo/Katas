using System.Linq;

namespace CSharpKatas.MineField
{
    public class MineField
    {
        private const char s_NewLine = ';';
        private const int s_MineValue = -1;

        public string CreateHint(string mines)
        {
            if (string.IsNullOrEmpty(mines)) return string.Empty;
            var hint = CreateHintField(mines);

            for (int x = 0; x < hint.Length; x++)
            {
                for (int y = 0; y < hint[x].Length; y++)
                {
                    if (!IsMineField(hint[x][y])) continue;

                    UpdateField(x, y - 1, hint);
                    UpdateField(x, y + 1, hint);

                    UpdateField(x - 1, y, hint);
                    UpdateField(x + 1, y , hint);

                    UpdateField(x - 1, y - 1, hint);
                    UpdateField(x - 1, y + 1, hint);

                    UpdateField(x + 1, y - 1, hint);
                    UpdateField(x + 1, y + 1, hint);
                }
            }

            return ShowHintField(hint);
        }

        private bool IsMineField(int field)
        {
            return field == s_MineValue;
        }

        private void UpdateField(int x, int y, int[][] hint)
        {
            if (x >= hint.Length || x < 0) return;
            if (y >= hint[x].Length || y < 0) return;
            if (IsMineField(hint[x][y])) return;

            hint[x][y] += 1;
        }

        private int[][] CreateHintField(string mines)
        {
            var mineLines = mines.Split(s_NewLine);
            int[][] result = new int[mineLines.Length][];

            for (int x = 0; x < mineLines.Length; x++)
            {
                result[x] = new int[mineLines[x].Length];

                for (int y = 0; y < mineLines[x].Length; y++)
                {
                    if (mineLines[x][y] == '*') result[x][y] = s_MineValue;
                    else result[x][y] = 0;
                }
            }

            return result;
        }

        private string ShowHintField(int[][] hint)
        {
            string result = hint.Aggregate(string.Empty, (s, f) => s + (string.Join("", f).Replace("-1", "*") + s_NewLine));
            return result.Substring(0, result.Length - 1);
        }
    }
}
