namespace TCS_Casino_Games {
    [System.Serializable]
    public class StraightBet : Bet {
        public int m_number;
        public StraightBet(int amount, int number) : base(amount) => m_number = number;
        public override int CalculatePayout(int resultNumber, BetColor resultColor) => resultNumber == m_number ? m_amount * 36 : 0;
    }
}