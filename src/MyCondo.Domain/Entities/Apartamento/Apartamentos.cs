using MyCondo.Domain.Entities.Base;
using MyCondo.Domain.Entities.Bloco;
using MyCondo.Domain.Entities.Morador;
using MyCondo.Domain.Utils.Enumeradores;
using System.Text.Json.Serialization;

namespace MyCondo.Domain.Entities.Apartamento;

public class Apartamentos : BaseEntity
{
    public string Numero { get; protected set; }
    public int Andar { get; protected set; }
    public ETipoApartamento TipoApartamento { get; protected set; }
    public int BlocosId { get; protected set; }
    [JsonIgnore]
    public Blocos Blocos { get; set; }

    public ICollection<Moradores> Moradores { get; set; }

    public Apartamentos()
    {
    }

    public void SetNumero(string numero) => Numero = numero;
    public void SetAndar(int andar) => Andar = andar;
    public void SetTipoApartamento(ETipoApartamento tipoApartamento) => TipoApartamento = tipoApartamento;
}
