using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using StringConverter = GameStore.FrontEnd.Converters.StringConverter;

namespace GameStore.FrontEnd.Models;

public class GamesDetails
{
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }
    [Required(ErrorMessage = "The genre field is required.")]

    [JsonConverter(typeof(StringConverter))]
    public string? GenreId { get; set; }
    [Range(1, 100)]
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
    

}
