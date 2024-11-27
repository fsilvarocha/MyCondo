using AutoMapper;
using MyCondo.Domain.Entities.Bloco;
using MyCondo.Domain.Transfer.DataTransfer.Bloco.Request;
using MyCondo.Domain.Transfer.DataTransfer.Bloco.Response;

namespace MyCondo.Domain.Transfer.DataTransfer.Bloco.Profiles;

public class BlocosProfile : Profile
{
    public BlocosProfile()
    {
        CreateMap<Blocos, BlocosAtualizarRequest>().ReverseMap();
        CreateMap<Blocos, BlocosPesquisaRequest>().ReverseMap();
        CreateMap<Blocos, BlocosInserirRequest>().ReverseMap();
        CreateMap<Blocos, BlocosResponse>().ReverseMap();
    }
}
