using GestionDette.Model;

namespace GestionDette.Repository;

public interface IntDetteRepo
{
    List<Dette> SelectAll();
    Dette? SelectById(int id);
    void Delete(Dette dette);
    void Update(Dette dette);
    void Insert(Dette dette);
}