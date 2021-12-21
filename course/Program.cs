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
        public static List<Pool> _pools;
        static void Main()
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
            Console.WriteLine($"title is {poolName} and options length is {poolOptions.Length}");
            if (CheckPoolOptionsValidity(poolOptions))
            {
                throw new Exception("You have entered invalid options. Add more options or use unique ones.");
            }
            var pool = new VotePool(poolName, poolOptions);
            _pools.Add(pool);
            Console.WriteLine("Your pool was created. Thank you!");
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
                ShowPool(selectedPoolIndex);
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
            Console.WriteLine(_pools[poolIndex].Name);
            foreach (var option in _pools[poolIndex].Body)
            {
                Console.WriteLine(option);
            }
        }

        private static bool CheckPoolOptionsValidity(string[] options)
        {
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
