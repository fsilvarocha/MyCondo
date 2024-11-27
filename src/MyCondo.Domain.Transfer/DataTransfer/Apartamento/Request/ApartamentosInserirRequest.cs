using MyCondo.Domain.Transfer.DataTransfer.Base;
using MyCondo.Domain.Utils.Enumeradores;

namespace MyCondo.Domain.Transfer.DataTransfer.Apartamento.Request;

public class ApartamentosInserirRequest : BaseInserirRequest
{
    public string Numero { get; set; }
    public int Andar { get; set; }
    public ETipoApartamento TipoApartamento { get; set; }
    public int BlocosId { get; set; }
}
