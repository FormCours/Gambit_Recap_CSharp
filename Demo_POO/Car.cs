namespace Demo_02_POO
{
    public class Car : IDisposable
    {
        public int Id;
        public string Brand { get; set; }
        public string? Model { get; set; }

        public Car(int id, string brand, string? model = null)
        {
            Id = id;
            Brand = brand;
            Model = model;
        }

        void IDisposable.Dispose()
        {
            Console.WriteLine($"Dispose : {Brand} {Model}");
            Console.WriteLine();
        }
    }
}
