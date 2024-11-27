using AutoMapper;
using MyCondo.Domain.Entities.Apartamento;
using MyCondo.Domain.Transfer.DataTransfer.Apartamento.Request;
using MyCondo.Domain.Transfer.DataTransfer.Apartamento.Response;

namespace MyCondo.Domain.Transfer.DataTransfer.Apartamento.Profiles;

public class ApartamentoProfile : Profile
{
    public ApartamentoProfile()
    {
        CreateMap<Apartamentos, ApartamentosAtualizarRequest>().ReverseMap();
        CreateMap<Apartamentos, ApartamentosExcluirRequest>().ReverseMap();
        CreateMap<Apartamentos, ApartamentosInserirRequest>().ReverseMap();
        CreateMap<Apartamentos, ApartamentosPesquisaRequest>().ReverseMap();
        CreateMap<Apartamentos, ApartamentosResponse>().ReverseMap();
    }
}
