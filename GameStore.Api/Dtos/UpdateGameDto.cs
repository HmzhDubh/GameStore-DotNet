using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record class UpdateGameDto
(
    [Required][StringLength(50)]
    string Name,
    [Required][StringLength(30)]
    string Gener,
    [Range(1, 100)]
    decimal Price,
    DateOnly ReleaseDate
);
