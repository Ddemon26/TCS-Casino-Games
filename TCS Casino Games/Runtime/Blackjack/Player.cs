namespace TCS_Blackjack {
    public class Player {
        public Hand Hand { get; private set; }
        public float Balance { get; private set; }
        public float Bet { get; private set; }

        public Player(float balance) {
            Balance = balance;
            Hand = new Hand();
        }

        public void PlaceBet(float amount) {
            if (amount > Balance) {
                throw new System.Exception("Bet exceeds balance");
            }

            Bet = amount;
            Balance -= amount;
        }

        public void WinBet(float multiplier) {
            Balance += Bet * (1 + multiplier);
            Bet = 0;
        }

        public void LoseBet() => Bet = 0;

        public void Push() {
            Balance += Bet;
            Bet = 0;
        }
    }
}