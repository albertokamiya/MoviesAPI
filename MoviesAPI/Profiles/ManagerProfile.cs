using System.Linq;
using AutoMapper;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class ManagerProfile : Profile
    {
        public ManagerProfile()
        {
            CreateMap<CreateManagerDto, Manager>();
            CreateMap<Manager, ReadManagerDto>()
                .ForMember(x => x.Cinemas, opts => opts
                .MapFrom(x => x.Cinemas.Select
                (c => new { c.Id, c.Name, c.Address, c.AddressId })));
        }
    }
}
