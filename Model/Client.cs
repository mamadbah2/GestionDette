namespace GestionDette.Model;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public string Telephone { get; set; }
    public string Address { get; set; }

    public string Email { get; set; }

    public Client() {}
     public Client(string name, string telephone, string address, string email)
    {
        Name = name;
        Telephone = telephone;
        Address = address;
        Email = email;
    }
    public IEnumerable<Dette> Dettes { get; } = new List<Dette>();

    public void AddDette(Dette dette)
    {
        Dettes.Append(dette);
        dette.Client = this;
    }
}