using MyCondo.Domain.Transfer.DataTransfer.Base;
using MyCondo.Domain.Utils.Enumeradores;

namespace MyCondo.Domain.Transfer.DataTransfer.Condominio.Request;

public class CondominiosAtualizarRequest
{
    public virtual string Nome { get; set; }
    public virtual string Cnpj { get; set; }
    public virtual ETipoCondominio TipoCondominio { get; set; } = new ETipoCondominio();
    public virtual string? Logo { get; set; }
    public virtual double AreaTotal { get; set; } = double.MinValue;

    public virtual string? Cep { get; set; }
    public virtual string? Cidade { get; set; }
    public virtual string? Uf { get; set; }
    public virtual string? Bairro { get; set; }
    public virtual string? Logradouro { get; set; }
    public virtual string? Numero { get; set; }
    public virtual string? Complemento { get; set; }
}
