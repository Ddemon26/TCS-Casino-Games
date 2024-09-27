using System.Collections.Generic;
using UnityEngine;
namespace TCS.CasinoGames.Tests {
    public class SlotMachineBenchmark : MonoBehaviour {
        SlotMachine m_slotMachine;
        
        void Start() {
            // Setup payout table and symbol weights
            Dictionary<SlotSymbol, float> payoutTable = new() {
                { SlotSymbol.Seven, 20f },
                { SlotSymbol.Bar, 5f },
                { SlotSymbol.Cherry, 3f },
                { SlotSymbol.Bell, 3f },
                { SlotSymbol.Diamond, 3f },
                { SlotSymbol.Star, 1.65f }
            };

            List<int> symbolWeights = new() { 1, 6, 8, 6, 6, 3 };

            // Create slot machine
            m_slotMachine = new SlotMachine(symbolWeights, payoutTable);

            // Run benchmark
            RunBenchmark(1000000, 10); // 1 million spins, 10 credits bet per spin
        }

        // Method to run the benchmark
        void RunBenchmark(int numSpins, int bet) {
            var totalBet = 0;
            var totalPayout = 0;

            for (var i = 0; i < numSpins; i++) {
                // Simulate a spin
                (List<SlotSymbol> _, int winnings) = m_slotMachine.Spin(bet);

                // Track total bet and payout
                totalBet += bet;
                totalPayout += winnings;
            }

            // Calculate the RTP (Return to Player) percentage
            float rtp = (float)totalPayout / totalBet * 100f;

            // Log results to console
            Debug.Log($"Total Bet: {totalBet} credits");
            Debug.Log($"Total Payout: {totalPayout} credits");
            Debug.Log($"RTP (Return to Player): {rtp}%");

            // Check if RTP is within the target range (e.g., 92%)
            Debug.Log(rtp is >= 91.5f and <= 93f ? "RTP is within the target range of 92%" : "RTP is outside the target range.");
        }
    }
}