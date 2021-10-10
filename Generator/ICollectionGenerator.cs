using System;

namespace Generator
{
    public interface ICollectionGenerator
    {
        Type Type { get; }
        object Generate(Type type, Type argumentType, Func<Type, object> method);
    }
}
