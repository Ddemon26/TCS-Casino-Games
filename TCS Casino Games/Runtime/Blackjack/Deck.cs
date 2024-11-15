using System.Collections.Generic;
using System.Linq;

namespace TCS_Blackjack {
    public class Deck {
        public List<Card> MCards;

        public Deck() {
            MCards = BuildDeck();
            Shuffle();
        }

        static List<Card> BuildDeck() {
            List<Card> deck = new();
            foreach (Suit suit in System.Enum.GetValues(typeof(Suit))) {
                deck.AddRange(from Rank rank in System.Enum.GetValues(typeof(Rank)) select new Card(suit, rank));
            }

            return deck;
        }

        public void Shuffle() {
            for (int i = MCards.Count - 1; i > 0; i--) {
                int j = UnityEngine.Random.Range(0, i + 1);
                (MCards[i], MCards[j]) = (MCards[j], MCards[i]);
            }
        }

        public Card DealCard() {
            if (MCards.Count == 0) {
                MCards = BuildDeck();
                Shuffle();
            }

            var card = MCards[0];
            MCards.RemoveAt(0);
            return card;
        }
    }
}