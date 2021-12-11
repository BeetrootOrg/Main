using System;
using System.Text;
namespace FirstProject
{
    class Animal
    class Program
    {
        public int NumOfPaws { get; set; }
        public int Length { get; set; }
        public virtual bool HasTale { get; set; }
        public string Color { get; set; }

        public virtual string MakeNoise() => "Unknown Animal says ???";
        public void Eat() => Console.WriteLine("Unknwon Animal eats ???");

        public override bool Equals(object obj) => Equals(obj as Animal);

        protected virtual bool Equals(Animal animal)
        {
            if (animal == null)
            {
                return false;
            }
        static void Main()
        {
            string str1 = "gav1";
            string str2 = "Hello";

            if (ReferenceEquals(this, animal))
            {
                return true;
            }
            //COMPARE
            Console.WriteLine("Compare work: ");
            Console.WriteLine(Compare(str1, str2)+"\n");

            if (this.GetType() != animal.GetType())
            {
                return false;
            }
            //ANALYZE
            Console.WriteLine("Analyze work: ");
            Console.WriteLine(Analyze(str1)+"\n");

            //SORT
            Console.WriteLine("Sort work: ");
            string st = "Hello";
            Console.WriteLine(SortString(st) + "\n");

            //DUPLICATE
            Console.WriteLine("Duplicate work: ");
            foreach (char str in Duplicate("Abbccdee"))
            {
                Console.WriteLine(str);
            }


        public override int GetHashCode() => NumOfPaws.GetHashCode() ^
            Length.GetHashCode() ^
            HasTale.GetHashCode() ^
            Color.GetHashCode();

        public override string ToString() => $"{nameof(NumOfPaws)} = {NumOfPaws}; " +
            $"{nameof(Length)} = {Length}; " +
            $"{nameof(HasTale)} = {HasTale}; " +
            $"{nameof(Color)} = {Color}";
    }

    class Cat : Animal
    {
        public string Breed { get; set; }
        public override bool HasTale { get => true; set => throw new NotImplementedException("Cannot change tale"); }

        public override string MakeNoise() => "Cat says 'meow'";
        public new void Eat() => Console.WriteLine("Cat eats fish");
    }
        }
        //1 task(compare)
        static bool Compare(string a, string b)
        {
            char[] str1 = a.ToCharArray();
            char[] str2 = b.ToCharArray();
            if (str1.Length != str2.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    if (str1[i] != str2[i])
                    {
                        return false;
                    }

                }
                return true;
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
                NumOfPaws = 4
            };

            Console.WriteLine("ANIMAL");
            ShowAnimal(animal);
        }
        //2 task (analyze)
        static string Analyze(string str)
        {
            int alphChars = 0;
            int digits = 0;
            int specSymb = 0;
            str.ToCharArray();
            foreach (var item in str)
            {
                if (Char.IsDigit(item))
                {
                    digits++;
                }
                if (Char.IsLetter(item))
                {
                    alphChars++;
                }
                else specSymb++;
            }

            Console.WriteLine("CAT");
            ShowAnimal(cat);
            string res = $"Alphabetic chars in string: {alphChars}\n Digits in string:{digits}\n Special symbols in string: {specSymb} ";

            Console.WriteLine(cat.HasTale);
            return res;

            Console.WriteLine(animal);
            Console.WriteLine(cat);
        }
        static string SortString(string str)
        {

            char[] tempStr = str.Replace(" ", "").ToLower().ToCharArray();

            var animal2 = new Animal
            {
                Color = "red",
                HasTale = true,
                NumOfPaws = 5,
                Length = -1
            };
            for (int i = 0; i < tempStr.Length; i++)
            {
                for (int j = 0; j < tempStr.Length - 1 - i; j++)
                {
                    if (tempStr[j] > tempStr[j + 1])
                    {
                        char temp = tempStr[j + 1];
                        tempStr[j + 1] = tempStr[j];
                        tempStr[j] = temp;
                    }
                }
            }
            return String.Join("", tempStr);
        }
        //решение duplicate подсмотрел у коллег 
        static char[] Duplicate(string str)
        {
            char[] tempStr = str.Replace(" ", "").ToLower().ToCharArray();

            StringBuilder strCopy = new StringBuilder(str.Replace(" ", "").ToLower());
            StringBuilder result = new StringBuilder();

            Console.WriteLine(animal == animal2);
            Console.WriteLine(animal.Equals(animal2));
            Console.WriteLine(animal.Equals(new object()));
        }
            for (int i = 0; i < str.Length; i++)
            {
                int currentLenght = strCopy.Length;

        static void ShowAnimal(Animal animal)
        {
            Console.WriteLine(animal.MakeNoise());
            animal.Eat();
        }
    }
}
                if (currentLenght - strCopy.Replace(str[i].ToString(), "").Length > 1)
                {
                    result.Append(str[i]);
                }
            }
            return result.ToString().ToCharArray();


        }


    }
}
