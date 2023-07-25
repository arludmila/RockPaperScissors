using Microsoft.AspNetCore.Components;
using RockPaperScissors.Entities.Core;
using RockPaperScissors.Entities.DTOs;

namespace RockPaperScissors.BlazorApp.Pages
{
    public partial class Singleplayer
    {
        // Variables to track game state and scores
        private string? roundResultMsg;
        private string? playerChoiceStr;
        private string? opponentChoiceStr;
        private int playerScore = 0;
        private int opponentScore = 0;
        private List<Choice> playerChoices = new List<Choice>();
        
        private int currentRound = 0;
        private bool isGameOver = false;
        private bool isGameActive = true;
        private string finalGameMessage = string.Empty;
        [Parameter]
        public int MaxRounds { get; set; }
        // Button click handlers for Rock, Paper, and Scissors
        private async void OnClickRock()
        {
            await PlayRound(new Rock());
        }

        private async void OnClickPaper()
        {
            await PlayRound(new Paper());
        }

        private async void OnClickScissors()
        {
            await PlayRound(new Scissors());
        }

        // Play a round of the game
        private async Task PlayRound(Choice playerChoice)
        {
            if (!ChoiceInputValidation(playerChoice))
            {
                return;
            }

            // Get the game result and update scores accordingly
            GameResultDTO gameResult = await GetResult(playerChoice);
            switch (gameResult.RoundOutcome)
            {
                case Outcome.Win:
                    playerScore++;
                    break;
                case Outcome.Lose:
                    opponentScore++;
                    break;
                default:
                    // Draw: no score change 
                    break;
            }

            currentRound++;
            // Check if the game is over
            if (currentRound >= MaxRounds)
            {
                if (playerScore > opponentScore)
                {
                    isGameActive = false;
                    finalGameMessage = "YOU WON! 😊";
                    await Task.Delay(2000);
                    isGameOver = true;
                    StateHasChanged();
                }
                else if (opponentScore > playerScore)
                {
                    isGameActive = false;
                    finalGameMessage = "YOU LOST! 😭";
                    await Task.Delay(2000);
                    isGameOver = true;
                    StateHasChanged();
                }
            }
        }

        // Validate player choice
        private bool ChoiceInputValidation(Choice choice)
        {
            if (choice.Equals(new Rock()) || choice.Equals(new Paper()) || choice.Equals(new Scissors()))
            {
                return true;
            }

            return false;
        }

        // Get the game result from the service
        private async Task<GameResultDTO> GetResult(Choice playerChoice)
        {
            playerChoices.Add(playerChoice);
            GameResultDTO gameResult = await rpsGameService.GetGameResultAsync(playerChoice, playerChoices);
            roundResultMsg = $"{gameResult.PlayerChoice.ToUpper()} {gameResult.RoundOutcome.ToString().ToUpper()} AGAINST {gameResult.OpponentChoice.ToUpper()}";
            playerChoiceStr = gameResult.PlayerChoice;
            opponentChoiceStr = gameResult.OpponentChoice;
            return gameResult;
        }

        // Get the corresponding image based on the game result
        private string GetResultImage(string result)
        {
            if (result.Contains("WIN", StringComparison.OrdinalIgnoreCase))
            {
                return "win.png";
            }
            else if (result.Contains("LOSE", StringComparison.OrdinalIgnoreCase))
            {
                return "lose.png";
            }
            else
            {
                return "draw.png";
            }
        }

        // Reset all scores and game state
        private void ResetScores()
        {
            playerScore = 0;
            opponentScore = 0;
            roundResultMsg = null;
            playerChoiceStr = null;
            opponentChoiceStr = null;
            playerChoices.Clear();
            currentRound = 0;
            finalGameMessage = string.Empty;
            isGameOver = false;
            isGameActive = true;
        }
    }
}