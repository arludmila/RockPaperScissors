using Microsoft.AspNetCore.Components;

namespace RockPaperScissors.BlazorApp.Pages
{
    public partial class Index
    {
        private int roundsAmount = 10;
        public void GoToSingleplayer()
        {
            NavigationManager.NavigateTo($"/singleplayer/{roundsAmount}");
        }
    }
}