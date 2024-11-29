using MyCondo.Domain.Entities.Apartamento;
using MyCondo.Domain.Entities.Base;
using MyCondo.Domain.Utils.Enumeradores;
using System.Text.Json.Serialization;

namespace MyCondo.Domain.Entities.Morador;

public class Moradores : BaseEntity
{
    public string Nome { get; protected set; }
    public string? Cpf { get; protected set; }
    public ETipoMorador TipoMorador { get; protected set; }
    public int ApartamentoId { get; protected set; }
    public string Foto { get; protected set; }

    [JsonIgnore]
    public Apartamentos Apartamentos { get; set; }

    public Moradores()
    {
    }

    public void SetNome(string nome) => Nome = nome;
    public void SetCpf(string cpf) => Cpf = cpf;
    public void SetTipoMorador(ETipoMorador tipoMorador) => TipoMorador = tipoMorador;
    public void SetFoto(string foto) => Foto = foto;
    public void SetApartamentoId(int apartamentoId) => ApartamentoId = apartamentoId;

}
