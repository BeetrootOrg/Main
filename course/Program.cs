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
                    ShowPools(true);
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
            if (!CheckPoolValidity(poolName, poolOptions))
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

        private static void ShowPools(bool isVoting = false)
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
                Console.WriteLine($"\n \nPlease, type the pool number which you would like to {(isVoting ? "participate" : "see")}");
                CheckIndexValidity(_pools.Count, out int selectedPoolIndex);
                if (isVoting) {
                    VoteInPool(selectedPoolIndex - 1);
                }
                else
                {
                    ShowPool(selectedPoolIndex - 1);
                }
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

        private static void VoteInPool(int poolIndex)
        {
            Console.Clear();
            Console.WriteLine($"{_pools[poolIndex].Name}\n");
            var index = 1;
            foreach (var option in _pools[poolIndex].Body)
            {
                Console.WriteLine($"{index}. {option.Key}");
                ++index;
            }
            Console.WriteLine("\nPlease, type a number of specific option.");
            CheckIndexValidity(_pools[poolIndex].Body.Count, out int selectedPoolIndex);
            var selectedOptionName = _pools[poolIndex].Body.Keys.ToArray()[selectedPoolIndex - 1];
            _pools[poolIndex].Body[selectedOptionName] = ++_pools[poolIndex].Body[selectedOptionName];
            Console.WriteLine("Your vote has been counted. Thank you!");
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

        private static void CheckIndexValidity(int maxCountToCompare, out int parsedIndex)
        {
            bool isIndexValid = int.TryParse(Console.ReadLine(), out int selectedPoolIndex);
            if (!isIndexValid || selectedPoolIndex > maxCountToCompare)
            {
                throw new Exception("The value is not a number or you've selected the non-existing option");
            }
            parsedIndex = selectedPoolIndex;
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }
        
        private static void Wait()
        {
            Console.WriteLine("\nTo back to menu type Enter...");
            Console.ReadLine();
        }
    }
}
