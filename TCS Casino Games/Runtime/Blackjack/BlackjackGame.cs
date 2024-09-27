using System;

namespace TCS_Blackjack {
    public class BlackjackGame {
        const float BLACKJACK_PAYOUT = 1.5f;
        const float REGULAR_WIN_PAYOUT = 1.0f;

        Deck m_deck;
        Player m_player;
        Dealer m_dealer;

        public BlackjackGame(float startingBalance) {
            m_deck = new Deck();
            m_player = new Player(startingBalance);
            m_dealer = new Dealer();
        }

        public void StartRound(float betAmount) {
            m_player.PlaceBet(betAmount);
            m_player.Hand.Reset();
            m_dealer.Hand.Reset();

            DealInitialCards();
            ShowHands(false);

            if (CheckBlackjack()) {
                return;
            }

            PlayerTurn();
            if (m_player.Hand.Total <= 21) {
                DealerTurn();
            }

            SettleBets();
        }

        void DealInitialCards() {
            for (var i = 0; i < 2; i++) {
                m_player.Hand.AddCard(m_deck.DealCard());
                m_dealer.Hand.AddCard(m_deck.DealCard());
            }
        }

        void ShowHands(bool revealDealer) {
            Console.WriteLine($"Player's Hand: {m_player.Hand}");
            Console.WriteLine(revealDealer
                                  ? $"Dealer's Hand: {m_dealer.Hand}"
                                  : $"Dealer's Hand: {m_dealer.Hand.Cards[0]}, ?");
        }

        bool CheckBlackjack() {
            bool playerBlackjack = m_player.Hand.Total == 21;
            bool dealerBlackjack = m_dealer.Hand.Total == 21;

            if (!playerBlackjack && !dealerBlackjack) return false;
            ShowHands(true);

            switch (playerBlackjack) {
                case true when dealerBlackjack:
                    Console.WriteLine("Push! Both have Blackjack.");
                    m_player.Push();
                    break;
                case true:
                    Console.WriteLine("Player has Blackjack! You win.");
                    m_player.WinBet(BLACKJACK_PAYOUT);
                    break;
                default:
                    Console.WriteLine("Dealer has Blackjack. You lose.");
                    m_player.LoseBet();
                    break;
            }

            return true;

        }

        void PlayerTurn() {
            while (true) {
                Console.WriteLine("Choose action (hit/stand): ");
                string action = Console.ReadLine()?.ToLower();

                if (action == "hit") {
                    m_player.Hand.AddCard(m_deck.DealCard());
                    ShowHands(false);
                    if (m_player.Hand.Total <= 21) continue;
                    Console.WriteLine("Player Busts!");
                    return;
                }
                else if (action == "stand") {
                    break;
                }
                else {
                    Console.WriteLine("Invalid choice.");
                }
            }
        }

        void DealerTurn() {
            while (m_dealer.MustHit()) {
                m_dealer.Hand.AddCard(m_deck.DealCard());
            }

            ShowHands(true);
        }

        void SettleBets() {
            if (m_player.Hand.Total > 21) {
                Console.WriteLine("Player Busts. You lose.");
                m_player.LoseBet();
            }
            else if (m_dealer.Hand.Total > 21) {
                Console.WriteLine("Dealer Busts. You win.");
                m_player.WinBet(REGULAR_WIN_PAYOUT);
            }
            else if (m_player.Hand.Total > m_dealer.Hand.Total) {
                Console.WriteLine("Player wins!");
                m_player.WinBet(REGULAR_WIN_PAYOUT);
            }
            else if (m_player.Hand.Total < m_dealer.Hand.Total) {
                Console.WriteLine("Dealer wins.");
                m_player.LoseBet();
            }
            else {
                Console.WriteLine("Push!");
                m_player.Push();
            }
        }

        public float GetPlayerBalance() => m_player.Balance;
    }
}