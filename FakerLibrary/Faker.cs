using System;
using Generator;

namespace FakerLibrary
{
    public class Faker
    {
        private readonly IFakerConfig _config;

        public T Create<T>()
        {
            var instance = Create(typeof(T));
            return instance != null ? (T)instance : default;
        }

        private object Create(Type type)
        {
            object generated;

            var generator = DictionaryGenerator.GetGenerator(type);
            if (generator != null)
            {
                return generator.Generate();
            }

            return null;
        }



        public Faker(IFakerConfig config)
        {
            _config = config;
        }



    }
}