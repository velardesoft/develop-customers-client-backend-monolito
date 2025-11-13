using Microsoft.EntityFrameworkCore;
using u20211c221.Customers.Domain.Model.Aggregates;

namespace u20211c221.Customers.Infrastructure.Persistence.EFC.Configurations.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyClientsConfigurations(this ModelBuilder builder)
    {
        builder.Entity<Client>().HasKey(c => c.Id);
        builder.Entity<Client>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Client>().Property(c => c.Name).IsRequired(); 
        builder.Entity<Client>().Property(c => c.Email).IsRequired();
    } // ApplyCarManagementConfigurations
}