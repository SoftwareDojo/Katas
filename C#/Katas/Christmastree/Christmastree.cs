using System;
using System.Collections.Generic;

namespace Katas
{
    public class Christmastree
    {
        private const string Space = " ";
        private const string X = "X";
        private const string Star = "*";

        public static string Draw(int height)
        {
            return CreateTree(new List<string>(), height, 0);
        }

        public static string DrawWithStar(int height)
        {
            var tree = new List<string> {CreateSymbols(CreateIndent(height - 1, 0), Star, 0)};
            return CreateTree(tree, height, 1);
        }

        private static string CreateTree(IList<string> tree, int height, int insertIndex)
        {
            tree.Add(CreateSymbols(CreateIndent(height - 1, 0), X, 0));

            for (int i = height - 1; i > 0; i--)
            {
                tree.Insert(insertIndex + 1, CreateSymbols(CreateIndent(height - 1, i), X, i));
            }

            tree.Add(CreateSymbols(CreateIndent(height - 1, 0), X, 0));
            return string.Join(Environment.NewLine, tree);
        }

        private static string CreateIndent(int height, int position)
        {
            string indent = string.Empty;
            for (int j = position; j < height; j++) indent += Space;
            return indent;
        }

        private static string CreateSymbols(string source, string symbole, int position)
        {
            for (int j = 0; j < position * 2 + 1; j++) source += symbole;
            return source;
        }
    }
}
