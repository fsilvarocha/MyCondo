using AutoMapper;
using MyCondo.Domain.Entities.Condominio;
using MyCondo.Domain.Transfer.DataTransfer.Condominio.Request;
using MyCondo.Domain.Transfer.DataTransfer.Condominio.Response;

namespace MyCondo.Domain.Transfer.DataTransfer.Condominio.Profiles;

public class CondominiosProfile : Profile
{
    public CondominiosProfile()
    {
        CreateMap<Condominios, CondominiosResponse>().ReverseMap();
        CreateMap<Condominios, CondominiosInserirRequest>().ReverseMap();
        CreateMap<Condominios, CondominiosPesquisaRequest>().ReverseMap();
        CreateMap<Condominios, CondominiosAtualizarRequest>().ReverseMap();
    }
}
