using MyCondo.Domain.Entities.Condominio;
using MyCondo.Domain.Interface.Condominio;
using MyCondo.Infra.Data;
using MyCondo.Infra.Repositories.Base;

namespace MyCondo.Infra.Repositories.Condominio;

public class CondominiosRepository(MyCondoContext context) : BaseRepository<Condominios>(context), ICondominiosRepository
{
    private readonly MyCondoContext _context = context;
}
