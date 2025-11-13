namespace u20211c221.Customers.Domain.Model.Aggregates;

public partial class Client
{
    public int Id { get; set; }
    public string Name { get; private set; }
    public string Email { get; private set; }

    protected Client()
    {
        Name = string.Empty;
        Email = string.Empty;
    }
    
    public Client(string name, string email)
    {
        Name = name;
        Email = email;
    }
    
    public void Update(string neName, string newEmail)
    {
        Name = neName;
        Email = newEmail;
    }
}