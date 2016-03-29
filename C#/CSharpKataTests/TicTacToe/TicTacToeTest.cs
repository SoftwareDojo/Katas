using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpKatas.TicTacToe.Refactoring;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace CSharpKataTests.TicTacToe
{
    [TestFixture]
    public class TicTacToeTest
    {
        private const char s_E = CSharpKatas.TicTacToe.TicTacToe.EmptyCell;
        private const char s_X = 'X';
        private const char s_O = 'O';

        [TestCase(new[] { s_X, s_X, s_X, s_E, s_E, s_E, s_E, s_E, s_E })]
        [TestCase(new[] { s_E, s_E, s_E, s_X, s_X, s_X, s_E, s_E, s_E })]
        [TestCase(new[] { s_E, s_E, s_E, s_E, s_E, s_E, s_X, s_X, s_X })]
        [TestCase(new[] { s_X, s_E, s_E, s_X, s_E, s_E, s_X, s_E, s_E })]
        [TestCase(new[] { s_E, s_X, s_E, s_E, s_X, s_E, s_E, s_X, s_E })]
        [TestCase(new[] { s_E, s_E, s_X, s_E, s_E, s_X, s_E, s_E, s_X })]
        [TestCase(new[] { s_X, s_E, s_E, s_E, s_X, s_E, s_E, s_E, s_X })]
        [TestCase(new[] { s_E, s_E, s_X, s_E, s_X, s_E, s_X, s_E, s_E })]
        public void PlayerWins(char[] cells)
        {
            // arrange
            var players = new[]
            {
                new Player("Player 1", s_X),
                new Player("Player 2", s_O)
            };

            var ttt = new CSharpKatas.TicTacToe.TicTacToe(new MockConsole(), cells, players);

            // act
            bool result = ttt.PlayerWins(s_X);

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsDraw()
        {
            // arrange
            var players = new[]
            {
                new Player("Player 1", s_X),
                new Player("Player 2", s_O)
            };

            var cells = new[] { s_X, s_X, s_X, s_O, s_O, s_O, s_X, s_X, s_X };

            var ttt = new CSharpKatas.TicTacToe.TicTacToe(new MockConsole(), cells, players);

            // act
            bool result = ttt.IsDraw();

            // assert
            Assert.IsTrue(result);
        }
    }

    public class MockConsole : IConsole
    {
        public void WriteLine(string text) { }

        public string ReadLine()
        {
            return string.Empty;
        }

        public void Clear() { }
    }
}
