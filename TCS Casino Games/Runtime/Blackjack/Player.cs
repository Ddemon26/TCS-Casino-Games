namespace TCS_Blackjack {
    public class Player {
        public Hand Hand { get; private set; }
        public float Balance { get; private set; }
        
        float m_bet;

        public Player(float balance) {
            Balance = balance;
            Hand = new Hand();
        }

        public void PlaceBet(float amount) {
            if (amount > Balance) {
                throw new System.Exception("Bet exceeds balance");
            }

            m_bet = amount;
            Balance -= amount;
        }

        public void WinBet(float multiplier) {
            Balance += m_bet * (1 + multiplier);
            m_bet = 0;
        }

        public void LoseBet() => m_bet = 0;

        public void Push() {
            Balance += m_bet;
            m_bet = 0;
        }
    }
}