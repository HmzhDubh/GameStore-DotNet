using System;

namespace GameStore.Api.Dtos;

public record class GameDetailsDto(

    int Id,
    string Name,
    int GenerId,
    decimal Price,
    DateOnly ReleaseDate
);

