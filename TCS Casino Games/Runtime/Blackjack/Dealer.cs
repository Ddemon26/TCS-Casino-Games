namespace TCS_Blackjack {
    public class Dealer {
        public Hand Hand { get; private set; }
        public Dealer() => Hand = new Hand();
        public bool MustHit() => Hand.Total < 17;
        public void Reset() => Hand.Reset();
    }
}