using HigherOrLowerGameApi.API.Core.services;
using HigherOrLowerGameApi.API.Core.services.interfaces;
using HigherOrLowerGameApi.API.Infra.repositories;
using HigherOrLowerGameApi.API.Infra.repositories.interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HigherOrLowerGameApi.API.Configuration
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            
            services.AddScoped(typeof(IGameRepository), typeof(GameRepository));
            
            services.AddScoped(typeof(IGameService), typeof(GameService));
            
            
        }
       
    }
}