using System;
public class GenresClient
{
    private readonly Genre[] genres = [
        new(){
            Id = "1",
            Name = "Action"
        },
        new(){
            Id = "2",
            Name = "Adventure"
        },
        new(){
            Id = "3",
            Name = "RPG"
        },
        new(){
            Id = "4",
            Name = "Strategy"
        },
        new(){
            Id = "5",
            Name = "Simulation"
        }
    ];

    public Genre[] GetAllGenres() => genres;
    
    
}
