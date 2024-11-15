namespace TCS_Blackjack {
    public class Dealer {
        public Hand Hand { get; } = new();
        public bool MustHit() => Hand.Total < 17;
        public void Reset() => Hand.Reset();
    }
}