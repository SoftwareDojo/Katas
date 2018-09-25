using System.IO;
using System.Linq;

using Katas.Maze;
using Xunit;

namespace KatasTests.Maze
{
    public class MazeSolverTests
    {
        [Fact]
        public void StartPosition_NotDefined()
        {
            // act & assert
            Assert.Throws<InvalidDataException>(() => new MazeSolver().Solve(new[]{"E"}));
        }

        [Fact]
        public void EndPosition_NoDefined()
        {
            // act & assert
            Assert.Throws<InvalidDataException>(() => new MazeSolver().Solve(new[]{"S"}));
        }

        [Fact]
        public void Move_Right()
        {
            // arrange
            var solver = new MazeSolver();
            // act
            var actual = solver.Solve(new[]{"S 0 0 E"});
            // assert
            Assert.Equal("S X X E", actual[0]);
        }

        [Fact]
        public void Move_Left()
        {
            // arrange
            var solver = new MazeSolver();
            // act
            var actual = solver.Solve(new[]{"E 0 0 S"});
            // assert
            Assert.Equal("E X X S", actual[0]);
        }

        [Fact]
        public void Move_Down()
        {
            // arrange
            var solver = new MazeSolver();
            // act
            var actual = solver.Solve(new[]{"S","0","0","E"});
            // assert
            Assert.Equal("S", actual[0]);
            Assert.Equal("X", actual[1]);
            Assert.Equal("X", actual[2]);
            Assert.Equal("E", actual[3]);
        }

        [Fact]
        public void Move_Up()
        {
            // arrange
            var solver = new MazeSolver();
            // act
            var actual = solver.Solve(new[]{"E","0","0","S"});
            // assert
            Assert.Equal("E", actual[0]);
            Assert.Equal("X", actual[1]);
            Assert.Equal("X", actual[2]);
            Assert.Equal("S", actual[3]);
        }

        [Theory]
        //[InlineData("S 0 0,0 0 0,0 0 E", "S X X,0 0 X,0 0 E")]
        //[InlineData("S 0 0,0 E 0,0 0 0", "S X 0,0 E 0,0 0 0")]
        [InlineData("E 0 0,0 0 0,0 0 S", "E 0 0,X 0 0,X X S")]
        public void Move_Diagonal(string maze, string expected)
        {
            // arrange
            var solver = new MazeSolver();
            // act
            var actual = solver.Solve(maze.Split(","));
            // assert
            Assert.True(actual.SequenceEqual(expected.Split(",")), string.Join(",", actual));
        }

        [Theory]
        [InlineData("S 0 0,0 0 0,0 0 E", "S X X,0 0 X,0 0 E")]
        public void Move_Simple_Walls(string maze, string expected)
        {
            // arrange
            var solver = new MazeSolver();
            // act
            var actual = solver.Solve(maze.Split(","));
            // assert
            Assert.True(actual.SequenceEqual(expected.Split(",")), string.Join(",", actual));
        }
    }
}
