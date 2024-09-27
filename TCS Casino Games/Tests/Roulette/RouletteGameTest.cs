using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
namespace TCS_Casino_Games.Tests {
    public class RouletteGameTest : MonoBehaviour {
        [SerializeField] int m_balance;
        [SerializeField] RouletteWheel m_wheel;

        StraightBet m_straightBet;
        RedBlackBet m_colorBet;
        EvenOddBet m_evenOddBet;
        HighLowBet m_highLowBet;
        
        [SerializeField] RouletteBetType m_betType;
        [Space]
        [SerializeField] int m_betNumber;
        [SerializeField] BetColor m_betColor;
        [SerializeField] EvenOdd m_betEvenOdd;
        [SerializeField] HighLow m_betHighLow;
        [Space]
        [SerializeField] int m_betAmount;

        List<Bet> m_bets = new();
        List<Bet> m_previousBets = new();

        // Initialize the game
        void Start() {
            m_balance = 1000; // Starting balance
            m_wheel = new RouletteWheel(); // Initialize the roulette wheel
            m_betAmount = 0; // Initialize the bet amount
            m_bets = new List<Bet>(); // Initialize the list of bets
            m_previousBets = new List<Bet>(); // Initialize the list of previous bets
        }

        [Button]
        public void SetupBetByType(int amount) {
            //set bet amount before setting the bet
            if (amount <= 0) {
                Debug.Log("Invalid bet amount.");
                return;
            }
            SetupBet(m_betType, amount);
        }
        
        void SetupBet(RouletteBetType rouletteBetType, int amount) {
            switch (rouletteBetType) {
                case RouletteBetType.Straight:
                    m_straightBet = new StraightBet(amount, m_betNumber);
                    break;
                case RouletteBetType.RedBlack:
                    m_colorBet = new RedBlackBet(amount, m_betColor);
                    break;
                case RouletteBetType.EvenOdd:
                    m_evenOddBet = new EvenOddBet(amount, m_betEvenOdd);
                    break;
                case RouletteBetType.HighLow:
                    m_highLowBet = new HighLowBet(amount, m_betHighLow);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(rouletteBetType), rouletteBetType, null);
            }
            
            m_balance -= amount;
            m_betAmount += amount;
            
            Debug.Log($"Bet placed: {amount} on {rouletteBetType}");
            
            SetFinalBet(rouletteBetType);
        }

        void SetFinalBet(RouletteBetType type) {
            switch (type) {
                case RouletteBetType.Straight:
                    m_bets.Add(m_straightBet);
                    break;
                case RouletteBetType.RedBlack:
                    m_bets.Add(m_colorBet);
                    break;
                case RouletteBetType.EvenOdd:
                    m_bets.Add(m_evenOddBet);
                    break;
                case RouletteBetType.HighLow:
                    m_bets.Add(m_highLowBet);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            
            Debug.Log($"Bet placed: {m_bets[^1]}");
        }
        
        [Button]
        public void PlayRound() {
            if (m_bets.Count == 0) {
                Debug.Log("No bets placed.");
                return;
            }

            (int resultNumber, var resultColor) = m_wheel.Spin(); // Spin the wheel once

            Debug.Log($"The wheel spun: {resultNumber} ({resultColor})");

            // Resolve all bets
            int totalPayout = m_bets.Sum(bet => bet.CalculatePayout(resultNumber, resultColor)); // Total payout for the round

            m_balance += totalPayout; // Add the total payout to the player's balance

            // Display results
            Debug.Log(totalPayout > 0 ? $"You won {totalPayout} in total!" : "You lost all your bets.");

            Debug.Log($"Your updated balance is: {m_balance}");

            // Clear bets after the round
            //debug log the bet list before clearing
            foreach (var bet in m_bets) {
                Debug.Log(bet + bet.m_amount.ToString());
            }
            
            m_previousBets.Clear();
            m_previousBets.AddRange(m_bets);
            
            m_bets.Clear();
            m_betAmount = 0;
        }
        
        [Button]
        public void UndoLastBet() {
            if (m_bets.Count == 0) {
                Debug.Log("No previous bets to undo.");
                return;
            }

            var lastBet = m_bets[^1];
            m_balance += lastBet.m_amount;
            m_betAmount -= lastBet.m_amount;
            m_bets.Remove(lastBet);
            Debug.Log($"Bet undone: {lastBet}");
        }
        
        [Button]
        public void ResetBets() {
            m_balance += m_betAmount;
            m_betAmount = 0;
            m_bets.Clear();
            Debug.Log("All bets have been reset.");
        }
        
        //method to reset our current bets and then set the previous bets list if it exists
        [Button]
        public void ResetBetsAndSetPrevious() {
            if (m_previousBets.Count == 0) {
                Debug.Log("No previous bets to set.");
                return;
            }
            
            if (m_previousBets.Count <= 0) return;
            ResetBets();
            if (m_balance < m_previousBets.Sum(bet => bet.m_amount)) {
                Debug.Log("Insufficient balance to set previous bets.");
                return;
            }
            m_balance -= m_previousBets.Sum(bet => bet.m_amount);
            m_betAmount += m_previousBets.Sum(bet => bet.m_amount);
            
            m_bets.AddRange(m_previousBets);
            
            
            foreach (var bet in m_bets) {
                Debug.Log(bet + bet.m_amount.ToString());
            }
        }

        [Button]
        public void ResetGame() {
            m_balance = 1000;
            m_betAmount = 0;
            Debug.Log("Game has been reset. Starting balance: 1000");
            m_bets.Clear(); // Clear any placed bets
        }
    }
}