using AutoMapper;
using RepositoryPatternWithUOW.Core.Dtos;
using RepositoryPatternWithUOW.Core.Models;
namespace RepositoryPatternWithUOW.Core.Mapping;
public class MappingProfile : Profile
{
    public MappingProfile()
    {

        CreateMap<ItemDto, Item>()/*.ForMember(dest => dest.Id, opt => {
            opt.Condition(src => src.Id > 0);
            opt.MapFrom(src => src.Id);
            })*/
            .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.ItemName)).ReverseMap();
            /*.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.UomId, opt => opt.MapFrom(src => src.UomId))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.QTY, opt => opt.MapFrom(src => src.Qty))*/; 

    }
}
