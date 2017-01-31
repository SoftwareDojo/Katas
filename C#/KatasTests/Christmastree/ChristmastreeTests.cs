using Xunit;

namespace KatasTests.Christmastree
{
    public class ChristmastreeTests
    {
        private const string Tree5 = "    X\r\n   XXX\r\n  XXXXX\r\n XXXXXXX\r\nXXXXXXXXX\r\n    X";
        private const string Tree3 = "  X\r\n XXX\r\nXXXXX\r\n  X";
        private const string Tree1 = "X\r\nX";
        private const string TreeStar1 = "*\r\n" + Tree1;
        private const string TreeStar3 = "  *\r\n" + Tree3;
        private const string TreeStar5 = "    *\r\n" + Tree5;

        [Theory]
        [InlineData(5, Tree5)]
        [InlineData(3, Tree3)]
        [InlineData(1, Tree1)]
        public void Draw_Tree(int height, string expected)
        {
            // arrange
            var tree = new Katas.Christmastree.Christmastree();

            // act
            var actual = tree.Draw(height);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(5, TreeStar5)]
        [InlineData(3, TreeStar3)]
        [InlineData(1, TreeStar1)]
        public void Draw_Tree_With_Star(int height, string expected)
        {
            // arrange
            var tree = new Katas.Christmastree.Christmastree();

            // act
            var actual = tree.DrawWithStar(height);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
