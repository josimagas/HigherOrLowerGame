using AutoMapper;
using HigherOrLowerGameApi.API.Core.Dto;
using HigherOrLowerGameApi.API.Model;

namespace HigherOrLowerGameApi.API.Core.services
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