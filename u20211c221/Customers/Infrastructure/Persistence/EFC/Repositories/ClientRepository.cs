using u20211c221.Customers.Domain.Model.Aggregates;
using u20211c221.Customers.Domain.Repositories;
using u20211c221.Shared.Infrastructure.Persistence.EFC.Configuration;
using u20211c221.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace u20211c221.Customers.Infrastructure.Persistence.EFC.Repositories;

public class ClientRepository(AppDbContext context) : BaseRepository<Client>(context), IClientRepository
{
    
}