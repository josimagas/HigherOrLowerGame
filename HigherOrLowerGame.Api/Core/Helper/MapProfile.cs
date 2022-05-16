using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using HigherOrLowerGame.Api.Core.Dto;
using HigherOrLowerGame.Api.Model;

namespace HigherOrLowerGame.Api.Core.Helper
{
    [ExcludeFromCodeCoverage]
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Request
            CreateMap<PlayGameRequest, Game>().ReverseMap();
            #endregion

            #region Response

            CreateMap<Game, PlayGameResponse>();
            CreateMap<Game, StartGameResponse>();
            CreateMap<Game, GameStatusResponse>();

            #endregion
           
        }
    }
}