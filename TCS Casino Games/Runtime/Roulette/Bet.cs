namespace TCS_Casino_Games {
    [System.Serializable]
    public abstract class Bet {
        public int m_amount;
        protected Bet(int amount) => m_amount = amount;
        // Abstract method to calculate payout
        public abstract int CalculatePayout(int resultNumber, BetColor resultColor);
    }
}