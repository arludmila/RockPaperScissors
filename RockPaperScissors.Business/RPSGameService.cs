using RockPaperScissors.Entities.Core;
using RockPaperScissors.Entities.DTOs;

namespace RockPaperScissors.Business
{
    public class RPSGameService
    {
        
        /// <summary>
        /// Calculates the result of a round in the Rock-Paper-Scissors game, given the player's choice.
        /// The opponent's choice is generated randomly.
        /// </summary>
        /// <param name="playerChoice">The player's choice (Rock, Paper, or Scissors).</param>
        /// <returns>A GameResultDTO object containing the result of the round.</returns>
        public GameResultDTO GetGameResult(Choice playerChoice)
        {
            Choice opponent = GenerateOpponentChoice();
            GameResult result = GetResultAgainst(playerChoice, opponent);
            GameResultDTO resultDTO = new GameResultDTO(result);
            return resultDTO;
        }
        /// <summary>
        /// Generates a random choice for the opponent in the Rock-Paper-Scissors game.
        /// </summary>
        /// <returns>A randomly selected Choice object representing the opponent's choice.</returns>
        private Choice GenerateOpponentChoice()
        {
            var random = new Random();
            var opponentChoice = random.Next(0, 3);
            switch (opponentChoice)
            {
                case 0:
                    return new Rock();
                case 1:
                    return new Paper();
                case 2:
                    return new Scissors();
                default:
                    // Default choice: rock
                    return new Rock();
            }
        }
        /// <summary>
        /// Calculates the result of a round in the Rock-Paper-Scissors game, given the player's choice.
        /// The opponent's choice is generated with weighted probabilities based on previous player choices.
        /// </summary>
        /// <param name="playerChoice">The player's choice (Rock, Paper, or Scissors).</param>
        /// <param name="playerChoices">A list of previous player choices.</param>
        /// <returns>A GameResultDTO object containing the result of the round.</returns>
        public GameResultDTO GetGameResult(Choice playerChoice, List<Choice> playerChoices)
        {
            Choice opponent = GenerateOpponentChoice(playerChoices);
            GameResult result = GetResultAgainst(playerChoice, opponent);
            GameResultDTO resultDTO = new GameResultDTO(result);
            return resultDTO;
        }
        // Async version
        public async Task<GameResultDTO> GetGameResultAsync(Choice playerChoice, List<Choice> playerChoices)
        {
            Choice opponent = await GenerateOpponentChoiceAsync(playerChoices);
            GameResult result = GetResultAgainst(playerChoice, opponent);
            GameResultDTO resultDTO = new GameResultDTO(result);
            return resultDTO;
        }
        /// <summary>
        /// Generates the opponent's choice in the Rock-Paper-Scissors game using weighted probabilities based on previous player choices.
        /// </summary>
        /// <param name="playerChoices">A list of previous player choices.</param>
        /// <returns>A Choice object representing the opponent's choice.</returns>
        private Choice GenerateOpponentChoice(List<Choice> playerChoices)
        {
            // TODO: maybe not repeat the moves too much?
            Dictionary<Choice, int> choiceWeights = new()
            {
                { new Rock(), 1 },
                { new Paper(), 1 },
                { new Scissors(), 1 }
            };
            foreach (var item in playerChoices)
            {
                if (choiceWeights.ContainsKey(item))
                {
                    choiceWeights[item]++;
                }
            }
            int maxWeight = choiceWeights.Values.Max();
            List<Choice> maxWeightChoices = choiceWeights.Where(kv => kv.Value == maxWeight).Select(kv => kv.Key).ToList();
            Choice selectedChoice = maxWeightChoices[new Random().Next(maxWeightChoices.Count)];
            return selectedChoice;
        }
        // Async version
        private async Task<Choice> GenerateOpponentChoiceAsync(List<Choice> playerChoices)
        {
            // TODO: maybe not repeat the moves too much?
            Dictionary<Choice, int> choiceWeights = new()
            {
                { new Rock(), 1 },
                { new Paper(), 1 },
                { new Scissors(), 1 }
            };

            foreach (var item in playerChoices)
            {
                if (choiceWeights.ContainsKey(item))
                {
                    choiceWeights[item]++;
                }
            }

            int maxWeight = choiceWeights.Values.Max();
            List<Choice> maxWeightChoices = choiceWeights.Where(kv => kv.Value == maxWeight).Select(kv => kv.Key).ToList();
            Choice selectedChoice = maxWeightChoices[new Random().Next(maxWeightChoices.Count)];

            return await Task.FromResult(selectedChoice);
        }
        /// <summary>
        /// Determines the result of a round in the Rock-Paper-Scissors game for the player's choice against the opponent's choice.
        /// </summary>
        /// <param name="playerChoice">The player's choice (Rock, Paper, or Scissors).</param>
        /// <param name="opponentChoice">The opponent's choice (Rock, Paper, or Scissors).</param>
        /// <returns>A GameResult object representing the outcome of the round.</returns>
        private GameResult GetResultAgainst(Choice playerChoice, Choice opponentChoice)
        {
            return playerChoice.GetResultAgainst(opponentChoice);
        }

    }
}