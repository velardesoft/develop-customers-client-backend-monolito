using u20211c221.Customers.Domain.Model.Aggregates;
using u20211c221.Customers.Domain.Model.Commands;

namespace u20211c221.Customers.Domain.Services;

public interface IClientCommandService
{
    Task<Client?> Handle(CreateClientCommand command);
    Task<Client?> Handle(UpdateClientCommand command); 
    Task<bool> Handle(DeleteClientCommand command);
}