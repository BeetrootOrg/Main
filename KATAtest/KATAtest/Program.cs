using System;
using System.Collections.Generic;
using System.Linq;

namespace KATAtest
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
        //public static int MakeNegative(int number)
        //{
        //    if (number <= 0)
        //    {
        //         return number;
        //    }
        //         return -number;
        //}
        //public static IEnumerable<string> FriendOrFoe(string[] names)
        //{
        //    // Good luck!
        //    foreach (var item in names)
        //    {
        //        int count = item.Length;
        //        if (count == 4)
        //        {

        //           yield return item;

        //        }
        //    }
        //}
        //public static int Paperwork(int n, int m)
        //{
        //    //#Happy Coding! ^_^
        //    if (n < 0 || m < 0)
        //    {
        //        return 0;
        //    }
        //        return m * n;
        //}
        //public static bool Hero(int bullets, int dragons)
        //{
        //    //Do Some Magic...
        //    if (bullets < (dragons * 2))
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        //public static string boolToWord(bool word)
        //{
        //    //TODO
        //    if (word == true)
        //    {
        //       return "Yes";
        //    }
        //    return "No";
        //}
        //public static int CountSheeps(bool[] sheeps)
        //{
        //    //TODO
        //       int count = 0;

        //        for (int i = 0; i < sheeps.Length; i++)
        //        {
        //            if (sheeps[i] == true)
        //            {
        //                count += 1;
        //            }
        //        }
        //        return count;
        //}
        //public static long[] Digitize(long n)
        //{
        //    return n.ToString()
        //       .Reverse()
        //       .Select(t => Convert.ToInt64(t.ToString()))
        //       .ToArray();
        //}
        //public static bool Check(object[] a, object x)
        //{
        //    bool res = a.Contains(x);
        //    return res;
        //}
        //public static int PositiveSum(int[] arr)
        //{
        //    int temp = 0;


        //    foreach (var item in arr)
        //    {
        //        if (item > 0)
        //            temp = temp + item;
        //    }
        //    return temp;
        //}
        //public int Min(int[] list)
        //{
        //    int minValue = list[0];

        //    for (int i = 0; i < list.Length; i++)
        //    {
        //        if (list[i] < minValue)
        //        {
        //            minValue = list[i];
        //        }
        //    }
        //    return minValue;
        //}

        //public int Max(int[] list)
        //{
        //    int maxValue = list[0];

        //    for (int i = 0; i < list.Length; i++)
        //    {
        //        if (list[i] > maxValue)
        //        {
        //            maxValue = list[i];
        //        }
        //    }
        //    return maxValue;

        //}
        //public static string Greet()
        //{
        //    char[] hello = { 'H', 'e', 'l', 'l', 'o', 'W', 'o', 'r', 'l', 'd'};
        //    string txt = new string(hello);
        //    return txt;
        //}
        //public static int DuplicateCount(string str)
        //{
        //    str = str.ToLower();
        //    char[] strChar = str.ToCharArray();
        //    int count = 1;
        //    for (int i = 0; i < strChar.Length -1; i++)
        //    {
        //        for (int j = i+1; j < strChar.Length; j++)
        //        {
        //            if (strChar[i] == strChar[j])
        //            {
        //                count++;
        //            }
        //            else
        //            {
        //                continue;
        //            }
        //        }
        //        if (count > 1)
        //        {
        //            i += (count - 1);
        //        }
        //    }
        //    return count;
        //}
        //public static int DuplicateCount(string str)
        //{
        //    //str = "ПомОгите";

        //    str = str.ToLower();

        //    char[] chars = str.ToCharArray();


        //    Dictionary<char, int> charDictionary = new Dictionary<char, int>();

        //    foreach (var item in chars)
        //    {
        //        if (charDictionary.ContainsKey(item))
        //        {
        //            charDictionary[item] = charDictionary[item] + 1;
        //        }
        //        else
        //        {
        //            charDictionary.Add(item, 1);
        //        }
        //    }
        //        var keys = new HashSet<char>(charDictionary.Keys);
        //        int temp = 0;

        //        foreach (var item in keys)
        //        {
        //            if (charDictionary[item]> 1)
        //            {
        //                temp = charDictionary[item];
        //                Console.WriteLine(temp);
        //            }
        //        }
        //    return temp;
        //}
        //public static int DuplicateCount(string str)
        //{
        //    int count = str.ToLower().GroupBy(x => x).Select(y => y).Where(z => z.Count() > 1).Count();
        //    return count;

        //}
        //public static String Accum(string s)
        //{
        //    string result = String.Empty;
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        char c = s[i];
        //        result += char.ToUpper(c);
        //        result += new String(char.ToLower(c), i);
        //        if (i < s.Length - 1)
        //        {
        //            result += "-";
        //        }
        //    }
        //    return result;
        //}
        //public static string Solution(string str)
        //{
        //    string rev = "";

        //    for (int i = str.Length - 1; i >= 0; i--)

        //    {
        //        rev += str[i];
        //    }
        //    return rev;
        //}
    }
}