internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddApplicationServices(builder.Configuration);
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // initialize the database .....

        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<dataContext>();
            // var userManager = services.GetRequiredService<UserManager<AppUser>>();
            // var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
           // if(context.Database.ExecuteSqlRaw("SELECT * FROM training.COURSES") == 0){}
            await context.Database.EnsureCreatedAsync();
            // await Seed.SeedUsers(userManager, roleManager);
            
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred during migration");
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //app.UseHttpsRedirection();

        //app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}