using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Serilog;
using TodoListSPA.Data;
using TodoListSPA.Helpers;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Application starting up...");

    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
    IWebHostEnvironment environment = builder.Environment;
    IServiceCollection? services = builder.Services;

    // Add services to the container.

    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console()
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(ctx.Configuration));

    string dbConn = builder.Configuration.GetConnectionString("DataContext") ??
        throw new Exception("Connection String missing!");

    services.AddDbContext<DataContext>(options =>
    {
        options.UseSqlServer(dbConn);
    });

    services.AddControllersWithViews().AddNewtonsoftJson(newtonsoftJson =>
    {
        newtonsoftJson.SerializerSettings.Converters.Add(new StringEnumConverter());
        newtonsoftJson.SerializerSettings.NullValueHandling = NullValueHandling.Include;
        newtonsoftJson.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

    services.AddCors();

    if (environment.IsDevelopment())
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo List SPA API", Description = "ASP.NET + React + Vite" });
            options.SchemaFilter<EnumSchemaFilter>();
        });

    }

    WebApplication app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoList SPA API V1");
        });

#if DEBUG
        bool seed = app.Configuration.GetValue<bool>("seed");
        if (seed)
        {
            using IServiceScope scope = app.Services.CreateScope();
            DataContext? context = scope.ServiceProvider.GetService<DataContext>();
            DbInitializer.SeedDb(context!);
        }
#endif
    }
    
    if (!app.Environment.IsDevelopment())
    {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseSerilogRequestLogging();
    app.UseStaticFiles();
    app.UseRouting();

    app.UseCors(opts =>
    {
        opts.WithOrigins("https://localhost:3000");
    });

    if (app.Environment.IsDevelopment())
        app.MapGet("/", (HttpResponse response) => response.Redirect("/swagger")).ExcludeFromDescription();
    else
        app.MapGet("/", () => "").ExcludeFromDescription();


    app.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");

    app.MapFallbackToFile("index.html");

    app.Run();

}
catch (Exception ex)
{
    if (ex.GetType().Name.Equals("HostAbortedException", StringComparison.Ordinal))
        throw;
    Log.Fatal(ex, "Unhandled error in application. Application will now exit.");
}
finally
{
    Log.Information("Application shutting down...");
    Log.CloseAndFlush();
}