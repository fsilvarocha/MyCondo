using MyCondo.Domain.Transfer.DataTransfer.Base;

namespace MyCondo.Domain.Transfer.DataTransfer.Bloco.Request;

public class BlocosInserirRequest : BaseInserirRequest
{
    public string Nome { get; set; }
    public int QuantidadeAndar { get; set; }
    public int CondominiosId { get; set; }
}
