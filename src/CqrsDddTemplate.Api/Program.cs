using CqrsDddTemplate.Handlers.Abstractions;
using CqrsDddTemplate.Handlers.ImplementedEntities.Commands;
using CqrsDddTemplate.Handlers.ImplementedEntities.Queries;
using CqrsDddTemplate.Infrastructure;
using CqrsDddTemplate.Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((hostContext, services, configuration) =>
{
    configuration
        .WriteTo.Console();
});

builder.Services.AddOpenApi();

//TODO: Configure DB
builder.Services.AddDbContext<IDbContext, ApplicationDbContext>(options => { options.UseSqlServer(); });

builder.Services.AddScoped<IHandlerContext, HandlerContext>();
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(IHandlerContext).Assembly); });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//TODO: Move to new file
var group = app.MapGroup("/implemented-entity");
group.MapGet("/",
    async (ISender mediatr) =>
    {
        var entities = await mediatr.Send(new ListImplementedEntities.Query());
        return Results.Ok(entities);
    });

group.MapPost("/",
    async (CreateImplementedEntity.Command command, ISender mediatr) =>
    {
        var entityId = await mediatr.Send(command);
        // return Results.Created($"/implemented-entity/{entityId}", new { id = entityId });
        return Results.Created();
    });

app.Run();