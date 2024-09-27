using System.Collections.Generic;
using UnityEngine;
namespace TCS.CasinoGames.Tests {
    public class SlotMachineTest : MonoBehaviour {
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

            // Create the slot machine
            var slotMachine = new SlotMachine(symbolWeights, payoutTable);

            // Create playable slot machine
            var playableSlotMachine = new PlayableSlotMachine(100, slotMachine);

            // Simulate playing
            while (playableSlotMachine.CanContinue()) {
                playableSlotMachine.Spin(10);
            }

            Debug.Log("Out of credits! Game over.");
        }
    }
}