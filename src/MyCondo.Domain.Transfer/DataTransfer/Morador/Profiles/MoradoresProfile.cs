using AutoMapper;
using MyCondo.Domain.Entities.Morador;
using MyCondo.Domain.Transfer.DataTransfer.Morador.Request;
using MyCondo.Domain.Transfer.DataTransfer.Morador.Response;
using MyCondo.Domain.Utils.Extensoes;

namespace MyCondo.Domain.Transfer.DataTransfer.Morador.Profiles;

public class MoradoresProfile : Profile
{
    public MoradoresProfile()
    {
        CreateMap<Moradores, MoradoresAtualizarRequest>().ReverseMap();
        CreateMap<Moradores, MoradoresExcluirRequest>().ReverseMap();
        CreateMap<Moradores, MoradoresPesquisaRequest>().ReverseMap();
        CreateMap<Moradores, MoradoresInserirRequest>().ReverseMap();
        CreateMap<Moradores, MoradoresResponse>()
            .ForMember(dest => dest.TipoMoradorDescricao, opt => opt.MapFrom(src => src.TipoMorador.ObterDescriaoEnum()))
            .ReverseMap();
    }
}
