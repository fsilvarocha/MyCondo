using MyCondo.Domain.Transfer.DataTransfer.Base;
using MyCondo.Domain.Utils.Enumeradores;

namespace MyCondo.Domain.Transfer.DataTransfer.Morador.Response;

public class MoradoresResponse : BaseResponse
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Foto { get; set; }
    public ETipoMorador TipoMorador { get; set; }
    public string TipoMoradorDescricao { get; set; }
}
