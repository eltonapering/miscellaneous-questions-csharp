var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();


// Endpoint GET /sum que recebe dois parâmetros via query string

app.MapGet("/sum", (string? a, string? b) =>
{
    // Validação dos parâmetros para garantir que sejam números
    if (!double.TryParse(a, out var numberA))
    {
        return Results.BadRequest(new { error = $"O parâmetro 'a' não é um número válido: {a}" });
    }

    if (!double.TryParse(b, out var numberB))
    {
        return Results.BadRequest(new { error = $"O parâmetro 'b' não é um número válido: {b}" });
    }

    // Calcula a soma dos dois números
    var result = numberA + numberB;

    // Retorna o resultado no formato JSON
    return Results.Json(new { result });
});

app.Run();
