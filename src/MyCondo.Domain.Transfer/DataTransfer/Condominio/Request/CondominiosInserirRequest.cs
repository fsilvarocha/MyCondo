using MyCondo.Domain.Transfer.DataTransfer.Base;

namespace MyCondo.Domain.Transfer.DataTransfer.Condominio.Request;

public class CondominiosInserirRequest : BaseInserirRequest
{
    public string Nome { get; set; }
    public string Cep { get; set; }
}
