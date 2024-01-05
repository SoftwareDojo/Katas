using System.Collections.Generic;
using Katas;
using Xunit;

namespace KatasTests
{
    public class PokerTests
    {
        [Fact]
        public void IsRoyalFlush()
        {
            var hand = new List<PokerCard>
            {
                new (Suit.Spades, Rank.Ten),
                new (Suit.Spades, Rank.Jack),
                new (Suit.Spades, Rank.Queen),
                new (Suit.Spades, Rank.King),
                new (Suit.Spades, Rank.Ace),
            };

            Assert.Equal(PokerHandRank.RoyalFlush, new Poker().EvaluateHand(hand));
        }

        [Fact]
        public void IsStraightFlush()
        {
            var hand = new List<PokerCard>
            {
                new (Suit.Hearts, Rank.Ten),
                new (Suit.Hearts, Rank.Nine),
                new (Suit.Hearts, Rank.Eight),
                new (Suit.Hearts, Rank.Seven),
                new (Suit.Hearts, Rank.Six),
            };

            Assert.Equal(PokerHandRank.StraightFlush, new Poker().EvaluateHand(hand));
        }

        [Fact]
        public void IsMaxStraight()
        {
            var hand = new List<PokerCard>
            {
                new (Suit.Hearts, Rank.Ace),
                new (Suit.Clubs, Rank.King),
                new (Suit.Spades, Rank.Queen),
                new (Suit.Diamonds, Rank.Jack),
                new (Suit.Hearts, Rank.Ten),
            };

            Assert.Equal(PokerHandRank.Straight, new Poker().EvaluateHand(hand));
        }

        [Fact]
        public void IsMinStraight()
        {
            var hand = new List<PokerCard>
            {
                new (Suit.Hearts, Rank.Ace),
                new (Suit.Clubs, Rank.Two),
                new (Suit.Spades, Rank.Three),
                new (Suit.Diamonds, Rank.Four),
                new (Suit.Hearts, Rank.Five),
            };

            Assert.Equal(PokerHandRank.Straight, new Poker().EvaluateHand(hand));
        }

        [Fact]
        public void IsFlush()
        {
            var hand = new List<PokerCard>
            {
                new (Suit.Hearts, Rank.Ace),
                new (Suit.Hearts, Rank.Ten),
                new (Suit.Hearts, Rank.Five),
                new (Suit.Hearts, Rank.Eight),
                new (Suit.Hearts, Rank.Three),
            };

            Assert.Equal(PokerHandRank.Flush, new Poker().EvaluateHand(hand));
        }

        [Fact]
        public void IsHighCard()
        {
            var hand = new List<PokerCard>
            {
                new (Suit.Hearts, Rank.Ace),
                new (Suit.Clubs, Rank.Ten),
                new (Suit.Spades, Rank.Five),
                new (Suit.Diamonds, Rank.Eight),
                new (Suit.Hearts, Rank.Three),
            };

            Assert.Equal(PokerHandRank.HighCard, new Poker().EvaluateHand(hand));
        }

        [Fact]
        public void IsOnePair()
        {
            var hand = new List<PokerCard>
            {
                new (Suit.Hearts, Rank.Ace),
                new (Suit.Clubs, Rank.Ace),
                new (Suit.Spades, Rank.Five),
                new (Suit.Diamonds, Rank.Eight),
                new (Suit.Hearts, Rank.Three),
            };

            Assert.Equal(PokerHandRank.OnePair, new Poker().EvaluateHand(hand));
        }

        [Fact]
        public void IsTwoPair()
        {
            var hand = new List<PokerCard>
            {
                new (Suit.Hearts, Rank.Ace),
                new (Suit.Clubs, Rank.Ace),
                new (Suit.Spades, Rank.Five),
                new (Suit.Diamonds, Rank.Five),
                new (Suit.Hearts, Rank.Three),
            };

            Assert.Equal(PokerHandRank.TwoPair, new Poker().EvaluateHand(hand));
        }

        [Fact]
        public void IsThreeOfAKind()
        {
            var hand = new List<PokerCard>
            {
                new (Suit.Hearts, Rank.Ace),
                new (Suit.Clubs, Rank.Ace),
                new (Suit.Spades, Rank.Ace),
                new (Suit.Diamonds, Rank.Five),
                new (Suit.Hearts, Rank.Three),
            };

            Assert.Equal(PokerHandRank.ThreeOfAKind, new Poker().EvaluateHand(hand));
        }

        [Fact]
        public void IsFourOfAKind()
        {
            var hand = new List<PokerCard>
            {
                new (Suit.Hearts, Rank.Ace),
                new (Suit.Clubs, Rank.Ace),
                new (Suit.Spades, Rank.Ace),
                new (Suit.Diamonds, Rank.Ace),
                new (Suit.Hearts, Rank.Three),
            };

            Assert.Equal(PokerHandRank.FourOfAKind, new Poker().EvaluateHand(hand));
        }

        [Fact]
        public void IsFullHouse()
        {
            var hand = new List<PokerCard>
            {
                new (Suit.Hearts, Rank.Ace),
                new (Suit.Clubs, Rank.Ace),
                new (Suit.Spades, Rank.Five),
                new (Suit.Diamonds, Rank.Five),
                new (Suit.Hearts, Rank.Five),
            };

            Assert.Equal(PokerHandRank.FullHouse, new Poker().EvaluateHand(hand));
        }
    }
}
