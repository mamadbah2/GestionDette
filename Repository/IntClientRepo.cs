using GestionDette.Model;

namespace GestionDette.Repository;

public interface IntClientRepo
{
    List<Client> SelectAll();
    Client? SelectById(int id);
    Client? SelectByName(string name);
    void Insert(Client client);
    void Update(Client client);
    void Delete(Client client);
}