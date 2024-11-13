using GestionDette.Model;

namespace GestionDette.Repository.Implementation;

public class DetteRepo : IntDetteRepo
{
    private readonly List<Dette> _dettes= new List<Dette>();
    
    public List<Dette> SelectAll()
    {
        return _dettes;
    }

    public Dette? SelectById(int id)
    {
        return _dettes.FirstOrDefault(d => d.Id == id);;
    }

    public void Delete(Dette dette)
    {
        _dettes.Remove(dette);
    }

    public void Insert(Dette dette)
    {
        _dettes.Add(dette);
    }

    public void Update(Dette dette)
    {
        int index = _dettes.FindIndex(d => d.Id == dette.Id);
        _dettes[index] = dette;
    }
}