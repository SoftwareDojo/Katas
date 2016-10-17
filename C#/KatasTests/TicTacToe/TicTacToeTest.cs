using Xunit;
using Katas.TicTacToe;

namespace KatasTests.TicTacToe
{
    public class TicTacToeTest
    {
        private const char s_E = '0';
        private const char s_X = 'X';
        private const char s_O = 'O';

        [Theory]
        [InlineData(new[] { s_X, s_X, s_X, s_E, s_E, s_E, s_E, s_E, s_E })]
        [InlineData(new[] { s_E, s_E, s_E, s_X, s_X, s_X, s_E, s_E, s_E })]
        [InlineData(new[] { s_E, s_E, s_E, s_E, s_E, s_E, s_X, s_X, s_X })]
        [InlineData(new[] { s_X, s_E, s_E, s_X, s_E, s_E, s_X, s_E, s_E })]
        [InlineData(new[] { s_E, s_X, s_E, s_E, s_X, s_E, s_E, s_X, s_E })]
        [InlineData(new[] { s_E, s_E, s_X, s_E, s_E, s_X, s_E, s_E, s_X })]
        [InlineData(new[] { s_X, s_E, s_E, s_E, s_X, s_E, s_E, s_E, s_X })]
        [InlineData(new[] { s_E, s_E, s_X, s_E, s_X, s_E, s_X, s_E, s_E })]
        public void PlayerWins(char[] cells)
        {
            // arrange
            var players = new[]
            {
                new Player("Player 1", s_X),
                new Player("Player 2", s_O)
            };

            var ttt = new TicTacToeGame(new MockConsole(), cells, players);

            // act
            bool result = ttt.PlayerWins(s_X);

            // assert
            Assert.True(result);
        }

        [Fact]
        public void IsDraw()
        {
            // arrange
            var players = new[]
            {
                new Player("Player 1", s_X),
                new Player("Player 2", s_O)
            };

            var cells = new[] { s_X, s_X, s_X, s_O, s_O, s_O, s_X, s_X, s_X };

            var ttt = new TicTacToeGame(new MockConsole(), cells, players);

            // act
            bool result = ttt.IsDraw();

            // assert
            Assert.True(result);
        }
    }
}
