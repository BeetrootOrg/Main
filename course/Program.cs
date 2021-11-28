using System.Text;

namespace Course
{
    class Course
    {
        static bool Compare(string strF, string strS)
        {
            if (strF.Length != strS.Length)
            {
                return false;
            }

            for (int i = 0; i < strF.Length; i++)
            {
                if (strF[i] != strS[i])
                {
                    return false;
                }
            }

            return true;
        }
        static void Analyze(string text, out int alpbets, out int digits, out int specialC)
        {
            alpbets = 0;
            digits = 0;
            specialC = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLetter(text[i]))
                {
                    alpbets++;
                } else if (Char.IsDigit(text[i]))
                {
                    digits++;
                } else
                {
                    specialC++;
                }
            }
        }
        static string Sort(string textToSort)
        {
            char[] letters = textToSort.ToLower().ToCharArray();
            Array.Sort(letters);
            return new string(letters);
        }
        static char[] Duplicate(string textToCheck)
        {
            StringBuilder stringBuilder = new StringBuilder("");
            string sortedString = Sort(textToCheck);
            for (int i = 0; i < sortedString.Length - 1; i++)
            {
                if (sortedString[i] == sortedString[i + 1] && stringBuilder.ToString().IndexOf(sortedString[i]) == -1)
                {
                    stringBuilder.Append(sortedString[i]);
                }
            }
            return stringBuilder.ToString().ToCharArray();
        }
        static void PrintArray(char[] arrToPrint)
        {
            Array.ForEach(arrToPrint, (el) => Console.WriteLine(el));
        }
        public static void Main()
        {
            Console.WriteLine(Compare("Everything is fine", "Everything is Fine"));

            Analyze("Some random stuff 4 you to analyzE!@#", out int alphabet, out int digits, out int specialC);
            Console.WriteLine($"Text contain {alphabet} letters, {digits} digits and {specialC} special characters");

            Console.WriteLine(Sort("Wonderfull"));

            Console.WriteLine("Duplicates in word `Hello`:");
            PrintArray(Duplicate("Hello"));
        }
    }
}
