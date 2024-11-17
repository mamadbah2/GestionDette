namespace GestionDette.Core;

public interface IDataAccess
{
    void OpenConnection(); 
    void CloseConnection();
    
    void ExecuteNonQuery(string sql, Dictionary<string, object> parameters = null);
    List<Dictionary<string, object>> ExecuteQuery(string sql, Dictionary<string, object> parameters = null);
}