using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator.Primitive
{
    public class UlongGenerator : IGenerator
    {
        public Type Type => typeof(ulong);

        private readonly Random _random;

        public UlongGenerator(Random random)
        {
            _random = random;
        }

        public object Generate()
        {
            var bytes = new byte[sizeof(ulong)];
            _random.NextBytes(bytes);
            return BitConverter.ToUInt64(bytes, 0);
        }
    }
}
