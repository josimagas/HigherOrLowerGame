using AutoMapper;
using HigherOrLowerGameApi.API.Core.Dto;
using HigherOrLowerGameApi.API.Model;

namespace HigherOrLowerGameApi.API.Core.services
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<PlayGameRequest, Game>();
        }
    }
}