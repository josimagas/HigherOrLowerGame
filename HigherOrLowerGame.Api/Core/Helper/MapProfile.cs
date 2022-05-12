using AutoMapper;
using HigherOrLowerGame.Api.Core.Dto;
using HigherOrLowerGame.Api.Model;

namespace HigherOrLowerGame.Api.Core.Helper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Request
            CreateMap<PlayGameRequest, Game>().ReverseMap();
            #endregion

            #region Response

            CreateMap<Game, PlayGameResponse>();
            CreateMap<Game, StarGameResponse>();
            CreateMap<Game, GameStatusResponse>();

            #endregion
           
        }
    }
}