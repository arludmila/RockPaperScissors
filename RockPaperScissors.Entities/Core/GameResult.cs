
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RockPaperScissors.Entities.Core
{
    /// <summary>
    /// Represents the result of a round in the Rock-Paper-Scissors game.
    /// </summary>
    public class GameResult
    {
        public Outcome RoundOutcome { get; set; }
        public Choice PlayerChoice { get; set; }
        public Choice OpponentChoice { get; set; }
        /// <summary>
        /// Initializes a new instance of the GameResult class with the specified round outcome, player choice, and opponent choice.
        /// </summary>
        /// <param name="roundOutcome">The outcome of the round (Win, Lose, or Draw).</param>
        /// <param name="playerChoice">The choice made by the player in the round.</param>
        /// <param name="opponentChoice">The choice made by the opponent in the round.</param>
        public GameResult(Outcome roundOutcome, Choice playerChoice, Choice opponentChoice)
        {
            RoundOutcome = roundOutcome;
            PlayerChoice = playerChoice;
            OpponentChoice = opponentChoice;
        }
        public GameResult()
        {
            
        }
    }
}
