using System.Collections.Generic;
namespace TCS_Blackjack {
    public class Shoe {
        readonly List<Deck> m_decks;
        readonly int m_numDecks;

        readonly List<Card> m_cards = new();
        
        public Shoe(int numDecks) {
            m_numDecks = numDecks;
            m_decks = new List<Deck>();
            BuildShoe();
            Shuffle();
        }
        
        void BuildShoe() {
            for (var i = 0; i < m_numDecks; i++) {
                m_decks.Add(new Deck());
            }
            
            foreach (var deck in m_decks) {
                m_cards.AddRange(deck.MCards);
            }
        }
        
        public void Shuffle() {
            for (int i = m_cards.Count - 1; i > 0; i--) {
                int j = UnityEngine.Random.Range(0, i + 1);
                (m_cards[i], m_cards[j]) = (m_cards[j], m_cards[i]);
            }
        }
        
        public Card DealCard() {
            if (m_cards.Count == 0) {
                BuildShoe();
                Shuffle();
            }

            var card = m_cards[0];
            m_cards.RemoveAt(0);
            return card;
        }
        
    }
}