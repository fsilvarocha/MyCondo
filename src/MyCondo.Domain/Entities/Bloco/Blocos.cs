using MyCondo.Domain.Entities.Apartamento;
using MyCondo.Domain.Entities.Base;
using MyCondo.Domain.Entities.Condominio;
using System.Text.Json.Serialization;

namespace MyCondo.Domain.Entities.Bloco;

public class Blocos : BaseEntity
{
    public string Nome { get; protected set; }
    public int QuantidadeAndar { get; protected set; }
    public int CondominiosId { get; protected set; }
    [JsonIgnore]
    public Condominios Condominios { get; set; }

    public ICollection<Apartamentos> Apartamentos { get; set; }

    public void SetNome(string nome) => Nome = nome;
    public void SetQuantidadeAndar(int quantidadeAndar) => QuantidadeAndar = quantidadeAndar;
}
