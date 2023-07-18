using AutoMapper;
using SalutVaga.DTO;
using SalutVaga.Models;

namespace SalutVaga.Mapping
{
    public class EntitiesToDtoMappingProfile : Profile
    {
        public EntitiesToDtoMappingProfile()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }

    }
}
