using Microsoft.EntityFrameworkCore;
using TodoListSPA.Entities;

namespace TodoListSPA.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }

    public virtual DbSet<Todo> Todos => Set<Todo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
