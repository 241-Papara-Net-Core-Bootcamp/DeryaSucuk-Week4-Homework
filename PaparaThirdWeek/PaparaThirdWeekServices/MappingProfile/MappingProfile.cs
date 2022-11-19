using AutoMapper;
using PaparaThirdWeek.Domain.Entities;
using PaparaThirdWeek.Services.DTOs;

namespace PaparaThirdWeek.Services.MappingProfile
{
    public class MappingProfile:Profile 
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();//dto daki proları ile company deki propleri eşler
        }
    }
}
