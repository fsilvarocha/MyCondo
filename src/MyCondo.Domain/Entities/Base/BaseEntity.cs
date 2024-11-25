namespace MyCondo.Domain.Entities.Base;

public class BaseEntity
{
    public int Id { get; protected set; }
    public Guid Tenante { get; protected set; }
    public DateTime DataCriacao { get; protected set; } = DateTime.Now;
    public DateTime? DataAtualizado { get; protected set; }
}
