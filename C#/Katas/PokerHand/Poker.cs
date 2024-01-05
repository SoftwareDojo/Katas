using System.Collections.Generic;
using System.Linq;

namespace Katas
{
    public class Poker
    {
        public PokerHandRank EvaluateHand(List<PokerCard> hand)
        {
            var groupByRank = hand.GroupBy(card => card.Rank);

            if (IsRoyalFlush(hand)) return PokerHandRank.RoyalFlush;
            if (IsStraightFlush(hand)) return PokerHandRank.StraightFlush;
            if (IsFourOfAKind(groupByRank)) return PokerHandRank.FourOfAKind;
            if (IsFullHouse(groupByRank)) return PokerHandRank.FullHouse;
            if (IsFlush(hand)) return PokerHandRank.Flush;
            if (IsStraight(hand)) return PokerHandRank.Straight;
            if (IsThreeOfAKind(groupByRank)) return PokerHandRank.ThreeOfAKind;
            if (IsTwoPair(groupByRank)) return PokerHandRank.TwoPair;
            if (IsOnePair(groupByRank)) return PokerHandRank.OnePair;
            return PokerHandRank.HighCard;
        }

        private bool IsRoyalFlush(IReadOnlyCollection<PokerCard> hand)
        {
            return IsStraightFlush(hand) && hand.All(card => card.Rank >= Rank.Ten);
        }

        private bool IsStraightFlush(IReadOnlyCollection<PokerCard> hand)
        {
            return IsFlush(hand) && IsStraight(hand);
        }

        private bool IsFlush(IReadOnlyCollection<PokerCard> hand)
        {
            return hand.GroupBy(card => card.Suit).Count() == 1;
        }

        private bool IsStraight(IReadOnlyCollection<PokerCard> hand)
        {
            var maxRanks = hand.Select(card => (int)card.Rank).OrderBy(rank => rank).ToList();
            if (AscendingOrder(maxRanks)) return true;

            var minRanks = hand.Select(card => (int)card.GetMinRank()).OrderBy(rank => rank).ToList();
            return AscendingOrder(minRanks);
        }

        private bool AscendingOrder(IList<int> ranks)
        {
            for (int i = 1; i < ranks.Count; i++)
            {
                if (ranks[i] != ranks[i - 1] + 1)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsFourOfAKind(IEnumerable<IGrouping<Rank, PokerCard>> hand)
        {
            return CountByRank(hand, 4) == 1;
        }

        private bool IsThreeOfAKind(IEnumerable<IGrouping<Rank, PokerCard>> hand)
        {
            return CountByRank(hand, 3) == 1;
        }

        private bool IsTwoPair(IEnumerable<IGrouping<Rank, PokerCard>> hand)
        {
            return CountByRank(hand, 2) == 2;
        }

        private bool IsOnePair(IEnumerable<IGrouping<Rank, PokerCard>> hand)
        {
            return CountByRank(hand, 2) == 1;
        }

        private bool IsFullHouse(IEnumerable<IGrouping<Rank, PokerCard>> hand)
        {
            return CountByRank(hand, 3) == 1 && CountByRank(hand, 2) == 1;
        }

        private int CountByRank(IEnumerable<IGrouping<Rank, PokerCard>> hand, int count)
        {
            return hand.Count(group => group.Count() == count);
        }
    }
}