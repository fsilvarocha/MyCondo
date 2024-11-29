using MyCondo.Domain.Transfer.DataTransfer.Base;
using MyCondo.Domain.Utils.Enumeradores;

namespace MyCondo.Domain.Transfer.DataTransfer.Morador.Request;

public class MoradoresInserirRequest : BaseInserirRequest
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public int ApartamentoId { get; set; }
    public string Foto { get; set; } = "semfoto";
    public ETipoMorador TipoMorador { get; set; } = ETipoMorador.Proprietario;
}
