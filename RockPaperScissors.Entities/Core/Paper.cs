using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Entities.Core
{
    /// <summary>
    /// Represents the "Paper" choice in the Rock-Paper-Scissors game.
    /// </summary>
    public class Paper : Choice
    {
        public override string Type { get; } = nameof(Paper);
        /// <summary>
        /// Initializes a new instance of the Paper class with the specified name.
        /// </summary>
        /// <param name="name">The name of the choice ("paper").</param>
        public Paper() : base("paper")
        {
        }
        /// <summary>
        /// Determines the result of a round in the Rock-Paper-Scissors game for the player's choice (Paper) against the opponent's choice.
        /// Overrides the base method to provide custom outcome mappings.
        /// </summary>
        /// <param name="opponentChoice">The opponent's choice (Rock, Paper, or Scissors).</param>
        /// <returns>A GameResult object representing the outcome of the round.</returns>
        public override GameResult GetResultAgainst(Choice opponentChoice)
        {
            if (opponentChoice is Rock)
                return GetGameResult(opponentChoice,Outcome.Win);
            else if (opponentChoice is Paper)
                return GetGameResult(opponentChoice, Outcome.Draw);
            else if (opponentChoice is Scissors)
                return GetGameResult(opponentChoice, Outcome.Lose);

            throw new ArgumentException("Invalid choice type.", nameof(opponentChoice));
        }
        /// <summary>
        /// Returns the name of the choice ("paper") as a string representation of the Paper object.
        /// </summary>
        /// <returns>The name of the choice as a string.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
