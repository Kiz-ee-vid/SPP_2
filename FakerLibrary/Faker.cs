using System;

namespace FakerLibrary
{
    public class Faker
    {
        private readonly IFakerConfig _config;

        public Faker()
        {
        }

        public Faker(IFakerConfig config)
        {
            _config = config;
        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        private object Create(Type type)
        {

        }


    }
}