using System;
using System.Text.Json.Serialization;
using GameStore.FrontEnd.Converters;

public class Genre
{
    [JsonConverter(typeof(StringConverter))]
    public string Id { get; set; }
    public required string Name { get; set; }
}
