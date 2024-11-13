using GestionDette.Model;

namespace GestionDette.Service;

public interface IntClientServ
{
    List<Client> GetClients();
    Client? GetClientById(int id);
    void AddClient(Client client);
    void RemoveClient(Client client);
    void UpdateClient(Client client);
}