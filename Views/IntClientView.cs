using GestionDette.Model;

namespace GestionDette.Views;

public interface IntClientView
{
    void ShowClients(List<Client> clients);
    public int EnterId();
    void ShowDettesClient(Client client);
    Client CreateNewClient();
    int DeleteClient();
}