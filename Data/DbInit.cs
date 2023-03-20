using Bogus;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TodoListSPA.Entities;

namespace TodoListSPA.Data;

public static class DbInitializer
{
    public static void SeedDb(DataContext context)
    {
        try
        {
            Log.Information("---STARTING DB SEED ROUTINE!---");
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            Log.Information("...CREATING TODOS!");

            Faker<Todo> fakeTodos = new Faker<Todo>()
                .RuleFor(u => u.Id, f => Guid.NewGuid())
                .RuleFor(u => u.Name, f => f.Hacker.Phrase())
                .RuleFor(u => u.Created, f => f.Date.Recent())
                .RuleFor(u => u.Status, f => f.PickRandom<TodoStatus>());

            List<Todo> todos = fakeTodos.Generate(10);

            context.Todos.AddRange(todos);
            context.SaveChanges();

            Log.Information("---DB SEED ROUTINE COMPLETE!---");
            Environment.Exit(0);
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);
            Environment.Exit(1);
        }
    }
}
