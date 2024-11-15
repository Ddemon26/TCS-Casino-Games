using System.Collections.Generic;
namespace TCS.CasinoGames {
    public class SlotMachine {
        List<Reel> m_reels;
        ResultEvaluator m_evaluator;

        public SlotMachine(List<int> symbolWeights, Dictionary<SlotSymbol, float> payoutTable) {
            m_reels = new List<Reel> { new(symbolWeights), new(symbolWeights), new(symbolWeights) };
            m_evaluator = new ResultEvaluator(payoutTable);
        }

        // Spin method to spin all reels and evaluate the result
        public (List<SlotSymbol>, int) Spin(int bet) {
            List<SlotSymbol> result = new() {
                m_reels[0].Spin(),
                m_reels[1].Spin(),
                m_reels[2].Spin(),
            };

            int winnings = m_evaluator.Evaluate(result, bet);
            return (result, winnings);
        }
    }
}