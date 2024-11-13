using GestionDette.Model;
using GestionDette.Repository;
using GestionDette.Repository.Implementation;

namespace GestionDette.Service.Implementation;

public class DetteServ : IntDetteServ
{
    private IntDetteRepo _repository = new DetteRepo();
    public List<Dette> GetDettes()
    {
        return _repository.SelectAll();
    }

    public Dette? GetDetteById(int id)
    {
        return _repository.SelectById(id);
    }

    public void AddDette(Dette dette)
    {
        _repository.Insert(dette);
    }

    public void RemoveDette(Dette dette)
    {
        _repository.Delete(dette);
    }

    public void UpdateDette(Dette dette)
    {
        _repository.Update(dette);
    }
}