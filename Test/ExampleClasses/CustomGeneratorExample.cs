namespace Test.ExampleClasses
{
    class CustomGeneratorExample
    {
        public string City { get; set; }
        public string Name { get; }

        public string RandomString { get; set; }

        public CustomGeneratorExample(string name)
        {
            Name = name;
        }
    }
}
