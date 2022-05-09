using HigherOrLowerGameApi.API.Core.services;
using HigherOrLowerGameApi.API.Core.services.interfaces;
using HigherOrLowerGameApi.API.Infra.repositories;
using HigherOrLowerGameApi.API.Infra.repositories.interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HigherOrLowerGameApi.API.Configuration
{
    
        public static class DependencyInjectionConfig
        {
            public static void RegisterServices(this IServiceCollection services)
            {
                
                services.AddScoped<IGameRepository, GameRepository>();
                
                services.AddScoped<IGameService, GameService>();
            
            }
        }
        
    }
