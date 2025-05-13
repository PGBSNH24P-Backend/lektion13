using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("view-balance", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireRole("employee");
            });

            options.AddPolicy("withdraw-money", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireRole("owner");
            });
        });
        builder.Services.AddControllers();

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=password;Database=lektion13"));

        builder.Services.AddIdentityCore<UserEntity>()
            .AddRoles<IdentityRole>() // Denna måste ligga först
            .AddEntityFrameworkStores<AppDbContext>()
            .AddApiEndpoints();

        var app = builder.Build();

        app.MapIdentityApi<UserEntity>();
        app.MapControllers();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        Task.WaitAll([CreateDefaultRoles(app)]);

        app.Run();
    }

    static async Task CreateDefaultRoles(WebApplication app)
    {
        using var scope = app.Services.CreateAsyncScope();

        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        if (await roleManager.FindByNameAsync("owner") == null)
        {
            await roleManager.CreateAsync(new IdentityRole("owner"));
        }
        if (await roleManager.FindByNameAsync("employee") == null)
        {
            await roleManager.CreateAsync(new IdentityRole("employee"));
        }
        if (await roleManager.FindByNameAsync("user") == null)
        {
            await roleManager.CreateAsync(new IdentityRole("user"));
        }
    }
}