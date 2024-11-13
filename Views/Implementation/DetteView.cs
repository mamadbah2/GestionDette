using GestionDette.Model;

namespace GestionDette.Views.Implementation;

public class DetteView : IntDetteView
{
    public void ShowDettes(List<Dette> dettes)
    {
        foreach (var dette in dettes)
        {
            Console.WriteLine(dette);
        }
    }
}