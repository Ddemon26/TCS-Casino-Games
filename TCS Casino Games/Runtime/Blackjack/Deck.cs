using System.Collections.Generic;
using System.Linq;

namespace TCS_Blackjack {
    public class Deck {
        List<Card> m_cards;

        public Deck() {
            m_cards = BuildDeck();
            Shuffle();
        }

        List<Card> BuildDeck() {
            List<Card> deck = new();
            foreach (Suit suit in System.Enum.GetValues(typeof(Suit))) {
                deck.AddRange(from Rank rank in System.Enum.GetValues(typeof(Rank)) select new Card(suit, rank));
            }

            return deck;
        }

        public void Shuffle() => m_cards = m_cards.OrderBy(x => UnityEngine.Random.value).ToList();

        public Card DealCard() {
            if (m_cards.Count == 0) {
                m_cards = BuildDeck();
                Shuffle();
            }

            var card = m_cards[0];
            m_cards.RemoveAt(0);
            return card;
        }
    }
}