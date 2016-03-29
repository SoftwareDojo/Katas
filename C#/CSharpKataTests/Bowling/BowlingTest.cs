using CSharpKatas.Bowling;
using NUnit.Framework;

namespace CSharpKataTests.Bowling
{
    [TestFixture]
    public class BowlingTest
    {
        [TestCase(0, 0)]
        [TestCase(1, 20)]
        [TestCase(2, 40)]
        [TestCase(3, 60)]
        [TestCase(4, 80)]
        public void Rolls20(int pins, int expected)
        {
            // arrange
            var bowling = new Game();

            // act
            for (int i = 0; i < 20; i++)
            {
                bowling.Roll(pins);
            }

            // assert
            Assert.AreEqual(expected, bowling.TotalScore());
        }

        [TestCase(0, 0)]
        [TestCase(1, 10)]
        [TestCase(2, 20)]
        [TestCase(3, 30)]
        [TestCase(4, 40)]
        [TestCase(5, 50)]
        [TestCase(6, 60)]
        [TestCase(7, 70)]
        [TestCase(8, 80)]
        [TestCase(9, 90)]
        public void RollWithMiss(int pins, int expected)
        {
            // arrange
            var bowling = new Game();

            // act
            for (int i = 0; i < 10; i++)
            {
                bowling.Roll(pins);
                bowling.Roll(0);
            }

            // assert
            Assert.AreEqual(expected, bowling.TotalScore());
        }

        [TestCase(1, 110)]
        [TestCase(2, 120)]
        [TestCase(3, 130)]
        [TestCase(4, 140)]
        [TestCase(5, 150)]
        [TestCase(6, 160)]
        [TestCase(7, 170)]
        [TestCase(8, 180)]
        [TestCase(9, 190)]
        public void RollWithSpare(int pins, int expected)
        {
            // arrange
            var bowling = new Game();

            // act
            for (int i = 0; i < 10; i++)
            {
                bowling.Roll(pins);
                bowling.Roll(10-pins);
            }

            bowling.Roll(pins);

            // assert
            Assert.AreEqual(expected, bowling.TotalScore());
        }

        [TestCase(0, 0)]
        [TestCase(1, 10)]
        [TestCase(2, 20)]
        [TestCase(3, 30)]
        [TestCase(4, 40)]
        [TestCase(5, 50)]
        [TestCase(6, 60)]
        [TestCase(7, 70)]
        [TestCase(8, 80)]
        [TestCase(9, 90)]
        public void MissWithRoll(int pins, int expected)
        {
            // arrange
            var bowling = new Game();

            // act
            for (int i = 0; i < 10; i++)
            {
                bowling.Roll(0);
                bowling.Roll(pins);
            }

            // assert
            Assert.AreEqual(expected, bowling.TotalScore());
        }

        [TestCase(0, 10)]
        [TestCase(1, 9)]
        [TestCase(2, 8)]
        [TestCase(3, 7)]
        [TestCase(4, 6)]
        [TestCase(5, 5)]
        public void Spare(int pins1, int pins2)
        {
            // arrange
            var bowling = new Game();

            // act
            bowling.Roll(pins1);
            bowling.Roll(pins2);
            bowling.Roll(3);

            // assert
            Assert.AreEqual(16, bowling.TotalScore());
        }

        [Test]
        public void Strike()
        {
            // arrange
            var bowling = new Game();

            // act
            bowling.Roll(10);
            bowling.Roll(3);
            bowling.Roll(4);

            // assert
            Assert.AreEqual(24, bowling.TotalScore());
        }

        [Test]
        public void PerfectGame()
        {
            // arrange
            var bowling = new Game();

            // act
            for (int i = 0; i < 12; i++)
            {
                bowling.Roll(10);
            }

            // assert
            Assert.AreEqual(300, bowling.TotalScore());
        }

        [Test]
        public void Sample_Game()
        {
            // arrange
            var bowling = new Game();

            // act
            bowling.Roll(1);
            Assert.AreEqual(1, bowling.Frames[0].Score());
            bowling.Roll(4);
            Assert.AreEqual(5, bowling.Frames[0].Score());

            bowling.Roll(4);
            Assert.AreEqual(4, bowling.Frames[1].Score());
            bowling.Roll(5);
            Assert.AreEqual(9, bowling.Frames[1].Score());

            bowling.Roll(6);
            Assert.AreEqual(6, bowling.Frames[2].Score());
            bowling.Roll(4);
            Assert.AreEqual(10, bowling.Frames[2].Score());

            bowling.Roll(5);
            Assert.AreEqual(15, bowling.Frames[2].Score());
            Assert.AreEqual(5, bowling.Frames[3].Score());
            bowling.Roll(5);
            Assert.AreEqual(15, bowling.Frames[2].Score());
            Assert.AreEqual(10, bowling.Frames[3].Score());

            bowling.Roll(10);
            Assert.AreEqual(20, bowling.Frames[3].Score());
            Assert.AreEqual(10, bowling.Frames[4].Score());

            bowling.Roll(0);
            Assert.AreEqual(10, bowling.Frames[4].Score());
            Assert.AreEqual(0, bowling.Frames[5].Score());
            bowling.Roll(1);
            Assert.AreEqual(11, bowling.Frames[4].Score());
            Assert.AreEqual(1, bowling.Frames[5].Score());

            bowling.Roll(7);
            Assert.AreEqual(7, bowling.Frames[6].Score());
            bowling.Roll(3);
            Assert.AreEqual(10, bowling.Frames[6].Score());

            bowling.Roll(6);
            Assert.AreEqual(16, bowling.Frames[6].Score());
            Assert.AreEqual(6, bowling.Frames[7].Score());
            bowling.Roll(4);
            Assert.AreEqual(10, bowling.Frames[7].Score());

            bowling.Roll(10);
            Assert.AreEqual(20, bowling.Frames[7].Score());
            Assert.AreEqual(10, bowling.Frames[8].Score());

            bowling.Roll(2);
            Assert.AreEqual(12, bowling.Frames[8].Score());
            Assert.AreEqual(2, bowling.Frames[9].Score());
            bowling.Roll(8);
            Assert.AreEqual(20, bowling.Frames[8].Score());
            Assert.AreEqual(10, bowling.Frames[9].Score());
            bowling.Roll(6);
            Assert.AreEqual(20, bowling.Frames[8].Score());
            Assert.AreEqual(16, bowling.Frames[9].Score());

            // assert
            Assert.AreEqual(133, bowling.TotalScore());
        }
    }
}
