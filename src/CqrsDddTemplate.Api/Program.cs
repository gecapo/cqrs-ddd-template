using System.Reflection;
using CqrsDddTemplate.Handlers.ImplementedEntities.Commands;
using CqrsDddTemplate.Handlers.ImplementedEntities.Queries;
using CqrsDddTemplate.Infrastructure;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/implemented-entity", async (ISender mediatr) =>
{
    var entities = await mediatr.Send(new ListImplementedEntities.Query());
    return Results.Ok(entities);
});

app.MapPost("/implemented-entity", async (CreateImplementedEntity.Command command, ISender mediatr) =>
{
    var entityId = await mediatr.Send(command);
    // return Results.Created($"/implemented-entity/{entityId}", new { id = entityId });
    return Results.Created();
});


app.Run();