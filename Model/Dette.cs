namespace GestionDette.Model;

public class Dette
{
    public int Id { get; set; }
    public float Montant { get; set; }
    public Client Client { get; set; } = new Client();
    public DateTime Date { get; set; } = DateTime.Now;

    public override string ToString()
    {
        return $"Dette Id: {Id}, Montant: {Montant}, Date: {Date}";
    }
}