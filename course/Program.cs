namespace Course
{
    class Course
    {
        static void PrintArrayElements(int[] arrayToPrint)
        {
            Array.ForEach(arrayToPrint, el => Console.WriteLine(el));
        }

        static int[] BubbleSorting(int[] arrayToSort)
        {
            for (int i = 0; i < arrayToSort.Length - 1; i++)
            {
                for (int j = 0; j < arrayToSort.Length - 1; j++)
                {
                    if (arrayToSort[j + 1] < arrayToSort[j])
                    {
                        var temp = arrayToSort[j];
                        arrayToSort[j] = arrayToSort[j + 1];
                        arrayToSort[j + 1] = temp;
                    }
                }
            }

            return arrayToSort;
        }

        public static void Main(string[] args)
        {
            PrintArrayElements(BubbleSorting(new int[] { 2, 4, 9, 3, 6, 1 }));
        }
    }
}
