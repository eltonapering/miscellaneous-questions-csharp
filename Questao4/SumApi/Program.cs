var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();


// Endpoint GET /sum que recebe dois par�metros via query string

app.MapGet("/sum", (string? a, string? b) =>
{
    // Valida��o dos par�metros para garantir que sejam n�meros
    if (!double.TryParse(a, out var numberA))
    {
        return Results.BadRequest(new { error = $"O par�metro 'a' n�o � um n�mero v�lido: {a}" });
    }

    if (!double.TryParse(b, out var numberB))
    {
        return Results.BadRequest(new { error = $"O par�metro 'b' n�o � um n�mero v�lido: {b}" });
    }

    // Calcula a soma dos dois n�meros
    var result = numberA + numberB;

    // Retorna o resultado no formato JSON
    return Results.Json(new { result });
});

app.Run();
