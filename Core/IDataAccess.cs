namespace GestionDette.Core;

public interface IDataAccess
{
    void OpenConnection();
    void CloseConnection();
}