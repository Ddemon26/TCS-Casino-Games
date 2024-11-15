namespace TCS_Blackjack {
    /// <summary>
    /// Represents a playing card with a suit and rank.
    /// </summary>
    /// <param name="Suit">The suit of the card (e.g., Hearts, Diamonds, Clubs, Spades).</param>
    /// <param name="Rank">The rank of the card (e.g., Ace, 2, 3, ..., King).</param>
    public record Card(Suit Suit, Rank Rank);
}