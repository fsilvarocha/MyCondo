using AutoMapper;
using MyCondo.Domain.Entities.Apartamento;
using MyCondo.Domain.Transfer.DataTransfer.Apartamento.Request;
using MyCondo.Domain.Transfer.DataTransfer.Apartamento.Response;
using MyCondo.Domain.Utils.Extensoes;

namespace MyCondo.Domain.Transfer.DataTransfer.Apartamento.Profiles;

public class ApartamentoProfile : Profile
{
    public ApartamentoProfile()
    {
        CreateMap<Apartamentos, ApartamentosAtualizarRequest>().ReverseMap();
        CreateMap<Apartamentos, ApartamentosExcluirRequest>().ReverseMap();
        CreateMap<Apartamentos, ApartamentosInserirRequest>().ReverseMap();
        CreateMap<Apartamentos, ApartamentosPesquisaRequest>().ReverseMap();
        CreateMap<Apartamentos, ApartamentosResponse>()
            .ForMember(dest => dest.TipoApartamentoDescricao, opt => opt.MapFrom(src => src.TipoApartamento.ObterDescriaoEnum()))
            .ReverseMap();
    }
}
