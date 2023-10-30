namespace Shared.Interfaces;

public interface IDataManager<T>
{
    public event EventHandler<T> Updated;
    public T Get();
    public void Update(T newData);
}