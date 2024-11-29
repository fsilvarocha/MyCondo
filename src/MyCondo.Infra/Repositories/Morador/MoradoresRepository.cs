using MyCondo.Domain.Entities.Morador;
using MyCondo.Domain.Interface.Morador;
using MyCondo.Infra.Data;
using MyCondo.Infra.Repositories.Base;

namespace MyCondo.Infra.Repositories.Morador;

public class MoradoresRepository(MyCondoContext context) : BaseRepository<Moradores>(context), IMoradoresRepository
{
    private readonly MyCondoContext _context = context;
}
