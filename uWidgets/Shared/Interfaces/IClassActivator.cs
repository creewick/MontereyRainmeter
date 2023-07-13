using System;

namespace Shared.Interfaces;

public interface IClassActivator
{
    public object Activate(string assemblyPath, Type? parentType = null, string? className = null, params object[] args);
    public object Activate(Type type, params object[] args);
    public Type GetType(string assemblyPath, Type? parentType = null, string? className = null);
}