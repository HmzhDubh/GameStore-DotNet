using System;
using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{

    private static readonly List<GameDto> games = [
        new (1, "The Witcher 3: Wild Hunt", "RPG", 39.99m, new DateOnly(2015, 5, 19)),
        new (2, "Cyberpunk 2077", "Action", 59.99m, new DateOnly(2020, 12, 10)),
        new (3, "God of War", "Adventure", 49.99m, new DateOnly(2018, 4, 20))
    ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games");

        // GET /games
        group.MapGet("/", () => games);
        // GET /games/{id}
        group.MapGet("/{id}", (int id) =>
        {
            GameDto? game = games.Find(game => game.Id == id);
            return game == null ? Results.NotFound() : Results.Ok(game);
        })
        .WithName("GetGame");

        // POST /games
        group.MapPost("/", (CreateGameDto newGame) =>
        {


            GameDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Gener,
                newGame.Price,
                newGame.ReleaseDate
            );

            games.Add(game);

            return Results.CreatedAtRoute("GetGame", new { id = game.Id }, game);

        }).WithParameterValidation();

        // PUT /games/{id}
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);
            if (index == -1) return Results.NotFound();
            games[index] = new GameDto(
                id,
                updatedGame.Name,
                updatedGame.Gener,
                updatedGame.Price,
                updatedGame.ReleaseDate
            );

            return Results.NoContent();
        });

        // DELETE /games/{id}
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);
            return Results.NoContent();
        });

        return group;
    }
}
