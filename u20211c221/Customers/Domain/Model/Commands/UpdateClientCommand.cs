namespace u20211c221.Customers.Domain.Model.Commands;

public record UpdateClientCommand(int Id, string Name, string Email);