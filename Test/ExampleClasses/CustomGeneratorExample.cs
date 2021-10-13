namespace Test.ExampleClasses
{
    class CustomGeneratorExample
    {
        public string CarBrands { get; set; }

        public string RandomString { get; set; }

        public CustomGeneratorExample(string CarBrand)
        {
            CarBrands = CarBrand;
        }
    }
}
