using GestionDette.Model;

namespace GestionDette.Views;

public interface IntClientView
{
    void ShowClients(List<Client> clients);
    Client CreateNewClient();
    int DeleteClient();
}