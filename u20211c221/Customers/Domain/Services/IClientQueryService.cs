using u20211c221.Customers.Domain.Model.Aggregates;
using u20211c221.Customers.Domain.Model.Queries;

namespace u20211c221.Customers.Domain.Services;

public interface IClientQueryService
{
    Task<Client?> Handle(GetClientByIdQuery query);
    Task<IEnumerable<Client>> Handle(GetAllClientsQuery query); 
}