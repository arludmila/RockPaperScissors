using RockPaperScissors.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Entities.DTOs
{
    /// <summary>
    /// Represents the result of a game round in a simplified format.
    /// </summary>
    public class GameResultDTO
    {
        public Outcome RoundOutcome { get; set; }
        public string PlayerChoice { get; set; } = string.Empty;
        public string OpponentChoice { get; set; } = string.Empty;
        /// <summary>
        /// Initializes a new instance of the GameResultDTO class with default values.
        /// </summary>
        public GameResultDTO()
        {
            
        }
        /// <summary>
        /// Initializes a new instance of the GameResultDTO class using a GameResult object.
        /// </summary>
        /// <param name="gameResult">The GameResult object containing the round outcome and choices.</param>
        public GameResultDTO(GameResult gameResult)
        {
            PlayerChoice = gameResult.PlayerChoice.Name;
            OpponentChoice = gameResult.OpponentChoice.Name;
            RoundOutcome = gameResult.RoundOutcome;
            
        }
    }
}
