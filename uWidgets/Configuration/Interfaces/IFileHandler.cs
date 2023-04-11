namespace uWidgets.Configuration.Interfaces;

public interface IFileHandler<T>
{
    T Get();
    void Save(T newData);
}