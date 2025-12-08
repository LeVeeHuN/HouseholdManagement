using HHMBApp.Application.Interfaces;
using HHMBApp.Application.Services;
using HHMBApp.Application.Settings;
using HHMBApp.Infrastructure.Data;
using HHMBApp.Infrastructure.Interfaces;
using HHMBApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HHMBApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(JwtOptions.SectionName));

            builder.Services.AddSingleton<IJwtTokenService, JwtTokenService>();

            var jwtSection = builder.Configuration.GetSection(JwtOptions.SectionName);
            var jwtOptions = jwtSection.Get<JwtOptions>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))
                    };
                });

            builder.Services.AddAuthorization();
            builder.Services.AddControllers();

            // Register services
            builder.Services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
            builder.Services.AddScoped<IGroceryListItemRepository, GroceryListItemRepository>();
            builder.Services.AddScoped<IGroceryListRepository, GroceryListRepository>();
            builder.Services.AddScoped<IHouseholdRepository, HouseholdRepository>();
            builder.Services.AddScoped<IIncomeRepository, IncomeRepository>();
            builder.Services.AddScoped<ITodoRepository, TodoRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IWishRepository, WIshRepository>();

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IExpenseService, ExpenseService>();
            builder.Services.AddScoped<IGroceryService, GroceryService>();
            builder.Services.AddScoped<IHouseholdService, HouseholdService>();
            builder.Services.AddScoped<IIncomeService, IncomeService>();
            builder.Services.AddScoped<ITodoService, TodoService>();
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
