
using System.Diagnostics.CodeAnalysis;
using HigherOrLowerGame.Api.Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HigherOrLowerGame.Api.Configuration
{
    [ExcludeFromCodeCoverage]
public static class DatabaseManagementService
    {
         // Getting the scope of our database context
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                 // Takes all of our migrations files and apply them against the database in case they are not implemented
                 serviceScope.ServiceProvider.GetService<AppDbContext>().Database.EnsureCreated();
               // serviceScope.ServiceProvider.GetService<AppDbContext>().Database.Migrate();
                
            }
        }
    }
}