using u20211c221.Customers.Domain.Model.Aggregates;
using u20211c221.Customers.Interfaces.REST.Resources;

namespace u20211c221.Customers.Interfaces.REST.Transform;

public class ClientResourceFromEntityAssembler
{
    public static ClientResource ToClientResourceFromEntity(Client entity) =>
        new ClientResource(entity.Id, entity.Name, entity.Email); 
}