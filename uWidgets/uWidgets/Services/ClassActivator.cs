using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Shared.Interfaces;

namespace uWidgets.Services;

public class ClassActivator : IClassActivator
{
    private readonly IServiceProvider serviceProvider;

    public ClassActivator(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public object Activate(string assemblyPath, Type? parentType = null, string? className = null, params object[] args)
    {
        var type = GetType(assemblyPath, parentType, className);

        return Activate(type, args);
    }
    
    public object Activate(Type type, params object[] args)
    {
        try
        {
            return ActivatorUtilities.CreateInstance(serviceProvider, type, args);
        }
        catch (Exception e)
        {
            throw new InvalidOperationException($"Failed to create an instance of type {type.FullName}", e);
        }
    }

    public Type GetType(string assemblyPath, Type? parentType = null, string? className = null)
    {
        var assembly = GetAssembly(assemblyPath);
        
        return GetType(assembly, parentType, className);
    }

    private static Assembly GetAssembly(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException($"Assembly file not found: {path}");

        try
        {
            return Assembly.LoadFile(path);
        }
        catch (Exception e)
        {
            throw new InvalidOperationException($"Failed to load assembly from file: {path}", e);
        }
    }

    private static Type GetType(Assembly assembly, Type? parentType = null, string? className = null)
    {
        var type = assembly
            .GetTypes()
            .FirstOrDefault(type => (parentType == null || type.IsAssignableTo(parentType)) &&
                                    (className == null || type.Name == className));

        if (type == null)
            throw new ArgumentException($"Suitable class for {parentType} not found in assembly {assembly.FullName}");

        return type;
    }
}