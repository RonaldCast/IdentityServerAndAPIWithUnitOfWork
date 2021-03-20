using APITreiber.DomainModel.Models;
using APITreiber.DTOs.PersonDTOs;
using AutoMapper;

namespace APITreiber.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonDTO, Person>().ReverseMap();
        }
    }
}