using u20211c221.Customers.Domain.Model.Aggregates;
using u20211c221.Customers.Domain.Model.Queries;
using u20211c221.Customers.Domain.Repositories;
using u20211c221.Customers.Domain.Services;

namespace u20211c221.Customers.Application.Internal.QueryServices;

public class ClientQueryService (IClientRepository clientRepository) : IClientQueryService
{
    public async Task<Client?> Handle(GetClientByIdQuery query) => await clientRepository.FindByIdAsync(query.Id);

    public async Task<IEnumerable<Client>> Handle(GetAllClientsQuery query) => await clientRepository.ListAsync();
}