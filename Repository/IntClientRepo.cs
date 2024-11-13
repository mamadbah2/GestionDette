using GestionDette.Core;
using GestionDette.Model;

namespace GestionDette.Repository;

public interface IntClientRepo : IRepository<Client>
{
    Client? SelectByName(string name);
}