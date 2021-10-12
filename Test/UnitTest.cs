using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using FakerLibrary;
using Test.ExampleClasses;
using CustomGenerators;

namespace Test
{
    public class Tests
    {
        private readonly Faker _faker = new();

        [Test]
        public void TestGenerateImplementedPrimitive()
        {
            var primitive = _faker.Create<int>();
            Assert.AreEqual(typeof(int), primitive.GetType());
            Assert.AreNotEqual(default, primitive);
        }

        [Test]
        public void TestGenerateNotImplementedPrimitive()
        {
            var primitive = _faker.Create<sbyte>();
            Assert.AreEqual(typeof(sbyte), primitive.GetType());
            Assert.AreEqual(default(sbyte), primitive);
        }

        [Test]
        public void TestGenerateImplementedSystemType()
        {
            var system = _faker.Create<DateTime>();
            Assert.AreEqual(typeof(DateTime), system.GetType());
            Assert.AreNotEqual(default, system);
        }

        [Test]
        public void TestGenerateNotImplementedSystemType()
        {
            var system = _faker.Create<Guid>();
            Assert.AreEqual(typeof(Guid), system.GetType());
            Assert.AreEqual(default(Guid), system);
        }

        [Test]
        public void TestGenerateListWithPrimitive()
        {
            var list = _faker.Create<List<ulong>>();
            Assert.AreEqual(typeof(List<ulong>), list.GetType());
            Assert.AreEqual(typeof(ulong), list.GetType().GetGenericArguments().Single());
            Assert.True(list.Count > 0);
        }

        [Test]
        public void TestGenerateListWithSystemType()
        {
            var list = _faker.Create<List<DateTime>>();
            Assert.AreEqual(typeof(List<DateTime>), list.GetType());
            Assert.AreEqual(typeof(DateTime), list.GetType().GetGenericArguments().Single());
            Assert.True(list.Count > 0);
        }

        [Test]
        public void TestGenerateClass()
        {
            var generatedClass = _faker.Create<ExampleClass>();
            Assert.AreNotEqual(default(char), generatedClass.Char);
            Assert.AreNotEqual(default(string), generatedClass.String);
            Assert.AreNotEqual(default(decimal), generatedClass.Decimal);
            Assert.AreNotEqual(default(int), generatedClass.Int);
            Assert.AreNotEqual(default(long), generatedClass.Long);
            Assert.AreNotEqual(default(ulong), generatedClass.Ulong);
            Assert.AreNotEqual(default(DateTime), generatedClass.DateTime);
        }

        [Test]
        public void TestCycleDependencyResolver()
        {
            var generatedClass = _faker.Create<DependencyEx>();

            Assert.AreEqual(default, generatedClass.Foo.List[0].FooBar.Foo);
            Assert.AreEqual(default, generatedClass.Foo.List[1].FooBar.Foo);
        }

        [Test]
        public void TestCustomGenerator()
        {
            var config = new FakerConfig();
            config.Add<CustomGeneratorExample, string, CarBrandsGenerator>(c => c.Name);
            var faker = new Faker(config);

            var generatedClass = faker.Create<CustomGeneratorExample>();

            var cars = new List<string>() { "Audi", "Lada Vesta", "Toyota", "Ford", "Nissan", "Renault", "BMW", "Mersedes" };

            Assert.True(cars.Contains(generatedClass.Name));

            Assert.False(cars.Contains(generatedClass.RandomString));
        }
    }
}