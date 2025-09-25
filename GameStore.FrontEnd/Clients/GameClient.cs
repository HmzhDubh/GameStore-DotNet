using System;
using GameStore.FrontEnd.Models;
namespace GameStore.FrontEnd.Clients;

public class GameClient
{
    private readonly List<Games> games = [
        new(){
            Id = 1,
            Name = "The Legend of Zelda: Breath of the Wild",
            Genre = "Action",
            Price = 59.99M,
            ReleaseDate = new DateOnly(2017, 3, 3)
        },
        new(){
            Id = 2,
            Name = "God of War",
            Genre = "adventure",
            Price = 49.99M,
            ReleaseDate = new DateOnly(2018, 4, 20)
        },
        new(){
            Id = 3,
            Name = "Red Dead Redemption 2",
            Genre = "Action",
            Price = 39.99M,
            ReleaseDate = new DateOnly(2018, 10, 26)
        },
        new(){
            Id = 4,
            Name = "The Witcher 3: Wild Hunt",
            Genre = "Action",
            Price = 29.99M,
            ReleaseDate = new DateOnly(2015, 5, 19)
        }
    ];
    private readonly Genre[] genres = new GenresClient().GetAllGenres();
    public Games[] GetAllGames() => [.. games];

    public void AddGame(GamesDetails game)
    {
        Genre genre = GetGenreById(game.GenreId);
        var newGame = new Games
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

        games.Add(newGame);
    }

    public GamesDetails? GetGameById(int id)
    {
        Games? game = GetGameSummaryById(id);

        var genre = genres.Single(genre => string.Equals(genre.Name, game.Genre, StringComparison.OrdinalIgnoreCase));

        return new GamesDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }
    public void UpdateGame(GamesDetails updatedGame)
    {
        ArgumentNullException.ThrowIfNull(updatedGame);
        var existingGame = GetGameSummaryById(updatedGame.Id);
        var genre = GetGenreById(updatedGame.GenreId);

        existingGame.Name = updatedGame.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;
    }
    public void DeleteGame(int id)
    {
        var game = GetGameSummaryById(id);
        games.Remove(game);
    }
    private Games GetGameSummaryById(int id)
    {
        var game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrEmpty(id);
        return genres.Single(genre => int.Parse(genre.Id) == int.Parse(id));
        
    }

}
