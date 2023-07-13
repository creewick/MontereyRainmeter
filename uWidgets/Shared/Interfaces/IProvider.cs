namespace Shared.Interfaces;

public interface IProvider<T>
{
    public T Get();
    public void Update(T newData);
}