namespace TCS_Casino_Games {
    [System.Serializable]
    public class EvenOddBet : Bet {
        public EvenOdd m_evenOdd;
        public EvenOddBet(int amount, EvenOdd evenOdd) : base(amount) => m_evenOdd = evenOdd;
        // Calculate payout for an even/odd bet
        public override int CalculatePayout(int resultNumber, BetColor resultColor) {
            if (resultNumber == 0) return 0; // 0 is not even or odd
            bool isEven = resultNumber % 2 == 0;
            return (isEven && m_evenOdd == EvenOdd.Even) || (!isEven && m_evenOdd == EvenOdd.Odd) ? m_amount * 2 : 0;
        }
    }
}