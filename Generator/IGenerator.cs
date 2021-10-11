using System;

namespace Generator
{
    public interface IGenerator
    {
        Type Type { get; }
        object Generate();
    }

}