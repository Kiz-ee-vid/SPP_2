using System;

namespace Generator.Primitive
{
    public class CharGenerator : IGenerator
    {
        public Type Type => typeof(char);

        private readonly Random _random;

        public CharGenerator(Random random)
        {
            _random = random;
        }

        public object Generate()
        {
            return (char)_random.Next('A', 'z');
        }
    }
}