using GameShopCRUD.Dtos;

namespace GameShopCRUD;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

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
        app.MapGet("/games/{id}", (int id) => games.Find(g => g.Id == id));
        
        
        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}