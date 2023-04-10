namespace uWidgets.Infrastructure.Files;

public interface IFileHandler<T>
{
    T Get();
    void Save(T newData);
}