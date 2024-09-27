using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace TCS.CasinoGames {
    public class Reel {
        List<SlotSymbol> m_symbols;
        List<int> m_weights;

        public Reel(List<int> symbolWeights) {
            m_symbols = new List<SlotSymbol> { SlotSymbol.Seven, SlotSymbol.Bar, SlotSymbol.Cherry, SlotSymbol.Bell, SlotSymbol.Diamond, SlotSymbol.Star };
            m_weights = symbolWeights;
        }

        // Spin method, randomly choosing a symbol based on weights
        public SlotSymbol Spin() {
            int totalWeight = m_weights.Sum();

            int randomValue = Random.Range(0, totalWeight);
            for (var i = 0; i < m_weights.Count; i++) {
                if (randomValue < m_weights[i]) {
                    return m_symbols[i];
                }

                randomValue -= m_weights[i];
            }

            return m_symbols[0]; // Default return in case of failure (shouldn't happen)
        }
    }
}