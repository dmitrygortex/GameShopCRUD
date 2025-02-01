using GameShopCRUD.Dtos;

namespace GameShopCRUD;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();
        
        const string getGameEndpointName = "GetGame";

        List<GameDto> games =
        [
            new GameDto(
                1,
                "Watch Dogs 2",
                "HackGame",
                4200M,
                new DateOnly(2018, 4, 3)
            ),
            
            new GameDto(
                2,
                "Rayman",
                "Platformer",
                3100M,
                new DateOnly(2016, 1, 24)
                ),
            
            new GameDto(
                3,
                "Minecraft",
                "Survive game",
            1200,
                new DateOnly(2012, 6, 21)
            )


        ];
        
        app.MapGet("/games", () => games);
        app.MapGet("/games/{id}", (int id) => games.Find(g => g.Id == id))
            .WithName(getGameEndpointName);
        app.MapPost("games", (CreateGameDto createGameDto) =>
        {
            var game = new GameDto(
                games.Count + 1,
                createGameDto.Name,
                createGameDto.Genre,
                createGameDto.Price,
                createGameDto.ReleaseDate
            );
            
            games.Add(game);
            return Results.CreatedAtRoute(getGameEndpointName, new { id = game.Id }, game);
        });
        
        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}