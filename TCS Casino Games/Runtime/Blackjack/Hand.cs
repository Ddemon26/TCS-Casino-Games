using System.Collections.Generic;

namespace TCS_Blackjack {
    public class Hand {
        public List<Card> Cards { get; private set; }
        public int Total { get; private set; }
        int m_aces;

        public Hand() {
            Cards = new List<Card>();
            Total = 0;
            m_aces = 0;
        }

        public void AddCard(Card card) {
            Cards.Add(card);
            Total += (int)card.Rank;

            if (card.Rank == Rank.Ace) {
                m_aces++;
            }

            AdjustForAces();
        }

        void AdjustForAces() {
            while (Total > 21 && m_aces > 0) {
                Total -= 10;
                m_aces--;
            }
        }

        public void Reset() {
            Cards.Clear();
            Total = 0;
            m_aces = 0;
        }

        public override string ToString() => $"Hand: {string.Join(", ", Cards)}, Total: {Total}";
    }
}