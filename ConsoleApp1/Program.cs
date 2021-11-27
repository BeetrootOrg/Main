namespace ConsoleApp
{
    //simple bubble algorithm
    class Program
    {
        static void Main()
        {
            int[] arr = { 800, 11, 50, 771, 649, 770, 240, 9 };

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

    }
}