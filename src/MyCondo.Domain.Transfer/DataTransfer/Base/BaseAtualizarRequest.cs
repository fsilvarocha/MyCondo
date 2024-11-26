namespace MyCondo.Domain.Transfer.DataTransfer.Base;

public class BaseAtualizarRequest
{
    public int Id { get; set; }
    public Guid Tenante { get; set; }
}
