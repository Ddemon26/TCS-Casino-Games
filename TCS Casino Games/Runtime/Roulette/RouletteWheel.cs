namespace TCS_Casino_Games {
    [System.Serializable]
    public class RouletteWheel {
        readonly BetColor[] m_wheelColors;

        public RouletteWheel() {
            m_wheelColors = new BetColor[37];
            m_wheelColors[0] = BetColor.Green; // Set the zero position to Green

            for (var i = 1; i < m_wheelColors.Length; i++) {
                m_wheelColors[i] = (i % 2 == 0) ? BetColor.Black : BetColor.Red;
            }
        }

        // Spin the roulette wheel and return the result (number and color)
        public (int, BetColor) Spin() {
            int resultNumber = UnityEngine.Random.Range(0, 37); // Range from 0-36
            var resultColor = m_wheelColors[resultNumber];
            return (resultNumber, resultColor);
        }
    }
}