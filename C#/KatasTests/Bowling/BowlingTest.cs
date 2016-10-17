using Xunit;
using Katas.Bowling;

namespace KatasTests.Bowling
{
    public class BowlingTest
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 20)]
        [InlineData(2, 40)]
        [InlineData(3, 60)]
        [InlineData(4, 80)]
        public void Rolls20(int pins, int expected)
        {
            // arrange
            var bowling = new Game();

            // act
            for (int i = 0; i < 20; i++)
            {
                bowling.Throw(pins);
            }

            // assert
            Assert.Equal(expected, bowling.TotalScore());
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 10)]
        [InlineData(2, 20)]
        [InlineData(3, 30)]
        [InlineData(4, 40)]
        [InlineData(5, 50)]
        [InlineData(6, 60)]
        [InlineData(7, 70)]
        [InlineData(8, 80)]
        [InlineData(9, 90)]
        public void RollWithMiss(int pins, int expected)
        {
            // arrange
            var bowling = new Katas.Bowling.Game();

            // act
            for (int i = 0; i < 10; i++)
            {
                bowling.Throw(pins);
                bowling.Throw(0);
            }

            // assert
            Assert.Equal(expected, bowling.TotalScore());
        }

        [Theory]
        [InlineData(1, 110)]
        [InlineData(2, 120)]
        [InlineData(3, 130)]
        [InlineData(4, 140)]
        [InlineData(5, 150)]
        [InlineData(6, 160)]
        [InlineData(7, 170)]
        [InlineData(8, 180)]
        [InlineData(9, 190)]
        public void RollWithSpare(int pins, int expected)
        {
            // arrange
            var bowling = new Katas.Bowling.Game();

            // act
            for (int i = 0; i < 10; i++)
            {
                bowling.Throw(pins);
                bowling.Throw(10 - pins);
            }

            bowling.Throw(pins);

            // assert
            Assert.Equal(expected, bowling.TotalScore());
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 10)]
        [InlineData(2, 20)]
        [InlineData(3, 30)]
        [InlineData(4, 40)]
        [InlineData(5, 50)]
        [InlineData(6, 60)]
        [InlineData(7, 70)]
        [InlineData(8, 80)]
        [InlineData(9, 90)]
        public void MissWithRoll(int pins, int expected)
        {
            // arrange
            var bowling = new Katas.Bowling.Game();

            // act
            for (int i = 0; i < 10; i++)
            {
                bowling.Throw(0);
                bowling.Throw(pins);
            }

            // assert
            Assert.Equal(expected, bowling.TotalScore());
        }

        [Theory]
        [InlineData(0, 10)]
        [InlineData(1, 9)]
        [InlineData(2, 8)]
        [InlineData(3, 7)]
        [InlineData(4, 6)]
        [InlineData(5, 5)]
        public void Spare(int pins1, int pins2)
        {
            // arrange
            var bowling = new Katas.Bowling.Game();

            // act
            bowling.Throw(pins1);
            bowling.Throw(pins2);
            bowling.Throw(3);

            // assert
            Assert.Equal(16, bowling.TotalScore());
        }

        [Fact]
        public void Strike()
        {
            // arrange
            var bowling = new Katas.Bowling.Game();

            // act
            bowling.Throw(10);
            bowling.Throw(3);
            bowling.Throw(4);

            // assert
            Assert.Equal(24, bowling.TotalScore());
        }

        [Fact]
        public void PerfectGame()
        {
            // arrange
            var bowling = new Katas.Bowling.Game();

            // act
            for (int i = 0; i < 12; i++)
            {
                bowling.Throw(10);
            }

            // assert
            Assert.Equal(300, bowling.TotalScore());
        }

        [Fact]
        public void Scoring_Spare()
        {
            // arrange
            var bowling = new Katas.Bowling.Game();
            bowling.Throw(9);
            bowling.Throw(1);

            // act
            var score = bowling.TotalScore();
            var scoreBoard = bowling.ScoreBoard();

            // assert
            Assert.Equal(10, score);
            Assert.True(scoreBoard.StartsWith("Frame 1: 10 = 9 /"));
        }

        [Fact]
        public void Scoring_Strike()
        {
            // arrange
            var bowling = new Katas.Bowling.Game();
            bowling.Throw(10);

            // act
            var score = bowling.TotalScore();
            var scoreBoard = bowling.ScoreBoard();

            // assert
            Assert.Equal(10, score);
            Assert.True(scoreBoard.StartsWith("Frame 1: 10 = X"));
        }

        [Fact]
        public void ScoreBoard_PerfectGame()
        {
            // arrange
            var bowling = new Katas.Bowling.Game();

            for (int i = 0; i < 12; i++)
            {
                bowling.Throw(10);
            }

            // act and assert
            Assert.True(bowling.ScoreBoard().Contains("Frame 10: 300 = X X X"));
        }

        [Fact]
        public void Sample_Game()
        {
            // arrange
            var bowling = new Katas.Bowling.Game();

            // act
            bowling.Throw(1);
            Assert.Equal(1, bowling.Frames[0].Score());
            bowling.Throw(4);
            Assert.Equal(5, bowling.Frames[0].Score());

            bowling.Throw(4);
            Assert.Equal(4, bowling.Frames[1].Score());
            bowling.Throw(5);
            Assert.Equal(9, bowling.Frames[1].Score());

            bowling.Throw(6);
            Assert.Equal(6, bowling.Frames[2].Score());
            bowling.Throw(4);
            Assert.Equal(10, bowling.Frames[2].Score());

            bowling.Throw(5);
            Assert.Equal(15, bowling.Frames[2].Score());
            Assert.Equal(5, bowling.Frames[3].Score());
            bowling.Throw(5);
            Assert.Equal(15, bowling.Frames[2].Score());
            Assert.Equal(10, bowling.Frames[3].Score());

            bowling.Throw(10);
            Assert.Equal(20, bowling.Frames[3].Score());
            Assert.Equal(10, bowling.Frames[4].Score());

            bowling.Throw(0);
            Assert.Equal(10, bowling.Frames[4].Score());
            Assert.Equal(0, bowling.Frames[5].Score());
            bowling.Throw(1);
            Assert.Equal(11, bowling.Frames[4].Score());
            Assert.Equal(1, bowling.Frames[5].Score());

            bowling.Throw(7);
            Assert.Equal(7, bowling.Frames[6].Score());
            bowling.Throw(3);
            Assert.Equal(10, bowling.Frames[6].Score());

            bowling.Throw(6);
            Assert.Equal(16, bowling.Frames[6].Score());
            Assert.Equal(6, bowling.Frames[7].Score());
            bowling.Throw(4);
            Assert.Equal(10, bowling.Frames[7].Score());

            bowling.Throw(10);
            Assert.Equal(20, bowling.Frames[7].Score());
            Assert.Equal(10, bowling.Frames[8].Score());

            bowling.Throw(2);
            Assert.Equal(12, bowling.Frames[8].Score());
            Assert.Equal(2, bowling.Frames[9].Score());
            bowling.Throw(8);
            Assert.Equal(20, bowling.Frames[8].Score());
            Assert.Equal(10, bowling.Frames[9].Score());
            bowling.Throw(6);
            Assert.Equal(20, bowling.Frames[8].Score());
            Assert.Equal(16, bowling.Frames[9].Score());

            // assert
            Assert.Equal(133, bowling.TotalScore());
        }
    }
}
