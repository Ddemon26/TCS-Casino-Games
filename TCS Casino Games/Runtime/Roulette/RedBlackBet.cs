namespace TCS_Casino_Games {
    [System.Serializable]
    public class RedBlackBet : Bet {
        public BetColor m_color;
        public RedBlackBet(int amount, BetColor color) : base(amount) => m_color = color;
        // Calculate payout for a red/black bet
        public override int CalculatePayout(int resultNumber, BetColor resultColor) => resultColor == m_color ? m_amount * 2 : 0;
    }
}