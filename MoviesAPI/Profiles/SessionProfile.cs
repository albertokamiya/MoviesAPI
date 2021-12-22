using AutoMapper;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<CreateSessionDto, Session>();
            CreateMap<Session, ReadSessionDto>()
                .ForMember(dto => dto.BeginSession, opt => opt
                .MapFrom(dto => dto.EndSesssion.AddMinutes(dto.Movie.Duration * (-1))));

            CreateMap<UpdateSessionDto, Session>();
        }
    }
}
