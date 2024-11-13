using GestionDette.Model;

namespace GestionDette.Views.Implementation;

public class ClientView : IntClientView
{
    public void ShowClients(List<Client> clients)
    {
        foreach (var client in clients)
        {
            Console.WriteLine(client);
        }
    }

    public Client CreateNewClient()
    {
        Console.WriteLine("Creating new client");
        Console.Write("Enter name: ");
        string name = Console.ReadLine()!;
        Console.Write("Enter telephone number: ");
        string phone = Console.ReadLine()!;
        Console.Write("Enter address: ");
        string address = Console.ReadLine()!;
        Console.Write("Enter your mail");
        string mail = Console.ReadLine()!;
            Console.Write("Would you append a debt : [Y/N]?");
            string answer = Console.ReadLine()!.ToUpper();
            Client client = new (name, phone, address, mail);
            if (answer.Equals("Y"))
            {
                do
                {
                    Console.Write("Enter amount of debt : ");
                    float amount = float.Parse(Console.ReadLine()!);
                    Dette dette = new Dette();
                    dette.Montant = amount;
                    client.AddDette(dette);
                    Console.Write("Would you append a debt : [Y/N]?");
                    answer = Console.ReadLine()!.ToUpper();
                } while (answer.Equals("Y"));
            }

        return client;
    }

    public int DeleteClient()
    {
        Console.WriteLine("Enter the id of the client you want to delete: ");
        int id = int.Parse(Console.ReadLine()!);
        return id;
    }
}