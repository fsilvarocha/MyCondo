using MyCondo.Domain.Entities.Bloco;
using MyCondo.Domain.Interface.Bloco;
using MyCondo.Infra.Data;
using MyCondo.Infra.Repositories.Base;

namespace MyCondo.Infra.Repositories.Bloco;

public class BlocoRepository(MyCondoContext context) : BaseRepository<Blocos>(context), IBlocosRepository
{
    private readonly MyCondoContext _context1 = context;
}
