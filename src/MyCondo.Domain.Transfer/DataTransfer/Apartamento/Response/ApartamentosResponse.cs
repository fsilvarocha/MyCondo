using MyCondo.Domain.Transfer.DataTransfer.Base;
using MyCondo.Domain.Utils.Enumeradores;

namespace MyCondo.Domain.Transfer.DataTransfer.Apartamento.Response;

public class ApartamentosResponse : BaseResponse
{
    public string Numero { get; set; }
    public int Andar { get; set; }
    public ETipoApartamento TipoApartamento { get; set; }
}
