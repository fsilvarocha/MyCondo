using MyCondo.Domain.Entities.Base;

namespace MyCondo.Domain.Entities.Condominio;

public class Condominios : BaseEntity
{
    public string Nome { get; set; }
    public string Cep { get; set; }
}
