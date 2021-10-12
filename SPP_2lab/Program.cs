using System;
using FakerLibrary;
using System.Collections.Generic;
using System.Text.Json;
using CustomGenerators;

namespace SPP_2lab
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new FakerConfig();

            config.Add<C, string, CarBrandsGenerator>(c => c.Name);
            var faker = new Faker(config);

            var user = faker.Create<A>();

            var jsonOptions = new JsonSerializerOptions() { IncludeFields = true, WriteIndented = true };
            var json = JsonSerializer.Serialize(user, jsonOptions);
            Console.WriteLine(json);
        }
    }


    internal class A
    {
        public double DoubleProperty { get; }
        public short ShortField;

        public B B;

        public A(B b, double doubleProperty)
        {
            B = b;
            DoubleProperty = doubleProperty;
        }
    }

    internal class B
    {
        public char CharProperty { get; set; }
        public byte ByteField;

        public C C;

        public B(C c)
        {
            C = c;
        }
    }

    internal class C
    {
        public List<DateTime> DatesProperty { get; set; }
        public string RandomString { get; set; }
        public string Name;
        public A A;

    }

}
