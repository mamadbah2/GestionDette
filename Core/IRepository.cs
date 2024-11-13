namespace GestionDette.Core;

public interface IRepository <T>
{
    List<T> SelectAll();
    T? SelectById(int id);
    void Insert(T data);
    void Update(T data);
    void Delete(T data);
}