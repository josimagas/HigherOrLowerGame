using System.Diagnostics.CodeAnalysis;
using HigherOrLowerGame.Api.Core.services;
using HigherOrLowerGame.Api.Core.services.interfaces;
using HigherOrLowerGame.Api.Infra.repositories;
using HigherOrLowerGame.Api.Infra.repositories.interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HigherOrLowerGame.Api.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            
            services.AddScoped<IGameRepository, GameRepository>();
            
            services.AddTransient<IGameService, GameService>();
            
            
        }
       
    }
}