using AutoMapper;
using BackOffice.Application.Dto;
using BackOffice.Models;

namespace BackOffice.Application.Mapping
{
    public class CompanyMapperProfile : Profile
    {
        public CompanyMapperProfile()
        {
            CreateMap<Company, CompanyDto>();
        }      
    }
}
