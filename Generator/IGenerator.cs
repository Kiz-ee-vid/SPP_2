using System;

namespace Generator
{
    public interface IGenerator<out T, in TU>
    {
        T Generate();

        T Generate(TU min, TU max);
    }
}
