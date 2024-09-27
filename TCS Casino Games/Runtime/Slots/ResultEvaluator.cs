using System.Collections.Generic;
using UnityEngine;
namespace TCS.CasinoGames {
    public class ResultEvaluator {
        Dictionary<SlotSymbol, float> m_payoutTable;

        public ResultEvaluator(Dictionary<SlotSymbol, float> payout) {
            m_payoutTable = payout;
        }

        public int Evaluate(List<SlotSymbol> result, int bet) {
            // Check if STAR appears
            if (result.Contains(SlotSymbol.Star)) {
                return Mathf.RoundToInt(m_payoutTable[SlotSymbol.Star] * bet);
            }

            // Check for three matching symbols
            if (result[0] == result[1] && result[1] == result[2]) {
                return Mathf.RoundToInt(m_payoutTable[result[0]] * bet);
            }

            // Check for two matching symbols
            if (result[0] == result[1] || result[1] == result[2] || result[0] == result[2]) {
                return Mathf.RoundToInt(0.85f * bet); // Using 0.85x for two matches as per our logic
            }

            return 0; // No win
        }
    }
}