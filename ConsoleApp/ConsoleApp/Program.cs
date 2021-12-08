namespace ConsoleApp
{
    class Animal
    {
        public int NumOfPaws { get; set; }
        public int Length { get; set; }
        public bool HasTale { get; set; }
        public string Color { get; set; }

        public string MakeNoise() => "Unknown Animal says ???";
    }

    class Cat : Animal
    {
    }

    class Program
    {
        static void Main()
        {
            var animal = new Animal
            {
                Color = "red",
                HasTale = true,
                NumOfPaws = 5,
                Length = -1
            };

            var cat = new Cat
            {
                Color = "black",
                Length = 30,
                NumOfPaws = 4,
                HasTale = true
            };

            System.Console.WriteLine(animal.MakeNoise());
            System.Console.WriteLine(cat.MakeNoise());
        }
    }
}