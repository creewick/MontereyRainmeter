using System;

namespace Shared.Interfaces;

public interface IProvider<T>
{
    public event EventHandler<T> Updated;
    public T Get();
    public void Update(T newData);
}