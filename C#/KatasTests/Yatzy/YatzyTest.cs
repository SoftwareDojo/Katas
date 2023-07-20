using System;
using Xunit;
using Katas.Yatzy;

namespace KatasTests.Yatzy
{
    public class YatzyTest
    {
        [Theory]
        [InlineData(new[] { 2, 3, 4, 5, 1 }, 15)]
        [InlineData(new[] { 3, 3, 4, 5, 1 }, 16)]
        public void Chance_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, new YatzyScorer().Chance);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 1)]
        [InlineData(new[] { 1, 2, 1, 4, 5 }, 2)]
        [InlineData(new[] { 6, 2, 2, 4, 5 }, 0)]
        [InlineData(new[] { 1, 2, 1, 1, 1 }, 4)]
        public void Ones_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, new YatzyScorer().Ones);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 2, 6 }, 4)]
        [InlineData(new[] { 2, 2, 2, 2, 2 }, 10)]
        public void Twos_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, new YatzyScorer().Twos);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 2, 3 }, 6)]
        [InlineData(new[] { 2, 3, 3, 3, 3 }, 12)]
        public void Threes_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, new YatzyScorer().Threes);
        }

        [Theory]
        [InlineData(new[] { 4, 5, 5, 5, 5 }, 4)]
        [InlineData(new[] { 4, 4, 5, 5, 5 }, 8)]
        [InlineData(new[] { 4, 4, 4, 5, 5 }, 12)]
        public void Fours_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, new YatzyScorer().Fours);
        }

        [Theory]
        [InlineData(new[] { 4, 4, 4, 5, 5 }, 10)]
        [InlineData(new[] { 4, 4, 5, 5, 5 }, 15)]
        [InlineData(new[] { 4, 5, 5, 5, 5 }, 20)]
        public void Fives_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, new YatzyScorer().Fives);
        }

        [Theory]
        [InlineData(new[] { 4, 4, 4, 5, 5 }, 0)]
        [InlineData(new[] { 4, 4, 6, 5, 5 }, 6)]
        [InlineData(new[] { 6, 5, 6, 6, 5 }, 18)]
        public void Sixes_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, new YatzyScorer().Sixes);
        }

        [Theory]
        [InlineData(new[] { 6, 6, 6, 6, 3 }, 0)]
        [InlineData(new[] { 4, 4, 4, 4, 4 }, 50)]
        [InlineData(new[] { 6, 6, 6, 6, 6 }, 50)]
        public void Yatzy_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, new YatzyScorer().Yatzy);
        }

        [Theory]
        [InlineData(new[] { 3, 4, 2, 5, 6 }, 0)]
        [InlineData(new[] { 3, 4, 3, 5, 6 }, 6)]
        [InlineData(new[] { 5, 3, 3, 3, 5 }, 10)]
        [InlineData(new[] { 5, 3, 6, 6, 5 }, 12)]
        [InlineData(new[] { 6, 6, 6, 6, 5 }, 12)]
        public void OnePair_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, new YatzyScorer().OnePair);
        }

        [Theory]
        [InlineData(new[] { 3, 4, 2, 5, 5 }, 0)]
        [InlineData(new[] { 3, 3, 5, 5, 5 }, 16)]
        [InlineData(new[] { 3, 3, 5, 4, 5 }, 16)]
        public void TwoPair_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, new YatzyScorer().TwoPair);
        }

        [Theory]
        [InlineData(new[] { 3, 3, 3, 4, 5 }, 9)]
        [InlineData(new[] { 3, 3, 3, 3, 5 }, 9)]
        [InlineData(new[] { 5, 3, 5, 4, 5 }, 15)]
        public void ThreeOfAKind_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, new YatzyScorer().ThreeOfAKind);
        }

        [Theory]
        [InlineData(new[] { 3, 3, 3, 3, 5 }, 12)]
        [InlineData(new[] { 3, 3, 3, 3, 3 }, 12)]
        [InlineData(new[] { 5, 5, 5, 4, 5 }, 20)]
        public void FourOfAKind_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, new YatzyScorer().FourOfAKind);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 2, 4, 5 }, 0)]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 15)]
        [InlineData(new[] { 2, 3, 4, 5, 1 }, 15)]
        public void SmallStraight_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, new YatzyScorer().SmallStraight);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 2, 4, 5 }, 0)]
        [InlineData(new[] { 2, 3, 4, 5, 6 }, 20)]
        [InlineData(new[] { 6, 2, 3, 4, 5 }, 20)]
        public void LargeStraight_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, new YatzyScorer().LargeStraight);
        }

        [Theory]
        [InlineData(new[] { 2, 3, 4, 5, 6 }, 0)]
        [InlineData(new[] { 5, 5, 5, 5, 6 }, 0)]
        [InlineData(new[] { 6, 2, 2, 2, 6 }, 18)]
        public void FullHouse_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, new YatzyScorer().FullHouse);
        }

        private void AreEqual(int[] dice, int expected, Func<int[], int> scoreAction)
        {
            Assert.Equal(expected, scoreAction(dice));
        }
    }
}
