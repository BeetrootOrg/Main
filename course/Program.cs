namespace Course
{
    public abstract class Pool
    {
        public string Name { get; set; }
        public Dictionary<string, int> Body { get; set; }
    }

    public class VotePool : Pool
    {
        public VotePool(string name, string[] options)
        {
            Name = name;
            Body = new Dictionary<string, int>();
            foreach (var option in options) Body.Add(option, 0);
        }
    }

    class Course
    {
        public static List<Pool> _pools = new List<Pool>();
        static void Main()
        {

            while (true)
            {
                Menu();
            }
        }

        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Phone Book Application!\n");
            Console.WriteLine("\tMenu");
            Console.WriteLine("\t1. Create pool");
            Console.WriteLine("\t2. Show pool results");
            Console.WriteLine("\t3. Vote for something");
            Console.WriteLine("\t0. Exit");

            ConsoleKeyInfo ck = Console.ReadKey();

            switch (ck.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    CreatePool();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ShowPools();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    // SearchByName();
                    break;
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    Exit();
                    break;
            }
        }

        private static void CreatePool()
        {
            Console.Clear();
            Console.WriteLine("Please, enter the name of the pool");
            var poolName = Console.ReadLine();
            Console.WriteLine("Please, enter coma-separated options for your pool");
            var poolOptionsText = Console.ReadLine();
            var poolOptions = poolOptionsText.Split(",");
            if (!CheckPoolValidity(poolOptionsText, poolOptions))
            {
                throw new Exception("Pool data is invalid." +
                    "The pool name must contain at least one symbol." +
                    "The options must be unique and contains at least two.");
            }
            var pool = new VotePool(poolName, poolOptions);
            _pools.Add(pool);
            Console.WriteLine("\nYour pool was created. Thank you!");
            Wait();
        }

        private static void ShowPools()
        {
            Console.Clear();
            var index = 1;
            if (_pools.Count > 0) {
                Console.WriteLine("Existing pools: \n");
                foreach (var pool in _pools)
                {
                    Console.WriteLine($"{index}. {pool.Name}");
                    ++index;
                }
                Console.WriteLine("\n \nPlease, type the pool number which you would like to see");
                bool isIndexValid = int.TryParse(Console.ReadLine(), out int selectedPoolIndex);
                if (!isIndexValid || selectedPoolIndex > _pools.Count)
                {
                    throw new Exception("The value is not a number or you've selected the non-existing pool");
                }
                ShowPool(selectedPoolIndex - 1);
            }
            else
            {
                Console.WriteLine("No pools are created yet. Please, return and create some.");
                Wait();
            }
        }

        private static void ShowPool(int poolIndex)
        {
            Console.Clear();
            Console.WriteLine($"{_pools[poolIndex].Name}\n");
            foreach (var option in _pools[poolIndex].Body)
            {
                Console.WriteLine($"Option - {option.Key}. Votes - {option.Value}");
            }
            Wait();
        }

        private static bool CheckPoolValidity(string name, string[] options)
        {
            if (name.Length == 0) return false;
            if (options.Length < 2) return false;
            string[] uniqueOptions = options.Distinct<string>().ToArray();
            if (options.Length != uniqueOptions.Length) return false;

            return true;
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }
        
        private static void Wait()
        {
            Console.WriteLine("To back to menu type Enter...");
            Console.ReadLine();
        }
    }
}
