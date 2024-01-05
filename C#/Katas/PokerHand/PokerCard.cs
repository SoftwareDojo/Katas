namespace Katas;

public class PokerCard
{
    public Suit Suit { get; }
    public Rank Rank { get; }
    public PokerCard(Suit suit, Rank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public int GetMinRank()
    {
        if (Rank == Rank.Ace) return 1;
        return (int)Rank;
    }
}

public enum Suit
{
    Hearts,
    Diamonds,
    Clubs,
    Spades,
}

public enum Rank
{
    Two = 2,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
    Ace,
}