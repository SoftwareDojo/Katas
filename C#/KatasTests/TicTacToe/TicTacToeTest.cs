using Katas.TicTacToe;
using Moq;
using Xunit;

namespace KatasTests.TicTacToe
{
    public class TicTacToeTest
    {
        private const char s_E = '0';
        private const char s_X = 'X';
        private const char s_O = 'O';
        private readonly Player[] players = new[]
            {
                new Player("Player 1", s_X),
                new Player("Player 2", s_O),
            };

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
            Assert.True(new TicTacToeGame(new Mock<IUserInterface>().Object, cells, players).PlayerWins(s_X));
        }

        [Theory]
        [InlineData(new[] { s_X, s_X, s_X, s_O, s_O, s_O, s_X, s_X, s_X  })]
        public void IsDraw(char[] cells)
        {
            Assert.True(new TicTacToeGame(new Mock<IUserInterface>().Object, cells, players).IsDraw());
        }
    }
}
