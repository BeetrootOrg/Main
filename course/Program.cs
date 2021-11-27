namespace Course
{
    class Course
    {
        static void PrintArray(int[] arr)
        {
            Array.ForEach(arr, el => Console.WriteLine(el));
        }
        static int[] Copy(ref int[] fromCopy, ref int[] toCopy)
        {
            int index = 0;
            foreach (var item in fromCopy)
            {
                toCopy[index++] = item;
            }

            return toCopy;
        }
        public static void Main(string[] args)
        {
            int[] a = new int[] { 1, 2, 3 };
            int[] b = new int[] { 5, 6, 7 };
            PrintArray(Copy(ref a, ref b));
        }
    }
}
