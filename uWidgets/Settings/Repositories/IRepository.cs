namespace uWidgets.Settings.Repositories;

public interface IRepository<T>
{
    public T Get();
    public void Save(T data);
}