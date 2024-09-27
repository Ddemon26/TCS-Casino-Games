namespace TCS_Casino_Games {
    [System.Serializable]
    public class HighLowBet : Bet {
        public HighLow m_highLow;
        public HighLowBet(int amount, HighLow highLow) : base(amount) => m_highLow = highLow;
        // Calculate payout for a high/low bet
        public override int CalculatePayout(int resultNumber, BetColor resultColor) {
            if (resultNumber == 0) return 0; // 0 is neither high nor low
            bool isLow = resultNumber <= 18;
            return (isLow && m_highLow == HighLow.Low) || (!isLow && m_highLow == HighLow.High) ? m_amount * 2 : 0;
        }
    }
}