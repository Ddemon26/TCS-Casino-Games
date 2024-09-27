using System.Collections.Generic;
using UnityEngine;
namespace TCS.CasinoGames {
    public class PlayableSlotMachine {
        int m_credits;
        SlotMachine m_slotMachine;

        public PlayableSlotMachine(int initialCredits, SlotMachine slotMachine) {
            m_credits = initialCredits;
            m_slotMachine = slotMachine;
        }

        public bool PlaceBet(int bet) {
            if (bet > m_credits) {
                Debug.Log("Not enough credits to place that bet.");
                return false;
            }

            m_credits -= bet;
            return true;
        }

        public void Spin(int bet) {
            if (!PlaceBet(bet)) {
                return;
            }

            (List<SlotSymbol> result, int winnings) = m_slotMachine.Spin(bet);
            m_credits += winnings;

            Debug.Log($"Spin result: {string.Join(", ", result)}");
            Debug.Log($"Won: {winnings} credits");
            Debug.Log($"Remaining credits: {m_credits}");
        }

        public bool CanContinue() {
            return m_credits >= 10; // Ensure enough credits for the next bet
        }
    }
}