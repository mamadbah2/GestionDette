using GestionDette.Model;

namespace GestionDette.Repository.Implementation;

public class ClientRepo : IntClientRepo
{
    private readonly List<Client> _clients = new List<Client>();
    public List<Client> SelectAll()
    {
        return _clients;
    }

    public Client? SelectById(int id)
    {
        return _clients.FirstOrDefault(c => c.Id == id);
    }

    public Client? SelectByName(string name)
    {
        return _clients.FirstOrDefault(c => c.Name == name);
    }

    public void Insert(Client client)
    {
        client.Id = _clients.Count;
        _clients.Add(client);
    }

    public void Update(Client client)
    {
        int index = _clients.FindIndex(c => c.Id == client.Id);
        if (index != -1)
            _clients[index] = client;
    }

    public void Delete(Client client)
    {
        _clients.Remove(client);
    }
}