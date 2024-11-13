using GestionDette.Model;

namespace GestionDette.Service;

public interface IntDetteServ
{
    List<Dette> GetDettes();
    Dette? GetDetteById(int id);
    void AddDette(Dette dette);
    void RemoveDette(Dette dette);
    void UpdateDette(Dette dette);
    
}