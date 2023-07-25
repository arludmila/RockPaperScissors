using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RockPaperScissors.Entities.Core
{
    /// <summary>
    /// Represents an abstract base class for choices in the Rock-Paper-Scissors game.
    /// </summary>
    public abstract class Choice
    {
        public string Name { get; private set; }
        public abstract string Type { get; }
        /// <summary>
        /// Initializes a new instance of the Choice class with the specified name.
        /// This constructor is protected as Choice is an abstract class and cannot be instantiated directly.
        /// </summary>
        /// <param name="name">The name of the choice (e.g., "rock", "paper", or "scissors").</param>
        protected Choice(string name)
        {
            Name = name;
        }
        /// <summary>
        /// Determines the result of a round in the Rock-Paper-Scissors game for the player's choice against the opponent's choice.
        /// Each concrete implementation of Choice should override this method to provide custom outcome mappings.
        /// </summary>
        /// <param name="opponentChoice">The opponent's choice (Rock, Paper, or Scissors).</param>
        /// <returns>A GameResult object representing the outcome of the round.</returns>
        public abstract GameResult GetResultAgainst(Choice opponentChoice);
        /// <summary>
        /// Creates a new GameResult object representing the outcome of a round in the Rock-Paper-Scissors game.
        /// </summary>
        /// <param name="opponentChoice">The opponent's choice (Rock, Paper, or Scissors).</param>
        /// <param name="outcome">The outcome of the round (Win, Lose, or Draw).</param>
        /// <returns>A new GameResult object representing the outcome of the round.</returns>
        public GameResult GetGameResult(Choice opponentChoice, Outcome outcome)
        {
            return new GameResult()
            {
                RoundOutcome = outcome,
                PlayerChoice = this,
                OpponentChoice = opponentChoice
            };
        }
        /// <summary>
        /// Overrides the default implementation of the Equals method to compare two Choice objects based on their Type and Name properties.
        /// </summary>
        /// <param name="obj">The object to compare with the current Choice instance.</param>
        /// <returns>true if the specified object is equal to the current Choice; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Choice other = (Choice)obj;
            return Type == other.Type && Name == other.Name;
        }
        /// <summary>
        /// Overrides the default implementation of the GetHashCode method to calculate a hash code based on the Type and Name properties.
        /// </summary>
        /// <returns>An integer hash code representing the current Choice object.</returns>

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + Type.GetHashCode();
                hash = hash * 23 + Name.GetHashCode();
                return hash;
            }
        }
    }
    /// <summary>
    /// Represents the possible outcomes of a round in the Rock-Paper-Scissors game.
    /// </summary>
    public enum Outcome
    {
        Win,
        Lose,
        Draw
    }

}
