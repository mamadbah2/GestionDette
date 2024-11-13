using GestionDette.Model;
using GestionDette.Repository;
using GestionDette.Repository.Implementation;

namespace GestionDette.Service.Implementation;

public class ClientServ : IntClientServ
{
    private readonly IntClientRepo _repository = new ClientRepo();
    public List<Client> GetClients()
    {
        return _repository.SelectAll();
    }

    public Client? GetClientById(int id)
    {
        return _repository.SelectById(id);
    }

    public void AddClient(Client client)
    {
        _repository.Insert(client);
    }

    public void RemoveClient(Client client)
    {
        _repository.Delete(client);
    }

    public void UpdateClient(Client client)
    {
        _repository.Update(client);
    }
}