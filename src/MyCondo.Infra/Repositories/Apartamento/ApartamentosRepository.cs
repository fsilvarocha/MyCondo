using MyCondo.Domain.Entities.Apartamento;
using MyCondo.Domain.Interface.Apartamento;
using MyCondo.Infra.Data;
using MyCondo.Infra.Repositories.Base;

namespace MyCondo.Infra.Repositories.Apartamento;

public class ApartamentosRepository(MyCondoContext context) : BaseRepository<Apartamentos>(context), IApartamentosRepository
{
    private readonly MyCondoContext _context = context;
}
