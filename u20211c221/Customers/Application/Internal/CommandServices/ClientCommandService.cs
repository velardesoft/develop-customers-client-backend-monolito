using u20211c221.Customers.Domain.Model.Aggregates;
using u20211c221.Customers.Domain.Model.Commands;
using u20211c221.Customers.Domain.Repositories;
using u20211c221.Customers.Domain.Services;
using u20211c221.Customers.Infrastructure.Persistence.EFC.Repositories;
using u20211c221.Shared.Domain.Repositories;

namespace u20211c221.Customers.Application.Internal.CommandServices;

public class ClientCommandService (IClientRepository clientRepository, IUnitOfWork unitOfWork) : IClientCommandService
{
    public async Task<Client?> Handle(CreateClientCommand command)
    {
        var client = new Client(command.Name, command.Email);
        await clientRepository.AddAsync(client);
        await unitOfWork.CompleteAsync();
        return client; 
    }

    public async Task<Client?> Handle(UpdateClientCommand command)
    {
        var client = await clientRepository.FindByIdAsync(command.Id);
        if (client == null) return null;
        client.Update(command.Name, command.Email);
        clientRepository.Update(client);
        await unitOfWork.CompleteAsync();
        return client;
    }

    public async Task<bool> Handle(DeleteClientCommand command)
    {
        var client = await clientRepository.FindByIdAsync(command.Id);
        if (client == null) return false;
        clientRepository.Remove(client);
        await unitOfWork.CompleteAsync();
        return true;
    }
}