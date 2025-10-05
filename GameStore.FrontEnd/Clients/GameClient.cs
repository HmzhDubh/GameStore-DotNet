using System;
using System.Threading.Tasks;
using GameStore.FrontEnd.Models;
namespace GameStore.FrontEnd.Clients;

public class GameClient(HttpClient httpClient)
{
   
    public async Task<Games[]> GetAllGamesAsync()
        => await httpClient.GetFromJsonAsync<Games[]>("games") ?? [];

    public async Task AddGameAsync(GamesDetails game)
        => await httpClient.PostAsJsonAsync("games", game);
    

    public async Task<GamesDetails?> GetGameAsync(int id)
        => await httpClient.GetFromJsonAsync<GamesDetails>($"games/{id}") ?? throw new Exception("Game not found");

    public async Task UpdateGameAsync(GamesDetails updatedGame)
        => await httpClient.PutAsJsonAsync($"games/{updatedGame.Id}", updatedGame);
    public async Task DeleteGameAsync(int id) =>
        await httpClient.DeleteAsync($"games/{id}");

}
