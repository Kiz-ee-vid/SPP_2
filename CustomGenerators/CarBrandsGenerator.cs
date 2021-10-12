using System;
using Generator;
using System.Collections.Generic;

namespace CustomGenerators
{
    public class CarBrandsGenerator : IGenerator
    {
        public Type Type => typeof(string);

        private readonly Random _random = new();
        private readonly List<string> CarBrands;

        public CarBrandsGenerator()
        {
            CarBrands = new List<string>()
            {
                "Audi", "Lada Vesta", "Toyota", "Ford", "Nissan", "Renault","BMW","Mersedes"
            };
        }

        public object Generate()
        {
            return CarBrands[_random.Next(CarBrands.Count)];
        }
    }
}
